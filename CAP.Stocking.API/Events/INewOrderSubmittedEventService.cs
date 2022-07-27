using API.Shared.Events;
using API.Shared.Models;

namespace CAP.Stocking.API.Events
{
    public interface INewOrderSubmittedEventService
    {
        Task<EventData<ProductStockDeductedEvent>> DeductProductStock(EventData<NewOrderSubmittedEvent> eventData); 
    }
}
