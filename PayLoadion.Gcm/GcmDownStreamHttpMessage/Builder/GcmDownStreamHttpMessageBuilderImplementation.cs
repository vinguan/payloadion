using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayLoadion.Gcm.Exceptions;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Message;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Message.Enums;
using PayLoadion.Gcm.PayLoad;
using PayLoadion.Gcm.PayLoad.GcmNotification;

namespace PayLoadion.Gcm.GcmDownStreamHttpMessage.Builder
{
    internal class GcmDownStreamHttpMessageBuilderImplementation : 
        IGcmDownStreamHttpMessageBuilder,
        IGcmDownStreamHttpMessageBuilderTargets,
        IGcmDownStreamHttpMessageBuilderOptions, 
        IGcmDownStreamHttpMessagePayLoadBuilder,
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationTitle,
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationIcon,
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions,
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs,
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs
    {
        private GcmDownStreamHttpMessageImplementation _gcmDownStreamHttpMessageImplementation;

        internal GcmDownStreamHttpMessageBuilderImplementation()
        {
            _gcmDownStreamHttpMessageImplementation = new GcmDownStreamHttpMessageImplementation();
        }

        internal GcmDownStreamHttpMessageBuilderImplementation(IGcmDownStreamHttpMessage gcmDownStreamHttpMessage)
        {
            _gcmDownStreamHttpMessageImplementation = new GcmDownStreamHttpMessageImplementation(gcmDownStreamHttpMessage);
        }

        #region IGcmDownStreamHttpMessageBuilderTargets
        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderTargets.ToDevice(string deviceRegistrationId)
        {
            _gcmDownStreamHttpMessageImplementation.To = deviceRegistrationId;

            return this;
        }

        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderTargets.AddDeviceId(string deviceRegistrationId)
        {
            _gcmDownStreamHttpMessageImplementation.InternalRegistrationIds.Add(deviceRegistrationId);

            return this;
        }

        #endregion IGcmDownStreamHttpMessageBuilderTargets

        #region IGcmDownStreamHttpMessageBuilderOptions

        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderOptions.AddDeviceId(string deviceRegistrationId)
        {
            _gcmDownStreamHttpMessageImplementation.InternalRegistrationIds.Add(deviceRegistrationId);

            return this;
        }

        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderOptions.CollapseKey(string collapseKey)
        {
            _gcmDownStreamHttpMessageImplementation.CollapseKey = collapseKey;

            return this;
        }

        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderOptions.Priority(GcmPriorityEnum priority)
        {
            _gcmDownStreamHttpMessageImplementation.Priority = priority;

            return this;
        }

        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderOptions.IsContentAvailable(bool isContentAvailable)
        {
            _gcmDownStreamHttpMessageImplementation.ContentAvailable = isContentAvailable;

            return this;
        }

        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderOptions.DelayWhileIdle(bool delayWhileIdle)
        {
            _gcmDownStreamHttpMessageImplementation.DelayWhileIdle = delayWhileIdle;

            return this;
        }

        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderOptions.TimeToLiveInSeconds(int seconds)
        {
            _gcmDownStreamHttpMessageImplementation.TimeToLive = seconds;

            return this;
        }

        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderOptions.TimeToLiveUntil(DateTimeOffset limitDate)
        {
            _gcmDownStreamHttpMessageImplementation.TimeToLive = Convert.ToInt32(limitDate.Subtract(DateTimeOffset.UtcNow).TotalSeconds);

            return this;
        }

        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderOptions.RestrictedPackageName(string restrictedPackageName)
        {
            _gcmDownStreamHttpMessageImplementation.RestrictedPackageName = restrictedPackageName;

            return this;
        }

        IGcmDownStreamHttpMessageBuilderOptions IGcmDownStreamHttpMessageBuilderOptions.IsDryRun(bool isDryRun)
        {
            _gcmDownStreamHttpMessageImplementation.DryRun = isDryRun;

            return this;
        }

        IGcmDownStreamHttpMessagePayLoadBuilder IGcmDownStreamHttpMessageBuilderOptions.PayLoad()
        {
           _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation = new GcmPayLoadImplementation();

            return this;
        }

        #endregion IGcmDownStreamHttpMessageBuilderOptions

        #region IGcmDownStreamHttpMessagePayLoadBuilder

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationTitle IGcmDownStreamHttpMessagePayLoadBuilder.Notification()
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation = new GcmNotificationImplementation();

            return this;
        }

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions.TitleLocalizableKey(
            string titleLocalizableKey)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.TitleLocKey = titleLocalizableKey;

            return this;
        }

        IGcmDownStreamHttpMessageBuilder IGcmDownStreamHttpMessagePayLoadBuilder.AddCustomData(string customDataKey, object customDataValue)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.InternalCustomData.Add(customDataKey, customDataValue);

            return this;
        }

        #endregion IGcmDownStreamHttpMessagePayLoadBuilder

        #region IGcmDownStreamHttpMessagePayLoadBuilderNotificationTitle 
        IGcmDownStreamHttpMessagePayLoadBuilderNotificationIcon IGcmDownStreamHttpMessagePayLoadBuilderNotificationTitle.Title(string title)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.Title = title;

            return this;
        }
        #endregion IGcmDownStreamHttpMessagePayLoadBuilderNotificationTitle 

        #region IGcmDownStreamHttpMessagePayLoadBuilderNotificationIcon

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions IGcmDownStreamHttpMessagePayLoadBuilderNotificationIcon.Icon(string icon)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.Icon = icon;

            return this;
        }

        #endregion

        #region IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions.Body(string body)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.Body = body;
            return this;
        }

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions.Sound(string soundFileName)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.Sound = soundFileName;
            return this;
        }

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions.BadgeCount(string badgeCount)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.Badge = badgeCount;
            return this;
        }

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions.Tag(string tag)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.Tag = tag;
            return this;
        }

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions.Color(string color)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.Color = color;
            return this;
        }

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions.ClickAction(string clickAction)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.Color = clickAction;

            return this;
        }

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions.BodyLocalizableKey(
            string bodyLocalizableKey)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.BodyLocKey = bodyLocalizableKey;

            return this;
        }

        IGcmDownStreamHttpMessageBuilder IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptions.
            AddCustomData(string customDataKey, object customDataValue)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.InternalCustomData.Add(customDataKey, customDataValue);

            return this;
        }

        #endregion

        #region IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs.AddBodyLocalizableArgument(
            string bodyLocArgument)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.InternalBodyLocArgs.Add(bodyLocArgument);

            return this;
        }

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs.TitleLocalizableKey(
            string titleLocalizableKey)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.TitleLocKey = titleLocalizableKey;

            return this;
        }

        IGcmDownStreamHttpMessageBuilder IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsBodyLocalizableArgs.AddCustomData(string customDataKey, object customDataValue)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.InternalCustomData.Add(customDataKey, customDataValue);

            return this;
        }

        #endregion

        #region IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs 

        IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs.AddTitleLocalizableArgument(string titleLocArgument)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.GcmNotificationImplementation.InternalTitleLocArgs.Add(titleLocArgument);

            return this;
        }

        IGcmDownStreamHttpMessageBuilder IGcmDownStreamHttpMessagePayLoadBuilderNotificationOptionsTitleLocalizableArgs.AddCustomData(string customDataKey, object customDataValue)
        {
            _gcmDownStreamHttpMessageImplementation.GcmPayLoadImplementation.InternalCustomData.Add(customDataKey, customDataValue);

            return this;
        }

        #endregion

        public IGcmDownStreamHttpMessage BuildGcmDownStreamHttpMessage()
        {
            return _gcmDownStreamHttpMessageImplementation;
        }

        public async Task<IGcmDownStreamHttpMessage> BuildGcmDownStreamHttpMessageAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                return await Task.Run(() => BuildGcmDownStreamHttpMessage(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new GcmDownStreamHttpMessageBuilderException("An error ocurred while building the GCM Downstream Http Message, please check inner exception", ex);
            }
        }

        public string BuildGcmDownStreamHttpMessageToJson(bool indent = false)
        {

            try
            {
                var downStreamJsonObject = JObject.FromObject(_gcmDownStreamHttpMessageImplementation);

                if (_gcmDownStreamHttpMessageImplementation.GcmPayLoad.Notification != null)
                {
                    downStreamJsonObject.Add("notification", JObject.FromObject(_gcmDownStreamHttpMessageImplementation.GcmPayLoad.Notification));
                }

                if (_gcmDownStreamHttpMessageImplementation.GcmPayLoad.CustomData != null && _gcmDownStreamHttpMessageImplementation.GcmPayLoad.CustomData.Count > 0)
                {
                    downStreamJsonObject.Add("data", JObject.FromObject(_gcmDownStreamHttpMessageImplementation.GcmPayLoad.CustomData));
                }

                return downStreamJsonObject.ToString(indent ? Formatting.Indented : Formatting.None);
            }
            catch (Exception ex)
            {
                throw new GcmDownStreamHttpMessageBuilderException("An error ocurred while building the GCM Downstream Http Message, please check inner exception", ex);
            }
        }

        public async Task<string> BuildGcmDownStreamHttpMessageToJsonAsync(bool indent = false,CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                return await Task.Run(() => BuildGcmDownStreamHttpMessageToJson(indent), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new GcmDownStreamHttpMessageBuilderException("An error ocurred while building the GCM Downstream Http Message, please check inner exception", ex);
            }
        }

        public void Dispose()
        {
            _gcmDownStreamHttpMessageImplementation.Dispose();

            _gcmDownStreamHttpMessageImplementation = null;

            GC.SuppressFinalize(this);
        }

    }
}