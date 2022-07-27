using CAP.Stocking.API.Models;

namespace CAP.Stocking.API.Services
{
    public interface IStockService
    {
        Task<IList<Stock>> GetAllStocks();
        Task<Stock> GetStock(string productId);
        Task CreateStock(Stock stock);
        Task UpdateStock(Stock stock);
    }
}
