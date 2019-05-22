using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class PendingOrderRequestMessageArgs : OrderRequestMessageArgs
    {
        public double Price { get; set; }

        public double? StopLossInPrice { get; set; }

        public double? TakeProfitInPrice { get; set; }

        public DateTimeOffset? ExpirationTime { get; set; }
    }
}
