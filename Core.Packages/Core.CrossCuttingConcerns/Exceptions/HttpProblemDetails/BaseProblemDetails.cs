using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public abstract class BaseProblemDetails : ProblemDetails
    {
        public BaseProblemDetails(int statusCode)
        {

            Title = "An Error Occurred";
            Detail = "An error occurred";
            Status = statusCode;
            Type = "";
        }

        public BaseProblemDetails(string detail, int statusCode)
        {
            Title = "An Error Occurred";
            Detail = detail;
            Status = statusCode;
            Type = "";
        }

        public BaseProblemDetails(string title, string detail, int statusCode)
        {
            Title = title;
            Detail = detail;
            Status = statusCode;
            Type = "";
        }

        public BaseProblemDetails(string title, string detail, string type, int statusCode)
        {
            Title = title;
            Detail = detail;
            Status = statusCode;
            Type = type;
        }
    }
}
