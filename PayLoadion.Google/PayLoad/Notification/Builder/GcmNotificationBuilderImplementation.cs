using System;
using System.Threading.Tasks;
using PayLoadion.Builder;
using PayLoadion.Google.Exceptions;

namespace PayLoadion.Google.PayLoad.Notification.Builder
{
    internal class GcmNotificationBuilderImplementation : IGcmNotificationBuilder
    {
        private GcmNotificationImplementation _gcmNotificationImplementation;

        internal GcmNotificationBuilderImplementation()
        {
            _gcmNotificationImplementation = new GcmNotificationImplementation();
        }

        internal GcmNotificationBuilderImplementation(IGcmNotification gcmNotification)
        {
            _gcmNotificationImplementation = new GcmNotificationImplementation(gcmNotification);
        }

        public IGcmNotificationBuilder Title(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            _gcmNotificationImplementation.Title = title;

            return this;
        }

        public IGcmNotificationBuilder Body(string body)
        {
            if (string.IsNullOrEmpty(body))
                throw new ArgumentNullException(nameof(body));

            _gcmNotificationImplementation.Body = body;

            return this;
        }

        public IGcmNotificationBuilder IconFileName(string iconFileName)
        {
            if (string.IsNullOrEmpty(iconFileName))
                throw new ArgumentNullException(nameof(iconFileName));

            _gcmNotificationImplementation.Icon = iconFileName;

            return this;
        }

        public IGcmNotificationBuilder SoundFileName(string soundFileName)
        {
            if (string.IsNullOrEmpty(soundFileName))
                throw new ArgumentNullException(nameof(soundFileName));

            _gcmNotificationImplementation.Sound = soundFileName;

            return this;
        }

        public IGcmNotificationBuilder BadgeCount(string badgeCount)
        {
            if (string.IsNullOrEmpty(badgeCount))
                throw new ArgumentNullException(nameof(badgeCount));

            _gcmNotificationImplementation.Badge = badgeCount;

            return this;
        }

        public IGcmNotificationBuilder Tag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
                throw new ArgumentNullException(nameof(tag));

            _gcmNotificationImplementation.Tag = tag;

            return this;
        }

        public IGcmNotificationBuilder Color(string color)
        {
            if (string.IsNullOrEmpty(color))
                throw new ArgumentNullException(nameof(color));

            _gcmNotificationImplementation.Color = color;

            return this;
        }

        public IGcmNotificationBuilder ClickAction(string clickAction)
        {
            if (string.IsNullOrEmpty(clickAction))
                throw new ArgumentNullException(nameof(clickAction));

            _gcmNotificationImplementation.ClickAction = clickAction;

            return this;
        }

        public IGcmNotificationBuilder BodyLocalizableKey(string bodyLocalizableKey)
        {
            if (string.IsNullOrEmpty(bodyLocalizableKey))
                throw new ArgumentNullException(nameof(bodyLocalizableKey));

            _gcmNotificationImplementation.BodyLocKey = bodyLocalizableKey;

            return this;
        }

        public IGcmNotificationBuilder AddBodyLocalizableArgument(string bodyLocArgument)
        {
            if (string.IsNullOrEmpty(bodyLocArgument))
                throw new ArgumentNullException(nameof(bodyLocArgument));

            _gcmNotificationImplementation.InternalBodyLocArgs.Add(bodyLocArgument);

            return this;
        }

        public IGcmNotificationBuilder TitleLocalizableKey(string titleLocalizableKey)
        {
            if (string.IsNullOrEmpty(titleLocalizableKey))
                throw new ArgumentNullException(nameof(titleLocalizableKey));

            _gcmNotificationImplementation.TitleLocKey = titleLocalizableKey;

            return this;
        }

        public IGcmNotificationBuilder AddTitleLocalizableArgument(string titleLocArgument)
        {
            if (string.IsNullOrEmpty(titleLocArgument))
                throw new ArgumentNullException(nameof(titleLocArgument));

            _gcmNotificationImplementation.InternalTitleLocArgs.Add(titleLocArgument);

            return this;
        }

        public IGcmNotification Build()
        {
            if (_gcmNotificationImplementation.TitleLocKey == null && 
               (_gcmNotificationImplementation.TitleLocArgs != null && _gcmNotificationImplementation.TitleLocArgs.Count > 0))
            {
                throw new GcmNotificationBuilderException("TitleLocKey is null but it has TitleLocKey") { GcmNotificationWithErrors = _gcmNotificationImplementation }; ;
            }

            if (_gcmNotificationImplementation.BodyLocKey == null &&
               (_gcmNotificationImplementation.BodyLocArgs != null && _gcmNotificationImplementation.BodyLocArgs.Count > 0))
            {
                throw new GcmNotificationBuilderException("LocKey is null but it has LocArgs") { GcmNotificationWithErrors = _gcmNotificationImplementation };
            }

            return _gcmNotificationImplementation;
        }

        public async Task<IGcmNotification> BuildAsync()
        {
            return await Task.Run(() => Build());
        }

        public void Dispose()
        {
            _gcmNotificationImplementation = null;
        }
    }
}