using Microsoft.Extensions.DependencyInjection;
using DataService.Service;

namespace DataService.Registers
{
    public static class DataServiceRegister
    {
        public static void RegisterDataService(this IServiceCollection services)
        {
            services.AddScoped<IMessageLogService, MessageLogService>();
        }
    }
}