using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class TraderUpdatedEventParameters : ParametersBase
    {
        public TraderUpdatedEventParameters() : base((int)ProtoOAPayloadType.PROTO_OA_TRADER_UPDATE_EVENT)
        {
        }

        public long AccountId { get; set; }
    }
}
