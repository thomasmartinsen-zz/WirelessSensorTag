using Newtonsoft.Json;

namespace WirelessSensorTag.Entities
{
    public class MotionEntity
    {
        [JsonProperty(PropertyName = "secOfDay")]
        public int SecOfDay { get; set; }

        [JsonProperty(PropertyName = "eventType")]
        public string EventType { get; set; }

        [JsonProperty(PropertyName = "durationSec")]
        public int DurationSec { get; set; }
    }
}
