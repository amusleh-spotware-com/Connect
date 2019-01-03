using Newtonsoft.Json;
using System;
using Connect.Common;

namespace Connect.Account
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

        [JsonProperty("createTimestamp")]
        public long CreateTimestamp { get; set; }

        [JsonProperty("expirationTimestamp")]
        public long? ExpirationTimestamp { get; set; }

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

        public DateTimeOffset CreateTime => DateTimeOffset.FromUnixTimeMilliseconds(CreateTimestamp);

        public DateTimeOffset? ExpirationTime => ExpirationTimestamp.HasValue ?
            (DateTimeOffset?)DateTimeOffset.FromUnixTimeMilliseconds(ExpirationTimestamp.Value) : null;

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