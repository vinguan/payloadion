using System;
using System.Threading.Tasks;
using PayLoadion.Apple.Exceptions.Alert;

namespace PayLoadion.Apple.PayLoad.Alert.Builder
{
    internal class AlertBuilderImplementation : IAlertBuilder
    {
        private AlertImplementation _alertImplementation;

        public AlertBuilderImplementation()
        {
            _alertImplementation = new AlertImplementation();
        }

        public AlertBuilderImplementation(IAlert alert)
        {
            _alertImplementation = new AlertImplementation(alert);
        }

        public IAlertBuilder Title(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            _alertImplementation.Title = title;

            return this;
        }

        public IAlertBuilder Body(string body)
        {
            if (string.IsNullOrEmpty(body))
                throw new ArgumentNullException(nameof(body));

            _alertImplementation.Body = body;

            return this;
        }

        public IAlertBuilder TitleLocalizableKey(string titleLocKey)
        {
            if (string.IsNullOrEmpty(titleLocKey))
                throw new ArgumentNullException(nameof(titleLocKey));

            _alertImplementation.TitleLocKey = titleLocKey;

            return this;
        }

        public IAlertBuilder AddTitleLocalizableArgument(string titleLocArgument)
        {
            if (string.IsNullOrEmpty(titleLocArgument))
                throw new ArgumentNullException(nameof(titleLocArgument));

            _alertImplementation.InternalTitleLocArgs.Add(titleLocArgument);

            return this;
        }

        public IAlertBuilder ActionLocalizableKey(string actionLocalizableKey)
        {
            if (string.IsNullOrEmpty(actionLocalizableKey))
                throw new ArgumentNullException(nameof(actionLocalizableKey));

            _alertImplementation.ActionLocKey = actionLocalizableKey;

            return this;
        }

        public IAlertBuilder LocalizableKey(string localizableKey)
        {
            if (string.IsNullOrEmpty(localizableKey))
                throw new ArgumentNullException(nameof(localizableKey));

            _alertImplementation.LocKey = localizableKey;

            return this;
        }

        public IAlertBuilder AddLocalizableArgument(string titleLocalizableArgument)
        {
            if (string.IsNullOrEmpty(titleLocalizableArgument))
                throw new ArgumentNullException(nameof(titleLocalizableArgument));

            _alertImplementation.InternalLocArgs.Add(titleLocalizableArgument);

            return this;
        }

        public IAlertBuilder LaunchImageFileName(string launchImageFileName)
        {
            if (string.IsNullOrEmpty(launchImageFileName))
                throw new ArgumentNullException(nameof(launchImageFileName));

            _alertImplementation.LaunchImage = launchImageFileName;

            return this;
        }

        public IAlert Build()
        {
            if (_alertImplementation.TitleLocKey == null &&
               (_alertImplementation.TitleLocArgs != null && _alertImplementation.TitleLocArgs.Count > 0))
            {
                throw new AlertBuilderException("TitleLocKey is null but it has TitleLocKey") { AlertWithError = _alertImplementation }; ;
            }

            if (_alertImplementation.LocKey == null &&
               (_alertImplementation.LocArgs != null && _alertImplementation.LocArgs.Count > 0))
            {
                throw new AlertBuilderException("LocKey is null but it has LocArgs") { AlertWithError = _alertImplementation };
            }

            return _alertImplementation;
        }

        public async Task<IAlert> BuildAsync()
        {
            return await Task.FromResult(_alertImplementation);
        }

        public void Dispose()
        {
            _alertImplementation = null;
        }
    }
}