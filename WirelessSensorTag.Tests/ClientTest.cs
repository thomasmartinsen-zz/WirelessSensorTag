using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WirelessSensorTag.Tests
{
    [TestClass]
    public class ClientTest
    {
        private readonly IClient client;
        private readonly ITestData testData;

        public ClientTest()
        {
            client = new Client();

            testData = new TestData(); /// Instantiate new implementation of ITestData containing your data.
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
