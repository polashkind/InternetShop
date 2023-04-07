using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
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
            IEnumerable<UserModel> result = await _userService.GetAll(cancellationToken);
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var user in result)
            {
                var userViewModel = _mapper.Map<UserViewModel>(user);
                userViewModels.Add(userViewModel);
            }
            return userViewModels;
        }

        [HttpGet("{id}")]
        public async Task<UserViewModel?> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserViewModel>(await _userService.GetById(id, cancellationToken));
            return user;
        }

        [HttpPost]
        public async Task<UserViewModel?> PostUser([FromBody] UserEntity userEntity, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserViewModel>(await _userService.Create(userEntity, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async ValueTask Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _userService.Delete(id, cancellationToken);
        }

        [HttpPut]
        public async Task<UserViewModel?> Update([FromBody] UserEntity userEntity, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserViewModel>(await _userService.Update(userEntity, cancellationToken));
        }
    }
}