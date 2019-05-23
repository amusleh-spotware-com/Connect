using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class SymbolByIdRequestParameters : ParametersBase
    {
        public SymbolByIdRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_SYMBOL_BY_ID_REQ)
        {
        }

        public long AccountId { get; set; }

        public List<long> SymbolIds { get; set; }
    }
}
