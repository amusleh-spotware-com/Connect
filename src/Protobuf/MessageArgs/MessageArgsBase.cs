using Connect.Protobuf.MessageArgs.Abstractions;

namespace Connect.Protobuf.MessageArgs
{
    public abstract class MessageArgsBase : IMessageArgs
    {
        public MessageArgsBase(int payloadType)
        {
            PayloadType = payloadType;
        }

        public string ClientMessageId { get; set; }

        public int PayloadType { get; private set; }
    }
}