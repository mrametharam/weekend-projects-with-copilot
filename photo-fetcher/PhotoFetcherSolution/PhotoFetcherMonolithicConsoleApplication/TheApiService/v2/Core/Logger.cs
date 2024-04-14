using System.Text;

namespace PhotoFetcherMonolithicConsoleApplication.TheApiService.v2.Core;

public class Logger
{
    StringBuilder _logEntries = new StringBuilder();

    public void LogInformation(string logEntry)
    {
        _logEntries.AppendLine(logEntry);
        Console.WriteLine(logEntry);
    }

    public void ClearLog() { 
        _logEntries.Clear();
    }

    public void PrintAndClearLog()
    {
        Console.WriteLine(_logEntries.ToString());
        _logEntries.Clear();
    }
}
