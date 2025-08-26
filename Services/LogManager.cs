using Microsoft.Extensions.Logging;
using MultiOutputLogger.Interface;
using MultiOutputLogger.Loggers;
using MultiOutputLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogger = MultiOutputLogger.Interface.ILogger;
using LogLevel = MultiOutputLogger.Models.LogLevel;

namespace MultiOutputLogger.Services
{
    public class LogManager
    {
        private readonly List<ILogger> _allLogger;
        private readonly Dictionary<LogLevel, List<ILogger>> _policies;

        public LogManager(List<ILogger> loggers)
        {
            _allLogger = loggers;

            _policies = new Dictionary<LogLevel, List<ILogger>>();

            var policiesDefinition = new Dictionary<LogLevel, List<Type>>
    {
        { LogLevel.Info, new List<Type> { typeof(ConsoleLogger) } },
        { LogLevel.Warning, new List<Type> { typeof(ConsoleLogger), typeof(FileLogger) } },
        { LogLevel.Error, new List<Type> { typeof(ConsoleLogger), typeof(FileLogger), typeof(DatabaseLogger) } }
    };

            foreach (var policy in policiesDefinition)
            {
                var level = policy.Key;
                var allowedTypes = policy.Value;

                var loggersForLevel = _allLogger
                 .Where(logger => allowedTypes.Contains(logger.GetType()))
                 .ToList();

                _policies[level] = loggersForLevel;
            }
        }

        public void Log(string message, LogLevel level)
        {
            if (_policies.TryGetValue(level, out var loggersToExecute))
            {
                foreach (var logger in loggersToExecute)
                {
                    logger.Log(message, level);
                }
            }
        }
    }
}
