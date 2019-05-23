using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class ReconcileRequestMessageArgs : MessageArgsBase
    {
        public ReconcileRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_RECONCILE_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
