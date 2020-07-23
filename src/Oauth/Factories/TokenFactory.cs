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