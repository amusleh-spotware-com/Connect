using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class ExecutionEventMessageArgs : MessageArgsBase
    {
        public ExecutionEventMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_EXECUTION_EVENT)
        {
        }

        public ProtoOAExecutionType ExecutionType { get; set; }

        public ProtoOAOrder Order { get; set; }

        public ProtoOAOrder.Builder OrderBuilder { get; set; }

        public ProtoOAPosition Position { get; set; }

        public ProtoOAPosition.Builder PositionBuilder { get; set; }

        public string ErrorCode { get; set; }
    }
}
