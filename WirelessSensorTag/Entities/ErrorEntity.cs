using Newtonsoft.Json;

namespace WirelessSensorTag.Entities
{
    public class ErrorEntity
    {
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "StackTrace")]
        public string StackTrace { get; set; }

        [JsonProperty(PropertyName = "ExceptionType")]
        public string ExceptionType { get; set; }
    }
}
