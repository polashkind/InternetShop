using System;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

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
            IEnumerable<UserEntity> userEntities = await _userRepository.GetAll(cancellationToken);
            List<UserModel> userModels = new List<UserModel>();
            foreach (var user in userEntities)
            {
                var userModel = _mapper.Map<UserModel>(user);
                userModels.Add(userModel);
            }
            return userModels;
        }

        public async Task<UserModel?> GetById(int id, CancellationToken cancellationToken)
        {
            var userModel = _mapper.Map<UserModel>(await _userRepository.GetById(id, cancellationToken));
            return userModel;
        }

        public async Task<UserModel?> Create(UserEntity userEntity, CancellationToken cancellationToken)
        {
            var userModel = _mapper.Map<UserModel>(await _userRepository.Create(userEntity, cancellationToken));
            return userModel;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            UserEntity? user = await _userRepository.GetById(id, cancellationToken);

            await _userRepository.Delete(user, cancellationToken);
        }

        public async Task<UserModel?> Update(UserEntity userEntity, CancellationToken cancellationToken)
        {
            var userModel = _mapper.Map<UserModel>(await _userRepository.Update(userEntity, cancellationToken));
            return userModel;
        }
    }
}

