using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class VersionRequestParameters : ParametersBase
    {
        public VersionRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_VERSION_REQ)
        {
        }
    }
}
