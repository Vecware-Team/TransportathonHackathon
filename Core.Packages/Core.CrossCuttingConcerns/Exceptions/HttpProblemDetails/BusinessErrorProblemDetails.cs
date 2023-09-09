using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class BusinessErrorProblemDetails : BaseProblemDetails
    {
        public BusinessErrorProblemDetails() : base(StatusCodes.Status400BadRequest)
        {
        }

        public BusinessErrorProblemDetails(string detail) : base(detail, StatusCodes.Status400BadRequest)
        {
        }

        public BusinessErrorProblemDetails(string title, string detail) : base(title, detail, StatusCodes.Status400BadRequest)
        {
        }

        public BusinessErrorProblemDetails(string title, string detail, string type) : base(title, detail, type, StatusCodes.Status400BadRequest)
        {
        }
    }
}
