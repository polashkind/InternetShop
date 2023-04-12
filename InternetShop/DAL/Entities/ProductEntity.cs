using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
	public class ProductEntity
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        public int Quantity { get; set; } = 0!;
        [Required]
        public decimal Price { get; set; }
    }
}

