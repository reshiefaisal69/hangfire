namespace LogDbCleanUp.Configuration;

public class ConnectionStringsConfiguration
{
    public string LogDbConnectionString { get; init; } = null!;
    
    public string JobsConnectionString { get; init; } = null!;

}