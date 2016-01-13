# WirelessSensorTag.NET

##.NET wrapper on top of official WirelessSensorTag JSON api.

Currently the tool only supports the following parts of the API:

* ethLogShared.asmx 
 * GetLatestTemperatureRawDataByUUID
 * GetStatsRawByUUID
 * GetTemperatureRawDataByUUID
 * GetTemperatureStatsByUUID

Short example of how to use the tool:
```
var client = new WirelessSensorTag.Client();
var latestTemperature = await client.LogShared.GetLatestTemperatureRawDataByUUIDAsync("0123456789");
```

Documentation of official JSON api can be found at http://wirelesstag.net/media/mytaglist.com/apidoc.html.

NuGet package available at https://www.nuget.org/packages/WirelessSensorTag.NET.
