using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Shared.Events
{
    /// <summary>
    /// 产品库存扣减
    /// </summary>
    public class ProductStockDeductedEvent
    {
        public ProductStockDeductedEvent()
        { }

        public ProductStockDeductedEvent(string orderId, bool isSuccess, string message = null)
        {
            OrderId = orderId;
            IsSuccess = isSuccess;
            Message = message;
        }

        public string OrderId { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
