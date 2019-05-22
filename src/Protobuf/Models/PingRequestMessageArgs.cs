using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class PingRequestMessageArgs: MessageArgsBase
    {
        public ulong Timestamp { get; set; }
    }
}
