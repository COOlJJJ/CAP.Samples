using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Shared.Utils.MsgTracker.Microsoft.Extensions.DependencyInjection
{
    public static class MsgTrackerServiceCollectionExtensions
    {
        public static void AddMsgTracker(this IServiceCollection services)
        {
            services.AddSingleton<IMsgTracker, RedisMsgTracker>();
        }
    }
}
