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

        public static async Task<Token> GetTokenAsync(AuthCode authCode, string authUri = BaseUrls.OauthUrl)
        {
            var client = new RestClient(authUri);

            var request = GetTokenRequest(authCode);

            var response = await client.ExecuteGetAsync(request).ConfigureAwait(false);

            var token = DeserializeToken(response);

            token.Mode = authCode.Mode;

            return token;
        }

        public static Token GetToken(AuthCode authCode, string authUri = BaseUrls.OauthUrl)
        {
            var client = new RestClient(authUri);

            var request = GetTokenRequest(authCode);

            var response = client.Execute(request);

            var token = DeserializeToken(response);

            token.Mode = authCode.Mode;

            return token;
        }

        private static RestRequest GetTokenRequest(AuthCode authCode)
        {
            var request = new RestRequest("token");

            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", authCode.Code);
            request.AddParameter("redirect_uri", authCode.App.RedirectUri);
            request.AddParameter("client_id", authCode.App.ClientId);
            request.AddParameter("client_secret", authCode.App.Secret);

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

        #endregion Methods
    }
}