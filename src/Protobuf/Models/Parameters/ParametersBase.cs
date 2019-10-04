using Connect.Protobuf.Models.Parameters.Abstractions;

namespace Connect.Protobuf.Models.Parameters
{
    public abstract class ParametersBase : IParameters
    {
        public ParametersBase(int payloadType)
        {
            PayloadType = payloadType;
        }

        public string ClientMessageId { get; set; }

        public int PayloadType { get; }
    }
}