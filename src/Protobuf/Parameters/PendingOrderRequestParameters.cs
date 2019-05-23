using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
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
    }
}
