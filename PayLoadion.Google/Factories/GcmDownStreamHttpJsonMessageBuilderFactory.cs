using PayLoadion.Google.GcmDownStreamHttpJsonMessage.Builder;
using PayLoadion.Google.GcmDownStreamHttpJsonMessage.Message;
using PayLoadion.Google.PayLoad;

namespace PayLoadion.Google.Factories
{
    public static class GcmDownStreamHttpJsonMessageBuilderFactory
    {
        public static IGcmDownStreamHttpJsonMessageBuilderToUniqueDevice Create()
        {
            return new GcmDownStreamHttpJsonMessageBuilderImplementation();
        }

        public static IGcmDownStreamHttpJsonMessageBuilderToUniqueDevice Create(IGcmDownStreamHttpJsonMessage gcmDownStreamHttpJsonMessage)
        {
            return new GcmDownStreamHttpJsonMessageBuilderImplementation(gcmDownStreamHttpJsonMessage);
        }
    }
}