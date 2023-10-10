using System.IO.IsolatedStorage;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Adapter.Adapters;

namespace Adapter.Registers
{
    public static class DatabaseRegister
    {
        public static void RegisterChatroomDatabase(this IServiceCollection services, string connectionSetting)
        {
            services.AddScoped<IDbConnection>(_ => new SqlConnection(connectionSetting));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IMessageLogAdapter, MessageLogAdapter>();  
            //services.AddDbContext<ChatroomDBContext>(options => options.UseSqlServer(connectionSetting));
        }
    }
}
