using Core;
using Core.Services;
using DataClass.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;
using Utility;

namespace webapi.Registers
{
    public static class ServicesRegister
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<AesEncryptionHelper>();
        }
    }
}
