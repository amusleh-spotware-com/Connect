using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class SymbolByIdRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }

        public List<long> SymbolIds { get; set; }
    }
}
