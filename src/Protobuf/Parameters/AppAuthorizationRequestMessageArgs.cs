using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class AppAuthorizationRequestMessageArgs : MessageArgsBase
    {
        public AppAuthorizationRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_APPLICATION_AUTH_REQ)
        {
        }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
