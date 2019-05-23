using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class TraderRequestParameters : ParametersBase
    {
        public TraderRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_TRADER_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
