using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayLoadion.Apns.PayLoad.Alert
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class ApnsAlertImplementation : IApnsAlert
    {
        private List<string> _internalTitleLocArgs;

        private List<string> _internalLocArgs;

        [JsonProperty(PropertyName = "title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "title-loc-key", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleLocKey { get; set; }

        internal List<string> InternalTitleLocArgs
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

        internal List<string> InternalLocArgs
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

        internal ApnsAlertImplementation()
        {
              
        }

        internal ApnsAlertImplementation(IApnsAlert apnsAlert)
        {
            Title = apnsAlert.Title;

            Body = apnsAlert.Body;

            TitleLocKey = apnsAlert.TitleLocKey;

            _internalTitleLocArgs = new List<string>(apnsAlert.TitleLocArgs);

            ActionLocKey = apnsAlert.ActionLocKey;

            LocKey = apnsAlert.LocKey;

            _internalLocArgs = new List<string>(apnsAlert.LocArgs);

            LaunchImage = apnsAlert.LaunchImage;
        }

        public void Dispose()
        {
            _internalTitleLocArgs = null;

            _internalLocArgs = null;

            GC.SuppressFinalize(this);
        }
    }
}
