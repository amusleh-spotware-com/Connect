using Connect.Common.Enums;
using Connect.Common.JsonConverters;
using Newtonsoft.Json;

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