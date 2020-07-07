using Connect.Common.Enums;
using Connect.Common.Helpers;
using Connect.Protobuf.Helpers;
using Connect.Protobuf.Streams;
using Google.Protobuf;
using System;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Reactive.Linq;
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

        #endregion Fields

        public Client(int maxMessageSize = 1000000)
        {
            MaxMessageSize = maxMessageSize;

            _cancellationTokenSource = new CancellationTokenSource();
        }

        #region Properties

        public bool IsConnected => _client?.Client != null && _client.Client.Connected;

        public bool IsAppAuthorized { get; private set; }

        public bool IsDisposed { get; private set; }

        public Mode Mode { get; private set; }

        public ObservableStreams Streams { get; } = new ObservableStreams();

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

            SendingHeartbeatsStatus = ProcessStatus.WaitingToStop;

            await WaitForHeartbeatsToStop().ConfigureAwait(false);

            ListeningStatus = ProcessStatus.WaitingToStop;

            await WaitForListeningToStop().ConfigureAwait(false);

            _stream?.Dispose();

            _cancellationTokenSource.Dispose();

            IsDisposed = true;
        }

        #endregion Disposing

        #region Heart beat

        private void StartSendingHeartbeats()
        {
            CheckIsDisposed();

            SendingHeartbeatsStatus = ProcessStatus.WaitingToRun;

            System.Timers.Timer heartbeatTimer = new System.Timers.Timer(1000) { AutoReset = false };

            var heartbeatEvent = new ProtoHeartbeatEvent();

            heartbeatTimer.Elapsed += async (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                try
                {
                    if (SendingHeartbeatsStatus == ProcessStatus.Running && IsConnected)
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
                    SendingHeartbeatsStatus = ProcessStatus.Error;

                    Streams.OnHeartbeatSendingException(ex);

                    if (!Streams.HeartbeatSendingExceptionStream.Observers.Any())
                    {
                        throw ex;
                    }
                }
            };

            SendingHeartbeatsStatus = ProcessStatus.Running;

            heartbeatTimer.Start();
        }

        private async Task WaitForHeartbeatsToStop()
        {
            CheckIsDisposed();

            var startTime = DateTime.Now;

            while (SendingHeartbeatsStatus == ProcessStatus.Running && DateTime.Now < startTime.AddMinutes(1))
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

                        _cancellationTokenSource.Token.ThrowIfCancellationRequested();

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

                        Streams.InvokeMessageStream(message);
                    }
                }
                catch (OperationCanceledException)
                {
                    ListeningStatus = ProcessStatus.Stopped;
                }
                catch (Exception ex)
                {
                    ListeningStatus = ProcessStatus.Error;

                    Streams.OnListenerException(ex);

                    if (!Streams.ListenerExceptionStream.Observers.Any())
                    {
                        throw;
                    }
                }
            });
        }

        private async Task WaitForListeningToStop()
        {
            CheckIsDisposed();

            var startTime = DateTime.Now;

            while (ListeningStatus == ProcessStatus.Running && DateTime.Now < startTime.AddMinutes(2))
            {
                await Task.Delay(200).ConfigureAwait(false);
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

                _cancellationTokenSource.Token.ThrowIfCancellationRequested();

                await _stream.WriteAsync(messageByte, 0, messageByte.Length, _cancellationTokenSource.Token)
                    .ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                Streams.OnSenderException(ex);

                if (!Streams.SenderExceptionStream.Observers.Any())
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