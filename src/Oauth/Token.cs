using Newtonsoft.Json;
using RestSharp;
using Connect.Common;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Connect.Common.JsonConverters;

namespace Connect.Oauth
{
    public class Token
    {
        #region Properties

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonConverter(typeof(UnixDateTimeOffsetConverter))]
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