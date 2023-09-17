using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using Core.Security.Constants;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Delete
{
    public class DeleteTransportRequestCommand : IRequest<DeletedTransportRequestResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid Id { get; set; }

        public string[] Roles => new string[] { RoleConstants.Admin };
        public Claim[] Claims => new Claim[] { ClaimConstants.AdminClaim };
    }
}
