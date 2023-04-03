using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public async Task<UserEntity?> GetById([FromQuery] int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(id, cancellationToken);
            return user;
        }

        [HttpPost]
        public async Task<UserEntity?> PostUser([FromBody] UserEntity userEntity, CancellationToken cancellationToken)
        {
            return await _userRepository.Create(userEntity, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async ValueTask Delete([FromQuery]int id, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetById(id, cancellationToken);
            
            await _userRepository.Delete(userEntity, cancellationToken);
        }

        [HttpPut]
        public async Task<UserEntity?> Update([FromBody] UserEntity userEntity, CancellationToken cancellationToken)
        {
            //var result = await _userRepository.GetById(userEntity.Id, cancellationToken);

            return await _userRepository.Update(userEntity, cancellationToken);
        }
    }
}