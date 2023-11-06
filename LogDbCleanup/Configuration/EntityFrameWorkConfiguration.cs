namespace LogDbCleanup.Configuration;

public class EntityFrameWorkConfiguration
{
    public string LogDbConnectionString { get; init; } = null!;
    
    public string JobsConnectionString { get; init; } = null!;
}