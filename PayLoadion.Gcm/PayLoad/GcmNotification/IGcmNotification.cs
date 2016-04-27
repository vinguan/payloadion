using System;
using System.Collections.Generic;

namespace PayLoadion.Gcm.PayLoad.GcmNotification
{
    /// <summary>
    /// Represents the contracts for GCM notification
    /// </summary>
    public interface IGcmNotification : IDisposable
    {
        #region Properties
        /// <summary>
        /// Gets the title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the body
        /// </summary>
        string Body { get; }

        /// <summary>
        /// Gets the icon
        /// </summary>
        string Icon { get; }

        /// <summary>
        /// Gets the sound
        /// </summary>
        string Sound { get; }

        /// <summary>
        /// Gets the badge
        /// </summary>
        string Badge { get; }

        /// <summary>
        /// Gets the tag
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// Gets the color
        /// </summary>
        string Color { get; }

        /// <summary>
        /// Gets the click-action
        /// </summary>
        string ClickAction { get; }

        /// <summary>
        /// Gets the body-loc-key
        /// </summary>
        string BodyLocKey { get; }

        /// <summary>
        /// Gets the body-loc-args
        /// </summary>
        IReadOnlyList<string> BodyLocArgs { get; }

        /// <summary>
        /// Gets the title-loc-key
        /// </summary>
        string TitleLocKey { get; }

        /// <summary>
        /// Gets the title-loc-args
        /// </summary>
        IReadOnlyList<string> TitleLocArgs { get; }
        #endregion Properties
    }
}