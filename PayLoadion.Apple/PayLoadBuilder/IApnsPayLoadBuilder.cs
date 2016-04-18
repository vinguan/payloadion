using System;
using PayLoadion.Apple.PayLoad;
using PayLoadion.Apple.PayLoad.Alert;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Apple.PayLoadBuilder
{
    public interface IApnsPayLoadBuilder : IPayLoadBuilder<IApnsPayLoad>, IDisposable
    {
        IApnsPayLoadBuilder AlertMessage(string alertMessage);
        IApnsPayLoadBuilder Alert(IApnsAlert apnsAlert);
        IApnsPayLoadBuilder SoundName(string soundName);
        IApnsPayLoadBuilder BadgeCount(int badgeCount);
        IApnsPayLoadBuilder IsContentAvailable(bool isContentAvailable);
        IApnsPayLoadBuilder CategoryIdentifier(string categoryIdentifier);
    }
}