using Newtonsoft.Json;
using System;

namespace Connect.RESTful
{
    public class Trendbar
    {
        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        public DateTimeOffset Time => DateTimeOffset.FromUnixTimeMilliseconds(TimeStamp);
    }
}