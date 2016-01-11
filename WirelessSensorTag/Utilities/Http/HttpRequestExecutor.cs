using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WirelessSensorTag.Exceptions;
using WirelessSensorTag.Extensions;

namespace WirelessSensorTag.Utilities.Http
{
    public class HttpRequestExecutor : IHttpRequestExecutor
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HttpRequestExecutor(IHttpClientFactory httpClientFactory)
        {
            httpClientFactory.ThrowIfParameterIsNull(nameof(httpClientFactory));

            this.httpClientFactory = httpClientFactory;
        }

        public async Task<TResponse> Put<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> bodyParameter, string token = null)
            where TResponse : class
        {
            var client = httpClientFactory.CreateHttpClient(token);
            var content = new FormUrlEncodedContent(bodyParameter);
            var response = await client.PutAsync(url, content);
            return await HandleResponse<TResponse>(response);
        }

        public async Task<TResponse> Delete<TResponse>(string url, string token = null)
            where TResponse : class
        {
            var client = httpClientFactory.CreateHttpClient(token);

            var bodyParameter = new List<KeyValuePair<string, string>>()
            {
            };

            var content = new FormUrlEncodedContent(bodyParameter);

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Delete, url);
            requestMessage.Content = content;

            var response = await client.SendAsync(requestMessage);
            return await HandleResponse<TResponse>(response);
        }

        public async Task<TResponse> Post<TContent, TResponse>(string url, TContent bodyParameter, string token = null)
            where TResponse : class where TContent : class
        {
            var client = httpClientFactory.CreateHttpClient(token);
            var response = await client.PostAsync(url, CreateJsonContent<TContent>(bodyParameter));
            return await HandleResponse<TResponse>(response);
        }

        public async Task<TResponse> Post<TResponse>(string url, byte[] bodyParameter, string token = null)
            where TResponse : class
        {
            var client = httpClientFactory.CreateHttpClient(token);
            var response = await client.PostAsync(url, new ByteArrayContent(bodyParameter));
            return await HandleResponse<TResponse>(response);
        }

        public async Task<TResponse> Get<TResponse>(string url, string token = null)
            where TResponse : class
        {
            var client = httpClientFactory.CreateHttpClient(token);
            HttpResponseMessage response = await client.GetAsync(url);
            return await HandleResponse<TResponse>(response);
        }

        public async Task<string> GetContent(string url, string token = null)
        {
            var client = httpClientFactory.CreateHttpClient(token);
            HttpResponseMessage response = await client.GetAsync(url);

            var contentAsString = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return contentAsString;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new SecurityException();
            }

            return null;
        }

        private static StringContent CreateJsonContent<TContent>(TContent bodyParameter) where TContent : class
        {
            var content = JsonConvert.SerializeObject(bodyParameter);

            return new StringContent(content, Encoding.UTF8, "application/json");
        }

        private static async Task<TResponse> HandleResponse<TResponse>(HttpResponseMessage response) where TResponse : class
        {
            var contentAsString = await response.Content.ReadAsStringAsync();

            try
            {
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TResponse>(contentAsString);
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new SecurityException();
                }
            }
            catch (SecurityException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new HttpException(contentAsString);
            }

            return null;
        }
    }
}
