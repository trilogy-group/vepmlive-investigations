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
        private string m_basepaths;
        object sitesLock = new object();
        private List<QMSite> GetSites(out string basepaths)
        {
            lock (sitesLock)
            {
                List<QMSite> res = new List<QMSite>();
                res.AddRange(m_sites);
                basepaths = m_basepaths;
                return res;
            }
        }

        private void BuildSitesList()
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
                    m_basepaths = basepaths;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("BuildSitesList", ex);
            }

        }

        public void QueueNotification(Notification notification)
        {
            string basepaths;
            List<QMSite> sites = GetSites(out basepaths);
            if (sites != null)
            {
                var site = sites.Where(i => i.basePath.Equals(notification.BasePath, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
                if (ManageQueueJobs(site, true))
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
                BuildSitesList();
                string basepaths;
                List<QMSite> sites = GetSites(out basepaths);
                _cts = new CancellationTokenSource();
                token = _cts.Token;

                if (!string.IsNullOrEmpty(basepaths))
                {
                    MessageHandler("Start", "Built 28AUG2013. Any CPU. Foundation 4.5.\nOnStart\nUser : " + sNTUserName, "active basePaths :\n" + basepaths.Replace(',', '\n'));
                    m_lExceptionCount = 0;

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
                    string basepaths;
                    List<QMSite> sites = GetSites(out basepaths);
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
        List<WaitingJob> longRunQueue = new List<WaitingJob>();

        void EnqueueSite(QueueManager qm, bool prioritize)
        {
            lock (longRunQueueLock)
            {
                int index = longRunQueue.Select(x => x.QM.BasePath).ToList().IndexOf(qm.BasePath);
                while (index >= 0 && !longRunQueue[index].QM.guidJob.Equals(qm.guidJob))
                {
                    index = longRunQueue.Select(x => x.QM.BasePath).ToList().IndexOf(qm.BasePath, index + 1);
                }
                if (index < 0)
                {
                    longRunQueue.Add(new WaitingJob { QM = qm, Prioritize = prioritize });
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
                    if (longRunQueue[i].QM.BasePath.Equals(matchSite.basePath, StringComparison.OrdinalIgnoreCase))
                        exclusion += "'" + longRunQueue[i].QM.guidJob + "',";
                }
            }
            if (!string.IsNullOrWhiteSpace(exclusion))
                exclusion = exclusion.Substring(0, exclusion.Length - 1);
            return exclusion;
        }
        //Loop once every:
        TimeSpan mainLoopPeriod = new TimeSpan(0, 1, 0);
        TimeSpan jobMaxTimeout = new TimeSpan(1, 0, 0);

        //Backup queue jobs processing call every:
        TimeSpan queueJobsPeriod = new TimeSpan(0, 10, 0);
        //check for timed jobs every:
        TimeSpan timedJobsPeriod = new TimeSpan(0, 1, 0);
        //Build sites every:
        TimeSpan buildSitesPeriod = new TimeSpan(0, 30, 0);

        int maxThreadCount = 4;
        int reserveSeats = 2;
        AutoResetEvent kickOffLongWorkEvent = new AutoResetEvent(false);
        void DoLongRun()
        {

            List<ProcessingJob> processingJobs = new List<ProcessingJob>();
            DateTime sitesLastCheck = DateTime.Now;
            DateTime queuedLastCheck = DateTime.Now;
            DateTime timedLastCheck = DateTime.Now;
            while (!token.IsCancellationRequested)
            {

                //BUILD SITES
                try
                {
                    DateTime sitesNewCheck = DateTime.Now;
                    if (sitesNewCheck - sitesLastCheck > buildSitesPeriod)
                    {
                        sitesLastCheck = sitesNewCheck;
                        BuildSitesList();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler("BuildingSites", ex);
                }

                //QUEUING
                try
                {
                    DateTime queuedNewCheck = DateTime.Now;
                    if (queuedNewCheck - queuedLastCheck > queueJobsPeriod)
                    {
                        queuedLastCheck = queuedNewCheck;
                        string basepaths;
                        List<QMSite> sites = GetSites(out basepaths);
                        if (!string.IsNullOrEmpty(basepaths))
                            MessageHandler("Refresh", "Refresh site list",
                                            "active basePaths :\n" + basepaths.Replace(',', '\n'));
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
                    ExceptionHandler("QueuingJobs", ex);
                }
                try
                {
                    DateTime timedNewCheck = DateTime.Now;
                    if (timedNewCheck - timedLastCheck > timedJobsPeriod)
                    {
                        timedLastCheck = timedNewCheck;
                        string basepaths;
                        List<QMSite> sites = GetSites(out basepaths);
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
                    ExceptionHandler("TimingJobs", ex);
                }

                if (!(processingJobs.Count < maxThreadCount && processingJobs.Count < longRunQueue.Count)
                    && !(processingJobs.Count > 0 && Task.WaitAny(processingJobs.Select(x => x.ExecTask).ToArray(), 0) >= 0)
                    )
                {
                    kickOffLongWorkEvent.WaitOne(mainLoopPeriod);
                }

                //REORDER
                lock (longRunQueueLock)
                {
                    List<WaitingJob> newList = longRunQueue.GetRange(processingJobs.Count, longRunQueue.Count - processingJobs.Count);
                    longRunQueue.RemoveRange(processingJobs.Count, newList.Count);
                    longRunQueue.AddRange(newList.OrderByDescending(x => x.Prioritize).ThenBy(x => x.QM.Submitted).ToArray());
                }

                //PROCESSING
                while (processingJobs.Count < maxThreadCount && processingJobs.Count < longRunQueue.Count)
                {
                    var nextJob = longRunQueue.Where(x => !processingJobs.Any(y => y.QM.BasePath == x.QM.BasePath)).FirstOrDefault();
                    if (nextJob != null)
                    {
                        int nextIndex = longRunQueue.IndexOf(nextJob);
                        var swapJob = longRunQueue[processingJobs.Count];
                        longRunQueue[processingJobs.Count] = nextJob;
                        longRunQueue[nextIndex] = swapJob;
                    }
                    
                    QueueManager qm = longRunQueue[processingJobs.Count].QM;

                    if (qm.ContextData.Contains("<EPKProcess>") && processingJobs.Count >= maxThreadCount - reserveSeats)
                    {
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
                            var jobQM = (QueueManager)obj;
                            using (tokenSource.Token.Register(Thread.CurrentThread.Abort))
                            {
                                if (!jobQM.ManageQueue())
                                {
                                    WSSAdmin wssadmin = new WSSAdmin();
                                    var result = wssadmin.RSVPRequest("ManageQueue", jobQM.BasePath, jobQM.guidJob.ToString());
                                }
                                return true;
                            }
                        }
                        catch (ThreadAbortException)
                        {
                            return false;
                        }
                    }, qm, tokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    processingJobs.Add(new ProcessingJob { QM = qm, EntryTime = DateTime.Now, CancelSource = tokenSource, ExecTask = newJob, QueueOrder = processingJobs.Count });
                }

                //service shutdown
                if (token.IsCancellationRequested)
                {
                    foreach (var job in processingJobs)
                    {
                        job.CancelSource.Cancel();
                        job.QM.RequeueJob();
                    }
                    processingJobs.Clear();
                    break;
                }

                //Check completion
                int completedJobProcessingIndex = Task.WaitAny(processingJobs.Select(x => x.ExecTask).ToArray(), 0);
                int completedJobQueueIndex = -1;
                if (completedJobProcessingIndex >= 0)
                {
                    completedJobQueueIndex = processingJobs[completedJobProcessingIndex].QueueOrder;
                    processingJobs.RemoveAt(completedJobProcessingIndex);

                    for (int i = completedJobProcessingIndex; i < processingJobs.Count; i++)
                    {
                        processingJobs[i].QueueOrder = processingJobs[i].QueueOrder - 1;
                    }
                }
                else if (processingJobs.Count >= 1 && (DateTime.Now - processingJobs[0].EntryTime) > jobMaxTimeout && !processingJobs[0].ExecTask.IsCompleted && longRunQueue.Count > processingJobs.Count)
                {
                    processingJobs[0].CancelSource.Cancel();
                    processingJobs[0].QM.RequeueJob();
                    completedJobQueueIndex = processingJobs[0].QueueOrder;
                    processingJobs.RemoveAt(0);
                    for (int i = 0; i < processingJobs.Count; i++)
                    {
                        processingJobs[i].QueueOrder = processingJobs[i].QueueOrder - 1;
                    }
                }

                //remove completions from queue
                if (completedJobQueueIndex >= 0)
                {
                    lock (longRunQueueLock)
                    {
                        longRunQueue.RemoveAt(completedJobQueueIndex);
                    }
                }

            }
        }



        private static readonly ConcurrentDictionary<string, object> _locks = new ConcurrentDictionary<string, object>();

        private bool ManageQueueJobs(QMSite site, bool prioritize = false)
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
                        while (true)
                        {
                            using (var qm = new QueueManager(sXML))
                            {
                                if (!qm.ReadNextQueuedItem(GetExclusionList(site)))
                                    break;
                                new LogService(sXML).TraceLog("ManageQueueJobs", (StatusEnum)0, "Queue Manager Next item found for  site : " + site.basePath);
                                EnqueueSite(qm, prioritize);
                                enqueued = true;
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

    public class ProcessingJob
    {
        public QueueManager QM;
        public DateTime EntryTime;
        public CancellationTokenSource CancelSource;
        public Task ExecTask;
        public int QueueOrder;

    }
    public class WaitingJob
    {
        public QueueManager QM;
        public bool Prioritize;
    }

}
