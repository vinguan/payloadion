using System;
using System.Collections.Generic;

namespace PayLoadion.Apns.PayLoad.Alert
{
    /// <summary>
    /// Represents the contracts for Apns Alert properties 
    /// </summary>
    public interface IApnsAlert : IDisposable 
    {
        /// <summary>
        /// Gets the Title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the Body
        /// </summary>
        string Body { get;  }

        /// <summary>
        /// Gets the TitleLocKey
        /// </summary>
        string TitleLocKey { get;  }

        /// <summary>
        /// Gets the TitleLocArgs
        /// </summary>
        IReadOnlyList<string> TitleLocArgs { get;  }

        /// <summary>
        /// Gets the ActionLocKey
        /// </summary>
        string ActionLocKey { get;  }

        /// <summary>
        /// Gets the LocKey
        /// </summary>
        string LocKey { get;  }

        /// <summary>
        /// Gets the LocArgs
        /// </summary>
        IReadOnlyList<string> LocArgs { get;}

        /// <summary>
        /// Gets the LaunchImage
        /// </summary>
        string LaunchImage { get; }
    }
}