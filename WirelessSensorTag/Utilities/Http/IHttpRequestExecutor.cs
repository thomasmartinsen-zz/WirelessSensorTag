using System.Collections.Generic;
using System.Threading.Tasks;

namespace WirelessSensorTag.Utilities.Http
{
    public interface IHttpRequestExecutor
    {
        Task<TResponse> Put<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> bodyParameter, string token = null) where TResponse : class;

        Task<TResponse> Delete<TResponse>(string url, string token = null) where TResponse : class;

        Task<TResponse> Post<TContent, TResponse>(string url, TContent bodyParameter, string token = null) where TResponse : class where TContent : class;

        Task<TResponse> Post<TResponse>(string url, byte[] bodyParameter, string token = null) where TResponse : class;

        Task<TResponse> Get<TResponse>(string url, string token = null) where TResponse : class;

        Task<string> GetContent(string url, string token = null);
    }
}
