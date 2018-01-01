using System;
using Microsoft.SharePoint.Administration;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace TimerService
{
    public abstract class ProcessorBase
    {
        protected static SPWebApplicationCollection GetWebApplications()
        {
            return SPWebService.ContentService.WebApplications;
        }
        private Object thisLock = new Object();

        protected struct RunnerData
        {
            public string cn;
            public DataRow dr;
        }
        
        private class WorkerThreads
        {
            private Task[] _arrWorkers;
            private int _maxThreads;
            public int MaxThreads {
                get { return _maxThreads; }
            }

            public WorkerThreads(int maxThreads)
            {
                _maxThreads = maxThreads;
                _arrWorkers = new Task[maxThreads];
            }

            public Task add(Action<RunnerData> action, RunnerData rd)
            {

                for (int i = 0; i < _maxThreads; i++)
                    if (_arrWorkers[i] != null)
                        if (_arrWorkers[i].IsCompleted)
                            _arrWorkers[i] = null;

                for (int i = 0; i < _maxThreads; i++)
                {
                    if (_arrWorkers[i] == null)
                    {
                        Task bw = Task.Run(() => { action(rd); });
                        _arrWorkers[i] = bw;
                        return bw;
                    }
                }
                return null;
            }

        }

        private WorkerThreads workingThreads = null;

        protected int MaxThreads {
            get { return workingThreads == null ? 0 : workingThreads.MaxThreads; }
        }

        protected bool startProcess(RunnerData rd)
        {
            try
            {
                Task bw = workingThreads.add(DoWork, rd);
                if (bw == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                logMessage("ERR", "STPR", ex.Message);
                return false;
            }
        }

        protected void logMessage(string type, string module, string message)
        {
            lock (thisLock)
            {
                DateTime dt = DateTime.Now;

                using (StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\" + LogName + "_" + dt.Year + dt.Month + dt.Day + ".log", true))
                {

                    swLog.WriteLine(DateTime.Now.ToString() + "\t" + type + "\t" + module + "\t" + message);

                }
            }
        }

        public virtual bool InitializeTask()
        {
            return InitializeTask(true);
        }

        public virtual bool InitializeTask(bool initializeThreads)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS");
            }
            catch { }

            logMessage("INIT", "STMR", "Starting Timer Service");
            if (!initializeThreads)
                return true;
            int maxThreads = 0;
            try
            {
                maxThreads = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting(ThreadsProperty));
            }
            catch (Exception e)
            {
                logMessage("INIT", "GTERR", "Unable to read default thread value from Farm Settings");
            }
            if (maxThreads < 1)
                return false;

            logMessage("INIT", "STMR", "Setting threads to: " + maxThreads);
            workingThreads = new WorkerThreads(maxThreads);
            return true;
        }
        public virtual void StopTimer()
        {
            logMessage("STOP", "STMR", "Stopped Timer Service");
        }
        protected abstract string LogName {
            get;
        }

        public abstract void RunTask(CancellationToken token);

        protected abstract void DoWork(RunnerData rd);

        protected abstract string ThreadsProperty {
            get;
        }

    }
}
