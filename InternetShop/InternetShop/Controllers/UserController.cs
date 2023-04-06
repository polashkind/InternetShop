using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using InternetShop.ViewModels.UserViewModels;

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

        private UserViewModel ConvertToUserViewModel(UserModel userModel)
        {
            var userViewModel = new UserViewModel
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Address = userModel.Address
            };

            return userViewModel;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAll(CancellationToken cancellationToken)
        {
            //var result = await _userService.GetAll(cancellationToken);
            //return result;

            IEnumerable<UserModel> result = await _userService.GetAll(cancellationToken);
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var user in result)
            {
                userViewModels.Add(ConvertToUserViewModel(user));
            }
            return userViewModels;
        }

        [HttpGet("{id}")]
        public async Task<UserViewModel?> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetById(id, cancellationToken);
            return ConvertToUserViewModel(user);
        }

        [HttpPost]
        public async Task<UserViewModel?> PostUser([FromBody] UserEntity userEntity, CancellationToken cancellationToken)
        {
            return ConvertToUserViewModel(await _userService.Create(userEntity, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async ValueTask Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _userService.Delete(id, cancellationToken);
        }

        [HttpPut]
        public async Task<UserViewModel?> Update([FromBody] UserEntity userEntity, CancellationToken cancellationToken)
        {
            return ConvertToUserViewModel(await _userService.Update(userEntity, cancellationToken));
        }
    }
}