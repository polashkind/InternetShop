using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
	public class BasketEntity
	{
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal To_pay { get; set; }
    }
}

