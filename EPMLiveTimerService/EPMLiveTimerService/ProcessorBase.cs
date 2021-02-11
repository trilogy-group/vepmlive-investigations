using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using Microsoft.SharePoint.Administration;

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

        protected int RunningThreads
        {
            get
            {
                return threadList.Count;
            }
        }
        private static readonly object threadsLock = new object();
        private int _maxThreads;
        protected int MaxThreads {
            get
            {
                lock (threadsLock)
                {
                    for (var i = threadList.Count - 1; i >= 0; i--)
                    {
                        if (!threadList[i].Item1.IsAlive)
                        {
                            threadList.RemoveAt(i);
                        }
                        else if (Timeout > 0 && DateTime.Now - threadList[i].Item2 > new TimeSpan(0, Timeout * threadList[i].Item3, 0))
                        {
                            try
                            {
                                threadList[i].Item1.Abort();
                                threadList[i].Item1.Join();
                            }
                            catch (Exception ex)
                            {
                                logMessage("ERR", "MXTD", $"Exception suppressed: {ex}");
                            }

                            threadList.RemoveAt(i);
                        }
                    }
                    return _maxThreads - threadList.Count;
                }
            }
        }

        readonly List<Tuple<Thread, DateTime, int>> threadList = new List<Tuple<Thread, DateTime, int>>();
        protected bool startProcess(RunnerData rd, int trialNumber = 1)
        {
            try
            {
                Thread newThread = new Thread(new ParameterizedThreadStart(DoWork));
                newThread.Start(rd);
                lock (threadsLock)
                {
                    threadList.Add(new Tuple<Thread, DateTime, int>(newThread, DateTime.Now, trialNumber));
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
            _maxThreads = maxThreads;
            return true;
        }
        public void HeartBeat()
        {
            logMessage("HTBT", "MNTH", "Dispatcher alive");
        }
        public virtual void StopTimer()
        {
            logMessage("STOP", "STMR", "Stopped Timer Service");
        }
        protected abstract string LogName {
            get;
        }

        protected virtual int Timeout
        {
            get
            {
                return 0;
            }
        }

        public abstract void RunTask(CancellationToken token);

        protected abstract void DoWork(object rd);

        protected abstract string ThreadsProperty {
            get;
        }

    }
}
