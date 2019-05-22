using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    interface IMessageArgs
    {
        string ClientMessageId { get; set; }
    }
}
