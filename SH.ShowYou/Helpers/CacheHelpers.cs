using System;
using System.Web;
using System.Web.Caching;

namespace SH.ShowYou.Helpers
{
    public class CacheHelpers
    {
        public static void Add(string key, object value)
        {
            HttpContext.Current.Cache.Add(key, value, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public static bool Exist(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }

        public static T Get<T>(string key) where T : class
        {
            if (Exist(key))
            {
                return (T)HttpContext.Current.Cache.Get(key);
            }

            return default(T);
        }
    }
}