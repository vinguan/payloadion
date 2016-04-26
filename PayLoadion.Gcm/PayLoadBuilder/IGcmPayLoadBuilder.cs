using PayLoadion.Gcm.PayLoad;
using PayLoadion.Gcm.PayLoad.GcmNotification;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Gcm.PayLoadBuilder
{
    /// <summary>
    /// Represents the contracts for the start GCM payload builder
    /// </summary>
    public interface IGcmPayLoadBuilder : IPayLoadBuilder<IGcmPayLoad>
    {
       
    }

    /// <summary>
    /// Represents the contracts for the start GCM payload builder
    /// </summary>
    public interface IGcmPayLoadBuilderNotification : IGcmPayLoadBuilder
    {
        /// <summary>
        /// Starts the builder for <see cref="IGcmNotification"/>
        /// </summary>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationTitle Notification();
    }

    /// <summary>
    /// Represents the contracts for the <see cref="IGcmNotification"/> builder
    /// </summary>
    public interface IGcmPayLoadBuilderNotificationTitle 
    {
        /// <summary>
        /// Sets the title of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="title">The title</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationIcon Title(string title);
    }

    /// <summary>
    /// Represents the contracts for the <see cref="IGcmNotification"/> builder
    /// </summary>
    public interface IGcmPayLoadBuilderNotificationIcon
    {
        /// <summary>
        /// Sets the icon of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="iconFileName">The icon</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationOptions Icon(string iconFileName);
    }

    /// <summary>
    /// Represents the contracts for the <see cref="IGcmNotification"/> builder
    /// </summary>
    public interface IGcmPayLoadBuilderNotificationOptions : IGcmPayLoadBuilder
    {
        /// <summary>
        /// Sets the body of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="body">The body</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationOptions Body(string body);

        /// <summary>
        /// Sets the sound of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="soundFileName">The sound</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationOptions Sound(string soundFileName);

        /// <summary>
        /// Sets the badge of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="badgeCount">The badge</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationOptions BadgeCount(string badgeCount);

        /// <summary>
        /// Sets the tag of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationOptions Tag(string tag);

        /// <summary>
        /// Sets the color of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="color">The color</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationOptions Color(string color);

        /// <summary>
        /// Sets the click-action of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="clickAction">The click-action</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationOptions ClickAction(string clickAction);

        /// <summary>
        /// Sets the body-loc-key of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="bodyLocalizableKey">The body-loc-key</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationBodyLocalizableArgs BodyLocalizableKey(string bodyLocalizableKey);

        /// <summary>
        /// Sets the title-loc-key of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="titleLocalizableKey">The title-loc-key</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationTitleLocalizableArgs TitleLocalizableKey(string titleLocalizableKey);
    }

    /// <summary>
    /// Represents the contracts for the <see cref="IGcmNotification"/> builder
    /// </summary>
    public interface IGcmPayLoadBuilderNotificationBodyLocalizableArgs : IGcmPayLoadBuilder
    {
        /// <summary>
        /// Adds a argument to body-loc-argument
        /// </summary>
        /// <param name="bodyLocArgument">The title-loc argument</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationBodyLocalizableArgs AddBodyLocalizableArgument(string bodyLocArgument);

        /// <summary>
        /// Sets the title-loc-key of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="titleLocalizableKey">The title-loc-key</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationTitleLocalizableArgs TitleLocalizableKey(string titleLocalizableKey);
    }

    /// <summary>
    /// Represents the contracts for the <see cref="IGcmNotification"/> builder
    /// </summary>
    public interface IGcmPayLoadBuilderNotificationTitleLocalizableArgs : IGcmPayLoadBuilder
    {
        /// <summary>
        /// Sets the title-loc-key of <see cref="IGcmNotification"/>
        /// </summary>
        /// <param name="titleLocArgument">The title-loc argument</param>
        /// <returns>The payload builder</returns>
        IGcmPayLoadBuilderNotificationTitleLocalizableArgs AddTitleLocalizableArgument(string titleLocArgument);
    }
}