using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Shared.Utils.CacheClient
{
    public interface IRedisCacheClient
    {
        Task<bool> SetAsync(string key, object value, int? expireSeconds = null);

        Task<string> GetAsync(string key);

        Task<T> GetAsync<T>(string key);

        Task<IList<T>> GetFilteredListAsync<T>(string pattern);

        Task<bool> DeleteAsync(params string[] keys);

        Task<long> IncByAsync(string key, long value = 1);

        Task<T> Lock<T>(string key, Func<Task<T>> func, int expire = 60);

        Task<bool> Unlock(object redisClientLock);
    }
}
