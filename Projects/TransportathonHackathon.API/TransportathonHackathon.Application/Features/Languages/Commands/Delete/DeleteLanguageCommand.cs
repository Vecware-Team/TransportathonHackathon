using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Delete
{
    public class DeleteLanguageCommand : IRequest<DeletedLanguageResponse>, ITransactionalRequest, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string? CacheKey => "GetListLanguageQuery";

        public string? CacheGroupKey => "GetListLanguageQueryGroup";

        public bool BypassCache => false;
    }
}
