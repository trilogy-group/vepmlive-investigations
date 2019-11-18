using Microsoft.Win32;
using PortfolioEngineCore;
using PortfolioEngineCore.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using WE_QueueMgr.MsmqIntegration;


namespace WE_QueueMgr
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class PPMWorkEngineQueueService : ServiceBase, INotificationDispatcher
    {

        private const string const_subKey = "SOFTWARE\\Wow6432Node\\EPMLive\\PortfolioEngine\\";
        private long m_lExceptionCount = 0;

        private List<QMSite> m_sites;
        object sitesLock = new object();
        private List<QMSite> Sites
        {
            get
            {
                lock (sitesLock)
                {
                    return m_sites;
                }
            }
        }
        private string BuildSitesList()
        {

            try
            {

                List<QMSite> newSites = new List<QMSite>();
                string basepaths = "";
                string sNTUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(const_subKey);
                if (rk != null)
                {
                    string[] m_sBasePathSubkeys = rk.GetSubKeyNames();
                    rk.Close();
                    foreach (string sBasePath in m_sBasePathSubkeys)
                    {
                        string basePath = sBasePath.Trim();
                        try
                        {
                            if (!string.IsNullOrEmpty(basePath))
                            {
                                rk = Registry.LocalMachine.OpenSubKey(const_subKey + basePath);
                                if (rk != null)
                                {
                                    QMSite site = null;
                                    if (rk.GetValue("QMActive", "no").ToString().ToLower() == "yes")
                                    {
                                        site = new QMSite();
                                        site.basePath = basePath;
                                        var dbConnectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = rk.GetValue("ConnectionString", string.Empty).ToString().Trim() };
                                        dbConnectionStringBuilder.Remove("Provider");

                                        site.connection = dbConnectionStringBuilder.ToString();
                                        site.pid = rk.GetValue("PID", string.Empty).ToString().Trim();
                                        site.cn = rk.GetValue("CN", string.Empty).ToString().Trim();
                                        int nDefaultTraceChannels = 0;
                                        Int32.TryParse(rk.GetValue("Trace", 0).ToString(), out nDefaultTraceChannels);
                                        site.ActiveTraceChannels = nDefaultTraceChannels.ToString();

                                    }
                                    rk.Close();
                                    if (site != null)
                                    {
                                        using (var m_oConnection = new SqlConnection())
                                        {
                                            m_oConnection.ConnectionString = site.connection + ";Application Name=PfEQueueManager";
                                            m_oConnection.Open();

                                            using (SqlCommand cmd = new SqlCommand("SELECT WRES_ID,RES_NAME,WRES_TRACE FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT", m_oConnection))
                                            {
                                                cmd.CommandType = CommandType.Text;
                                                cmd.Parameters.AddWithValue("@WRES_NT_ACCOUNT", sNTUserName.ToLower());
                                                using (SqlDataReader reader = cmd.ExecuteReader())
                                                {
                                                    if (reader != null)
                                                    {
                                                        if (reader.Read())
                                                        {
                                                            site.WRES_ID = reader["WRES_ID"].ToString();
                                                            site.userName = reader["RES_NAME"].ToString();
                                                            site.NTAccount = sNTUserName.ToLower();
                                                            site.SessionInfo = Guid.NewGuid().ToString().ToUpper();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        newSites.Add(site);
                                        if (!string.IsNullOrEmpty(basepaths))
                                            basepaths += ",";
                                        basepaths += basePath.Trim();

                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler("BuildSitesList for basepath '" + basePath + "'", ex);
                        }
                    }
                }
                lock (sitesLock)
                {
                    m_sites = newSites;
                }
                return basepaths;
            }
            catch (Exception ex)
            {
                ExceptionHandler("BuildSitesList", ex);
                return "";
            }

        }

        public void QueueNotification(Notification notification)
        {
            List<QMSite> sites = Sites;
            if (sites != null)
            {
                var site = sites.Where(i => i.basePath.Equals(notification.BasePath, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
                if (ManageQueueJobs(site))
                    kickOffLongWorkEvent.Set();
            }
        }

        private ServiceHost serviceHost = null;
        private IMessageQueue messageQueue;
        public PPMWorkEngineQueueService()
        {
            try
            {
                InitializeComponent();

                messageQueue = new Msmq();


                var msmqAddress = new ServiceHost(this).Description.Endpoints.Where(i => i.Address.Uri.Scheme == "net.msmq").First().Address.Uri.ToString();
                messageQueue.CreateQueue(@".\Private$\" + msmqAddress.Split('/').Last());
            }
            catch (Exception ex)
            {
                ExceptionHandler("InitializeComponent", ex);
            }
        }
        protected CancellationTokenSource _cts;
        protected CancellationToken token;
        private Task longRunTask;
        private Task monitorTask;
        protected override void OnStart(string[] args)
        {
            try
            {
                //System.Diagnostics.Debugger.Launch();
                string sNTUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                string timeoutString = System.Configuration.ConfigurationManager.AppSettings["jobmaxtimeout"];
                if (!string.IsNullOrEmpty(timeoutString))
                {
                    int timeoutMins;
                    if (!int.TryParse(timeoutString, out timeoutMins))
                    {
                        TimeSpan timeoutSpan;
                        if (TimeSpan.TryParse(timeoutString, out timeoutSpan))
                        {
                            jobMaxTimeout = timeoutSpan;
                        }
                    }
                    else
                    {
                        jobMaxTimeout = new TimeSpan(0, timeoutMins, 0);
                    }
                }

                string basepaths = BuildSitesList();
                _cts = new CancellationTokenSource();
                token = _cts.Token;

                if (!string.IsNullOrEmpty(basepaths))
                {
                    MessageHandler("Start", "Built 28AUG2013. Any CPU. Foundation 4.5.\nOnStart\nUser : " + sNTUserName, "active basePaths :\n" + basepaths.Replace(',', '\n'));
                    m_lExceptionCount = 0;
                    List<QMSite> sites = Sites;
                    if (sites != null)
                    {
                        foreach (QMSite site in sites)
                        {
                            string sXML = BuildProductInfoString(site);
                            new LogService(sXML).TraceLog("OnStart", (StatusEnum)0, "Service Started for : " + site.basePath);
                            ManageQueueJobs(site);
                            ManageTimedJobs(site);
                        }
                    }
                    longRunTask = Task.Run(() => DoLongRun(), token);
                    monitorTask = Task.Run(() => DoMonitor(), token);

                    serviceHost = new ServiceHost(this);
                    serviceHost.Open();
                }
                else
                {
                    ErrorHandler("Start", 99995);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("OnStart", ex);
                throw;
            }
            MessageHandler("Start", "OnStart", "");
        }
        protected override void OnStop()
        {
            _cts.Cancel();
            monitorTask = null;
            longRunTask = null;
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            serviceHost = null;
            MessageHandler("Stop", "OnStop", "Exceptions: " + m_lExceptionCount.ToString());
        }

        //Heartbeat every:
        TimeSpan heartBeatPeriod = new TimeSpan(0, 10, 0);
        //loop once every:
        TimeSpan doMonitorPeriod = new TimeSpan(0, 1, 0);
        FaultItem longRunFault = null;
        const int RETRIES = 5;
        private void DoMonitor()
        {
            DateTime lastCheck = DateTime.Now;
            bool firstBeat = false;
            while (!token.IsCancellationRequested)
            {
                //If task is faulted
                CheckTaskFault(longRunTask, ref longRunFault);

                if (longRunFault != null && !longRunFault.Recovered && DateTime.Now > longRunFault.FaultTime + new TimeSpan(0, 0, Convert.ToInt16(Math.Pow(2, longRunFault.FaultCount)) * 10))
                {
                    longRunTask = Task.Run(() => DoLongRun(), token);
                    longRunFault.Recovered = true;
                }

                DateTime newCheck = DateTime.Now;
                if (!firstBeat || newCheck - lastCheck > heartBeatPeriod)
                {
                    firstBeat = true;
                    lastCheck = newCheck;
                    List<QMSite> sites = Sites;
                    if (sites != null)
                    {
                        foreach (QMSite site in sites)
                        {
                            string sXML = BuildProductInfoString(site);
                            try
                            {
                                using (var qm = new QueueManager(sXML))
                                {
                                    qm.AddHeartBeat();
                                }
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandler("MonitorThread, Site: " + site.basePath, ex);
                            }
                        }
                    }
                }
                Thread.Sleep(doMonitorPeriod);
            }
        }
        void CheckTaskFault(Task task, ref FaultItem faultItem)
        {
            if (task.IsCompleted && !token.IsCancellationRequested)
            {
                if (faultItem == null)
                {
                    faultItem = new FaultItem { FaultTime = DateTime.Now, FaultCount = 1, Recovered = false };
                }
                else if (faultItem.Recovered)
                {
                    DateTime newFaultTime = DateTime.Now;
                    DateTime oldFaultTime = faultItem.FaultTime;
                    TimeSpan sinceLastFault = newFaultTime - oldFaultTime;
                    faultItem.FaultTime = newFaultTime;
                    if (sinceLastFault > new TimeSpan(0, 0, Convert.ToInt16(Math.Pow(2, RETRIES)) * 10))
                    {
                        faultItem.FaultCount = 1;
                    }
                    else
                    {
                        faultItem.FaultCount++;
                    }
                    faultItem.Recovered = false;
                }

            }
        }

        object longRunQueueLock = new object();
        List<Tuple<QMSite, Guid, String>> longRunQueue = new List<Tuple<QMSite, Guid, String>>();

        void EnqueueSite(QMSite site, Guid jobId, string contextData)
        {
            lock (longRunQueueLock)
            {
                int index = longRunQueue.Select(x => x.Item1).ToList().IndexOf(site);
                while (index >= 0 && !longRunQueue[index].Item2.Equals(jobId))
                {
                    index = longRunQueue.Select(x => x.Item1).ToList().IndexOf(site, index + 1);
                }
                if (index < 0)
                {
                    longRunQueue.Add(new Tuple<QMSite, Guid, String>(site, jobId, contextData));
                }

            }
        }

        string GetExclusionList(QMSite matchSite)
        {
            string exclusion = "";
            lock (longRunQueueLock)
            {
                for (int i = 0; i < longRunQueue.Count; i++)
                {
                    if (longRunQueue[i].Item1.basePath.Equals(matchSite.basePath, StringComparison.OrdinalIgnoreCase))
                        exclusion += "'" + longRunQueue[i].Item2 + "',";
                }
            }
            if (!string.IsNullOrWhiteSpace(exclusion))
                exclusion = exclusion.Substring(0, exclusion.Length - 1);
            return exclusion;
        }
        //Loop once every:
        TimeSpan longRunPeriod = new TimeSpan(0, 1, 0);
        TimeSpan jobMaxTimeout = new TimeSpan(1, 0, 0);
        TimeSpan completionPollPeriod = new TimeSpan(0, 1, 0);
        //Backup queue jobs processing call every:
        TimeSpan queueJobsPeriod = new TimeSpan(0, 10, 0);
        //check for timed jobs every:
        TimeSpan timedJobsPeriod = new TimeSpan(0, 1, 0);
        int maxThreadCount = 4;
        int reserveSeats = 2;
        AutoResetEvent kickOffLongWorkEvent = new AutoResetEvent(false);
        void DoLongRun()
        {
            List<Tuple<QMSite, Guid, DateTime, CancellationTokenSource, Task, int>> processingJobs = new List<Tuple<QMSite, Guid, DateTime, CancellationTokenSource, Task, int>>();
            DateTime queuedLastCheck = DateTime.Now;
            DateTime timedLastCheck = DateTime.Now;
            while (!token.IsCancellationRequested)
            {
                //QUEUING
                try
                {
                    DateTime queuedNewCheck = DateTime.Now;
                    if (queuedNewCheck - queuedLastCheck > queueJobsPeriod)
                    {
                        queuedLastCheck = queuedNewCheck;
                        string basepaths = BuildSitesList();
                        if (!string.IsNullOrEmpty(basepaths))
                            MessageHandler("Refresh", "Refresh site list",
                                            "active basePaths :\n" + basepaths.Replace(',', '\n'));
                        List<QMSite> sites = Sites;
                        if (sites != null)
                        {
                            foreach (QMSite site in sites)
                            {
                                ManageQueueJobs(site);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler("ProcessTimerJobs", ex);
                }
                try
                {
                    DateTime timedNewCheck = DateTime.Now;
                    if (timedNewCheck - timedLastCheck > timedJobsPeriod)
                    {
                        timedLastCheck = timedNewCheck;
                        List<QMSite> sites = Sites;
                        if (sites != null)
                        {
                            foreach (QMSite site in sites)
                            {
                                string sXML = BuildProductInfoString(site);
                                new LogService(sXML).TraceLog("ServiceTimer_Tick", 0, "");
                                ManageTimedJobs(site);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler("ProcessTimerJobs", ex);
                }


                kickOffLongWorkEvent.WaitOne(longRunPeriod);

                //PROCESSING
                while (processingJobs.Count < maxThreadCount && processingJobs.Count < longRunQueue.Count)
                {
                    QMSite site = longRunQueue[processingJobs.Count].Item1;
                    Guid jobId = longRunQueue[processingJobs.Count].Item2;
                    string contextData = longRunQueue[processingJobs.Count].Item3;
                    if (contextData.Contains("<EPKProcess>") && processingJobs.Count >= maxThreadCount - reserveSeats)
                    {
                        //string sXML = BuildProductInfoString(site);
                        //using (var qm = new QueueManager(sXML))
                        //{
                        //	  qm.RequeueJob(jobId);

                        //}
                        lock (longRunQueueLock)
                        {
                            longRunQueue.RemoveAt(processingJobs.Count);
                        }
                        continue;

                    }
                    CancellationTokenSource tokenSource = new CancellationTokenSource();
                    Task newJob = Task.Factory.StartNew((object obj) =>
                     {
                         try
                         {
                             var data = (dynamic)obj;
                             using (tokenSource.Token.Register(Thread.CurrentThread.Abort))
                             {
                                 WSSAdmin wssadmin = new WSSAdmin();
                                 var result = wssadmin.RSVPRequest("ManageQueue", data.basePath, data.jobId.ToString());
                                 return true;
                             }
                         }
                         catch (ThreadAbortException)
                         {
                             return false;
                         }
                     }, new { basePath = site.basePath, jobId = jobId }, tokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    processingJobs.Add(new Tuple<QMSite, Guid, DateTime, CancellationTokenSource, Task, int>(site, jobId, DateTime.Now, tokenSource, newJob, processingJobs.Count));
                }

                //service shutdown
                if (token.IsCancellationRequested)
                {
                    foreach (var job in processingJobs)
                    {
                        job.Item4.Cancel();
                        string sXML = BuildProductInfoString(job.Item1);
                        using (var qm = new QueueManager(sXML))
                        {
                            qm.RequeueJob(job.Item2);
                        }
                    }
                    processingJobs.Clear();
                    break;
                }

                //Check completion
                List<Task> jobs = processingJobs.Select(x => x.Item5).ToList();
                List<int> completedJobsIndex = new List<int>();
                int completedJobIndex = Task.WaitAny(jobs.ToArray(), completionPollPeriod);
                if (completedJobIndex >= 0)
                {
                    completedJobsIndex.Add(processingJobs[completedJobIndex].Item6);
                    processingJobs.RemoveAt(completedJobIndex);

                    for (int i = completedJobIndex; i < processingJobs.Count; i++)
                    {
                        processingJobs[i] = new Tuple<QMSite, Guid, DateTime, CancellationTokenSource, Task, int>(processingJobs[i].Item1, processingJobs[i].Item2, processingJobs[i].Item3, processingJobs[i].Item4, processingJobs[i].Item5, processingJobs[i].Item6 - 1);
                    }
                }
                else if (processingJobs.Count >= 1 && (DateTime.Now - processingJobs[0].Item3) > jobMaxTimeout && !processingJobs[0].Item5.IsCompleted && longRunQueue.Count > processingJobs.Count)
                {
                    processingJobs[0].Item4.Cancel();
                    string sXML = BuildProductInfoString(processingJobs[0].Item1);
                    using (var qm = new QueueManager(sXML))
                    {
                        qm.RequeueJob(processingJobs[0].Item2);
                    }
                    completedJobsIndex.Add(processingJobs[0].Item6);
                    processingJobs.RemoveAt(0);
                    for (int i = 0; i < processingJobs.Count; i++)
                    {
                        processingJobs[i] = new Tuple<QMSite, Guid, DateTime, CancellationTokenSource, Task, int>(processingJobs[i].Item1, processingJobs[i].Item2, processingJobs[i].Item3, processingJobs[i].Item4, processingJobs[i].Item5, processingJobs[i].Item6 - 1);
                    }
                }

                //remove completions from queue
                if (completedJobsIndex.Any())
                {
                    completedJobsIndex.Sort();
                    lock (longRunQueueLock)
                    {
                        for (int i = completedJobsIndex.Count - 1; i >= 0; i--)
                        {
                            longRunQueue.RemoveAt(completedJobsIndex[i]);
                        }
                    }
                }

            }
        }



        private static readonly ConcurrentDictionary<string, object> _locks = new ConcurrentDictionary<string, object>();

        private bool ManageQueueJobs(QMSite site)
        {
            bool enqueued = false;
            if (site != null)
            {
                lock (_locks.GetOrAdd(site.basePath.ToLower(), s => new object()))
                {
                    string sXML = BuildProductInfoString(site);
                    try
                    {
                        // check the queue for .net items before using RSVP
                        using (var qm = new QueueManager(sXML))
                        {

                            while (qm.ReadNextQueuedItem(GetExclusionList(site)))
                            {
                                new LogService(sXML).TraceLog("ManageQueueJobs", (StatusEnum)0, "Queue Manager Next item found for  site : " + site.basePath);
                                // we have a queued item - try to handle it in portfolioenginecore first
                                if (!qm.ManageQueue()) // false means not handled
                                {
                                    switch (qm.Context)
                                    {
                                        case 200:
                                            //////PortfolioEngineAPI pFeAPI = new PortfolioEngineAPI();
                                            //////pFeAPI.Execute("RefreshRoles", "");
                                            //////pFeAPI.Dispose();
                                            qm.SetJobCompleted();
                                            ErrorHandler("ManageQueueJobs Case 200", 98765);
                                            break;
                                        default:
                                            EnqueueSite(site, qm.guidJob, qm.ContextData);
                                            enqueued = true;
                                            break;
                                    }
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        new LogService(sXML).TraceStatusError("ManageQueue exception thrown for " + site.basePath, (StatusEnum)99, ex);
                        ExceptionHandler("ManageQueueJobs - " + site.basePath, ex);
                    }
                }
            }
            return enqueued;
        }

        private bool ManageTimedJobs(QMSite site)
        {
            bool enqueued = false;
            if (site.basePath != string.Empty)
            {
                string sXML = BuildProductInfoString(site);
                try
                {
                    //var s = InvokeComObject(site, "ManageTimerJobs");
                    using (var qm = new QueueManager(sXML))
                    {
                        int result = qm.ManageTimedJobs();

                        if (result == (int)StatusEnum.rsSuccess)
                            enqueued = ManageQueueJobs(site);
                    }
                }
                catch (Exception ex)
                {
                    new LogService(sXML).TraceStatusError("ManageTimedJobs - " + site.basePath, (StatusEnum)100, ex);
                    ExceptionHandler("ManageTimedJobs - " + site.basePath, ex);
                }
            }
            return enqueued;
        }

        private string BuildProductInfoString(QMSite site)
        {
            CStruct xEPKServer = new CStruct();
            xEPKServer.Initialize("EPKServer");
            xEPKServer.CreateString("basepath", site.basePath);
            //xEPKServer.CreateString("Port", port);
            xEPKServer.CreateString("dbcnstring", site.connection);
            xEPKServer.CreateString("username", site.userName);
            xEPKServer.CreateString("WResID", site.WRES_ID);
            xEPKServer.CreateString("pid", site.pid);
            xEPKServer.CreateString("session", site.SessionInfo);
            xEPKServer.CreateString("ActiveTraceChannels", site.ActiveTraceChannels);
            //xEPKServer.CreateString("ProductFlags", site.);


            return xEPKServer.XML();
        }

        private void ExceptionHandler(string sLocation, Exception ex)
        {
            // don't flood the event log with exceptions
            if (m_lExceptionCount++ < 10)
            {
                EventLog.WriteEntry("PfE Queue Manager (FA3) - Exception", "Exception " + sLocation + " : " + ex.ToString(), EventLogEntryType.Error);
            }
        }

        private void ErrorHandler(string sLocation, long lError)
        {
            // don't flood the event log with exceptions
            if (m_lExceptionCount++ < 10)
            {
                EventLog.WriteEntry("PfE Queue Manager (FA3) - Error", "Error " + sLocation + " : " + lError.ToString(), EventLogEntryType.Error);
            }
        }

        private void MessageHandler(string sContext, string sLocation, string sInfo)
        {
            try
            {
                const int _maxlen = 30000;
                string sSource = "PfE Queue Manager (FA3)";
                if (sContext != "") sSource += " - " + sContext;
                string s = sLocation + "\n\n" + sInfo;
                if (s.Length > _maxlen)
                    s = s.Substring(0, _maxlen) + "...\nString truncated from " + s.Length.ToString() + " to " + _maxlen.ToString();
                EventLog.WriteEntry(sSource, s, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                ExceptionHandler("MessageHandler - " + sContext + sLocation, ex);
            }
        }


    }

    internal class QMSite
    {
        public string basePath;
        public string connection;
        public string pid;
        public string cn;
        public string WRES_ID;
        public string userName;
        public string NTAccount;
        public string SessionInfo;
        public string ActiveTraceChannels;

        public override bool Equals(object obj)
        {
            if (obj is QMSite)
                return basePath.Equals(((QMSite)obj).basePath, StringComparison.OrdinalIgnoreCase);
            return base.Equals(obj);
        }
    }
    internal class FaultItem
    {
        public DateTime FaultTime;
        public int FaultCount;
        public bool Recovered = false;
    }

    public class Item
    {
        public Guid jobid;
        private QMSite site;
        public int Priority;
    }

}
