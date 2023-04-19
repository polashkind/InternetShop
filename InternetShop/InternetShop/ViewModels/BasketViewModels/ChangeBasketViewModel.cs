using System.ComponentModel.DataAnnotations;

namespace InternetShop.ViewModels.BasketViewModels
{
	public class ChangeBasketViewModel
	{
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal TotalBasketPrice { get; set; }
    }
}

