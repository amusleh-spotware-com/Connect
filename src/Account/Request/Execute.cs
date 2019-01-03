using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Connect.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Connect.Account.Request
{
    public static class Execute
    {
        #region Fields

        private static DateTime _lastRequestTime;

        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        #endregion

        #region Methods

        private static async Task WaitForRequestExecutionTime()
        {
            await _semaphore.WaitAsync();

            TimeSpan timeDiff = DateTime.Now - _lastRequestTime;

            TimeSpan timeToWait = TimeSpan.FromSeconds(5);

            if (timeDiff < timeToWait)
            {
                await Task.Delay(timeToWait - timeDiff);
            }

            _lastRequestTime = DateTime.Now;

            _semaphore.Release();
        }

        public static async Task<List<T>> Get<T>(RestClient restClient, RestRequest request, string cursor = null) where T : new()
        {
            await WaitForRequestExecutionTime();

            if (!string.IsNullOrEmpty(cursor))
            {
                request.AddOrUpdateParameter("cursor", cursor, ParameterType.QueryString);
            }

            IRestResponse response = await restClient.ExecuteGetTaskAsync(request);

            List<T> result = new List<T>();

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                StringBuilder exMessage = new StringBuilder(ExceptionMessages.BadResponse);

                exMessage.AppendLine($"Response: {response.Content}");

                throw new WebException(exMessage.ToString());
            }

            JObject jObject = null;

            try
            {
                jObject = JObject.Parse(response.Content);

                result.Add(JsonConvert.DeserializeObject<T>(jObject["data"].ToString()));

                if (jObject.GetValue("next") != null)
                {
                    string nextCursor = jObject["next"].ToString();

                    if (!string.IsNullOrEmpty(nextCursor))
                    {
                        result.AddRange(await Get<T>(restClient, request, nextCursor));
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                StringBuilder exMessage = new StringBuilder(ex.Message);

                exMessage.AppendLine($"Response: {response.Content}");

                Error error = jObject?.GetValue("error") != null ? JsonConvert.DeserializeObject<Error>(jObject["error"].ToString()) : null;

                throw error != null ? new ConnectException(exMessage.ToString(), ex, error.Code) : new ConnectException(
                    exMessage.ToString(), ex);
            }
        }

        public static async Task<HttpStatusCode> Post(RestClient restClient, RestRequest request)
        {
            await WaitForRequestExecutionTime();

            IRestResponse response = await restClient.ExecutePostTaskAsync(request);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                StringBuilder exMessage = new StringBuilder(ExceptionMessages.BadResponse);

                exMessage.AppendLine($"Response: {response.Content}");

                JObject jObject = JObject.Parse(response.Content);

                Error error = jObject?.GetValue("error") != null ? JsonConvert.DeserializeObject<Error>(jObject["error"].ToString()) : null;

                throw error != null ? new ConnectException(exMessage.ToString(), error.Code) : new ConnectException(exMessage.ToString());
            }

            return response.StatusCode;
        }

        public static async Task<T> Post<T>(RestClient restClient, RestRequest request)
        {
            await WaitForRequestExecutionTime();

            IRestResponse response = await restClient.ExecutePostTaskAsync(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                StringBuilder exMessage = new StringBuilder(ExceptionMessages.BadResponse);

                exMessage.AppendLine($"Response: {response.Content}");

                throw new WebException(exMessage.ToString());
            }

            JObject jObject = null;

            try
            {
                jObject = JObject.Parse(response.Content);

                return JsonConvert.DeserializeObject<T>(jObject["data"].ToString());
            }
            catch (Exception ex)
            {
                StringBuilder exMessage = new StringBuilder(ex.Message);

                exMessage.AppendLine($"Response: {response.Content}");

                Error error = jObject?.GetValue("error") != null ? JsonConvert.DeserializeObject<Error>(jObject["error"].ToString()) : null;

                throw error != null ? new ConnectException(exMessage.ToString(), ex, error.Code) : new ConnectException(
                    exMessage.ToString(), ex);
            }
        }

        #endregion
    }
}