using PayLoadion.Google.PayLoad;
using PayLoadion.Google.PayLoadBuilder;

namespace PayLoadion.Google.Factories
{
    public static class GcmPayLoadBuilderFactory
    {
        public static IGcmPayLoadBuilder CreateGcmPayLoadBuilder()
        {
            return new GcmPayLoadBuilderImplementation();
        }

        public static IGcmPayLoadBuilder CreateGcmPayLoadBuilder(IGcmPayLoad gcmPayLoad)
        {
            return new GcmPayLoadBuilderImplementation(gcmPayLoad);
        }
    }
}