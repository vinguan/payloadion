using System;
using PayLoadion.Builder;

namespace PayLoadion.Apple.PayLoad.Alert.Builder
{
    public interface IAlertBuilder : IBuilder<IAlert>, IDisposable
    {
        IAlertBuilder Title(string title);
        IAlertBuilder Body(string body);
        IAlertBuilder TitleLocalizableKey(string titleLocKey);
        IAlertBuilder AddTitleLocalizableArgument(string titleLocArgument);
        IAlertBuilder ActionLocalizableKey(string actionLocalizableKey);
        IAlertBuilder LocalizableKey(string localizableKey);
        IAlertBuilder AddLocalizableArgument(string titleLocalizableArgument);
        IAlertBuilder LaunchImageFileName(string launchImageFileName);
    }
}