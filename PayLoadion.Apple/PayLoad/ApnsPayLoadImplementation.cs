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

        public IAlert Alert { get; set; }

        public string AlertMessage { get; set; }

        [JsonProperty(PropertyName = "badge", NullValueHandling = NullValueHandling.Ignore)]
        public int? Badge { get; set; }

        [JsonProperty(PropertyName = "sound", NullValueHandling = NullValueHandling.Ignore)]
        public string Sound { get; set; }

        [JsonProperty(PropertyName = "content_available", NullValueHandling = NullValueHandling.Ignore)]
        public int? ContentAvailable { get; set; }

        [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        public Dictionary<string, object> InternalCustomData
        {
            get { return _internalCustomData ?? (_internalCustomData = new Dictionary<string, object>()); }
        }

        public IReadOnlyDictionary<string, object> CustomData
        {
            get { return _internalCustomData; }
        }

        public ApnsPayLoadImplementation()
        {

        }

        public ApnsPayLoadImplementation(IApnsPayLoad apnsPayLoad)
        {
            Alert = apnsPayLoad.Alert;

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
