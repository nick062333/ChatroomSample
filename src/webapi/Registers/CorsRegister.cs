namespace webapi.Registers
{
    public static class CorsRegister
    {
        public const string HubClienOriginsPolicyName = "_HubClientOriginsPolicyName";

        public static void RegisterCors(this IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: HubClienOriginsPolicyName,
                    policy =>
                    {
                        policy
                        .WithOrigins("https://localhost:5173", "http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });
        }
    }
}
