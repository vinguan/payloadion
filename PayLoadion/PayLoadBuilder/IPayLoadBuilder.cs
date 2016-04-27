using System;
using System.Threading;
using System.Threading.Tasks;
using PayLoadion.PayLoad;

namespace PayLoadion.PayLoadBuilder
{
    /// <summary>
    /// Represents the contracts for a PayLoad Builder
    /// </summary>
    /// <typeparam name="TPayLoad">The <see cref="IPayLoad"/></typeparam>
    public interface IPayLoadBuilder<TPayLoad> : IDisposable where TPayLoad : IPayLoad
    {
        /// <summary>
        /// Builds the payload object
        /// </summary>
        /// <returns>The payload</returns>
        TPayLoad BuildPayLoad();

        /// <summary>
        /// Builds the payload object async
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The payload</returns>
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