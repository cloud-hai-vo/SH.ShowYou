using System.Runtime.Caching;

namespace SH.ShowYou.Core.Helpers
{
    public class CacheHelper
    {
        public static void Add(string key, object value)
        {
            var cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.NotRemovable
            };

            cache.Add(key, value, policy);
        }

        public static bool Exist(string key) => MemoryCache.Default[key] != null;

        public static T Get<T>(string key) where T : class
        {
            if (Exist(key))
            {
                var cache = MemoryCache.Default;
                return (T)cache[key];
            }

            return default(T);
        }
    }
}