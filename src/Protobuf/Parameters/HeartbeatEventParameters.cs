using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class HeartbeatEventParameters : ParametersBase
    {
        public HeartbeatEventParameters() : base((int)ProtoPayloadType.HEARTBEAT_EVENT)
        {
        }
    }
}
