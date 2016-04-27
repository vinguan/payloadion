using PayLoadion.Apns.PayLoad;
using PayLoadion.Apns.PayLoadBuilder;

namespace PayLoadion.Apns.Factories
{
    /// <summary>
    /// Represents the factory for <see cref="IApnsPayLoadBuilder"/>
    /// </summary>
    public class ApnsPayLoadBuilderFactory
    {
        #region Methods
        #region Public Methods
        /// <summary>
        /// Creates the <see cref="IApnsPayLoadBuilder"/>
        /// </summary>
        /// <returns>the payload builder</returns>
        public static IApnsPayLoadBuilder CreateApnsPayLoadBuilder()
        {
            return new ApnsPayLoadBuilderImplementation();
        }

        /// <summary>
        /// Creates the <see cref="IApnsPayLoadBuilder"/> based on another <see cref="IApnsPayLoad"/>
        /// </summary>
        /// <param name="apnsPayLoad">The <see cref="IApnsPayLoad"/></param>
        /// <returns>the payload builder</returns>
        public static IApnsPayLoadBuilder CreateApnsPayLoadBuilder(IApnsPayLoad apnsPayLoad)
        {
            return new ApnsPayLoadBuilderImplementation(apnsPayLoad);
        }
        #endregion Public Methods
        #endregion Methods
    }
}