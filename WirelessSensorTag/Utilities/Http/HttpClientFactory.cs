using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WirelessSensorTag.Utilities.Http
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateHttpClient(string token)
        {
            var handler = new HttpClientHandler();

            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }

            var httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);

            return httpClient;
        }
    }
}
