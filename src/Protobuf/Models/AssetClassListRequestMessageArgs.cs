using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class AssetClassListRequestMessageArgs : MessageArgsBase
    {
        public AssetClassListRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_ASSET_CLASS_LIST_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
