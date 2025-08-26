using MultiOutputLogger.Interface;
using MultiOutputLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiOutputLogger.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly string _Directory = "log";
        private static readonly object _lock = new object();


        public FileLogger()
        {
            if (!Directory.Exists(_Directory))
            {
                Directory.CreateDirectory(_Directory);
            }
        }

        public void Log(string message, LogLevel logLevel)
        {
            string LogFileName = $"{logLevel.ToString().ToLower()}.log";
            string filePath = Path.Combine(_Directory, LogFileName);
            string logMessage = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] [{logLevel}] {message}";
            lock (_lock)
            {
                File.AppendAllText(filePath, logMessage + Environment.NewLine);
            }
        }
    }
}
