using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PayLoadion.Apple.PayLoad.Alert;

namespace PayLoadion.Apple.PayLoad
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class ApnsPayLoadImplementation : IApnsPayLoad
    {
        private Dictionary<string, object> _internalCustomData;

        [JsonProperty(PropertyName = "alert", NullValueHandling = NullValueHandling.Ignore)]
        public object AlertValue
        {
            get
            {
                if(Alert != null)
                    return Alert;

                return AlertMessage;
            }
        }

        public IApnsAlert Alert
        {
            get { return AlertImplementation; }
        }

        internal ApnsAlertImplementation AlertImplementation { get; set; }

        public string AlertMessage { get; set; }

        [JsonProperty(PropertyName = "badge", NullValueHandling = NullValueHandling.Ignore)]
        public int? Badge { get; set; }

        [JsonProperty(PropertyName = "sound", NullValueHandling = NullValueHandling.Ignore)]
        public string Sound { get; set; }

        [JsonProperty(PropertyName = "content_available", NullValueHandling = NullValueHandling.Ignore)]
        public int? ContentAvailable { get; set; }

        [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        internal Dictionary<string, object> InternalCustomData
        {
            get { return _internalCustomData ?? (_internalCustomData = new Dictionary<string, object>()); }
        }

        public IReadOnlyDictionary<string, object> CustomData
        {
            get { return _internalCustomData; }
        }

        internal ApnsPayLoadImplementation()
        {
            AlertMessage = null;
        }

        internal ApnsPayLoadImplementation(IApnsPayLoad apnsPayLoad)
        {
            AlertImplementation = new ApnsAlertImplementation(apnsPayLoad.Alert);

            AlertMessage = apnsPayLoad.AlertMessage;

            Badge = apnsPayLoad.Badge;

            Sound = apnsPayLoad.Sound;

            ContentAvailable = apnsPayLoad.ContentAvailable;

            Category = apnsPayLoad.Category;

            if (apnsPayLoad.CustomData != null)
            {
                _internalCustomData = apnsPayLoad.CustomData.ToDictionary(customDataKvpKey => customDataKvpKey.Key,
                                                                         customDataKvpValue => customDataKvpValue.Value);
            }
        }
    }
}
