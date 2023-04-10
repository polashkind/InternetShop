using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Models;
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
        public async Task<IEnumerable<UserViewModel>> GetAll(CancellationToken cancellationToken)
        {
            var users = _mapper.Map<IEnumerable<UserViewModel>>(await _userService.GetAll(cancellationToken));
            return users;
        }

        [HttpGet("{id}")]
        public async Task<UserViewModel?> GetById([FromQuery] int id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetById(id, cancellationToken);
            var mappedUser = _mapper.Map<UserModel>(user);
            return _mapper.Map<UserViewModel>(mappedUser);
        }

        [HttpPost]
        public async Task<UserViewModel?> PostUser([FromBody] ChangeUserViewModel changeUserViewModel, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<UserModel>(changeUserViewModel);
            var result = await _userService.Create(mappedUser, cancellationToken);
            return _mapper.Map<UserViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async ValueTask Delete([FromQuery] int id, CancellationToken cancellationToken)
        {
            await _userService.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<UserViewModel?> Update([FromBody] ChangeUserViewModel changeUserViewModel, [FromQuery] int id, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<UserModel>(changeUserViewModel);
            mappedUser.Id = id;
            var result = await _userService.Update(mappedUser, cancellationToken);
            return _mapper.Map<UserViewModel>(result);
        }
    }
}