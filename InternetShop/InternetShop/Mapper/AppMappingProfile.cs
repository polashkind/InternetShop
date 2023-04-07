using AutoMapper;
using DAL.Models;
using InternetShop.ViewModels.UserViewModels;

namespace InternetShop.Mapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserViewModel, UserModel>();
        }
    }
}

