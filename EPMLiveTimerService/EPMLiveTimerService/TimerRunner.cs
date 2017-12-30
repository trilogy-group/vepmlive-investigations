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
namespace TimerService
{
    public class TimerRunner
    {
        private Task timesheetWorker;
        private IProgress<int> timesheetProgress;
        private Task mainWorker;
        private IProgress<int> mainProgress;
        private Task priorityWorker;
        private IProgress<int> priorityProgress;
        private Task securityWorker;
        private IProgress<int> securityProgress;
        private Task notificationWorker;
        private IProgress<int> notificationProgress;
        private IProgress<int> rollupProgress;
        private Task rollupWorker;
        private Task integrationWorker;
        private IProgress<int> integrationProgress;
        private CancellationTokenSource _cts;
        private CancellationToken token;
        public bool startTimer()
        {
            try
            {
                _cts = new CancellationTokenSource();
                token = _cts.Token;

                //=========================Run Main Queue
                mainProgress = new Progress<int>(value => { });
                mainWorker = Task.Run(() => { DoWork(new TimerClass(), mainProgress, token); }, token);
                //=========================Run High Priority Queue
                priorityProgress  = new Progress<int>(value => { });
                priorityWorker = Task.Run(() => { DoWork(new HighTimerClass(),priorityProgress, token); }, token);
                //=========================Run TS Queue
                timesheetProgress = new Progress<int>(value => { });
                timesheetWorker = Task.Run(() => { DoWork(new TimesheetTimerClass(), timesheetProgress, token); }, token);
                //=========================Run Sec Queue
                securityProgress = new Progress<int>(value => { });
                securityWorker = Task.Run(() => { DoWork(new SecurityClass(), securityProgress, token); }, token);
                //================Run Notifications
                notificationProgress = new Progress<int>(value => { });
                notificationWorker = Task.Run(() => { DoWork(new NotificationClass(), notificationProgress, token, "NotificationInterval"); }, token);
                //=========================Run Rollup Queue
                rollupProgress = new Progress<int>(value => { });
                rollupWorker = Task.Run(() => { DoWork(new RollupClass(), rollupProgress, token); }, token);
                //================Run Integrations
                integrationProgress = new Progress<int>(value => { });
                integrationWorker = Task.Run(() => { DoWork(new IntegrationClass(), integrationProgress, token); }, token);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        void DoWork(ProcessorBase mc, IProgress<int> progress, CancellationToken token, string pollingProperty = "PollingInterval")
        {
            if (mc.StartTimer())
            {
                while (true)
                {
                    mc.RunTimer(token);
                    token.ThrowIfCancellationRequested();
                    int poll = 5;
                    try
                    {
                        poll = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting(pollingProperty));
                    }
                    catch { }

                    Thread.Sleep(poll * 1000);
                }
            }
            else
            {
                throw new Exception("Could not start timer");
            }
        }
       

        public bool timerRunning()
        {
            return !mainWorker.IsCompleted;
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
