using Connect.Common.Enums;
using Connect.Common.Helpers;
using Connect.Protobuf.Helpers;
using Google.Protobuf;
using System;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Connect.Protobuf
{
    public class Client : IDisposable
    {
        #region Fields

        private readonly CancellationTokenSource _cancellationTokenSource;

        private TcpClient _client;

        private SslStream _stream;

        private bool _stopSendingHeartbeats;

        #endregion Fields

        public Client(int maxMessageSize = 1000000)
        {
            MaxMessageSize = maxMessageSize;

            Events = new EventsContainer(this);

            Streams = new StreamsContainer(Events);

            _cancellationTokenSource = new CancellationTokenSource();
        }

        #region Properties

        public bool IsConnected => _client?.Client != null && _client.Client.Connected;

        public bool IsAppAuthorized { get; private set; }

        public Mode Mode { get; private set; }

        public EventsContainer Events { get; }

        public StreamsContainer Streams { get; }

        public bool IsDisposed { get; private set; }

        public ProcessStatus ListeningStatus { get; private set; }

        public ProcessStatus SendingHeartbeatsStatus { get; private set; }

        public DateTimeOffset LastSentMessageTime { get; private set; }

        public int MaxMessageSize { get; }

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

            _cancellationTokenSource.Cancel(true);

            ListeningStatus = ProcessStatus.WaitingToStop;

            await WaitForListeningToStop().ConfigureAwait(false);

            await StoptSendingHeartbeats().ConfigureAwait(false);

            _stream?.Dispose();

            IsDisposed = true;
        }

        #endregion Disposing

        #region Heart beat

        private void StartSendingHeartbeats()
        {
            CheckIsDisposed();

            SendingHeartbeatsStatus = ProcessStatus.WaitingToRun;

            System.Timers.Timer heartbeatTimer = new System.Timers.Timer(1000);

            var heartbeatEvent = new ProtoHeartbeatEvent();

            heartbeatTimer.Elapsed += async (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                try
                {
                    (sender as System.Timers.Timer).Stop();

                    if (!_stopSendingHeartbeats && IsConnected)
                    {
                        if (DateTime.Now - LastSentMessageTime >= TimeSpan.FromSeconds(10))
                        {
                            await SendMessage(heartbeatEvent, ProtoPayloadType.HeartbeatEvent).ConfigureAwait(false);
                        }

                        (sender as System.Timers.Timer).Start();
                    }
                    else
                    {
                        SendingHeartbeatsStatus = ProcessStatus.Stopped;
                    }
                }
                catch (Exception ex)
                {
                    (sender as System.Timers.Timer).Stop();

                    SendingHeartbeatsStatus = ProcessStatus.Error;

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

            SendingHeartbeatsStatus = ProcessStatus.WaitingToStop;

            _stopSendingHeartbeats = true;

            while (SendingHeartbeatsStatus != ProcessStatus.Stopped)
            {
                await Task.Delay(100).ConfigureAwait(false);
            }
        }

        #endregion Heart beat

        #region Listener

        private void StartListening()
        {
            CheckIsDisposed();

            ListeningStatus = ProcessStatus.WaitingToRun;

            Task.Run(async () =>
            {
                try
                {
                    ListeningStatus = ProcessStatus.Running;

                    while (true)
                    {
                        byte[] lengthArray = new byte[sizeof(int)];

                        int readBytes = 0;

                        do
                        {
                            readBytes += await _stream.ReadAsync(lengthArray, readBytes, lengthArray.Length - readBytes,
                                _cancellationTokenSource.Token).ConfigureAwait(false);
                        }
                        while (readBytes < lengthArray.Length);

                        int length = BitConverter.ToInt32(lengthArray.Reverse().ToArray(), 0);

                        if (length <= 0)
                        {
                            continue;
                        }
                        else if (length > MaxMessageSize)
                        {
                            string exceptionMsg = $"Message length ({length}) is out of range (0 - {MaxMessageSize})";

                            throw new ArgumentOutOfRangeException(exceptionMsg);
                        }

                        byte[] message = new byte[length];

                        readBytes = 0;

                        do
                        {
                            readBytes += await _stream.ReadAsync(message, readBytes, message.Length - readBytes,
                                _cancellationTokenSource.Token).ConfigureAwait(false);
                        }
                        while (readBytes < length);

                        Events.InvokeMessageEvent(message);
                    }
                }
                catch (OperationCanceledException)
                {
                    ListeningStatus = ProcessStatus.Stopped;
                }
                catch (Exception ex)
                {
                    ListeningStatus = ProcessStatus.Error;

                    if (!Events.OnListenerException(ex))
                    {
                        throw;
                    }
                }
            });
        }

        private async Task WaitForListeningToStop()
        {
            CheckIsDisposed();

            while (ListeningStatus != ProcessStatus.Stopped)
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

                LastSentMessageTime = DateTime.Now;

                await _stream.WriteAsync(length, 0, length.Length, _cancellationTokenSource.Token).ConfigureAwait(false);

                await _stream.WriteAsync(messageByte, 0, messageByte.Length, _cancellationTokenSource.Token)
                    .ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
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