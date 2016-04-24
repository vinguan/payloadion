using System;
using PayLoadion.Google.PayLoad.GcmNotification;
using PayLoadion.PayLoad;

namespace PayLoadion.Google.PayLoad
{
    public interface IGcmPayLoad : IPayLoad, IDisposable
    {
        IGcmNotification Notification { get; }
    }
}