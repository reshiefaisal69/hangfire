using Hangfire;
using LogDbCleanUp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogDbCleanUp.HangfireConfig;

public static class Hangfire
{
    public static BackgroundJobServer SetupHangfire(this IServiceProvider serviceProvider)
    {
        GlobalConfiguration.Configuration.UseSqlServerStorage(
            serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("JobsConnectionString"));
        var server = new BackgroundJobServer();
        var scope = serviceProvider.CreateScope();
        var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
        
        recurringJobManager.AddOrUpdate<LogCleanupService>(
            "LogCleanupService",
            x => x.Execute(),
            Cron.Minutely(),
            new RecurringJobOptions());

        return server;
    }
}