using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Parameters.Abstractions
{
    public interface IParameters
    {
        string ClientMessageId { get; }

        int PayloadType { get; }
    }
}
