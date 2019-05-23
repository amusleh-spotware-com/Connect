using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.MessageArgs
{
    public class AccountLogoutRequestMessageArgs : MessageArgsBase
    {
        public AccountLogoutRequestMessageArgs(): base((int)ProtoOAPayloadType.PROTO_OA_ACCOUNT_LOGOUT_REQ)
        {
        }

        public long AccountId { get; set; }
    }
}
