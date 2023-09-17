using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Approve
{
    public class ApproveTransportRequestCommand : IRequest<ApproveTransportRequestResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CompanyClaim };
    }
}
