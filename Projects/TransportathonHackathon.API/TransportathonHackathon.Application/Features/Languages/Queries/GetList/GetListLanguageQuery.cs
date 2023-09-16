using Core.Application.Pipelines.Caching;
using MediatR;

namespace TransportathonHackathon.Application.Features.Languages.Queries.GetList
{
    public class GetListLanguageQuery : IRequest<List<GetListLanguageResponse>>, ICachableRequest
    {
        public string CacheKey { get; set; } = "GetListLanguageQuery";

        public string? CacheGroupKey { get; set; } = "GetListLanguageQueryGroup";

        public bool BypassCache { get; set; } = false;

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
