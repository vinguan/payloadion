using System.Collections.Generic;
using PayLoadion.Google.GcmDownStreamHttpJsonMessage.Message.Enums;
using PayLoadion.Google.PayLoad;

namespace PayLoadion.Google.GcmDownStreamHttpJsonMessage.Message
{
    public interface IGcmDownStreamHttpJsonMessage 
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

        IGcmPayLoad GcmPayLoad { get; }
    }
}