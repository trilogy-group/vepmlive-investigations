using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.ServiceProcess;
using System.Timers;
using Microsoft.Win32;
using System.Configuration;
using PortfolioEngineCore;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace WE_QueueMgr
{
    public partial class PPMWorkEngineQueueService : ServiceBase
    {
        internal class QMSite
        {
            public string siteName;
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
        private System.Timers.Timer timer = null;

        //private const string const_subKey = "SOFTWARE\\EPMLive\\PortfolioEngine\\";
        private const string const_subKey = "SOFTWARE\\Wow6432Node\\EPMLive\\PortfolioEngine\\";
        private const string PASS_PHRASE = "MnjkafjhkAS&*^#@";
        private bool m_bFirstTick;
        private long m_lMinutes;
        private long m_lTenSeconds;
        private long m_lExceptionCount = 0;
        private long m_lElapsedMinutes = 0;
        private const int const_Frequency = 60;

        System.Collections.Generic.List<QMSite> sites;

        public PPMWorkEngineQueueService()
        {
            try
            {
                InitializeComponent();

                m_lMinutes = DateTime.Now.Ticks / 600000000;
                m_lTenSeconds = DateTime.Now.Ticks / 100000000;
                m_lElapsedMinutes = 0;

                double interval = 1000;
                timer = new System.Timers.Timer(interval);
                timer.Elapsed += new ElapsedEventHandler(this.ServiceTimer_Tick);
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
                if (basepaths != "")
                {
                    m_bFirstTick = true;
                    MessageHandler("Start", "Built 28AUG2013. Any CPU. Foundation 4.5.\nOnStart\nUser : " + sNTUserName,  "active basePaths :\n" + basepaths.Replace(',', '\n'));
                    m_lExceptionCount = 0;
                    foreach (QMSite site in sites)
                    {
                        try
                        {
                            if (site.basePath != string.Empty && site.connection != string.Empty)
                                ManageTimerJobs(site);
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler("OnStart for basepath '" + site.basePath + "'", ex);
                        }
                    }

                    m_bFirstTick = false;
                    timer.AutoReset = true;
                    timer.Enabled = true;
                    timer.Start();
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
                            if (basePath != string.Empty && basePath.Length > 0)
                            {
                                rk = Registry.LocalMachine.OpenSubKey(const_subKey + basePath);
                                if (rk != null)
                                {
                                    QMSite site = null;
                                    if (rk.GetValue("QMActive", "no").ToString().ToLower() == "yes")
                                    {
                                        site = new QMSite();
                                        site.basePath = basePath;
                                        //EPML-4761: Logic to get encrypted/clear text registry key
                                        var encrypted = rk.GetValue("encrypted");
                                        string strConnectionString = rk.GetValue("ConnectionString", string.Empty).ToString().Trim();
                                        if (encrypted != null)
                                        {
                                            strConnectionString = Decrypt(strConnectionString, PASS_PHRASE);
                                        }
                                        var dbConnectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = strConnectionString };
                                        dbConnectionStringBuilder.Remove("Provider");

                                        site.connection = dbConnectionStringBuilder.ToString();
                                        //END-4761
                                        site.pid = rk.GetValue("PID", string.Empty).ToString().Trim();
                                        site.cn = rk.GetValue("CN", string.Empty).ToString().Trim();
                                        int nDefaultTraceChannels = 0;
                                        Int32.TryParse(rk.GetValue("Trace", 0).ToString(), out nDefaultTraceChannels);
                                        site.ActiveTraceChannels = nDefaultTraceChannels.ToString();

                                    }
                                    rk.Close();
                                    if (site != null)
                                    {
                                        SqlConnection m_oConnection = new SqlConnection();
                                        m_oConnection.ConnectionString = site.connection + ";Application Name=PfEQueueManager";
                                        m_oConnection.Open();

                                        SqlCommand cmd = new SqlCommand("SELECT WRES_ID,RES_NAME,WRES_TRACE FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT", m_oConnection);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.AddWithValue("@WRES_NT_ACCOUNT", sNTUserName.ToLower());
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        if (reader != null)
                                        {
                                            if (reader.Read() == true)
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
                                        if (basepaths != "")
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
            timer.AutoReset = false;
            timer.Enabled = false;
            MessageHandler("Stop", "OnStop", "Exceptions: " + m_lExceptionCount.ToString());
        }

        protected override void OnPause()
        {
            this.timer.Stop();
            MessageHandler("Pause", "OnPause", "");
        }

        protected override void OnContinue()
        {
            this.timer.Start();
            MessageHandler("Continue", "OnContinue", "");
        }

        private void ServiceTimer_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.timer.Stop();
            long lMinutes = DateTime.Now.Ticks / 600000000;
            long lTenSeconds = DateTime.Now.Ticks / 100000000;
            try
            {
                bool bNewMinute = (lMinutes != m_lMinutes);
                bool bNewTenSeconds = (lTenSeconds != m_lTenSeconds);
                if (bNewTenSeconds == true || bNewMinute == true)
                {
                    if (bNewMinute)
                    {
                        m_lElapsedMinutes++;
                        if (m_lElapsedMinutes >= const_Frequency)
                        {
                            m_lElapsedMinutes = 0;
                            string basepaths = BuildSitesList();
                            if (basepaths != "")
                                MessageHandler("Refresh", "Refresh site list",
                                               "active basePaths :\n" + basepaths.Replace(',', '\n'));
                        }
                    }
                    if (sites != null)
                    {
                        foreach (QMSite site in sites)
                        {
                            try
                            {
                                {
                                    if (bNewMinute)
                                        ManageTimerJobs(site);
                                    if (bNewTenSeconds)
                                        ManageQueue(site);
                                }
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandler("ServiceTimer_Tick ManageJobs for '" + site + "'", ex);
                            }
                        }
                    }
                    m_bFirstTick = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("ServiceTimer_Tick", ex);
            }
            finally
            {
                m_lMinutes = lMinutes;
                m_lTenSeconds = lTenSeconds;
                this.timer.Start();
            }
        }

        private void ManageTimerJobs(QMSite site)
        {
            if (site.basePath != string.Empty)
            {
                try
                {
                    Type comObjectType = Type.GetTypeFromProgID("WE_WSSAdmin.WSSAdmin");
                    object comObject = Activator.CreateInstance(comObjectType);
                    object[] myparams = new object[] { "ManageTimerJobs", site.basePath };
                    string s = (string) comObjectType.InvokeMember("RSVPRequest",
                                                            BindingFlags.InvokeMethod,
                                                            null,
                                                            comObject,
                                                            myparams);

                    comObject = null;
                    // added check for non-zero reply status CRL 18JAN13
                    string slc = s.ToLower();
                    if (slc.Contains("<error") == true || slc.Contains("<status>0</status>") == false)
                    {
                        EventLog.WriteEntry("PfE Queue Manager (FA3) - ManageTimerJobs Error", "basePath : " + site.basePath + "\nReply : " + s, EventLogEntryType.Error);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler("ManageTimerJobs - " + site.basePath, ex);
                }
            }
        }
        private void ManageQueue(QMSite site)
        {
            if (site.basePath != string.Empty)
            {
                try
                {
                    // check the queue for .net items before using RSVP
                    string sXML = BuildProductInfoString(site);
                    PortfolioEngineCore.QueueManager qm = new QueueManager(sXML);
                    if (qm.ReadNextQueuedItem() == true)
                    {
                        // we have a queued item - try to handle it in portfolioenginecore first
                        if (qm.ManageQueue() == false) // false means not handled
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
                                    Type comObjectType = Type.GetTypeFromProgID("WE_WSSAdmin.WSSAdmin");
                                    object comObject = Activator.CreateInstance(comObjectType);
                                    object[] myparams = new object[] { "ManageQueue", site.basePath };
                                    string s = (string)comObjectType.InvokeMember("RSVPRequest",
                                                                BindingFlags.
                                                                    InvokeMethod,
                                                                null,
                                                                comObject,
                                                                myparams);

                                    comObject = null;
                                    if (s.Contains("<Error"))
                                    {
                                        EventLog.WriteEntry("PfE Queue Manager (FA3) - ManageQueue Error", "basePath : " + site.basePath + "\nReply : " + s, EventLogEntryType.Error);
                                    }
                                    break;
                            }
                        }
                        qm = null;
                    }   
                }
                catch (Exception ex)
                {
                    ExceptionHandler("ManageQueue - " + site.basePath, ex);
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

        public static string Decrypt(string cipherText, string passPhrase)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes("77B2c3D4e1F3g7R1");
                byte[] saltValueBytes = Encoding.ASCII.GetBytes("f53fNDH@");
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                "SHA1",
                                                                2);

                byte[] keyBytes = password.GetBytes(256 / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);

                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                              decryptor,
                                                              CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                           0,
                                                           decryptedByteCount);
                return plainText;
            }
            catch { return ""; }
        }

    }
}