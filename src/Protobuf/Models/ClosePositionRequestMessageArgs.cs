using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class ClosePositionRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }

        public long PositionId { get; set; }

        public long Volume { get; set; }
    }
}
