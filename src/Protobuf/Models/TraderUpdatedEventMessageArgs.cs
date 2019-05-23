using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class TraderUpdatedEventMessageArgs : MessageArgsBase
    {
        public TraderUpdatedEventMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_TRADER_UPDATE_EVENT)
        {
        }

        public long AccountId { get; set; }
    }
}
