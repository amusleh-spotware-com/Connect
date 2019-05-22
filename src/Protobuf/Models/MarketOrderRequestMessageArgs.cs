using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class MarketOrderRequestMessageArgs : OrderRequestMessageArgs
    {
        public MarketOrderRequestMessageArgs()
        {
            OrderType = ProtoOAOrderType.MARKET;
        }

        public long? RelativeStopLoss { get; set; }

        public long? RelativeTakeProfit { get; set; }

        public long? PositionId { get; set; }
    }
}
