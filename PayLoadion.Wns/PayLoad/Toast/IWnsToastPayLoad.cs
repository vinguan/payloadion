using PayLoadion.Wns.PayLoad.Audiable;

namespace PayLoadion.Wns.PayLoad.Toast
{
    public interface IWnsToastPayLoad : IWnsAudiablePayLoad
    {
        string Launch { get; }

        string Duration { get; }
    }
}