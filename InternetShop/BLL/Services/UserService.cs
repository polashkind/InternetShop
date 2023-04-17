using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using DAL.Entities;
using BLL.Models;
using DAL.Repositories;

namespace BLL.Services
{
    public class UserService : GenericService<UserModel, UserEntity>, IUserService
    {
        protected readonly IGenericRepository<UserEntity> _genericRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
    }
}

