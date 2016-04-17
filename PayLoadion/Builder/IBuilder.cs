using System.Threading.Tasks;

namespace PayLoadion.Builder
{
    public interface IBuilder<TBuilderResult>
    {
        TBuilderResult Build();

        Task<TBuilderResult> BuildAsync();
    }
}