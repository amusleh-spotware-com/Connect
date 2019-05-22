using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class SymbolsListRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }
    }
}
