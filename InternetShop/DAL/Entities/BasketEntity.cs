using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
	public class BasketEntity
	{
        public int Id { get; set; }
        [Required]
        public int ItemCount { get; set; }
        [Required]
        public decimal TotalBasketPrice { get; set; }

        public virtual ICollection<BasketItemEntity> BasketItems { get; set; }
    }
}

