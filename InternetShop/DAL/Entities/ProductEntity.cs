using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
	public class ProductEntity
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        public string Quantity { get; set; } = null!;
    }
}

