using System;

namespace PayLoadion.Apple.Exceptions
{
    public class ApnsPayloadBuilderException : Exception
    {

        public ApnsPayloadBuilderException(string message) : base(message)
        {

        }

        public ApnsPayloadBuilderException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
