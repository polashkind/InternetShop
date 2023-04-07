using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Mapper
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<UserEntity, UserModel>();
		}
	}
}

