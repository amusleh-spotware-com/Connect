using Newtonsoft.Json;

namespace Connect.Account
{
    public class DepositWithdrawRes
    {
        [JsonProperty("cashflowId")]
        public long CashflowId { get; set; }
    }
}