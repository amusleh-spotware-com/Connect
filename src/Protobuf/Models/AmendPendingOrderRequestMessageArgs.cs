using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class AmendPendingOrderRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }

        public long OrderId { get; set; }

        public ProtoOAOrderType OrderType { get; set; }

        public double? Price { get; set; }

        public DateTimeOffset? ExpirationTime { get; set; }

        public double? StopLossPrice { get; set; }

        public double? TakeProfitPrice { get; set; }
    }
}
