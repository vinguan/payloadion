using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayLoadion.Google.Exceptions;
using PayLoadion.Google.GcmDownStreamHttpJsonMessage.Builder;

namespace PayLoadion.Google.PayLoad.GcmNotification.Builder
{
    internal class GcmNotificationBuilderImplementation : IGcmNotificationBuilder,
        IGcmNotificationBuilderTitle,
        IGcmNotificationBuilderIcon,
        IGcmNotificationBuilderOptions,
        IGcmNotificationBuilderBodyLocalizableArgs,
        IGcmNotificationBuilderTitleLocalizableArgs

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

        #region IGcmNotificationBuilderTitle
        public IGcmNotificationBuilderIcon Title(string title)
        {
            _gcmNotificationImplementation.Title = title;

            return this;
        }
        #endregion IGcmNotificationBuilderTitle

        #region IGcmNotificationBuilderIcon
        public IGcmNotificationBuilderOptions Icon(string icon)
        {
            _gcmNotificationImplementation.Icon = icon;

            return this;
        }
        #endregion IGcmNotificationBuilderIcon

        #region IGcmNotificationBuilderOptions
        public IGcmNotificationBuilderOptions Body(string body)
        {
            _gcmNotificationImplementation.Body = body;

            return this;
        }

        public IGcmNotificationBuilderOptions SoundFileName(string soundFileName)
        {
            _gcmNotificationImplementation.Sound = soundFileName;

            return this;
        }

        public IGcmNotificationBuilderOptions BadgeCount(string badgeCount)
        {
            _gcmNotificationImplementation.Badge = badgeCount;

            return this;
        }

        public IGcmNotificationBuilderOptions Tag(string tag)
        {
            _gcmNotificationImplementation.Tag = tag;

            return this;
        }

        public IGcmNotificationBuilderOptions Color(string color)
        {
            _gcmNotificationImplementation.Color = color;

            return this;
        }

        public IGcmNotificationBuilderOptions ClickAction(string clickAction)
        {
            _gcmNotificationImplementation.ClickAction = clickAction;

            return this;
        }

        public IGcmNotificationBuilderBodyLocalizableArgs BodyLocalizableKey(string bodyLocalizableKey)
        {
            if (string.IsNullOrEmpty(bodyLocalizableKey))
                throw new ArgumentNullException(nameof(bodyLocalizableKey));

            _gcmNotificationImplementation.BodyLocKey = bodyLocalizableKey;

            return this;
        }

        IGcmDownStreamHttpJsonMessageBuilder IGcmNotificationBuilderOptions.CollapseKey(string collapseKey)
        {
            return GcmDownStreamHttpJsonMessageBuilderImplementation.StaticByPassGcmDownStreamHttpJsonMessageBuilderImplementation;
        }

        #endregion IGcmNotificationBuilderOptions

        #region IGcmNotificationBuilderBodyLocalizableArgs
        public IGcmNotificationBuilderBodyLocalizableArgs AddBodyLocalizableArgument(string bodyLocArgument)
        {
            if (string.IsNullOrEmpty(bodyLocArgument))
                throw new ArgumentNullException(nameof(bodyLocArgument));

            _gcmNotificationImplementation.InternalBodyLocArgs.Add(bodyLocArgument);

            return this;
        }

        public IGcmNotificationBuilderTitleLocalizableArgs TitleLocalizableKey(string titleLocalizableKey)
        {
            if (string.IsNullOrEmpty(titleLocalizableKey))
                throw new ArgumentNullException(nameof(titleLocalizableKey));

            _gcmNotificationImplementation.TitleLocKey = titleLocalizableKey;

            return this;
        }

        IGcmDownStreamHttpJsonMessageBuilder IGcmNotificationBuilderBodyLocalizableArgs.CollapseKey(string collapseKey)
        {
            return GcmDownStreamHttpJsonMessageBuilderImplementation.StaticByPassGcmDownStreamHttpJsonMessageBuilderImplementation;
        }
        #endregion IGcmNotificationBuilderBodyLocalizableArgs

        #region IGcmNotificationBuilderTitleLocalizableArgs
        public IGcmNotificationBuilderTitleLocalizableArgs AddTitleLocalizableArgument(string titleLocArgument)
        {
            if (string.IsNullOrEmpty(titleLocArgument))
                throw new ArgumentNullException(nameof(titleLocArgument));

            _gcmNotificationImplementation.InternalTitleLocArgs.Add(titleLocArgument);

            return this;
        }

        IGcmDownStreamHttpJsonMessageBuilder IGcmNotificationBuilderTitleLocalizableArgs.CollapseKey(string collapseKey)
        {
            return GcmDownStreamHttpJsonMessageBuilderImplementation.StaticByPassGcmDownStreamHttpJsonMessageBuilderImplementation;
        }
        #endregion IGcmNotificationBuilderTitleLocalizableArgs

        #region IGcmNotificationBuilder

        public IGcmNotification BuildGcmNotification()
        {
            if (_gcmNotificationImplementation.TitleLocKey == null &&
                (_gcmNotificationImplementation.TitleLocArgs != null && _gcmNotificationImplementation.TitleLocArgs.Count > 0))
            {
                throw new GcmNotificationBuilderException("TitleLocKey is null but it has TitleLocArgs") { GcmNotificationWithErrors = _gcmNotificationImplementation }; ;
            }

            if (_gcmNotificationImplementation.BodyLocKey == null &&
               (_gcmNotificationImplementation.BodyLocArgs != null && _gcmNotificationImplementation.BodyLocArgs.Count > 0))
            {
                throw new GcmNotificationBuilderException("LocKey is null but it has LocArgs") { GcmNotificationWithErrors = _gcmNotificationImplementation };
            }

            return _gcmNotificationImplementation;
        }

        public async Task<IGcmNotification> BuildGcmNotificationAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Task.Run(() => BuildGcmNotification(), cancellationToken);
        }

        public string BuildGcmNotificationToString()
        {
            return JsonConvert.SerializeObject(_gcmNotificationImplementation);
        }

        public async Task<string> BuildGcmNotificationToStringAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Task.Run(() => BuildGcmNotificationToString(), cancellationToken);
        }

        #endregion IGcmNotificationBuilder 
    }
}