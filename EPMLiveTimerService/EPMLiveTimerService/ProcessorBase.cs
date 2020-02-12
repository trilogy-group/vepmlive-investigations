using System;
using Microsoft.SharePoint.Administration;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

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

        private int _maxThreads;
        protected int MaxThreads {
            get {
                for (int i = taskList.Count - 1; i >= 0; i--)
                {
                    if (taskList[i].Status != TaskStatus.Running)
                    {
                        taskList.RemoveAt(i);
                    }
                }
                return _maxThreads - taskList.Count;
            }
        }
        List<Task> taskList = new List<Task>();
        protected bool startProcess(RunnerData rd)
        {
            try
            {
                Task newTask = Task.Run(() => DoWork(rd));
                Thread.Sleep(500);
                if (!newTask.IsCompleted)
                {
                    taskList.Add(newTask);
                    return true;
                }
                return false;
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

        public abstract void RunTask(CancellationToken token);

        protected abstract void DoWork(RunnerData rd);

        protected abstract string ThreadsProperty {
            get;
        }

    }
}
