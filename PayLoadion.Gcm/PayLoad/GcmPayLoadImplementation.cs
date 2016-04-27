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
        #region Fields
        private Dictionary<string, object> _internalCustomData;
        #endregion Fields

        #region Properties

        #region Private Properties

        #endregion Private Properties

        #region Public Properties
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

        
        #endregion Public Properties

        #region Protected Properties

        #endregion Protected Properties

        #region Internal Properties
        internal Dictionary<string, object> InternalCustomData
        {
            get { return _internalCustomData ?? (_internalCustomData = new Dictionary<string, object>()); }
        }

        internal GcmNotificationImplementation GcmNotificationImplementation { get; set; }
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
        #endregion Internal Constructors

        #endregion Constructors

        #region Methods

        #region Private Methods

        #endregion Private Methods

        #region Public Methods

        #region Implementation of IDisposable

        public void Dispose()
        {
            GcmNotificationImplementation.Dispose();

            GcmNotificationImplementation = null;

            _internalCustomData = null;

            GC.SuppressFinalize(this);
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