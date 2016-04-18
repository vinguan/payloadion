using System;
using PayLoadion.Apple.PayLoad.Alert;

namespace PayLoadion.Apple.Exceptions.Alert
{
    public class ApnsAlertBuilderException : Exception
    {
        public IApnsAlert ApnsAlertWithErrors { get; set; }

        public ApnsAlertBuilderException(string message) : base(message)
        {

        }

        public ApnsAlertBuilderException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}