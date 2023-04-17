using System;
namespace BLL.Interfaces
{
	public interface IGenericService<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken);
        Task<TModel?> GetById(int id, CancellationToken cancellationToken);
        Task<TModel?> Create(TModel model, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<TModel> Update(TModel model, CancellationToken cancellationToken);
    }
}

