using Microsoft.Win32;
using PortfolioEngineCore;
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
        private ServiceHost serviceHost = null;

        private const string const_subKey = "SOFTWARE\\Wow6432Node\\EPMLive\\PortfolioEngine\\";
        private long m_lExceptionCount = 0;
        private const int const_Frequency = 60;
        private List<QMSite> m_sites;
        private List<QMSite> Sites
        {
            get
            {
                lock (this)
                {
                    return m_sites;
                }
            }
        }
        private IMessageQueue messageQueue;


        public void QueueNotification(Notification notification)
        {
            List<QMSite> sites = Sites;
            if (sites != null)
            {
                var site = sites.Where(i => i.basePath.Equals(notification.BasePath, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
                ManageQueueJobs(site);
            }
        }

        public PPMWorkEngineQueueService()
        {
            try
            {
                InitializeComponent();

                messageQueue = new Msmq();


                var msmqAddress = serviceHost.Description.Endpoints.Where(i => i.Address.Uri.Scheme == "net.msmq").First().Address.Uri.ToString();
                messageQueue.CreateQueue(@".\Private$\" + msmqAddress.Split('/').Last());
            }
            catch (Exception ex)
            {
                ExceptionHandler("InitializeComponent", ex);
            }
        }

        protected override void OnStart(string[] args)
        {
            ResumeProcessing();
            MessageHandler("Start", "OnStart", "");
        }

        protected CancellationTokenSource _cts;
        protected CancellationToken token;
        private Task timerTask;
        private Task monitorTask;
        private void ResumeProcessing()
        {
            try
            {
                string sNTUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                string basepaths = BuildSitesList();
                _cts = new CancellationTokenSource();
                token = _cts.Token;
                timerTask = Task.Run(() => DoWork(), token);
                monitorTask = Task.Run(() => DoMonitor(), token);
                serviceHost = new ServiceHost(this);
                serviceHost.Open();
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
                }
                else
                {
                    ErrorHandler("Start", 99995);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("OnStart", ex);
            }
        }
        private void PauseProcessing()
        {
            _cts.Cancel();
            if (!monitorTask.IsCompleted)
            {
                monitorTask.Wait();
                monitorTask = null;
            }
            if (!timerTask.IsCompleted)
            {
                timerTask.Wait();
                timerTask = null;
            }
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
            token = CancellationToken.None;
            _cts = null;
        }
        private string BuildSitesList()
        {
            lock (this)
            {
                try
                {

                    m_sites = new List<QMSite>();
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
                                            var m_oConnection = new SqlConnection();
                                            m_oConnection.ConnectionString = site.connection + ";Application Name=PfEQueueManager";
                                            m_oConnection.Open();

                                            SqlCommand cmd = new SqlCommand("SELECT WRES_ID,RES_NAME,WRES_TRACE FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT", m_oConnection);
                                            cmd.CommandType = CommandType.Text;
                                            cmd.Parameters.AddWithValue("@WRES_NT_ACCOUNT", sNTUserName.ToLower());
                                            SqlDataReader reader = cmd.ExecuteReader();
                                            if (reader != null)
                                            {
                                                if (reader.Read())
                                                {
                                                    site.WRES_ID = reader["WRES_ID"].ToString();
                                                    site.userName = reader["RES_NAME"].ToString();
                                                    site.NTAccount = sNTUserName.ToLower();
                                                    site.SessionInfo = Guid.NewGuid().ToString().ToUpper();
                                                }
                                                reader.Close();
                                                reader.Dispose();
                                            }

                                            if (m_oConnection.State != System.Data.ConnectionState.Closed)
                                                m_oConnection.Close();
                                            m_oConnection.Dispose();

                                            m_sites.Add(site);
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
                    return basepaths;
                }
                catch (Exception ex)
                {
                    ExceptionHandler("BuildSitesList", ex);
                    return "";
                }
            }
        }

        protected override void OnStop()
        {
            PauseProcessing();
            MessageHandler("Stop", "OnStop", "Exceptions: " + m_lExceptionCount.ToString());
        }

        protected override void OnPause()
        {
            PauseProcessing();
            MessageHandler("Pause", "OnPause", "");
        }

        protected override void OnContinue()
        {
            ResumeProcessing();
            MessageHandler("Continue", "OnContinue", "");
        }

        TimeSpan heartBeatPeriod = new TimeSpan(0, 1, 0);

        TimeSpan doMonitorPeriod = new TimeSpan(0, 0, 15);

        private void DoMonitor()
        {
            DateTime lastCheck = DateTime.Now;
            while (!token.IsCancellationRequested)
            {
                if (timerTask.IsCompleted && !token.IsCancellationRequested)
                    timerTask = Task.Run(() => DoWork(), token);
                Thread.Sleep(new TimeSpan(0, 0, 15));
                DateTime newCheck = DateTime.Now;
                if (newCheck - lastCheck > heartBeatPeriod)
                {
                    lastCheck = newCheck;
                    List<QMSite> sites = Sites;
                    if (sites != null && sites.Count > 0)
                    {
                        string sXML = BuildProductInfoString(sites[0]);
                        try
                        {
                            using (var qm = new QueueManager(sXML))
                            {
                                qm.AddHeartBeat();
                            }
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler("MonitorThread", ex);
                        }
                    }
                }
            }
        }
        TimeSpan queueJobsPeriod = new TimeSpan(1, 0, 0);
        TimeSpan timedJobsPeriod = new TimeSpan(0, 1, 0);
        TimeSpan doWorkPeriod = new TimeSpan(0, 0, 15);

        private void DoWork()
        {
            DateTime queuedLastCheck = DateTime.Now;
            DateTime timedLastCheck = DateTime.Now;
            while (!token.IsCancellationRequested)
            {
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
                Thread.Sleep(doWorkPeriod);
            }
        }

        private static readonly ConcurrentDictionary<string, object> _locks = new ConcurrentDictionary<string, object>();

        private void ManageQueueJobs(QMSite site)
        {
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
                            while (qm.ReadNextQueuedItem())
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
                                            var s = InvokeComObject(site, "ManageQueue");
                                            if (s.Contains("<Error"))
                                            {
                                                new LogService(sXML).TraceStatusError("ManageQueue", (StatusEnum)99, "PfE Queue Manager (FA3) - ManageQueue Error basePath : " + site.basePath + "\nReply : " + s);
                                                EventLog.WriteEntry("PfE Queue Manager (FA3) - ManageQueue Error", "basePath : " + site.basePath + "\nReply : " + s, EventLogEntryType.Error);
                                            }
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
        }

        private void ManageTimedJobs(QMSite site)
        {
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
                            ManageQueueJobs(site);
                    }
                }
                catch (Exception ex)
                {
                    new LogService(sXML).TraceStatusError("ManageTimedJobs - " + site.basePath, (StatusEnum)100, ex);
                    ExceptionHandler("ManageTimedJobs - " + site.basePath, ex);
                }
            }
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

        private string InvokeComObject(QMSite site, string job)
        {
            object comObject = null;
            try
            {
                var comObjectType = Type.GetTypeFromProgID("WE_WSSAdmin.WSSAdmin");
                comObject = Activator.CreateInstance(comObjectType);
                var myparams = new object[] { job, site.basePath };
                return (string)comObjectType.InvokeMember("RSVPRequest",
                                                        BindingFlags.InvokeMethod,
                                                        null,
                                                        comObject,
                                                        myparams);
            }
            finally
            {
                comObject = null;
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
    }
}