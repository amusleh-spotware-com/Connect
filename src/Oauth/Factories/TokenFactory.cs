using Connect.Common.Helpers;
using Connect.Oauth.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Connect.Oauth.Factories
{
    public static class TokenFactory
    {
        #region Methods

        public static async Task<Token> GetTokenAsync(AuthCode authCode)
        {
            RestClient client = new RestClient(BaseUrls.OauthUrl);

            RestRequest request = GetTokenRequest(authCode);

            IRestResponse response = await client.ExecuteGetAsync(request).ConfigureAwait(false);

            Token token = DeserializeToken(response);

            token.Mode = authCode.Mode;

            return token;
        }

        public static Token GetToken(AuthCode authCode)
        {
            RestClient client = new RestClient(BaseUrls.OauthUrl);

            RestRequest request = GetTokenRequest(authCode);

            IRestResponse response = client.Execute(request);

            Token token = DeserializeToken(response);

            token.Mode = authCode.Mode;

            return token;
        }

        public static async Task RefreshTokenAsync(Token token, App app)
        {
            RestClient client = new RestClient(BaseUrls.OauthUrl);

            RestRequest request = GetRefreshTokenRequest(app, token.RefreshToken);

            IRestResponse response = await client.ExecuteGetAsync(request).ConfigureAwait(false);

            Token newToken = DeserializeToken(response);

            UpdateTokenProperties(newToken, token);
        }

        public static void RefreshToken(Token token, App app)
        {
            RestClient client = new RestClient(BaseUrls.OauthUrl);

            RestRequest request = GetRefreshTokenRequest(app, token.RefreshToken);

            IRestResponse response = client.Execute(request);

            Token newToken = DeserializeToken(response);

            UpdateTokenProperties(newToken, token);
        }

        private static RestRequest GetTokenRequest(AuthCode authCode)
        {
            RestRequest request = new RestRequest("token");

            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", authCode.Code);
            request.AddParameter("redirect_uri", authCode.App.RedirectUri);
            request.AddParameter("client_id", authCode.App.ClientId);
            request.AddParameter("client_secret", authCode.App.Secret);

            return request;
        }

        private static RestRequest GetRefreshTokenRequest(App app, string refreshToken)
        {
            RestRequest request = new RestRequest("token");

            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("refresh_token", refreshToken);
            request.AddParameter("client_id", app.ClientId);
            request.AddParameter("client_secret", app.Secret);

            return request;
        }

        private static Token DeserializeToken(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK && response.ResponseStatus == ResponseStatus.Completed)
            {
                try
                {
                    return JsonConvert.DeserializeObject<Token>(response.Content);
                }
                catch (Exception ex)
                {
                    throw new JsonException("Couldn't deserialize the token request response content to Token object", ex);
                }
            }
            else
            {
                throw new WebException(response.ErrorMessage, response.ErrorException);
            }
        }

        private static void UpdateTokenProperties(Token newtoken, Token oldToken)
        {
            oldToken.AccessToken = newtoken.AccessToken;

            oldToken.ExpiresIn = newtoken.ExpiresIn;

            oldToken.TokenType = newtoken.TokenType;

            oldToken.RefreshToken = newtoken.RefreshToken;

            oldToken.ErrorCode = newtoken.ErrorCode;

            oldToken.ErrorDescription = newtoken.ErrorDescription;
        }

        #endregion Methods
    }
}