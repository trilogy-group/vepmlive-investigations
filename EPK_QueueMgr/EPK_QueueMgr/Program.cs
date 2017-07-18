using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Diagnostics;
using System.Text;
using PortfolioEngineCore;
using System.Configuration;

namespace WE_QueueMgr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            try
            {
                Global.Instance.Start();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("PfE Queue Manager - Exception", "WE_QueueMgr.Main Exception : " + ex.ToString(), EventLogEntryType.Error);
            }
        }
    }
}