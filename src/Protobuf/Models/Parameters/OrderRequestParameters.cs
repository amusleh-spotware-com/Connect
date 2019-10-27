using System;
using System.Collections.Generic;
using System.Text;

namespace Connect.Protobuf.Models.Parameters
{
    public abstract class OrderRequestParameters : ParametersBase
    {
        public OrderRequestParameters(ProtoOAOrderType orderType) : base((int)ProtoOAPayloadType.PROTO_OA_NEW_ORDER_REQ)
        {
            OrderType = orderType;
        }

        public ProtoOAOrderType OrderType { get; private set; }

        public long AccountId { get; set; }

        public long SymbolId { get; set; }

        public ProtoOATradeSide TradeSide { get; set; }

        public long Volume { get; set; }

        public string Comment { get; set; }

        public string Label { get; set; }

        public bool? GuaranteedStopLoss { get; set; }

        public bool? TrailingStopLoss { get; set; }

        public ProtoOATimeInForce? TimeInForce { get; set; }
    }
}
