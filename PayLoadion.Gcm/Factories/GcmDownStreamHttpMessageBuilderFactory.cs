using PayLoadion.Gcm.GcmDownStreamHttpMessage.Builder;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Message;

namespace PayLoadion.Gcm.Factories
{
    /// <summary>
    /// Represents the Factory for <see cref="IGcmDownStreamHttpMessageBuilder"/>
    /// </summary>
    public static class GcmDownStreamHttpMessageBuilderFactory
    {
        /// <summary>
        /// Creates the <see cref="IGcmDownStreamHttpMessageBuilder"/>
        /// </summary>
        /// <returns><see cref="IGcmDownStreamHttpMessageBuilder"/></returns>
        public static IGcmDownStreamHttpMessageBuilderTargets CreateGcmDownStreamHttpJsonMessageBuilder()
        {
            return new GcmDownStreamHttpMessageBuilderImplementation();
        }

        /// <summary>
        ///  Creates the <see cref="IGcmDownStreamHttpMessageBuilder"/>
        /// </summary>
        /// <param name="gcmDownStreamHttpMessage">the other <see cref="IGcmDownStreamHttpMessage"/></param>
        /// <returns><see cref="IGcmDownStreamHttpMessageBuilder"/></returns>
        public static IGcmDownStreamHttpMessageBuilderTargets CreateGcmDownStreamHttpJsonMessageBuilder(IGcmDownStreamHttpMessage gcmDownStreamHttpMessage)
        {
            return new GcmDownStreamHttpMessageBuilderImplementation(gcmDownStreamHttpMessage);
        }
    }
}