using DAL.Entities;

namespace DAL.Interfaces
{
	public interface IUserRepository
	{
        Task<IEnumerable<UserEntity>> GetAll(CancellationToken cancellationToken);
        Task<UserEntity?> GetById(int id, CancellationToken cancellationToken);
        Task<UserEntity?> Create(UserEntity userEntity, CancellationToken cancellationToken);
        Task Delete(UserEntity userEntity, CancellationToken cancellationToken);
        Task<UserEntity?> Update(UserEntity userEntity, CancellationToken cancellationToken);
    }
}