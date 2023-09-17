using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Delete
{
    public class DeleteDriverLicenseCommand : IRequest<DeletedDriverLicenseResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid DriverId { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CompanyClaim, ProjectClaimConstants.DriverClaim };
    }
}
