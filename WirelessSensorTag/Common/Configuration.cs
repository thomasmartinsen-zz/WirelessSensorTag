using System;
using WirelessSensorTag.Extensions;

namespace WirelessSensorTag.Common
{
    public class Configuration : IConfiguration
    {
        private readonly Uri endpointUrl;

        public Configuration(Uri endpointUrl)
        {
            endpointUrl.ThrowIfParameterIsNull(nameof(endpointUrl));

            this.endpointUrl = endpointUrl;
        }

        public Uri EndpointUrl
        {
            get
            {
                return endpointUrl;
            }
        }
    }
}
