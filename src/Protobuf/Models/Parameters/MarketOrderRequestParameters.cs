using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class MarketOrderRequestParameters : OrderRequestParameters
    {
        public MarketOrderRequestParameters(): base(ProtoOAOrderType.MARKET)
        {
        }

        public MarketOrderRequestParameters(ProtoOAOrderType orderType) : base(orderType)
        {
        }

        public long? RelativeStopLoss { get; set; }

        public long? RelativeTakeProfit { get; set; }

        public long? PositionId { get; set; }
    }
}
