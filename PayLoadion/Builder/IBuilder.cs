using System.Threading.Tasks;

namespace PayLoadion.Builder
{
    /// <summary>
    /// Represents the contracts for a Builder
    /// </summary>
    /// <typeparam name="TBuilderResult">The type of the buider result</typeparam>
    public interface IBuilder<TBuilderResult>
    {
        /// <summary>
        /// Builds the result
        /// </summary>
        /// <returns>The result of the builder</returns>
        TBuilderResult Build();

        /// <summary>
        /// Builds the object async
        /// </summary>
        /// <returns>The result of the builder</returns>
        Task<TBuilderResult> BuildAsync();
    }
}