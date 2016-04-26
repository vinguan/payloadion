using System;
using PayLoadion.Apns.PayLoad.Alert;
using PayLoadion.PayLoad;

namespace PayLoadion.Apns.PayLoad
{
    /// <summary>
    /// Represents the contracts for the Apns Payload
    /// </summary>
    public interface IApnsPayLoad : IPayLoad
    {
        /// <summary>
        /// Gets the <see cref="IApnsAlert"/>
        /// </summary>
        IApnsAlert Alert { get; }

        /// <summary>
        /// Gets the Alert message
        /// </summary>
        string AlertMessage { get; }

        /// <summary>
        /// Gets the badge count
        /// </summary>
        int? Badge { get; }

        /// <summary>
        /// Gets the sound file name
        /// </summary>
        string Sound { get; }

        /// <summary>
        /// Gets whether is content available
        /// </summary>
        int? ContentAvailable { get; }

        /// <summary>
        /// Gets or sets the category
        /// </summary>
        string Category { get; }
    }
}
