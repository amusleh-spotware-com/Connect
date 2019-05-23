using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
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
