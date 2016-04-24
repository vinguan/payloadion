using System.Threading;
using System.Threading.Tasks;
using PayLoadion.PayLoad;

namespace PayLoadion.PayLoadBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TPayLoad"></typeparam>
    public interface IPayLoadBuilder<TPayLoad> where TPayLoad : IPayLoad
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customDataKey"></param>
        /// <param name="customDataValue"></param>
        /// <returns></returns>
        IPayLoadBuilder<TPayLoad> AddCustomData(string customDataKey, object customDataValue);

        TPayLoad BuildPayLoad();

        Task<TPayLoad> BuildPayLoadAsync(CancellationToken cancellationToken = default(CancellationToken));

        string BuildPayLoadToString(bool indent = false);

        Task<string> BuildPayLoadToStringAsync(bool indent = false, CancellationToken cancellationToken = default(CancellationToken));
    }
}