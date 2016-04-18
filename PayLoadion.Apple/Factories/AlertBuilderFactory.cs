using PayLoadion.Apple.PayLoad.Alert;
using PayLoadion.Apple.PayLoad.Alert.Builder;

namespace PayLoadion.Apple.Factories
{
    public class AlertBuilderFactory
    {
        public static IApnsAlertBuilder CreateAlertBuilder()
        {
            return new ApnsAlertBuilderImplementation();
        }

        public static IApnsAlertBuilder CreateAlertBuilder(IApnsAlert apnsAlert)
        {
            return new ApnsAlertBuilderImplementation(apnsAlert);
        }
    }
}