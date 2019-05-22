using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class TickDataRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }

        public long SymbolId { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public ProtoOAQuoteType QuoteType { get; set; }
    }
}
