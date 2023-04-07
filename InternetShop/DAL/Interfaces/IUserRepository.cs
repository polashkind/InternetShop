using DAL.Models;

namespace DAL.Interfaces
{
	public interface IUserRepository
	{
        Task<IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken);
        Task<UserModel?> GetById(int Id, CancellationToken cancellationToken);
        Task<UserModel?> Create(UserModel userModel, CancellationToken cancellationToken);
        Task Delete(UserModel userModel, CancellationToken cancellationToken);
        Task<UserModel?> Update(UserModel userModel, CancellationToken cancellationToken);
    }
}