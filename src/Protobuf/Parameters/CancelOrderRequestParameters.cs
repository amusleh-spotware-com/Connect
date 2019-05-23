using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class CancelOrderRequestParameters : ParametersBase
    {
        public CancelOrderRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_CANCEL_ORDER_REQ)
        {
        }

        public long AccountId { get; set; }

        public long OrderId { get; set; }
    }
}
