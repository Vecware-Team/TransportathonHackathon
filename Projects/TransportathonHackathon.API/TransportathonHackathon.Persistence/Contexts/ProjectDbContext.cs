using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Persistence.Contexts
{
    public class ProjectDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverLicense> DriverLicenses { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Translate> Translates { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
            .HasOne(e => e.Company)
            .WithOne(e => e.AppUser)
            .HasForeignKey<Company>(e => e.AppUserId);

            builder.Entity<AppUser>()
            .HasOne(e => e.Customer)
            .WithOne(e => e.AppUser)
            .HasForeignKey<Customer>(e => e.AppUserId);

            builder.Entity<AppUser>()
            .HasOne(e => e.Driver)
            .WithOne(e => e.AppUser)
            .HasForeignKey<Driver>(e => e.AppUserId);

            builder.Entity<AppUser>()
           .HasOne(e => e.Carrier)
           .WithOne(e => e.AppUser)
           .HasForeignKey<Carrier>(e => e.AppUserId);

            builder.Entity<Driver>()
            .HasOne(e => e.DriverLicense)
            .WithOne(e => e.Driver)
            .HasForeignKey<DriverLicense>(e => e.DriverId);

            //builder.Entity<Language>()
            //.HasMany(l => l.Translates)
            //.WithOne(t => t.Language);

            //builder.Entity<Translate>()
            //.HasOne(l => l.Language)
            //.WithMany(t => t.Translates).HasForeignKey(l => l.LanguageId);


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
