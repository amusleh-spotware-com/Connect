using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class HeartbeatEventParameters : ParametersBase
    {
        public HeartbeatEventParameters() : base((int)ProtoPayloadType.HEARTBEAT_EVENT)
        {
        }
    }
}
