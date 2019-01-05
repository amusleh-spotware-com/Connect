using Newtonsoft.Json;

namespace Connect.RESTful
{
    public class DepositWithdrawRes
    {
        [JsonProperty("cashflowId")]
        public long CashflowId { get; set; }
    }
}