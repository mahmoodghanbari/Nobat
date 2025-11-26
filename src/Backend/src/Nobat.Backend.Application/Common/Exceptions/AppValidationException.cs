using FluentValidation.Results;

namespace Nobat.Backend.Application.Common.Exceptions
{
    public class AppValidationException : Exception
    {
        public AppValidationException()
            : base("یک یا چند خطای اعتبارسنجی رخ داده است.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public AppValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
