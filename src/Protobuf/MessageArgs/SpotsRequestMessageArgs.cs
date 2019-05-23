using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class SpotsRequestMessageArgs : MessageArgsBase
    {
        public SpotsRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_SPOTS_REQ)
        {
        }

        public long AccountId { get; set; }

        public long SymbolId { get; set; }
    }
}
