using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class DepthQuotesRequestParameters : ParametersBase
    {
        public DepthQuotesRequestParameters(ProtoOAPayloadType payloadType) : base((int)payloadType)
        {
            if (payloadType != ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_DEPTH_QUOTES_REQ &&
                payloadType != ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_DEPTH_QUOTES_REQ)
            {
                throw new InvalidOperationException("The payload type of LiveTrendbarRequestParameters must be either" +
                    " PROTO_OA_SUBSCRIBE_DEPTH_QUOTES_REQ or PROTO_OA_UNSUBSCRIBE_DEPTH_QUOTES_REQ");
            }
        }

        public long AccountId { get; set; }

        public List<long> SymbolIds { get; set; }
    }
}
