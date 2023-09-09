using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        private HttpResponse? _response;
        public HttpResponse Response
        {
            get => _response ?? throw new ArgumentNullException(nameof(_response));
            set => _response = value;
        }

        protected override Task HandleException(BusinessException exception)
        {
            Response.StatusCode = exception.StatusCode;
            string details = new BusinessErrorProblemDetails(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(ValidationException exception)
        {
            Response.StatusCode = exception.StatusCode;
            string details = new ValidationErrorProblemDetails(exception.Errors).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(UnauthorizedException exception)
        {
            Response.StatusCode = exception.StatusCode;
            string details = new UnauthorizedErrorProblemDetails(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(AuthorizationDeniedException exception)
        {
            Response.StatusCode = exception.StatusCode;
            string details = new AuthorizationDeniedErrorProblemDetails(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(NotFoundException exception)
        {
            Response.StatusCode = exception.StatusCode;
            string details = new NotFoundErrorProblemDetails(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            string details = new InternalServerErrorProblemDetails(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }
    }
}
