using Connect.Common.Enums;
using Connect.Common.Helpers;
using Connect.Common.Utils;
using Connect.Oauth.Enums;
using System;

namespace Connect.Oauth.Models
{
    public class Auth
    {
        public Auth(App app, string authUri = BaseUrls.OauthUrl, Scope scope = Scope.Trading, Mode mode = Mode.Live)
        {
            App = app;
            Scope = scope;
            Mode = mode;

            var authURIBuilder = new UriBuilder(authUri);

            authURIBuilder.Path += "auth";

            authURIBuilder.Query = $"client_id={App.ClientId}&redirect_uri={App.RedirectUri}&scope={EnumTools.GetEnumDescription(Scope)}";

            AuthUri = authURIBuilder.Uri;
        }

        #region Properties

        public App App { get; }

        public Scope Scope { get; }

        public Mode Mode { get; }

        public Uri AuthUri { get; }

        #endregion Properties
    }
}