using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WirelessSensorTag.Tests
{
    [TestClass]
    public class ClientTest
    {
        private readonly IClient client;
        private readonly TestData testData;

        public ClientTest()
        {
            client = new Client();

            testData = TestData.LoadFromJsonFile(@"c:\temp\sampledata.json"); /// Load with url to JSON containing your data.
        }

        [TestMethod]
        public async Task LogShared_GetLatestTemperatureRawDataByUUIDAsync()
        {
            var result = await client.LogShared.GetLatestTemperatureRawDataByUUIDAsync(testData.DeviceUUID);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Battery > 0);
        }
    }
}
