﻿using Microsoft.Extensions.DependencyInjection;
using BLL.Services;
using BLL.Interfaces;
using DAL.DI;
using Microsoft.Extensions.Configuration;
using BLL.Models;
using DAL.Entities;

namespace BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddDataAccess(configuration);
        }
    }
}
