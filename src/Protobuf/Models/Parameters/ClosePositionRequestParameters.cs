using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class ClosePositionRequestParameters : ParametersBase
    {
        public ClosePositionRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_CLOSE_POSITION_REQ)
        {
        }

        public long AccountId { get; set; }

        public long PositionId { get; set; }

        public long Volume { get; set; }
    }
}
