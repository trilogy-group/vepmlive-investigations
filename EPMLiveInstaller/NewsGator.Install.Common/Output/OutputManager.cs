using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Threading;
using NewsGator.Install.Resources;

namespace NewsGator.Install.Common.Output
{
    [Serializable]
    public class OutputManager : IDisposable
    {
        #region Fields and Constants
        private string _logFormat = "{0} \r\n";
        private string _logFileNameFormat = "NewsGatorLog_{0}.log";
        private string _logEventSource = "NewsGator Social Sites Installer";
        private string _logEventStorage = "Application";
        private string _logExceptionFormat = "### Exception ###\r\nMessage:\r\n{0} \r\n\r\nDetails:\r\n{1} \r\n\r\nStack Trace:\r\n{2}";
        private string _logExceptionFileLoadFormat = "\r\n\r\nFile Name:\r\n{0} \r\n\r\nFusion Log:\r\n{1}";
        private string _logExceptionFileLoadDataFormat = "\r\n\r\nData:\r\nKey: '{0}' - Value: '{1}";
        private string _logExceptionInnerFormat = "\r\n\r\n### Inner Exception ###\r\n{0}";

        private bool _disposed = false;
        private bool _outputConsole = false;
        private bool _outputCmdlet = false;
        private bool _outputEventViewer = false;
        private bool _outputLogFile = false;

        [NonSerialized]
        private Cmdlet _cmdlet = null;
        private string _logFilePath = null;

        public long CountError { get; set; }
        public long CountWarning { get; set; }
        public long CountWrite { get; set; }

        private Collection<string> _errors = new Collection<string>();
        public Collection<string> Errors
        {
            get { return _errors; }
        }
        private Collection<string> _warnings = new Collection<string>();
        public Collection<string> Warnings
        {
            get { return _warnings; }
        }

        public string InterfaceStatusVerbose { get; set; }
        public string InterfaceStatusProgress { get; set; }
        public int InterfacePercent { get; set; }

        public EventHandler OnWriteOutput { get; set; }
        #endregion

        #region Constructors
        private void ConstructorDefaults()
        {
            this.InterfacePercent = 0;
            this.InterfaceStatusProgress = string.Empty;
            this.InterfaceStatusVerbose = string.Empty;
            this.CountError = 0;
            this.CountWarning = 0;
            this.CountWrite = 0;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public OutputManager(bool logFile = false, string logPath = null, bool isConsole = false)
        {
            ConstructorDefaults();
            if (logFile)
            {
                this._outputConsole = isConsole;
                this._outputCmdlet = false;
                this._outputEventViewer = true;
                this._outputLogFile = true;
                if (string.IsNullOrEmpty(logPath))
                    this.CreateLogFile();
                else
                    this.CreateLogFile(logPath);
            }
            else
            {
                this._outputConsole = isConsole;
                this._outputCmdlet = false;
                this._outputEventViewer = true;
                this._outputLogFile = false;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), CLSCompliant(false)]
        public OutputManager(Cmdlet cmdlet, bool logFile = false, string logPath = null)
        {
            ConstructorDefaults();
            this._cmdlet = cmdlet;
            if (logFile)
            {
                this._outputConsole = false;
                this._outputCmdlet = true;
                this._outputEventViewer = true;
                this._outputLogFile = true;
                if (string.IsNullOrEmpty(logPath))
                    this.CreateLogFile();
                else
                    this.CreateLogFile(logPath);
            }
            else
            {
                this._outputConsole = false;
                this._outputCmdlet = true;
                this._outputEventViewer = true;
                this._outputLogFile = false;
            }
        }
        #endregion

        #region Destructors
        ~OutputManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            //GC.Collect();
        }

        protected virtual void Dispose(bool disposing)
        {
            this._disposed = true;

            if (disposing)
            {
                this._cmdlet = null;
                this._errors = null;
                this._logEventSource = null;
                this._logEventStorage = null;
                this._logExceptionFileLoadDataFormat = null;
                this._logExceptionFileLoadFormat = null;
                this._logExceptionFormat = null;
                this._logExceptionInnerFormat = null;
                this._logFileNameFormat = null;
                this._logFilePath = null;
                this._logFormat = null;
                this._warnings = null;
                this.CountError = 0;
                this.CountWarning = 0;
                this.CountWrite = 0;
                this.InterfacePercent = 0;
                this.InterfaceStatusProgress = null;
                this.InterfaceStatusVerbose = null;
                this.OnWriteOutput = null;
            }
        }
        #endregion

        #region Public Methods
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2116:AptcaMethodsShouldOnlyCallAptcaMethods"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Management.Automation.Cmdlet.WriteVerbose(System.String)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        internal void WriteVerbose(string message, bool logOnly = false, DateTime? dateTime = null)
        {
            if (!this._disposed)
            {
                if (!dateTime.HasValue)
                    dateTime = DateTime.Now;

                this.CountWrite++;

                if (this._outputEventViewer)
                    this.WriteEventLog(message, EventLogEntryType.Information);

                if (this._outputConsole)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(message);
                }
                else
                {
                    var formattedOutput = string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.LogVerbose, dateTime.Value.ToString(), message);

                    if (this._outputLogFile && this._logFilePath != null)
                        this.WriteLogFile(formattedOutput);

                    if (!logOnly)
                    {
                        if (this._outputCmdlet && this._cmdlet != null)
                            this._cmdlet.WriteVerbose(dateTime.Value.ToString() + " - " + message);
                    }

                    this.InterfaceStatusVerbose = message;

                    if (OnWriteOutput != null)
                    {
                        if (message.IndexOf("ERROR: ", StringComparison.Ordinal) > -1)
                            OnWriteOutput(this, new OutputEventArgs(OutputType.Error, formattedOutput));
                        else if (message.IndexOf("WARNING: ", StringComparison.Ordinal) > -1)
                            OnWriteOutput(this, new OutputEventArgs(OutputType.Warning, formattedOutput));
                        else
                            OnWriteOutput(this, new OutputEventArgs(OutputType.Verbose, formattedOutput));
                    }
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2116:AptcaMethodsShouldOnlyCallAptcaMethods"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        internal void WriteError(string message, Exception exception, bool terminatingError = false, bool logOnly = false, DateTime? dateTime = null)
        {
            if (!this._disposed && exception != null)
            {
                if (!dateTime.HasValue)
                    dateTime = DateTime.Now;

                this.CountWrite++;

                this.CountError++;

                if (this._outputEventViewer)
                    this.WriteEventLog(ParseException(exception), EventLogEntryType.Error);

                if (this._outputConsole)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.ConsoleError, message + " : " + ParseException(exception)));
                }
                else
                {
                    if (this._outputLogFile && this._logFilePath != null)
                        this.WriteLogFile(string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.LogError, dateTime.Value.ToString(), ParseException(exception)));

                    if (!logOnly)
                    {
                        if (this._outputCmdlet && this._cmdlet != null)
                        {
                            if (terminatingError)
                                this._cmdlet.ThrowTerminatingError(new ErrorRecord(exception, message, ErrorCategory.NotSpecified, null));
                            else
                                this._cmdlet.WriteError(new ErrorRecord(exception, message, ErrorCategory.NotSpecified, null));
                        }
                    }

                    this.InterfaceStatusVerbose = string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.ConsoleError, message);
                    _errors.Add(this.InterfaceStatusVerbose);

                    if (OnWriteOutput != null)
                        OnWriteOutput(this, new OutputEventArgs(OutputType.Error, this.InterfaceStatusVerbose));
                }

                if ((!this._outputCmdlet) && terminatingError)
                    throw exception;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2116:AptcaMethodsShouldOnlyCallAptcaMethods"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Management.Automation.Cmdlet.WriteVerbose(System.String)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "NewsGator.Install.Common.Output.OutputManager.WriteEventLog(System.String,System.Diagnostics.EventLogEntryType)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        internal void WriteProgress(string activity, string description, int percent = -1, bool logOnly = false, DateTime? dateTime = null)
        {
            if (!this._disposed)
            {
                if (!dateTime.HasValue)
                    dateTime = DateTime.Now;

                this.CountWrite++;

                if (this._outputEventViewer)
                    this.WriteEventLog(activity + ": " + description, EventLogEntryType.Information);

                if (this._outputConsole)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.ConsoleProgess, activity, description));
                }
                else
                {
                    var formattedOutput = string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.LogProgress, dateTime.Value.ToString(), activity, description);

                    if (this._outputLogFile && this._logFilePath != null)
                        this.WriteLogFile(formattedOutput);

                    if (!logOnly)
                    {
                        if (this._outputCmdlet && this._cmdlet != null)
                        {
                            var progressRecord = new ProgressRecord(0, activity, description);

                            if (percent >= 0)
                                progressRecord.PercentComplete = percent;
                            progressRecord.RecordType = ProgressRecordType.Processing;
                            if (percent >= 100)
                                progressRecord.RecordType = ProgressRecordType.Completed;

                            this._cmdlet.WriteProgress(progressRecord);
                            this._cmdlet.WriteVerbose(dateTime.Value.ToString() + " - " + activity + " - " + description);
                        }
                    }

                    //this.InterfaceStatusProgress = string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.ConsoleProgess, activity, description);
                    this.InterfaceStatusProgress = activity;
                    this.InterfacePercent = percent != -1 ? percent : 0;

                    if (OnWriteOutput != null)
                        OnWriteOutput(this, new OutputEventArgs(OutputType.Progress, formattedOutput));
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2116:AptcaMethodsShouldOnlyCallAptcaMethods"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Management.Automation.Cmdlet.WriteWarning(System.String)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        internal void WriteWarning(string message, bool logOnly = false, DateTime? dateTime = null)
        {
            if (!this._disposed)
            {
                if (!dateTime.HasValue)
                    dateTime = DateTime.Now;

                this.CountWrite++;

                this.CountWarning++;

                if (this._outputEventViewer)
                    this.WriteEventLog(message, EventLogEntryType.Warning);

                if (this._outputConsole)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.ConsoleWarning, message));
                }
                else
                {
                    var formattedOutput = string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.LogWarning, dateTime.Value.ToString(), message);

                    if (this._outputLogFile && this._logFilePath != null)
                        this.WriteLogFile(formattedOutput);

                    if (!logOnly)
                    {
                        if (this._outputCmdlet && this._cmdlet != null)
                            this._cmdlet.WriteWarning(dateTime.Value.ToString() + " - " + message);
                    }

                    this.InterfaceStatusVerbose = string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.ConsoleWarning, message);
                    _warnings.Add(this.InterfaceStatusVerbose);

                    if (OnWriteOutput != null)
                        OnWriteOutput(this, new OutputEventArgs(OutputType.Warning, formattedOutput));
                }
            }
        }
        #endregion

        #region Private Methods
        private void CreateLogFile()
        {
            var path = Directory.GetCurrentDirectory() + "\\LOGS\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            this.CreateLogFile(path);
        }

        private void CreateLogFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                CreateLogFile();

            if (!path.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                path = path + "\\";

            this._logFilePath = path + string.Format(System.Globalization.CultureInfo.InvariantCulture, _logFileNameFormat, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss", CultureInfo.InvariantCulture));
            //File.Create(this._logFilePath);
            WriteLogFile(string.Format(System.Globalization.CultureInfo.CurrentCulture, Logging.LogHeader, DateTime.Now.ToString()));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void WriteLogFile(string logEntry)
        {
            logEntry = logEntry.Replace("\\r\\n", Environment.NewLine);
            if (this._outputLogFile)
            {
                if (this._logFilePath == null)
                {
                    CreateLogFile();
                }

                try
                {
                    File.AppendAllText(this._logFilePath, string.Format(System.Globalization.CultureInfo.CurrentCulture, _logFormat, logEntry));
                }
                catch
                {
                    Thread.Sleep(2000);
                    try
                    {
                        File.AppendAllText(this._logFilePath, string.Format(System.Globalization.CultureInfo.CurrentCulture, _logFormat, logEntry));
                    }
                    catch
                    {
                        WriteEventLog(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.UnableToAddEntryToLogFile, string.Format(System.Globalization.CultureInfo.CurrentCulture, _logFormat, logEntry)), EventLogEntryType.Warning);
                    }
                }
            }
        }

        private void WriteEventLog(string message, EventLogEntryType eventType)
        {
            if (!EventLog.SourceExists(this._logEventSource))
                EventLog.CreateEventSource(this._logEventSource, this._logEventStorage);

            // Event Log cannot handle messages much over 30k
            if (message.Length > 30000)
                message = message.Substring(0, 30000);

            EventLog.WriteEntry(this._logEventSource, message, eventType);
        }

        private string ParseException(Exception exception)
        {
            var exceptionString = string.Format(CultureInfo.InvariantCulture, _logExceptionFormat, exception.Message, exception.ToString(), exception.StackTrace);

            var fileLoadException = exception as FileLoadException;
            if (fileLoadException != null)
            {
                exceptionString += string.Format(CultureInfo.InvariantCulture, _logExceptionFileLoadFormat, fileLoadException.FileName, fileLoadException.FusionLog);
                if (fileLoadException.Data != null)
                {
                    foreach (DictionaryEntry entry in fileLoadException.Data)
                    {
                        exceptionString += string.Format(CultureInfo.InvariantCulture, _logExceptionFileLoadDataFormat, entry.Key, entry.Value);
                    }
                }
            }
            else
            {
                if (exception.Data != null)
                {
                    foreach (DictionaryEntry entry in exception.Data)
                    {
                        exceptionString += string.Format(CultureInfo.InvariantCulture, _logExceptionFileLoadDataFormat, entry.Key, entry.Value);
                    }
                }
            }

            if (exception.InnerException != null && exception != exception.InnerException)
                exceptionString += string.Format(CultureInfo.InvariantCulture, _logExceptionInnerFormat, ParseException(exception.InnerException));

            return exceptionString;
        }
        #endregion
    }
}
