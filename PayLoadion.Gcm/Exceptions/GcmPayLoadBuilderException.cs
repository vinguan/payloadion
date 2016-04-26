using System;
using PayLoadion.Gcm.PayLoadBuilder;

namespace PayLoadion.Gcm.Exceptions
{
    /// <summary>
    /// Exception for <see cref="IGcmPayLoadBuilder"/>
    /// </summary>
    public class GcmPayLoadBuilderException : Exception
    {
        /// <summary>
        /// Inits a new instance of <see cref="GcmPayLoadBuilderException"/>
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public GcmPayLoadBuilderException(string message, Exception innerException = null) : base(message, innerException)
        {

        }
    }
}