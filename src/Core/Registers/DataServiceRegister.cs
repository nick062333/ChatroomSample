using Microsoft.Extensions.DependencyInjection;
using DataService.Service;
using DataService;
using Core.Services;

namespace Core.Registers
{
    public static class DataServiceRegister
    {
        public static void RegisterDataService(this IServiceCollection services)
        {
            services.AddScoped<IMessageLogDataService, MessageLogDataService>();
            services.AddScoped<IChatroomDataService, ChatroomDataService>();

            services.AddScoped<IUserDataService, UserDataService>();
            services.AddScoped<IMessageService, MessageService>();
        }
    }
}