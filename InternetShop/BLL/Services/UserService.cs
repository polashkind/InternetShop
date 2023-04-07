using BLL.Interfaces;
using DAL.Models;
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

        public async Task<IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAll(cancellationToken);
        }

        public async Task<UserModel?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _userRepository.GetById(id, cancellationToken);
        }

        public async Task<UserModel?> Create(UserModel userModel, CancellationToken cancellationToken)
        {
            return await _userRepository.Create(userModel, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            UserModel? user = await _userRepository.GetById(id, cancellationToken);

            await _userRepository.Delete(user, cancellationToken);
        }

        public async Task<UserModel?> Update(UserModel userModel, CancellationToken cancellationToken)
        {
            return await _userRepository.Update(userModel, cancellationToken);
        }
    }
}

