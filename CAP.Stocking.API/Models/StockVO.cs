using System;

namespace CAP.Stocking.API.Models
{
    public class StockVO
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
