using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Persistence.Contexts
{
    public class ProjectDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverLicense> DriverLicenses { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Translate> Translates { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
