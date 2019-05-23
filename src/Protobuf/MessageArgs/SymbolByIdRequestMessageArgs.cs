using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class SymbolByIdRequestMessageArgs : MessageArgsBase
    {
        public SymbolByIdRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_SYMBOL_BY_ID_REQ)
        {
        }

        public long AccountId { get; set; }

        public List<long> SymbolIds { get; set; }
    }
}
