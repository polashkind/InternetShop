using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UserModel, UserEntity>().ReverseMap();
            CreateMap<ProductModel, ProductEntity>().ReverseMap();
            CreateMap<BasketModel, BasketEntity>().ReverseMap();
        }
	}
}