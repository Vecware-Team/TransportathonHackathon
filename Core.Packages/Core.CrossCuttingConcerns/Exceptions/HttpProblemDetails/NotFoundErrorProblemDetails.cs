using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class NotFoundErrorProblemDetails : BaseProblemDetails
    {
        public NotFoundErrorProblemDetails() : base(StatusCodes.Status404NotFound)
        {
        }

        public NotFoundErrorProblemDetails(string detail) : base(detail, StatusCodes.Status404NotFound)
        {
        }

        public NotFoundErrorProblemDetails(string title, string detail) : base(title, detail, StatusCodes.Status404NotFound)
        {
        }

        public NotFoundErrorProblemDetails(string title, string detail, string type) : base(title, detail, type, StatusCodes.Status404NotFound)
        {
        }
    }
}
