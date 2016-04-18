using System.Collections.Generic;
using PayLoadion.Google.PayLoad.Enums;
using PayLoadion.Google.PayLoad.Notification;
using PayLoadion.PayLoad;

namespace PayLoadion.Google.PayLoad
{
    public interface IGcmPayLoad : IPayLoad
    {
        string To { get; }

        IReadOnlyList<string> RegistrationIds { get; }

        string CollapseKey { get; }

        GcmPriorityEnum Priority { get; }

        bool? ContentAvailable { get; }

        bool? DelayWhileIdle { get; }

        int? TimeToLive { get; }

        string RestrictedPackageName { get; }

        bool? DryRun { get; }

        IGcmNotification Notification { get; }
    }
}