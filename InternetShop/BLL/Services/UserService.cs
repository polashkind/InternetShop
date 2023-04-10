using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using DAL.Entities;
using BLL.Models;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken)
        {
            var users = _mapper.Map<IEnumerable<UserModel>>(await _userRepository.GetAll(cancellationToken));
            return users;
        }

        public async Task<UserModel?> GetById(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(id, cancellationToken);
            var mappedUser = _mapper.Map<UserModel>(user);
            return mappedUser;
        }

        public async Task<UserModel?> Create(UserModel userModel, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<UserEntity>(userModel);
            var result = await _userRepository.Create(mappedUser, cancellationToken);
            return _mapper.Map<UserModel>(result);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(id, cancellationToken);
            await _userRepository.Delete(user, cancellationToken);
        }

        public async Task<UserModel?> Update(UserModel userModel, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<UserEntity>(userModel);
            var user = await _userRepository.Update(mappedUser, cancellationToken);
            return _mapper.Map<UserModel>(user);
        }
    }
}

