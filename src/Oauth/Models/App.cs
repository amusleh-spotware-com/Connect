namespace Connect.Oauth.Models
{
    public class App
    {
        public App(string clientId, string secret, string redirectUri)
        {
            ClientId = clientId;
            Secret = secret;
            RedirectUri = redirectUri;
        }

        #region Properties

        public string ClientId { get; }
        public string Secret { get; }
        public string RedirectUri { get; }

        #endregion Properties
    }
}