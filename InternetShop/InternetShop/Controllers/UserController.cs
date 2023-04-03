using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using DAL.Context;
using DAL;
using DAL.Interfaces;

namespace InternetShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
	{
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<UserEntity>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAll(cancellationToken);
            return result;

        }
    }
}