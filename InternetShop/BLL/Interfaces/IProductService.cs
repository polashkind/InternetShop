using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Interfaces
{
	public interface IProductService : IGenericService<ProductModel>
    {
        Task<IEnumerable<ProductModel>> GetByPrice(decimal price, CancellationToken cancellationToken);
    }
}

