using Core.CrossCuttingConcerns.Exceptions.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Core.CrossCuttingConcerns.Exceptions.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder ConfigureCustomExceptionMiddleware(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>();
    }
}
