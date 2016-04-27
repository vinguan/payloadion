using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayLoadion.Apns.PayLoad.Alert
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class ApnsAlertImplementation : IApnsAlert
    {
        #region Fields
        private List<string> _internalTitleLocArgs;

        private List<string> _internalLocArgs;
        #endregion Fields

        #region Properties

        #region Public Properties

        #region Implementation of IApnsAlert
        [JsonProperty(PropertyName = "title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "title-loc-key", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleLocKey { get; set; }

        [JsonProperty(PropertyName = "title-loc-args", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<string> TitleLocArgs
        {
            get { return _internalTitleLocArgs; }
        }

        [JsonProperty(PropertyName = "action-loc-key", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionLocKey { get; set; }

        [JsonProperty(PropertyName = "loc-key", NullValueHandling = NullValueHandling.Ignore)]
        public string LocKey { get; set; }

        [JsonProperty(PropertyName = "loc-args", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<string> LocArgs
        {
            get { return _internalLocArgs; }
        }

        [JsonProperty(PropertyName = "launch-image", NullValueHandling = NullValueHandling.Ignore)]
        public string LaunchImage { get; set; }
        #endregion Implementation of  IApnsAlert

        #endregion Public Properties

        #region Internal Properties
        internal List<string> InternalTitleLocArgs
        {
            get { return _internalTitleLocArgs ?? (_internalTitleLocArgs = new List<string>()); }
        }

        internal List<string> InternalLocArgs
        {
            get { return _internalLocArgs ?? (_internalLocArgs = new List<string>()); }
        }
        #endregion Internal Properties

        #endregion Properties

        #region Constructors

        #region Internal Constructors

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

        #endregion Public Constructors

        #endregion Constructors

        #region Methods

        #region Public Methods

        #region Implementation of IDisposable
        public void Dispose()
        {
            _internalTitleLocArgs = null;

            _internalLocArgs = null;

            GC.SuppressFinalize(this);
        }
        #endregion Implementation of IDisposable

        #endregion Public Methods

        #endregion Methods
    }
}
