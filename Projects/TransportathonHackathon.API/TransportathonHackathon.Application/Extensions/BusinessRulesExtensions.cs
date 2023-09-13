using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.CrossCuttingConcerns.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Application.Extensions
{
    public static class BusinessRulesExtensions
    {
        public static async Task CheckIfUserEmailorUserNameDuplicatedWhenInserting(this BaseBusinessRules rules, string email, string userName)
        {
            UserManager<AppUser> userManager = ServiceTool.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            AppUser? user = await userManager.FindByEmailAsync(email) ?? await userManager.FindByNameAsync(userName);

            if (user is not null)
                throw new BusinessException("User already exists");
        }

        public static async Task CheckIfUserIsNotOwnerTheObject(this BaseBusinessRules rules, Guid userId)
        {
            IHttpContextAccessor httpContextAccessor = ServiceTool.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
            UserManager<AppUser> userManager = ServiceTool.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            AppUser? user = await userManager.FindByIdAsync(userId.ToString());

            if (user is null)
                throw new BusinessException("User is not exists");

            if (httpContextAccessor.HttpContext.User is null || httpContextAccessor.HttpContext.User?.Claims is null)
                throw new UnauthorizedException();

            if (httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(e=>e.Type == ClaimTypes.NameIdentifier) is null)
                throw new UnauthorizedException();

            httpContextAccessor.HttpContext.User.Claims.ToList().ForEach(claim =>
            {
                if(claim.Type == ClaimTypes.NameIdentifier)
                    if(user.Id.ToString() != claim.Value)
                        throw new AuthorizationDeniedException();
            });
        }
    }
}
