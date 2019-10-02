using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class AccountListRequestParameters : ParametersBase
    {
        public AccountListRequestParameters() : base((int)ProtoOAPayloadType.PROTO_OA_GET_ACCOUNTS_BY_ACCESS_TOKEN_REQ)
        {
        }

        public string Token { get; set; }
    }
}
