using System;
using WirelessSensorTag.Entities;

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

        public HttpException(ErrorEntity error) : base(error.Message)
        {
        }
    }
}
