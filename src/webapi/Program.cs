using Adapter.Registers;
using Microsoft.EntityFrameworkCore;
using Utility.Registers;
using webapi.Hubs;
using webapi.Registers;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen();

builder.Services.RegisterHub();
builder.Services.RegisterCors();
builder.Services.RegisterServices();

// builder.Logging.ClearProviders();
// builder.Logging.AddConsole();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole(); // 選擇控制台作為日誌輸出
});

builder.Services.RegisterChatroomDatabase(builder.Configuration.GetConnectionString("ChatroomDBContext")!);

builder.Services.AddJwtAuthentication((option) => { 
    option.Issuer = configuration.GetValue<string>("JwtSettings:Issuer")!;
    option.SignKey = configuration.GetValue<string>("JwtSettings:SignKey")!;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(CorsRegister.HubClienOriginsPolicyName);
app.MapControllers();
app.MapHub<NotificationHub>("/hub/notification");

// app.Use(async (context, next) =>
// {
//     var bearerToken = context.Request.Query["access_token"].ToString();

//     if (!String.IsNullOrEmpty(bearerToken))
//         context.Request.Headers.TryAdd("Authorization", "Bearer " + bearerToken);

//     await next();
// });

app.Run();