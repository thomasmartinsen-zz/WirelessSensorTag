using WirelessSensorTag.Api;

namespace WirelessSensorTag
{
    public interface IClient
    {
        ILogShared LogShared { get; set; }
    }
}
