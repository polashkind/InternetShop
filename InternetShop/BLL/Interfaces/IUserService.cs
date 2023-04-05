using BLL.Models;
using DAL.Entities;

namespace BLL.Interfaces
{
	public interface IUserService
	{
        Task<IEnumerable<UserEntity>> GetAll(CancellationToken cancellationToken);
        Task<UserEntity?> GetById(int Id, CancellationToken cancellationToken);
        Task<UserEntity?> Create(UserEntity userEntity, CancellationToken cancellationToken);
        Task Delete(UserEntity userEntity, CancellationToken cancellationToken);
        Task<UserEntity?> Update(UserEntity userEntity, CancellationToken cancellationToken);
    }
}

