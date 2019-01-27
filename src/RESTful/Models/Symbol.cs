using Newtonsoft.Json;
using System;
using Connect.RESTful.Enums;

namespace Connect.RESTful.Models
{
    public class Symbol
    {
        #region Properties

        [JsonProperty("symbolName")]
        public string Name { get; set; }

        [JsonProperty("digits")]
        public int Digits { get; set; }

        [JsonProperty("pipPosition")]
        public int PipPosition { get; set; }

        [JsonProperty("measurementUnits")]
        public string MeasurementUnits { get; set; }

        [JsonProperty("baseAsset")]
        public string BaseAsset { get; set; }

        [JsonProperty("quoteAsset")]
        public string QuoteAsset { get; set; }

        [JsonProperty("tradeEnabled")]
        public bool TradeEnabled { get; set; }

        [JsonProperty("tickSize")]
        public double TickSize { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("maxLeverage")]
        public int MaxLeverage { get; set; }

        [JsonProperty("minOrderVolume")]
        public long MinOrderVolume { get; set; }

        [JsonProperty("minOrderStep")]
        public long MinOrderStep { get; set; }

        [JsonProperty("maxOrderVolume")]
        public long MaxOrderVolume { get; set; }

        [JsonProperty("swapLong")]
        public double SwapLong { get; set; }

        [JsonProperty("swapShort")]
        public double SwapShort { get; set; }

        [JsonProperty("threeDaysSwaps")]
        public string ThreeDaysSwaps { get; set; }

        [JsonProperty("assetClass")]
        public string AssetClass { get; set; }

        [JsonProperty("lastBid")]
        public double? LastBid { get; set; }

        [JsonProperty("lastAsk")]
        public double? LastAsk { get; set; }

        public string DescriptiveName => $"{Name}, {Description}";

        public double PipSize => TickSize * Math.Pow(10, Digits - PipPosition);

        public SymbolType Type => GetSymbolType(this);

        public string TypeText => Type.ToString();

        #endregion Properties

        #region Methods

        public static bool operator !=(Symbol obj1, Symbol obj2)
        {
            return object.ReferenceEquals(obj1, null) ? !object.ReferenceEquals(obj2, null) : !obj1.Equals(obj2);
        }

        public static bool operator ==(Symbol obj1, Symbol obj2)
        {
            return object.ReferenceEquals(obj1, null) ? object.ReferenceEquals(obj2, null) : obj1.Equals(obj2);
        }

        public override bool Equals(object obj)
        {
            return !(obj is Symbol) ? false : Equals((Symbol)obj);
        }

        public bool Equals(Symbol other)
        {
            StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

            if (other != null &&
            other.Name.Equals(Name, comparison) &&
            other.MeasurementUnits.Equals(MeasurementUnits, comparison) &&
            other.Type == Type)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hash = 17;

            hash = !string.IsNullOrEmpty(Name) ? (hash * 31) + Name.GetHashCode() : hash;

            return hash;
        }

        public static SymbolType GetSymbolType(Symbol symbol)
        {
            StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

            if (symbol.BaseAsset.StartsWith(symbol.MeasurementUnits, comparison) &&
                symbol.Name.Equals(symbol.Name.ToUpperInvariant(), comparison))
            {
                return SymbolType.Forex;
            }
            else if (symbol.MeasurementUnits.Equals("Indices", comparison) || symbol.MeasurementUnits.Equals("INDEX", comparison))
            {
                return SymbolType.Indices;
            }
            else if (symbol.MeasurementUnits.Equals("Oz", comparison) || symbol.MeasurementUnits.Equals("OZS", comparison))
            {
                return SymbolType.Metals;
            }
            else if (symbol.MeasurementUnits.Equals("Futures", comparison))
            {
                return SymbolType.Futures;
            }
            else if (symbol.MeasurementUnits.Equals("Barrel", comparison) ||
                symbol.MeasurementUnits.Equals("Barrels", comparison) ||
                symbol.MeasurementUnits.Equals("MMBtu", comparison) ||
                symbol.MeasurementUnits.Equals("BBL", comparison))
            {
                return SymbolType.Energies;
            }
            else
            {
                return SymbolType.None;
            }
        }

        #endregion Methods
    }
}