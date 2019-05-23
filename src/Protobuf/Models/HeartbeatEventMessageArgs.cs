using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class HeartbeatEventMessageArgs : MessageArgsBase
    {
        public HeartbeatEventMessageArgs() : base((int)ProtoPayloadType.HEARTBEAT_EVENT)
        {
        }
    }
}
