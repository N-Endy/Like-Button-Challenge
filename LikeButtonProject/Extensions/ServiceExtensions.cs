using AspNetCoreRateLimit;
using LikeButtonProject.Contracts;
using LikeButtonProject.LoggerService;
using LikeButtonProject.Repository;
using LikeButtonProject.Service;
using LikeButtonProject.Service.Contracts;
using Microsoft.EntityFrameworkCore;

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

    public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

    public static void ConfigureRateLimiting(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();
        services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
        services.AddInMemoryRateLimiting();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    }

}