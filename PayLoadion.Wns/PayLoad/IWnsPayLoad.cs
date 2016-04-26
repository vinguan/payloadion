using PayLoadion.PayLoad;

namespace PayLoadion.Wns.PayLoad
{
    public interface IWnsPayLoad : IPayLoad
    {
        string RootElement { get; }

        int? Version { get; }
    }
}