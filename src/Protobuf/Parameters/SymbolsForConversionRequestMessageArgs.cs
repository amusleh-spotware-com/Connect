using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class SymbolsForConversionRequestMessageArgs : MessageArgsBase
    {
        public SymbolsForConversionRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_FOR_CONVERSION_REQ)
        {
        }

        public long AccountId { get; set; }

        public long FirstAssetId { get; set; }

        public long LastAssetId { get; set; }
    }
}
