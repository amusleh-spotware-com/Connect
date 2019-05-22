using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class AppAuthorizationRequestMessageArgs : MessageArgsBase
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
