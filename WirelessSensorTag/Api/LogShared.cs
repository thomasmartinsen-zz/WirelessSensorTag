using System.Threading.Tasks;
using WirelessSensorTag.Api.Dto;
using WirelessSensorTag.Common;
using WirelessSensorTag.Entities;
using WirelessSensorTag.Extensions;
using WirelessSensorTag.Utilities.Http;

namespace WirelessSensorTag.Api
{
    public class LogShared : ILogShared
    {
        private readonly IConfiguration configuration;
        private readonly IHttpRequestExecutor http;

        internal LogShared(IConfiguration configuration, IHttpRequestExecutor http)
        {
            this.configuration = configuration;
            this.http = http;
        }

        public async Task<TemperatureEntity> GetLatestTemperatureRawDataByUUIDAsync(string uuid)
        {
            uuid.ThrowIfParameterIsNullOrWhiteSpace(nameof(uuid));

            WirelessTagUuidRequest content = new WirelessTagUuidRequest()
            {
                UUID = uuid
            };

            string url = string.Concat(configuration.EndpointUrl.AbsoluteUri, "ethLogShared.asmx/GetLatestTemperatureRawDataByUUID");
            var result = await http.Post<WirelessTagUuidRequest, GenericResponse<TemperatureEntity>>(url, content);

            return result.Data;
        }
    }
}
