using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class PingRequestParameters: ParametersBase
    {
        public PingRequestParameters() : base((int)ProtoPayloadType.PING_REQ)
        {
        }

        public ulong Timestamp { get; set; }
    }
}
