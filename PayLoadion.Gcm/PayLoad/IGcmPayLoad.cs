using PayLoadion.Gcm.PayLoad.GcmNotification;
using PayLoadion.PayLoad;

namespace PayLoadion.Gcm.PayLoad
{
    /// <summary>
    /// Represents the contracts for GCM - Google Cloud Messaging
    /// </summary>
    public interface IGcmPayLoad : IPayLoad
    {
        /// <summary>
        /// Gets the <see cref="IGcmNotification"/> for this payload
        /// </summary>
        IGcmNotification Notification { get; }
    }
}