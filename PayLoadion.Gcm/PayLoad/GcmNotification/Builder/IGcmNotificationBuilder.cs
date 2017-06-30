using System.Threading;
using System.Threading.Tasks;
using PayLoadion.Google.GcmDownStreamHttpJsonMessage.Builder;

namespace PayLoadion.Google.PayLoad.GcmNotification.Builder
{
    public interface IGcmNotificationBuilder
    {
        IGcmNotification BuildGcmNotification();

        Task<IGcmNotification> BuildGcmNotificationAsync(CancellationToken cancellationToken = default(CancellationToken));

        string BuildGcmNotificationToString();

        Task<string> BuildGcmNotificationToStringAsync(CancellationToken cancellationToken = default(CancellationToken));
    }

    public interface IGcmNotificationBuilderTitle : IGcmNotificationBuilder
    {
        IGcmNotificationBuilderIcon Title(string title);
    }

    public interface IGcmNotificationBuilderIcon : IGcmNotificationBuilder
    {
        IGcmNotificationBuilderOptions Icon(string iconFileName);
    }

    public interface IGcmNotificationBuilderOptions : IGcmNotificationBuilder
    {
        IGcmNotificationBuilderOptions Body(string body);

        IGcmNotificationBuilderOptions SoundFileName(string soundFileName);

        IGcmNotificationBuilderOptions BadgeCount(string badgeCount);

        IGcmNotificationBuilderOptions Tag(string tag);

        IGcmNotificationBuilderOptions Color(string color);

        IGcmNotificationBuilderOptions ClickAction(string clickAction);

        IGcmNotificationBuilderBodyLocalizableArgs BodyLocalizableKey(string bodyLocalizableKey);

        IGcmDownStreamHttpJsonMessageBuilder CollapseKey(string collapseKey);
    }

    public interface IGcmNotificationBuilderBodyLocalizableArgs : IGcmNotificationBuilder
    {
        IGcmNotificationBuilderBodyLocalizableArgs AddBodyLocalizableArgument(string bodyLocArgument);

        IGcmNotificationBuilderTitleLocalizableArgs TitleLocalizableKey(string titleLocalizableKey);

        IGcmDownStreamHttpJsonMessageBuilder CollapseKey(string collapseKey);
    }

    public interface IGcmNotificationBuilderTitleLocalizableArgs : IGcmNotificationBuilder
    {
        IGcmNotificationBuilderTitleLocalizableArgs AddTitleLocalizableArgument(string titleLocArgument);

        IGcmDownStreamHttpJsonMessageBuilder CollapseKey(string collapseKey);
    }
}