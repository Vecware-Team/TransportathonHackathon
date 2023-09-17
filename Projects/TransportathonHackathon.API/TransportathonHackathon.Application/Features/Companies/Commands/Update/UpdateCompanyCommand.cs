using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Update
{
    public class UpdateCompanyCommand : IRequest<UpdatedCompanyResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid AppUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CompanyClaim };
    }
}
