using System;
using Newtonsoft.Json;

namespace WirelessSensorTag.Entities
{
    public class TemperatureEntity
    {
        [JsonProperty(PropertyName = "__type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }

        [JsonProperty(PropertyName = "temp_degC")]
        public float TempDegC { get; set; }

        [JsonProperty(PropertyName = "cap")]
        public float Cap { get; set; }

        [JsonProperty(PropertyName = "battery_volts")]
        public float Battery { get; set; }
    }
}
