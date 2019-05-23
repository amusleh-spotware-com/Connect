using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class AssetListRequestMessageArgs : MessageArgsBase
    {
        public AssetListRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
