using Newtonsoft.Json;
using System;
using Connect.Common;
using Connect.RESTful.Enums;
using Connect.Common.JsonConverters;

namespace Connect.RESTful.Models
{
    public class PendingOrder
    {
        #region Properties

        [JsonProperty("orderId")]
        public long Id { get; set; }

        [JsonProperty("symbolName")]
        public string SymbolName { get; set; }

        [JsonProperty("orderType")]
        public string OrderTypeText { get; set; }

        [JsonProperty("tradeSide")]
        public string TradeSide { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("stopLoss")]
        public double? StopLoss { get; set; }

        [JsonProperty("takeProfit")]
        public double? TakeProfit { get; set; }

        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        [JsonProperty("createTimestamp")]
        public long CreateTime { get; set; }

        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        [JsonProperty("expirationTimestamp")]
        public long? ExpirationTime { get; set; }

        [JsonProperty("currentPrice")]
        public double? CurrentPrice { get; set; }

        [JsonProperty("distanceInPips")]
        public double? DistanceInPips { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        public TradeType TradeType => Utility.ParseEnum(TradeSide, TradeType.None);

        public OrderType OrderType => Utility.ParseEnum(OrderTypeText, OrderType.None);

        #endregion Properties

        #region Methods

        public static bool operator !=(PendingOrder obj1, PendingOrder obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return !object.ReferenceEquals(obj2, null);
            }

            return !obj1.Equals(obj2);
        }

        public static bool operator ==(PendingOrder obj1, PendingOrder obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return object.ReferenceEquals(obj2, null);
            }

            return obj1.Equals(obj2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is PendingOrder))
            {
                return false;
            }

            return Equals((PendingOrder)obj);
        }

        public bool Equals(PendingOrder other) => other?.Id == Id;

        public override int GetHashCode()
        {
            int hash = 17;

            hash = (hash * 31) + Id.GetHashCode();

            return hash;
        }

        #endregion Methods
    }
}