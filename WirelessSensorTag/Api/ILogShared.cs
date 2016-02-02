using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WirelessSensorTag.Entities;

namespace WirelessSensorTag.Api
{
    public interface ILogShared
    {
        ////Task<MotionEntity> GetDetailLogByUUIDAsync(string uuid, DateTime date);

        Task<StatsCollectionEntity> GetHourlyStatsByUUIDsAsync(string[] uuids, string sensorType);

        Task<TemperatureEntity> GetLatestTemperatureRawDataByUUIDAsync(string uuid);

        Task<IEnumerable<StatsEntity>> GetStatsRawByUUIDAsync(string uuid, DateTime fromDate, DateTime toDate);

        Task<IEnumerable<TemperatureEntity>> GetTemperatureRawDataByUUIDAsync(string uuid);

        Task<TemperatureStatsEntity> GetTemperatureStatsByUUIDAsync(string uuid);
    }
}
