using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiOutputLogger.Models;

namespace MultiOutputLogger.Interface
{
    public interface ILogger
    {
        void Log(string message , LogLevel logLevel);
    }
}
