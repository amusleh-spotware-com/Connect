using Google.Protobuf;

namespace Connect.Protobuf.Helpers
{
    public static class ProtoMessageGenerator
    {
        public static ProtoMessage GetProtoMessage(ProtoPayloadType payloadType, ByteString payload,
            string clientMessageId = null)
        {
            return GetProtoMessage((uint)payloadType, payload, clientMessageId);
        }

        public static ProtoMessage GetProtoMessage(ProtoOAPayloadType payloadType, ByteString payload,
            string clientMessageId = null)
        {
            return GetProtoMessage((uint)payloadType, payload, clientMessageId);
        }

        public static ProtoMessage GetProtoMessage(uint payloadType, ByteString payload, string clientMessageId = null)
        {
            return new ProtoMessage
            {
                PayloadType = payloadType,
                Payload = payload,
                ClientMsgId = clientMessageId
            };
        }
    }
}