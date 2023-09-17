using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Create
{
    public class CreateCommentCommand : IRequest<CreatedCommentResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid TransportRequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Point { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CustomerClaim };
    }
}
