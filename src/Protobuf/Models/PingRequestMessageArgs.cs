using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class PingRequestMessageArgs: MessageArgsBase
    {
        public PingRequestMessageArgs() : base((int)ProtoPayloadType.PING_REQ)
        {
        }

        public ulong Timestamp { get; set; }
    }
}
