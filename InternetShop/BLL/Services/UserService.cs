using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAll(cancellationToken);
        }

        public async Task<UserEntity?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _userRepository.GetById(id, cancellationToken);
        }

        public async Task<UserEntity?> Create(UserEntity userEntity, CancellationToken cancellationToken)
        {
            return await _userRepository.Create(userEntity, cancellationToken);
        }

        public async Task Delete(UserEntity userEntity, CancellationToken cancellationToken)
        {
            await _userRepository.Delete(userEntity, cancellationToken);
        }

        public async Task<UserEntity?> Update(UserEntity userEntity, CancellationToken cancellationToken)
        {
            return await _userRepository.Update(userEntity, cancellationToken);
        }
    }
}

