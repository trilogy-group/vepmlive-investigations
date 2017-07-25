using Microsoft.Win32;
using PortfolioEngineCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Timers;
using WE_QueueMgr.MsmqIntegration;

namespace WE_QueueMgr
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class PPMWorkEngineQueueService : ServiceBase, INotificationDispatcher
    {
        private ServiceHost serviceHost = null;
        private Timer timerJobsTimer = null;
        private const string const_subKey = "SOFTWARE\\Wow6432Node\\EPMLive\\PortfolioEngine\\";
        private long m_lMinutes;
        private long m_lExceptionCount = 0;
        private long m_lElapsedMinutes = 0;
        private const int const_Frequency = 60;
        private List<QMSite> sites;
        private IMessageQueue messageQueue;

        public void QueueNotification(Notification notification)
        {
            ManageQueueJobs(notification.BasePath);
        }

        public PPMWorkEngineQueueService()
        {
            try
            {
                InitializeComponent();

                m_lMinutes = DateTime.Now.Ticks / 600000000;
                m_lElapsedMinutes = 0;

                double interval = 30 * 1000;
                timerJobsTimer = new Timer(interval);
                timerJobsTimer.Elapsed += ManageTimerJobs;

                messageQueue = new Msmq();

                serviceHost?.Close();
                serviceHost = new ServiceHost(this);
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
            try
            {
                string sNTUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                string basepaths = BuildSitesList();
                if (!string.IsNullOrEmpty(basepaths))
                {
                    MessageHandler("Start", "Built 28AUG2013. Any CPU. Foundation 4.5.\nOnStart\nUser : " + sNTUserName, "active basePaths :\n" + basepaths.Replace(',', '\n'));
                    m_lExceptionCount = 0;
                    foreach (QMSite site in sites)
                    {
                        string sXML = BuildProductInfoString(site);
                        new LogService(sXML).TraceLog("OnStart", (StatusEnum)0, "Service Started for : " + site.basePath);
                        try
                        {
                            if (!string.IsNullOrEmpty(site.basePath) && !string.IsNullOrEmpty(site.connection))
                                ManageTimerJobs(site);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler("OnStart for basepath '" + site.basePath + "'", ex);
                        }
                    }

                    timerJobsTimer.AutoReset = true;
                    timerJobsTimer.Enabled = true;
                    timerJobsTimer.Start();
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
            }
        }

        private string BuildSitesList()
        {
            try
            {
                sites = new List<QMSite>();
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
                                                //int nResTrace = 0;
                                                //Int32.TryParse(reader["WRES_TRACE"].ToString(), out nResTrace);
                                                //int nActiveTrace = (nDefaultTraceChannels | nResTrace);
                                                //site.ActiveTraceChannels = nActiveTrace.ToString();
                                                //WebAdmin.SetSPSessionString(Context, basePath, "ProductFlags", nProductFlags.ToString());
                                                //WebAdmin.SetSPSessionString(Context, basePath, "PID", sPID.ToString());

                                                //string site = reader["ADM_WE_SERVERURL"].ToString().Trim();
                                                //if (site != "")
                                                //{
                                                //    if (sites != "")
                                                //        sites += ",";
                                                //    sites += site + "/_vti_bin/webservice.asmx";
                                                //}
                                            }
                                            reader.Close();
                                            reader.Dispose();
                                        }

                                        if (m_oConnection.State != System.Data.ConnectionState.Closed)
                                            m_oConnection.Close();
                                        m_oConnection.Dispose();

                                        sites.Add(site);
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

        protected override void OnStop()
        {
            timerJobsTimer.AutoReset = false;
            timerJobsTimer.Enabled = false;
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
            MessageHandler("Stop", "OnStop", "Exceptions: " + m_lExceptionCount.ToString());
        }

        protected override void OnPause()
        {
            timerJobsTimer.Stop();
            serviceHost?.Close();
            MessageHandler("Pause", "OnPause", "");
        }

        protected override void OnContinue()
        {
            timerJobsTimer.Start();
            serviceHost?.Open();
            MessageHandler("Continue", "OnContinue", "");
        }

        private void ManageTimerJobs(object sender, ElapsedEventArgs e)
        {
            timerJobsTimer.Stop();
            try
            {
                var lMinutes = DateTime.Now.Ticks / 600000000;
                try
                {
                    var bNewMinute = (lMinutes != m_lMinutes);
                    if (bNewMinute)
                    {
                        m_lElapsedMinutes++;
                        if (m_lElapsedMinutes >= const_Frequency)
                        {
                            m_lElapsedMinutes = 0;
                            string basepaths = BuildSitesList();
                            if (!string.IsNullOrEmpty(basepaths))
                                MessageHandler("Refresh", "Refresh site list",
                                               "active basePaths :\n" + basepaths.Replace(',', '\n'));
                        }
                        if (sites != null)
                        {
                            foreach (QMSite site in sites)
                            {
                                string sXML = BuildProductInfoString(site);
                                new LogService(sXML).TraceLog("ServiceTimer_Tick", 0, "");
                                try
                                {
                                    ManageTimerJobs(site);
                                }
                                catch (Exception exception)
                                {
                                    ExceptionHandler($"ServiceTimer_Tick ManageJobs for '{site}'", exception);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    m_lMinutes = lMinutes;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("ProcessTimerJobs", ex);
            }
            finally
            {
                timerJobsTimer.Start();
            }
        }

        public void ManageQueueJobs(string basePath)
        {
            lock(basePath)
            {
                var site = sites.Where(i => i.basePath == basePath).SingleOrDefault();
                if (site != null)
                {
                    try
                    {
                        // check the queue for .net items before using RSVP
                        string sXML = BuildProductInfoString(site);
                        using (var qm = new QueueManager(sXML))
                        {
                            if (qm.ReadNextQueuedItem())
                            {
                                new LogService(sXML).TraceLog("ManageQueue", (StatusEnum)0, "Queue Manager Next item found for  site : " + site.basePath);
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
                                            ErrorHandler("ManageQueue Case 200", 98765);
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
                        string sXML = BuildProductInfoString(site);
                        new LogService(sXML).TraceStatusError("ManageQueue exception thrown for " + site.basePath, (StatusEnum)99, ex);
                        ExceptionHandler("ManageQueue - " + site.basePath, ex);
                    }
                }
            }
        }

        private void ManageTimerJobs(QMSite site)
        {
            if (site.basePath != string.Empty)
            {
                string sXML = BuildProductInfoString(site);
                try
                {
                    var s = InvokeComObject(site, "ManageTimerJobs");
                    // added check for non-zero reply status CRL 18JAN13
                    string slc = s.ToLower();
                    if (slc.Contains("<error") || !slc.Contains("<status>0</status>"))
                    {
                        new LogService(sXML).TraceStatusError("ManageTimerJobs", (StatusEnum)100, "PfE Queue Manager (FA3) - ManageTimerJobs Error basePath : " + site.basePath + "\nReply : " + s);
                        EventLog.WriteEntry("PfE Queue Manager (FA3) - ManageTimerJobs Error", "basePath : " + site.basePath + "\nReply : " + s, EventLogEntryType.Error);
                    }
                    else
                    {
                        ManageQueueJobs(site.basePath);
                    }
                }
                catch (Exception ex)
                {
                    new LogService(sXML).TraceStatusError("ManageTimerJobs - " + site.basePath, (StatusEnum)100, ex);
                    ExceptionHandler("ManageTimerJobs - " + site.basePath, ex);
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