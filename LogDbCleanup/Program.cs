using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using LogDbCleanUp.Extensions;
using LogDbCleanUp.HangfireConfig;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configure Hangfire services
builder.Services.AddHangfireServices(builder.Configuration);

// Configure your application services
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Set up Hangfire Dashboard
app.UseHangfireDashboard();

// Start the Hangfire server
var serviceProvider = app.Services;
using var hangfireServer = serviceProvider.SetupHangfire();

app.Run();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Add your application services
    services.AddApplicationServices(configuration);
}