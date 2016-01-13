using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

        [TestMethod]
        public async Task LogShared_GetStatsRawByUUIDAsync()
        {
            var fromDate = new DateTime(2015, 1, 1);
            var toDate = new DateTime(2015, 1, 10);

            var result = await client.LogShared.GetStatsRawByUUIDAsync(testData.DeviceUUID, fromDate, toDate);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public async Task LogShared_GetTemperatureRawDataByUUIDAsync()
        {
            var result = await client.LogShared.GetTemperatureRawDataByUUIDAsync(testData.DeviceUUID);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public async Task LogShared_GetTemperatureStatsByUUIDAsync()
        {
            var result = await client.LogShared.GetTemperatureStatsByUUIDAsync(testData.DeviceUUID);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Temps);
            Assert.IsTrue(result.Temps.Count() > 0);
        }
    }
}
