using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayLoadion.Google.PayLoad.Notification
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class GcmNotificationImplementation : IGcmNotification
    {
        private List<string> _internalBodyLocArgs;

        private List<string> _internalTitleLocArgs;

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "sound", NullValueHandling = NullValueHandling.Ignore)]
        public string Sound { get; set; }

        [JsonProperty(PropertyName = "badge", NullValueHandling = NullValueHandling.Ignore)]
        public string Badge { get; set; }

        [JsonProperty(PropertyName = "tag", NullValueHandling = NullValueHandling.Ignore)]
        public string Tag { get; set; }

        [JsonProperty(PropertyName = "color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "click_action", NullValueHandling = NullValueHandling.Ignore)]
        public string ClickAction { get; set; }

        [JsonProperty(PropertyName = "body_loc_key", NullValueHandling = NullValueHandling.Ignore)]
        public string BodyLocKey { get; set; }

        internal List<string> InternalBodyLocArgs
        {
            get { return _internalBodyLocArgs ?? (_internalBodyLocArgs = new List<string>()); }
        }

        [JsonProperty(PropertyName = "body_loc_args", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<string> BodyLocArgs
        {
            get { return _internalBodyLocArgs; }
        }

        [JsonProperty(PropertyName = "title_loc_key", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleLocKey { get; set; }

        internal List<string> InternalTitleLocArgs
        {
            get { return _internalTitleLocArgs ?? (_internalTitleLocArgs = new List<string>()); }
        }

        [JsonProperty(PropertyName = "title_loc_args", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<string> TitleLocArgs
        {
            get { return _internalTitleLocArgs; }
        }

        internal GcmNotificationImplementation()
        {
                
        }

        internal GcmNotificationImplementation(IGcmNotification gcmNotification)
        {
            Title = gcmNotification.Title;

            Body = gcmNotification.Body;

            Icon = gcmNotification.Icon;

            Sound = gcmNotification.Sound;

            Badge = gcmNotification.Badge;

            Tag = gcmNotification.Tag;

            Color = gcmNotification.Color;

            ClickAction = gcmNotification.ClickAction;

            BodyLocKey = gcmNotification.BodyLocKey;

            _internalTitleLocArgs = new List<string>(gcmNotification.BodyLocArgs);

            TitleLocKey = gcmNotification.TitleLocKey;

            _internalTitleLocArgs = new List<string>(gcmNotification.TitleLocArgs);
        }
    }
}