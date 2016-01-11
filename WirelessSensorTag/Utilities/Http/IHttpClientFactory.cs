using System.Net.Http;

namespace WirelessSensorTag.Utilities.Http
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient(string authenticationKey);
    }
}
