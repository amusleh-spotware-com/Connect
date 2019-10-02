using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class AppAuthorizationRequestParameters : ParametersBase
    {
        public AppAuthorizationRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_APPLICATION_AUTH_REQ)
        {
        }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
