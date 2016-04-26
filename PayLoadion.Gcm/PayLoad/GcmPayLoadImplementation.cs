using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PayLoadion.Gcm.PayLoad.GcmNotification;

namespace PayLoadion.Gcm.PayLoad
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class GcmPayLoadImplementation : IGcmPayLoad
    {
        private Dictionary<string, object> _internalCustomData;

        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore)]
        public IGcmNotification Notification
        {
            get { return GcmNotificationImplementation; }
        }

        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyDictionary<string, object> CustomData
        {
            get { return _internalCustomData; }
        }

        internal Dictionary<string, object> InternalCustomData
        {
            get { return _internalCustomData ?? (_internalCustomData = new Dictionary<string, object>()); }
        }

        public GcmNotificationImplementation GcmNotificationImplementation { get; set; }

        internal GcmPayLoadImplementation()
        {
            GcmNotificationImplementation = new GcmNotificationImplementation();
        }

        internal GcmPayLoadImplementation(IGcmPayLoad gcmPayLoad)
        {
            if (gcmPayLoad.CustomData != null)
            {
                _internalCustomData = gcmPayLoad.CustomData.ToDictionary(customDataKvpKey => customDataKvpKey.Key,
                                                                         customDataKvpValue => customDataKvpValue.Value);
            }

            GcmNotificationImplementation = new GcmNotificationImplementation(gcmPayLoad.Notification);
        }

        public void Dispose()
        {
            GcmNotificationImplementation.Dispose();

            GcmNotificationImplementation = null;

            _internalCustomData = null;

            GC.SuppressFinalize(this);
        }
    }
}