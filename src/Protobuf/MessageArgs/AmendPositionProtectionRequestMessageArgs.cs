using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class AmendPositionProtectionRequestMessageArgs : MessageArgsBase
    {
        public AmendPositionProtectionRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_AMEND_POSITION_SLTP_REQ)
        {
        }

        public long AccountId { get; set; }

        public long PositionId { get; set; }

        public double? StopLossPrice { get; set; }

        public double? TakeProfitPrice { get; set; }
    }
}
