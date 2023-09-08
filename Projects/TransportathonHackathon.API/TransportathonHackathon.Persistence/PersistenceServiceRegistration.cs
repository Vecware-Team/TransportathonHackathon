using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Persistence.Contexts;
using TransportathonHackathon.Persistence.Repositories;

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

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IDriverLicenseRepository, DriverLicenseRepository>();

            return services;
        }
    }
}
