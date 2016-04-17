using PayLoadion.Builder;
using PayLoadion.PayLoad;

namespace PayLoadion.PayLoadBuilder
{
    public interface IPayLoadBuilder<out TPayLoad> : IBuilder<string> where TPayLoad : IPayLoad
    {
        TPayLoad PayLoad { get; }
    }
}