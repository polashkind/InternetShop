using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
	public class BasketModel
	{
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal TotalBasketPrice { get; set; }
    }
}