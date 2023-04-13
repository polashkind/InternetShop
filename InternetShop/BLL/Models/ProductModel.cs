using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
	public class ProductModel
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public decimal PriceWithDiscount { get; set; }
    }
}

