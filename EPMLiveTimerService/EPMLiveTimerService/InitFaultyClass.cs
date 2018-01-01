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
        public override bool InitializeTask()
        {
            if (!base.InitializeTask(false))
                return false;
            throw new Exception("InitFaultyClass: deliberate failure");
        }
        public override void RunTask(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            Thread.Sleep(new TimeSpan(0, 0, 5));
        }

        protected override string LogName {
            get {
                return "InitFaulty";
            }
        }
        protected override void DoWork(RunnerData rd)
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
