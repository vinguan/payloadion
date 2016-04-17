using System;
using PayLoadion.Apple.PayLoad.Alert;

namespace PayLoadion.Apple.Exceptions.Alert
{
    public class AlertBuilderException : Exception
    {
        public IAlert AlertWithError { get; set; }

        public AlertBuilderException(string message) : base(message)
        {

        }

        public AlertBuilderException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}