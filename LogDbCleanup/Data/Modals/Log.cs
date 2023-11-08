using Hangfire.Logging;

namespace LogDbCleanUp.Data.Modals;

public class Log
{
    public string Message { get; set; } = null!;
    
    public string MessageTemplate { get; set; } = null!;
    
    public LogLevel Level { get; set; }

    public DateTime TimeStamp { get; set; }
    
    public string Exception { get; set; } = null!;
    
    public string LogEvent { get; set; } = null!;
}