using System;
using WirelessSensorTag.Api;
using WirelessSensorTag.Common;
using WirelessSensorTag.Utilities.Http;

namespace WirelessSensorTag
{
    public class Client : IClient
    {
        private readonly IConfiguration configuration;
        private readonly IHttpRequestExecutor httpRequestExecutor;

        public Client()
        {
            Uri wirelessTagEndpointUrl = new Uri("http://www.mytaglist.com");
            configuration = new Configuration(wirelessTagEndpointUrl);

            IHttpClientFactory httpClientFactory = new HttpClientFactory();
            httpRequestExecutor = new HttpRequestExecutor(httpClientFactory);

            LogShared = new LogShared(configuration, httpRequestExecutor);
        }

        public ILogShared LogShared { get; set; }
    }
}
