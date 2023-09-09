using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Core.CrossCuttingConcerns.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.CrossCuttingConcerns.Exceptions.Extensions
{
    public static class ExceptionHandlersRegistration
    {
        public static IServiceCollection AddExceptionHandlers(this IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            services.AddExceptionHandlersFromAssembly(Assembly.GetExecutingAssembly(), serviceLifetime);
            return services;
        }

        public static IServiceCollection AddExceptionHandlersFromAssembly(this IServiceCollection services, Assembly assembly, ServiceLifetime serviceLifetime)
        {
            services.AddSubClassesOfType(assembly, typeof(ExceptionHandler), (s, t) => serviceLifetime switch
            {
                ServiceLifetime.Singleton => s.AddSingleton(t),
                ServiceLifetime.Scoped => s.AddScoped(t),
                ServiceLifetime.Transient => s.AddTransient(t),
                _ => throw new NotImplementedException(),
            });
            return services;
        }
    }
}
