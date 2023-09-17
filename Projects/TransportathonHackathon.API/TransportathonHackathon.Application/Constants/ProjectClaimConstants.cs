using Core.Security.Constants;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Constants
{
    public static class ProjectClaimConstants
    {
        public static Claim CompanyClaim = new Claim(ClaimTypeConstants.UserType, "Company");
        public static Claim CustomerClaim = new Claim(ClaimTypeConstants.UserType, "Customer");
        public static Claim DriverClaim = new Claim(ClaimTypeConstants.UserType, "Driver");
        public static Claim CarrierClaim = new Claim(ClaimTypeConstants.UserType, "Carrier");
    }
}
