using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class AuthorizationDeniedErrorProblemDetails : BaseProblemDetails
    {
        public AuthorizationDeniedErrorProblemDetails() : base(StatusCodes.Status403Forbidden)
        {
            Type = "Authorization";
        }

        public AuthorizationDeniedErrorProblemDetails(string detail) : base(detail, StatusCodes.Status403Forbidden)
        {
            Type = "Authorization";
        }

        public AuthorizationDeniedErrorProblemDetails(string title, string detail) : base(title, detail, StatusCodes.Status403Forbidden)
        {
            Type = "Authorization";
        }

        public AuthorizationDeniedErrorProblemDetails(string title, string detail, string type) : base(title, detail, type, StatusCodes.Status403Forbidden)
        {
            Type = "Authorization";
        }
    }
}
