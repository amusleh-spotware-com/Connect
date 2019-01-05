using Newtonsoft.Json;
using System;
using Connect.Common;

namespace Connect.RESTful
{
    public class Deal
    {
        #region Properties

        [JsonProperty("dealId")]
        public long DealId { get; set; }

        [JsonProperty("positionId")]
        public long PositionId { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("tradeSide")]
        public string TradeSide { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("filledVolume")]
        public long FilledVolume { get; set; }

        [JsonProperty("symbolName")]
        public string SymbolName { get; set; }

        [JsonProperty("commision")]
        public long Commission { get; set; }

        [JsonProperty("executionPrice")]
        public double ExecutionPrice { get; set; }

        [JsonProperty("baseToUsdConversionRate")]
        public double BaseToUsdConversionRate { get; set; }

        [JsonProperty("marginRate")]
        public double MarginRate { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("createTimestamp")]
        public long CreateTimestamp { get; set; }

        [JsonProperty("executionTimestamp")]
        public long ExecutionTimestamp { get; set; }

        [JsonProperty("positionCloseDetails")]
        public PositionCloseDetails CloseDetails { get; set; }

        public DateTimeOffset CreateTime => DateTimeOffset.FromUnixTimeMilliseconds(CreateTimestamp);

        public DateTimeOffset ExecutionTime => DateTimeOffset.FromUnixTimeMilliseconds(ExecutionTimestamp);

        public TradeType TradeType => Utility.ParseEnum(TradeSide, TradeType.None);

        #endregion Properties

        #region Methods

        public static bool operator !=(Deal obj1, Deal obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return !object.ReferenceEquals(obj2, null);
            }

            return !obj1.Equals(obj2);
        }

        public static bool operator ==(Deal obj1, Deal obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return object.ReferenceEquals(obj2, null);
            }

            return obj1.Equals(obj2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Deal))
            {
                return false;
            }

            return Equals((Deal)obj);
        }

        public bool Equals(Deal other) => other?.DealId == DealId && other.OrderId == OrderId && other.PositionId == PositionId;

        public override int GetHashCode()
        {
            int hash = 17;

            hash = (hash * 31) + DealId.GetHashCode();
            hash = (hash * 31) + OrderId.GetHashCode();
            hash = (hash * 31) + PositionId.GetHashCode();

            return hash;
        }

        #endregion Methods
    }
}