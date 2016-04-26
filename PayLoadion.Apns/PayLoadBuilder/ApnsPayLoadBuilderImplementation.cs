using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayLoadion.Apns.Exceptions;
using PayLoadion.Apns.PayLoad;
using PayLoadion.Apns.PayLoad.Alert;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Apns.PayLoadBuilder
{
    internal class ApnsPayLoadBuilderImplementation : IPayLoadBuilder<IApnsPayLoad>,
                                                      IApnsPayLoadBuilderStart,
                                                      IApnsPayLoadBuilderAlert,
                                                      IApnsPayLoadBuilderAlertTitleLocalizableArgs,
                                                      IApnsPayLoadBuilderAlertLocalizableArgs,
                                                      IApnsPayLoadBuilderAlertLaunchImage,
                                                      IApnsPayLoadBuilderWithBadge,
                                                      IApnsPayLoadBuilderWithSound,
                                                      IApnsPayLoadBuilderWithContentAvailable,
                                                      IApnsPayLoadBuilderWithCategoryIdentifier
    {
        private ApnsPayLoadImplementation _apnsPayLoadImplementation;

        public IApnsPayLoad PayLoad
        {
            get { return _apnsPayLoadImplementation; }
        }

        internal ApnsPayLoadBuilderImplementation()
        {
            _apnsPayLoadImplementation = new ApnsPayLoadImplementation();
        }

        internal ApnsPayLoadBuilderImplementation(IApnsPayLoad apnsPayLoad)
        {
            _apnsPayLoadImplementation = new ApnsPayLoadImplementation(apnsPayLoad);
        }

        public IApnsPayLoadBuilderWithBadge Alert(string alertMessage)
        {
            _apnsPayLoadImplementation.AlertMessage = alertMessage;

            return this;
        }

        public IApnsPayLoadBuilderAlert Alert()
        {
            _apnsPayLoadImplementation.AlertImplementation = new ApnsAlertImplementation();

            return this;
        }

        #region IApnsPayLoadBuilderAlert

        IApnsPayLoadBuilderAlert IApnsPayLoadBuilderAlert.Title(string title)
        {
            _apnsPayLoadImplementation.AlertImplementation.Title = title;

            return this;
        }

        IApnsPayLoadBuilderAlert IApnsPayLoadBuilderAlert.Body(string body)
        {
            _apnsPayLoadImplementation.AlertImplementation.Body = body;

            return this;
        }

        IApnsPayLoadBuilderAlertTitleLocalizableArgs IApnsPayLoadBuilderAlert.TitleLocalizableKey(string titleLocKey)
        {
            _apnsPayLoadImplementation.AlertImplementation.TitleLocKey = titleLocKey;

            return this;
        }

        IApnsPayLoadBuilderAlertLocalizableArgs IApnsPayLoadBuilderAlert.LocalizableKey(string localizableKey)
        {
            _apnsPayLoadImplementation.AlertImplementation.LocKey = localizableKey;

            return this;
        }

        IApnsPayLoadBuilderAlertLaunchImage IApnsPayLoadBuilderAlert.ActionLocalizableKey(string actionLocalizableKey)
        {
            _apnsPayLoadImplementation.AlertImplementation.ActionLocKey = actionLocalizableKey;

            return this;
        }

        IApnsPayLoadBuilderWithBadge IApnsPayLoadBuilderAlert.LaunchImageFileName(string launchImageFileName)
        {
            _apnsPayLoadImplementation.AlertImplementation.LaunchImage = launchImageFileName;

            return this;
        }

        #endregion IApnsPayLoadBuilderAlert

        #region IApnsPayLoadBuilderAlertTitleLocalizableArgs
        IApnsPayLoadBuilderAlertTitleLocalizableArgs IApnsPayLoadBuilderAlertTitleLocalizableArgs.AddTitleLocalizableArgument(string titleLocArgument)
        {
            _apnsPayLoadImplementation.AlertImplementation.InternalTitleLocArgs.Add(titleLocArgument);

            return this;
        }

        IApnsPayLoadBuilderAlertLocalizableArgs IApnsPayLoadBuilderAlertTitleLocalizableArgs.LocalizableKey(string localizableKey)
        {
            _apnsPayLoadImplementation.AlertImplementation.LocKey = localizableKey;

            return this;
        }

        IApnsPayLoadBuilderAlertLaunchImage IApnsPayLoadBuilderAlertTitleLocalizableArgs.ActionLocalizableKey(string actionLocalizableKey)
        {
            _apnsPayLoadImplementation.AlertImplementation.ActionLocKey = actionLocalizableKey;

            return this;
        }

        IApnsPayLoadBuilderWithBadge IApnsPayLoadBuilderAlertTitleLocalizableArgs.LaunchImageFileName(string launchImageFileName)
        {
            _apnsPayLoadImplementation.AlertImplementation.LaunchImage = launchImageFileName;

            return this;
        }
        #endregion IApnsPayLoadBuilderAlertTitleLocalizableArgs

        #region IApnsPayLoadBuilderAlertLocalizableArgs 
        IApnsPayLoadBuilderAlertLocalizableArgs IApnsPayLoadBuilderAlertLocalizableArgs.AddLocalizableArgument(string localizableArgument)
        {
            _apnsPayLoadImplementation.AlertImplementation.InternalLocArgs.Add(localizableArgument);

            return this;
        }

        IApnsPayLoadBuilderAlertLaunchImage IApnsPayLoadBuilderAlertLocalizableArgs.ActionLocalizableKey(string actionLocalizableKey)
        {
            _apnsPayLoadImplementation.AlertImplementation.ActionLocKey = actionLocalizableKey;

            return this;
        }

        IApnsPayLoadBuilderWithBadge IApnsPayLoadBuilderAlertLocalizableArgs.LaunchImageFileName(string launchImageFileName)
        {
            _apnsPayLoadImplementation.AlertImplementation.LaunchImage = launchImageFileName;

            return this;
        }
        #endregion IApnsPayLoadBuilderAlertLocalizableArgs

        #region IApnsPayLoadBuilderAlertLaunchImage
        IApnsPayLoadBuilderWithBadge IApnsPayLoadBuilderAlertLaunchImage.LaunchImageFileName(string launchImageFileName)
        {
            _apnsPayLoadImplementation.AlertImplementation.LaunchImage = launchImageFileName;

            return this;
        }

        IApnsPayLoadBuilderWithSound IApnsPayLoadBuilderAlertLaunchImage.BadgeCount(int badgeCount)
        {
            _apnsPayLoadImplementation.Badge = badgeCount;

            return this;
        }
        #endregion IApnsPayLoadBuilderAlertLaunchImage

        #region IApnsPayLoadBuilderWithBadge

        IApnsPayLoadBuilderWithSound IApnsPayLoadBuilderWithBadge.BadgeCount(int badgeCount)
        {
            _apnsPayLoadImplementation.Badge = badgeCount;

            return this;
        }

        IApnsPayLoadBuilderWithContentAvailable IApnsPayLoadBuilderWithBadge.SoundName(string soundName)
        {
            _apnsPayLoadImplementation.Sound = soundName;

            return this;
        }

        IApnsPayLoadBuilderWithCategoryIdentifier IApnsPayLoadBuilderWithBadge.IsContentAvailable(bool isContentAvailable)
        {
            _apnsPayLoadImplementation.ContentAvailable = isContentAvailable ? 1 : (int?)null;

            return this;
        }

        IPayLoadBuilder<IApnsPayLoad> IApnsPayLoadBuilderWithBadge.CategoryIdentifier(string categoryIdentifier)
        {
            _apnsPayLoadImplementation.Category = categoryIdentifier;

            return this;
        }
        #endregion IApnsPayLoadBuilderWithBadge

        #region IApnsPayLoadBuilderWithSound
        IApnsPayLoadBuilderWithContentAvailable IApnsPayLoadBuilderWithSound.SoundName(string soundName)
        {
            _apnsPayLoadImplementation.Sound = soundName;

            return this;
        }

        IApnsPayLoadBuilderWithCategoryIdentifier IApnsPayLoadBuilderWithSound.IsContentAvailable(bool isContentAvailable)
        {
            _apnsPayLoadImplementation.ContentAvailable = isContentAvailable ? 1 : (int?)null;

            return this;
        }

        IPayLoadBuilder<IApnsPayLoad> IApnsPayLoadBuilderWithSound.CategoryIdentifier(string categoryIdentifier)
        {
            _apnsPayLoadImplementation.Category = categoryIdentifier;

            return this;
        }
        #endregion IApnsPayLoadBuilderWithSound

        #region IApnsPayLoadBuilderWithContentAvailable
        IApnsPayLoadBuilderWithCategoryIdentifier IApnsPayLoadBuilderWithContentAvailable.IsContentAvailable(bool isContentAvailable)
        {
            _apnsPayLoadImplementation.ContentAvailable = isContentAvailable ? 1 : (int?)null;

            return this;
        }

        IPayLoadBuilder<IApnsPayLoad> IApnsPayLoadBuilderWithContentAvailable.CategoryIdentifier(string categoryIdentifier)
        {
            _apnsPayLoadImplementation.Category = categoryIdentifier;

            return this;
        }
        #endregion IApnsPayLoadBuilderWithContentAvailable

        #region IApnsPayLoadBuilderWithCategoryIdentifier
        IPayLoadBuilder<IApnsPayLoad> IApnsPayLoadBuilderWithCategoryIdentifier.CategoryIdentifier(string categoryIdentifier)
        {
            _apnsPayLoadImplementation.Category = categoryIdentifier;

            return this;
        }
        #endregion IApnsPayLoadBuilderWithCategoryIdentifier

        #region IPayLoadBuilder<IApnsPayLoad>
        public IPayLoadBuilder<IApnsPayLoad> AddCustomData(string customDataKey, object customDataValue)
        {
            if (string.IsNullOrEmpty(customDataKey))
                throw new ArgumentNullException(nameof(customDataKey));

            if (customDataValue == null)
                throw new ArgumentNullException(nameof(customDataValue));

            _apnsPayLoadImplementation.InternalCustomData.Add(customDataKey, customDataValue);

            return this;
        }

        public IApnsPayLoad BuildPayLoad()
        {
            return _apnsPayLoadImplementation;
        }

        public async Task<IApnsPayLoad> BuildPayLoadAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                return await Task.Run(() => BuildPayLoad(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApnsPayloadBuilderException("An unexpected error ocurred while building ApnsPayLoad, please check inner exception", ex);
            }
        }

        public string BuildPayLoadToString(bool indent = false)
        {
            if (_apnsPayLoadImplementation.AlertMessage != null && _apnsPayLoadImplementation.Alert != null)
            {
                throw new ApnsPayloadBuilderException("AlertMessage and IApnsAlert are not null, choose to use one of them");
            }

            try
            {
                var apsJObject = JObject.FromObject(new
                {
                    aps = _apnsPayLoadImplementation,
                });

                if (_apnsPayLoadImplementation.CustomData == null || _apnsPayLoadImplementation.CustomData.Count <= 0)
                    return apsJObject.ToString();

                foreach (var customData in _apnsPayLoadImplementation.CustomData)
                {
                    var valueType = customData.Value.GetType();

                    if (customData.Value is string || valueType.GetTypeInfo().IsValueType)
                    {
                        apsJObject.Add(new JProperty(customData.Key, customData.Value));
                    }
                    else
                    {
                        apsJObject.Add(new JProperty(customData.Key, JObject.FromObject(customData.Value)));
                    }
                }

                return apsJObject.ToString(indent ? Formatting.Indented : Formatting.None);
            }
            catch (Exception ex)
            {
                throw new ApnsPayloadBuilderException("An unexpected error ocurred while building ApnsPayLoad, please check inner exception", ex);
            }
        }

        public async Task<string> BuildPayLoadToStringAsync(bool indent = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                return await Task.Run(() => BuildPayLoadToString(indent), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApnsPayloadBuilderException("An unexpected error ocurred while building ApnsPayLoad, please check inner exception", ex);
            }
        }
        #endregion IPayLoadBuilder<IApnsPayLoad>

        #region IDisposable
        public void Dispose()
        {
            _apnsPayLoadImplementation = null;
        }
        #endregion IDisposable
    }
}