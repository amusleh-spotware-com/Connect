namespace Connect.Common
{
    public static class BaseUrls
    {
        #region Fields

        public const string OauthLiveUrl = "https://connect.spotware.com/apps/";
        public const string OauthSandboxUrl = "https://sandbox-connect.spotware.com/apps/";

        public const string AccountLiveUrl = "https://api.spotware.com/connect/";
        public const string AccountSandboxUrl = "https://sandbox-api.spotware.com/connect/";

        public const string TradingLiveUrl = "tradeapi-{proxy}.spotware.com";
        public const string TradingSandboxUrl = "sandbox-tradeapi.spotware.com";

        public const int TradingPort = 5032;

        #endregion Fields

        #region Methods

        public static string GetBaseUrl(ApiType type, Mode mode, Proxy proxy = Proxy.None)
        {
            switch (type)
            {
                case ApiType.Oauth:
                    return mode == Mode.Live ? OauthLiveUrl : OauthSandboxUrl;

                case ApiType.Account:
                    return mode == Mode.Live ? AccountLiveUrl : AccountSandboxUrl;

                case ApiType.Trading:
                    {
                        string url = mode == Mode.Live ? TradingLiveUrl : TradingSandboxUrl;

                        if (mode == Mode.Live)
                        {
                            string proxyDesc = Utility.GetEnumDescription(proxy);

                            url = proxy == Proxy.None ? url.Replace("-{proxy}", string.Empty) : url.Replace("{proxy}", proxyDesc);
                        }

                        return url;
                    }

                default:
                    return null;
            }
        }

        #endregion Methods
    }
}