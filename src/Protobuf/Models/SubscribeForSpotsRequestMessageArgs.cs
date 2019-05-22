using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class SubscribeForSpotsRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }

        public long SymbolId { get; set; }
    }
}
