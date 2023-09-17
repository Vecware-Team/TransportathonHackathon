using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using Core.Security.Constants;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Delete
{
    public class DeleteTranslateCommand : IRequest<DeletedTranslateResponse>, ITransactionalRequest,ISecuredRequest
    {
        public Guid Id { get; set; }

        public string[] Roles => new string[] { RoleConstants.Admin };
        public Claim[] Claims => new Claim[] { ClaimConstants.AdminClaim };
    }
}
