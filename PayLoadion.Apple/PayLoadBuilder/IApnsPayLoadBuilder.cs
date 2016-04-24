using System;
using PayLoadion.Apple.PayLoad;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Apple.PayLoadBuilder
{
    public interface IApnsPayLoadBuilder : IPayLoadBuilder<IApnsPayLoad>, IDisposable
    {
        IApnsPayLoadBuilderAlert Alert();

        IApnsPayLoadBuilderWithBadge Alert(string alertMessage);
    }

    public interface IApnsPayLoadBuilderAlert : IApnsPayLoadBuilder
    {
        IApnsPayLoadBuilderAlert Title(string title);

        IApnsPayLoadBuilderAlert Body(string body);

        IApnsPayLoadBuilderAlertTitleLocalizableArgs TitleLocalizableKey(string titleLocKey);

        IApnsPayLoadBuilderAlertLocalizableArgs LocalizableKey(string localizableKey);

        IApnsPayLoadBuilderAlertLaunchImage ActionLocalizableKey(string actionLocalizableKey);

        IApnsPayLoadBuilderWithBadge LaunchImageFileName(string launchImageFileName);
    }

    public interface IApnsPayLoadBuilderAlertTitleLocalizableArgs : IApnsPayLoadBuilder
    {
        IApnsPayLoadBuilderAlertTitleLocalizableArgs AddTitleLocalizableArgument(string titleLocArgument);

        IApnsPayLoadBuilderAlertLocalizableArgs LocalizableKey(string localizableKey);

        IApnsPayLoadBuilderAlertLaunchImage ActionLocalizableKey(string actionLocalizableKey);

        IApnsPayLoadBuilderWithBadge LaunchImageFileName(string launchImageFileName);
    }

    public interface IApnsPayLoadBuilderAlertLocalizableArgs : IApnsPayLoadBuilder
    {
        IApnsPayLoadBuilderAlertLocalizableArgs AddLocalizableArgument(string titleLocalizableArgument);

        IApnsPayLoadBuilderAlertLaunchImage ActionLocalizableKey(string actionLocalizableKey);

        IApnsPayLoadBuilderWithBadge LaunchImageFileName(string launchImageFileName);
    }

    public interface IApnsPayLoadBuilderAlertLaunchImage : IApnsPayLoadBuilder
    {
        IApnsPayLoadBuilderWithBadge LaunchImageFileName(string launchImageFileName);

        IApnsPayLoadBuilderWithSound BadgeCount(int badgeCount);
    }

    public interface IApnsPayLoadBuilderWithBadge : IApnsPayLoadBuilder
    {
        IApnsPayLoadBuilderWithSound BadgeCount(int badgeCount);

        IApnsPayLoadBuilderWithContentAvailable SoundName(string soundName);

        IApnsPayLoadBuilderWithCategoryIdentifier IsContentAvailable(bool isContentAvailable);

        IPayLoadBuilder<IApnsPayLoad> CategoryIdentifier(string categoryIdentifier);
    }

    public interface IApnsPayLoadBuilderWithSound : IApnsPayLoadBuilder
    {
        IApnsPayLoadBuilderWithContentAvailable SoundName(string soundName);

        IApnsPayLoadBuilderWithCategoryIdentifier IsContentAvailable(bool isContentAvailable);

        IPayLoadBuilder<IApnsPayLoad> CategoryIdentifier(string categoryIdentifier);
    }

    public interface IApnsPayLoadBuilderWithContentAvailable : IApnsPayLoadBuilder
    {
        IApnsPayLoadBuilderWithCategoryIdentifier IsContentAvailable(bool isContentAvailable);

        IPayLoadBuilder<IApnsPayLoad> CategoryIdentifier(string categoryIdentifier);
    }

    public interface IApnsPayLoadBuilderWithCategoryIdentifier : IApnsPayLoadBuilder
    {
        IPayLoadBuilder<IApnsPayLoad> CategoryIdentifier(string categoryIdentifier);
    }
}