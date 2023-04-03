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
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult?> PostUser(UserEntity userEntity)
        {
            return Ok(await _userRepository.PostUser(userEntity));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.Delete(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult?> UpdateEmployee(int id, UserEntity userEntity)
        {
            await _userRepository.GetById(id);
            return Ok(await _userRepository.Update(userEntity));
        }
    }
}