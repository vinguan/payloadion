using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PayLoadion.Google.GcmDownStreamHttpJsonMessage.Message.Enums;
using PayLoadion.Google.PayLoad;

namespace PayLoadion.Google.GcmDownStreamHttpJsonMessage.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class GcmDownStreamHttpJsonMessageImplementation : IGcmDownStreamHttpJsonMessage
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

        internal GcmDownStreamHttpJsonMessageImplementation()
        {

        }

        internal GcmDownStreamHttpJsonMessageImplementation(IGcmDownStreamHttpJsonMessage gcmDownStreamHttpJsonMessage)
        {
            _internalRegistrationsIds = new List<string>(gcmDownStreamHttpJsonMessage.RegistrationIds);

            To = gcmDownStreamHttpJsonMessage.To;

            CollapseKey = gcmDownStreamHttpJsonMessage.CollapseKey;

            Priority = gcmDownStreamHttpJsonMessage.Priority;

            ContentAvailable = gcmDownStreamHttpJsonMessage.ContentAvailable;

            DelayWhileIdle = gcmDownStreamHttpJsonMessage.DelayWhileIdle;

            TimeToLive = gcmDownStreamHttpJsonMessage.TimeToLive;

            RestrictedPackageName = gcmDownStreamHttpJsonMessage.RestrictedPackageName;

            DryRun = gcmDownStreamHttpJsonMessage.DryRun;

            GcmPayLoadImplementation = new GcmPayLoadImplementation(gcmDownStreamHttpJsonMessage.GcmPayLoad);

        }
    }
}