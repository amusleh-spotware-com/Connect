using Google.Protobuf;

namespace Connect.Protobuf.Streams
{
    public class StreamMessage<T> where T : IMessage<T>
    {
        public StreamMessage(T message, string clientMessageId)
        {
            Message = message;

            ClientMessageId = clientMessageId;
        }

        public T Message { get; }

        public string ClientMessageId { get; }
    }
}