using System;
using EPMLiveCore.Infrastructure.Logging;

namespace EPMLiveCore.Infrastructure
{
    public interface ILogger : IDisposable
    {
        #region Operations (2) 

        void LogMessage(Exception exception, string component, LogKind kind = LogKind.Error);

        void LogMessage(string message, string component, LogKind kind, string details = null);

        #endregion Operations 
    }
}