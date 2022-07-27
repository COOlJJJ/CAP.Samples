using API.Shared.Events;
using API.Shared.Models;

namespace CAP.Ordering.API.Events
{
    public interface IProductStockDeductedEventService
    {
        Task MarkOrderStatus(EventData<ProductStockDeductedEvent> eventData);
    }
}
