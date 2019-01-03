using Newtonsoft.Json;
using System;

namespace Connect.Account
{
    public class TickData
    {
        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("tick")]
        public double Tick { get; set; }

        public DateTimeOffset Time => DateTimeOffset.FromUnixTimeMilliseconds(TimeStamp);
    }
}