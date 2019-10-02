using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class SpotsRequestParameters : ParametersBase
    {
        public SpotsRequestParameters(ProtoOAPayloadType payloadType) : base((int)payloadType)
        {
            if (payloadType != ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_SPOTS_REQ &&
                payloadType != ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_SPOTS_REQ)
            {
                throw new InvalidOperationException("The payload type of SpotsRequestParameters must be either" +
                    " PROTO_OA_SUBSCRIBE_SPOTS_REQ or PROTO_OA_UNSUBSCRIBE_SPOTS_REQ");
            }
        }

        public long AccountId { get; set; }

        public List<long> SymbolIds { get; set; }
    }
}
