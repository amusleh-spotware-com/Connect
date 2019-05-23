using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class MarketOrderRequestParameters : OrderRequestParameters
    {
        public MarketOrderRequestParameters()
        {
            OrderType = ProtoOAOrderType.MARKET;
        }

        public long? RelativeStopLoss { get; set; }

        public long? RelativeTakeProfit { get; set; }

        public long? PositionId { get; set; }
    }
}
