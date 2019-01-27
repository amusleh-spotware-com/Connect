using Newtonsoft.Json;
using Connect.Common;
using System;

namespace Connect.RESTful.Models
{
    public class Error
    {
        #region Properties

        [JsonProperty("errorCode")]
        public string CodeText { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public ErrorCode Code => Utility.ParseEnum(CodeText, ErrorCode.None);

        #endregion Properties
    }
}