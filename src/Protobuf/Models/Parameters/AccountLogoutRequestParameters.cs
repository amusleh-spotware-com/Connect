using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public class AccountLogoutRequestParameters : ParametersBase
    {
        public AccountLogoutRequestParameters(): base((int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_LOGOUT_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
