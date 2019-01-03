using Newtonsoft.Json;
using RestSharp;
using Connect.Common;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Connect.Oauth
{
    public class Token
    {
        #region Properties

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("expiresIn")]
        public long ExpiresInTimestamp { get; set; }

        [JsonProperty("tokenType")]
        public string TokenType { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCodeText { get; set; }

        [JsonProperty("description")]
        public string ErrorDescription { get; set; }

        public ErrorCode ErrorCode => Utility.ParseEnum(ErrorCodeText, ErrorCode.None);

        public DateTimeOffset ExpiresIn => DateTimeOffset.FromUnixTimeMilliseconds(ExpiresInTimestamp);

        public Mode Mode { get; set; }

        #endregion Properties
    }
}