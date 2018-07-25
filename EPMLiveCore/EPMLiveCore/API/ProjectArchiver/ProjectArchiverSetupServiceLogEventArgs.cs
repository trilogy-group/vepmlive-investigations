using System;

namespace EPMLiveCore.API.ProjectArchiver
{
    public class ProjectArchiverSetupServiceLogEventArgs : EventArgs
    {
        public const int Info = 0;

        public const int Skipped = 1;

        public const int Success = 2;

        public const int Error = -1;

        public int LogLevel { get; }

        public int LogScope { get; }

        public string Message { get; }

        public ProjectArchiverSetupServiceLogEventArgs(string message, int level, int scope)
        {
            Message = message;
            LogLevel = level;
            LogScope = scope;
        }
    }
}