using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters
{
    public class AccountAuthorizationRequestParameters : ParametersBase
    {
        public AccountAuthorizationRequestParameters(): base((int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_AUTH_REQ)
        {
        }

        public string Token { get; set; }

        public long AccountId { get; set; }
    }
}
