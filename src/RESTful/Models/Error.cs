using Newtonsoft.Json;
using Connect.Common;
using System;
using Connect.Common.JsonConverters;

namespace Connect.RESTful.Models
{
    public class Error
    {
        #region Properties

        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
        [JsonProperty("errorCode")]
        public ErrorCode Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        #endregion Properties
    }
}