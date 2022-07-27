using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Shared.Events
{
    /// <summary>
    /// 新订单提交事件
    /// </summary>
    public class NewOrderSubmittedEvent
    {
        public NewOrderSubmittedEvent()
        { }

        public NewOrderSubmittedEvent(string orderId, string productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
