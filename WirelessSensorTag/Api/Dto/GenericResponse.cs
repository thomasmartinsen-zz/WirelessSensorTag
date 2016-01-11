using Newtonsoft.Json;
using WirelessSensorTag.Entities;

namespace WirelessSensorTag.Api.Dto
{
    public class GenericResponse<T> where T : class
    {
        [JsonProperty(PropertyName ="d")]
        public T Data { get; set; }
    }
}