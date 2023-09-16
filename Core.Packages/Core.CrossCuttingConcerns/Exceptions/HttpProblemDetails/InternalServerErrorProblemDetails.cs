using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class InternalServerErrorProblemDetails : BaseProblemDetails
    {
        public InternalServerErrorProblemDetails() : base(StatusCodes.Status500InternalServerError)
        {
            Type = "Internal";
        }

        public InternalServerErrorProblemDetails(string detail) : base(detail, StatusCodes.Status500InternalServerError)
        {
            Type = "Internal";
        }

        public InternalServerErrorProblemDetails(string title, string detail) : base(title, detail, StatusCodes.Status500InternalServerError)
        {
            Type = "Internal";
        }

        public InternalServerErrorProblemDetails(string title, string detail, string type) : base(title, detail, type, StatusCodes.Status500InternalServerError)
        {
            Type = "Internal";
        }
    }
}
