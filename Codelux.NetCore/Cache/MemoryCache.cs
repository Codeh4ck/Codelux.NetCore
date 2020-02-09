using System.Collections.Concurrent;

namespace Codelux.NetCore.Cache
{
    public class MemoryCache : ICache
    {
        private readonly ConcurrentDictionary<string, CachedItem> _cache;
        public int NumberOfItems => _cache.Count;

        public MemoryCache()
        {
            _cache = new ConcurrentDictionary<string, CachedItem>();
        }

        public void Flush()
        {
            _cache.Clear();
        }

        public bool Remove(string key)
        {
            return _cache.TryRemove(key, out CachedItem _);
        }

        public bool TryGet<T>(string key, out T t)
        {
            t = default(T);

            if (!_cache.TryGetValue(key, out var item)) return false;
            if (item.HasExpired) return false;

            t = (T) item.Value;

            return true;
        }

        public void Set<T>(string key, T t, ExpirationOptions expirationOptions)
        {
            if (expirationOptions == null) expirationOptions = ExpirationOptions.CreateWithNoExpiration();
            CachedItem item = new CachedItem(t, expirationOptions);

            _cache.AddOrUpdate(key, item, (k, existingItem) =>
            {
                CachedItem existing = new CachedItem(t, expirationOptions);
                return existing;
            });
        }

        public bool InsertIfNotExists<T>(string key, T value, ExpirationOptions expirationOptions)
        {
            if (expirationOptions == null) expirationOptions = ExpirationOptions.CreateWithNoExpiration();
            if (TryGet(key, out T t)) return false;

            Set(key, value, expirationOptions);
            return true;
        }

    }
}