using Core;
using Core.Services;
using Utility;

namespace webapi.Registers
{
    public static class ServicesRegister
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IChatroomService, ChatroomService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<AesEncryptionHelper>();
        }
    }
}
