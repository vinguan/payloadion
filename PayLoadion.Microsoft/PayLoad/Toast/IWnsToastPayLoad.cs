using PayLoadion.Microsoft.PayLoad.Audiable;

namespace PayLoadion.Microsoft.PayLoad.Toast
{
    public interface IWnsToastPayLoad : IWnsAudiablePayLoad
    {
        string Launch { get; }

        string Duration { get; }
    }
}