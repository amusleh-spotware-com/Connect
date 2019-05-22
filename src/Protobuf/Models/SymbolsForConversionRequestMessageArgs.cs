using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class SymbolsForConversionRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }

        public long FirstAssetId { get; set; }

        public long LastAssetId { get; set; }
    }
}
