using System;

namespace PayLoadion.Google.Exceptions
{
    public class GcmPayLoadBuilderException : Exception
    {
        public GcmPayLoadBuilderException(string message) : base(message)
        {

        }

        public GcmPayLoadBuilderException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}