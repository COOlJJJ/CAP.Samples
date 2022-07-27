using API.Shared.Utils.IdGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Shared.Models
{
    /// <summary>
    /// 事件数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventData<T> where T : class
    {
        public string Id { get; set; }

        public T MessageBody { get; set; }

        public DateTime CreatedDate { get; set; }

        public EventData(T messageBody)
        {
            MessageBody = messageBody;
            CreatedDate = DateTime.Now;
            Id = SnowflakeGenerator.Instance().GetId().ToString();
        }
    }
}
