using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace PostManager.CL.Manager
{
    public  sealed class CacheManager : ICacheManager
    {
        private readonly MemoryCache _cache = new MemoryCache("PostManagerCache");
        private readonly CacheItemPolicy _cacheItemPolicy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
        };

        public IList<T> Get<T>()
        {
            var result = new List<T>();

            var cacheEnumerator = (IDictionaryEnumerator)((IEnumerable)_cache).GetEnumerator();

            while (cacheEnumerator.MoveNext())
                result.Add((T)cacheEnumerator.Value);

            return result;
        }

        public T Get<T>(string key)
        {
            return (T)_cache.Get(key);
        }

        public bool IsExist(string key)
        {
            return _cache.Contains(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Set<T>(string key, T value)
        {
            _cache.Set(key, value, _cacheItemPolicy);
        }
    }
}
