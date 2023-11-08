using System.Data;
using LogDbCleanUp.Configuration;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace LogDbCleanUp.Data.Persistence;
public class DapperContext
{
    private readonly ConnectionStringsConfiguration _config;
    
    public DapperContext(ConnectionStringsConfiguration config)
    {
        _config = config;
    }

    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_config.LogDbConnectionString);
}
