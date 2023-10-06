using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Utility.Authentication;

namespace Utility.Registers
{
    public static class JwtRegister
    {
        public static void AddJwtAuthentication(this IServiceCollection services, Action<AuthData> option)
        {
            AuthData authData = new();
            option.Invoke(authData);
            VerifyAuthData(authData);

            services.AddSingleton<JwtHelpers>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                // 當驗證失敗時，回應標頭會包含 WWW-Authenticate 標頭，這裡會顯示失敗的詳細錯誤原因
                options.IncludeErrorDetails = true; // 預設值為 true，有時會特別關閉

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier,
                    RoleClaimType = ClaimTypes.Role,

                    // 一般我們都會驗證 Issuer
                    ValidateIssuer = true,
                    ValidIssuer = authData.Issuer,

                    // 通常不太需要驗證 Audience
                    ValidateAudience = false,
                    //ValidAudience = "JwtAuthDemo", // 不驗證就不需要填寫

                    // 一般我們都會驗證 Token 的有效期間
                    ValidateLifetime = true,

                    // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
                    ValidateIssuerSigningKey = false,

                    // "1234567890123456" 應該從 IConfiguration 取得
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authData.SignKey))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // SignalR 會將 Token 以參數名稱 access_token 的方式放在 URL 查詢參數裡
                        var accessToken = context.Request.Query["access_token"];

                        // 連線網址為 Hubs 相關路徑才檢查
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hub"))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization();
        }

        public static void VerifyAuthData(AuthData authData)
        {
            if (string.IsNullOrWhiteSpace(authData.Issuer))
                throw new ArgumentNullException(nameof(authData.Issuer));

            if (string.IsNullOrWhiteSpace(authData.SignKey))
                throw new ArgumentNullException(nameof(authData.SignKey));
        }
    }
}
