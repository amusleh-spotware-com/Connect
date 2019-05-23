using Connect.Protobuf.Parameters.Abstractions;

namespace Connect.Protobuf.Parameters
{
    public abstract class ParametersBase : IParameters
    {
        public ParametersBase(int payloadType)
        {
            PayloadType = payloadType;
        }

        public string ClientMessageId { get; set; }

        public int PayloadType { get; private set; }
    }
}