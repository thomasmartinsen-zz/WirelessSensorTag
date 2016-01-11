using System;

namespace WirelessSensorTag.Exceptions
{
    public class HttpException : Exception
    {
        public HttpException() : base("unknown http error")
        {
        }

        public HttpException(string message) : base(message)
        {
        }
    }
}
