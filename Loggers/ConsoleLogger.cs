using MultiOutputLogger.Interface;
using MultiOutputLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiOutputLogger.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel logLevel)
        {
            Console.ForegroundColor = logLevel switch
            {
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Info => ConsoleColor.Green,
                _ => ConsoleColor.White
            };

            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] [{logLevel}] [{message}]");
            Console.ResetColor();
        }
    }
}
