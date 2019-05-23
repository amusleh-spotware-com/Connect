using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class MarketRangeOrderRequestParameters : MarketOrderRequestParameters
    {
        public MarketRangeOrderRequestParameters()
        {
            OrderType = ProtoOAOrderType.MARKET_RANGE;
        }

        public double BaseSlippagePrice { get; set; }

        public int SlippageInPoints { get; set; }
    }
}
