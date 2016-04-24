using System;
using PayLoadion.PayLoadBuilder;
using PayLoadion.Google.PayLoad;

namespace PayLoadion.Google.PayLoadBuilder
{
    public interface IGcmPayLoadBuilder : IPayLoadBuilder<IGcmPayLoad>, IDisposable
    {
       
    }

    public interface IGcmPayLoadBuilderNotification : IGcmPayLoadBuilder
    {
        IGcmPayLoadBuilderNotificationTitle Notification();
    }

    public interface IGcmPayLoadBuilderNotificationTitle 
    {
        IGcmPayLoadBuilderNotificationIcon Title(string title);
    }

    public interface IGcmPayLoadBuilderNotificationIcon
    {
        IGcmPayLoadBuilderNotificationOptions Icon(string iconFileName);
    }

    public interface IGcmPayLoadBuilderNotificationOptions : IGcmPayLoadBuilder
    {
        IGcmPayLoadBuilderNotificationOptions Body(string body);

        IGcmPayLoadBuilderNotificationOptions SoundFileName(string soundFileName);

        IGcmPayLoadBuilderNotificationOptions BadgeCount(string badgeCount);

        IGcmPayLoadBuilderNotificationOptions Tag(string tag);

        IGcmPayLoadBuilderNotificationOptions Color(string color);

        IGcmPayLoadBuilderNotificationOptions ClickAction(string clickAction);

        IGcmPayLoadBuilderNotificationBodyLocalizableArgs BodyLocalizableKey(string bodyLocalizableKey);
    }

    public interface IGcmPayLoadBuilderNotificationBodyLocalizableArgs : IGcmPayLoadBuilder
    {
        IGcmPayLoadBuilderNotificationBodyLocalizableArgs AddBodyLocalizableArgument(string bodyLocArgument);

        IGcmPayLoadBuilderNotificationTitleLocalizableArgs TitleLocalizableKey(string titleLocalizableKey);
    }

    public interface IGcmPayLoadBuilderNotificationTitleLocalizableArgs : IGcmPayLoadBuilder
    {
        IGcmPayLoadBuilderNotificationTitleLocalizableArgs AddTitleLocalizableArgument(string titleLocArgument);
    }
}