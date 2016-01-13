using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace WirelessSensorTag.Tests
{
    public class TestData
    {
        [JsonProperty("device-uuid")]
        public string DeviceUUID { get; set; }

        public static TestData LoadFromJsonFile(string sampleDataUrl)
        {
            using (var streamReader = new StreamReader(sampleDataUrl, Encoding.UTF8))
            {
                var json = streamReader.ReadToEnd();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TestData>(json);
            }
        }
    }
}
