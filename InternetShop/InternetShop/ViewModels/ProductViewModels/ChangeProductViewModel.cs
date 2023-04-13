using System.ComponentModel.DataAnnotations;

namespace InternetShop.ViewModels.ProductViewModels
{
	public class ChangeProductViewModel
	{
        public string Name { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}

