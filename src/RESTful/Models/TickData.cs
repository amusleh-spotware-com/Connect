using Newtonsoft.Json;
using System;
using Connect.Common.JsonConverters;

namespace Connect.RESTful.Models
{
    public class TickData
    {
        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        [JsonProperty("timestamp")]
        public long Time { get; set; }

        [JsonProperty("tick")]
        public double Tick { get; set; }
    }
}