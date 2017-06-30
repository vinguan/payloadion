using System;
using PayLoadion.PayLoadBuilder;
using PayLoadion.Apns.PayLoad.Alert;

namespace PayLoadion.Apns.PayLoadBuilder.Alert
{
    public interface IApnsAlertBuilder : IDisposable
    {
        IApnsAlertBuilder Title(string title);
        IApnsAlertBuilder Body(string body);
        IApnsAlertBuilder TitleLocalizableKey(string titleLocKey);
        IApnsAlertBuilder AddTitleLocalizableArgument(string titleLocArgument);
        IApnsAlertBuilder ActionLocalizableKey(string actionLocalizableKey);
        IApnsAlertBuilder LocalizableKey(string localizableKey);
        IApnsAlertBuilder AddLocalizableArgument(string titleLocalizableArgument);
        IApnsAlertBuilder LaunchImageFileName(string launchImageFileName);
    }
}