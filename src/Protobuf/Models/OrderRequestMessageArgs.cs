﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models
{
    public class OrderRequestMessageArgs : MessageArgsBase
    {
        public ProtoOAOrderType OrderType { get; set; }

        public long AccountId { get; set; }

        public long SymbolId { get; set; }

        public ProtoOATradeSide TradeSide { get; set; }

        public long Volume { get; set; }

        public string Comment { get; set; }

        public string Label { get; set; }
    }
}