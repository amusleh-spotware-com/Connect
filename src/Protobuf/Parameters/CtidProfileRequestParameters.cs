using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class CtidProfileRequestParameters : ParametersBase
    {
        public CtidProfileRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_GET_CTID_PROFILE_BY_TOKEN_REQ)
        {
        }

        public string Token { get; set; }
    }
}
