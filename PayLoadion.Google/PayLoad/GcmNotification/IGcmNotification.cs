using System;
using System.Collections.Generic;

namespace PayLoadion.Google.PayLoad.GcmNotification
{
    public interface IGcmNotification : IDisposable
    {
        string Title { get; }

        string Body { get; }

        string Icon { get; }

        string Sound { get; }

        string Badge { get; }

        string Tag { get; }

        string Color { get; }

        string ClickAction { get; }

        string BodyLocKey { get; }

        IReadOnlyList<string> BodyLocArgs { get; }

        string TitleLocKey { get; }

        IReadOnlyList<string> TitleLocArgs { get; }
    }
}