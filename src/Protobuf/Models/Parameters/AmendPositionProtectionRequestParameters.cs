using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class AmendPositionProtectionRequestParameters : ParametersBase
    {
        public AmendPositionProtectionRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_AMEND_POSITION_SLTP_REQ)
        {
        }

        public long AccountId { get; set; }

        public long PositionId { get; set; }

        public double? StopLossPrice { get; set; }

        public double? TakeProfitPrice { get; set; }

        public bool? GuaranteedStopLoss { get; set; }

        public bool? TrailingStopLoss { get; set; }

        public ProtoOAOrderTriggerMethod? StopLossTriggerMethod { get; set; }
    }
}
