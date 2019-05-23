using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class TickDataRequestParameters : ParametersBase
    {
        public TickDataRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_GET_TICKDATA_REQ)
        {
        }

        public long AccountId { get; set; }

        public long SymbolId { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public ProtoOAQuoteType QuoteType { get; set; }
    }
}
