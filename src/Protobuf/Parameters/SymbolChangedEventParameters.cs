using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class SymbolChangedEventParameters : ParametersBase
    {
        public SymbolChangedEventParameters() : base((int)ProtoOAPayloadType.PROTO_OA_SYMBOL_CHANGED_EVENT)
        {
        }

        public long AccountId { get; set; }

        public List<long> SymbolIds { get; set; }
    }
}
