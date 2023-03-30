using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DAL.Repositories;
using DAL.Interfaces;

namespace DAL.DI
{
	public static class DataAccessRegister
	{
		public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddDbContext<DatabaseContext>(context =>
			{
				context.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
			});
		}
	}
}

