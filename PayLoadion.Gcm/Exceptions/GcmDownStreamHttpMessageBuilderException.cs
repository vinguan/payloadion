using System;
using PayLoadion.Gcm.GcmDownStreamHttpMessage.Builder;

namespace PayLoadion.Gcm.Exceptions
{
    /// <summary>
    /// Exception for <see cref="IGcmDownStreamHttpMessageFinalBuilder"/>
    /// </summary>
    public class GcmDownStreamHttpMessageBuilderException : Exception
    {
        #region Constructors

        #region Public Constructors
        /// <summary>
        /// Inits a new instance of <see cref="GcmDownStreamHttpMessageBuilderException"/>
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public GcmDownStreamHttpMessageBuilderException(string message, Exception innerException = null) : base(message, innerException)
        {

        }
        #endregion Public Constructors

        #endregion Constructors
    }
}