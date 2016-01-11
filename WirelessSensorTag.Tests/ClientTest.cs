using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WirelessSensorTag.Tests
{
    [TestClass]
    public class ClientTest
    {
        private readonly IClient client;

        public ClientTest()
        {
            client = new Client();
        }

        [TestMethod]
        public async Task LogShared_GetLatestTemperatureRawDataByUUIDAsync()
        {
            var uuid =" eb3b1715-212a-4511-a68f-93c0aed3df23";
            var result = await client.LogShared.GetLatestTemperatureRawDataByUUIDAsync(uuid);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Battery > 0);
        }
    }
}
