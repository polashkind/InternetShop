using AutoMapper;
using BLL.Models;
using InternetShop.ViewModels.ProductViewModels;
using InternetShop.ViewModels.UserViewModels;

namespace InternetShop.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, UserModel>().ReverseMap();
            CreateMap<ChangeUserViewModel, UserModel>().ReverseMap();

            CreateMap<ProductViewModel, ProductModel>().ReverseMap();
            CreateMap<ChangeProductViewModel, ProductModel>().ReverseMap();
        }
    }
}
