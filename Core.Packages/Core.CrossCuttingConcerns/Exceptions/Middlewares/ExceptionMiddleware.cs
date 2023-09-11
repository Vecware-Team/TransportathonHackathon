using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpExceptionHandler _httpExceptionHandler;

        public ExceptionMiddleware(RequestDelegate next, HttpExceptionHandler httpExceptionHandler)
        {
            _next = next;
            _httpExceptionHandler = httpExceptionHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            LogException(context, exception);

            context.Response.ContentType = "application/json";
            _httpExceptionHandler.Response = context.Response;
            await _httpExceptionHandler.HandleExceptionAsync(exception);
        }

        private void LogException(HttpContext context, Exception exception)
        {
            List<LogParameter> parameters = new List<LogParameter>()
            {
                new() { Type = context.GetType().Name, Value = exception.ToString() },
            };

            ExceptionLogDetail logDetail = new ExceptionLogDetail()
            {
                MethodName = _next.Method.Name,
                Parameters = parameters,
                ExceptionMessage = exception.Message,
                User = context?.User?.Identity?.Name ?? "?",
            };

            LoggerFactory.RunLoggersSafety(LogType.Error, JsonSerializer.Serialize(logDetail));
        }
    }
}
