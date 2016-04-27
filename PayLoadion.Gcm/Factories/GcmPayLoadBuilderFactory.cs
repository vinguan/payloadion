using PayLoadion.Gcm.PayLoad;
using PayLoadion.Gcm.PayLoadBuilder;

namespace PayLoadion.Gcm.Factories
{
    /// <summary>
    /// Represents the factory for <see cref="GcmPayLoadBuilderFactory"/>
    /// </summary>
    public static class GcmPayLoadBuilderFactory
    {
        #region Methods

        #region Public Methods
        /// <summary>
        /// Creates the <see cref="IGcmPayLoadBuilder"/>
        /// </summary>
        /// <returns><see cref="IGcmPayLoadBuilder"/></returns>
        public static IGcmPayLoadBuilder CreateGcmPayLoadBuilder()
        {
            return new GcmPayLoadBuilderImplementation();
        }

        /// <summary>
        /// Creates the <see cref="IGcmPayLoadBuilder"/>
        /// </summary>
        /// <param name="gcmPayLoad">The other <see cref="IGcmPayLoad"/></param>
        /// <returns><see cref="IGcmPayLoadBuilder"/></returns>
        public static IGcmPayLoadBuilder CreateGcmPayLoadBuilder(IGcmPayLoad gcmPayLoad)
        {
            return new GcmPayLoadBuilderImplementation(gcmPayLoad);
        }
        #endregion Public Methods

        #endregion Methods
    }
}