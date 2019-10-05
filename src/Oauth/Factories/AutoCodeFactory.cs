using Connect.Common.Enums;
using Connect.Oauth.Enums;
using Connect.Oauth.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Connect.Oauth.Factories
{
    public static class AutoCodeFactory
    {
        /// <summary>
        /// Creates and returns an authentication code model based on the provided authentication URL
        /// </summary>
        /// <param name="url">The API returned URL</param>
        /// <param name="app">The app responsible for the authentication</param>
        /// <param name="scope">The access scope</param>
        /// <param name="mode">The access mode</param>
        /// <returns>AuthCode</returns>
        /// <exception cref="KeyNotFoundException">Code parameter isn't in provided URL</exception>
        /// <exception cref="ArgumentNullException">The query of URL is null</exception>
        public static AuthCode GetAutoCode(string url, App app, Scope scope, Mode mode)
        {
            Uri codeUri = new Uri(url);

            string code = HttpUtility.ParseQueryString(codeUri.Query).Get("code");

            if (string.IsNullOrEmpty(code))
            {
                throw new KeyNotFoundException($"The authentication code parameter not found in provided URL query," +
                    $" the provided URL query is: {codeUri.Query}");
            }

            return new AuthCode(code, app, scope, mode);
        }
    }
}