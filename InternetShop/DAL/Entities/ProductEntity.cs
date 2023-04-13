using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
	public class ProductEntity
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Discount { get; set; }
    }
}

