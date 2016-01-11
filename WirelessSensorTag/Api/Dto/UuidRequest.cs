using Newtonsoft.Json;

namespace WirelessSensorTag.Api.Dto
{
    public class WirelessTagUuidRequest
    {
        [JsonProperty(PropertyName = "uuid")]
        public string UUID { get; set; }
    }
}
