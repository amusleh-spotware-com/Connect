using RestSharp;
using System;

namespace Connect.RESTful.Request
{
    public static class Factory
    {
        public static RestRequest GetRequest(string resource, string accessToken, Method method = Method.GET)
        {
            RestRequest request = new RestRequest(resource, method);

            request.AddParameter(Request.Parameters.AccessToken, accessToken, ParameterType.QueryString);

            return request;
        }

        public static RestRequest GetRequest(string resource, string accessToken, long limit, Method method = Method.GET)
        {
            RestRequest request = new RestRequest(resource, method);

            request.AddParameter(Request.Parameters.AccessToken, accessToken, ParameterType.QueryString);
            request.AddParameter(Request.Parameters.Limit, limit, ParameterType.QueryString);

            return request;
        }

        public static RestRequest GetRequest(
            string resource,
            string accessToken,
            DateTimeOffset from,
            DateTimeOffset to,
            bool isTimeStamp = true,
            long? limit = null,
            Method method = Method.GET)
        {
            RestRequest request = new RestRequest(resource, method);

            request.AddParameter(Request.Parameters.AccessToken, accessToken, ParameterType.QueryString);

            if (isTimeStamp)
            {
                request.AddParameter(Request.Parameters.FromTimestamp, from.ToUnixTimeMilliseconds(), ParameterType.QueryString);
                request.AddParameter(Request.Parameters.ToTimestamp, to.ToUnixTimeMilliseconds(), ParameterType.QueryString);
            }
            else
            {
                request.AddParameter(Request.Parameters.From, from.ToString("yyyyMMddHHmmss"), ParameterType.QueryString);
                request.AddParameter(Request.Parameters.To, to.ToString("yyyyMMddHHmmss"), ParameterType.QueryString);
            }

            if (limit.HasValue)
            {
                request.AddParameter(Request.Parameters.Limit, limit.Value, ParameterType.QueryString);
            }

            return request;
        }

        public static RestRequest GetRequest(
            string resource,
            string accessToken,
            DateTime date,
            TimeSpan from,
            TimeSpan to,
            long? limit = null,
            Method method = Method.GET)
        {
            RestRequest request = new RestRequest(resource, method);

            request.AddParameter(Request.Parameters.AccessToken, accessToken, ParameterType.QueryString);
            request.AddParameter(Request.Parameters.Date, date.ToString("yyyyMMdd"), ParameterType.QueryString);
            request.AddParameter(Request.Parameters.From, from.ToString("hhmmss"), ParameterType.QueryString);
            request.AddParameter(Request.Parameters.To, to.ToString("hhmmss"), ParameterType.QueryString);

            if (limit.HasValue)
            {
                request.AddParameter(Request.Parameters.Limit, limit.Value, ParameterType.QueryString);
            }

            return request;
        }
    }
}