using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class ClosePositionRequestMessageArgs : MessageArgsBase
    {
        public ClosePositionRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_CLOSE_POSITION_REQ)
        {
        }

        public long AccountId { get; set; }

        public long PositionId { get; set; }

        public long Volume { get; set; }
    }
}
