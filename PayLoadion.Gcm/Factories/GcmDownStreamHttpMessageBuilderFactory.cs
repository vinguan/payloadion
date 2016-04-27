using PayLoadion.Gcm.GcmDownStreamHttpMessage.Builder;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Message;

namespace PayLoadion.Gcm.Factories
{
    /// <summary>
    /// Represents the Factory for <see cref="IGcmDownStreamHttpMessageFinalBuilder"/>
    /// </summary>
    public static class GcmDownStreamHttpMessageBuilderFactory
    {
        #region Methods

        #region Public Methods
        /// <summary>
        /// Creates the <see cref="IGcmDownStreamHttpMessageFinalBuilder"/>
        /// </summary>
        /// <returns><see cref="IGcmDownStreamHttpMessageBuilder"/></returns>
        public static IGcmDownStreamHttpMessageBuilder CreateGcmDownStreamHttpMessageBuilder()
        {
            return new GcmDownStreamHttpMessageBuilderImplementation();
        }

        /// <summary>
        ///  Creates the <see cref="IGcmDownStreamHttpMessageFinalBuilder"/>
        /// </summary>
        /// <param name="gcmDownStreamHttpMessage">the other <see cref="IGcmDownStreamHttpMessage"/></param>
        /// <returns><see cref="IGcmDownStreamHttpMessageBuilder"/></returns>
        public static IGcmDownStreamHttpMessageBuilder CreateGcmDownStreamHttpMessageBuilder(IGcmDownStreamHttpMessage gcmDownStreamHttpMessage)
        {
            return new GcmDownStreamHttpMessageBuilderImplementation(gcmDownStreamHttpMessage);
        }
        #endregion Public Methods

        #endregion Methods
    }
}