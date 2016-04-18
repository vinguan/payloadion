using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayLoadion.Google.Exceptions;
using PayLoadion.Google.PayLoad;
using PayLoadion.Google.PayLoad.Enums;
using PayLoadion.Google.PayLoad.Notification;
using PayLoadion.PayLoadBuilder;

namespace PayLoadion.Google.PayLoadBuilder
{
    internal class GcmPayLoadBuilderImplementation : IGcmPayLoadBuilder
    {
        private GcmPayLoadImplementation _gcmPayLoadImplementation;

        public IGcmPayLoad PayLoad
        {
            get { return _gcmPayLoadImplementation; }
        }

        internal GcmPayLoadBuilderImplementation()
        {
            _gcmPayLoadImplementation = new GcmPayLoadImplementation();
        }

        internal GcmPayLoadBuilderImplementation(IGcmPayLoad apnsPayLoad)
        {
            _gcmPayLoadImplementation = new GcmPayLoadImplementation(apnsPayLoad);
        }

        public IGcmPayLoadBuilder ToDevice(string stringDeviceId)
        {
            _gcmPayLoadImplementation.To = stringDeviceId;

            return this;
        }

        public IGcmPayLoadBuilder AddDeviceId(string stringDeviceId)
        {
            _gcmPayLoadImplementation.InternalRegistrationIds.Add(stringDeviceId);

            return this;
        }

        public IGcmPayLoadBuilder CollapseKey(string collapseKey)
        {
            _gcmPayLoadImplementation.CollapseKey = collapseKey;

            return this;
        }

        public IGcmPayLoadBuilder Priority(GcmPriorityEnum priority)
        {
            _gcmPayLoadImplementation.Priority = priority;

            return this;
        }

        public IGcmPayLoadBuilder IsContentAvailable(bool isContentAvailable)
        {
            _gcmPayLoadImplementation.ContentAvailable = isContentAvailable;

            return this;
        }

        public IGcmPayLoadBuilder DelayWhileIdle(bool delayWhileIdle)
        {
            _gcmPayLoadImplementation.DelayWhileIdle = delayWhileIdle;

            return this;
        }

        public IGcmPayLoadBuilder TimeToLiveInSeconds(int seconds)
        {
            _gcmPayLoadImplementation.TimeToLive = seconds;

            return this;
        }

        public IGcmPayLoadBuilder TimeToLiveUntil(DateTimeOffset limitDate)
        {
            _gcmPayLoadImplementation.TimeToLive = DateTimeOffset.UtcNow.Subtract(limitDate).Seconds;

            return this;
        }

        public IGcmPayLoadBuilder RestrictedPackageName(string restrictedPackageName)
        {
            _gcmPayLoadImplementation.RestrictedPackageName = restrictedPackageName;

            return this;
        }

        public IGcmPayLoadBuilder IsDryRun(bool isDryRun)
        {
            _gcmPayLoadImplementation.DryRun = isDryRun;

            return this;
        }

        public IPayLoadBuilder<IGcmPayLoad> AddCustomData(string customDataKey, object customDataValue)
        {
            if (string.IsNullOrEmpty(customDataKey))
                throw new ArgumentNullException(nameof(customDataKey));

            if (customDataValue == null)
                throw new ArgumentNullException(nameof(customDataValue));

            _gcmPayLoadImplementation.InternalCustomData.Add(customDataKey, customDataValue);

            return this;
        }

        public IGcmPayLoadBuilder Notification(IGcmNotification gcmNotification)
        {
            _gcmPayLoadImplementation.Notification = gcmNotification;

            return this;
        }

        public string Build()
        {
            try
            {
                if (_gcmPayLoadImplementation.RegistrationIds != null && _gcmPayLoadImplementation.RegistrationIds.Count > 0)
                    _gcmPayLoadImplementation.To = null;

                return JsonConvert.SerializeObject(_gcmPayLoadImplementation);
            }
            catch (Exception ex)
            {
                throw new GcmPayLoadBuilderException("An unexpected error ocurred while building GcmPayLoad, please check inner exception", ex);
            }
        }

        public async Task<string> BuildAsync()
        {
            return await Task.Run(() => Build());
        }

        public void Dispose()
        {
            _gcmPayLoadImplementation = null;
        }
    }
}