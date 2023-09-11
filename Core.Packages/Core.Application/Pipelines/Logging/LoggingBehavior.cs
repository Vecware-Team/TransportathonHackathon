using Core.CrossCuttingConcerns.Logging;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ILoggableRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggingBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<LogParameter> parameters = new()
            {
                new LogParameter
                {
                    Type = request.GetType().Name,
                    Value = request
                }
            };

            LogDetail logDetail = new LogDetail()
            {
                FullName = next.Method.ReflectedType.FullName,
                MethodName = next.Method.Name,
                Parameters = parameters,
                User = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "?",
            };

            LoggerFactory.RunLoggers(LogType.Info, JsonSerializer.Serialize(logDetail));

            return next();
        }
    }
}
