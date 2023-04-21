using System;
namespace DAL.Entities
{
	public class BasketItemEntity
	{
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }

        public int BasketId { get; set; }
        public virtual BasketEntity Basket { get; set; }

        public int ProductId { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}

