using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Core.Security.Jwt
{
    public interface ITokenHelper<TId> where TId : IEquatable<TId>
    {
        AccessToken CreateToken(IdentityUser<TId> user, IList<Claim> claims, IList<string> roles);
    }
}
