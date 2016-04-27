using System;
using System.Collections.Generic;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Message.Enums;
using PayLoadion.Gcm.PayLoad;

namespace PayLoadion.Gcm.GcmDownStreamHttpMessage.Message
{
    /// <summary>
    /// Represents the contracts for GCM DownStream Http Message in JSON
    /// </summary>
    public interface IGcmDownStreamHttpMessage : IDisposable 
    {
        #region Properties
        /// <summary>
        /// Gets the to. Represents the device id target.
        /// </summary>
        string To { get; }

        /// <summary>
        /// Gets the registration_ids
        /// </summary>
        IReadOnlyList<string> RegistrationIds { get; }

        /// <summary>
        /// Gets the collapse-key
        /// </summary>
        string CollapseKey { get; }

        /// <summary>
        /// Gets the priority
        /// </summary>
        GcmPriorityEnum Priority { get; }

        /// <summary>
        /// Gets the content-available
        /// </summary>
        bool? ContentAvailable { get; }

        /// <summary>
        /// Gets the delay_while_idle
        /// </summary>
        bool? DelayWhileIdle { get; }

        /// <summary>
        /// Gets the time_to_live
        /// </summary>
        int? TimeToLive { get; }

        /// <summary>
        /// Gets the restricted_package_name
        /// </summary>
        string RestrictedPackageName { get; }

        /// <summary>
        /// Gets the dry_run
        /// </summary>
        bool? DryRun { get; }

        /// <summary>
        /// Gets the <see cref="IGcmPayLoad"/>
        /// </summary>
        IGcmPayLoad GcmPayLoad { get; }
        #endregion Properties
    }
}