using System.Linq;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class ProductRepository : IProductRepository
	{
        protected readonly DatabaseContext _context;
        protected readonly DbSet<ProductEntity> _dbSet;


        public ProductRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<ProductEntity>();
        }

        public async Task<IEnumerable<ProductEntity>> GetAll(CancellationToken cancellationToken)
        {
            var productEntities = await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
            return productEntities;
        }

        public async Task<ProductEntity?> GetById(int id, CancellationToken cancellationToken)
        {
            var productEntity = await _dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            return productEntity;
        }

        public async Task<IEnumerable<ProductEntity>> GetByPrice(decimal price, CancellationToken cancellationToken)
        {
            var productPrice = await _dbSet.AsNoTracking().Where(entity => entity.Price >= price).ToListAsync();
            return productPrice;
        }

        public async Task<ProductEntity?> Create(ProductEntity productEntity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(productEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return productEntity;
        }

        public async Task Delete(ProductEntity productEntity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(productEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ProductEntity> Update(ProductEntity productEntity, CancellationToken cancellationToken)
        {
            _context.Entry(productEntity).State = EntityState.Modified;
            _dbSet.Update(productEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return productEntity;
        }


    }
}

