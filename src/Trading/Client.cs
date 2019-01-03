using Connect.Common;
using System;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Connect.Trading
{
    public class Client
    {
        #region Fields

        private TcpClient _apiClient;

        private SslStream _apiStream;

        private readonly int _maxMessageSize = 10000;

        private readonly Events _events = new Events();

        private ProcessStatus _listenerStatus = ProcessStatus.None, _heartbeatSenderStatus = ProcessStatus.None;

        private bool _isAuthorized;

        #endregion Fields

        #region Properties

        public bool IsConnected => _apiClient?.Client != null && _apiClient.Client.Connected;

        public bool IsAuthorized => _isAuthorized;

        public Events Events => _events;

        public ProcessStatus ListenerStatus => _listenerStatus;

        public ProcessStatus HeartbeatSenderStatus => _heartbeatSenderStatus;

        #endregion Properties

        #region Connection

        public async Task Connect(Mode mode = Mode.Live, Proxy proxy = Proxy.None, bool keepConnectionAlive = true, bool startListener = true)
        {
            _apiClient = new TcpClient();

            _apiClient.ReceiveTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;
            _apiClient.SendTimeout = (int)TimeSpan.FromSeconds(20).TotalMilliseconds;

            string apiURL = BaseUrls.GetBaseUrl(ApiType.Trading, mode, proxy);

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

            if (keepConnectionAlive)
            {
                StartHeartbeatSending();
            }

            if (startListener)
            {
                StartListener();
            }
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

        #region Requests

        public async Task SendPingRequest()
        {
            ProtoMessage message = MessageFactory.CreatePingRequest((ulong)DateTime.Now.Ticks);

            await SendMessage(message);
        }

        public async Task SendHeartbeatEvent()
        {
            ProtoMessage message = MessageFactory.CreateHeartbeatEvent();

            await SendMessage(message);
        }

        public async Task SendAuthorizationRequest(string clientId, string secrect)
        {
            ProtoMessage message = MessageFactory.CreateAuthorizationRequest(clientId, secrect);

            await SendMessage(message);
        }

        public async Task SendSubscribeForTradingEventsRequest(long accountId, string accessToken)
        {
            ProtoMessage message = MessageFactory.CreateSubscribeForTradingEventsRequest(accountId, accessToken);

            await SendMessage(message);
        }

        public async Task SendSubscribeForSpotsRequest(long accountId, string accessToken, string symbolName, string clientMsgId = null)
        {
            ProtoMessage message = MessageFactory.CreateSubscribeForSpotsRequest(accountId, accessToken, symbolName, clientMsgId);

            await SendMessage(message);
        }

        public async Task SendUnsubscribeForSpotsRequest(long accountId, string symbolName, string clientMsgId = null)
        {
            ProtoMessage message = MessageFactory.CreateUnsubscribeFromSymbolSpotsRequest(symbolName, clientMsgId);

            await SendMessage(message);
        }

        public async Task SendUnsubscribeForTradingEventsRequest(long accountId)
        {
            ProtoMessage message = MessageFactory.CreateUnsubscribeForTradingEventsRequest(accountId);

            await SendMessage(message);
        }

        public async Task SendGetAllSubscriptionsForTradingEventsRequest()
        {
            ProtoMessage message = MessageFactory.CreateAllSubscriptionsForTradingEventsRequest();

            await SendMessage(message);
        }

        public async Task SendGetAllSubscriptionsForSpotEventsRequest()
        {
            ProtoMessage message = MessageFactory.CreateGetAllSpotSubscriptionsRequest();

            await SendMessage(message);
        }

        public async Task SendMarketOrderRequest(
            long accountId,
            string accessToken,
            string symbolName,
            ProtoTradeSide tradeSide,
            long orderVolume,
            string comment = null,
            int? stopLossInPips = null,
            int? takeProfitInPips = null,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? positionId = null)
        {
            ProtoMessage message = MessageFactory.CreateMarketOrderRequest(
                accountId,
                accessToken,
                symbolName,
                tradeSide,
                orderVolume,
                comment,
                stopLossInPips,
                takeProfitInPips,
                stopLossPrice,
                takeProfitPrice,
                positionId);

            await SendMessage(message);
        }

        public async Task SendAmendPositionProtectionRequest(
            long accountId,
            string accessToken,
            long positionId,
            double? stopLossPrice,
            double? takeProfitPrice,
            string clientMsgId = null)
        {
            ProtoMessage message = MessageFactory.CreateAmendPositionProtectionRequest(
                accountId, accessToken, positionId, stopLossPrice, takeProfitPrice, clientMsgId);

            await SendMessage(message);
        }

        public async Task SendAmendPositionStopLossRequest(
            long accountId, string accessToken, long positionId, double stopLossPrice, string clientMsgId = null)
        {
            ProtoMessage message = MessageFactory.CreateAmendPositionStopLossRequest(
                accountId, accessToken, positionId, stopLossPrice, clientMsgId);

            await SendMessage(message);
        }

        public async Task SendAmendPositionTakeProfitRequest(
            long accountId,
            string accessToken,
            long positionId,
            double takeProfitPrice,
            string clientMsgId = null)
        {
            ProtoMessage message = MessageFactory.CreateAmendPositionTakeProfitRequest(
                accountId, accessToken, positionId, takeProfitPrice, clientMsgId);

            await SendMessage(message);
        }

        public async Task SendClosePositionRequest(
            long accountId,
            string accessToken,
            long orderId,
            long orderVolume,
            string clientMsgId = null)
        {
            ProtoMessage message = MessageFactory.CreateClosePositionRequest(
                accountId,
                accessToken,
                orderId,
                orderVolume,
                clientMsgId);

            await SendMessage(message);
        }

        public async Task SendMarketRangeOrderRequest(
            long accountId,
            string accessToken,
            string symbolName,
            ProtoTradeSide tradeSide,
            long orderVolume,
            long slippageInPips,
            double baseSlippagePrice,
            string comment = null,
            int? stopLossInPips = null,
            int? takeProfitInPips = null,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? positionId = null)
        {
            ProtoMessage message = MessageFactory.CreateMarketRangeOrderRequest(
                accountId,
                accessToken,
                symbolName,
                tradeSide,
                orderVolume,
                slippageInPips,
                baseSlippagePrice,
                comment,
                stopLossInPips,
                takeProfitInPips,
                stopLossPrice,
                takeProfitPrice,
                positionId);

            await SendMessage(message);
        }

        public async Task SendLimitOrderRequest(
            long accountId,
            string accessToken,
            string symbolName,
            ProtoTradeSide tradeSide,
            long orderVolume,
            double limitPrice,
            string comment = null,
            int? stopLossInPips = null,
            int? takeProfitInPips = null,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? expirationTimestamp = null)
        {
            ProtoMessage message = MessageFactory.CreateLimitOrderRequest(
                accountId,
                accessToken,
                symbolName,
                tradeSide,
                orderVolume,
                limitPrice,
                comment,
                stopLossInPips,
                takeProfitInPips,
                stopLossPrice,
                takeProfitPrice,
                expirationTimestamp);

            await SendMessage(message);
        }

        public async Task SendAmendLimitOrderRequest(
            long accountId,
            string accessToken,
            long orderId,
            double limitPrice,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? expirationTimestamp = null,
            string clientMsgId = null)
        {
            ProtoMessage message = MessageFactory.CreateAmendLimitOrderRequest(
                accountId,
                accessToken,
                orderId,
                limitPrice,
                stopLossPrice,
                takeProfitPrice,
                expirationTimestamp,
                clientMsgId: clientMsgId);

            await SendMessage(message);
        }

        public async Task SendStopOrderRequest(
            long accountId,
            string accessToken,
            string symbolName,
            ProtoTradeSide tradeSide,
            long orderVolume,
            double stopPrice,
            string comment = null,
            int? stopLossInPips = null,
            int? takeProfitInPips = null,
            double? stopLossPrice = null,
            double? takeProfitPrice = null,
            long? expirationTimestamp = null)
        {
            ProtoMessage message = MessageFactory.CreateStopOrderRequest(
                accountId,
                accessToken,
                symbolName,
                tradeSide,
                orderVolume,
                stopPrice,
                comment,
                stopLossInPips,
                takeProfitInPips,
                stopLossPrice,
                takeProfitPrice,
                expirationTimestamp);

            await SendMessage(message);
        }

        public async Task SendAmendStopOrderRequest(long accountId, string accessToken, long orderId, double stopPrice, double? stopLossPrice = null, double? takeProfitPrice = null, long? expirationTimestamp = null, string clientMsgId = null)
        {
            ProtoMessage message = MessageFactory.CreateAmendStopOrderRequest(
                accountId,
                accessToken,
                orderId,
                stopPrice,
                stopLossPrice,
                takeProfitPrice,
                expirationTimestamp,
                clientMsgId: clientMsgId);

            await SendMessage(message);
        }

        public async Task SendCancelOrderRequest(long accountId, string accessToken, long orderId, string clientMsgId = null)
        {
            ProtoMessage message = MessageFactory.CreateCancelOrderRequest(accountId, accessToken, orderId, clientMsgId);

            await SendMessage(message);
        }

        public async Task SendMessage(ProtoMessage message)
        {
            if (IsConnected && IsAuthorized)
            {
                byte[] messageByte = message.ToByteArray();

                byte[] length = BitConverter.GetBytes(messageByte.Length).Reverse().ToArray();

                await _apiStream.WriteAsync(length, 0, length.Length);

                await _apiStream.WriteAsync(messageByte, 0, messageByte.Length);
            }
            else
            {
                if (!IsConnected)
                {
                    throw new InvalidOperationException(ExceptionMessages.ClientNotConnected);
                }
                else if (!IsAuthorized)
                {
                    throw new InvalidOperationException(ExceptionMessages.ClientNotAuthorized);
                }
            }
        }

        #endregion Requests

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
                        await SendHeartbeatEvent();
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

                    MessageTranslator(message);
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

        #region Others

        private void MessageTranslator(byte[] message)
        {
            uint messagePayloadType = MessageFactory.GetPayloadType(message);

            switch (messagePayloadType)
            {
                case 2016:
                    {
                        ProtoOAExecutionEvent executionEvent = MessageFactory.GetExecutionEvent(message);

                        _events.OnExecutionEvent(this, executionEvent);

                        break;
                    }
                case 2029:
                    {
                        _events.OnSpotEvent(this, MessageFactory.GetSpotEvent(message));

                        break;
                    }
                case 50:
                    {
                        _events.OnError(this, MessageFactory.GetErrorResponse(message));

                        break;
                    }
                case 2001:
                    {
                        _isAuthorized = true;

                        _events.OnAuthorized(this);

                        break;
                    }
                default:
                    break;
            }
        }

        #endregion Others
    }
}