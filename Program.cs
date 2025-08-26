using MultiOutputLogger.Interface;
using MultiOutputLogger.Loggers;
using MultiOutputLogger.Services;
using MultiOutputLogger.Models;

namespace MultiOutputLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new LoggingDbContext();

            var loggers = new List<ILogger>
        {
            new ConsoleLogger(),
            new FileLogger(),
            new DatabaseLogger(context)
        };
            var logManager = new LogManager(loggers);

            logManager.Log("Everything is running fine", LogLevel.Info);
            logManager.Log("Disk space is low", LogLevel.Warning);
            logManager.Log("Unhandled exception occurred!", LogLevel.Error);
        }
    }
}
