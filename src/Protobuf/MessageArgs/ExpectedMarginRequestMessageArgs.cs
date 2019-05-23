using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class ExpectedMarginRequestMessageArgs : MessageArgsBase
    {
        public ExpectedMarginRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_EXPECTED_MARGIN_REQ)
        {
        }

        public long AccountId { get; set; }

        public long SymbolId { get; set; }

        public List<long> Volumes { get; set; }
    }
}
