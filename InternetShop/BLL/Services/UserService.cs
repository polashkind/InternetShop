using BLL.Interfaces;
using BLL.Models;
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

        private UserModel ConvertToUserModel(UserEntity userEntity)
        {
            var userModel = new UserModel
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Address = userEntity.Address
            };

            return userModel;
        }

        public async Task<IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken)
        {
            IEnumerable<UserEntity> userEntities = await _userRepository.GetAll(cancellationToken);
            List<UserModel> userModels = new List<UserModel>();
            foreach (var user in userEntities)
            {
                userModels.Add(ConvertToUserModel(user));
            }
            return userModels;
        }

        public async Task<UserModel?> GetById(int id, CancellationToken cancellationToken)
        {
            return ConvertToUserModel(await _userRepository.GetById(id, cancellationToken));
        }

        public async Task<UserModel?> Create(UserEntity userEntity, CancellationToken cancellationToken)
        {
            return ConvertToUserModel(await _userRepository.Create(userEntity, cancellationToken));
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            UserEntity? user = await _userRepository.GetById(id, cancellationToken);

            await _userRepository.Delete(user, cancellationToken);
        }

        public async Task<UserModel?> Update(UserEntity userEntity, CancellationToken cancellationToken)
        {
            return ConvertToUserModel(await _userRepository.Update(userEntity, cancellationToken));
        }
    }
}

