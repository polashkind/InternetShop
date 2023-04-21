using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
			Database.Migrate();
		}

		public DbSet<UserEntity> Users { get; set; }
		public DbSet<ProductEntity> Products { get; set; }
        public DbSet<BasketEntity> Baskets { get; set; }
        public DbSet<BasketItemEntity> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

			modelBuilder.Entity<BasketItemEntity>()
				.HasKey(bi => new { bi.BasketId, bi.ProductId });
			modelBuilder.Entity<BasketItemEntity>()
				.HasOne(bi => bi.Product)
				.WithMany(b => b.BasketItems)
				.HasForeignKey(bi => bi.ProductId);
            modelBuilder.Entity<BasketItemEntity>()
                .HasOne(bi => bi.Basket)
                .WithMany(b => b.BasketItems)
                .HasForeignKey(bi => bi.BasketId);

        }
    }
}

