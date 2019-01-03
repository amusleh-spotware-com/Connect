namespace Connect.Oauth
{
    public class App
    {
        #region Constructor

        public App()
        {
        }

        public App(string clientId, string secret, string redirectUri)
        {
            ClientId = clientId;
            Secret = secret;
            RedirectUri = redirectUri;
        }

        #endregion Constructor

        #region Properties

        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string RedirectUri { get; set; }

        #endregion Properties
    }
}