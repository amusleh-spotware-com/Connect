using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class SymbolsListRequestParameters : ParametersBase
    {
        public SymbolsListRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_SYMBOLS_LIST_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
