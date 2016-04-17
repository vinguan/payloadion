using PayLoadion.Apple.PayLoad.Alert;
using PayLoadion.Apple.PayLoad.Alert.Builder;

namespace PayLoadion.Apple.Factories
{
    public class AlertBuilderFactory
    {
        public static IAlertBuilder CreateAlertBuilder()
        {
            return new AlertBuilderImplementation();
        }

        public static IAlertBuilder CreateAlertBuilder(IAlert alert)
        {
            return new AlertBuilderImplementation(alert);
        }
    }
}