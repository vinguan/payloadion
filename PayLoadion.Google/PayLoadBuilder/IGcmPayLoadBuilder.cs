using System;
using PayLoadion.Google.PayLoad;
using PayLoadion.Google.PayLoad.Enums;
using PayLoadion.Google.PayLoad.Notification;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Google.PayLoadBuilder
{
    public interface IGcmPayLoadBuilder : IPayLoadBuilder<IGcmPayLoad>, IDisposable
    {
        IGcmPayLoadBuilder ToDevice(string stringDeviceId);
        IGcmPayLoadBuilder AddDeviceId(string stringDeviceId);
        IGcmPayLoadBuilder CollapseKey(string collapseKey);
        IGcmPayLoadBuilder Priority(GcmPriorityEnum priority);
        IGcmPayLoadBuilder IsContentAvailable(bool isContentAvailable);
        IGcmPayLoadBuilder DelayWhileIdle(bool delayWhileIdle);
        IGcmPayLoadBuilder TimeToLiveInSeconds(int seconds);
        IGcmPayLoadBuilder TimeToLiveUntil(DateTimeOffset limitDate);
        IGcmPayLoadBuilder RestrictedPackageName(string restrictedPackageName);
        IGcmPayLoadBuilder IsDryRun(bool isDryRun);
        IGcmPayLoadBuilder Notification(IGcmNotification gcmNotification);
    }
}