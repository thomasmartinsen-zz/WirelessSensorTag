using System;
using System.Collections;
using System.Collections.Generic;
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

        public async Task<MotionEntity> GetDetailLogByUUIDAsync(string uuid, DateTime date)
        {
            uuid.ThrowIfParameterIsNullOrWhiteSpace(nameof(uuid));

            GenericRequest content = new GenericRequest()
            {
                ID = uuid,
                Date = date.ToString(),
            };

            string url = string.Concat(configuration.EndpointUrl.AbsoluteUri, "ethLogShared.asmx/GetDetailLogByUUID");
            var result = await http.Post<GenericRequest, GenericResponse<MotionEntity>>(url, content);

            return result.Data;
        }

        /// <summary>
        /// For specified list of tag UUIDs, retrieves average temperature, battery voltage or humidity of each hour.
        /// </summary>
        /// <param name="uuids"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<StatsCollectionEntity> GetHourlyStatsByUUIDsAsync(string[] uuids, string sensorType)
        {
            uuids.ThrowIfObjectIsNull(nameof(uuids));
            sensorType.ThrowIfParameterIsNullOrWhiteSpace(nameof(sensorType));

            GenericRequest content = new GenericRequest()
            {
                UUIDs = uuids,
                Type = sensorType,
            };

            string url = string.Concat(configuration.EndpointUrl.AbsoluteUri, "ethLogShared.asmx/GetHourlyStatsByUUIDs");
            var result = await http.Post<GenericRequest, GenericResponse<StatsCollectionEntity>>(url, content);

            return result.Data;
        }

        public async Task<TemperatureEntity> GetLatestTemperatureRawDataByUUIDAsync(string uuid)
        {
            uuid.ThrowIfParameterIsNullOrWhiteSpace(nameof(uuid));

            GenericRequest content = new GenericRequest()
            {
                UUID = uuid
            };

            string url = string.Concat(configuration.EndpointUrl.AbsoluteUri, "ethLogShared.asmx/GetLatestTemperatureRawDataByUUID");
            var result = await http.Post<GenericRequest, GenericResponse<TemperatureEntity>>(url, content);

            return result.Data;
        }

        public async Task<IEnumerable<StatsEntity>> GetStatsRawByUUIDAsync(string uuid, DateTime fromDate, DateTime toDate)
        {
            uuid.ThrowIfParameterIsNullOrWhiteSpace(nameof(uuid));

            GenericRequest content = new GenericRequest()
            {
                UUID = uuid,
                FromDate = fromDate.ToString(),
                ToDate = toDate.ToString(),
            };

            string url = string.Concat(configuration.EndpointUrl.AbsoluteUri, "ethLogShared.asmx/GetStatsRawByUUID");
            var result = await http.Post<GenericRequest, GenericResponse<IEnumerable<StatsEntity>>>(url, content);

            return result.Data;
        }

        public async Task<IEnumerable<TemperatureEntity>> GetTemperatureRawDataByUUIDAsync(string uuid)
        {
            uuid.ThrowIfParameterIsNullOrWhiteSpace(nameof(uuid));

            GenericRequest content = new GenericRequest()
            {
                UUID = uuid
            };

            string url = string.Concat(configuration.EndpointUrl.AbsoluteUri, "ethLogShared.asmx/GetTemperatureRawDataByUUID");
            var result = await http.Post<GenericRequest, GenericResponse<IEnumerable<TemperatureEntity>>>(url, content);

            return result.Data;
        }

        public async Task<TemperatureStatsEntity> GetTemperatureStatsByUUIDAsync(string uuid)
        {
            uuid.ThrowIfParameterIsNullOrWhiteSpace(nameof(uuid));

            GenericRequest content = new GenericRequest()
            {
                ID = uuid
            };

            string url = string.Concat(configuration.EndpointUrl.AbsoluteUri, "ethLogShared.asmx/GetTemperatureStatsByUUID");
            var result = await http.Post<GenericRequest, GenericResponse<TemperatureStatsEntity>>(url, content);

            return result.Data;
        }
    }
}
