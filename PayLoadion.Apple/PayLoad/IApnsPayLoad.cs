using PayLoadion.Apple.PayLoad.Alert;
using PayLoadion.PayLoad;

namespace PayLoadion.Apple.PayLoad
{
    public interface IApnsPayLoad : IPayLoad
    {
        IApnsAlert Alert { get; }

        string AlertMessage { get; }

        int? Badge { get; }

        string Sound { get; }

        int? ContentAvailable { get; }

        string Category { get; }
    }
}
