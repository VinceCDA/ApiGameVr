using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Interfaces.Logging
{
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception? ex = null);
        void LogDebug(string message);
    }
}
