using Microsoft.AspNetCore.SignalR;

namespace webapi.Registers
{
    public static class HubRegister
    {
        public static void RegisterHub(this IServiceCollection services) 
        {
            services.AddSingleton<HubFilter>();

            // builder.Services.AddConnections();

            //https://github.com/MessagePack-CSharp/MessagePack-CSharp
            services.AddSignalR(hubOptions => { 
                hubOptions.AddFilter<HubFilter>(); 
            })
            .AddMessagePackProtocol();
        }
    }
}
