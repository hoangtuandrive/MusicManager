using System.Globalization;

namespace MusicManager.Application.Exceptions
{


    /// <summary>
    /// Represents an exception thrown when an API call fails.
    /// </summary>
    public class ApiException : Exception
    {
        public ApiException() : base()
        {
        }

        public ApiException(string message) : base(message)
        {
        }



        /// <summary>
        /// Creates an ApiException with a formatted message.
        /// </summary>
        /// <param name="message">The message to format.</param>
        /// <param name="args">The arguments to format the message with.</param>
        /// <returns>A new ApiException with the formatted message.</returns>
        public ApiException(string message, params object[] args)
                    : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}