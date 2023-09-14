using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Application.Services;
using TransportathonHackathon.Domain.Entities.Identity;
using TransportathonHackathon.Persistence.Contexts;
using TransportathonHackathon.Persistence.Repositories;
using TransportathonHackathon.Persistence.Services;

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

            services.AddIdentityCore<AppUser>().AddRoles<AppRole>().AddEntityFrameworkStores<ProjectDbContext>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICarrierRepository, CarrierRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IDriverLicenseRepository, DriverLicenseRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ITranslateRepository, TranslateRepository>();
            services.AddScoped<ITransportRequestRepository, TransportRequestRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ITruckRepository, TruckRepository>();
            services.AddScoped<IPickupTruckRepository, PickupTruckRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<IMessageService, MessageService>();

            return services;
        }
    }
}
