using System.Security.Claims;

namespace Core.Security.Constants
{
    public static class ClaimConstants
    {
        public static Claim AdminClaim = new Claim(ClaimTypeConstants.UserType, ClaimValueConstants.Admin);
    }
}
