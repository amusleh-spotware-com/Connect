using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class SpotsRequestMessageArgs : MessageArgsBase
    {
        public SpotsRequestMessageArgs(ProtoOAPayloadType payloadType) : base((int)payloadType)
        {
            if (payloadType != ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_SPOTS_REQ &&
                payloadType != ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_SPOTS_REQ)
            {
                throw new InvalidOperationException("The payload type of SpotsRequestMessageArgs must be either" +
                    " PROTO_OA_SUBSCRIBE_SPOTS_REQ or PROTO_OA_UNSUBSCRIBE_SPOTS_REQ");
            }
        }

        public long AccountId { get; set; }

        public List<long> SymbolIds { get; set; }
    }
}
