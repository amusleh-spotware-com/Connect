using Connect.Common.Enums;
using Connect.Common.Helpers;
using Connect.Protobuf.Helpers;
using Google.Protobuf;
using System;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Connect.Protobuf
{
    public class Client : IDisposable
    {
        #region Fields

        private readonly int _maxMessageSize;

        private TcpClient _client;

        private SslStream _stream;

        private bool _stopSendingHeartbeats, _stopListening;

        private ProcessStatus _listeningStatus, _sendingHeartbeatsStatus;

        private DateTime _lastSentMessageTime;

        #endregion Fields

        public Client(int maxMessageSize = 1000000)
        {
            _maxMessageSize = maxMessageSize;

            Events = new EventsContainer(this);

            Streams = new StreamsContainer(Events);
        }

        #region Properties

        public bool IsConnected => _client?.Client != null && _client.Client.Connected;

        public bool IsAppAuthorized { get; private set; }

        public Mode Mode { get; private set; }

        public EventsContainer Events { get; }

        public StreamsContainer Streams { get; }

        public bool IsDisposed { get; private set; }

        #endregion Properties

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

            await _client.ConnectAsync(url, BaseUrls.ProtobufPort).ConfigureAwait(false);

            _stream = new SslStream(_client.GetStream(), false,
                (sender, certificate, chain, sslPolicyErrors) => sslPolicyErrors == SslPolicyErrors.None);

            await _stream.AuthenticateAsClientAsync(url).ConfigureAwait(false);

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

            await StoptListening().ConfigureAwait(false);

            await StoptSendingHeartbeats().ConfigureAwait(false);

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

            var heartbeatEvent = new ProtoHeartbeatEvent();

            heartbeatTimer.Elapsed += async (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                try
                {
                    (sender as System.Timers.Timer).Stop();

                    if (!_stopSendingHeartbeats && IsConnected)
                    {
                        if (DateTime.Now - _lastSentMessageTime >= TimeSpan.FromSeconds(10))
                        {
                            await SendMessage(heartbeatEvent, ProtoPayloadType.HeartbeatEvent).ConfigureAwait(false);
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

                    if (!Events.OnHeartbeatSendingException(ex))
                    {
                        throw ex;
                    }
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
                await Task.Delay(100).ConfigureAwait(false);
            }
        }

        #endregion Heart beat

        #region Listener

        public void StartListening()
        {
            CheckIsDisposed();

            _listeningStatus = ProcessStatus.WaitingToRun;

            Task.Run(async () =>
            {
                try
                {
                    _listeningStatus = ProcessStatus.Running;

                    while (!_stopListening)
                    {
                        byte[] lengthArray = new byte[sizeof(int)];

                        int readBytes = 0;

                        do
                        {
                            readBytes += await _stream.ReadAsync(lengthArray, readBytes, lengthArray.Length - readBytes)
                            .ConfigureAwait(false);
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
                            readBytes += await _stream.ReadAsync(message, readBytes, message.Length - readBytes)
                            .ConfigureAwait(false);
                        }
                        while (readBytes < length);

                        Events.InvokeMessageEvent(message);
                    }

                    _listeningStatus = ProcessStatus.Stopped;
                }
                catch (Exception ex)
                {
                    _listeningStatus = ProcessStatus.Error;

                    if (!Events.OnListenerException(ex))
                    {
                        throw;
                    }
                }
            });
        }

        public async Task StoptListening()
        {
            CheckIsDisposed();

            _listeningStatus = ProcessStatus.WaitingToStop;

            _stopListening = true;

            while (_listeningStatus != ProcessStatus.Stopped)
            {
                await Task.Delay(100).ConfigureAwait(false);
            }
        }

        #endregion Listener

        #region Send message

        public Task SendMessage<T>(T message, ProtoPayloadType payloadType, string clientMsgId = null) where T :
            IMessage<T>
        {
            var protoMessage = ProtoMessageGenerator.GetProtoMessage(payloadType, message.ToByteString(), clientMsgId);

            return SendMessage(protoMessage);
        }

        public Task SendMessage<T>(T message, ProtoOAPayloadType payloadType, string clientMsgId = null) where T :
            IMessage<T>
        {
            var protoMessage = ProtoMessageGenerator.GetProtoMessage(payloadType, message.ToByteString(), clientMsgId);

            return SendMessage(protoMessage);
        }

        public async Task SendMessage(ProtoMessage message)
        {
            CheckIsDisposed();

            try
            {
                byte[] messageByte = message.ToByteArray();

                byte[] length = BitConverter.GetBytes(messageByte.Length).Reverse().ToArray();

                _lastSentMessageTime = DateTime.Now;

                await _stream.WriteAsync(length, 0, length.Length).ConfigureAwait(false);

                await _stream.WriteAsync(messageByte, 0, messageByte.Length).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (!Events.OnSenderException(ex))
                {
                    throw;
                }
            }
        }

        #endregion Send message

        #region Others

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