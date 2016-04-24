using System;
using System.Threading;
using System.Threading.Tasks;
using PayLoadion.Google.GcmDownStreamHttpJsonMessage.Message.Enums;

namespace PayLoadion.Google.GcmDownStreamHttpJsonMessage.Builder
{
    public interface IGcmDownStreamHttpJsonMessageBuilder
    {
        string BuildDownStreamJson(bool indent = false);

        Task<string> BuildDownStreamJsonAsync(bool indent = false,CancellationToken cancellationToken = default(CancellationToken));
    }

    public interface IGcmDownStreamHttpJsonMessageBuilderToUniqueDevice : IGcmDownStreamHttpJsonMessageBuilder
    {
        IGcmDownStreamHttpJsonMessageBuilderOptions ToDevice(string deviceId);

        IGcmDownStreamHttpJsonMessageBuilderToMultipleDevices AddDeviceId(string deviceId);
    }

    public interface IGcmDownStreamHttpJsonMessageBuilderToMultipleDevices : IGcmDownStreamHttpJsonMessageBuilder
    {
        IGcmDownStreamHttpJsonMessageBuilderToMultipleDevices AddDeviceId(string deviceId);

        IGcmDownStreamHttpJsonMessageBuilderOptions CollapseKey(string collapseKey);
    }

    public interface IGcmDownStreamHttpJsonMessageBuilderOptions : IGcmDownStreamHttpJsonMessageBuilder
    {
        IGcmDownStreamHttpJsonMessageBuilderOptions CollapseKey(string collapseKey);

        IGcmDownStreamHttpJsonMessageBuilderOptions Priority(GcmPriorityEnum priority);

        IGcmDownStreamHttpJsonMessageBuilderOptions IsContentAvailable(bool isContentAvailable);

        IGcmDownStreamHttpJsonMessageBuilderOptions DelayWhileIdle(bool delayWhileIdle);

        IGcmDownStreamHttpJsonMessageBuilderOptions TimeToLiveInSeconds(int seconds);

        IGcmDownStreamHttpJsonMessageBuilderOptions TimeToLiveUntil(DateTimeOffset limitDate);

        IGcmDownStreamHttpJsonMessageBuilderOptions RestrictedPackageName(string restrictedPackageName);

        IGcmDownStreamHttpJsonMessageBuilderOptions IsDryRun(bool isDryRun);

        IGcmDownStreamHttpJsonMessagePayLoadBuilder PayLoad();
    }

    public interface IGcmDownStreamHttpJsonMessagePayLoadBuilder
    {
        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationTitle Notification();

        IGcmDownStreamHttpJsonMessageBuilder AddCustomData(string customDataKey, object customDataValue);
    }

    public interface IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationTitle 
    {
        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationIcon Title(string title);
    }

    public interface IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationIcon
    {
        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptions Icon(string iconFileName);
    }

    public interface IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptions : IGcmDownStreamHttpJsonMessageBuilder
    {
        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptions Body(string body);

        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptions SoundFileName(string soundFileName);

        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptions BadgeCount(string badgeCount);

        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptions Tag(string tag);

        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptions Color(string color);

        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptions ClickAction(string clickAction);

        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs BodyLocalizableKey(string bodyLocalizableKey);

        IGcmDownStreamHttpJsonMessageBuilder AddCustomData(string customDataKey, object customDataValue);
    }

    public interface IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs : IGcmDownStreamHttpJsonMessageBuilder
    {
        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs AddBodyLocalizableArgument(string bodyLocArgument);

        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs TitleLocalizableKey(string titleLocalizableKey);

        IGcmDownStreamHttpJsonMessageBuilder AddCustomData(string customDataKey, object customDataValue);
    }

    public interface IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs : IGcmDownStreamHttpJsonMessageBuilder
    {
        IGcmDownStreamHttpJsonMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs AddTitleLocalizableArgument(string titleLocArgument);

        IGcmDownStreamHttpJsonMessageBuilder AddCustomData(string customDataKey, object customDataValue);
    }
}