using PayLoadion.Apns.PayLoad.Alert;
using PayLoadion.Apns.PayLoadBuilder.Alert;

namespace PayLoadion.Apns.Factories
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