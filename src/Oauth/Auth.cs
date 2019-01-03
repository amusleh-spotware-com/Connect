using Connect.Common;
using System;
using System.Collections.Generic;
using System.Web;

namespace Connect.Oauth
{
    public class Auth
    {
        #region Constructor

        public Auth(App app, Scope scope = Scope.Trading, Mode mode = Mode.Live)
        {
            App = app;
            Scope = scope;
            Mode = mode;

            UriBuilder authURIBuilder = new UriBuilder(BaseUrls.GetBaseUrl(ApiType.Oauth, mode));

            authURIBuilder.Path += "auth";

            authURIBuilder.Query = $"client_id={App.ClientId}&redirect_uri={App.RedirectUri}&scope={Utility.GetEnumDescription(Scope)}";

            AuthUri = authURIBuilder.Uri;
        }

        #endregion Constructor

        #region Properties

        public App App { get; private set; }

        public Scope Scope { get; private set; }

        public Mode Mode { get; private set; }

        public Uri AuthUri { get; private set; }

        #endregion Properties

        #region Methods

        public AuthCode GetAuthCode(string url)
        {
            Uri codeUri = new Uri(url);

            string code = string.Empty;

            try
            {
                code = HttpUtility.ParseQueryString(codeUri.Query).Get("code");

                return new AuthCode(code, App, Scope, Mode);
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("The authentication code parameter not found in provided URL", ex);
            }
        }

        #endregion Methods
    }
}