using Core.Application.Pipelines.Transaction;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TransportathonHackathon.Application.Features.Drivers.Rules;

namespace TransportathonHackathon.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionScopeBehavior<,>));

            services.AddScoped<DriverBusinessRules>();

            return services;
        }
    }
}
