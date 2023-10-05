using System.Security.Claims;
using System.Text;
using Adapter;
using DataClass.Configs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using webapi;
using webapi.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen();

// builder.Services.AddConnections();

//https://github.com/MessagePack-CSharp/MessagePack-CSharp
builder.Services.AddSignalR(hubOptions => {
    hubOptions.AddFilter<HubFilter>();
}).AddMessagePackProtocol();;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy
            .WithOrigins("https://localhost:5173", "http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); 
        });
});

builder.Services.AddSingleton<HubFilter>();

builder.Services.AddDbContext<ChatroomDBContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("ChatroomDBContext")));

builder.Services.Configure<ConnectionSettings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddSingleton<JwtHelpers>();

// builder.Services.AddSingleton<IUserIdProvider, JWTUserIdProvider>();



// builder.Services.AddDefaultIdentity<IdentityUser>(options =>
// { 
//     options.ClaimsIdentity.UserNameClaimType = "sub";
//     options.ClaimsIdentity.RoleClaimType = "role";
// });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            ValidIssuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer"),

            // 通常不太需要驗證 Audience
            ValidateAudience = false,
            //ValidAudience = "JwtAuthDemo", // 不驗證就不需要填寫

            // 一般我們都會驗證 Token 的有效期間
            ValidateLifetime = true,

            // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
            ValidateIssuerSigningKey = false,

            // "1234567890123456" 應該從 IConfiguration 取得
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:SignKey")))
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
 builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.Use(async (context, next) =>
// {
//     var bearerToken = context.Request.Query["access_token"].ToString();

//     if (!String.IsNullOrEmpty(bearerToken))
//         context.Request.Headers.TryAdd("Authorization", "Bearer " + bearerToken);

//     await next();
// });

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.MapHub<NotificationHub>("/hub/notification");

app.Run();