using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Update
{
    public class UpdateLanguageCommand : IRequest<UpdatedLanguageResponse>, ITransactionalRequest, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string GloballyName { get; set; }
        public string LocallyName { get; set; }

        public string? CacheKey => "GetListLanguageQuery";

        public string? CacheGroupKey => "GetListLanguageQueryGroup";

        public bool BypassCache => false;
    }
}
