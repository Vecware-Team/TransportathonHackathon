using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddDbContext<ProjectDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(isDevelopment ? "MsSqlDevelopment" : "MsSqlProduction"));
            });

            return services;
        }
    }
}
