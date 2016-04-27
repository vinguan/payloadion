using System;

namespace PayLoadion.Apns.Exceptions
{
    /// <summary>
    /// Represents the Exception that may occur while ApnsPayLoadBuilder execution
    /// </summary>
    public class ApnsPayloadBuilderException : Exception
    {
        #region Constructors
        #region Public Constructors
        /// <summary>
        ///  Inits a new instance of <see cref="ApnsPayloadBuilderException"/>
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">the inner exception</param>
        public ApnsPayloadBuilderException(string message, Exception innerException = null) : base(message, innerException)
        {

        }
        #endregion Public Constructors
        #endregion Constructors
    }
}
