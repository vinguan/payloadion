using PayLoadion.Gcm.PayLoad;
using PayLoadion.Gcm.PayLoadBuilder;

namespace PayLoadion.Gcm.Factories
{
    /// <summary>
    /// Represents the factory for <see cref="GcmPayLoadBuilderFactory"/>
    /// </summary>
    public static class GcmPayLoadBuilderFactory
    {
        /// <summary>
        /// Creates the <see cref="IGcmPayLoadBuilderNotification"/>
        /// </summary>
        /// <returns><see cref="IGcmPayLoadBuilderNotification"/></returns>
        public static IGcmPayLoadBuilderNotification Create()
        {
            return new GcmPayLoadBuilderImplementation();
        }

        /// <summary>
        /// Creates the <see cref="IGcmPayLoadBuilderNotification"/>
        /// </summary>
        /// <param name="gcmPayLoad">The other <see cref="IGcmPayLoad"/></param>
        /// <returns><see cref="IGcmPayLoadBuilderNotification"/></returns>
        public static IGcmPayLoadBuilderNotification Create(IGcmPayLoad gcmPayLoad)
        {
            return new GcmPayLoadBuilderImplementation(gcmPayLoad);
        }
    }
}