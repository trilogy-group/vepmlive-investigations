using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using Microsoft.Win32;
using Microsoft.SharePoint;
using EPMLiveCore;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    public class PEHelper
    {
        string m_sStatusText = "";
        string m_sStackTrace = "";

        public int SetDataCache(HttpContext context, Guid guidOptionalTicketIn, string sData, out Guid guidTicketOut)
        {
            int nStatus = 0;
            m_sStatusText = "";
            m_sStackTrace = "";
            guidTicketOut = Guid.Empty;
            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(context, out sStage) == true)
            {
                string sDBConnect = WebAdmin.GetConnectionString(context);
                SqlConnection conn = null;

                try
                {
                    conn = new SqlConnection(sDBConnect);
                    Guid guidTicket = Guid.Empty;

                    if (guidOptionalTicketIn == Guid.Empty)
                        guidTicket = Guid.NewGuid();
                    else
                        guidTicket = guidOptionalTicketIn;

                    string sCommand = "INSERT INTO EPG_DATA_CACHE(DC_TICKET,DC_TIMESTAMP,DC_DATA) VALUES(@DC_TICKET,@DC_TIMESTAMP,@DC_DATA)";

                    SqlCommand oCommand = new SqlCommand(sCommand, conn);

                    oCommand.Parameters.Add("@DC_TICKET", SqlDbType.UniqueIdentifier, 16).Value = guidTicket;
                    oCommand.Parameters.Add("@DC_TIMESTAMP", SqlDbType.Timestamp).Value = DateTime.Now;
                    oCommand.Parameters.Add("@DC_DATA", SqlDbType.NText, vb.Max(1, sData.Length)).Value = sData;

                    int lRowsAffected = oCommand.ExecuteNonQuery();

                    if (lRowsAffected == 1) guidTicketOut = guidTicket;

                }
                catch (Exception ex)
                {
                    m_sStatusText = ex.Message.ToString();
                    m_sStackTrace = ex.StackTrace.ToString();
                    nStatus = 1;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                m_sStatusText = "PEHelper.SetDataCache failed to authenticate user. Stage=" + sStage;
                nStatus = 2;
            }

            return nStatus;
        }

        public string StatusText
        {
            get
            {
                return m_sStatusText;
            }
        }

        public string StackTrace
        {
            get
            {
                return m_sStackTrace;
            }
        }
    }
    
    
    
    public class WebAdmin
    {

        public static void CapturePFEBaseInfo(out string basepath, out string username, out string ppmId, out string ppmCompany, out string ppmDbConn, out SecurityLevels secLevel)
        {

            secLevel = SecurityLevels.Base;
            using (SPWeb web = SPContext.Current.Web)
            {
                using (var site = new SPSite(web.Site.ID))
                {
                    SPWeb rootWeb = site.RootWeb;

                    basepath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                    ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                    ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                    ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");
                    username = ConfigFunctions.GetCleanUsername(rootWeb);
                }
            }
        }


        public static string BuildBaseInfo(HttpContext context)
        {
            string basePath, username, pid, company, dbcnstring;
            PortfolioEngineCore.SecurityLevels secLevel;
            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out pid, out company, out dbcnstring, out secLevel);
            
            CStruct xEPKServer = new CStruct();
            xEPKServer.Initialize("BaseInfo");
            xEPKServer.CreateString("basepath", basePath);
            xEPKServer.CreateString("username", username);
            xEPKServer.CreateString("pid", pid);
            xEPKServer.CreateString("company", company);
            xEPKServer.CreateString("dbcnstring", dbcnstring);
            xEPKServer.CreateInt("port", context.Request.Url.Port);
            xEPKServer.CreateString("session", context.Session.SessionID);

            return xEPKServer.XML();
        }

        public static string GetConnectionString(HttpContext Context)
        {
            return GetConnectionString();
        }

        public static string GetConnectionString()
        {
            //string basePath = Context.Request.ApplicationPath;

            // Bugfix V4.2 CRL 03NOV2011 need to always read basepath from SP as multiple sites with different basepaths can share session
            string basePath = WebAdmin.GetBasePath();
            return GetConnectionString(basePath);
        }

        public static string GetConnectionString(string basePath)
        {
            string sConnection = "";
            if (basePath.Length > 0)
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(WebAdmin.BuildSiteRegistryKey(basePath));
                if (rk != null)
                {
                    sConnection = rk.GetValue("ConnectionString", "").ToString();
                    rk.Close();
                }
            }
            return sConnection;
        }

        public static string BuildSiteRegistryKey(string basePath)
        {
            string sRoot = "SOFTWARE\\Wow6432Node\\EPMLive\\PortfolioEngine\\";
            if (basePath.Length > 0)
                return  sRoot + basePath;
            else
                return sRoot;
        }

        public static string GetBasePath()
        {
            try
            {
                string basePath = "";
                using (SPWeb web = SPContext.Current.Web)
                {
                    basePath = ConfigFunctions.getConfigSetting(web.Site.RootWeb, "EPKBasepath");
                }
                basePath = basePath.Replace("/", "");
                basePath = basePath.Replace("\\", "");
                return basePath.ToString();
            }
            catch { return ""; }
        }

        public static string GetSPSessionString(HttpContext Context, string sName)
        {
            try
            {
                string basePath = WebAdmin.GetBasePath();
                return Context.Session[basePath + "_" + sName].ToString();
            }
            catch { return ""; }
        }

        public static void SetSPSessionString(HttpContext Context, string basePath, string sName, string sValue)
        {
            try
            {
                Context.Session[basePath + "_" + sName] = sValue;
            }
            catch { }
        }

        public static void SetSPSessionString(HttpContext Context, string sName, string sValue)
        {
            try
            {
                string basePath = WebAdmin.GetBasePath();
                Context.Session[basePath + "_" + sName] = sValue;
            }
            catch { }
        }

        public static bool AuthenticateUserAndProduct(HttpContext Context, out string sStage)
        {
            sStage = "";
            bool bAuthenticated = false;
            try
            {
                bAuthenticated = Context.Request.IsAuthenticated;
                if (bAuthenticated == true)
                {
                    string basePath = WebAdmin.GetBasePath();
                    string sNTUserName = "";
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    { sNTUserName = ConfigFunctions.GetCleanUsername(SPContext.Current.Web).ToLower(); });

                    if (sNTUserName != string.Empty)
                    {
                        sStage = "5-No registry key.";
                        RegistryKey rk = null;
                        string sKey = WebAdmin.BuildSiteRegistryKey(basePath);
                        rk = Registry.LocalMachine.OpenSubKey(sKey);
                        if (rk != null)
                        {
                            sStage = "6-No valid security PID.";
                            string sPID = rk.GetValue("PID", "").ToString();
                            string connectionString = rk.GetValue("ConnectionString", "").ToString();
                            int nDefaultTraceChannels = 0;
                            var dbConnectionStringBuilder = new DbConnectionStringBuilder {ConnectionString = connectionString};
                            dbConnectionStringBuilder.Remove("Provider");
                            connectionString = dbConnectionStringBuilder.ToString();
                            Int32.TryParse(rk.GetValue("Trace", 0).ToString(), out nDefaultTraceChannels);
                            rk.Close();

                            if (Security.ValidatePID(sPID) == true)
                            {
                                // Get the product flags from the PID
                                int nProductFlags = 0;
                                Int32.TryParse(Security.GetData(sPID, Security.vars.v_products), out nProductFlags);

                                sStage = "7-Failed to connect to DB";
                                SqlConnection conn = new SqlConnection(connectionString);
                                sStage = "8b-Failed to read data for NT user '" + sNTUserName + "'";
                                string cmdText = "SELECT WRES_ID,RES_NAME,WRES_TRACE FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT";
                                SqlCommand cmd = new SqlCommand(cmdText, conn);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@WRES_NT_ACCOUNT", sNTUserName.ToLower());
                                conn.Open();
                                SqlDataReader reader = cmd.ExecuteReader();
                                sStage = "9b-'" + sNTUserName + "' not PfE NTAccount.";
                                if (reader.Read())
                                {
                                    sStage = "10";
                                    WebAdmin.SetSPSessionString(Context, basePath, "basePath", basePath);
                                    WebAdmin.SetSPSessionString(Context, basePath, "WResID", reader["WRES_ID"].ToString());
                                    WebAdmin.SetSPSessionString(Context, basePath, "userName", reader["RES_NAME"].ToString());
                                    WebAdmin.SetSPSessionString(Context, basePath, "NTAccount", sNTUserName.ToLower());
                                    WebAdmin.SetSPSessionString(Context, basePath, "SessionInfo", Guid.NewGuid().ToString().ToUpper());
                                    int nResTrace = 0;
                                    Int32.TryParse(reader["WRES_TRACE"].ToString(), out nResTrace);
                                    int nActiveTrace = (nDefaultTraceChannels | nResTrace);
                                    WebAdmin.SetSPSessionString(Context, basePath, "ActiveTraceChannels", nActiveTrace.ToString("0"));
                                    WebAdmin.SetSPSessionString(Context, basePath, "ProductFlags", nProductFlags.ToString("0"));
                                    WebAdmin.SetSPSessionString(Context, basePath, "PID", sPID);
                                    bAuthenticated = true;
                                }
                                reader.Close();
                                conn.Close();
                            }
                        }
                    }
                }


                //if (Context.Request.IsAuthenticated)
                //{
                //    sStage = "1-No Session.";
                //    if (Context.Session != null)
                //    {
                //        // pick up the basepath held in SP - see if session setup for it
                //        sStage = "2-No SP basepath.";
                //        // CRL Note : base path is used to identify db connection info in the registry
                //        //string basePath = Context.Request.ApplicationPath;
                //        if (SPContext.Current == null)
                //            sStage += "; SPContext.Current == null";
                //        else if (SPContext.Current.Site == null)
                //            sStage += "; SPContext.Current.Site == null";
                //        string basePath = WebAdmin.GetBasePath();
                //        if (basePath.Length > 0)
                //        {
                //            // have session values been created for it
                //            string sNTUserName = "";
                //            SPSecurity.RunWithElevatedPrivileges(delegate()
                //            {
                //                //SPUser user = SPContext.Current.Web.CurrentUser;
                //                //sNTUserName = EPMLiveCore.CoreFunctions.GetRealUserName(user.LoginName).ToLower();
                //                sNTUserName = ConfigFunctions.GetCleanUsername(SPContext.Current.Web).ToLower();
                //            });
                //            string sBasePathValue = WebAdmin.GetSPSessionString(Context, "basePath");
                //            string sNTUserNameValue = WebAdmin.GetSPSessionString(Context, "NTAccount");
                //            if (string.IsNullOrEmpty(sBasePathValue)
                //                || string.IsNullOrEmpty(sNTUserNameValue)
                //                || sBasePathValue != basePath
                //                || sNTUserNameValue != sNTUserName)
                //            {
                //                // not set so go and validate further
                //                sStage = "3-Sharpoint user exception";
                //                if (SPContext.Current == null)
                //                    sStage += "; SPContext.Current == null";
                //                else if (SPContext.Current.Web == null)
                //                    sStage += "; SPContext.Current.Web == null";
                //                else if (SPContext.Current.Web.CurrentUser == null)
                //                    sStage += "; SPContext.Current.Web.CurrentUser == null";

                //                sStage = "4-No User.";
                //                if (sNTUserName != string.Empty)
                //                {
                //                    sStage = "5-No registry key.";
                //                    int nPort = Context.Request.Url.Port;
                //                    RegistryKey rk = null;
                //                    string sKey = WebAdmin.BuildSiteRegistryKey(basePath);    
                //                    rk = Registry.LocalMachine.OpenSubKey(sKey);
                //                    if (rk != null)
                //                    {
                //                        sStage = "6-No valid security PID.";
                //                        string sPID = rk.GetValue("PID", "").ToString();
                //                        string connectionString = rk.GetValue("ConnectionString", "").ToString();
                //                        int nDefaultTraceChannels = 0;
                //                        var dbConnectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = connectionString };
                //                        dbConnectionStringBuilder.Remove("Provider");
                //                        connectionString = dbConnectionStringBuilder.ToString();
                //                        Int32.TryParse(rk.GetValue("Trace", 0).ToString(), out nDefaultTraceChannels);
                //                        rk.Close();

                //                        if (Security.ValidatePID(sPID) == true)
                //                        {
                //                            // Get the product flags from the PID
                //                            int nProductFlags = 0;
                //                            Int32.TryParse(Security.GetData(sPID, Security.vars.v_products), out nProductFlags);

                //                            sStage = "7-Failed to connect to DB";
                //                            SqlConnection conn = new SqlConnection(connectionString);
                //                            sStage = "8b-Failed to read data for NT user '" + sNTUserName + "'";
                //                            string cmdText = "SELECT WRES_ID,RES_NAME,WRES_TRACE FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT";
                //                            SqlCommand cmd = new SqlCommand(cmdText, conn);
                //                            cmd.CommandType = CommandType.Text;
                //                            cmd.Parameters.AddWithValue("@WRES_NT_ACCOUNT", sNTUserName.ToLower());
                //                            conn.Open();
                //                            SqlDataReader reader = cmd.ExecuteReader();
                //                            sStage = "9b-'" + sNTUserName + "' not PfE NTAccount.";
                //                            if (reader.Read())
                //                            {
                //                                sStage = "10";
                //                                WebAdmin.SetSPSessionString(Context, basePath, "basePath", basePath);
                //                                WebAdmin.SetSPSessionString(Context, basePath, "WResID", reader["WRES_ID"].ToString());
                //                                WebAdmin.SetSPSessionString(Context, basePath, "userName", reader["RES_NAME"].ToString());
                //                                WebAdmin.SetSPSessionString(Context, basePath, "NTAccount", sNTUserName.ToLower());
                //                                WebAdmin.SetSPSessionString(Context, basePath, "SessionInfo", Guid.NewGuid().ToString().ToUpper());
                //                                int nResTrace = 0;
                //                                Int32.TryParse(reader["WRES_TRACE"].ToString(), out nResTrace);
                //                                int nActiveTrace = (nDefaultTraceChannels | nResTrace);
                //                                WebAdmin.SetSPSessionString(Context, basePath, "ActiveTraceChannels", nActiveTrace.ToString());
                //                                WebAdmin.SetSPSessionString(Context, basePath, "ProductFlags", nProductFlags.ToString());
                //                                WebAdmin.SetSPSessionString(Context, basePath, "PID", sPID.ToString());
                //                                bAuthenticated = true;
                //                            }
                //                            reader.Close();
                //                            conn.Close();
                //                        }
                //                    }
                //                }
                //            }
                //            else
                //                bAuthenticated = true;
                //        }
                //    }
                //}
            }
            catch(Exception e)
            {
                sStage += " Exception=" + e.Message;
                bAuthenticated = false;
            }
            return bAuthenticated;
        }

        internal static bool CheckUserGlobalPermission(DBAccess dba, int lWResID, WorkEnginePPM.GlobalPermissionsEnum ePermUID)
        {
            bool bRet = false;
            // Administrator has all permissions
            if (lWResID == 1)
                bRet = true;
            else
            {
                SqlCommand oCommand = null;
                SqlDataReader reader = null;
                oCommand = new SqlCommand("EPG_SP_CheckUserGlobalPermission", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add("WResID", SqlDbType.Int).Value = lWResID;
                oCommand.Parameters.Add("PermUID", SqlDbType.Int).Value = (int)ePermUID;
                reader = oCommand.ExecuteReader();

                if (reader.Read())
                    bRet = true;

                reader.Close();
                reader = null;
            }
            return bRet;
        }

        public static bool HasPagePermission(string sPageId, string sMode)
        {
            return true;
        }

        public static void DBTrace(StatusEnum eStatus, TraceChannelEnum eChannel, string sKeyword, string sFunction, string sText, string sDetails)
        {
            DBTrace(HttpContext.Current, eStatus, eChannel, sKeyword, sFunction, sText, sDetails);
        }

        public static void DBTrace(HttpContext Context, StatusEnum eStatus, TraceChannelEnum eChannel, string sKeyword, string sFunction, string sText, string sDetails)
        {
            try
            {
                int nTrace = (int)TraceChannelEnum.None;
                Int32.TryParse(WebAdmin.GetSPSessionString(Context, "ActiveTraceChannels"), out nTrace);

                if ((TraceChannelEnum)nTrace != TraceChannelEnum.None)
                {
                    // let's see if the channel is one of the active DB trace channels
                    if (((int)eChannel & nTrace) == 0)
                        return;

                    SqlConnection conn = null;
                    SqlCommand oCommand = null;
                    string sCommand = "";
                    try
                    {
                        string sConnectionString = GetConnectionString(Context);

                        int lWResID = 0;
                        Int32.TryParse(WebAdmin.GetSPSessionString(Context,"WResID"), out lWResID);

                        string sSession = WebAdmin.GetSPSessionString(Context,"SessionInfo");

                        conn = new SqlConnection(sConnectionString);
                        conn.Open();

                        sCommand =
                            "INSERT INTO EPG_LOG "
                            + " (LOG_WRES_ID,LOG_SESSION,LOG_STATUS,LOG_CHANNEL,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS) "
                            + " VALUES(@LOG_WRES_ID,@LOG_SESSION,@LOG_STATUS,@LOG_CHANNEL,@LOG_TIMESTAMP,@LOG_KEYWORD,@LOG_FUNCTION,@LOG_TEXT,@LOG_DETAILS)";

                        oCommand = new SqlCommand(sCommand, conn);

                        oCommand.Parameters.Add("@LOG_WRES_ID", SqlDbType.Int).Value = lWResID;
                        oCommand.Parameters.Add("@LOG_SESSION", SqlDbType.VarChar, 48).Value = sSession;
                        oCommand.Parameters.Add("@LOG_STATUS", SqlDbType.Int).Value = (int)eStatus;
                        oCommand.Parameters.Add("@LOG_CHANNEL", SqlDbType.Int).Value = (int)eChannel;
                        oCommand.Parameters.Add("@LOG_TIMESTAMP", SqlDbType.Timestamp).Value = DateTime.Now;
                        oCommand.Parameters.Add("@LOG_KEYWORD", SqlDbType.VarChar, 50).Value = sKeyword;
                        oCommand.Parameters.Add("@LOG_FUNCTION", SqlDbType.VarChar, 50).Value = sFunction;
                        oCommand.Parameters.Add("@LOG_TEXT", SqlDbType.VarChar, 255).Value = sText;
                        oCommand.Parameters.Add("@LOG_DETAILS", SqlDbType.NText).Value = sDetails;

                        int lRowsAffected = oCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            catch
            {
            }
        }

        //public static void SimpleDBTrace(Guid SiteId, int lStatus, string sKeyword, string sFunction, string sText, string sDetails)
        //{
        //    try
        //    {
        //        SqlConnection conn = null;
        //        SqlCommand oCommand = null;
        //        string sCommand = "";
        //        try
        //        {
        //            string sConnection = "";
        //            string basePath = "";
        //            using(SPSite site = new SPSite(SiteId))
        //            {
        //                basePath = ConfigFunctions.getConfigSetting(site.RootWeb, "EPKBasepath");
        //            }
        //            if (basePath.Length > 0)
        //            {
        //                RegistryKey rk = Registry.LocalMachine.OpenSubKey(WebAdmin.BuildSiteRegistryKey(basePath));
        //                if (rk != null)
        //                {
        //                    sConnection = rk.GetValue("ConnectionString", "").ToString();
        //                    rk.Close();
        //                }
        //            }

        //            int lWResID = 0;

        //            conn = new SqlConnection(sConnection);
        //            conn.Open();

        //            sCommand =
        //                "INSERT INTO EPG_LOG "
        //                + " (LOG_WRES_ID,LOG_SESSION,LOG_STATUS,LOG_CHANNEL,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS) "
        //                + " VALUES(@,@,@,@,@,@,@,@,@)";

        //            oCommand = new SqlCommand(sCommand, conn);

        //            oCommand.Parameters.Add("LOG_WRES_ID", SqlDbType.Int).Value = lWResID;
        //            oCommand.Parameters.Add("LOG_SESSION", SqlDbType.VarChar, 48).Value = "";
        //            oCommand.Parameters.Add("LOG_STATUS", SqlDbType.Int).Value = (int)lStatus;
        //            oCommand.Parameters.Add("LOG_CHANNEL", SqlDbType.Int).Value = (int)0;
        //            oCommand.Parameters.Add("LOG_TIMESTAMP", SqlDbType.DBTimeStamp).Value = DateTime.Now;
        //            oCommand.Parameters.Add("LOG_KEYWORD", SqlDbType.VarChar, 50).Value = sKeyword;
        //            oCommand.Parameters.Add("LOG_FUNCTION", SqlDbType.VarChar, 50).Value = sFunction;
        //            oCommand.Parameters.Add("LOG_TEXT", SqlDbType.VarChar, 255).Value = sText;
        //            oCommand.Parameters.Add("LOG_DETAILS", SqlDbType.LongVarWChar).Value = sDetails;

        //            int lRowsAffected = oCommand.ExecuteNonQuery();
        //        }
        //        catch
        //        {
        //        }
        //        finally
        //        {
        //            conn.Close();
        //            conn.Dispose();
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
    }
}
