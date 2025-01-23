using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using MyShop.Application.Interfaces;

namespace MyShop.Infrastructure.Services;

public class CacheManager:ICacheManager
{
        private readonly IDistributedCache _distributedCache;
        public CacheManager(IDistributedCache distributedCache )
        {
            _distributedCache = distributedCache;
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            };
            await _distributedCache.SetStringAsync(key, serializedValue, options);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            try
            {
                var cachedValue = await _distributedCache.GetStringAsync(key);
                return cachedValue != null ? JsonSerializer.Deserialize<T>(cachedValue) : default;
            }
            catch (Exception exception)
            {
                return default;
            }
        }

        public async Task RemoveAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    
}