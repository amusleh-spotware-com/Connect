using Newtonsoft.Json;

namespace Connect.Account
{
    public class PositionCloseDetails
    {
        #region Properties

        [JsonProperty("entryPrice")]
        public double EntryPrice { get; set; }

        [JsonProperty("profit")]
        public long Profit { get; set; }

        [JsonProperty("swap")]
        public long Swap { get; set; }

        [JsonProperty("commission")]
        public long Commission { get; set; }

        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("balanceVersion")]
        public long BalanceVersion { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("stopLossPrice")]
        public double? StopLossPrice { get; set; }

        [JsonProperty("takeProfitPrice")]
        public double? TakeProfitPrice { get; set; }

        [JsonProperty("quoteToDepositConversionRate ")]
        public double? QuoteToDepositConversionRate { get; set; }

        [JsonProperty("closedVolume")]
        public long ClosedVolume { get; set; }

        [JsonProperty("profitInPips")]
        public double ProfitInPips { get; set; }

        [JsonProperty("roi")]
        public double Roi { get; set; }

        [JsonProperty("equityBasedROI")]
        public double EquityBasedRoi { get; set; }

        [JsonProperty("equity")]
        public long Equity { get; set; }

        #endregion Properties
    }
}