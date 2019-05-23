using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class ExpectedMarginRequestParameters : ParametersBase
    {
        public ExpectedMarginRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_EXPECTED_MARGIN_REQ)
        {
        }

        public long AccountId { get; set; }

        public long SymbolId { get; set; }

        public List<long> Volumes { get; set; }
    }
}
