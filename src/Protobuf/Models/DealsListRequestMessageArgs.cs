using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class DealsListRequestMessageArgs : MessageArgsBase
    {
        public DealsListRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_DEAL_LIST_REQ)
        {
        }

        public long AccountId { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }
    }
}
