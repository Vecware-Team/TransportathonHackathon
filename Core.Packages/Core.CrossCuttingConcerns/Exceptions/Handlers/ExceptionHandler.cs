using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers
{
    public abstract class ExceptionHandler
    {
        public Task HandleExceptionAsync(Exception exception) => exception switch
        {
            BusinessException businessException => HandleException(businessException),
            ValidationException validationException => HandleException(validationException),
            UnauthorizedException unauthorizedException => HandleException(unauthorizedException),
            AuthorizationDeniedException authorizationDeniedException => HandleException(authorizationDeniedException),
            NotFoundException notFoundException => HandleException(notFoundException),
            _ => HandleException(exception)
        };

        protected abstract Task HandleException(BusinessException exception);
        protected abstract Task HandleException(ValidationException exception);
        protected abstract Task HandleException(UnauthorizedException exception);
        protected abstract Task HandleException(AuthorizationDeniedException exception);
        protected abstract Task HandleException(NotFoundException exception);
        protected abstract Task HandleException(Exception exception);
    }
}
