using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;

namespace InternetShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _userService.GetAll(cancellationToken);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<UserModel?> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetById(id, cancellationToken);
            return user;
        }

        [HttpPost]
        public async Task<UserModel?> PostUser([FromBody] UserEntity userEntity, CancellationToken cancellationToken)
        {
            return await _userService.Create(userEntity, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async ValueTask Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _userService.Delete(id, cancellationToken);
        }

        [HttpPut]
        public async Task<UserModel?> Update([FromBody] UserEntity userEntity, CancellationToken cancellationToken)
        {
            return await _userService.Update(userEntity, cancellationToken);
        }
    }
}