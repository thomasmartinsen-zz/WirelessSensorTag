using Newtonsoft.Json;

namespace WirelessSensorTag.Api.Dto
{
    public class GenericRequest
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "uuid")]
        public string UUID { get; set; }

        [JsonProperty(PropertyName = "fromDate")]
        public string FromDate { get; set; }

        [JsonProperty(PropertyName = "toDate")]
        public string ToDate { get; set; }
    }
}
