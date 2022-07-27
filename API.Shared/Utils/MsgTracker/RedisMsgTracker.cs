using API.Shared.Models;
using API.Shared.Utils.CacheClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Shared.Utils.MsgTracker
{
    public class RedisMsgTracker : IMsgTracker
    {
        private const string KEY_PREFIX = "msgtracker:"; // 默认Key前缀
        private const int DEFAULT_CACHE_TIME = 60 * 60 * 24 * 3; // 默认缓存时间为3天，单位为秒
        private readonly IRedisCacheClient _redisCacheClient;

        public RedisMsgTracker(IRedisCacheClient redisCacheClient)
        {
            _redisCacheClient = redisCacheClient ?? throw new ArgumentNullException("RedisClient未初始化");
        }

        public async Task<bool> HasProcessed(string msgId)
        {
            var msgRecord = await _redisCacheClient.GetAsync<MsgTrackLog>($"{KEY_PREFIX}{msgId}");
            if (msgRecord == null)
                return false;

            return true;
        }

        public async Task MarkAsProcessed(string msgId)
        {
            var msgRecord = new MsgTrackLog(msgId);
            await _redisCacheClient.SetAsync($"{KEY_PREFIX}{msgId}", msgRecord, DEFAULT_CACHE_TIME);
        }
    }
}
