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
using System.Configuration;
using System.Runtime.Caching;

namespace TimerService
{
    public class TimerRunner
    {
        protected class ClassItem
        {
            public ProcessorBase Processor;
            public IProgress<int> Progress;
            public string PollingProperty = "PollingInterval";
            public bool Initialized = false;
        }
        protected ClassItem[] classes;
        protected Task mainWorker;

        protected CancellationTokenSource _cts;
        protected CancellationToken token;

        const int HEART_BEAT_MINUTES = 5;

        public virtual bool startTimer()
        {
            try
            {
                bool queueJobs = ConfigurationManager.AppSettings["SecondaryTimer"] == null || ConfigurationManager.AppSettings["SecondaryTimer"].ToLower() != "true";
                classes = new ClassItem[7];

                classes[0] = new ClassItem
                {
                    Progress = new Progress<int>(value => { }),
                    Processor = new TimerClass(false, false)
                };

                classes[1] = new ClassItem
                {
                    Progress = new Progress<int>(value => { }),
                    Processor = new TimerClass(true, queueJobs)
                };

                classes[2] = new ClassItem
                {
                    Progress = new Progress<int>(value => { }),
                    Processor = new TimesheetTimerClass()
                };

                classes[3] = new ClassItem
                {
                    Progress = new Progress<int>(value => { }),
                    Processor = new SecurityClass()
                };

                classes[4] = new ClassItem
                {
                    Progress = new Progress<int>(value => { }),
                    Processor = new NotificationClass(),
                    PollingProperty = "NotificationInterval"
                };

                classes[5] = new ClassItem
                {
                    Progress = new Progress<int>(value => { }),
                    Processor = new RollupClass()
                };

                classes[6] = new ClassItem
                {
                    Progress = new Progress<int>(value => { }),
                    Processor = new IntegrationClass()
                };
                _cts = new CancellationTokenSource();
                token = _cts.Token;
                mainWorker = new Task(DoWork, token);
                mainWorker.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        const int WAIT = 20;
        protected void DoWork()
        {
            try
            {
                DateTime lastHeartBeat = DateTime.Now;
                List<TimeSpan> pollPeriods = new List<TimeSpan>();
                List<DateTime> lastTimeExecutions = new List<DateTime>();
                foreach (ClassItem currentClass in classes)
                {
                    int waitPeriod = WAIT;
                    try
                    {
                        waitPeriod = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting(currentClass.PollingProperty));
                    }
                    catch { }
                    pollPeriods.Add(new TimeSpan(0, 0, waitPeriod));
                    lastTimeExecutions.Add(lastHeartBeat);
                }
                
                while (true)
                {
                    DateTime newHeartBeat = DateTime.Now;
                    bool beatNow = false;
                    if ((newHeartBeat - lastHeartBeat) >= new TimeSpan(0, HEART_BEAT_MINUTES, 0))
                    {
                        beatNow = true;
                        lastHeartBeat = newHeartBeat;
                    }
                    TimeSpan minimumSleep = TimeSpan.MaxValue;
                    for (int index = 0; index < classes.Length; index++)
                    {
                        token.ThrowIfCancellationRequested();
                        TimeSpan pollPeriod = pollPeriods[index];
                        DateTime lastExecution = lastTimeExecutions[index];
                        TimeSpan expectedSleep = pollPeriod - new TimeSpan(((newHeartBeat - lastExecution).Ticks % pollPeriod.Ticks));
                        if (expectedSleep < minimumSleep)
                        {
                            minimumSleep = expectedSleep;
                        }
                        ClassItem currentClass = classes[index];
                        try
                        {
                            if (!currentClass.Initialized)
                            {
                                currentClass.Initialized = currentClass.Processor.InitializeTask(token);

                            }
                            if (beatNow)
                                currentClass.Processor.HeartBeat();

                            if (newHeartBeat - lastExecution < pollPeriod)
                            {
                                continue;
                            }
                            else
                            {
                                lastTimeExecutions[index] = newHeartBeat;
                            }
                            if (currentClass.Initialized)
                            {
                                currentClass.Processor.RunTask();
                            }
                        }
                        catch(Exception ex) when (!(ex is OperationCanceledException))
                        {
                            currentClass.Processor.LogMessage("ERR", "RUNT", ex.ToString());
                        }
                    }
                    if (minimumSleep < TimeSpan.MaxValue)
                    {
                        Thread.Sleep(minimumSleep);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                foreach (ClassItem currentClass in classes)
                {
                    currentClass.Processor.Cancel();
                }
                throw;
            }
        }



        public bool timerRunning()
        {
            return mainWorker != null && !mainWorker.IsCompleted;
        }

        public bool stopTimer()
        {
            try
            {
                _cts.Cancel();

                mainWorker.Wait();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
