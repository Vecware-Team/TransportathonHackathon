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
            AddTranslates(builder);
        }

        private static void AddAdminUser(ModelBuilder builder)
        {
            Guid ADMIN_ID = Guid.NewGuid();
            string ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
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
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            appUser.PasswordHash = passwordHasher.HashPassword(appUser, "Admin@123");

            builder.Entity<AppUser>().HasData(appUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID.ToString()
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
