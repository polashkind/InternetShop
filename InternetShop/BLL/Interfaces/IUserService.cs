using BLL.Models;
using DAL.Entities;

namespace BLL.Interfaces
{
	public interface IUserService
	{
        Task<IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken);
        Task<UserModel?> GetById(int Id, CancellationToken cancellationToken);
        Task<UserModel?> Create(UserEntity userEntity, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<UserModel?> Update(UserEntity userEntity, CancellationToken cancellationToken);
    }
}

