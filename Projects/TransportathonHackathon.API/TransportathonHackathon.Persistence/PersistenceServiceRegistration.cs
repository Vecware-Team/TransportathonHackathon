using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities.Identity;
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

            services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<ProjectDbContext>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IDriverLicenseRepository, DriverLicenseRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
