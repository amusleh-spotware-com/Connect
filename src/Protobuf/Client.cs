using Connect.Common;
using System;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Connect.Protobuf
{
    public class Client
    {
        #region Fields

        private readonly int _maxMessageSize = 1000000;

        private readonly Events _events = new Events();

        private readonly MessagesFactory _messagesFactory = new MessagesFactory();

        private TcpClient _apiClient;

        private SslStream _apiStream;

        private ProcessStatus _listenerStatus = ProcessStatus.None, _heartbeatSenderStatus = ProcessStatus.None;

        private bool _isAuthorized;

        #endregion Fields

        #region Properties

        public bool IsConnected => _apiClient?.Client != null && _apiClient.Client.Connected;

        public bool IsAuthorized => _isAuthorized;

        public Events Events => _events;

        public MessagesFactory MessagesFactory => _messagesFactory;

        public ProcessStatus ListenerStatus => _listenerStatus;

        public ProcessStatus HeartbeatSenderStatus => _heartbeatSenderStatus;

        #endregion Properties

        #region Connection

        public async Task Connect(Mode mode)
        {
            _apiClient = new TcpClient();

            _apiClient.ReceiveTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;
            _apiClient.SendTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;

            string apiURL = BaseUrls.GetBaseUrl(ApiType.Protobuf, mode);

            await _apiClient.ConnectAsync(apiURL, BaseUrls.ProtobufPort);

            _apiStream = new SslStream(
                _apiClient.GetStream(),
                false,
                new RemoteCertificateValidationCallback((
                    object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) =>
                {
                    return sslPolicyErrors == SslPolicyErrors.None;
                }),
                null);

            await _apiStream.AuthenticateAsClientAsync(apiURL);

            StartHeartbeatSending();

            StartListener();
        }

        public async Task Disconnect()
        {
            await StoptHeartbeatSending();

            await StoptListener();

            await _apiStream?.FlushAsync();

            _apiStream?.Dispose();

            _apiClient?.Close();
        }

        #endregion Connection

        #region Heart beat

        public void StartHeartbeatSending(double interval = 10000)
        {
            System.Timers.Timer heartbeatTimer = new System.Timers.Timer(interval);

            heartbeatTimer.Interval = interval;

            heartbeatTimer.Elapsed += async (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                try
                {
                    (sender as System.Timers.Timer).Stop();

                    if (IsConnected && _heartbeatSenderStatus == ProcessStatus.Running || _heartbeatSenderStatus == ProcessStatus.WaitingToRun)
                    {
                        ProtoMessage protoMessage = MessagesFactory.CreateHeartbeatEvent();

                        await SendMessage(protoMessage);
                    }
                    else
                    {
                        (sender as System.Timers.Timer).Stop();

                        _heartbeatSenderStatus = ProcessStatus.Stopped;
                    }

                    (sender as System.Timers.Timer).Start();
                }
                catch (Exception ex)
                {
                    (sender as System.Timers.Timer).Stop();

                    _heartbeatSenderStatus = ProcessStatus.Error;

                    Events.OnHeartbeatSendingStopped(this, ex);
                }
            };

            _heartbeatSenderStatus = ProcessStatus.WaitingToRun;

            heartbeatTimer.Start();
        }

        public async Task StoptHeartbeatSending()
        {
            _heartbeatSenderStatus = ProcessStatus.WaitingToStop;

            while (_heartbeatSenderStatus != ProcessStatus.Stopped)
            {
                await Task.Delay(10);
            }
        }

        #endregion Heart beat

        #region Listener

        public void StartListener()
        {
            _listenerStatus = ProcessStatus.WaitingToRun;

#pragma warning disable 4014
            Task.Run(() =>
            {
                Listener();
            });
#pragma warning restore 4014
        }

        public async Task StoptListener()
        {
            _listenerStatus = ProcessStatus.WaitingToStop;

            while (_listenerStatus != ProcessStatus.Stopped)
            {
                await Task.Delay(10);
            }
        }

        private async void Listener()
        {
            try
            {
                while (IsConnected && _listenerStatus == ProcessStatus.Running || _listenerStatus == ProcessStatus.WaitingToRun)
                {
                    byte[] lengthArray = new byte[sizeof(int)];

                    int readBytes = 0;

                    do
                    {
                        readBytes += await _apiStream.ReadAsync(lengthArray, readBytes, lengthArray.Length - readBytes);
                    }
                    while (readBytes < lengthArray.Length);

                    int length = BitConverter.ToInt32(lengthArray.Reverse().ToArray(), 0);

                    if (length <= 0)
                    {
                        continue;
                    }
                    else if (length > _maxMessageSize)
                    {
                        string exceptionMsg = $"Message length ({length}) is out of range (0 - {_maxMessageSize})";

                        throw new ArgumentOutOfRangeException(exceptionMsg);
                    }

                    byte[] message = new byte[length];

                    readBytes = 0;

                    do
                    {
                        readBytes += await _apiStream.ReadAsync(message, readBytes, message.Length - readBytes);
                    }
                    while (readBytes < length);

                    InvokeMessageEvent(message);
                }

                _listenerStatus = ProcessStatus.Stopped;
            }
            catch (Exception ex)
            {
                _listenerStatus = ProcessStatus.Error;

                Events.OnListenerStopped(this, ex);
            }
        }

        #endregion Listener

        #region Send message

        public async Task SendMessage(ProtoMessage message)
        {
            if (IsConnected)
            {
                byte[] messageByte = message.ToByteArray();

                byte[] length = BitConverter.GetBytes(messageByte.Length).Reverse().ToArray();

                await _apiStream.WriteAsync(length, 0, length.Length);

                await _apiStream.WriteAsync(messageByte, 0, messageByte.Length);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.ClientNotConnected);
            }
        }

        #endregion Others

        #region Others

        private void InvokeMessageEvent(byte[] message)
        {
            ProtoMessage protoMessage = MessagesFactory.GetMessage(message);

            _events.OnMessageReceived(this, protoMessage);

            switch (protoMessage.PayloadType)
            {
                case (int)ProtoOAPayloadType.PROTO_OA_ERROR_RES:
                    {
                        ProtoOAErrorRes protoErrorRes = MessagesFactory.GetErrorResponse(protoMessage.Payload);

                        _events.OnError(this, protoErrorRes);

                        break;
                    }
                case (int)ProtoPayloadType.HEARTBEAT_EVENT:
                    {
                        ProtoHeartbeatEvent protoHeartbeatEvent = MessagesFactory.GetHeartbeatEvent(protoMessage.Payload);

                        _events.OnHeartbeat(this, protoHeartbeatEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_AUTH_RES:
                    {
                        ProtoOAAccountAuthRes protoOAAccountAuthRes = MessagesFactory.GetAccountAuthorizationResponse(protoMessage.Payload);

                        _events.OnAccountAuthorizationResponse(this, protoOAAccountAuthRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_APPLICATION_AUTH_RES:
                    {
                        ProtoOAApplicationAuthRes protoOAApplicationAuthRes = MessagesFactory.GetApplicationAuthorizationResponse(protoMessage.Payload);

                        _isAuthorized = true;

                        _events.OnApplicationAuthResponse(this, protoOAApplicationAuthRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_CLIENT_DISCONNECT_EVENT:
                    {
                        ProtoOAClientDisconnectEvent protoOAClientDisconnect = MessagesFactory.GetClientDisconnectEvent(protoMessage.Payload);

                        _events.OnClientDisconnected(this, protoOAClientDisconnect);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_DEAL_LIST_RES:
                    {
                        ProtoOADealListRes protoOADealListRes = MessagesFactory.GetDealListResponse(protoMessage.Payload);

                        _events.OnDealListResponse(this, protoOADealListRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_RES:
                    {
                        ProtoOAAssetListRes protoOAAssetListRes = MessagesFactory.GetAssetListResponse(protoMessage.Payload);

                        _events.OnAssetListResponse(this, protoOAAssetListRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNTS_TOKEN_INVALIDATED_EVENT:
                    {
                        ProtoOAAccountsTokenInvalidatedEvent protoOAAccountsTokenInvalidatedEvent = MessagesFactory.GetAccountsTokenInvalidatedEvent(protoMessage.Payload);

                        _events.OnAccountsTokenInvalidated(this, protoOAAccountsTokenInvalidatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_CASH_FLOW_HISTORY_LIST_RES:
                    {
                        ProtoOACashFlowHistoryListRes protoOACashFlowHistoryListRes = MessagesFactory.GetCashFlowHistoryListResponse(protoMessage.Payload);

                        _events.OnCashFlowHistoryListResponse(this, protoOACashFlowHistoryListRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_EXECUTION_EVENT:
                    {
                        ProtoOAExecutionEvent protoOAExecutionEvent = MessagesFactory.GetExecutionEvent(protoMessage.Payload);

                        _events.OnExecution(this, protoOAExecutionEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_EXPECTED_MARGIN_RES:
                    {
                        ProtoOAExpectedMarginRes protoOAExpectedMarginRes = MessagesFactory.GetExpectedMarginResponse(protoMessage.Payload);

                        _events.OnExpectedMarginResponse(this, protoOAExpectedMarginRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_GET_ACCOUNTS_BY_ACCESS_TOKEN_RES:
                    {
                        ProtoOAGetAccountListByAccessTokenRes protoOAGetAccountListByAccessTokenRes = MessagesFactory.GetAccountListResponse(protoMessage.Payload);

                        _events.OnAccountListResponse(this, protoOAGetAccountListByAccessTokenRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_GET_TICKDATA_RES:
                    {
                        ProtoOAGetTickDataRes protoOAGetTickDataRes = MessagesFactory.GetTickDataResponse(protoMessage.Payload);

                        _events.OnGetTickDataResponse(this, protoOAGetTickDataRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_GET_TRENDBARS_RES:
                    {
                        ProtoOAGetTrendbarsRes protoOAGetTrendbarsRes = MessagesFactory.GetTrendbarsResponse(protoMessage.Payload);

                        _events.OnGetTrendbarsResponse(this, protoOAGetTrendbarsRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_MARGIN_CHANGED_EVENT:
                    {
                        ProtoOAMarginChangedEvent protoOAMarginChangedEvent = MessagesFactory.GetMarginChangedEvent(protoMessage.Payload);

                        _events.OnMarginChanged(this, protoOAMarginChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ORDER_ERROR_EVENT:
                    {
                        ProtoOAOrderErrorEvent protoOAOrderErrorEvent = MessagesFactory.GetOrderErrorEvent(protoMessage.Payload);

                        _events.OnOrderError(this, protoOAOrderErrorEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_RECONCILE_RES:
                    {
                        ProtoOAReconcileRes protoOAReconcileRes = MessagesFactory.GetReconcileResponse(protoMessage.Payload);

                        _events.OnReconcileResponse(this, protoOAReconcileRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SPOT_EVENT:
                    {
                        ProtoOASpotEvent protoOASpotEvent = MessagesFactory.GetSpotEvent(protoMessage.Payload);

                        _events.OnSpot(this, protoOASpotEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_SPOTS_RES:
                    {
                        ProtoOASubscribeSpotsRes protoOASubscribeSpotsRes = MessagesFactory.GetSubscribeSpotsResponse(protoMessage.Payload);

                        _events.OnSubscribeSpotsResponse(this, protoOASubscribeSpotsRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_FOR_CONVERSION_RES:
                    {
                        ProtoOASymbolsForConversionRes protoOASymbolsForConversionRes = MessagesFactory.GetSymbolsForConversionResponse(protoMessage.Payload);

                        _events.OnSymbolsForConversionResponse(this, protoOASymbolsForConversionRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_LIST_RES:
                    {
                        ProtoOASymbolsListRes protoOASymbolsListRes = MessagesFactory.GetSymbolsListResponse(protoMessage.Payload);

                        _events.OnSymbolsListResponse(this, protoOASymbolsListRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_BY_ID_RES:
                    {
                        ProtoOASymbolByIdRes protoOASymbolByIdRes = MessagesFactory.GetSymbolByIdResponse(protoMessage.Payload);

                        _events.OnSymbolByIdResponse(this, protoOASymbolByIdRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CHANGED_EVENT:
                    {
                        ProtoOASymbolChangedEvent protoOASymbolChangedEvent = MessagesFactory.GetSymbolChangedEvent(protoMessage.Payload);

                        _events.OnSymbolChanged(this, protoOASymbolChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_TRADER_RES:
                    {
                        ProtoOATraderRes protoOATraderRes = MessagesFactory.GetTraderResponse(protoMessage.Payload);

                        _events.OnTraderResponse(this, protoOATraderRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_TRADER_UPDATE_EVENT:
                    {
                        ProtoOATraderUpdatedEvent protoOATraderUpdatedEvent = MessagesFactory.GetTraderUpdatedEvent(protoMessage.Payload);

                        _events.OnTraderUpdated(this, protoOATraderUpdatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_TRAILING_SL_CHANGED_EVENT:
                    {
                        ProtoOATrailingSLChangedEvent protoOATrailingSLChangedEvent = MessagesFactory.GetTrailingSLChangedEvent(protoMessage.Payload);

                        _events.OnTrailingSLChanged(this, protoOATrailingSLChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_SPOTS_RES:
                    {
                        ProtoOAUnsubscribeSpotsRes protoOAUnsubscribeSpotsRes = MessagesFactory.GetUnsubscribeSpotsResponse(protoMessage.Payload);

                        _events.OnUnsubscribeSpotsResponse(this, protoOAUnsubscribeSpotsRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_VERSION_RES:
                    {
                        ProtoOAVersionRes protoOAVersionRes = MessagesFactory.GetVersionResponse(protoMessage.Payload);

                        _events.OnVersionResponse(this, protoOAVersionRes);

                        break;
                    }
                default:
                    break;
            }
        }

        #endregion
    }
}