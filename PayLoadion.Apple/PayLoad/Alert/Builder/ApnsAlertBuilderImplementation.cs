using System;
using System.Threading.Tasks;
using PayLoadion.Apple.Exceptions.Alert;

namespace PayLoadion.Apple.PayLoad.Alert.Builder
{
    internal class ApnsAlertBuilderImplementation : IApnsAlertBuilder
    {
        private ApnsAlertImplementation _apnsAlertImplementation;

        internal ApnsAlertBuilderImplementation()
        {
            _apnsAlertImplementation = new ApnsAlertImplementation();
        }

        internal ApnsAlertBuilderImplementation(IApnsAlert apnsAlert)
        {
            _apnsAlertImplementation = new ApnsAlertImplementation(apnsAlert);
        }

        public IApnsAlertBuilder Title(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            _apnsAlertImplementation.Title = title;

            return this;
        }

        public IApnsAlertBuilder Body(string body)
        {
            if (string.IsNullOrEmpty(body))
                throw new ArgumentNullException(nameof(body));

            _apnsAlertImplementation.Body = body;

            return this;
        }

        public IApnsAlertBuilder TitleLocalizableKey(string titleLocKey)
        {
            if (string.IsNullOrEmpty(titleLocKey))
                throw new ArgumentNullException(nameof(titleLocKey));

            _apnsAlertImplementation.TitleLocKey = titleLocKey;

            return this;
        }

        public IApnsAlertBuilder AddTitleLocalizableArgument(string titleLocArgument)
        {
            if (string.IsNullOrEmpty(titleLocArgument))
                throw new ArgumentNullException(nameof(titleLocArgument));

            _apnsAlertImplementation.InternalTitleLocArgs.Add(titleLocArgument);

            return this;
        }

        public IApnsAlertBuilder ActionLocalizableKey(string actionLocalizableKey)
        {
            if (string.IsNullOrEmpty(actionLocalizableKey))
                throw new ArgumentNullException(nameof(actionLocalizableKey));

            _apnsAlertImplementation.ActionLocKey = actionLocalizableKey;

            return this;
        }

        public IApnsAlertBuilder LocalizableKey(string localizableKey)
        {
            if (string.IsNullOrEmpty(localizableKey))
                throw new ArgumentNullException(nameof(localizableKey));

            _apnsAlertImplementation.LocKey = localizableKey;

            return this;
        }

        public IApnsAlertBuilder AddLocalizableArgument(string titleLocalizableArgument)
        {
            if (string.IsNullOrEmpty(titleLocalizableArgument))
                throw new ArgumentNullException(nameof(titleLocalizableArgument));

            _apnsAlertImplementation.InternalLocArgs.Add(titleLocalizableArgument);

            return this;
        }

        public IApnsAlertBuilder LaunchImageFileName(string launchImageFileName)
        {
            if (string.IsNullOrEmpty(launchImageFileName))
                throw new ArgumentNullException(nameof(launchImageFileName));

            _apnsAlertImplementation.LaunchImage = launchImageFileName;

            return this;
        }

        public IApnsAlert Build()
        {
            if (_apnsAlertImplementation.TitleLocKey == null &&
               (_apnsAlertImplementation.TitleLocArgs != null && _apnsAlertImplementation.TitleLocArgs.Count > 0))
            {
                throw new ApnsAlertBuilderException("TitleLocKey is null but it has TitleLocKey") { ApnsAlertWithErrors = _apnsAlertImplementation }; ;
            }

            if (_apnsAlertImplementation.LocKey == null &&
               (_apnsAlertImplementation.LocArgs != null && _apnsAlertImplementation.LocArgs.Count > 0))
            {
                throw new ApnsAlertBuilderException("LocKey is null but it has LocArgs") { ApnsAlertWithErrors = _apnsAlertImplementation };
            }

            return _apnsAlertImplementation;
        }

        public async Task<IApnsAlert> BuildAsync()
        {
            return await Task.Run(() => Build());
        }

        public void Dispose()
        {
            _apnsAlertImplementation = null;
        }
    }
}