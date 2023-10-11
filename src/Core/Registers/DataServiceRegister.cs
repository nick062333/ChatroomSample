using Microsoft.Extensions.DependencyInjection;
using DataService.Service;
using DataService;

namespace Core.Registers
{
    public static class DataServiceRegister
    {
        public static void RegisterDataService(this IServiceCollection services)
        {
            services.AddScoped<IMessageLogDataService, MessageLogDataService>();
            services.AddScoped<IUserDataService, UserDataService>();
        }
    }
}