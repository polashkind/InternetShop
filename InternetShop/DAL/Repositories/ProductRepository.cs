using System.Linq;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
	{
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductEntity>> GetByPrice(decimal price, CancellationToken cancellationToken)
        {
            var productPrice = await _dbSet.AsNoTracking().Where(entity => entity.Price >= price).ToListAsync(cancellationToken);
            return productPrice;
        }
    }
}

