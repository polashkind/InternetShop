﻿using AutoMapper;
using BLL.Models;
using InternetShop.ViewModels.UserViewModels;

namespace InternetShop.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, UserModel>().ReverseMap();
        }
    }
}
