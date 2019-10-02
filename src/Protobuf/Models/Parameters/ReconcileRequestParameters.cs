using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class ReconcileRequestParameters : ParametersBase
    {
        public ReconcileRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_RECONCILE_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
