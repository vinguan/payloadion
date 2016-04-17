using System;
using PayLoadion.Apple.PayLoad;
using PayLoadion.Apple.PayLoad.Alert;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Apple.PayLoadBuilder
{
    public interface IApnsPayLoadBuilder : IPayLoadBuilder<IApnsPayLoad>, IDisposable
    {
        IApnsPayLoadBuilder AlertMessage(string alertMessage);
        IApnsPayLoadBuilder Alert(IAlert alert);
        IApnsPayLoadBuilder SoundName(string soundName);
        IApnsPayLoadBuilder Badge(int badge);
        IApnsPayLoadBuilder IsContentAvailable(bool isContentAvailable);
        IApnsPayLoadBuilder CategoryName(string categoryName);
        IApnsPayLoadBuilder AddCustomData(string customDataKey, object customDataValue);
    }
}