using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PayLoadion.Apns.PayLoad.Alert;

namespace PayLoadion.Apns.PayLoad
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class ApnsPayLoadImplementation : IApnsPayLoad
    {
        #region Fields
        private Dictionary<string, object> _internalCustomData;
        #endregion Fields

        #region Properties

        #region Private Properties

        #endregion Private Properties

        #region Public Properties
        [JsonProperty(PropertyName = "alert", NullValueHandling = NullValueHandling.Ignore)]
        public object AlertValue
        {
            get
            {
                if (Alert != null)
                    return Alert;

                return AlertMessage;
            }
        }

        #region Implementation of IApnsPayLoad
        public IApnsAlert Alert
        {
            get { return AlertImplementation; }
        }

        public string AlertMessage { get; set; }

        [JsonProperty(PropertyName = "badge", NullValueHandling = NullValueHandling.Ignore)]
        public int? Badge { get; set; }

        [JsonProperty(PropertyName = "sound", NullValueHandling = NullValueHandling.Ignore)]
        public string Sound { get; set; }

        [JsonProperty(PropertyName = "content_available", NullValueHandling = NullValueHandling.Ignore)]
        public int? ContentAvailable { get; set; }

        [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        public IReadOnlyDictionary<string, object> CustomData
        {
            get { return _internalCustomData; }
        }
        #endregion Implementation of IApnsPayLoad

        #endregion Public Properties

        #region Protected Properties

        #endregion Protected Properties

        #region Internal Properties
        internal ApnsAlertImplementation AlertImplementation { get; set; }

        internal Dictionary<string, object> InternalCustomData
        {
            get { return _internalCustomData ?? (_internalCustomData = new Dictionary<string, object>()); }
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
        #endregion Internal Constructors

        #endregion Constructors

        #region Methods

        #region Private Methods

        #endregion Private Methods

        #region Public Methods
        #region Implementation of IDisposable
        public void Dispose()
        {
            _internalCustomData = null;

            AlertImplementation.Dispose();

            AlertImplementation = null;

            GC.SuppressFinalize(this);
        }
        #endregion Implementation of IDisposable
        #endregion Public Methods

        #region Protected Methods

        #endregion Protected Methods

        #region Internal Methods

        #endregion Internal Methods

        #endregion Methods
    }
}
