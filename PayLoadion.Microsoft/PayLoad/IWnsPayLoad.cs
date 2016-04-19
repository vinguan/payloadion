using PayLoadion.PayLoad;

namespace PayLoadion.Microsoft.PayLoad
{
    public interface IWnsPayLoad : IPayLoad
    {
        string RootElement { get; }

        int? Version { get; }
    }
}