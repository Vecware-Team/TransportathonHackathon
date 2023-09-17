using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using Core.Security.Constants;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Delete
{
    public class DeleteLanguageCommand : IRequest<DeletedLanguageResponse>, ITransactionalRequest, ICacheRemoverRequest, ISecuredRequest
    {
        public Guid Id { get; set; }

        public string? CacheKey => "GetListLanguageQuery";
        public string? CacheGroupKey => "GetListLanguageQueryGroup";
        public bool BypassCache => false;

        public string[] Roles => new string[] { RoleConstants.Admin };
        public Claim[] Claims => new Claim[] { ClaimConstants.AdminClaim };
    }
}
