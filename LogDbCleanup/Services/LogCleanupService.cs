using Dapper;
using LogDbCleanUp.Configuration;
using LogDbCleanUp.Data.Persistence;

namespace LogDbCleanUp.Services;
public class LogCleanupService
{
    private readonly LogCleanUpConfiguration _config;
    private readonly DapperContext _context;

    public LogCleanupService(LogCleanUpConfiguration config, DapperContext context)
    {
        _config = config;
        _context = context;
    }

    public async Task Execute()
    {
        using var connection = _context.CreateConnection();
        foreach (var application in _config.Applications)
        {
            await Console.Out.WriteLineAsync($"Deleting logs for {application.Application}");
            await Console.Out.WriteLineAsync($"Total tables in {application.Application}: {application.LogTables.Count}");

            foreach (var table in application.LogTables)
            {
                try
                {
                    await Console.Out.WriteLineAsync($"Deleting logs for table {table.Table}");

                    var date = DateTime.UtcNow.AddDays(table.ErrorLogsLifetime * -1);
                    var query = $"DELETE FROM {table.Table} WHERE timestamp > @Date AND level = 4";
                    var parameters = new { Date = date };
                    await connection.ExecuteScalarAsync(query, parameters);

                    date = DateTime.UtcNow.AddDays(table.OtherLogsLifetime * -1);
                    query = $"DELETE FROM {table.Table} WHERE timestamp > @Date AND level != 4";
                    await connection.ExecuteScalarAsync(query, parameters);
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync($"Error deleting logs for table {table.Table}: {ex.Message}");
                }
            }
        }
    }
}

