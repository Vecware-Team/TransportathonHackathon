using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Delete
{
    public class DeleteCompanyCommand : IRequest<DeletedCompanyResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid AppUserId { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CompanyClaim };
    }
}
