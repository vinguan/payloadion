using System;
using System.Threading;
using System.Threading.Tasks;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Message;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Message.Enums;
using PayLoadion.Gcm.PayLoad.GcmNotification;

namespace PayLoadion.Gcm.GcmDownStreamHttpMessage.Builder
{
    /// <summary>
    /// Represents the contracts for the builder of <see cref="IGcmDownStreamHttpMessage"/>
    /// </summary>
    public interface IGcmDownStreamHttpMessageFinalBuilder : IDisposable
    {
        /// <summary>
        /// Builds the <see cref="IGcmDownStreamHttpMessage"/> 
        /// </summary>
        /// <returns>The <see cref="IGcmDownStreamHttpMessage"/></returns>
        IGcmDownStreamHttpMessage BuildGcmDownStreamHttpMessage();

        /// <summary>
        /// Builds the <see cref="IGcmDownStreamHttpMessage"/> async
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="IGcmDownStreamHttpMessage"/>The cancellation token</returns>
        Task<IGcmDownStreamHttpMessage> BuildGcmDownStreamHttpMessageAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Builds the <see cref="IGcmDownStreamHttpMessage"/> to JSON
        /// </summary>
        /// <param name="indent">If the JSON should be indented</param>
        /// <returns>The <see cref="IGcmDownStreamHttpMessage"/> as JSON </returns>
        string BuildGcmDownStreamHttpMessageToJson(bool indent = false);

        /// <summary>
        /// Builds the <see cref="IGcmDownStreamHttpMessage"/> to JSON async
        /// </summary>
        /// <param name="indent">If the JSON should be indented</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IGcmDownStreamHttpMessage"/> as JSON</returns>
        Task<string> BuildGcmDownStreamHttpMessageToJsonAsync(bool indent = false,CancellationToken cancellationToken = default(CancellationToken));

    }

    /// <summary>
    /// Represents the contracts for the builder of <see cref="IGcmDownStreamHttpMessage"/>
    /// </summary>
    public interface IGcmDownStreamHttpMessageBuilder : IDisposable
    {
        /// <summary>
        /// Sets the TO. Use this if you want to send to only one device
        /// </summary>
        /// <param name="deviceRegistrationId">The device registration id on GCM</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderOptions ToDevice(string deviceRegistrationId);

        /// <summary>
        /// Adds a device registration id to registration_ids
        /// </summary>
        /// <param name="deviceRegistrationId">The device registration id on GCM</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderMultipleTargets AddDeviceId(string deviceRegistrationId);
    }

    /// <summary>
    /// Represents the contracts for the builder of <see cref="IGcmDownStreamHttpMessage"/>
    /// </summary>
    public interface IGcmDownStreamHttpMessageBuilderMultipleTargets : IGcmDownStreamHttpMessageBuilderOptions
    {
        /// <summary>
        /// Adds a device registration id to registration_ids
        /// </summary>
        /// <param name="deviceRegistrationId">The device registration id on GCM</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderMultipleTargets AddDeviceId(string deviceRegistrationId);
    }

    /// <summary>
    /// Represents the contracts for the builder of <see cref="IGcmDownStreamHttpMessage"/>
    /// </summary>
    public interface IGcmDownStreamHttpMessageBuilderOptions : IGcmDownStreamHttpMessageFinalBuilder
    {
        /// <summary>
        /// Sets the collapse_key
        /// </summary>
        /// <param name="collapseKey">The collapse_key</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderOptions CollapseKey(string collapseKey);

        /// <summary>
        /// Sets the priority
        /// </summary>
        /// <param name="priority">The priority</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderOptions Priority(GcmPriorityEnum priority);

        /// <summary>
        /// Sets the content_available
        /// </summary>
        /// <param name="isContentAvailable">If there is content available</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderOptions IsContentAvailable(bool isContentAvailable);

        /// <summary>
        /// Sets the delay_while_idle
        /// </summary>
        /// <param name="delayWhileIdle">If it should be delayed while idle</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderOptions DelayWhileIdle(bool delayWhileIdle);

        /// <summary>
        /// Sets the time_to_live
        /// </summary>
        /// <param name="seconds">The seconds for time_to_live</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderOptions TimeToLiveInSeconds(int seconds);

        /// <summary>
        /// Sets the time_to_live
        /// </summary>
        /// <param name="limitDate">The limit date for lifetime</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderOptions TimeToLiveUntil(DateTimeOffset limitDate);

        /// <summary>
        /// Sets the restricted_package_name
        /// </summary>
        /// <param name="restrictedPackageName">The restricted_package_name</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderOptions RestrictedPackageName(string restrictedPackageName);

        /// <summary>
        /// Sets if this message is a dry run
        /// </summary>
        /// <param name="isDryRun">if this message is a dry run</param>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageBuilderOptions IsDryRun(bool isDryRun);

        /// <summary>
        /// Starts the payload builder
        /// </summary>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilder PayLoad();
    }

    /// <summary>
    /// Represents the contracts for the builder of <see cref="IGcmDownStreamHttpMessage"/>
    /// </summary>
    public interface IGcmDownStreamHttpMessagePayLoadBuilder
    {
        /// <summary>
        /// Starts the builder for <see cref="IGcmNotification"/>
        /// </summary>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationTitle Notification();

        /// <summary>
        /// Add custom data to the <see cref="IGcmDownStreamHttpMessage"/>
        /// </summary>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageFinalBuilder AddCustomData(string customDataKey, object customDataValue);
    }

    /// <summary>
    /// Represents the contracts for the builder of <see cref="IGcmDownStreamHttpMessage"/>
    /// </summary>
    public interface IGcmDownStreamHttpMessagePayLoadBuilderNotificationTitle 
    {
        /// <summary>
        /// Sets the title of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="title">The title</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationIcon Title(string title);
    }

    /// <summary>
    /// Represents the contracts for the builder of <see cref="IGcmDownStreamHttpMessage"/>
    /// </summary>
    public interface IGcmDownStreamHttpMessagePayLoadBuilderNotificationIcon
    {
        /// <summary>
        /// Sets the icon of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="iconFileName">The icon</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions Icon(string iconFileName);
    }

    /// <summary>
    /// Represents the contracts for the builder of <see cref="IGcmDownStreamHttpMessage"/>
    /// </summary>
    public interface IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions : IGcmDownStreamHttpMessageFinalBuilder
    {
        /// <summary>
        /// Sets the body of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="body">The body</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions Body(string body);

        /// <summary>
        /// Sets the sound of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="soundFileName">The sound</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions Sound(string soundFileName);

        /// <summary>
        /// Sets the badge of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="badgeCount">The badge</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions Badge(string badgeCount);

        /// <summary>
        /// Sets the tag of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions Tag(string tag);

        /// <summary>
        /// Sets the color of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="color">The color</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions Color(string color);

        /// <summary>
        /// Sets the click-action of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="clickAction">The click-action</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions ClickAction(string clickAction);

        /// <summary>
        /// Sets the body-loc-key of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="bodyLocalizableKey">The body-loc-key</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs BodyLocalizableKey(string bodyLocalizableKey);

        /// <summary>
        /// Sets the title-loc-key of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="titleLocalizableKey">The title-loc-key</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs TitleLocalizableKey(string titleLocalizableKey);

        /// <summary>
        /// Add custom data to the <see cref="IGcmDownStreamHttpMessage"/>
        /// </summary>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageFinalBuilder AddCustomData(string customDataKey, object customDataValue);
    }

    /// <summary>
    /// Represents the contracts for the builder of <see cref="IGcmDownStreamHttpMessage"/>
    /// </summary>
    public interface IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs : IGcmDownStreamHttpMessageFinalBuilder
    {
        /// <summary>
        /// Adds a argument to body-loc-argument
        /// </summary>
        /// <param name="bodyLocArgument">The title-loc argument</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs AddBodyLocalizableArgument(string bodyLocArgument);

        /// <summary>
        /// Sets the title-loc-key of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="titleLocalizableKey">The title-loc-key</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs TitleLocalizableKey(string titleLocalizableKey);

        /// <summary>
        /// Add custom data to the <see cref="IGcmDownStreamHttpMessage"/>
        /// </summary>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageFinalBuilder AddCustomData(string customDataKey, object customDataValue);
    }

    /// <summary>
    /// Represents the contracts for the builder of <see cref="IGcmDownStreamHttpMessage"/>
    /// </summary>
    public interface IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs : IGcmDownStreamHttpMessageFinalBuilder
    {
        /// <summary>
        /// Sets the title-loc-key of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="titleLocArgument">The title-loc argument</param>
        /// <returns>The payload builder</returns>
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs AddTitleLocalizableArgument(string titleLocArgument);

        /// <summary>
        /// Add custom data to the <see cref="IGcmDownStreamHttpMessage"/>
        /// </summary>
        /// <returns>The builder</returns>
        IGcmDownStreamHttpMessageFinalBuilder AddCustomData(string customDataKey, object customDataValue);
    }
}