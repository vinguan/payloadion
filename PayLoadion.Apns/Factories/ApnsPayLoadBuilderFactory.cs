using PayLoadion.Apns.PayLoad;
using PayLoadion.Apns.PayLoadBuilder;

namespace PayLoadion.Apns.Factories
{
    /// <summary>
    /// Represents the factory for <see cref="IApnsPayLoadBuilderStart"/>
    /// </summary>
    public class ApnsPayLoadBuilderFactory
    {
        /// <summary>
        /// Creates the <see cref="IApnsPayLoadBuilderStart"/>
        /// </summary>
        /// <returns>the payload builder</returns>
        public static IApnsPayLoadBuilderStart CreateApnsPayLoadBuilder()
        {
            return new ApnsPayLoadBuilderImplementation();
        }

        /// <summary>
        /// Creates the <see cref="IApnsPayLoadBuilderStart"/> based on another <see cref="IApnsPayLoad"/>
        /// </summary>
        /// <param name="apnsPayLoad">The <see cref="IApnsPayLoad"/></param>
        /// <returns>the payload builder</returns>
        public static IApnsPayLoadBuilderStart CreateApnsPayLoadBuilder(IApnsPayLoad apnsPayLoad)
        {
            return new ApnsPayLoadBuilderImplementation(apnsPayLoad);
        }
    }
}