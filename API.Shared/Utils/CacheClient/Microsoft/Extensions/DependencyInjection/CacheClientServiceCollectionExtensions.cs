using API.Shared.Utils.CacheClient.Microsoft.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Shared.Utils.CacheClient.Microsoft.Extensions.DependencyInjection
{
    public static class CacheClientServiceCollectionExtensions
    {

        public static void AddRedisClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRedisClientSettings(configuration);
            services.AddSingleton<IRedisCacheClient, CSRedisCoreClient>();
        }

        public static void AddRedisClientSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var redisSettings = new RedisSettings();
            configuration.GetSection(nameof(RedisSettings)).Bind(redisSettings);

            // redis serveraddresses adapter
            if (string.IsNullOrWhiteSpace(redisSettings.Hosts) && redisSettings.SentinelHosts == null)
            {
                var serverAddressesStr = configuration["RedisClientOptions:SentinelHosts"];
                var serverAddresses = serverAddressesStr?.Split(',');
                redisSettings.SentinelHosts = serverAddresses ??
                    throw new ArgumentNullException("Redis SentinelHosts为空！");
            }

            services.AddSingleton<IRedisSettings>(redisSettings);
        }
    }
}
