using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommand : IRequest<DeletedCommentResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid TransportRequestId { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CustomerClaim };
    }
}
