using System;
using System.Diagnostics;
using System.ServiceProcess;

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
                var version = AssemblyInfo.Version();
                EventLog.WriteEntry("PfE Queue Manager - " + version, "", EventLogEntryType.Information);
                ServiceBase.Run(new ServiceBase[] { Global.Instance });
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("PfE Queue Manager - Exception", "WE_QueueMgr.Main Exception : " + ex.ToString(), EventLogEntryType.Error);
            }
        }
    }
}