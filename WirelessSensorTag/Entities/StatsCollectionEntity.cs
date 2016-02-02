using Newtonsoft.Json;

namespace WirelessSensorTag.Entities
{
    public class StatsCollectionEntity
    {
        [JsonProperty(PropertyName = "__type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "stats")]
        public StatsEntity[] Stats { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public string[] UUIDs { get; set; }

        [JsonProperty(PropertyName = "names")]
        public string[] Names { get; set; }
    }
}
