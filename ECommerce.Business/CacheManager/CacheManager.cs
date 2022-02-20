using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.CacheManager
{
    public class CacheManager : ICacheManager
    {
        ObjectCache cache;
        /// <summary>
        /// 
        /// </summary>
        public CacheManager()
        {
            cache = MemoryCache.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="source"></param>
        /// <param name="duration"></param>
        public void Add<T>(string key, T source, int duration)
        {
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(duration) };
            cache.Add(key, source, policy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="source"></param>
        public void Add<T>(string key, T source)
        {
            int duration = 60 * 60 * 24;
            Add<T>(key, source, duration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            return cache.Contains(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return (T)cache.Get(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}
