using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class HeartbeatEventMessageArgs : MessageArgsBase
    {
        public HeartbeatEventMessageArgs() : base((int)ProtoPayloadType.HEARTBEAT_EVENT)
        {
        }
    }
}
