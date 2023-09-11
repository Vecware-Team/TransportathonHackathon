using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Core.Application.Pipelines.Caching
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICachableRequest
    {
        private readonly CacheSettings _cacheSettings;
        private readonly IDistributedCache _cache;

        public CachingBehavior(IDistributedCache cache, IConfiguration configuration)
        {
            _cacheSettings = configuration.GetSection("CacheSettings").Get<CacheSettings>() ?? throw new InvalidOperationException();
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request.BypassCache)
                return await next();

            TResponse response;
            byte[]? cachedResponse = await _cache.GetAsync(request.CacheKey, cancellationToken);

            if (cachedResponse != null)
                response = JsonSerializer.Deserialize<TResponse>(Encoding.Default.GetString(cachedResponse));
            else
                response = await GetResponseAndAddToCache(request, next, cancellationToken);

            return response;
        }

        private async Task<TResponse?> GetResponseAndAddToCache(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response = await next();
            TimeSpan slidingExpiration = request.SlidingExpiration ?? TimeSpan.FromDays(_cacheSettings.SlidingExpiration);
            DistributedCacheEntryOptions cacheOptions = new DistributedCacheEntryOptions() { SlidingExpiration = slidingExpiration };

            byte[] serializedData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response));

            await _cache.SetAsync(request.CacheKey, serializedData, cacheOptions, cancellationToken);

            if (request.CacheGroupKey != null)
                await AddCacheKeyToGroup(request, slidingExpiration, cancellationToken);

            return response;
        }

        private async Task AddCacheKeyToGroup(TRequest request, TimeSpan slidingExpiration, CancellationToken cancellationToken)
        {
            byte[]? cacheGroup = await _cache.GetAsync(key: request.CacheGroupKey!, cancellationToken);
            HashSet<string> cacheKeysInGroup;

            if (cacheGroup != null)
            {
                cacheKeysInGroup = JsonSerializer.Deserialize<HashSet<string>>(Encoding.Default.GetString(cacheGroup))!;
                if (!cacheKeysInGroup.Contains(request.CacheKey))
                    cacheKeysInGroup.Add(request.CacheKey);
            }
            else
            {
                cacheKeysInGroup = new HashSet<string>(new[] { request.CacheKey });
            }

            byte[] newCacheGroup = JsonSerializer.SerializeToUtf8Bytes(cacheKeysInGroup);

            byte[]? cacheGroupSlidingExpirationCache = await _cache.GetAsync(
                key: $"{request.CacheGroupKey}SlidingExpiration",
                cancellationToken
            );

            int? cacheGroupSlidingExpirationValue = null;
            if (cacheGroupSlidingExpirationCache != null)
                cacheGroupSlidingExpirationValue = Convert.ToInt32(Encoding.Default.GetString(cacheGroupSlidingExpirationCache));

            if (cacheGroupSlidingExpirationValue == null || slidingExpiration.TotalSeconds > cacheGroupSlidingExpirationValue)
                cacheGroupSlidingExpirationValue = Convert.ToInt32(slidingExpiration.TotalSeconds);

            byte[] serializeCachedGroupSlidingExpirationData = JsonSerializer.SerializeToUtf8Bytes(cacheGroupSlidingExpirationValue);

            DistributedCacheEntryOptions cacheOptions =
                new() { SlidingExpiration = TimeSpan.FromSeconds(Convert.ToDouble(cacheGroupSlidingExpirationValue)) };

            await _cache.SetAsync(key: request.CacheGroupKey!, newCacheGroup, cacheOptions, cancellationToken);

            await _cache.SetAsync(
                key: $"{request.CacheGroupKey}SlidingExpiration",
                serializeCachedGroupSlidingExpirationData,
                cacheOptions,
                cancellationToken
            );
        }
    }
}
