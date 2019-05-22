using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class ReconcileRequestMessageArgs : MessageArgsBase
    {
        public long AccountId { get; set; }
    }
}
