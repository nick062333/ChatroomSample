using System.Text.Json;
using Adapter.Registers;
using Core.Registers;
using DataClass;
using DataClass.Configs;
using DataClass.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Utility.Registers;
using webapi.Filters;
using webapi.Hubs;
using webapi.Registers;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    var configuration = builder.Configuration;

    builder.Services.Configure<AesEncryptionSettings>(configuration.GetSection("AesEncryptionSettings"));

    builder.Logging.ClearProviders();
    builder.Host.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console()
        );

    builder.Services.AddEndpointsApiExplorer();

    _ = builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ChatroomExceptionHandler>();
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        //配置api行為
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e =>  JsonSerializer.Deserialize<ValidationPropertyErrorObject>(e.ErrorMessage));
            
            var message = string.Empty;

            if(errors.Any())
                message = string.Join("\n", errors.Select(x => $"{x.ErrorMessage}").ToArray());

            return new OkObjectResult(new ResponseBase(message, ChatroomStatusCode.DataVerificationFailed));
        };
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });


    builder.Services.AddHttpContextAccessor();

    builder.Services.AddSwaggerGen();

    builder.Services.RegisterHub();
    builder.Services.RegisterCors();
    builder.Services.RegisterServices();
    builder.Services.RegisterDataService();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.RegisterValidator();

    builder.Services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.AddConsole(); // 選擇控制台作為日誌輸出
    });

    builder.Services.RegisterChatroomDatabase(builder.Configuration.GetConnectionString("ChatroomDBContext")!);

    builder.Services.AddJwtAuthentication((option) => {
        option.Issuer = configuration.GetValue<string>("JwtSettings:Issuer")!;
        option.SignKey = configuration.GetValue<string>("JwtSettings:SignKey")!;
    });

    builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizationMiddlewareResultHandler>();

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseMiddleware<ExceptionMiddleware>();

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
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occurred during bootstrapping");
}
finally
{
    Log.CloseAndFlush();
}

