using DAL.Entities;

namespace DAL.Interfaces
{
	public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAll(CancellationToken cancellationToken);
        Task<ProductEntity?> GetById(int id, CancellationToken cancellationToken);
        Task<ProductEntity?> Create(ProductEntity productEntity, CancellationToken cancellationToken);
        Task Delete(ProductEntity productEntity, CancellationToken cancellationToken);
        Task<ProductEntity?> Update(ProductEntity productEntity, CancellationToken cancellationToken);
    }
}

