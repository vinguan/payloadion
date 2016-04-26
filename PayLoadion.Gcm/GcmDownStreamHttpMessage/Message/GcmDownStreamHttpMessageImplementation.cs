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
        private List<string> _internalRegistrationsIds;

        private GcmPriorityEnum _internalPriority;

        private bool? _priorityWasSet;

        [JsonProperty(PropertyName = "to", NullValueHandling = NullValueHandling.Ignore)]
        public string To { get; set; }

        internal List<string> InternalRegistrationIds
        {
            get { return _internalRegistrationsIds ?? (_internalRegistrationsIds = new List<string>()); }
        }

        [JsonProperty(PropertyName = "registration_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyList<string> RegistrationIds
        {
            get { return _internalRegistrationsIds; }
        }

        [JsonProperty(PropertyName = "collapse_key", NullValueHandling = NullValueHandling.Ignore)]
        public string CollapseKey { get; set; }

        private bool PriorityWasSet {
            get
            {
                if (_priorityWasSet.HasValue)
                    return _priorityWasSet.Value;

                return false;
            }
        }

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

        internal GcmPayLoadImplementation GcmPayLoadImplementation { get; set; }

        public IGcmPayLoad GcmPayLoad
        {
            get { return GcmPayLoadImplementation; }
        }

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

        #region Implementation of IDisposable

        public void Dispose()
        {
            this._internalRegistrationsIds = null;

            GcmPayLoadImplementation.Dispose();

            GcmPayLoadImplementation = null;

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}