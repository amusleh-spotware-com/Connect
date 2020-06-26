using Google.Protobuf;

namespace Connect.Protobuf.Helpers
{
    public static class ProtoMessageGenerator
    {
        public static ProtoMessage GetProtoMessage<T>(this T message, ProtoPayloadType payloadType, string clientMessageId = null)
            where T : IMessage<T>
        {
            return GetProtoMessage((uint)payloadType, message.ToByteString(), clientMessageId);
        }

        public static ProtoMessage GetProtoMessage<T>(this T message, ProtoOAPayloadType payloadType,
            string clientMessageId = null) where T : IMessage<T>
        {
            return GetProtoMessage((uint)payloadType, message.ToByteString(), clientMessageId);
        }

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
            var message = new ProtoMessage
            {
                PayloadType = payloadType,
                Payload = payload,
            };

            if (!string.IsNullOrEmpty(clientMessageId))
            {
                message.ClientMsgId = clientMessageId;
            }

            return message;
        }
    }
}