using LogDbCleanup.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);

var serviceProvider = serviceCollection.BuildServiceProvider();
serviceProvider.SetupHangfire();
return;

static void ConfigureServices(IServiceCollection services)
{
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appSettings.json")
        .Build();

    services.AddSingleton<IConfiguration>(configuration);
    services.AddHangfireServices(configuration);
    services.AddApplicationServices();
}