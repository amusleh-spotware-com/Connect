using Connect.Common.Enums;

namespace Connect.Common.Helpers
{
    public static class BaseUrls
    {
        #region Fields

        public const string OauthUrl = "https://connect.spotware.com/apps/";

        public const string ProtobufLiveUrl = "live.ctraderapi.com";
        public const string ProtobufDemoUrl = "demo.ctraderapi.com";

        public const int ProtobufPort = 5035;

        #endregion Fields

        #region Methods

        public static string GetBaseUrl(Mode mode) => mode == Mode.Live ? ProtobufLiveUrl : ProtobufDemoUrl;

        #endregion Methods
    }
}