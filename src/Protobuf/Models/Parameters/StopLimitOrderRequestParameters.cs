using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class StopLimitOrderRequestParameters : PendingOrderRequestParameters
    {
        public StopLimitOrderRequestParameters(): base(ProtoOAOrderType.STOP_LIMIT)
        {
        }

        public int SlippageInPoints { get; set; }
    }
}
