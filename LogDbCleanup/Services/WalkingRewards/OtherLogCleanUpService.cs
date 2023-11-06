using LogDbCleanup.Configuration;

namespace LogDbCleanup.Services.WalkingRewards;

public class OtherLogCleanUpService
{
    private readonly string _connectionString;
    private readonly LogCleanupConfiguration _config;

    public OtherLogCleanUpService(LogCleanupConfiguration config)
    {
        _config = config;
    }

    public  async Task Execute()
    {
        // Implement the logic to connect to PostgreSQL and perform log cleanup
    }
}