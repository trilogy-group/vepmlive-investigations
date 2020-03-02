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
                Task newTask = Task.Run(() => DoWork(rd), token);
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
                LogMessage("ERR", "STPR", ex.Message);
                return false;
            }
        }

        public void LogMessage(string type, string module, string message)
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

        protected CancellationToken token;
        public virtual bool InitializeTask(CancellationToken token)
        {
            return InitializeTask(true, token);
        }

        public virtual bool InitializeTask(bool initializeThreads, CancellationToken token)
        {
            this.token = token;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS");
            }
            catch { }

            LogMessage("INIT", "STMR", "Starting Timer Service");
            if (!initializeThreads)
                return true;
            int maxThreads = 0;
            try
            {
                maxThreads = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting(ThreadsProperty));
            }
            catch (Exception e)
            {
                LogMessage("INIT", "GTERR", "Unable to read default thread value from Farm Settings");
            }
            if (maxThreads < 1)
                return false;

            LogMessage("INIT", "STMR", "Setting threads to: " + maxThreads);
            _maxThreads = maxThreads;
            return true;
        }
        public void HeartBeat()
        {
            LogMessage("HTBT", "MNTH", "Dispatcher alive");
        }
        public virtual void Cancel()
        {
            Task.WaitAll(taskList.ToArray(), new TimeSpan(0, 0, 5)); 
            LogMessage("STOP", "STMR", "Stopped Timer Service");
        }
        protected abstract string LogName {
            get;
        }

        public abstract void RunTask();

        protected abstract void DoWork(RunnerData rd);

        protected abstract string ThreadsProperty {
            get;
        }

    }
}
