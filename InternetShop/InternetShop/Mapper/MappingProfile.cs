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
            CreateMap<ChangeUserViewModel, UserModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => $"{src.FirstName}"))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => $"{src.LastName}"))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.Address}"))
                .ReverseMap();

            CreateMap<ProductViewModel, ProductModel>().ReverseMap();
            CreateMap<ChangeProductViewModel, ProductModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => $"{src.Quantity}"))
                .ReverseMap();
        }
    }
}
