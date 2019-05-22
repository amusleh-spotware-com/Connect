using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class AmendPositionProtectionRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }

        public long PositionId { get; set; }

        public double? StopLossPrice { get; set; }

        public double? TakeProfitPrice { get; set; }
    }
}
