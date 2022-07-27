using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Shared.Models
{
    /// <summary>
    /// 消息追溯日志
    /// </summary>
    public class MsgTrackLog
    {
        public MsgTrackLog(string msgId)
        {
            MsgId = msgId;
            CreatedDate = DateTime.Now;
        }

        public string MsgId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
