using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayLoadion.Gcm.PayLoad.GcmNotification
{
    internal class GcmNotificationImplementation : IGcmNotification
    {
        #region Fields
        private List<string> _internalBodyLocArgs;

        private List<string> _internalTitleLocArgs;
        #endregion Fields

        #region Properties

        #region Private Properties

        #endregion Private Properties

        #region Public Properties

        #region IGcmNotification
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

        [JsonProperty(PropertyName = "body_loc_args", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<string> BodyLocArgs
        {
            get { return _internalBodyLocArgs; }
        }

        [JsonProperty(PropertyName = "title_loc_key", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleLocKey { get; set; }

        [JsonProperty(PropertyName = "title_loc_args", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<string> TitleLocArgs
        {
            get { return _internalTitleLocArgs; }
        }
        #endregion
        #endregion Public Properties

        #region Protected Properties

        #endregion Protected Properties

        #region Internal Properties
        internal List<string> InternalBodyLocArgs
        {
            get { return _internalBodyLocArgs ?? (_internalBodyLocArgs = new List<string>()); }
        }

        internal List<string> InternalTitleLocArgs
        {
            get { return _internalTitleLocArgs ?? (_internalTitleLocArgs = new List<string>()); }
        }
        #endregion Internal Properties

        #endregion Properties

        #region Constructors

        #region Private Constructors

        #endregion Private Constructors

        #region Public Constructors

        #endregion Public Constructors

        #region Protected Constructors

        #endregion Protected Constructors

        #region Internal Constructors
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

            _internalBodyLocArgs = new List<string>(gcmNotification.BodyLocArgs);

            TitleLocKey = gcmNotification.TitleLocKey;

            _internalTitleLocArgs = new List<string>(gcmNotification.TitleLocArgs);
        }
        #endregion Internal Constructors

        #endregion Constructors

        #region Methods

        #region Private Methods

        #endregion Private Methods

        #region Public Methods
        #region Implementation of IDisposable

        public void Dispose()
        {
            _internalBodyLocArgs = null;

            _internalBodyLocArgs = null;
        }

        #endregion
        #endregion Public Methods

        #region Protected Methods

        #endregion Protected Methods

        #region Internal Methods

        #endregion Internal Methods

        #endregion Methods
    }
}