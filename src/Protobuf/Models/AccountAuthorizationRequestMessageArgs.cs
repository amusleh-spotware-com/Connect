using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class AccountAuthorizationRequestMessageArgs : MessageArgsBase
    {
        public string Token { get; set; }

        public long AccountId { get; set; }
    }
}
