using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class AccountListRequestMessageArgs : MessageArgsBase
    {
        public AccountListRequestMessageArgs() : base((int)ProtoOAPayloadType.PROTO_OA_GET_ACCOUNTS_BY_ACCESS_TOKEN_REQ)
        {
        }

        public string Token { get; set; }
    }
}
