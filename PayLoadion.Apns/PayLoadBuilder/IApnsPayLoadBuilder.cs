using System;
using PayLoadion.Apns.PayLoad;
using PayLoadion.Apns.PayLoad.Alert;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Apns.PayLoadBuilder
{
    /// <summary>
    /// Represents the contracts for building a IApnsPayLoadBuilder
    /// </summary>
    public interface IApnsPayLoadBuilderStart 
    {
        /// <summary>
        /// Starts the builder for building the <see cref="IApnsAlert"/>
        /// </summary>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlert Alert();

        /// <summary>
        /// Starts the builder with a alert message
        /// </summary>
        /// <param name="alertMessage">The message</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithBadge Alert(string alertMessage);
    }

    /// <summary>
    /// Represents the contracts for building a <see cref="IApnsPayLoad"/> with <see cref="IApnsAlert"/>
    /// </summary>
    public interface IApnsPayLoadBuilderAlert : IPayLoadBuilder<IApnsPayLoad>
    {
        /// <summary>
        /// Sets the title of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="title">the title</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlert Title(string title);

        /// <summary>
        /// Sets the body of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="body">The body</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlert Body(string body);

        /// <summary>
        /// Sets the title-loc-key of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="titleLocKey">The title loc key</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlertTitleLocalizableArgs TitleLocalizableKey(string titleLocKey);

        /// <summary>
        /// Sets the loc-key of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="localizableKey">The localizable key</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlertLocalizableArgs LocalizableKey(string localizableKey);

        /// <summary>
        /// Sets the action-loc-key of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="actionLocalizableKey">the action-loc-key</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlertLaunchImage ActionLocalizableKey(string actionLocalizableKey);

        /// <summary>
        /// Sets the launch-image of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="launchImageFileName">the launch-image</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithBadge LaunchImageFileName(string launchImageFileName);
    }

    /// <summary>
    /// Represents the contracts for building a <see cref="IApnsPayLoad"/> with <see cref="IApnsAlert"/> with title-loc-args
    /// </summary>
    public interface IApnsPayLoadBuilderAlertTitleLocalizableArgs : IPayLoadBuilder<IApnsPayLoad>
    {
        /// <summary>
        /// Adds a argument to title-loc-args of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="titleLocArgument">the title-loc-arg</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlertTitleLocalizableArgs AddTitleLocalizableArgument(string titleLocArgument);

        /// <summary>
        /// Sets the loc-key of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="localizableKey">the loc-Key</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlertLocalizableArgs LocalizableKey(string localizableKey);

        /// <summary>
        /// Sets the action-loc-key of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="actionLocalizableKey">the action-loc-key</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlertLaunchImage ActionLocalizableKey(string actionLocalizableKey);

        /// <summary>
        /// Sets the launch-image of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="launchImageFileName">the launch-image></param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithBadge LaunchImageFileName(string launchImageFileName);
    }

    /// <summary>
    /// Represents the contracts for building a <see cref="IApnsPayLoad"/> with <see cref="IApnsAlert"/> with loc-args
    /// </summary>
    public interface IApnsPayLoadBuilderAlertLocalizableArgs : IPayLoadBuilder<IApnsPayLoad>
    {
        /// <summary>
        /// Adds a argument to title-loc-args of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="localizableArgument">the title-loc-arg</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlertLocalizableArgs AddLocalizableArgument(string localizableArgument);

        /// <summary>
        /// Adds a argument to action-loc-key of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="actionLocalizableKey">the action-loc-key</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderAlertLaunchImage ActionLocalizableKey(string actionLocalizableKey);

        /// <summary>
        /// Sets the launch-image of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="launchImageFileName">the launch-image></param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithBadge LaunchImageFileName(string launchImageFileName);
    }

    /// <summary>
    /// Represents the contracts for building a <see cref="IApnsPayLoad"/> with <see cref="IApnsAlert"/> with launch-iamge
    /// </summary>
    public interface IApnsPayLoadBuilderAlertLaunchImage : IPayLoadBuilder<IApnsPayLoad>
    {
        /// <summary>
        /// Sets the launch-image of the <see cref="IApnsAlert"/>
        /// </summary>
        /// <param name="launchImageFileName">the launch-image></param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithBadge LaunchImageFileName(string launchImageFileName);

        /// <summary>
        /// Sets the badge count
        /// </summary>
        /// <param name="badgeCount">the badge count</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithSound BadgeCount(int badgeCount);
    }

    /// <summary>
    /// Represents the contracts for building a <see cref="IApnsPayLoad"/>
    /// </summary>
    public interface IApnsPayLoadBuilderWithBadge : IPayLoadBuilder<IApnsPayLoad>
    {
        /// <summary>
        /// Sets the badge count
        /// </summary>
        /// <param name="badgeCount">the badge count</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithSound BadgeCount(int badgeCount);

        /// <summary>
        /// Sets the sound
        /// </summary>
        /// <param name="soundName">the sound name</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithContentAvailable SoundName(string soundName);

        /// <summary>
        /// Sets if there is content available
        /// </summary>
        /// <param name="isContentAvailable">if there is content available</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithCategoryIdentifier IsContentAvailable(bool isContentAvailable);

        /// <summary>
        /// Sets the category
        /// </summary>
        /// <param name="categoryIdentifier">The category identifier</param>
        /// <returns>The payload builder</returns>
        IPayLoadBuilder<IApnsPayLoad> CategoryIdentifier(string categoryIdentifier);
    }

    /// <summary>
    /// Represents the contracts for building a <see cref="IApnsPayLoad"/>
    /// </summary>
    public interface IApnsPayLoadBuilderWithSound : IPayLoadBuilder<IApnsPayLoad>
    {
        /// <summary>
        /// Sets the sound
        /// </summary>
        /// <param name="soundName">the sound name</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithContentAvailable SoundName(string soundName);

        /// <summary>
        /// Sets if there is content available
        /// </summary>
        /// <param name="isContentAvailable">if there is content available</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithCategoryIdentifier IsContentAvailable(bool isContentAvailable);

        /// <summary>
        /// Sets the category
        /// </summary>
        /// <param name="categoryIdentifier">The category identifier</param>
        /// <returns>The payload builder</returns>
        IPayLoadBuilder<IApnsPayLoad> CategoryIdentifier(string categoryIdentifier);
    }

    /// <summary>
    /// Represents the contracts for building a <see cref="IApnsPayLoad"/>
    /// </summary>
    public interface IApnsPayLoadBuilderWithContentAvailable : IPayLoadBuilder<IApnsPayLoad>
    {
        /// <summary>
        /// Sets if there is content available
        /// </summary>
        /// <param name="isContentAvailable">if there is content available</param>
        /// <returns>The payload builder</returns>
        IApnsPayLoadBuilderWithCategoryIdentifier IsContentAvailable(bool isContentAvailable);

        /// <summary>
        /// Sets the category
        /// </summary>
        /// <param name="categoryIdentifier">The category identifier</param>
        /// <returns>The payload builder</returns>
        IPayLoadBuilder<IApnsPayLoad> CategoryIdentifier(string categoryIdentifier);
    }

    /// <summary>
    /// Represents the contracts for building a <see cref="IApnsPayLoad"/>
    /// </summary>
    public interface IApnsPayLoadBuilderWithCategoryIdentifier : IPayLoadBuilder<IApnsPayLoad>
    {
        /// <summary>
        /// Sets the category
        /// </summary>
        /// <param name="categoryIdentifier">The category identifier</param>
        /// <returns>The payload builder</returns>
        IPayLoadBuilder<IApnsPayLoad> CategoryIdentifier(string categoryIdentifier);
    }
}