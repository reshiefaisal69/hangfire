using Hangfire;
using LogDbCleanUp.Configuration;
using LogDbCleanUp.Data.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogDbCleanUp.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DapperContext>();
        
        LogCleanUpConfiguration logConfig = new();
        configuration.GetSection("LogConfigurations").Bind(logConfig);
        services.AddSingleton(logConfig);

        ConnectionStringsConfiguration efConfig = new();
        configuration.GetSection("ConnectionStrings").Bind(efConfig);
        services.AddSingleton(efConfig);
    }

    public static void AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfireServer();
        services.AddHangfire(x => x
            .UseSqlServerStorage(configuration.GetConnectionString("JobsConnectionString")));
    }
    
}