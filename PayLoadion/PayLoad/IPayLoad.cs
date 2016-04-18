using System.Collections.Generic;

namespace PayLoadion.PayLoad
{
    public interface IPayLoad
    {
        IReadOnlyDictionary<string, object> CustomData { get; }
    }
}