using Hangfire;
using LogDbCleanup.Configuration;
using LogDbCleanup.Services;
using LogDbCleanup.Services.CabPortal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class HangfireSetup
{
    public static void SetupHangfire(this IServiceProvider serviceProvider)
    {
        GlobalConfiguration.Configuration.UseSqlServerStorage(
            serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("JobsDb"));

        using (var server = new BackgroundJobServer())
        {
            // Create a scope to resolve services
            using (var scope = serviceProvider.CreateScope())
            {
                var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
                var backgroundJobClient = scope.ServiceProvider.GetService<IBackgroundJobClient>();

                // Retrieve configuration or any other necessary services
                var config = scope.ServiceProvider.GetRequiredService<LogCleanupConfiguration>();

                // Schedule jobs
                recurringJobManager.AddOrUpdate<ErrorsLogCleanUpService>(
                    "LogCleanUp",
                    (x) => x.Execute(),
                    Cron.Monthly,
                    new RecurringJobOptions());
            }
        }
    }
}