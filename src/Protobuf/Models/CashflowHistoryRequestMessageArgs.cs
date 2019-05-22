using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class CashflowHistoryRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }
    }
}
