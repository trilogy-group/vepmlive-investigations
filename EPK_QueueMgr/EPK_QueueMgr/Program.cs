using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Diagnostics;
using System.Text;

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
                string sVersion = AssemblyInfo.Version();
                EventLog.WriteEntry("PfE Queue Manager - " + sVersion, "", EventLogEntryType.Information);
                ServiceBase[] ServicesToRun;

                // More than one user Service may run within the same process. To add
                // another service to this process, change the following line to
                // create a second service object. For example,
                //
                //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
                //
                ServicesToRun = new ServiceBase[] { new PPMWorkEngineQueueService() };

                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("PfE Queue Manager - Exception", "WE_QueueMgr.Main Exception : " + ex.ToString(), EventLogEntryType.Error);
            }
        }
    }
}