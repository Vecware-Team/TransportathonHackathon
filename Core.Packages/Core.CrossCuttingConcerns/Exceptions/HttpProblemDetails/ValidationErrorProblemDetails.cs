using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationErrorProblemDetails : BaseProblemDetails
    {
        public ValidationErrorProblemDetails() : base(StatusCodes.Status400BadRequest)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationErrorProblemDetails(IEnumerable<ValidationExceptionModel> errors) : base(StatusCodes.Status400BadRequest)
        {
            Errors = errors;
        }

        public ValidationErrorProblemDetails(string detail) : base(detail, StatusCodes.Status400BadRequest)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationErrorProblemDetails(string detail, IEnumerable<ValidationExceptionModel> errors) : base(detail, StatusCodes.Status400BadRequest)
        {
            Errors = errors;
        }

        public ValidationErrorProblemDetails(string title, string detail) : base(title, detail, StatusCodes.Status400BadRequest)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationErrorProblemDetails(string title, string detail, IEnumerable<ValidationExceptionModel> errors) : base(title, detail, StatusCodes.Status400BadRequest)
        {
            Errors = errors;
        }

        public ValidationErrorProblemDetails(string title, string detail, string type) : base(title, detail, type, StatusCodes.Status400BadRequest)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationErrorProblemDetails(string title, string detail, string type, IEnumerable<ValidationExceptionModel> errors) : base(title, detail, type, StatusCodes.Status400BadRequest)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationExceptionModel> Errors { get; init; }
    }
}
