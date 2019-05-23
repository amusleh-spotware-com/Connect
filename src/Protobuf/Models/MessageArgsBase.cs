using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public abstract class MessageArgsBase : IMessageArgs
    {
        public MessageArgsBase(int payloadType)
        {
            PayloadType = payloadType;
        }

        public string ClientMessageId { get; set; }

        public int PayloadType { get; private set; }
    }
}
