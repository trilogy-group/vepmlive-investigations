using System;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    internal class StepProcessor
    {
        private readonly Action<string> _logMessage;
        private readonly Action<string, string, int> _logMessageFormat;

        internal StepProcessor(
            Action<string> logMessage,
            Action<string, string, int> logMessageFormat)
        {
            _logMessage = logMessage;
            _logMessageFormat = logMessageFormat;
        }

        protected void LogMessage(string message)
        {
            _logMessage(message);
        }

        protected void LogMessage(string preFix, string message, int status)
        {
            _logMessageFormat(preFix, message, status);
        }
    }
}
