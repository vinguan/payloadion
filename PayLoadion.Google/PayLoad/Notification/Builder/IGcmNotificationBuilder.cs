using System;
using PayLoadion.Builder;

namespace PayLoadion.Google.PayLoad.Notification.Builder
{
    public interface IGcmNotificationBuilder : IBuilder<IGcmNotification>, IDisposable
    {
        IGcmNotificationBuilder Title(string title);
        IGcmNotificationBuilder Body(string body);
        IGcmNotificationBuilder IconFileName(string iconFileName);
        IGcmNotificationBuilder SoundFileName(string soundFileName);
        IGcmNotificationBuilder BadgeCount(string badgeCount);
        IGcmNotificationBuilder Tag(string tag);
        IGcmNotificationBuilder Color(string color);
        IGcmNotificationBuilder ClickAction(string clickAction);
        IGcmNotificationBuilder BodyLocalizableKey(string bodyLocalizableKey);
        IGcmNotificationBuilder AddBodyLocalizableArgument(string bodyLocArgument);
        IGcmNotificationBuilder TitleLocalizableKey(string titleLocalizableKey);
        IGcmNotificationBuilder AddTitleLocalizableArgument(string titleLocArgument);
    }
}