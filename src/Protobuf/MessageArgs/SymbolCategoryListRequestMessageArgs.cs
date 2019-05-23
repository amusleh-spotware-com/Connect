using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class SymbolCategoryListRequestMessageArgs : MessageArgsBase
    {
        public SymbolCategoryListRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CATEGORY_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
