using PayLoadion.Google.PayLoad;
using PayLoadion.Google.PayLoadBuilder;

namespace PayLoadion.Google.Factories
{
    public static class GcmPayLoadBuilderFactory
    {
        public static IGcmPayLoadBuilderNotification Create()
        {
            return new GcmPayLoadBuilderImplementation();
        }

        public static IGcmPayLoadBuilderNotification Create(IGcmPayLoad gcmPayLoad)
        {
            return new GcmPayLoadBuilderImplementation(gcmPayLoad);
        }
    }
}