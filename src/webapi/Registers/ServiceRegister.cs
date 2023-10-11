using Core;
using Core.Services;

namespace webapi.Registers
{
    public static class ServicesRegister
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
