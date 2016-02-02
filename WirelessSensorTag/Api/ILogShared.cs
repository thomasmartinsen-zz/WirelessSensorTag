using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WirelessSensorTag.Entities;

namespace WirelessSensorTag.Api
{
    public interface ILogShared
    {
        ////Task<MotionEntity> GetDetailLogByUUIDAsync(string uuid, DateTime date);

        /// <summary>
        /// For specified list of tag UUIDs, retrieves average temperature, battery voltage or humidity of each hour.
        /// </summary>
        /// <param name="uuids"></param>
        /// <param name=""></param>
        /// <returns></returns>
        Task<StatsCollectionEntity> GetHourlyStatsByUUIDsAsync(string[] uuids, string sensorType);

        /// <summary>
        /// For specified tag UUID, retrieves the latest temperature/batteryVolt/humidity raw data.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        Task<TemperatureEntity> GetLatestTemperatureRawDataByUUIDAsync(string uuid);

        /// <summary>
        /// For specified tag UUID, retrieves raw temperature/battery/humidity data for a given date range.
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        Task<IEnumerable<StatsEntity>> GetStatsRawByUUIDAsync(string uuid, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// For specified tag UUID, retrieves raw data used to build the downloaded csv file.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        Task<IEnumerable<TemperatureEntity>> GetTemperatureRawDataByUUIDAsync(string uuid);

        /// <summary>
        /// For specified tag UUID, retrieves average temperature of each hour.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        Task<TemperatureStatsEntity> GetTemperatureStatsByUUIDAsync(string uuid);
    }
}
