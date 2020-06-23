using Connect.Common.Enums;
using Connect.Common.Helpers;
using Connect.Protobuf.Helpers;
using Connect.Protobuf.Streams;
using Google.Protobuf;
using System;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
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

        private DateTime _lastSentMessageTime;

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

        #region Streams

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

        #endregion Streams

        #region Other properties

        public bool IsConnected => _client?.Client != null && _client.Client.Connected;

        public bool IsAppAuthorized { get; private set; }

        public Mode Mode { get; private set; }

        public Events Events { get; }

        public bool IsDisposed { get; private set; }

        #endregion Other properties

        #region Connection

        public async Task Connect(Mode mode)
        {
            CheckIsDisposed();

            Mode = mode;

            _client = new TcpClient
            {
                ReceiveTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds,
                SendTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds
            };

            var url = BaseUrls.GetBaseUrl(mode);

            await _client.ConnectAsync(url, BaseUrls.ProtobufPort);

            _stream = new SslStream(_client.GetStream(), false);

            await _stream.AuthenticateAsClientAsync(url);

            StartSendingHeartbeats();

            StartListening();
        }

        #endregion Connection

        #region Disposing

        public void Dispose()
        {
            DisposeAsync().Wait();
        }

        public async Task DisposeAsync()
        {
            CheckIsDisposed();

            await StoptListening();

            await StoptSendingHeartbeats();

            _stream?.Dispose();

            IsDisposed = true;
        }

        #endregion Disposing

        #region Heart beat

        private void StartSendingHeartbeats()
        {
            CheckIsDisposed();

            _sendingHeartbeatsStatus = ProcessStatus.WaitingToRun;

            System.Timers.Timer heartbeatTimer = new System.Timers.Timer(1000);

            var protoMessage = ProtoMessageGenerator.GetProtoMessage(ProtoPayloadType.HeartbeatEvent,
                new ProtoHeartbeatEvent().ToByteString());

            heartbeatTimer.Elapsed += async (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                try
                {
                    (sender as System.Timers.Timer).Stop();

                    if (!_stopSendingHeartbeats && IsConnected)
                    {
                        if (DateTime.Now - _lastSentMessageTime >= TimeSpan.FromSeconds(10))
                        {
                            await SendMessage(protoMessage);
                        }

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
            CheckIsDisposed();

            _sendingHeartbeatsStatus = ProcessStatus.WaitingToStop;

            _stopSendingHeartbeats = true;

            while (_sendingHeartbeatsStatus != ProcessStatus.Stopped)
            {
                await Task.Delay(100);
            }
        }

        #endregion Heart beat

        #region Listener

        public void StartListening()
        {
            CheckIsDisposed();

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
                catch (Exception ex)
                {
                    _listeningStatus = ProcessStatus.Error;

                    Events.OnListenerException(this, ex);

                    if (!IsManagableException(ex))
                    {
                        throw;
                    }
                }
            });
#pragma warning restore 4014
        }

        public async Task StoptListening()
        {
            CheckIsDisposed();

            _listeningStatus = ProcessStatus.WaitingToStop;

            _stopListening = true;

            while (_listeningStatus != ProcessStatus.Stopped)
            {
                await Task.Delay(100);
            }
        }

        #endregion Listener

        #region Send message

        public async Task SendMessage(ProtoMessage message)
        {
            CheckIsDisposed();

            try
            {
                byte[] messageByte = message.ToByteArray();

                byte[] length = BitConverter.GetBytes(messageByte.Length).Reverse().ToArray();

                _lastSentMessageTime = DateTime.Now;

                await _stream.WriteAsync(length, 0, length.Length);

                await _stream.WriteAsync(messageByte, 0, messageByte.Length);
            }
            catch (Exception ex)
            {
                Events.OnSenderException(this, ex);

                if (!IsManagableException(ex))
                {
                    throw;
                }
            }
        }

        #endregion Send message

        #region Others

        private void InvokeMessageEvent(byte[] data)
        {
            var protoMessage = ProtoMessage.Parser.ParseFrom(data);

            var payload = protoMessage.Payload;

            Events.OnMessageReceived(this, protoMessage);

            switch (protoMessage.PayloadType)
            {
                case (int)ProtoOAPayloadType.ProtoOaErrorRes:
                    {
                        var protoErrorRes = ProtoOAErrorRes.Parser.ParseFrom(payload);

                        Events.OnError(this, protoErrorRes);

                        break;
                    }
                case (int)ProtoPayloadType.HeartbeatEvent:
                    {
                        var protoHeartbeatEvent = ProtoHeartbeatEvent.Parser.ParseFrom(payload);

                        Events.OnHeartbeat(this, protoHeartbeatEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAccountAuthRes:
                    {
                        var protoOAAccountAuthRes = ProtoOAAccountAuthRes.Parser.ParseFrom(payload);

                        Events.OnAccountAuthorizationResponse(this, protoOAAccountAuthRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaApplicationAuthRes:
                    {
                        var protoOAApplicationAuthRes = ProtoOAApplicationAuthRes.Parser.ParseFrom(payload);

                        IsAppAuthorized = true;

                        Events.OnApplicationAuthResponse(this, protoOAApplicationAuthRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaClientDisconnectEvent:
                    {
                        var protoOAClientDisconnect = ProtoOAClientDisconnectEvent.Parser.ParseFrom(payload);

                        Events.OnClientDisconnected(this, protoOAClientDisconnect);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaDealListRes:
                    {
                        var protoOADealListRes = ProtoOADealListRes.Parser.ParseFrom(payload);

                        Events.OnDealListResponse(this, protoOADealListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAssetListRes:
                    {
                        var protoOAAssetListRes = ProtoOAAssetListRes.Parser.ParseFrom(payload);

                        Events.OnAssetListResponse(this, protoOAAssetListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAssetClassListRes:
                    {
                        var protoOAAssetClassListRes = ProtoOAAssetClassListRes.Parser.ParseFrom(payload);

                        Events.OnAssetClassListResponse(this, protoOAAssetClassListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAccountsTokenInvalidatedEvent:
                    {
                        var protoOAAccountsTokenInvalidatedEvent = ProtoOAAccountsTokenInvalidatedEvent.Parser.ParseFrom(payload);

                        Events.OnAccountsTokenInvalidated(this, protoOAAccountsTokenInvalidatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaCashFlowHistoryListRes:
                    {
                        var protoOACashFlowHistoryListRes = ProtoOACashFlowHistoryListRes.Parser.ParseFrom(payload);

                        Events.OnCashFlowHistoryListResponse(this, protoOACashFlowHistoryListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaExecutionEvent:
                    {
                        var protoOAExecutionEvent = ProtoOAExecutionEvent.Parser.ParseFrom(payload);

                        Events.OnExecution(this, protoOAExecutionEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaExpectedMarginRes:
                    {
                        var protoOAExpectedMarginRes = ProtoOAExpectedMarginRes.Parser.ParseFrom(payload);

                        Events.OnExpectedMarginResponse(this, protoOAExpectedMarginRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetAccountsByAccessTokenRes:
                    {
                        var protoOAGetAccountListByAccessTokenRes = ProtoOAGetAccountListByAccessTokenRes.Parser.ParseFrom(payload);

                        Events.OnAccountListResponse(this, protoOAGetAccountListByAccessTokenRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetTickdataRes:
                    {
                        var protoOAGetTickDataRes = ProtoOAGetTickDataRes.Parser.ParseFrom(payload);

                        Events.OnTickDataResponse(this, protoOAGetTickDataRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetTrendbarsRes:
                    {
                        var protoOAGetTrendbarsRes = ProtoOAGetTrendbarsRes.Parser.ParseFrom(payload);

                        Events.OnTrendbarsResponse(this, protoOAGetTrendbarsRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaMarginChangedEvent:
                    {
                        var protoOAMarginChangedEvent = ProtoOAMarginChangedEvent.Parser.ParseFrom(payload);

                        Events.OnMarginChanged(this, protoOAMarginChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaOrderErrorEvent:
                    {
                        var protoOAOrderErrorEvent = ProtoOAOrderErrorEvent.Parser.ParseFrom(payload);

                        Events.OnOrderError(this, protoOAOrderErrorEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaReconcileRes:
                    {
                        var protoOAReconcileRes = ProtoOAReconcileRes.Parser.ParseFrom(payload);

                        Events.OnReconcileResponse(this, protoOAReconcileRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSpotEvent:
                    {
                        var protoOASpotEvent = ProtoOASpotEvent.Parser.ParseFrom(payload);

                        Events.OnSpot(this, protoOASpotEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSubscribeSpotsRes:
                    {
                        var protoOASubscribeSpotsRes = ProtoOASubscribeSpotsRes.Parser.ParseFrom(payload);

                        Events.OnSubscribeSpotsResponse(this, protoOASubscribeSpotsRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolsForConversionRes:
                    {
                        var protoOASymbolsForConversionRes = ProtoOASymbolsForConversionRes.Parser.ParseFrom(payload);

                        Events.OnSymbolsForConversionResponse(this, protoOASymbolsForConversionRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolsListRes:
                    {
                        var protoOASymbolsListRes = ProtoOASymbolsListRes.Parser.ParseFrom(payload);

                        Events.OnSymbolsListResponse(this, protoOASymbolsListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolByIdRes:
                    {
                        var protoOASymbolByIdRes = ProtoOASymbolByIdRes.Parser.ParseFrom(payload);

                        Events.OnSymbolByIdResponse(this, protoOASymbolByIdRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolChangedEvent:
                    {
                        var protoOASymbolChangedEvent = ProtoOASymbolChangedEvent.Parser.ParseFrom(payload);

                        Events.OnSymbolChanged(this, protoOASymbolChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaTraderRes:
                    {
                        var protoOATraderRes = ProtoOATraderRes.Parser.ParseFrom(payload);

                        Events.OnTraderResponse(this, protoOATraderRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaTraderUpdateEvent:
                    {
                        var protoOATraderUpdatedEvent = ProtoOATraderUpdatedEvent.Parser.ParseFrom(payload);

                        Events.OnTraderUpdated(this, protoOATraderUpdatedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaTrailingSlChangedEvent:
                    {
                        var protoOATrailingSLChangedEvent = ProtoOATrailingSLChangedEvent.Parser.ParseFrom(payload);

                        Events.OnTrailingSLChanged(this, protoOATrailingSLChangedEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaUnsubscribeSpotsRes:
                    {
                        var protoOAUnsubscribeSpotsRes = ProtoOAUnsubscribeSpotsRes.Parser.ParseFrom(payload);

                        Events.OnUnsubscribeSpotsResponse(this, protoOAUnsubscribeSpotsRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaVersionRes:
                    {
                        var protoOAVersionRes = ProtoOAVersionRes.Parser.ParseFrom(payload);

                        Events.OnVersionResponse(this, protoOAVersionRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaGetCtidProfileByTokenRes:
                    {
                        var ctidProfileRes = ProtoOAGetCtidProfileByTokenRes.Parser.ParseFrom(payload);

                        Events.OnCtidProfileResponse(this, ctidProfileRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSymbolCategoryRes:
                    {
                        var symbolCategoryListRes = ProtoOASymbolCategoryListRes.Parser.ParseFrom(payload);

                        Events.OnSymbolCategoryListResponse(this, symbolCategoryListRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaDepthEvent:
                    {
                        var depthEvent = ProtoOADepthEvent.Parser.ParseFrom(payload);

                        Events.OnDepthQuotes(this, depthEvent);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaSubscribeDepthQuotesRes:
                    {
                        var subscribeDepthQuotesRes = ProtoOASubscribeDepthQuotesRes.Parser.ParseFrom(payload);

                        Events.OnSubscribeDepthQuotesResponse(this, subscribeDepthQuotesRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaUnsubscribeDepthQuotesRes:
                    {
                        var unsubscribeDepthQuotesRes = ProtoOAUnsubscribeDepthQuotesRes.Parser.ParseFrom(payload);

                        Events.OnUnsubscribeDepthQuotesResponse(this, unsubscribeDepthQuotesRes, protoMessage.ClientMsgId);

                        break;
                    }
                case (int)ProtoOAPayloadType.ProtoOaAccountLogoutRes:
                    {
                        var accountLogoutRes = ProtoOAAccountLogoutRes.Parser.ParseFrom(payload);

                        Events.OnAccountLogoutResponse(this, accountLogoutRes, protoMessage.ClientMsgId);

                        break;
                    }
                default:
                    break;
            }
        }

        private bool IsManagableException(Exception exception)
        {
            return exception is ArgumentNullException || exception is ArgumentOutOfRangeException ||
                exception is InvalidOperationException || exception is ArgumentException ||
                exception is NotSupportedException || exception is IOException || exception is ObjectDisposedException ||
                exception.InnerException is Google.Protobuf.InvalidProtocolBufferException;
        }

        private void CheckIsDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException("Client is disposed, you cannot access a disposed object");
            }
        }

        #endregion Others
    }
}