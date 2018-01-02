using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerService
{
    public class TestTimerRunner:TimerRunner
    {
        public override bool startTimer()
        {
            try
            {
                _cts = new CancellationTokenSource();
                token = _cts.Token;
                tasks = new Task[2];
                progress = new IProgress<int>[2];
                events = new ManualResetEvent[2];
                faultHistory = new List<FaultItem> { null, null };

                //=========================Run Initialization Exception 
                events[0] = new ManualResetEvent(false);
                progress[0] = new Progress<int>(value => { });
                tasks[0] = GetTask(0);
                //=========================Run Run Exception
                events[1] = new ManualResetEvent(false);
                progress[1] = new Progress<int>(value => { });
                tasks[1] = GetTask(1);
              

                monitoringWorker = Task.Run(() => DoMonitoring(), token);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override Task GetTask(int taskNumber)
        {
            switch (taskNumber)
            {
                case 0:
                    return Task.Run(() => DoWork(new InitFaultyClass(), progress[0], events[0]), token);
                case 1:
                    return Task.Run(() => DoWork(new RunFaultyClass(), progress[1], events[1]), token);
            }
            return null;
        }
    }
}
