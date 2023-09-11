using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Logging
{
    public static class RegisterLoggerExtensions
    {
        public static IServiceCollection RegisterLogger(this IServiceCollection services, Type loggerType, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            if (loggerType.BaseType != typeof(BaseLogger) && loggerType.BaseType?.BaseType != typeof(BaseLogger))
                throw new ArgumentException("Logger is not a subtype of " + nameof(BaseLogger));

            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(loggerType);
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped(loggerType);
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient(loggerType);
                    break;
                default:
                    services.AddScoped(loggerType);
                    break;
            }

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            LoggerFactory.RegisterLogger((BaseLogger)serviceProvider.GetRequiredService(loggerType));

            return services;
        }

        public static IServiceCollection RegisterLogger(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped, params Type[] loggers)
        {
            foreach (Type loggerType in loggers)
            {
                if (loggerType.BaseType != typeof(BaseLogger) && loggerType.BaseType?.BaseType != typeof(BaseLogger))
                    throw new ArgumentException("Logger is not a subtype of " + nameof(BaseLogger));

                switch (serviceLifetime)
                {
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(loggerType);
                        break;
                    case ServiceLifetime.Scoped:
                        services.AddScoped(loggerType);
                        break;
                    case ServiceLifetime.Transient:
                        services.AddTransient(loggerType);
                        break;
                    default:
                        services.AddScoped(loggerType);
                        break;
                }
            }

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            foreach (Type loggerType in loggers)
                LoggerFactory.RegisterLogger((BaseLogger)serviceProvider.GetRequiredService(loggerType));

            return services;
        }
    }
}
