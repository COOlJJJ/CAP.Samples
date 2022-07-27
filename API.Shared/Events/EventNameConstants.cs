using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Shared.Events
{
    /// <summary>
    /// 事件名称的常量
    /// </summary>
    public class EventNameConstants
    {
        public const string TOPIC_ORDER_SUBMITTED = "mall.order.placed";
        public const string TOPIC_STOCK_DEDUCTED = "mall.stock.deducted";

        public const string GROUP_ORDER_SUBMITTED = "mall.order.placed.consumers";
        public const string GROUP_STOCK_DEDUCTED = "mall.stock.deducted.consumers";
    }
}
