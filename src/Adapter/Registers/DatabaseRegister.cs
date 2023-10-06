using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Adapter.Registers
{
    public static class DatabaseRegister
    {
        public static void RegisterChatroomDatabase(this IServiceCollection services, string connectionSetting)
        {
            services.AddDbContext<ChatroomDBContext>(options => options.UseSqlServer(connectionSetting));
        }
    }
}
