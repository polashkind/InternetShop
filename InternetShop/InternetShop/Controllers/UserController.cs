using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using DAL.Models;
using InternetShop.ViewModels.UserViewModels;
using AutoMapper;

namespace InternetShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken)
        {
            var users = _mapper.Map<List<UserModel>>(await _userService.GetAll(cancellationToken));
            return users;
        }

        [HttpGet("{id}")]
        public async Task<UserModel?> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            return await _userService.GetById(id, cancellationToken);
        }

        [HttpPost]
        public async Task<UserModel?> PostUser([FromBody] UserViewModel userViewModel, CancellationToken cancellationToken)
        {
            return await _userService.Create(_mapper.Map<UserModel>(userViewModel), cancellationToken);
        }

        [HttpDelete("{id}")]
        public async ValueTask Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _userService.Delete(id, cancellationToken);
        }

        [HttpPut]
        public async Task<UserModel?> Update([FromBody] UserViewModel userViewModel, CancellationToken cancellationToken)
        {
            return await _userService.Update(_mapper.Map<UserModel>(userViewModel), cancellationToken);
        }
    }
}