using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayLoadion.Apple.Exceptions;
using PayLoadion.Apple.PayLoad;
using PayLoadion.Apple.PayLoad.Alert;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Apple.PayLoadBuilder
{
    internal class ApnsPayLoadBuilderImplementation : IApnsPayLoadBuilder,
                                                      IApnsPayLoadBuilderAlert,
                                                      IApnsPayLoadBuilderAlertTitleLocalizableArgs,
                                                      IApnsPayLoadBuilderAlertLocalizableArgs,
                                                      IApnsPayLoadBuilderAlertLaunchImage,
                                                      IApnsPayLoadBuilderWithBadge,
                                                      IApnsPayLoadBuilderWithSound,
                                                      IApnsPayLoadBuilderWithContentAvailable,
                                                      IApnsPayLoadBuilderWithCategoryIdentifier
    {
        protected ApnsPayLoadImplementation ApnsPayLoadImplementation;

        public IApnsPayLoad PayLoad
        {
            get { return ApnsPayLoadImplementation; }
        }

        internal ApnsPayLoadBuilderImplementation()
        {
            ApnsPayLoadImplementation = new ApnsPayLoadImplementation();
        }

        internal ApnsPayLoadBuilderImplementation(IApnsPayLoad apnsPayLoad)
        {
            ApnsPayLoadImplementation = new ApnsPayLoadImplementation(apnsPayLoad);
        }

        public IApnsPayLoadBuilderWithBadge Alert(string alertMessage)
        {
            ApnsPayLoadImplementation.AlertMessage = alertMessage;

            return this;
        }

        public IApnsPayLoadBuilderAlert Alert()
        {
            ApnsPayLoadImplementation.AlertImplementation = new ApnsAlertImplementation();

            return this;
        }

        #region IApnsPayLoadBuilderAlert

        IApnsPayLoadBuilderAlert IApnsPayLoadBuilderAlert.Title(string title)
        {
            ApnsPayLoadImplementation.AlertImplementation.Title = title;

            return this;
        }

        IApnsPayLoadBuilderAlert IApnsPayLoadBuilderAlert.Body(string body)
        {
            ApnsPayLoadImplementation.AlertImplementation.Body = body;

            return this;
        }

        IApnsPayLoadBuilderAlertTitleLocalizableArgs IApnsPayLoadBuilderAlert.TitleLocalizableKey(string titleLocKey)
        {
            ApnsPayLoadImplementation.AlertImplementation.TitleLocKey = titleLocKey;

            return this;
        }

        IApnsPayLoadBuilderAlertLocalizableArgs IApnsPayLoadBuilderAlert.LocalizableKey(string localizableKey)
        {
            ApnsPayLoadImplementation.AlertImplementation.LocKey = localizableKey;

            return this;
        }

        IApnsPayLoadBuilderAlertLaunchImage IApnsPayLoadBuilderAlert.ActionLocalizableKey(string actionLocalizableKey)
        {
            ApnsPayLoadImplementation.AlertImplementation.ActionLocKey = actionLocalizableKey;

            return this;
        }

        IApnsPayLoadBuilderWithBadge IApnsPayLoadBuilderAlert.LaunchImageFileName(string launchImageFileName)
        {
            ApnsPayLoadImplementation.AlertImplementation.LaunchImage = launchImageFileName;

            return this;
        }

        #endregion IApnsPayLoadBuilderAlert

        #region IApnsPayLoadBuilderAlertTitleLocalizableArgs
        IApnsPayLoadBuilderAlertTitleLocalizableArgs IApnsPayLoadBuilderAlertTitleLocalizableArgs.AddTitleLocalizableArgument(string titleLocArgument)
        {
            ApnsPayLoadImplementation.AlertImplementation.InternalTitleLocArgs.Add(titleLocArgument);

            return this;
        }

        IApnsPayLoadBuilderAlertLocalizableArgs IApnsPayLoadBuilderAlertTitleLocalizableArgs.LocalizableKey(string localizableKey)
        {
            ApnsPayLoadImplementation.AlertImplementation.LocKey = localizableKey;

            return this;
        }

        IApnsPayLoadBuilderAlertLaunchImage IApnsPayLoadBuilderAlertTitleLocalizableArgs.ActionLocalizableKey(string actionLocalizableKey)
        {
            ApnsPayLoadImplementation.AlertImplementation.ActionLocKey = actionLocalizableKey;

            return this;
        }

        IApnsPayLoadBuilderWithBadge IApnsPayLoadBuilderAlertTitleLocalizableArgs.LaunchImageFileName(string launchImageFileName)
        {
            ApnsPayLoadImplementation.AlertImplementation.LaunchImage = launchImageFileName;

            return this;
        }
        #endregion IApnsPayLoadBuilderAlertTitleLocalizableArgs

        #region IApnsPayLoadBuilderAlertLocalizableArgs 
        IApnsPayLoadBuilderAlertLocalizableArgs IApnsPayLoadBuilderAlertLocalizableArgs.AddLocalizableArgument(string titleLocalizableArgument)
        {
            ApnsPayLoadImplementation.AlertImplementation.InternalLocArgs.Add(titleLocalizableArgument);

            return this;
        }

        IApnsPayLoadBuilderAlertLaunchImage IApnsPayLoadBuilderAlertLocalizableArgs.ActionLocalizableKey(string actionLocalizableKey)
        {
            ApnsPayLoadImplementation.AlertImplementation.ActionLocKey = actionLocalizableKey;

            return this;
        }

        IApnsPayLoadBuilderWithBadge IApnsPayLoadBuilderAlertLocalizableArgs.LaunchImageFileName(string launchImageFileName)
        {
            ApnsPayLoadImplementation.AlertImplementation.LaunchImage = launchImageFileName;

            return this;
        }
        #endregion IApnsPayLoadBuilderAlertLocalizableArgs

        #region IApnsPayLoadBuilderAlertLaunchImage
        IApnsPayLoadBuilderWithBadge IApnsPayLoadBuilderAlertLaunchImage.LaunchImageFileName(string launchImageFileName)
        {
            ApnsPayLoadImplementation.AlertImplementation.LaunchImage = launchImageFileName;

            return this;
        }

        IApnsPayLoadBuilderWithSound IApnsPayLoadBuilderAlertLaunchImage.BadgeCount(int badgeCount)
        {
            ApnsPayLoadImplementation.Badge = badgeCount;

            return this;
        }
        #endregion IApnsPayLoadBuilderAlertLaunchImage

        #region IApnsPayLoadBuilderWithBadge

        IApnsPayLoadBuilderWithSound IApnsPayLoadBuilderWithBadge.BadgeCount(int badgeCount)
        {
            ApnsPayLoadImplementation.Badge = badgeCount;

            return this;
        }

        IApnsPayLoadBuilderWithContentAvailable IApnsPayLoadBuilderWithBadge.SoundName(string soundName)
        {
            ApnsPayLoadImplementation.Sound = soundName;

            return this;
        }

        IApnsPayLoadBuilderWithCategoryIdentifier IApnsPayLoadBuilderWithBadge.IsContentAvailable(bool isContentAvailable)
        {
            ApnsPayLoadImplementation.ContentAvailable = isContentAvailable ? 1 : (int?)null;

            return this;
        }

        IPayLoadBuilder<IApnsPayLoad> IApnsPayLoadBuilderWithBadge.CategoryIdentifier(string categoryIdentifier)
        {
            ApnsPayLoadImplementation.Category = categoryIdentifier;

            return this;
        }
        #endregion IApnsPayLoadBuilderWithBadge

        #region IApnsPayLoadBuilderWithSound
        IApnsPayLoadBuilderWithContentAvailable IApnsPayLoadBuilderWithSound.SoundName(string soundName)
        {
            ApnsPayLoadImplementation.Sound = soundName;

            return this;
        }

        IApnsPayLoadBuilderWithCategoryIdentifier IApnsPayLoadBuilderWithSound.IsContentAvailable(bool isContentAvailable)
        {
            ApnsPayLoadImplementation.ContentAvailable = isContentAvailable ? 1 : (int?)null;

            return this;
        }

        IPayLoadBuilder<IApnsPayLoad> IApnsPayLoadBuilderWithSound.CategoryIdentifier(string categoryIdentifier)
        {
            ApnsPayLoadImplementation.Category = categoryIdentifier;

            return this;
        }
        #endregion IApnsPayLoadBuilderWithSound

        #region IApnsPayLoadBuilderWithContentAvailable
        IApnsPayLoadBuilderWithCategoryIdentifier IApnsPayLoadBuilderWithContentAvailable.IsContentAvailable(bool isContentAvailable)
        {
            ApnsPayLoadImplementation.ContentAvailable = isContentAvailable ? 1 : (int?)null;

            return this;
        }

        IPayLoadBuilder<IApnsPayLoad> IApnsPayLoadBuilderWithContentAvailable.CategoryIdentifier(string categoryIdentifier)
        {
            ApnsPayLoadImplementation.Category = categoryIdentifier;

            return this;
        }
        #endregion IApnsPayLoadBuilderWithContentAvailable

        #region IApnsPayLoadBuilderWithCategoryIdentifier
        IPayLoadBuilder<IApnsPayLoad> IApnsPayLoadBuilderWithCategoryIdentifier.CategoryIdentifier(string categoryIdentifier)
        {
            ApnsPayLoadImplementation.Category = categoryIdentifier;

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

            ApnsPayLoadImplementation.InternalCustomData.Add(customDataKey, customDataValue);

            return this;
        }

        public IApnsPayLoad BuildPayLoad()
        {
            return ApnsPayLoadImplementation;
        }

        public async Task<IApnsPayLoad> BuildPayLoadAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Task.Run(() => BuildPayLoad(), cancellationToken);
        }

        public string BuildPayLoadToString(bool indent = false)
        {
            if (ApnsPayLoadImplementation.AlertMessage != null && ApnsPayLoadImplementation.Alert != null)
            {
                throw new ApnsPayloadBuilderException("apnsAlert Message and IAlert from IApnsPayLoad are not null, choose to use one of them");
            }

            try
            {
                var apsJObject = JObject.FromObject(new
                {
                    aps = ApnsPayLoadImplementation,
                });

                if (ApnsPayLoadImplementation.CustomData == null || ApnsPayLoadImplementation.CustomData.Count <= 0)
                    return apsJObject.ToString();

                foreach (var customData in ApnsPayLoadImplementation.CustomData)
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
            return await Task.Run(() => BuildPayLoadToString(indent), cancellationToken);
        }
        #endregion IPayLoadBuilder<IApnsPayLoad>

        #region IDisposable
        public void Dispose()
        {
            ApnsPayLoadImplementation = null;
        }
        #endregion IDisposable
    }
}