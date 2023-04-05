using Microsoft.Extensions.DependencyInjection;
using BLL.Services;
using BLL.Interfaces;

namespace BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
