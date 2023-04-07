using AutoMapper;
using DAL.Models;
using DAL.Entities;

namespace DAL.Mapper
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<UserModel, UserEntity>().ReverseMap();
		}
	}
}

