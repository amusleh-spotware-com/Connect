using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class SymbolCategoryListRequestParameters : ParametersBase
    {
        public SymbolCategoryListRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CATEGORY_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
