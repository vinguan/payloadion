using System;
using System.Collections.Generic;

namespace PayLoadion.PayLoad
{
    /// <summary>
    /// Represents the contracts for a PayLoad
    /// </summary>
    public interface IPayLoad : IDisposable
    {
        /// <summary>
        /// Gets the custom data that goes along with the schema payload
        /// </summary>
        IReadOnlyDictionary<string, object> CustomData { get; }
    }
}