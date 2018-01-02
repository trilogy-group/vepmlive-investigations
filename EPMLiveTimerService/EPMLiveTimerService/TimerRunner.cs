using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Data.SqlClient;
using Microsoft.SharePoint.Administration;
using System.IO;
using System.Data;
using Microsoft.SharePoint;
using System.Threading.Tasks;
using System.Linq;

namespace TimerService
{
    public class TimerRunner
    {
        protected class FaultItem
        {
            public DateTime FaultTime;
            public int FaultCount;
            public bool Recovered = false;
        }
        protected Task[] tasks;
        protected IProgress<int>[] progress;
        protected ManualResetEvent[] events;
        protected List<FaultItem> faultHistory;
        protected Task monitoringWorker;

        protected CancellationTokenSource _cts;
        protected CancellationToken token;

        public virtual bool startTimer()
        {
            try
            {
                _cts = new CancellationTokenSource();
                token = _cts.Token;
                tasks = new Task[7];
                progress = new IProgress<int>[7];
                events = new ManualResetEvent[7];
                faultHistory = new List<FaultItem> { null, null, null, null, null, null, null };

                //=========================Run Main Queue
                events[0] = new ManualResetEvent(false);
                progress[0] = new Progress<int>(value => { });
                tasks[0] = GetTask(0);
                //=========================Run High Priority Queue
                events[1] = new ManualResetEvent(false);
                progress[1] = new Progress<int>(value => { });
                tasks[1] = GetTask(1);
                //=========================Run TS Queue
                events[2] = new ManualResetEvent(false);
                progress[2] = new Progress<int>(value => { });
                tasks[2] = GetTask(2);
                //=========================Run Sec Queue
                events[3] = new ManualResetEvent(false);
                progress[3] = new Progress<int>(value => { });
                tasks[3] = GetTask(3);
                //================Run Notifications
                events[4] = new ManualResetEvent(false);
                progress[4] = new Progress<int>(value => { });
                tasks[4] = GetTask(4);
                //=========================Run Rollup Queue
                events[5] = new ManualResetEvent(false);
                progress[5] = new Progress<int>(value => { });
                tasks[5] = GetTask(5);
                //================Run Integrations
                events[6] = new ManualResetEvent(false);
                progress[6] = new Progress<int>(value => { });
                tasks[6] = GetTask(6);

                monitoringWorker = Task.Run(() => DoMonitoring(), token);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected virtual Task GetTask(int taskNumber)
        {
            switch (taskNumber)
            {
                case 0:
                    return Task.Run(() => DoWork(new TimerClass(false), progress[0], events[0]), token);
                case 1:
                    return Task.Run(() => DoWork(new TimerClass(true), progress[1], events[1]), token);
                case 2:
                    return Task.Run(() => DoWork(new TimesheetTimerClass(), progress[2], events[2]), token);
                case 3:
                    return Task.Run(() => DoWork(new SecurityClass(), progress[3], events[3]), token);
                case 4:
                    return Task.Run(() => DoWork(new NotificationClass(), progress[4], events[4], "NotificationInterval"), token);
                case 5:
                    return Task.Run(() => DoWork(new RollupClass(), progress[5], events[5]), token);
                case 6:
                    return Task.Run(() => DoWork(new IntegrationClass(), progress[6], events[6]), token);
            }
            return null;
        }

        const int RETRIES = 5;
        const int WAIT = 20;
        protected void DoMonitoring()
        {
            while (true)
            {
                int taskIndex = ManualResetEvent.WaitAny(events, new TimeSpan(0, 0, WAIT));
                token.ThrowIfCancellationRequested();
                RelaunchFaultedTasks();
                if (taskIndex == WaitHandle.WaitTimeout)
                {
                    continue;
                }
                events[taskIndex].Reset();
                if (faultHistory[taskIndex] == null)
                {
                    faultHistory[taskIndex] = new FaultItem { FaultTime = DateTime.Now, FaultCount = 1 };
                }
                else
                {
                    DateTime newFaultTime = DateTime.Now;
                    DateTime oldFaultTime = faultHistory[taskIndex].FaultTime;
                    TimeSpan sinceLastFault = newFaultTime - oldFaultTime;
                    faultHistory[taskIndex].FaultTime = newFaultTime;
                    if (sinceLastFault > new TimeSpan(0, 0, Convert.ToInt16(Math.Pow(2, RETRIES)) * 10))
                    {
                        faultHistory[taskIndex].FaultCount = 1;
                    }
                    else
                    {
                        faultHistory[taskIndex].FaultCount++;
                    }
                }
                faultHistory[taskIndex].Recovered = false;
            }
        }
        void RelaunchFaultedTasks()
        {
            DateTime checkTime = DateTime.Now;
            for (int i = 0; i < faultHistory.Count; i++)
            {
                if (faultHistory[i] == null || faultHistory[i].Recovered)
                    continue;
                if (checkTime >  faultHistory[i].FaultTime + new TimeSpan(0, 0, Convert.ToInt16(Math.Pow(2, faultHistory[i].FaultCount)) * 10))
                {
                    tasks[i] = GetTask(i);
                    faultHistory[i].Recovered = true;
                }
            }
        }
        protected void DoWork(ProcessorBase mc, IProgress<int> progress, ManualResetEvent faultEvent, string pollingProperty = "PollingInterval")
        {
            try
            {
                if (mc.InitializeTask())
                {
                    while (true)
                    {
                        token.ThrowIfCancellationRequested();
                        mc.RunTask(token);
                        int waitPeriod = WAIT;
                        try
                        {
                            waitPeriod = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting(pollingProperty));
                        }
                        catch { }
                        Thread.Sleep(new TimeSpan(0, 0, waitPeriod));
                    }
                }
                else
                {
                    throw new Exception("Could not start timer");
                }
            }
            catch (Exception ex) when (!(ex is OperationCanceledException))
            {
                faultEvent.Set();
                throw;
            }
        }


        public bool timerRunning()
        {
            return tasks[0] != null && !tasks[0].IsCompleted;
        }

        public bool stopTimer()
        {
            try
            {
                _cts.Cancel();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
