using LogDbCleanup.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;

namespace LogDbCleanup.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<LogCleanupConfiguration>();
        }

        public static void AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(x => x
                .UseSqlServerStorage(configuration.GetConnectionString("JobsDb")));

            services.AddHangfireServer();
        }
    }
}