using FluentValidation.Results;

namespace MusicManager.API.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when validation fails.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Creates a new instance of ValidationException with a default message.
        /// </summary>
        /// <returns>A new instance of ValidationException with a default message.</returns>
        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; }

        /// <summary>
        /// Constructor for ValidationException class which takes a collection of failures as parameter. 
        /// </summary>
        /// <returns>
        /// A ValidationException object with the collection of failures added to the Errors property.
        /// </returns>
        public ValidationException(IEnumerable<ValidationFailure> failures)
                    : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}