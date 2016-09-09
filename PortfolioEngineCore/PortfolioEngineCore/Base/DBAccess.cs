using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PortfolioEngineCore
{
    public class DBAccess : SqlDb
    {

        public DBAccess(string connectionString) : base(connectionString) { }
        public DBAccess(string connectionString, SqlConnection connection) : base(connectionString, connection) { }

    }

    public class SqlDb : IDisposable
    {
        private string m_sConnect = string.Empty;
        private string m_sEPKUID = string.Empty;
        private string m_sEPKPWD = string.Empty;
        private SqlConnection m_oConnection = null;
        private SqlTransaction m_oTransaction = null;

        private static SeverityEnum m_eStatusSeverity = SeverityEnum.None;
        private static StatusEnum m_eStatus = StatusEnum.rsSuccess;
        private static string m_sStatusFunction = string.Empty;
        private static string m_sStatusText = string.Empty;
        private static string m_sStackTrace = string.Empty;

        private int m_lActiveTraceChannels = 0;
        private CStruct m_xTraceMessages = null;
        private string m_sSessionInfo = "";
        public int UserWResID = 0;
        public string UserName = "";

        public SqlDb(string connectionString)
        {
            m_sConnect = connectionString;
            //ResetStatus();
        }

        public SqlDb(string connectionString, SqlConnection connection)
        {
            m_oConnection = connection;
            m_sConnect = connectionString;
            //ResetStatus();
        }

        public StatusEnum Open()
        {
            try
            {
                if (m_oConnection == null || m_oConnection.State != ConnectionState.Open)
                {
                    ResetStatus();
                    if (m_oConnection == null) m_oConnection = new SqlConnection();
                    var dbConnectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = m_sConnect };
                    dbConnectionStringBuilder.Remove("Provider");
                    //if (m_sEPKUID == "")
                    m_oConnection.ConnectionString = dbConnectionStringBuilder.ToString() + ";Application Name=PortfolioEngine";
                    //else
                    //    m_oConnection.ConnectionString = dbConnectionStringBuilder.ToString() + ";UID=" + m_sEPKUID + ";PWD=" + m_sEPKPWD + ";Application Name=PortfolioEngine";

                    m_oConnection.Open();
                }
            }
            catch (Exception ex)
            {
                return HandleStatusError(SeverityEnum.Exception, "Sql.Open", (StatusEnum)99959, ex.Message.ToString() + "; Connect='" + m_oConnection.ConnectionString + "'");
            }
            return StatusEnum.rsSuccess;
        }

        public void Close()
        {
            if (m_oConnection != null)
            {
                if (m_oConnection.State != System.Data.ConnectionState.Closed)
                    m_oConnection.Close();
                m_oConnection.Dispose();
                m_oConnection = null;
            }
        }

        public StatusEnum SelectData(string cmdText, StatusEnum eStatusOnException, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                System.Data.SqlClient.SqlCommand cmd = new SqlCommand(cmdText, m_oConnection, m_oTransaction);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "SelectData", (StatusEnum)eStatusOnException, ex.Message.ToString());
                throw new PFEException(99991, "SqlDb.SelectData : " + ex.GetBaseMessage());
            }
            return eStatus;
        }

        public StatusEnum SelectData(SqlCommand cmd, StatusEnum eStatusOnException, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "SelectData", (StatusEnum)eStatusOnException, ex.Message.ToString());
                throw new PFEException(99992, "SqlDb.SelectData : " + ex.GetBaseMessage());
            }
            return eStatus;
        }

        public StatusEnum SelectDataById(string cmdText, int id, StatusEnum eStatusOnException, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, m_oConnection, m_oTransaction);
                cmd.Parameters.AddWithValue("p1", id);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "SelectDataById", (StatusEnum)eStatusOnException, ex.Message);
                throw new PFEException(99993, "SqlDb.SelectDataById : " + ex.GetBaseMessage());
            }
            return eStatus;
        }
        public StatusEnum SelectDataByName(string cmdText, string name, StatusEnum eStatusOnException, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, m_oConnection, m_oTransaction);
                cmd.Parameters.AddWithValue("p1", name);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "SelectDataByName", (StatusEnum)eStatusOnException, ex.Message);
            }
            return eStatus;
        }

        public StatusEnum DeleteDataById(string cmdText, int id, StatusEnum eStatusOnException, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, m_oConnection, m_oTransaction);
                cmd.Parameters.AddWithValue("p1", id);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "DeleteDataById", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            return eStatus;
        }

        public StatusEnum DeleteData(string cmdText, StatusEnum eStatusOnException, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, m_oConnection, m_oTransaction);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "DeleteData", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            return eStatus;
        }

        public StatusEnum ExecuteReader(string sCommand, StatusEnum eStatusOnException, out SqlDataReader reader)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            SqlCommand oCommand = null;
            try
            {
                oCommand = new SqlCommand(sCommand, m_oConnection, m_oTransaction);
                reader = oCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                reader = null;
                eStatus = HandleStatusError(SeverityEnum.Exception, "Sql.ExecuteReader", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            finally
            {
                oCommand = null;
            }
            return eStatus;
        }

        public StatusEnum ExecuteReader(SqlCommand oCommand, StatusEnum eStatusOnException, out SqlDataReader reader)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            try
            {
                reader = oCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                reader = null;
                eStatus = HandleStatusError(SeverityEnum.Exception, "Sql.ExecuteReader", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            finally
            {
                oCommand = null;
            }
            return eStatus;
        }

        public StatusEnum ExecuteNonQuery(string sCommand, StatusEnum eStatusOnException, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            SqlCommand oCommand = null;
            lRowsAffected = 0;
            try
            {
                oCommand = new SqlCommand(sCommand, m_oConnection, m_oTransaction);
                lRowsAffected = oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "ExecuteNonQuery", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            return eStatus;
        }

        public StatusEnum Status
        {
            get
            {
                return m_eStatus;
            }
            set
            {
                m_eStatus = value;
            }
        }

        public string StatusText
        {
            get
            {
                return m_sStatusText;
            }
            set
            {
                m_sStatusText = value;
            }
        }

        public string StackTrace
        {
            get
            {
                return m_sStackTrace;
            }
            set
            {
                m_sStackTrace = value;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return m_oConnection;
            }
        }

        public SqlTransaction Transaction
        {
            get
            {
                return m_oTransaction;
            }
        }

        public void ResetStatus()
        {
            m_eStatus = StatusEnum.rsSuccess;
            m_sStatusFunction = string.Empty;
            m_sStatusText = string.Empty;
            m_sStackTrace = string.Empty;
        }


        public virtual string FormatErrorText()
        {

            string s = "";
            if (m_eStatus != StatusEnum.rsSuccess)
            {
                switch (m_eStatusSeverity)
                {
                    case SeverityEnum.Exception:
                        s = "Exception " + m_eStatus.ToString();
                        break;
                    case SeverityEnum.Error:
                        s = "Error " + m_eStatus.ToString();
                        break;
                    default:
                        s = "Status Error " + m_eStatus.ToString();
                        break;
                }
                if (string.IsNullOrEmpty(m_sStatusFunction) == false)
                    s += " has occurred in " + m_sStatusFunction;

                if (m_sStatusText != string.Empty)
                    s += "\n" + m_sStatusText;
                if (m_sStackTrace != string.Empty)
                    s += "\n" + "Trace : '" + m_sStackTrace + "'"; ;
            }
            return s;
        }

        public virtual StatusEnum HandleException(string sFunction, StatusEnum eStatus, Exception ex)
        {
            m_eStatusSeverity = SeverityEnum.Exception;
            m_sStatusFunction = sFunction;
            m_eStatus = eStatus;
            m_sStatusText = ex.Message.ToString();
            m_sStackTrace = ex.StackTrace.ToString();
            // V4.4.3 - don't let exception writing to eventlog hide original error
            try { EventLog.WriteEntry("DBAccess Exception", FormatErrorText(), EventLogEntryType.Error); }
            catch { }
            DBTrace(eStatus, TraceChannelEnum.Exception, "HandleException", sFunction, ex.Message.ToString(), "Exception Stack : " + ex.StackTrace.ToString(), true);
            return m_eStatus;
        }

        public virtual StatusEnum HandleStatusError(SeverityEnum eSeverity, string sFunction, StatusEnum eStatus, string sText)
        {
            m_eStatusSeverity = eSeverity;
            m_sStatusFunction = sFunction;
            m_eStatus = eStatus;
            m_sStatusText = sText;
            // V4.4.3 - don't let exception writing to eventlog hide original error
            try { EventLog.WriteEntry("DBAccess Error", FormatErrorText(), EventLogEntryType.Error); }
            catch { }
            DBTrace(eStatus, TraceChannelEnum.Exception, "HandleStatusError", sFunction, sText, "Severity : " + eSeverity.ToString(), true);
            return m_eStatus;
        }

        //public override StatusEnum HandleException(string sFunction, StatusEnum eStatus, Exception ex)
        //{
        //    base.HandleException(sFunction, eStatus, ex);
        //    DBTrace(eStatus, TraceChannelEnum.Exception, "HandleException", sFunction, ex.Message.ToString(), "Exception Stack : " + ex.StackTrace.ToString(), true);
        //    return eStatus;
        //}

        //public override StatusEnum HandleStatusError(SeverityEnum eSeverity, string sFunction, StatusEnum eStatus, string sText)
        //{
        //    base.HandleStatusError(eSeverity, sFunction, eStatus, sText);
        //    DBTrace(eStatus, TraceChannelEnum.Exception, "HandleStatusError", sFunction, sText, "Severity : " + eSeverity.ToString(), true);
        //    return eStatus;
        //}

        public void DBTrace(StatusEnum eStatus, TraceChannelEnum eChannel, string sKeyword, string sFunction, string sText, string sDetails, bool bImmediate = false)
        {

            // let's see if the channel is one of the active DB trace channels
            // V4.4.3 - log all channels
            //if (((int)eChannel & m_lActiveTraceChannels) == 0)
            //    return;

            if (m_xTraceMessages == null)
            {
                m_xTraceMessages = new CStruct();
                m_xTraceMessages.Initialize("TraceMessages");
            }

            CStruct xTrace;
            xTrace = m_xTraceMessages.CreateSubStruct("Trace");
            xTrace.CreateIntAttr("Status", (int)eStatus);
            xTrace.CreateIntAttr("Channel", (int)eChannel);
            xTrace.CreateDateAttr("Timestamp", DateTime.Now);
            xTrace.CreateStringAttr("Keyword", sKeyword);
            xTrace.CreateStringAttr("Function", sFunction);
            xTrace.CreateStringAttr("Text", sText);
            xTrace.CreateStringAttr("Details", sDetails);

            //if (bImmediate)
            {
                WriteTrace();
            }
        }

        private void WriteTrace()
        {
            if (m_xTraceMessages == null)
                return;
            if (Open() != StatusEnum.rsSuccess)
                return;

            SqlCommand oCommand;
            string sCommand;

            // delete lines > 5 days old but only once every 3 days - don't see real harm in leaving this here
            sCommand = "If Exists(Select TOP 1 LOG_TIMESTAMP From EPG_LOG Where LOG_TIMESTAMP < (GETDATE() - 8))"
                        + " Delete From EPG_LOG Where LOG_TIMESTAMP < (GETDATE() - 5)";
            oCommand = new SqlCommand(sCommand, Connection);
            oCommand.CommandType = CommandType.Text;
            oCommand.ExecuteNonQuery();

            sCommand =
                "INSERT INTO EPG_LOG (LOG_WRES_ID,LOG_SESSION,LOG_STATUS,LOG_CHANNEL,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS) "
              + " VALUES(@LOG_WRES_ID,@LOG_SESSION,@LOG_STATUS,@LOG_CHANNEL,GetDate(),@LOG_KEYWORD,@LOG_FUNCTION,@LOG_TEXT,@LOG_DETAILS)";
            try
            {
                oCommand = new SqlCommand(sCommand, Connection);

                oCommand.Parameters.Add("@LOG_WRES_ID", SqlDbType.Int).Value = UserWResID;
                oCommand.Parameters.Add("@LOG_SESSION", SqlDbType.VarChar, vb.Max(1, m_sSessionInfo.Length)).Value = m_sSessionInfo;

                SqlParameter pStatus = oCommand.Parameters.Add("@LOG_STATUS", SqlDbType.Int);
                SqlParameter pChannel = oCommand.Parameters.Add("@LOG_CHANNEL", SqlDbType.Int);
                //SqlParameter pTimestamp = oCommand.Parameters.Add("@LOG_TIMESTAMP", SqlDbType.Timestamp);
                SqlParameter pKeyword = oCommand.Parameters.Add("@LOG_KEYWORD", SqlDbType.VarChar, 50);
                SqlParameter pFunction = oCommand.Parameters.Add("@LOG_FUNCTION", SqlDbType.VarChar, 50);
                SqlParameter pText = oCommand.Parameters.Add("@LOG_TEXT", SqlDbType.VarChar, 255);
                SqlParameter pDetails = oCommand.Parameters.Add("@LOG_DETAILS", SqlDbType.VarChar, 2048);


                Queue<CStruct> clnTraceMessages = m_xTraceMessages.GetCollection("Trace");
                foreach (CStruct xTrace in clnTraceMessages)
                {
                    pStatus.Value = xTrace.GetIntAttr("Status");
                    pChannel.Value = xTrace.GetIntAttr("Channel");
                    //pTimestamp.Value = xTrace.GetDateAttr("Timestamp");
                    pKeyword.Value = vb.Left(xTrace.GetStringAttr("Keyword"), 48);
                    pFunction.Value = vb.Left(xTrace.GetStringAttr("Function"), 48);
                    pText.Value = vb.Left(xTrace.GetStringAttr("Text"), 253);
                    pDetails.Value = vb.Left(xTrace.GetStringAttr("Details"), 2048);

                    int lRowsAffected = oCommand.ExecuteNonQuery();
                }
                m_xTraceMessages = null;
            }
            catch (Exception ex)
            {
                // v4.4.3 - don't lose the original exception code
                if (m_eStatus == StatusEnum.rsSuccess)
                {
                    Status = (StatusEnum)9899;
                    StatusText = "WriteTrace Exception : " + ex.Message.ToString();
                }
            }
            return;
        }

        public void WriteImmTrace(string sKeyword, string sFunction, string sText, string sDetails)
        {
            if (Open() != StatusEnum.rsSuccess)
                return;

            try
            {
                SqlCommand oCommand;
                string sCommand;

                // delete lines > 5 days old but only once every 3 days
                sCommand = "If Exists(Select TOP 1 LOG_TIMESTAMP From EPG_LOG Where LOG_CHANNEL=9999 And LOG_TIMESTAMP < (GETDATE() - 8))"
                            + " Delete From EPG_LOG Where LOG_CHANNEL=9999 And LOG_TIMESTAMP < (GETDATE() - 5)";
                oCommand = new SqlCommand(sCommand, Connection);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();

                sCommand =
                    "INSERT INTO EPG_LOG (LOG_TIMESTAMP,LOG_WRES_ID,LOG_SESSION,LOG_STATUS,LOG_CHANNEL,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS) "
                  + " VALUES(GetDate(),@LOG_WRES_ID,@LOG_SESSION,@LOG_STATUS,@LOG_CHANNEL,@LOG_KEYWORD,@LOG_FUNCTION,@LOG_TEXT,@LOG_DETAILS)";
                oCommand = new SqlCommand(sCommand, Connection);

                oCommand.Parameters.Add("@LOG_WRES_ID", SqlDbType.Int).Value = UserWResID;
                oCommand.Parameters.Add("@LOG_SESSION", SqlDbType.VarChar, vb.Max(1, m_sSessionInfo.Length)).Value = m_sSessionInfo;

                SqlParameter pStatus = oCommand.Parameters.Add("@LOG_STATUS", SqlDbType.Int);
                SqlParameter pChannel = oCommand.Parameters.Add("@LOG_CHANNEL", SqlDbType.Int);
                SqlParameter pKeyword = oCommand.Parameters.Add("@LOG_KEYWORD", SqlDbType.VarChar, 50);
                SqlParameter pFunction = oCommand.Parameters.Add("@LOG_FUNCTION", SqlDbType.VarChar, 50);
                SqlParameter pText = oCommand.Parameters.Add("@LOG_TEXT", SqlDbType.VarChar, 255);
                SqlParameter pDetails = oCommand.Parameters.Add("@LOG_DETAILS", SqlDbType.VarChar, 2048);


                pStatus.Value = 0;
                pChannel.Value = 9999;
                if (sKeyword.Length > 48) sKeyword = sKeyword.Substring(1, 48);
                pKeyword.Value = sKeyword;
                if (sFunction.Length > 48) sFunction = sFunction.Substring(1, 48);
                pFunction.Value = sFunction;
                if (sText.Length > 253) sText = sText.Substring(1, 253);
                pText.Value = sText;
                if (sDetails.Length > 2048) sDetails = sDetails.Substring(1, 2048);
                pDetails.Value = sDetails;

                int lRowsAffected = oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // v4.4.3 - don't lose the original exception code
                //Status = (StatusEnum)9899;
                //StatusText = "WriteTrace Exception : " + ex.Message.ToString();
            }
            return;
        }

        public void BeginTransaction()
        {
            //m_oConnection.Execute CommandText:="BEGIN TRAN", Options:=adExecuteNoRecords
            m_oTransaction = m_oConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            //m_oConnection.Execute CommandText:="IF @@TRANCOUNT > 0 COMMIT TRAN", Options:=adExecuteNoRecords
            if (m_oTransaction != null)
                m_oTransaction.Commit();
            m_oTransaction = null;
        }

        public void RollbackTransaction()
        {
            //m_oConnection.Execute CommandText:="IF @@TRANCOUNT > 0 ROLLBACK TRAN", Options:=adExecuteNoRecords
            if (m_oTransaction != null)
                m_oTransaction.Rollback();
            m_oTransaction = null;
        }

        //public virtual void DBTrace(StatusEnum eStatus, TraceChannelEnum eChannel, string sKeyword, string sFunction, string sText, string sDetails, bool bImmediate)
        //{
        //}

        static public DateTime ReadDateValue(object obj)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToDateTime(obj);
            }
            return DateTime.MinValue;
        }

        static public DateTime ReadDateValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                try { return Convert.ToDateTime(obj); } catch { return DateTime.Parse("1901-01-01"); }
            }
            bIsNull = true;
            return DateTime.MinValue;
        }

        static public string ReadStringValue(object obj)
        {
            return ReadStringValue(obj, "");
        }

        static public string ReadStringValue(object obj, string sDefault)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToString(obj);
            }
            return sDefault;
        }

        static public string ReadStringValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                return Convert.ToString(obj);
            }
            bIsNull = true;
            return "";
        }

        static public double ReadDoubleValue(object obj)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToDouble(obj);
            }
            return 0.0;
        }

        static public double ReadDoubleValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                return Convert.ToDouble(obj);
            }
            bIsNull = true;
            return 0.0;
        }

        static public decimal ReadDecimalValue(object obj)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToDecimal(obj);
            }
            return 0.0M;
        }

        static public decimal ReadDecimalValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                return Convert.ToDecimal(obj);
            }
            bIsNull = true;
            return 0.0M;
        }

        static public bool ReadBoolValue(object obj)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToBoolean(obj);
            }
            return false;
        }

        static public bool ReadBoolValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                return Convert.ToBoolean(obj);
            }
            bIsNull = true;
            return false;
        }

        static public int ReadIntValue(object obj)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                try { return Convert.ToInt32(obj); } catch { return 0; }
            }
            return 0;
        }

        static public int ReadIntValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                try { return Convert.ToInt32(obj); } catch { return 0; }
            }
            bIsNull = true;
            return 0;
        }

        static public Guid ReadGuidValue(object obj)
        {
            return new Guid(Convert.ToString(obj));
        }

        public static string PrepareText(string sText)
        {
            return "'" + sText.Replace("'", "''") + "'";
        }

        public bool GetLastIdentityValue(out int lAutoNumber)
        {
            //ResetStatus();
            SqlCommand oCommand = new SqlCommand("EPG_SP_GetLastAutonumber", this.Connection);
            oCommand.Transaction = this.Transaction;
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = oCommand.ExecuteReader();
            lAutoNumber = 0;
            if (reader.Read())
            {
                lAutoNumber = ReadIntValue(reader["AutoNumber"]);
            }
            reader.Close();
            return true;
            //Exception_Error:
            //    eStatus = HandleException("CDbAccess.GetLastIdentityValue", 9703)
            //    GetLastIdentityValue = eStatus
        }

        public static string FormatAdminError(string severity, string location, string message, string trace = "")
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("error");
            xReply.CreateString("severity", severity);
            xReply.CreateString("location", location);
            xReply.CreateString("message", message);
            xReply.CreateString("trace", trace);
            return xReply.XML();
        }

        public void Dispose()
        {
            Close();
        }
    }
}

