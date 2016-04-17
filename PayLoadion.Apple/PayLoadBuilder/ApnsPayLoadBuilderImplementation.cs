using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using PayLoadion.Apple.Exceptions;
using PayLoadion.Apple.Exceptions.Alert;
using PayLoadion.Apple.PayLoad;
using PayLoadion.Apple.PayLoad.Alert;
using PayLoadion.Apple.PayLoad.Alert.Builder;

namespace PayLoadion.Apple.PayLoadBuilder
{
    internal class ApnsPayLoadBuilderImplementation : IApnsPayLoadBuilder
    {
        private ApnsPayLoadImplementation _apnsPayLoadImplementation;

        public IApnsPayLoad PayLoad
        {
            get { return _apnsPayLoadImplementation; }
        }

        public ApnsPayLoadBuilderImplementation()
        {
            _apnsPayLoadImplementation = new ApnsPayLoadImplementation();
        }

        public ApnsPayLoadBuilderImplementation(IApnsPayLoad apnsPayLoad)
        {
            _apnsPayLoadImplementation = new ApnsPayLoadImplementation(apnsPayLoad);
        }

        public IApnsPayLoadBuilder AlertMessage(string alertMessage)
        {
            _apnsPayLoadImplementation.AlertMessage = alertMessage;

            return this;
        }

        public IApnsPayLoadBuilder Alert(IAlert alert)
        {
            _apnsPayLoadImplementation.Alert = alert;

            return this;
        }

        public IApnsPayLoadBuilder SoundName(string soundName)
        {
            _apnsPayLoadImplementation.Sound = soundName;

            return this;
        }

        public IApnsPayLoadBuilder Badge(int badge)
        {
            _apnsPayLoadImplementation.Badge = badge;

            return this;
        }

        public IApnsPayLoadBuilder IsContentAvailable(bool isContentAvailable)
        {
            _apnsPayLoadImplementation.ContentAvailable = isContentAvailable ? 1 : (int?)null;

            return this;
        }

        public IApnsPayLoadBuilder CategoryName(string categoryName)
        {
            _apnsPayLoadImplementation.Category = categoryName;

            return this;
        }

        public IApnsPayLoadBuilder AddCustomData(string customDataKey, object customDataValue)
        {
            if (string.IsNullOrEmpty(customDataKey))
                throw new ArgumentNullException(nameof(customDataKey));

            if (customDataValue == null)
                throw new ArgumentNullException(nameof(customDataValue));

            _apnsPayLoadImplementation.InternalCustomData.Add(customDataKey, customDataValue);

            return this;
        }

        public static IApnsPayLoadBuilder Create()
        {
            return new ApnsPayLoadBuilderImplementation();
        }

        public static IApnsPayLoadBuilder Create(IApnsPayLoad apnsPayLoad)
        {
            return new ApnsPayLoadBuilderImplementation(apnsPayLoad);
        }

        public string Build()
        {
            if (_apnsPayLoadImplementation.AlertMessage != null && _apnsPayLoadImplementation.Alert != null)
            {
                throw new ApnsPayloadBuilderException("Alert Message and IAlert from IApnsPayLoad are not null, choose to use one of them");
            }

            try
            {

                if (_apnsPayLoadImplementation.CustomData != null && _apnsPayLoadImplementation.CustomData.Count > 0)
                {
                    var apnsJsonObject = JObject.FromObject(new
                    {
                        apns = _apnsPayLoadImplementation,
                    });

                    foreach (var customData in _apnsPayLoadImplementation.CustomData)
                    {
                        var valueType = customData.Value.GetType();

                        if (customData.Value is string || valueType.GetTypeInfo().IsValueType)
                        {
                            apnsJsonObject.Add(new JProperty(customData.Key, customData.Value));
                        }
                        else
                        {
                            apnsJsonObject.Add(new JProperty(customData.Key, JObject.FromObject(customData.Value)));
                        }
                    }

                    return apnsJsonObject.ToString();
                }
                else
                {
                    var apnsJsonObject = JObject.FromObject(new
                    {
                        apns = _apnsPayLoadImplementation,
                    });

                    return apnsJsonObject.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new ApnsPayloadBuilderException("An error occured while building ApnsPayload, Please check InnerException", ex);
            }             
        }

        public async Task<string> BuildAsync()
        {
            return await Task.Run(() => Build());
        }

        public void Dispose()
        {
            _apnsPayLoadImplementation = null;
        }
    }
}