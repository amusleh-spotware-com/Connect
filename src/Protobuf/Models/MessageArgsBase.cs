using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class MessageArgsBase : IMessageArgs
    {
        public string ClientMessageId { get; set; }
    }
}
