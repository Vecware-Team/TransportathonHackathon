using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class UnauthorizedErrorProblemDetails : BaseProblemDetails
    {
        public UnauthorizedErrorProblemDetails() : base(StatusCodes.Status401Unauthorized)
        {
            Type = "Unauthorized";
        }

        public UnauthorizedErrorProblemDetails(string detail) : base(detail, StatusCodes.Status401Unauthorized)
        {
            Type = "Unauthorized";
        }

        public UnauthorizedErrorProblemDetails(string title, string detail) : base(title, detail, StatusCodes.Status401Unauthorized)
        {
            Type = "Unauthorized";
        }

        public UnauthorizedErrorProblemDetails(string title, string detail, string type) : base(title, detail, type, StatusCodes.Status401Unauthorized)
        {
            Type = "Unauthorized";
        }
    }
}
