using System;
using Newtonsoft.Json;

namespace WirelessSensorTag.Entities
{
    public class StatsEntity
    {
        [JsonProperty(PropertyName = "__type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "tods")]
        public int[] Tods { get; set; }

        [JsonProperty(PropertyName = "temps")]
        public float[] Temps { get; set; }

        [JsonProperty(PropertyName = "caps")]
        public float[] Caps { get; set; }
    }
}

