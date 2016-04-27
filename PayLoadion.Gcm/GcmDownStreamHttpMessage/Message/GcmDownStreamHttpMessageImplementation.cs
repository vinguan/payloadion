using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Message.Enums;
using PayLoadion.Gcm.PayLoad;

namespace PayLoadion.Gcm.GcmDownStreamHttpMessage.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class GcmDownStreamHttpMessageImplementation : IGcmDownStreamHttpMessage
    {
        #region Fields
        private List<string> _internalRegistrationsIds;

        private GcmPriorityEnum _internalPriority;

        private bool? _priorityWasSet;
        #endregion Fields

        #region Properties

        #region Private Properties
        private bool PriorityWasSet
        {
            get
            {
                if (_priorityWasSet.HasValue)
                    return _priorityWasSet.Value;

                return false;
            }
        }
        #endregion Private Properties

        #region Public Properties
        [JsonProperty(PropertyName = "to", NullValueHandling = NullValueHandling.Ignore)]
        public string To { get; set; }

        [JsonProperty(PropertyName = "registration_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<string> RegistrationIds
        {
            get { return _internalRegistrationsIds; }
        }

        [JsonProperty(PropertyName = "collapse_key", NullValueHandling = NullValueHandling.Ignore)]
        public string CollapseKey { get; set; }

        [JsonProperty(PropertyName = "priority", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public object PriorityValue
        {
            get
            {
                if (PriorityWasSet)
                    return Priority;

                return null;
            }
        }

        public GcmPriorityEnum Priority
        {
            get { return _internalPriority; }
            set
            {
                _priorityWasSet = true;

                _internalPriority = value;
            }
        }

        [JsonProperty(PropertyName = "content_available", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ContentAvailable { get; set; }

        [JsonProperty(PropertyName = "delay_while_idle", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DelayWhileIdle { get; set; }

        [JsonProperty(PropertyName = "time_to_live", NullValueHandling = NullValueHandling.Ignore)]
        public int? TimeToLive { get; set; }

        [JsonProperty(PropertyName = "restricted_package_name", NullValueHandling = NullValueHandling.Ignore)]
        public string RestrictedPackageName { get; set; }

        [JsonProperty(PropertyName = "dry_run", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DryRun { get; set; }

        public IGcmPayLoad GcmPayLoad
        {
            get { return GcmPayLoadImplementation; }
        }
        #endregion Public Properties

        #region Protected Properties

        #endregion Protected Properties

        #region Internal Properties
        internal List<string> InternalRegistrationIds
        {
            get { return _internalRegistrationsIds ?? (_internalRegistrationsIds = new List<string>()); }
        }

        internal GcmPayLoadImplementation GcmPayLoadImplementation { get; set; }
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
        internal GcmDownStreamHttpMessageImplementation()
        {

        }

        internal GcmDownStreamHttpMessageImplementation(IGcmDownStreamHttpMessage gcmDownStreamHttpMessage)
        {
            _internalRegistrationsIds = new List<string>(gcmDownStreamHttpMessage.RegistrationIds);

            To = gcmDownStreamHttpMessage.To;

            CollapseKey = gcmDownStreamHttpMessage.CollapseKey;

            Priority = gcmDownStreamHttpMessage.Priority;

            ContentAvailable = gcmDownStreamHttpMessage.ContentAvailable;

            DelayWhileIdle = gcmDownStreamHttpMessage.DelayWhileIdle;

            TimeToLive = gcmDownStreamHttpMessage.TimeToLive;

            RestrictedPackageName = gcmDownStreamHttpMessage.RestrictedPackageName;

            DryRun = gcmDownStreamHttpMessage.DryRun;

            GcmPayLoadImplementation = new GcmPayLoadImplementation(gcmDownStreamHttpMessage.GcmPayLoad);

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
            this._internalRegistrationsIds = null;

            GcmPayLoadImplementation.Dispose();

            GcmPayLoadImplementation = null;

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