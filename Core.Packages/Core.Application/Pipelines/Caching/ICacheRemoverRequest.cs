namespace Core.Application.Pipelines.Caching
{
    public interface ICacheRemoverRequest
    {
        string? CacheKey { get; }
        string? CacheGroupKey { get; }
        bool BypassCache { get; }
    }
}
