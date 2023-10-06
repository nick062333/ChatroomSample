using Core;
using Core.Services;
using DataService;
using DataService.Service;

namespace webapi.Registers
{
    public static class ServicesRegister
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IChatService, ChatService>();

            services.AddScoped<IMessageLogService, MessageLogService>();
        }
    }
}
