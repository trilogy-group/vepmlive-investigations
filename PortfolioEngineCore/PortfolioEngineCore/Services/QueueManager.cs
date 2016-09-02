using System;
using System.Data.SqlClient;
using System.Reflection;

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

        public bool ReadNextQueuedItem()
        {
            bool bItemToProcess = false;
            try
            {
                // JOB_STATUS codes:
                //  0 - Job not started
                //  1 - Job started and being processed
                // -1 - Job completed with no errors
                // -2 - Job completed with errors
                const string sCommand =
                    "SELECT TOP 1 * FROM EPG_JOBS WHERE JOB_CONTEXT >= 0 AND JOB_STATUS = 0 ORDER BY JOB_SUBMITTED";
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

        public bool ManageQueue()
        {
            bool bHandled = false;
            try
            {
                int lContext = m_lContext;
                if (lContext >= 100 && lContext < 200)
                {
                    _dba.UserWResID = m_lWResID;
                    switch (lContext)
                    {
                        case 100: // Report to Reporting DB
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
                            bHandled = true;
                            break;
                        case 111: // Calculate all availabilities
                            //SecurityLevels secLevel1 = SecurityLevels.AdminCalc;
                            //AdminFunctions pec1 = new AdminFunctions(_basepath, _username, _pid, _company, _dbcnstring,
                            //                                         secLevel1);
                            //bool bret1 = pec1.CalcRPAllAvailabilities();
                            SetJobStarted();
                            bool bret1 = AdminFunctions.CalcRPAllAvailabilities(_dba);
                           bHandled = true;
                            break;
                        case 112: // Calculate Default FTEs
                            //SecurityLevels secLevel2 = SecurityLevels.AdminCalc;
                            //AdminFunctions pec2 = new AdminFunctions(_basepath, _username, _pid, _company, _dbcnstring,
                            //                                         secLevel2);
                            //bool bret2 = pec2.CalcAllDefaultFTEs();
                            SetJobStarted();
                            bool bret2 = AdminFunctions.CalcAllDefaultFTEs(_dba);
                            bHandled = true;
                            break;
                    }
                }
                if (bHandled && m_guidJob != Guid.Empty)
                {
                    SetJobCompleted();
                }

            }
            catch (Exception ex)
            {
                _dba.HandleException("ManageQueue", (StatusEnum) 99999, ex);
            }
            return bHandled;
        }

        public bool SetJobStarted()
        {
            bool bSuccess = false;
            try
            {
                if (m_guidJob != Guid.Empty)
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

        public bool SetJobCompleted()
        {
            bool bSuccess = false;
            try
            {
                if (m_guidJob != Guid.Empty)
                {
                    const string sCommand =
                        "UPDATE EPG_JOBS SET JOB_COMPLETED = @JOB_COMPLETED, JOB_STATUS = -1 WHERE JOB_COMPLETED IS null AND JOB_GUID = @JOB_GUID";
                    SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                    oCommand.Parameters.AddWithValue("@JOB_COMPLETED", DateTime.Now);
                    //oCommand.Parameters.AddWithValue("JOB_COMMENT", "Job Completed by C# QM");
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

        public bool HandleRequest(string sContext, string sRequest, out string sReply)
        {
            sReply = "";

            try
            {
                string sXML = BuildProductInfoString(IntPtr.Zero);
                // this is what we have to do to late bind to a 32bit com+ vb6 object from a 64bit .net process
                Type comObjectType = Type.GetTypeFromProgID("WE_WSSAdmin.WSSAdmin");
                object comObject = Activator.CreateInstance(comObjectType);
                object[] myparams = new object[] { sContext, sXML, sRequest };
                sReply = (string)comObjectType.InvokeMember("RSVPRequest", BindingFlags.InvokeMethod, null, comObject, myparams);

                comObject = null;
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
