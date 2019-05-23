using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class VersionRequestMessageArgs : MessageArgsBase
    {
        public VersionRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_VERSION_REQ)
        {
        }
    }
}
