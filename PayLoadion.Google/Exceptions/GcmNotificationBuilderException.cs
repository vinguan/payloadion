using System;
using PayLoadion.Google.PayLoad.Notification;

namespace PayLoadion.Google.Exceptions
{
    public class GcmNotificationBuilderException : Exception
    {
        public IGcmNotification GcmNotificationWithErrors { get; set; }

        public GcmNotificationBuilderException(string message) : base(message)
        {

        }

        public GcmNotificationBuilderException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}