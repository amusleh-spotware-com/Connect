using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class LiveTrendbarRequestParameters : ParametersBase
    {
        public LiveTrendbarRequestParameters(ProtoOAPayloadType payloadType) : base((int)payloadType)
        {
            if (payloadType != ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_LIVE_TRENDBAR_REQ &&
                payloadType != ProtoOAPayloadType.PROTO_OA_UNSUBSCRIBE_LIVE_TRENDBAR_REQ)
            {
                throw new InvalidOperationException("The payload type of LiveTrendbarRequestParameters must be either" +
                    " PROTO_OA_SUBSCRIBE_LIVE_TRENDBAR_REQ or PROTO_OA_UNSUBSCRIBE_LIVE_TRENDBAR_REQ");
            }
        }

        public long AccountId { get; set; }

        public long SymbolId { get; set; }

        public ProtoOATrendbarPeriod Period { get; set; }
    }
}
