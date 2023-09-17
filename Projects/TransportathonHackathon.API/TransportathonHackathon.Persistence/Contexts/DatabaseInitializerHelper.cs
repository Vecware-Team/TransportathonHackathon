using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Persistence.Contexts
{
    public static class DatabaseInitializerHelper
    {
        public static void Initialize(ModelBuilder builder)
        {
            AddAdminUser(builder);
            // AddTranslates(builder);
        }

        private static void AddAdminUser(ModelBuilder builder)
        {
            Guid ADMIN_ID = Guid.NewGuid();
            Guid ROLE_ID = Guid.NewGuid();

            builder.Entity<AppRole>().HasData(new AppRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

            var appUser = new AppUser
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumberConfirmed = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            appUser.PasswordHash = passwordHasher.HashPassword(appUser, "Admin@123");

            builder.Entity<AppUser>().HasData(appUser);

            builder.Entity<AppUserClaim>().HasData(new AppUserClaim
            {
                Id = 1,
                ClaimType = "UserType",
                ClaimValue = "Admin",
                UserId = ADMIN_ID,
            });

            builder.Entity<AppUserRole>().HasData(new AppUserRole
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
        private static void AddTranslates(ModelBuilder builder)
        {
            Guid languageIdTr = Guid.NewGuid();
            Guid languageIdEn = Guid.NewGuid();

            builder.Entity<Language>().HasData(new Language()
            {
                Id = languageIdTr,
                Code = "tr-Tr",
                GloballyName = "Turkish",
                LocallyName = "Türkçe",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            builder.Entity<Language>().HasData(new Language()
            {
                Id = languageIdEn,
                Code = "en-Us",
                GloballyName = "English",
                LocallyName = "English",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });

            builder.Entity<Translate>().HasData(new Translate()
            {
                Id = Guid.NewGuid(),
                LanguageId = languageIdTr,
                Key = "",
                Value = "",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
        }
    }
}
