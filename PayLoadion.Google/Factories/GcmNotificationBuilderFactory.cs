using PayLoadion.Google.PayLoad.Notification;
using PayLoadion.Google.PayLoad.Notification.Builder;

namespace PayLoadion.Google.Factories
{
    public static class GcmNotificationBuilderFactory
    {
        public static IGcmNotificationBuilder CreateGcmNotificationBuilder()
        {
            return new GcmNotificationBuilderImplementation();
        }

        public static IGcmNotificationBuilder CreateGcmNotificationBuilder(IGcmNotification gcmNotification)
        {
            return new GcmNotificationBuilderImplementation(gcmNotification);
        }
    }
}