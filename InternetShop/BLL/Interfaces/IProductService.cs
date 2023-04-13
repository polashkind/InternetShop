using BLL.Models;

namespace BLL.Interfaces
{
	public interface IProductService
	{
        Task<IEnumerable<ProductModel>> GetAll(CancellationToken cancellationToken);
        Task<ProductModel?> GetById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ProductModel>> GetByPrice(decimal price, CancellationToken cancellationToken);
        Task<ProductModel?> Create(ProductModel productModel, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<ProductModel?> Update(ProductModel productModel, CancellationToken cancellationToken);
    }
}

