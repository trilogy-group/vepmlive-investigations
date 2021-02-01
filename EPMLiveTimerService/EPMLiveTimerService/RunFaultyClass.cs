using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerService
{
    public class RunFaultyClass : ProcessorBase
    {
        public override void ProcessJobs()
        {
            token.ThrowIfCancellationRequested();
            Thread.Sleep(new TimeSpan(0, 0, 5));
            throw new Exception("RunFaultyClass: deliberate failure");
        }

        protected override string LogName {
            get {
                return "RunFaulty";
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
