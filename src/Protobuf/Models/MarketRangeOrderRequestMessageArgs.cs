using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class MarketRangeOrderRequestMessageArgs : MarketOrderRequestMessageArgs
    {
        public MarketRangeOrderRequestMessageArgs()
        {
            OrderType = ProtoOAOrderType.MARKET_RANGE;
        }

        public double BaseSlippagePrice { get; set; }

        public int SlippageInPoints { get; set; }
    }
}
