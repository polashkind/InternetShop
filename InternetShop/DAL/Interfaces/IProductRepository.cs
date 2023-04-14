using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces
{
	public interface IProductRepository : IGenericRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>?> GetByPrice(decimal price, CancellationToken cancellationToken);
    }
}

