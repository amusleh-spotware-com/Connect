using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class CancelOrderRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }

        public long OrderId { get; set; }
    }
}
