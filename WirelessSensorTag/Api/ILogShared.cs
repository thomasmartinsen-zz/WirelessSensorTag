using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WirelessSensorTag.Entities;

namespace WirelessSensorTag.Api
{
    public interface ILogShared
    {
        ////void GetDetailLogByUUID();

        ////void GetDoorStatsByUUID();

        ////void GetEventRawDataByUUID();

        ////void GetHourlyStatsByUUIDs();

        ////void GetLatestMultiTagStatsByUUIDs();

        Task<TemperatureEntity> GetLatestTemperatureRawDataByUUIDAsync(string uuid);

        ////void GetMultiTagStatsRawByUUIDs();

        Task<IEnumerable<StatsEntity>> GetStatsRawByUUIDAsync(string uuid, DateTime fromDate, DateTime toDate);

        Task<IEnumerable<TemperatureEntity>> GetTemperatureRawDataByUUIDAsync(string uuid);

        Task<TemperatureStatsEntity> GetTemperatureStatsByUUIDAsync(string uuid);
    }
}
