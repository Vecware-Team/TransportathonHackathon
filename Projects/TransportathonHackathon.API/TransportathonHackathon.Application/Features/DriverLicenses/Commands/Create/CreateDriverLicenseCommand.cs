using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Create
{
    public class CreateDriverLicenseCommand : IRequest<CreatedDriverLicenseResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Classes { get; set; }
        public bool IsNew { get; set; }
        public DateTime LicenseGetDate { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CompanyClaim, ProjectClaimConstants.DriverClaim };
    }
}
