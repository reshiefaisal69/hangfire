namespace LogDbCleanup.Configuration;

public class LogCleanupConfiguration
{

    public List<ApplicationLogConfig> Applications { get; set; } = new List<ApplicationLogConfig>();
}

public class ApplicationLogConfig
{
    public string Application { get; set; } = string.Empty;
    public List<LogTableConfig> LogTables { get; set; } = new List<LogTableConfig>();
}

public class LogTableConfig
{
    public string Table { get; set; } = string.Empty;
    public int ErrorLogsLifetime { get; set; }
    public int OtherLogsLifetime { get; set; }
}