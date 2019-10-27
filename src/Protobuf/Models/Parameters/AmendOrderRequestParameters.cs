using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class AmendOrderRequestParameters : ParametersBase
    {
        public AmendOrderRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_AMEND_ORDER_REQ)
        {
        }

        public long AccountId { get; set; }

        public long OrderId { get; set; }

        public ProtoOAOrderType OrderType { get; set; }

        public double? Price { get; set; }

        public DateTimeOffset? ExpirationTime { get; set; }

        public double? StopLossPrice { get; set; }

        public double? TakeProfitPrice { get; set; }

        public long? Volume { get; set; }

        public int? SlippageInPoints { get; set; }

        public bool? GuaranteedStopLoss { get; set; }

        public bool? TrailingStopLoss { get; set; }

        public ProtoOAOrderTriggerMethod? StopTriggerMethod { get; set; }
    }
}
