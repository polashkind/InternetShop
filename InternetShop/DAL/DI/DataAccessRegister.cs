using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.DI
{
	public static class DataAccessRegister
	{
		public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<DatabaseContext>(context =>
			{
				context.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
			});
		}
	}
}

