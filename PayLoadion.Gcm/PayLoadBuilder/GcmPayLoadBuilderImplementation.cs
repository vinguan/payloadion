using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayLoadion.Gcm.PayLoad;
using PayLoadion.Gcm.PayLoad.GcmNotification;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Gcm.PayLoadBuilder
{
    internal class GcmPayLoadBuilderImplementation :
        IPayLoadBuilder<IGcmPayLoad>,
        IGcmPayLoadBuilder,
        IGcmPayLoadBuilderNotificationTitle,
        IGcmPayLoadBuilderNotificationIcon,
        IGcmPayLoadBuilderNotificationOptions,
        IGcmPayLoadBuilderNotificationBodyLocalizableArgs,
        IGcmPayLoadBuilderNotificationTitleLocalizableArgs
    {
        #region Fields
        private GcmPayLoadImplementation _gcmPayLoadImplementation;
        #endregion Fields

        #region Properties

        #region Private Properties

        #endregion Private Properties

        #region Public Properties

        #endregion Public Properties

        #region Protected Properties

        #endregion Protected Properties

        #region Internal Properties

        #endregion Internal Properties

        #endregion Properties

        #region Constructors

        #region Private Constructors

        #endregion Private Constructors

        #region Public Constructors

        #endregion Public Constructors

        #region Protected Constructors

        #endregion Protected Constructors

        #region Internal Constructors
        internal GcmPayLoadBuilderImplementation()
        {
            _gcmPayLoadImplementation = new GcmPayLoadImplementation();
        }

        internal GcmPayLoadBuilderImplementation(IGcmPayLoad gcmPayLoad)
        {
            _gcmPayLoadImplementation = new GcmPayLoadImplementation(gcmPayLoad);
        }
        #endregion Internal Constructors

        #endregion Constructors

        #region Methods

        #region Private Methods

        #endregion Private Methods

        #region Public Methods
        #region IGcmPayLoadBuilder

        IGcmPayLoadBuilder IGcmPayLoadBuilder.AddCustomData(IDictionary<string, object> customDataDictionary)
        {
            foreach (var customData in customDataDictionary)
            {
                _gcmPayLoadImplementation.InternalCustomData.Add(customData.Key, customData.Value);
            }

            return this;
        }

        IGcmPayLoadBuilder IGcmPayLoadBuilder.AddCustomData(string customDataKey, object customDataValue)
        {
            _gcmPayLoadImplementation.InternalCustomData.Add(customDataKey, customDataValue);

            return this;
        }

        IGcmPayLoadBuilderNotificationTitle IGcmPayLoadBuilder.Notification()
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation = new GcmNotificationImplementation();

            return this;
        }
        #endregion

        #region IGcmPayLoadBuilderTitle

        IGcmPayLoadBuilderNotificationIcon IGcmPayLoadBuilderNotificationTitle.Title(string title)
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation.Title = title;

            return this;
        }
        #endregion IGcmPayLoadBuilderTitle

        #region IGcmPayLoadBuilderNotificationIcon

        IGcmPayLoadBuilderNotificationOptions IGcmPayLoadBuilderNotificationIcon.Icon(string icon)
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation.Icon = icon;

            return this;
        }
        #endregion 

        #region IGcmPayLoadBuilderNotificationOptions

        IGcmPayLoadBuilderNotificationOptions IGcmPayLoadBuilderNotificationOptions.Body(string body)
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation.Body = body;

            return this;
        }

        IGcmPayLoadBuilderNotificationOptions IGcmPayLoadBuilderNotificationOptions.Sound(string soundFileName)
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation.Sound = soundFileName;

            return this;
        }

        IGcmPayLoadBuilderNotificationOptions IGcmPayLoadBuilderNotificationOptions.BadgeCount(string badgeCount)
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation.Badge = badgeCount;

            return this;
        }

        IGcmPayLoadBuilderNotificationOptions IGcmPayLoadBuilderNotificationOptions.Tag(string tag)
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation.Tag = tag;

            return this;
        }

        IGcmPayLoadBuilderNotificationOptions IGcmPayLoadBuilderNotificationOptions.Color(string color)
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation.Color = color;

            return this;
        }

        IGcmPayLoadBuilderNotificationOptions IGcmPayLoadBuilderNotificationOptions.ClickAction(string clickAction)
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation.ClickAction = clickAction;

            return this;
        }

        IGcmPayLoadBuilderNotificationBodyLocalizableArgs IGcmPayLoadBuilderNotificationOptions.BodyLocalizableKey(string bodyLocalizableKey)
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation.BodyLocKey = bodyLocalizableKey;

            return this;
        }

        IGcmPayLoadBuilderNotificationTitleLocalizableArgs IGcmPayLoadBuilderNotificationOptions.TitleLocalizableKey(string titleLocalizableKey)
        {
            _gcmPayLoadImplementation.GcmNotificationImplementation.TitleLocKey = titleLocalizableKey;

            return this;
        }

        #endregion 

        #region IGcmPayLoadBuilderNotificationBodyLocalizableArgs

        IGcmPayLoadBuilderNotificationBodyLocalizableArgs IGcmPayLoadBuilderNotificationBodyLocalizableArgs.AddBodyLocalizableArgument(string bodyLocArgument)
        {
            if (string.IsNullOrEmpty(bodyLocArgument))
                throw new ArgumentNullException(nameof(bodyLocArgument));

            _gcmPayLoadImplementation.GcmNotificationImplementation.InternalBodyLocArgs.Add(bodyLocArgument);

            return this;
        }

        IGcmPayLoadBuilderNotificationTitleLocalizableArgs IGcmPayLoadBuilderNotificationBodyLocalizableArgs.TitleLocalizableKey(string titleLocalizableKey)
        {
            if (string.IsNullOrEmpty(titleLocalizableKey))
                throw new ArgumentNullException(nameof(titleLocalizableKey));

            _gcmPayLoadImplementation.GcmNotificationImplementation.TitleLocKey = titleLocalizableKey;

            return this;
        }

        #endregion 

        #region IGcmPayLoadBuilderNotificationTitleLocalizableArgs

        IGcmPayLoadBuilderNotificationTitleLocalizableArgs IGcmPayLoadBuilderNotificationTitleLocalizableArgs.AddTitleLocalizableArgument(string titleLocArgument)
        {
            if (string.IsNullOrEmpty(titleLocArgument))
                throw new ArgumentNullException(nameof(titleLocArgument));

            _gcmPayLoadImplementation.GcmNotificationImplementation.InternalTitleLocArgs.Add(titleLocArgument);

            return this;
        }

        #endregion IGcmPayLoadBuilderNotificationTitleLocalizableArgs

        #region IPayLoadBuilder<IGcmPayLoad>
        public IGcmPayLoad BuildPayLoad()
        {
            return _gcmPayLoadImplementation;
        }

        public async Task<IGcmPayLoad> BuildPayLoadAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await Task.Run(() => BuildPayLoad(), cancellationToken);
        }

        public string BuildPayLoadToString(bool indent = false)
        {
            return JsonConvert.SerializeObject(_gcmPayLoadImplementation, indent ? Formatting.Indented : Formatting.None);
        }

        public async Task<string> BuildPayLoadToStringAsync(bool indent = false, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await Task.Run(() => BuildPayLoadToString(indent), cancellationToken);
        }
        #endregion IPayLoadBuilder<IGcmPayLoad>

        #region IDisposable
        public void Dispose()
        {
            _gcmPayLoadImplementation.Dispose();

            _gcmPayLoadImplementation = null;

            GC.SuppressFinalize(this);
        }
        #endregion IDisposable
        #endregion Public Methods

        #region Protected Methods

        #endregion Protected Methods

        #region Internal Methods

        #endregion Internal Methods

        #endregion Methods
    }
}