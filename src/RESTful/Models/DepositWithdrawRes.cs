using Newtonsoft.Json;

namespace Connect.RESTful.Models
{
    public class DepositWithdrawRes
    {
        [JsonProperty("cashflowId")]
        public long CashflowId { get; set; }
    }
}