using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class AssetListRequestParameters : ParametersBase
    {
        public AssetListRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_ASSET_LIST_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
