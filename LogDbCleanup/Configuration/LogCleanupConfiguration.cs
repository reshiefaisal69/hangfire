namespace LogDbCleanUp.Configuration;

public class LogCleanUpConfiguration
{
    public List<ApplicationLogConfig> Applications { get; set; } = new List<ApplicationLogConfig>();
}

public class ApplicationLogConfig
{
    public string Application { get; set; } = String.Empty;

    public List<LogTableConfig> LogTables { get; set; } = new List<LogTableConfig>();
}

public class LogTableConfig
{
    public string Table { get; set; } = String.Empty;

    public int ErrorLogsLifetime { get; set; }

    public int OtherLogsLifetime { get; set; }
}
