using PortfolioEngineCore.Services;
using System;
using System.Data.SqlClient;
using System.Reflection;
using WE_PDSExt;

namespace PortfolioEngineCore
{
    public class QueueManager : PFEBase
    {
        private int m_lContext = 0;
        private Guid m_guidJob = Guid.Empty;
        private string m_sContextData = string.Empty;
        private string m_sSession = string.Empty;
        private string m_sComment = string.Empty;
        private int m_lWResID = 0;

        public QueueManager(string basepath, string username, string pid, string company, string dbcnstring,
                            SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading QueueManager Class");
            _dba.Open();
        }

        public QueueManager(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading QueueManager Class");
            _dba.Open();
        }

        //~QueueManager()
        //{
        //    _dba.Close();
        //}

        public int Context
        {
            get
            {
                return m_lContext;
            }
        }
        public Guid guidJob
        {
            get
            {
                return m_guidJob;
            }
        }
        public string ContextData
        {
            get
            {
                return m_sContextData;
            }
        }
        public string Session
        {
            get
            {
                return m_sSession;
            }
        }
        public string Comment
        {
            get
            {
                return m_sComment;
            }
        }
        public int WResID
        {
            get
            {
                return m_lWResID;
            }
        }

        DateTime m_dtSubmitted = DateTime.Now;
        public DateTime Submitted
        {
            get
            {
                return m_dtSubmitted;
            }
        }
        public bool ReadNextQueuedItem(string exclusion = null)
        {
            bool bItemToProcess = false;
            try
            {
                // JOB_STATUS codes:
                //  0 - Job not started
                //  1 - Job started and being processed
                // -1 - Job completed with no errors
                // -2 - Job completed with errors
                string sCommand =
                    "SELECT TOP 1 * FROM EPG_JOBS WHERE JOB_CONTEXT >= 0 AND JOB_STATUS = 0 " + (string.IsNullOrWhiteSpace(exclusion)? "" : " AND  JOB_GUID NOT IN (" + exclusion + ") ") + " ORDER BY JOB_SUBMITTED";
                SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection);
                SqlDataReader reader = oCommand.ExecuteReader();

                m_lContext = 0;
                m_guidJob = Guid.Empty;
                m_sContextData = string.Empty;
                m_sSession = string.Empty;
                m_sComment = string.Empty;
                m_lWResID = 0;
                if (reader.Read())
                {
                    m_lContext = DBAccess.ReadIntValue(reader["JOB_CONTEXT"]);
                    m_guidJob = DBAccess.ReadGuidValue(reader["JOB_GUID"]);
                    m_sContextData = DBAccess.ReadStringValue(reader["JOB_CONTEXT_DATA"]);
                    m_sSession = DBAccess.ReadStringValue(reader["JOB_SESSION"]);
                    m_sComment = DBAccess.ReadStringValue(reader["JOB_COMMENT"]);
                    m_lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                    m_dtSubmitted = DBAccess.ReadDateValue(reader["JOB_SUBMITTED"]);
                    bItemToProcess = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                _dba.HandleException("ReadNextQueuedItem", (StatusEnum) 99999, ex);
            }
            return bItemToProcess;
        }

        public enum QueuedJobContextEnum
        {
            qjcCustom = 0,
            qjcImportProject = 1,
            qjcImportLookup = 2,
            qjcImportResources = 3,
            qjcExecuteActiveX = 4,
            qjcImportPIs = 5,
            qjcImportData = 6,
            qjcExportData = 7,
            qjcMaintenance = 8,
            qjcRefreshRoles = 200,
            qjcCalcAvailability = 111,
            qjcCalcDefaultFTEs = 112,
            qjcReportToReportingDb  = 100,
            qjcTest = 100001,
            qjcNone = -1
        }
        private  string BuildCookie()
        {
            string sXML = "<EPKServer>";
            sXML = sXML + "<BasePath>" + _basepath + "</BasePath>";
            sXML = sXML + "<ConnectInfo>" + _dbcnstring + "</ConnectInfo>";
            sXML = sXML + "<ResName>" + _username + "</ResName>";
            sXML = sXML + "<WResID>" + m_lWResID + "</WResID>";
            sXML = sXML + "<SessionInfo>" + m_sSession + "</SessionInfo>";
            sXML = sXML + "</EPKServer>";
            return sXML;
        }
        public bool ManageQueue()
        {
            bool bHandled = true;
            try
            {
                _dba.UserWResID = m_lWResID;
                switch ((QueuedJobContextEnum)m_lContext)
                {
                    case QueuedJobContextEnum.qjcReportToReportingDb: // Report to Reporting DB
                        SetJobStarted();
                        CAdmin oAdmin = new CAdmin();
                        if (oAdmin.GetAdminInfo(_dba) == StatusEnum.rsSuccess)
                        {
                            if (oAdmin.WEReportingDBConnect != "")
                            {
                                string sBasePath = this._basepath;
                                string sPfEConnection = convertToSQL(this._dbcnstring);
                                PfEReporting.PfE_ReportingDB reporting = new PfEReporting.PfE_ReportingDB();
                                reporting.ReportingDB_Build(sPfEConnection, oAdmin.WEReportingDBConnect, sBasePath);
                            }
                        }
                       
                            SetJobCompleted();
                        break;
                    case QueuedJobContextEnum.qjcCalcAvailability: // Calculate all availabilities
                                                                   //SecurityLevels secLevel1 = SecurityLevels.AdminCalc;
                                                                   //AdminFunctions pec1 = new AdminFunctions(_basepath, _username, _pid, _company, _dbcnstring,
                                                                   //                                         secLevel1);
                                                                   //bool bret1 = pec1.CalcRPAllAvailabilities();
                        SetJobStarted();
                        bool bret1 = AdminFunctions.CalcRPAllAvailabilities(_dba);
                        SetJobCompleted();
                        break;
                    case QueuedJobContextEnum.qjcCalcDefaultFTEs: // Calculate Default FTEs
                                                                  //SecurityLevels secLevel2 = SecurityLevels.AdminCalc;
                                                                  //AdminFunctions pec2 = new AdminFunctions(_basepath, _username, _pid, _company, _dbcnstring,
                                                                  //                                         secLevel2);
                                                                  //bool bret2 = pec2.CalcAllDefaultFTEs();
                        SetJobStarted();
                        bool bret2 = AdminFunctions.CalcAllDefaultFTEs(_dba);
                        SetJobCompleted();
                        break;
                    case QueuedJobContextEnum.qjcRefreshRoles:
                        //////PortfolioEngineAPI pFeAPI = new PortfolioEngineAPI();
                        //////pFeAPI.Execute("RefreshRoles", "");
                        //////pFeAPI.Dispose();
                        m_sComment = "Job context 200 encountered!";
                        SetJobCompleted();
                        break;
                    case QueuedJobContextEnum.qjcCustom:
                        SetJobStarted();
                        CMain oEPK = new CMain();
                        string sReply = oEPK.SoapXMLRequest(BuildCookie(), m_sContextData, "-a");
                        CStruct xReply = new CStruct();
                        if (xReply.LoadXML(sReply))
                        {
                            StatusEnum eReplyStatus = (StatusEnum)xReply.GetInt("STATUS");
                            if (eReplyStatus != StatusEnum.rsSuccess)
                            {
                                string sError = xReply.GetString("Error");
                                AddJobMessage(sError);
                               
                            }
                            SetJobCompleted(eReplyStatus, sReply);
                        }
                        break;
                    case QueuedJobContextEnum.qjcTest:
                        SetJobStarted();
                        m_sComment = "Job Queue Tested OK!";
                        AddJobMessage("Test handling");
                        SetJobCompleted();
                        break;
                    default:
                        bHandled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                _dba.HandleException("ManageQueue", (StatusEnum)99999, ex);
            }
            return bHandled;
        }

        public int ManageTimedJobs()
        {
         
            try
            {

                return AdminFunctions.ManageTimedJobs(_dba, this._basepath);

            }
            catch (Exception ex)
            {
                _dba.HandleException("ManageTimedJobs", (StatusEnum)99999, ex);
            }
            return -1;
        }

        public void AddHeartBeat()
        {
            AdminFunctions.AddHeartBeat(_dba);
        }

        public void MarkBoundryJob()
        {
            _dba.WriteImmTrace("VBJobMark", "MarkVBJob", guidJob.ToString(), ContextData);
        }

        public bool SetJobStarted()
        {
            bool bSuccess = false;
            try
            {
                if (m_guidJob != Guid.Empty && _dba.Open() == StatusEnum.rsSuccess)
                {
                    const string sCommand =
                        "UPDATE EPG_JOBS SET JOB_STARTED = @JOB_STARTED, JOB_STATUS = 1 WHERE JOB_STARTED IS null AND JOB_GUID = @JOB_GUID";
                    SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                    oCommand.Parameters.AddWithValue("@JOB_STARTED", DateTime.Now);
                    //oCommand.Parameters.AddWithValue("JOB_COMMENT", "Job Completed by C# QM");
                    oCommand.Parameters.AddWithValue("@JOB_GUID", m_guidJob);
                    bSuccess = (oCommand.ExecuteNonQuery() != 0);
                }
            }
            catch (Exception ex)
            {
                _dba.HandleException("SetJobStarted", (StatusEnum)99999, ex);
            }
            return bSuccess;
        }
        public bool AddJobMessage(string message)
        {
            bool bSuccess = false;
            try
            {
                if (m_guidJob != Guid.Empty &&  _dba.Open() == StatusEnum.rsSuccess)
                {
                    string sCommand =
                  "INSERT INTO EPG_JOB_MSGS (JOB_GUID,JMG_TIMESTAMP,JMG_MESSAGE) VALUES(@JOB_GUID,@JMG_TIMESTAMP,@JMG_MESSAGE)";
                    SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                    oCommand.Parameters.AddWithValue("@JOB_GUID", m_guidJob);
                    oCommand.Parameters.AddWithValue("@JMG_TIMESTAMP", DateTime.Now);
                    oCommand.Parameters.AddWithValue("@JMG_MESSAGE", message);

                    bSuccess = (oCommand.ExecuteNonQuery() != 0);
                }
            }
            catch (Exception ex)
            {
                _dba.HandleException("AddJobMessage", (StatusEnum)99999, ex);
            }
            return bSuccess;
        }
        public bool SetJobCompleted()
        {
            return SetJobCompleted(StatusEnum.rsSuccess, null);
        }
        public bool SetJobCompleted(StatusEnum status, string result = null)
        {
            bool bSuccess = false;
            try
            {
                if (m_guidJob != Guid.Empty && _dba.Open() == StatusEnum.rsSuccess)
                {
                    string sCommand =
                        "UPDATE EPG_JOBS SET JOB_COMPLETED = @JOB_COMPLETED, JOB_STATUS = "
                        + (status == StatusEnum.rsSuccess? "-1" 
                        + (result == null ? "" : ", JOB_CONTEXT_RESULT = @JOB_CONTEXT_RESULT") 
                        : "-2, JOB_ERRORCODE = " + (int)status)
                        + (m_sComment == null? "":", JOB_COMMENT = @JOB_COMMENT") 
                        + " WHERE JOB_COMPLETED IS null AND JOB_GUID = @JOB_GUID";
                    SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                    oCommand.Parameters.AddWithValue("@JOB_COMPLETED", DateTime.Now);
                    if (result != null)
                    {
                        oCommand.Parameters.AddWithValue("@JOB_CONTEXT_RESULT", result);
                    }
                    if (m_sComment != null)
                    {
                        oCommand.Parameters.AddWithValue("@JOB_COMMENT", m_sComment);
                    }
                    oCommand.Parameters.AddWithValue("@JOB_GUID", m_guidJob);
                    bSuccess = (oCommand.ExecuteNonQuery() != 0);
                }
            }
            catch (Exception ex)
            {
                _dba.HandleException("SetJobCompleted", (StatusEnum)99999, ex);
            }
            return bSuccess;
        }
        
        public bool RequeueJob()
        {
            bool bSuccess = false;
            try
            {
                if (guidJob != Guid.Empty)
                {
                    string sCommand =
						"UPDATE EPG_JOBS SET JOB_SUBMITTED = @JOB_SUBMITTED, JOB_STATUS = 0, JOB_STARTED = null,  JOB_COMPLETED = null, JOB_COMMENT = (case when charindex('|Requeued', JOB_COMMENT) = 0 then JOB_COMMENT else substring(JOB_COMMENT, 0, charindex('|Requeued', JOB_COMMENT)) end) + N'|Requeued at ' + convert(varchar, getdate(), 20) WHERE JOB_GUID = @JOB_GUID";
                    SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                    oCommand.Parameters.AddWithValue("@JOB_SUBMITTED", DateTime.Now);
                    oCommand.Parameters.AddWithValue("@JOB_GUID", guidJob);
                    bSuccess = (oCommand.ExecuteNonQuery() != 0);
                }
            }
            catch (Exception ex)
            {
                _dba.HandleException("RequeueJob", (StatusEnum)99999, ex);
            }
            return bSuccess;
        }

        public bool HandleRequest(string sContext, string sRequest, out string sReply)
        {
            sReply = "";

            try
            {
                string sXML = BuildProductInfoString(IntPtr.Zero);
                WSSAdmin wssadmin = new WSSAdmin();
                sReply = wssadmin.RSVPRequest(sContext, BasePath, "", _dba);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private string BuildProductInfoString(IntPtr token)
        {
            CStruct xEPKServer = new CStruct();
            xEPKServer.Initialize("EPKServer");
            xEPKServer.CreateString("BasePath", _basepath);
            xEPKServer.CreateInt("Port", _port);
            xEPKServer.CreateString("ConnectInfo", _dbcnstring);
            xEPKServer.CreateString("ResName", _username);
            xEPKServer.CreateInt("WResID", _userWResID);
            xEPKServer.CreateString("SessionInfo", _session);
            xEPKServer.CreateInt("ActiveTraceChannels", 0);
            if (token != IntPtr.Zero)
                xEPKServer.CreateString("IdentityToken", token.ToString());

            return xEPKServer.XML();
        }

        private static string convertToSQL(string sSqlconnect)
        {
            string[] sComponents = sSqlconnect.Split(';');
            string sSQL = string.Empty;
            foreach (string sentry in sComponents)
            {
                if (!sentry.ToUpper().Contains("PROVIDER"))
                {
                    sSQL += ";" + sentry;
                }
            }
            if (sSQL.Length < 1) return string.Empty;
            else return sSQL.Remove(0, 1);
        }
    }
}
