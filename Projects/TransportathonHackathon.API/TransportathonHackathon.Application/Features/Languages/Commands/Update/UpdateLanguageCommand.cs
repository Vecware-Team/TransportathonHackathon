using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using Core.Security.Constants;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Update
{
    public class UpdateLanguageCommand : IRequest<UpdatedLanguageResponse>, ITransactionalRequest, ICacheRemoverRequest, ISecuredRequest
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string GloballyName { get; set; }
        public string LocallyName { get; set; }

        public string? CacheKey => "GetListLanguageQuery";
        public string? CacheGroupKey => "GetListLanguageQueryGroup";
        public bool BypassCache => false;

        public string[] Roles => new string[] { RoleConstants.Admin };
        public Claim[] Claims => new Claim[] { ClaimConstants.AdminClaim };
    }
}
