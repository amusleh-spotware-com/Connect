using Connect.Common.JsonConverters;
using Connect.Common.Utils;
using Connect.RESTful.Enums;
using Newtonsoft.Json;

namespace Connect.RESTful.Models
{
    public class Position
    {
        #region Properties

        [JsonProperty("positionID")]
        public long Id { get; set; }

        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        [JsonProperty("entryTimestamp")]
        public long EntryTime { get; set; }

        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        [JsonProperty("utcLastUpdateTimestamp")]
        public long UtcLastUpdateTime { get; set; }

        [JsonProperty("symbolName")]
        public string SymbolName { get; set; }

        [JsonProperty("tradeSide")]
        public string TradeSide { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("entryPrice")]
        public double EntryPrice { get; set; }

        [JsonProperty("stopLoss")]
        public double? StopLoss { get; set; }

        [JsonProperty("takeProfit")]
        public double? TakeProfit { get; set; }

        [JsonProperty("profit")]
        public long Profit { get; set; }

        [JsonProperty("commission")]
        public long Commission { get; set; }

        [JsonProperty("marginRate")]
        public double MarginRate { get; set; }

        [JsonProperty("swap")]
        public long Swap { get; set; }

        [JsonProperty("currentPrice")]
        public double? CurrentPrice { get; set; }

        [JsonProperty("profitInPips")]
        public double? ProfitInPips { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        public TradeType TradeType => EnumTools.ParseEnum(TradeSide, TradeType.None);

        #endregion Properties

        #region Methods

        public static bool operator !=(Position obj1, Position obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return !object.ReferenceEquals(obj2, null);
            }

            return !obj1.Equals(obj2);
        }

        public static bool operator ==(Position obj1, Position obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return object.ReferenceEquals(obj2, null);
            }

            return obj1.Equals(obj2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Position))
            {
                return false;
            }

            return Equals((Position)obj);
        }

        public bool Equals(Position other) => other?.Id == Id;

        public override int GetHashCode()
        {
            int hash = 17;

            hash = (hash * 31) + Id.GetHashCode();

            return hash;
        }

        #endregion Methods
    }
}