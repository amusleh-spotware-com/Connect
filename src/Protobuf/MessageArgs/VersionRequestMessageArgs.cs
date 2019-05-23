using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class VersionRequestMessageArgs : MessageArgsBase
    {
        public VersionRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_VERSION_REQ)
        {
        }
    }
}
