using Newtonsoft.Json;

namespace WirelessSensorTag.Entities
{
    public class TemperatureStatsEntity
    {
        [JsonProperty(PropertyName = "__type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "temps")]
        public StatsEntity[] Temps { get; set; }

        [JsonProperty(PropertyName = "temp_unit")]
        public int TempUnit { get; set; }
    }
}
