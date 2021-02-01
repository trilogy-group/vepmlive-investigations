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
                classes = new ProcessorBase[2];

                classes[0] = new InitFaultyClass();

                classes[1] = new RunFaultyClass();
               
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

    }
}
