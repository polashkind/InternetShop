using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DAL.Repositories;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.DI
{
	public static class DataAccessRegister
	{
		public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped(typeof(IGenericRepository<UserEntity>), typeof(GenericRepository<UserEntity>));
            services.AddDbContext<DatabaseContext>(context =>
			{
				context.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
			});
		}
	}
}