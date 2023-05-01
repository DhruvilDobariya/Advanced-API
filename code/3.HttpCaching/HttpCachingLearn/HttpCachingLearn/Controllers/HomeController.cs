using HttpCachingLearn.Filters;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Threading;
using System.Web.Http;

namespace HttpCachingLearn.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [CacheFilter(TimeDuration = 40)]
        public IHttpActionResult Get()
        {
            // memory cache
            ObjectCache cache = MemoryCache.Default;
            string cacheKey = string.Empty;

            if (cache.Contains(cacheKey))
            {
                return Ok(cache.Get(cacheKey));
            }

            var states = GetStates();
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.UtcNow.AddSeconds(40);
            cache.Set(cacheKey, states, policy);
            return Ok(states);
        }

        private static Dictionary<string, string> GetStates()
        {
            Dictionary<string, string> states = new Dictionary<string, string>();
            states.Add("1", "Punjab");
            states.Add("2", "Assam");
            states.Add("3", "UP");
            states.Add("4", "AP");
            states.Add("5", "J&K");
            states.Add("6", "Odisha");
            states.Add("7", "Delhi");
            states.Add("9", "Karnataka");
            states.Add("10", "Bangalore");
            states.Add("21", "Rajesthan");
            states.Add("31", "Jharkhand");
            states.Add("41", "chennai");
            states.Add("51", "jammu");
            states.Add("61", "Bhubaneshwar");
            states.Add("71", "Delhi");
            states.Add("19", "Karnataka");

            Thread.Sleep(7000);

            return states;
        }
    }
}
