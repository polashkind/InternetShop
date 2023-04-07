using AutoMapper;
using BLL.Models;
using InternetShop.ViewModels.UserViewModels;

namespace InternetShop.Mapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserModel, UserViewModel>();
        }
    }
}

