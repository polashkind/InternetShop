using DAL.Entities;

namespace DAL.Interfaces
{
	public interface IUserRepository
	{
        Task<IEnumerable<UserEntity>> GetAll(CancellationToken cancellationToken);
        Task<UserEntity?> GetById(int Id);
        void Create(UserEntity entity);
        Task<UserEntity?> PostUser(UserEntity userEntity);
        Task<UserEntity?> Delete(int id);
        Task<UserEntity?> Update(UserEntity userEntity);
    }
}

