using Newtonsoft.Json;
using System;
using Connect.Common.JsonConverters;

namespace Connect.RESTful.Models
{
    public class Trendbar
    {
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        [JsonProperty("timestamp")]
        public long Time { get; set; }

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
    }
}