using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Adapter.Registers
{
    public static class DatabaseRegister
    {
        public static void RegisterChatroomDatabase(this IServiceCollection services, string connectionSetting)
        {
            services.AddScoped<IDbConnection>(_ => new SqlConnection(connectionSetting));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            //services.AddDbContext<ChatroomDBContext>(options => options.UseSqlServer(connectionSetting));
        }
    }
}
