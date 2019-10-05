using Connect.Common.Enums;
using Connect.Common.JsonConverters;
using Newtonsoft.Json;
using System;

namespace Connect.Oauth.Models
{
    public class Token
    {
        #region Properties

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonConverter(typeof(RelativeSecondsDateTimeOffsetConverter))]
        [JsonProperty("expiresIn")]
        public DateTimeOffset ExpiresIn { get; set; }

        [JsonProperty("tokenType")]
        public string TokenType { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonConverter(typeof(ErrorCodeConverter))]
        [JsonProperty("errorCode")]
        public ErrorCode ErrorCode { get; set; }

        [JsonProperty("description")]
        public string ErrorDescription { get; set; }

        public Mode Mode { get; set; }

        #endregion Properties
    }
}