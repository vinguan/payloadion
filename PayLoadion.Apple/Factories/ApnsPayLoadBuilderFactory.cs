using PayLoadion.Apple.PayLoad;
using PayLoadion.Apple.PayLoadBuilder;

namespace PayLoadion.Apple.Factories
{
    public class ApnsPayLoadBuilderFactory
    {
        public static IApnsPayLoadBuilder CreateApnsPayLoadBuilder()
        {
            return new ApnsPayLoadBuilderImplementation();
        }

        public static IApnsPayLoadBuilder CreateApnsPayLoadBuilder(IApnsPayLoad apnsPayLoad)
        {
            return new ApnsPayLoadBuilderImplementation(apnsPayLoad);
        }
    }
}