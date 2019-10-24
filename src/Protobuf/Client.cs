using Connect.Common.Enums;
using Connect.Common.Helpers;
using Connect.Protobuf.Factories;
using Connect.Protobuf.Helpers;
using Connect.Protobuf.Models.Parameters;
using Connect.Protobuf.Models.Parameters.Abstractions;
using Connect.Protobuf.Streams;
using System;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Connect.Protobuf
{
    public class Client : IDisposable
    {
        #region Fields

        private readonly int _maxMessageSize = 1000000;

        private TcpClient _client;

        private SslStream _stream;

        private bool _stopSendingHeartbeats, _stopListening;

        private ProcessStatus _listeningStatus, _sendingHeartbeatsStatus;

        #endregion Fields

        public Client()
        {
            Events = new Events();

            SpotStream = new SpotStream(Events);

            HeartbeatStream = new HeartbeatStream(Events);

            ExecutionStream = new ExecutionStream(Events);

            MessageStream = new MessageStream(Events);

            DepthQuotesStream = new DepthQuotesStream(Events);

            TrailingSLChangedStream = new TrailingSLChangedStream(Events);

            TraderUpdateStream = new TraderUpdateStream(Events);

            SymbolChangeStream = new SymbolChangeStream(Events);

            OrderErrorStream = new OrderErrorStream(Events);

            MarginChangeStream = new MarginChangeStream(Events);

            TokenInvalidatedStream = new TokenInvalidatedStream(Events);

            ClientDisconnectedStream = new ClientDisconnectedStream(Events);

            ErrorStream = new ErrorStream(Events);
        }

        #region Properties

        public bool IsConnected => _client?.Client != null && _client.Client.Connected;

        public bool IsAuthorized { get; private set; }

        public Events Events { get; }

        public SpotStream SpotStream { get; }

        public HeartbeatStream HeartbeatStream { get; }

        public ExecutionStream ExecutionStream { get; }

        public MessageStream MessageStream { get; }

        public DepthQuotesStream DepthQuotesStream { get; }

        public TrailingSLChangedStream TrailingSLChangedStream { get; }

        public TraderUpdateStream TraderUpdateStream { get; }

        public SymbolChangeStream SymbolChangeStream { get; }

        public OrderErrorStream OrderErrorStream { get; }

        public MarginChangeStream MarginChangeStream { get; }

        public TokenInvalidatedStream TokenInvalidatedStream { get; }

        public ClientDisconnectedStream ClientDisconnectedStream { get; }

        public ErrorStream ErrorStream { get; }

        #endregion Properties

        #region Connection

        public async Task Connect(Mode mode)
        {
            _client = new TcpClient();

            _client.ReceiveTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;
            _client.SendTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;

            string url = BaseUrls.GetBaseUrl(ApiType.Protobuf, mode);

            await _client.ConnectAsync(url, BaseUrls.ProtobufPort);

            _stream = new SslStream(_client.GetStream(), false, new RemoteCertificateValidationCallback(CertificateValidationCallback),
                null);

            await _stream.AuthenticateAsClientAsync(url);

            StartSendingHeartbeats();

            StartListening();
        }

        public async Task Disconnect()
        {
            await StoptListening();

            await StoptSendingHeartbeats();

            await _stream.FlushAsync();

            _stream.Close();

            _client.Close();
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

                    if (!_stopSendingHeartbeats)
                    {
                        HeartbeatEventParameters messageArgs = new HeartbeatEventParameters();

                        ProtoMessage protoMessage = MessagesFactory.CreateHeartbeatEvent(messageArgs);

                        await SendMessage(protoMessage);

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

        public void StartListening()
        {
            _listeningStatus = ProcessStatus.WaitingToRun;

#pragma warning disable 4014
            Task.Run(async () =>
            {
                try
                {
                    if (!IsConnected)
                    {
                        throw new InvalidOperationException(ExceptionMessages.ClientNotConnected);
                    }

                    _listeningStatus = ProcessStatus.Running;

                    while (!_stopListening)
                    {
                        byte[] lengthArray = new byte[sizeof(int)];

                        int readBytes = 0;

                        do
                        {
                            readBytes += await _stream.ReadAsync(lengthArray, readBytes, lengthArray.Length - readBytes);
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
                            readBytes += await _stream.ReadAsync(message, readBytes, message.Length - readBytes);
                        }
                        while (readBytes < length);

                        InvokeMessageEvent(message);
                    }

                    _listeningStatus = ProcessStatus.Stopped;
                }
                catch (ObjectDisposedException)
                {
                }
                catch (Exception ex)
                {
                    _listeningStatus = ProcessStatus.Error;

                    Events.OnListenerException(this, ex);
                }
            });
#pragma warning restore 4014
        }

        public async Task StoptListening()
        {
            _stopListening = true;

            _listeningStatus = ProcessStatus.WaitingToStop;

            while (_listeningStatus != ProcessStatus.Stopped)
            {
                await Task.Delay(100);
            }
        }

        #endregion Listener

        #region Send message

        public async Task SendMessage(IParameters parameters)
        {
            ProtoMessage protoMessage = MessagesFactory.CreateMessage(parameters);

            await SendMessage(protoMessage);
        }

        public async Task SendMessage(ProtoMessage message)
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException(ExceptionMessages.ClientNotConnected);
            }

            byte[] messageByte = message.ToByteArray();

            byte[] length = BitConverter.GetBytes(messageByte.Length).Reverse().ToArray();

            await _stream.WriteAsync(length, 0, length.Length);

            await _stream.WriteAsync(messageByte, 0, messageByte.Length);
        }

        #endregion Send message

        #region Others

        private void InvokeMessageEvent(byte[] message)
        {
            ProtoMessage protoMessage = MessagesFactory.GetMessage(message);

            Events.OnMessageReceived(this, protoMessage);

            switch (protoMessage.PayloadType)
            {
                case (int)ProtoOAPayloadType.PROTO_OA_ERROR_RES:
                    {
                        ProtoOAErrorRes protoErrorRes = MessagesFactory.GetErrorResponse(protoMessage.Payload);

                        Events.OnError(this, protoErrorRes);

                        break;
                    }
                case (int)ProtoPayloadType.PING_RES:
                    {
                        ProtoPingRes protoPingRes = MessagesFactory.GetPingResponse(protoMessage.Payload);

                        Events.OnPingResponse(this, protoPingRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoPayloadType.HEARTBEAT_EVENT:
                    {
                        ProtoHeartbeatEvent protoHeartbeatEvent = MessagesFactory.GetHeartbeatEvent(protoMessage.Payload);

                        Events.OnHeartbeat(this, protoHeartbeatEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_AUTH_RES:
                    {
                        ProtoOAAccountAuthRes protoOAAccountAuthRes = MessagesFactory.GetAccountAuthorizationResponse(protoMessage.Payload);

                        Events.OnAccountAuthorizationResponse(this, protoOAAccountAuthRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_APPLICATION_AUTH_RES:
                    {
                        ProtoOAApplicationAuthRes protoOAApplicationAuthRes = MessagesFactory.GetApplicationAuthorizationResponse(protoMessage.Payload);

                        IsAuthorized = true;

                        Events.OnApplicationAuthResponse(this, protoOAApplicationAuthRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_CLIENT_DISCONNECT_EVENT:
                    {
                        ProtoOAClientDisconnectEvent protoOAClientDisconnect = MessagesFactory.GetClientDisconnectEvent(protoMessage.Payload);

                        Events.OnClientDisconnected(this, protoOAClientDisconnect);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_DEAL_LIST_RES:
                    {
                        ProtoOADealListRes protoOADealListRes = MessagesFactory.GetDealListResponse(protoMessage.Payload);

                        Events.OnDealListResponse(this, protoOADealListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_RES:
                    {
                        ProtoOAAssetListRes protoOAAssetListRes = MessagesFactory.GetAssetListResponse(protoMessage.Payload);

                        Events.OnAssetListResponse(this, protoOAAssetListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ASSET_CLASS_LIST_RES:
                    {
                        ProtoOAAssetClassListRes protoOAAssetClassListRes = MessagesFactory.GetAssetClassListResponse(protoMessage.Payload);

                        Events.OnAssetClassListResponse(this, protoOAAssetClassListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNTS_TOKEN_INVALIDATED_EVENT:
                    {
                        ProtoOAAccountsTokenInvalidatedEvent protoOAAccountsTokenInvalidatedEvent = MessagesFactory.GetAccountsTokenInvalidatedEvent(protoMessage.Payload);

                        Events.OnAccountsTokenInvalidated(this, protoOAAccountsTokenInvalidatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_CASH_FLOW_HISTORY_LIST_RES:
                    {
                        ProtoOACashFlowHistoryListRes protoOACashFlowHistoryListRes = MessagesFactory.GetCashFlowHistoryListResponse(protoMessage.Payload);

                        Events.OnCashFlowHistoryListResponse(this, protoOACashFlowHistoryListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_EXECUTION_EVENT:
                    {
                        ProtoOAExecutionEvent protoOAExecutionEvent = MessagesFactory.GetExecutionEvent(protoMessage.Payload);

                        Events.OnExecution(this, protoOAExecutionEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_EXPECTED_MARGIN_RES:
                    {
                        ProtoOAExpectedMarginRes protoOAExpectedMarginRes = MessagesFactory.GetExpectedMarginResponse(protoMessage.Payload);

                        Events.OnExpectedMarginResponse(this, protoOAExpectedMarginRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_GET_ACCOUNTS_BY_ACCESS_TOKEN_RES:
                    {
                        ProtoOAGetAccountListByAccessTokenRes protoOAGetAccountListByAccessTokenRes = MessagesFactory.GetAccountListResponse(protoMessage.Payload);

                        Events.OnAccountListResponse(this, protoOAGetAccountListByAccessTokenRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_GET_TICKDATA_RES:
                    {
                        ProtoOAGetTickDataRes protoOAGetTickDataRes = MessagesFactory.GetTickDataResponse(protoMessage.Payload);

                        Events.OnTickDataResponse(this, protoOAGetTickDataRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_GET_TRENDBARS_RES:
                    {
                        ProtoOAGetTrendbarsRes protoOAGetTrendbarsRes = MessagesFactory.GetTrendbarsResponse(protoMessage.Payload);

                        Events.OnTrendbarsResponse(this, protoOAGetTrendbarsRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_MARGIN_CHANGED_EVENT:
                    {
                        ProtoOAMarginChangedEvent protoOAMarginChangedEvent = MessagesFactory.GetMarginChangedEvent(protoMessage.Payload);

                        Events.OnMarginChanged(this, protoOAMarginChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ORDER_ERROR_EVENT:
                    {
                        ProtoOAOrderErrorEvent protoOAOrderErrorEvent = MessagesFactory.GetOrderErrorEvent(protoMessage.Payload);

                        Events.OnOrderError(this, protoOAOrderErrorEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_RECONCILE_RES:
                    {
                        ProtoOAReconcileRes protoOAReconcileRes = MessagesFactory.GetReconcileResponse(protoMessage.Payload);

                        Events.OnReconcileResponse(this, protoOAReconcileRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SPOT_EVENT:
                    {
                        ProtoOASpotEvent protoOASpotEvent = MessagesFactory.GetSpotEvent(protoMessage.Payload);

                        Events.OnSpot(this, protoOASpotEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_SPOTS_RES:
                    {
                        ProtoOASubscribeSpotsRes protoOASubscribeSpotsRes = MessagesFactory.GetSubscribeSpotsResponse(protoMessage.Payload);

                        Events.OnSubscribeSpotsResponse(this, protoOASubscribeSpotsRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_FOR_CONVERSION_RES:
                    {
                        ProtoOASymbolsForConversionRes protoOASymbolsForConversionRes = MessagesFactory.GetSymbolsForConversionResponse(protoMessage.Payload);

                        Events.OnSymbolsForConversionResponse(this, protoOASymbolsForConversionRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_LIST_RES:
                    {
                        ProtoOASymbolsListRes protoOASymbolsListRes = MessagesFactory.GetSymbolsListResponse(protoMessage.Payload);

                        Events.OnSymbolsListResponse(this, protoOASymbolsListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_BY_ID_RES:
                    {
                        ProtoOASymbolByIdRes protoOASymbolByIdRes = MessagesFactory.GetSymbolByIdResponse(protoMessage.Payload);

                        Events.OnSymbolByIdResponse(this, protoOASymbolByIdRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CHANGED_EVENT:
                    {
                        ProtoOASymbolChangedEvent protoOASymbolChangedEvent = MessagesFactory.GetSymbolChangedEvent(protoMessage.Payload);

                        Events.OnSymbolChanged(this, protoOASymbolChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_TRADER_RES:
                    {
                        ProtoOATraderRes protoOATraderRes = MessagesFactory.GetTraderResponse(protoMessage.Payload);

                        Events.OnTraderResponse(this, protoOATraderRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_TRADER_UPDATE_EVENT:
                    {
                        ProtoOATraderUpdatedEvent protoOATraderUpdatedEvent = MessagesFactory.GetTraderUpdatedEvent(protoMessage.Payload);

                        Events.OnTraderUpdated(this, protoOATraderUpdatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_TRAILING_SL_CHANGED_EVENT:
                    {
                        ProtoOATrailingSLChangedEvent protoOATrailingSLChangedEvent = MessagesFactory.GetTrailingSLChangedEvent(protoMessage.Payload);

                        Events.OnTrailingSLChanged(this, protoOATrailingSLChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_SPOTS_RES:
                    {
                        ProtoOAUnsubscribeSpotsRes protoOAUnsubscribeSpotsRes = MessagesFactory.GetUnsubscribeSpotsResponse(protoMessage.Payload);

                        Events.OnUnsubscribeSpotsResponse(this, protoOAUnsubscribeSpotsRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_VERSION_RES:
                    {
                        ProtoOAVersionRes protoOAVersionRes = MessagesFactory.GetVersionResponse(protoMessage.Payload);

                        Events.OnVersionResponse(this, protoOAVersionRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_GET_CTID_PROFILE_BY_TOKEN_RES:
                    {
                        ProtoOAGetCtidProfileByTokenRes ctidProfileRes = MessagesFactory.GetCtidProfileResponse(protoMessage.Payload);

                        Events.OnCtidProfileResponse(this, ctidProfileRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CATEGORY_RES:
                    {
                        ProtoOASymbolCategoryListRes symbolCategoryListRes = MessagesFactory.GetSymbolCategoryListResponse(protoMessage.Payload);

                        Events.OnSymbolCategoryListResponse(this, symbolCategoryListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_DEPTH_EVENT:
                    {
                        ProtoOADepthEvent depthEvent = MessagesFactory.GetDepthEvent(protoMessage.Payload);

                        Events.OnDepthQuotes(this, depthEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_DEPTH_QUOTES_RES:
                    {
                        ProtoOASubscribeDepthQuotesRes subscribeDepthQuotesRes = MessagesFactory.GetSubscribeDepthQuotesResponse(protoMessage.Payload);

                        Events.OnSubscribeDepthQuotesResponse(this, subscribeDepthQuotesRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_DEPTH_QUOTES_RES:
                    {
                        ProtoOAUnsubscribeDepthQuotesRes unsubscribeDepthQuotesRes = MessagesFactory.GetUnsubscribeDepthQuotesResponse(protoMessage.Payload);

                        Events.OnUnsubscribeDepthQuotesResponse(this, unsubscribeDepthQuotesRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_LOGOUT_RES:
                    {
                        ProtoOAAccountLogoutRes accountLogoutRes = MessagesFactory.GetAccountLogoutResponse(protoMessage.Payload);

                        Events.OnAccountLogoutResponse(this, accountLogoutRes, protoMessage.ClientMsgId);

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
            _stream?.Dispose();

            _client?.Dispose();
        }

        #endregion Others
    }
}