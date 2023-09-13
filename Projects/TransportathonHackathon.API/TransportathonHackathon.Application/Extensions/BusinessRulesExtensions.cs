using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.CrossCuttingConcerns.IoC;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
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
    }
}
