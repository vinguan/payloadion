using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayLoadion.Apple.PayLoad.Alert
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class AlertImplementation : IAlert
    {
        private List<string> _internalTitleLocArgs;

        private List<string> _internalLocArgs;

        [JsonProperty(PropertyName = "title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "title-loc-key", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleLocKey { get; set; }

        public List<string> InternalTitleLocArgs
        {
            get { return _internalTitleLocArgs ?? (_internalTitleLocArgs = new List<string>()); }
        }

        [JsonProperty(PropertyName = "title-loc-args", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<string> TitleLocArgs
        {
            get { return _internalTitleLocArgs; }
        }

        [JsonProperty(PropertyName = "action-loc-key", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionLocKey { get; set; }

        [JsonProperty(PropertyName = "loc-key", NullValueHandling = NullValueHandling.Ignore)]
        public string LocKey { get; set; }

        public List<string> InternalLocArgs
        {
            get { return _internalLocArgs ?? (_internalLocArgs = new List<string>()); }
        }

        [JsonProperty(PropertyName = "loc-args", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<string> LocArgs
        {
            get { return _internalLocArgs; }
        }

        [JsonProperty(PropertyName = "launch-image", NullValueHandling = NullValueHandling.Ignore)]
        public string LaunchImage { get; set; }

        public AlertImplementation()
        {
              
        }

        public AlertImplementation(IAlert alert)
        {
            Title = alert.Title;

            Body = alert.Body;

            TitleLocKey = alert.TitleLocKey;

            _internalTitleLocArgs = new List<string>(alert.TitleLocArgs);

            ActionLocKey = alert.ActionLocKey;

            LocKey = alert.LocKey;

            _internalLocArgs = new List<string>(alert.LocArgs);

            LaunchImage = alert.LaunchImage;
        }
    }
}
