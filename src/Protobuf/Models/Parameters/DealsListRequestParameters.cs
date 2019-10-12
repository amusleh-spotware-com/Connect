using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class DealsListRequestParameters : ParametersBase
    {
        public DealsListRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_DEAL_LIST_REQ)
        {
        }

        public long AccountId { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public int MaxRows { get; set; }
    }
}
