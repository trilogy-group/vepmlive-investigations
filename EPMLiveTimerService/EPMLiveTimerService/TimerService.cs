using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace TimerService
{
    public partial class TimerService : ServiceBase
    {
        TimerRunner tr;

        public TimerService()
        {
            InitializeComponent();
            tr = new TimerRunner();
        }

        protected override void OnStart(string[] args)
        {
            if (!tr.startTimer())
            {
                throw new Exception("One or more of the timer tasks failed to start");
            }
        }

        protected override void OnStop()
        {
            tr.stopTimer();
        }

    }
}
