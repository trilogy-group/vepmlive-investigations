using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace TimerService
{
    public class TimerRunner
    {
        protected ProcessorBase[] classes;
        protected Task mainWorker;

        protected CancellationTokenSource _cts;
        protected CancellationToken token;

        const int HEART_BEAT_MINUTES = 5;

        public virtual bool startTimer()
        {
            try
            {
                ThreadPool.SetMaxThreads(50, 100);
                ThreadPool.SetMinThreads(0, 0);
                bool queueJobs = ConfigurationManager.AppSettings["SecondaryTimer"] == null || ConfigurationManager.AppSettings["SecondaryTimer"].ToLower() != "true";
                classes = new ProcessorBase[7];

                classes[0] = new TimerClass(false, false);

                classes[1] = new TimerClass(true, queueJobs);

                classes[2] = new TimesheetTimerClass();

                classes[3] = new SecurityClass();

                classes[4] = new NotificationClass();

                classes[5] = new RollupClass();

                classes[6] = new IntegrationClass();
                
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
                foreach (ProcessorBase currentClass in classes)
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
                        ProcessorBase currentClass = classes[index];
                        try
                        {
                            if (!currentClass.Initialized)
                            {
                                currentClass.InitializeTask(token);

                            }
                            if (beatNow)
                                currentClass.HeartBeat();

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
                                currentClass.ProcessJobs();
                            }
                        }
                        catch(Exception ex) when (!(ex is OperationCanceledException))
                        {
                            currentClass.LogMessage("ERR", "RUNT", ex.ToString());
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
                foreach (ProcessorBase currentClass in classes)
                {
                    currentClass.Cancel();
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
