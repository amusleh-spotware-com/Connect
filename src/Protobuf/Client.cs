using Connect.Common;
using System;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Threading;

namespace Connect.Protobuf
{
    public class Client: IDisposable
    {
        #region Fields

        private readonly int _maxMessageSize = 1000000;

        private readonly Events _events = new Events();

        private readonly MessagesFactory _messagesFactory = new MessagesFactory();

        private TcpClient _liveClient, _demoClient;

        private SslStream _liveStream, _demoStream;

        private bool _isAuthorized, _stopSendingHeartbeats, _stopListening;

        private ProcessStatus _liveListeningStatus, _demoListeningStatus, _sendingHeartbeatsStatus;

        #endregion Fields

        #region Properties

        public bool IsLiveConnected => _liveClient?.Client != null && _liveClient.Client.Connected;

        public bool IsDemoConnected => _demoClient?.Client != null && _demoClient.Client.Connected;

        public bool IsConnected => IsLiveConnected && IsDemoConnected;

        public ProcessStatus LiveListeningStatus => _liveListeningStatus;

        public ProcessStatus DemoListeningStatus => _demoListeningStatus;

        public ProcessStatus SendingHeartbeatsStatus => _sendingHeartbeatsStatus;

        public bool IsAuthorized => _isAuthorized;

        public Events Events => _events;

        public MessagesFactory MessagesFactory => _messagesFactory;

        #endregion Properties

        #region Connection

        public async Task Connect()
        {
            _liveClient = new TcpClient();
            _demoClient = new TcpClient();

            _liveClient.ReceiveTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;
            _liveClient.SendTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;

            _demoClient.ReceiveTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;
            _demoClient.SendTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;

            string liveURL = BaseUrls.GetBaseUrl(ApiType.Protobuf, Mode.Live);
            string demoURL = BaseUrls.GetBaseUrl(ApiType.Protobuf, Mode.Sandbox);

            await _liveClient.ConnectAsync(liveURL, BaseUrls.ProtobufPort);
            await _demoClient.ConnectAsync(demoURL, BaseUrls.ProtobufPort);

            _liveStream = new SslStream(_liveClient.GetStream(), false, new RemoteCertificateValidationCallback(CertificateValidationCallback),
                null);

            _demoStream = new SslStream(_demoClient.GetStream(), false, new RemoteCertificateValidationCallback(CertificateValidationCallback),
                null);

            _liveStream.ReadTimeout = 20000;
            _liveStream.WriteTimeout = 20000;

            _demoStream.WriteTimeout = 20000;
            _demoStream.ReadTimeout = 20000;

            await _liveStream.AuthenticateAsClientAsync(liveURL);
            await _demoStream.AuthenticateAsClientAsync(demoURL);

            StartSendingHeartbeats();

            StartListening(_liveStream, Mode.Live);
            StartListening(_demoStream, Mode.Sandbox);
        }

        public async Task Disconnect()
        {
            await StoptListening();

            await StoptSendingHeartbeats();

            await _liveStream.FlushAsync();
            await _demoStream.FlushAsync();

            _liveStream.Close();
            _demoStream.Close();

            _liveClient.Close();
            _demoClient.Close();
        }

        #endregion Connection

        #region Heart beat

        private void StartSendingHeartbeats()
        {
            _sendingHeartbeatsStatus = ProcessStatus.WaitingToRun;

            System.Timers.Timer heartbeatTimer = new System.Timers.Timer(10000);

            heartbeatTimer.Elapsed += async (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                try
                {
                    (sender as System.Timers.Timer).Stop();

                    if (IsConnected && !_stopSendingHeartbeats)
                    {
                        ProtoMessage protoMessage = MessagesFactory.CreateHeartbeatEvent();

                        await SendMessage(protoMessage, Mode.Live);
                        await SendMessage(protoMessage, Mode.Sandbox);

                        (sender as System.Timers.Timer).Start();
                    }
                    else
                    {
                        _sendingHeartbeatsStatus = ProcessStatus.Stopped;
                    }
                }
                catch (Exception ex)
                {
                    (sender as System.Timers.Timer).Stop();

                    _sendingHeartbeatsStatus = ProcessStatus.Error;

                    Events.OnHeartbeatSendingException(this, ex);
                }
            };

            heartbeatTimer.Start();
        }

        private async Task StoptSendingHeartbeats()
        {
            _stopSendingHeartbeats = true;

            _sendingHeartbeatsStatus = ProcessStatus.WaitingToStop;

            while (_sendingHeartbeatsStatus != ProcessStatus.Stopped)
            {
                await Task.Delay(100);
            }
        }

        #endregion Heart beat

        #region Listener

        private void StartListening(SslStream stream, Mode mode)
        {
            SetListeningStatus(mode, ProcessStatus.WaitingToRun);

            #pragma warning disable 4014
            Task.Run(async () =>
            {
                try
                {
                    if (!IsConnected)
                    {
                        throw new InvalidOperationException(ExceptionMessages.ClientNotConnected);
                    }

                    SetListeningStatus(mode, ProcessStatus.Running);

                    while (!_stopListening)
                    {
                        byte[] lengthArray = new byte[sizeof(int)];

                        int readBytes = 0;

                        do
                        {
                            readBytes += await stream.ReadAsync(lengthArray, readBytes, lengthArray.Length - readBytes);
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
                            readBytes += await stream.ReadAsync(message, readBytes, message.Length - readBytes);
                        }
                        while (readBytes < length);

                        InvokeMessageEvent(message);
                    }

                    SetListeningStatus(mode, ProcessStatus.Stopped);
                }
                catch (Exception ex)
                {
                    SetListeningStatus(mode, ProcessStatus.Error);

                    Events.OnListenerException(this, ex, mode);
                }
            });
            #pragma warning restore 4014
        }

        private async Task StoptListening()
        {
            _stopListening = true;

            SetListeningStatus(Mode.Live, ProcessStatus.WaitingToStop);
            SetListeningStatus(Mode.Sandbox, ProcessStatus.WaitingToStop);

            while (_liveListeningStatus != ProcessStatus.Stopped || _demoListeningStatus != ProcessStatus.Stopped)
            {
                await Task.Delay(100);
            }
        }

        private void SetListeningStatus(Mode mode, ProcessStatus processStatus)
        {
            if (mode == Mode.Live)
            {
                _liveListeningStatus = processStatus;
            }
            else
            {
                _demoListeningStatus = processStatus;
            }
        }

        #endregion Listener

        #region Send message

        public async Task SendMessage(ProtoMessage message, Mode mode)
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException(ExceptionMessages.ClientNotConnected);
            }

            byte[] messageByte = message.ToByteArray();

            byte[] length = BitConverter.GetBytes(messageByte.Length).Reverse().ToArray();

            SslStream stream = mode == Mode.Live ? _liveStream : _demoStream;

            await stream.WriteAsync(length, 0, length.Length);

            await stream.WriteAsync(messageByte, 0, messageByte.Length);
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
                case (int)ProtoOAPayloadType.PROTO_OA_GET_CTID_PROFILE_BY_TOKEN_RES:
                    {
                        ProtoOAGetCtidProfileByTokenRes ctidProfileRes = MessagesFactory.GetCtidProfileResponse(protoMessage.Payload);

                        _events.OnCtidProfileResponse(this, ctidProfileRes);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CATEGORY_RES:
                    {
                        ProtoOASymbolCategoryListRes symbolCategoryListRes = MessagesFactory.GetSymbolCategoryListResponse(protoMessage.Payload);

                        _events.OnSymbolCategoryListResponse(this, symbolCategoryListRes);

                        break;
                    }
                default:
                    break;
            }
        }

        private bool CertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return sslPolicyErrors == SslPolicyErrors.None;
        }

        public void Dispose()
        {
            _liveStream?.Dispose();
            _demoStream?.Dispose();

            _liveClient?.Dispose();
            _demoClient?.Dispose();
        }

        #endregion
    }
}