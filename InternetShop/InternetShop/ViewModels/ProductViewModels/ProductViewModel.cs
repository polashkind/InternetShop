using System.ComponentModel.DataAnnotations;

namespace InternetShop.ViewModels.ProductViewModels
{
	public class ProductViewModel
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}

