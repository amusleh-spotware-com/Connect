using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class PendingOrderRequestParameters : OrderRequestParameters
    {
        public PendingOrderRequestParameters(ProtoOAOrderType orderType) : base(orderType)
        {
        }

        public double Price { get; set; }

        public double? StopLossInPrice { get; set; }

        public double? TakeProfitInPrice { get; set; }

        public DateTimeOffset? ExpirationTime { get; set; }

        public ProtoOAOrderTriggerMethod? StopTriggerMethod { get; set; }
    }
}
