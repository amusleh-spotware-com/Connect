using Connect.Common.Enums;

namespace Connect.Common.Helpers
{
    public static class BaseUrls
    {
        #region Fields

        public const string OauthLiveUrl = "https://connect.spotware.com/apps/";
        public const string OauthSandboxUrl = "https://sandbox-connect.spotware.com/apps/";

        public const string RESTfulLiveUrl = "https://api.spotware.com/connect/";
        public const string RESTfulSandboxUrl = "https://sandbox-api.spotware.com/connect/";

        public const string ProtobufLiveUrl = "live.ctraderapi.com";
        public const string ProtobufDemoUrl = "demo.ctraderapi.com";

        public const int ProtobufPort = 5035;

        #endregion Fields

        #region Methods

        public static string GetBaseUrl(ApiType type, Mode mode)
        {
            switch (type)
            {
                case ApiType.Oauth:
                    return mode == Mode.Live ? OauthLiveUrl : OauthSandboxUrl;

                case ApiType.RESTful:
                    return mode == Mode.Live ? RESTfulLiveUrl : RESTfulSandboxUrl;

                case ApiType.Protobuf:
                    return mode == Mode.Live ? ProtobufLiveUrl : ProtobufDemoUrl;

                default:
                    return null;
            }
        }

        #endregion Methods
    }
}