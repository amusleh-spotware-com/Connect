using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class TrendbarsRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }

        public long SymbolId { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public ProtoOATrendbarPeriod Period { get; set; }
    }
}
