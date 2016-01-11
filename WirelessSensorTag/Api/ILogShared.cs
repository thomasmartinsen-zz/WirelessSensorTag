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

        ////void GetStatsRawByUUID();

        ////void GetTemperatureRawDataByUUID();

        ////void GetTemperatureStatsByUUID();
    }
}
