using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerService
{
    public class InitFaultyClass: ProcessorBase
    {
        public override void InitializeTask(CancellationToken token) 
        {
            base.InitializeTask(false, token);
            throw new Exception("InitFaultyClass: deliberate failure");
        }
        public override void ProcessJobs()
        {
            token.ThrowIfCancellationRequested();
            Thread.Sleep(new TimeSpan(0, 0, 5));
        }

        protected override string LogName {
            get {
                return "InitFaulty";
            }
        }
        protected override void DoWork(object rd)
        {
            throw new NotImplementedException();
        }
        protected override string ThreadsProperty {
            get {
                throw new NotImplementedException();
            }
        }
    }
}
