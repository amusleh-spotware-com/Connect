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

        private readonly int _maxMessageSize = 10000;

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

        public async Task Connect(Mode mode = Mode.Live, Proxy proxy = Proxy.None)
        {
            _apiClient = new TcpClient();

            _apiClient.ReceiveTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;
            _apiClient.SendTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;

            string apiURL = BaseUrls.GetBaseUrl(ApiType.Protobuf, mode, proxy);

            await _apiClient.ConnectAsync(apiURL, BaseUrls.TradingPort);

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
            System.Timers.Timer heartbeatTimer = new System.Timers.Timer();

            heartbeatTimer.Interval = interval;

            heartbeatTimer.Elapsed += async (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                try
                {
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
            uint messagePayloadType = MessagesFactory.GetPayloadType(message);

            switch (messagePayloadType)
            {
                case (int)ProtoOAPayloadType.PROTO_OA_ERROR_RES:
                    {
                        ProtoOAErrorRes protoErrorRes = MessagesFactory.GetErrorResponse(message);

                        _events.OnError(this, protoErrorRes);

                        break;
                    }
                case (int)ProtoPayloadType.HEARTBEAT_EVENT:
                    {
                        ProtoHeartbeatEvent protoHeartbeatEvent = MessagesFactory.GetHeartbeatEvent(message);

                        _events.OnHeartbeat(this, protoHeartbeatEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_AUTH_RES:
                    {
                        ProtoOAAccountAuthRes protoOAAccountAuthRes = MessagesFactory.GetAccountAuthorizationResponse(message);

                        _events.OnAccountAuthorizationResponse(this, protoOAAccountAuthRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_APPLICATION_AUTH_RES:
                    {
                        ProtoOAApplicationAuthRes protoOAApplicationAuthRes = MessagesFactory.GetApplicationAuthorizationResponse(message);

                        _isAuthorized = true;

                        _events.OnApplicationAuthResponse(this, protoOAApplicationAuthRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_CLIENT_DISCONNECT_EVENT:
                    {
                        ProtoOAClientDisconnectEvent protoOAClientDisconnect = MessagesFactory.GetClientDisconnectEvent(message);

                        _events.OnClientDisconnected(this, protoOAClientDisconnect);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_DEAL_LIST_RES:
                    {
                        ProtoOADealListRes protoOADealListRes = MessagesFactory.GetDealListResponse(message);

                        _events.OnDealListResponse(this, protoOADealListRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_RES:
                    {
                        ProtoOAAssetListRes protoOAAssetListRes = MessagesFactory.GetAssetListResponse(message);

                        _events.OnAssetListResponse(this, protoOAAssetListRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNTS_TOKEN_INVALIDATED_EVENT:
                    {
                        ProtoOAAccountsTokenInvalidatedEvent protoOAAccountsTokenInvalidatedEvent = MessagesFactory.GetAccountsTokenInvalidatedEvent(message);

                        _events.OnAccountsTokenInvalidated(this, protoOAAccountsTokenInvalidatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_CASH_FLOW_HISTORY_LIST_RES:
                    {
                        ProtoOACashFlowHistoryListRes protoOACashFlowHistoryListRes = MessagesFactory.GetCashFlowHistoryListResponse(message);

                        _events.OnCashFlowHistoryListResponse(this, protoOACashFlowHistoryListRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_EXECUTION_EVENT:
                    {
                        ProtoOAExecutionEvent protoOAExecutionEvent = MessagesFactory.GetExecutionEvent(message);

                        _events.OnExecution(this, protoOAExecutionEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_EXPECTED_MARGIN_RES:
                    {
                        ProtoOAExpectedMarginRes protoOAExpectedMarginRes = MessagesFactory.GetExpectedMarginResponse(message);

                        _events.OnExpectedMarginResponse(this, protoOAExpectedMarginRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_GET_ACCOUNTS_BY_ACCESS_TOKEN_RES:
                    {
                        ProtoOAGetAccountListByAccessTokenRes protoOAGetAccountListByAccessTokenRes = MessagesFactory.GetAccountListByAccessTokenResponse(message);

                        _events.OnGetAccountListByAccessTokenResponse(this, protoOAGetAccountListByAccessTokenRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_GET_TICKDATA_RES:
                    {
                        ProtoOAGetTickDataRes protoOAGetTickDataRes = MessagesFactory.GetTickDataResponse(message);

                        _events.OnGetTickDataResponse(this, protoOAGetTickDataRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_GET_TRENDBARS_RES:
                    {
                        ProtoOAGetTrendbarsRes protoOAGetTrendbarsRes = MessagesFactory.GetTrendbarsResponse(message);

                        _events.OnGetTrendbarsResponse(this, protoOAGetTrendbarsRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_MARGIN_CHANGED_EVENT:
                    {
                        ProtoOAMarginChangedEvent protoOAMarginChangedEvent = MessagesFactory.GetMarginChangedEvent(message);

                        _events.OnMarginChanged(this, protoOAMarginChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ORDER_ERROR_EVENT:
                    {
                        ProtoOAOrderErrorEvent protoOAOrderErrorEvent = MessagesFactory.GetOrderErrorEvent(message);

                        _events.OnOrderError(this, protoOAOrderErrorEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_RECONCILE_RES:
                    {
                        ProtoOAReconcileRes protoOAReconcileRes = MessagesFactory.GetReconcileResponse(message);

                        _events.OnReconcileResponse(this, protoOAReconcileRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SPOT_EVENT:
                    {
                        ProtoOASpotEvent protoOASpotEvent = MessagesFactory.GetSpotEvent(message);

                        _events.OnSpot(this, protoOASpotEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_SPOTS_RES:
                    {
                        ProtoOASubscribeSpotsRes protoOASubscribeSpotsRes = MessagesFactory.GetSubscribeSpotsResponse(message);

                        _events.OnSubscribeSpotsResponse(this, protoOASubscribeSpotsRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_FOR_CONVERSION_RES:
                    {
                        ProtoOASymbolsForConversionRes protoOASymbolsForConversionRes = MessagesFactory.GetSymbolsForConversionResponse(message);

                        _events.OnSymbolsForConversionResponse(this, protoOASymbolsForConversionRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_LIST_RES:
                    {
                        ProtoOASymbolsListRes protoOASymbolsListRes = MessagesFactory.GetSymbolsListResponse(message);

                        _events.OnSymbolsListResponse(this, protoOASymbolsListRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_BY_ID_RES:
                    {
                        ProtoOASymbolByIdRes protoOASymbolByIdRes = MessagesFactory.GetSymbolByIdResponse(message);

                        _events.OnSymbolByIdResponse(this, protoOASymbolByIdRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CHANGED_EVENT:
                    {
                        ProtoOASymbolChangedEvent protoOASymbolChangedEvent = MessagesFactory.GetSymbolChangedEvent(message);

                        _events.OnSymbolChanged(this, protoOASymbolChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_TRADER_RES:
                    {
                        ProtoOATraderRes protoOATraderRes = MessagesFactory.GetTraderResponse(message);

                        _events.OnTraderResponse(this, protoOATraderRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_TRADER_UPDATE_EVENT:
                    {
                        ProtoOATraderUpdatedEvent protoOATraderUpdatedEvent = MessagesFactory.GetTraderUpdatedEvent(message);

                        _events.OnTraderUpdated(this, protoOATraderUpdatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_TRAILING_SL_CHANGED_EVENT:
                    {
                        ProtoOATrailingSLChangedEvent protoOATrailingSLChangedEvent = MessagesFactory.GetTrailingSLChangedEvent(message);

                        _events.OnTrailingSLChanged(this, protoOATrailingSLChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_SPOTS_RES:
                    {
                        ProtoOAUnsubscribeSpotsRes protoOAUnsubscribeSpotsRes = MessagesFactory.GetUnsubscribeSpotsResponse(message);

                        _events.OnUnsubscribeSpotsResponse(this, protoOAUnsubscribeSpotsRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_VERSION_RES:
                    {
                        ProtoOAVersionRes protoOAVersionRes = MessagesFactory.GetVersionResponse(message);

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