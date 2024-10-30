using LikeButtonProject.Contracts;
using LikeButtonProject.LoggerService;

namespace LikeButtonProject.Extensions;
public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .WithMethods("POST", "GET")
            .AllowAnyHeader());
    });

    public static void ConfigureIISIntegration(this IServiceCollection services) => services.Configure<IISOptions>(options =>
    {

    });

    public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
}