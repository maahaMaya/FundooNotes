using System;
using System.Collections.Generic;
using System.Text;

namespace FundooLoggerService
{
    public interface ILoggerManager
    {
        void LogError(string message);
        void LogInfo(string message);
        void LogDebug(string message);
        void LogWarning(string message);
    }
}
