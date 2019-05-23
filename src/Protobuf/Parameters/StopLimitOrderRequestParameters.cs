using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class StopLimitOrderRequestParameters : PendingOrderRequestParameters
    {
        public StopLimitOrderRequestParameters()
        {
            OrderType = ProtoOAOrderType.STOP_LIMIT;
        }

        public int SlippageInPoints { get; set; }
    }
}
