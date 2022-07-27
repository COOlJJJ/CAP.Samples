using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Shared.Utils.MsgTracker
{
    public interface IMsgTracker
    {
        Task<bool> HasProcessed(string msgId);
        Task MarkAsProcessed(string msgId);
    }
}
