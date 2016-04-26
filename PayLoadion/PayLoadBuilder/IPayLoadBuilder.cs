using System;
using System.Threading;
using System.Threading.Tasks;
using PayLoadion.PayLoad;

namespace PayLoadion.PayLoadBuilder
{
    /// <summary>
    /// Represents the contracts for a PayLoad Builder
    /// </summary>
    /// <typeparam name="TPayLoad"></typeparam>
    public interface IPayLoadBuilder<TPayLoad> : IDisposable where TPayLoad : IPayLoad
    {
        /// <summary>
        /// Add custom data to payload
        /// </summary>
        /// <param name="customDataKey">The custom data key</param>
        /// <param name="customDataValue">the custom data value</param>
        /// <returns>The payload builder</returns>
        IPayLoadBuilder<TPayLoad> AddCustomData(string customDataKey, object customDataValue);

        /// <summary>
        /// Builds the payload object
        /// </summary>
        /// <returns></returns>
        TPayLoad BuildPayLoad();

        /// <summary>
        /// Builds the payload object async
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        Task<TPayLoad> BuildPayLoadAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Builds the payload and serializes it to string
        /// </summary>
        /// <param name="indent">If it should be indented</param>
        /// <returns>The payload serialized to string</returns>
        string BuildPayLoadToString(bool indent = false);

        /// <summary>
        /// Builds the payload and serializes it to string async
        /// </summary>
        /// <param name="indent">If it should be indented</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The payload serialized to string</returns>
        Task<string> BuildPayLoadToStringAsync(bool indent = false, CancellationToken cancellationToken = default(CancellationToken));
    }
}