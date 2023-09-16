using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.WebAPI.Middlewares
{
    public class AddDefaultUserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AddDefaultUserMiddleware(RequestDelegate next, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _next = next;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            AppRole? role = await _roleManager.FindByNameAsync("Admin");
            AppUser? user = await _userManager.FindByNameAsync("admin");

            if (role is not null && user is not null)
            {
                bool isAdmin =
                    (await _userManager.GetRolesAsync(user)).Contains("Admin") &&
                    (await _userManager.GetClaimsAsync(user)).FirstOrDefault(e => e.Type == "UserType" && e.Value == "Admin") != null;
                if (isAdmin)
                {
                    await _next(context);
                    return;
                }
            }

            if (role is null)
            {
                IdentityResult result = await _roleManager.CreateAsync(new AppRole() { Name = "Admin" });
                if (!result.Succeeded) throw new Exception();
                role = await _roleManager.FindByNameAsync("Admin");
            }

            if (user is null)
            {
                IdentityResult result = await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                }, "Admin@123");

                if (!result.Succeeded) throw new Exception();
                user = await _userManager.FindByNameAsync("admin");
            }

            await _userManager.AddClaimAsync(user, new Claim("UserType", "Admin"));
            await _userManager.AddToRoleAsync(user, "Admin");

            await _next(context);
        }
    }
}
