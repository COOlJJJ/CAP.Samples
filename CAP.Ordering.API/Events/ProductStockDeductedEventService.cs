using API.Shared.Events;
using API.Shared.Models;
using CAP.Ordering.API.Models;
using CAP.Ordering.API.Services;
using DotNetCore.CAP;

namespace CAP.Ordering.API.Events
{
    public class ProductStockDeductedEventService : IProductStockDeductedEventService, ICapSubscribe
    {
        private readonly IOrderService _orderService;

        public ProductStockDeductedEventService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// 这边就是CallBackName的Topic订阅，做一些补偿事务和确认。
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        [CapSubscribe(name: EventNameConstants.TOPIC_STOCK_DEDUCTED, Group = EventNameConstants.GROUP_STOCK_DEDUCTED)]
        public async Task MarkOrderStatus(EventData<ProductStockDeductedEvent> eventData)
        {
            if (eventData == null || eventData.MessageBody == null)
                return;

            var order = await _orderService.GetOrder(eventData.MessageBody.OrderId);
            if (order == null)
                return;

            if (eventData.MessageBody.IsSuccess)
            {
                order.Status = OrderStatus.Succeed;
                // Todo: 一些额外的逻辑
            }
            else
            {
                order.Status = OrderStatus.Failed;
                // Todo: 一些额外的逻辑
            }

            await _orderService.UpdateOrder(order);
        }
    }
}
