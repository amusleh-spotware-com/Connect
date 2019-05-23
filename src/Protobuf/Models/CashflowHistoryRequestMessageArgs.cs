using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class CashflowHistoryRequestMessageArgs : MessageArgsBase
    {
        public CashflowHistoryRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_CASH_FLOW_HISTORY_LIST_REQ)
        {
        }

        public long AccountId { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }
    }
}
