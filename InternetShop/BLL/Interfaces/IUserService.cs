using BLL.Models;

namespace BLL.Interfaces
{
	public interface IUserService
	{
        Task<IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken);
        Task<UserModel?> GetById(int Id, CancellationToken cancellationToken);
        Task<UserModel?> Create(UserModel userModel, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<UserModel?> Update(UserModel userModel, CancellationToken cancellationToken);
    }
}

