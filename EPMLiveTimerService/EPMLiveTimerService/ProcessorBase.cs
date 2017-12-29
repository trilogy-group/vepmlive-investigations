using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Data.SqlClient;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using System.Xml;


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
            private BackgroundWorker[] _arrWorkers;
            private int _maxThreads;
            public int MaxThreads {
                get { return _maxThreads; }
            }

            public WorkerThreads(int maxThreads)
            {
                _maxThreads = maxThreads;
                _arrWorkers = new BackgroundWorker[maxThreads];
            }

            public BackgroundWorker add()
            {

                for (int i = 0; i < _maxThreads; i++)
                    if (_arrWorkers[i] != null)
                        if (!((BackgroundWorker)_arrWorkers[i]).IsBusy)
                            _arrWorkers[i] = null;

                for (int i = 0; i < _maxThreads; i++)
                {
                    if (_arrWorkers[i] == null)
                    {
                        BackgroundWorker bw = new BackgroundWorker();
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

        protected bool startProcess(RunnerData dr)
        {
            try
            {
                BackgroundWorker bw = workingThreads.add();
                if (bw == null)
                {
                    return false;
                }
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;

                bw.DoWork += bw_DoWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.RunWorkerAsync(dr);
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


        public virtual bool startTimer()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS");
            }
            catch { }

            logMessage("INIT", "STMR", "Starting Timer Service");

            int maxThreads = 0;
            try
            {
                maxThreads = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("QueueThreads"));
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
        public virtual void stopTimer()
        {
            logMessage("STOP", "STMR", "Stopped Timer Service");
        }

        protected virtual void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        protected abstract string LogName {
            get;
        }

        public abstract void runTimer();

        protected abstract void bw_DoWork(object sender, DoWorkEventArgs e);


    }
}
