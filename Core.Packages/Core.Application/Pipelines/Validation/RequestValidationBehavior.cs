using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using FluentValidation;
using MediatR;

namespace Core.Application.Pipelines.Validation
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ValidationContext<object> context = new ValidationContext<object>(request);

            IEnumerable<ValidationExceptionModel> errors = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .GroupBy(
                    keySelector: validationFailure => validationFailure.PropertyName,
                    resultSelector: (propertyName, _errors) =>
                        new ValidationExceptionModel()
                        {
                            Property = propertyName,
                            Errors = _errors.Select(error => error.ErrorMessage)
                        }).ToList();

            if (errors.Any())
                throw new CrossCuttingConcerns.Exceptions.ExceptionTypes.ValidationException(errors);

            TResponse response = await next();
            return response;
        }
    }
}
