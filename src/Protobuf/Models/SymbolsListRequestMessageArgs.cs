using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class SymbolsListRequestMessageArgs : MessageArgsBase
    {
        public SymbolsListRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_LIST_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
