using System.ComponentModel.DataAnnotations;

namespace CAP.Ordering.API.Models
{
    public class OrderDTO
    {
        [Required(ErrorMessage = "UserId is necessary!")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "ProductId is necessary!")]
        public string ProductId { get; set; }
        [Range(1, 9999, ErrorMessage = "Valid range is 1 to 9999!")]
        public int Quantity { get; set; }
    }
}
