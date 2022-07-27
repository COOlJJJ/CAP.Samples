using CAP.Ordering.API.Models;

namespace CAP.Ordering.API.Services
{
    public interface IOrderService
    {
        Task<IList<Order>> GetAllOrders();
        Task<Order> GetOrder(string orderId);
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
    }
}
