using Microsoft.Extensions.Logging;
using MultiOutputLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogLevel = MultiOutputLogger.Models.LogLevel;
using ILogger = MultiOutputLogger.Interface.ILogger;

namespace MultiOutputLogger.Loggers
{
    public class DatabaseLogger : ILogger
    {
        private readonly LoggingDbContext _context;

        public DatabaseLogger(LoggingDbContext context)
        {
            _context = context;
        }
        public void Log(string message, LogLevel logLevel)
        {
            var log = new Log
            {
                Level = logLevel.ToString(),
                Message = message,
                CreatedAt = DateTime.Now
            };

            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}
