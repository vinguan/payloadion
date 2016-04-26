using System;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Builder;

namespace PayLoadion.Gcm.Exceptions
{
    /// <summary>
    /// Exception for <see cref="IGcmDownStreamHttpMessageBuilder"/>
    /// </summary>
    public class GcmDownStreamHttpMessageBuilderException : Exception
    {
        /// <summary>
        /// Inits a new instance of <see cref="GcmDownStreamHttpMessageBuilderException"/>
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public GcmDownStreamHttpMessageBuilderException(string message, Exception innerException = null) : base(message, innerException)
        {

        }
    }
}