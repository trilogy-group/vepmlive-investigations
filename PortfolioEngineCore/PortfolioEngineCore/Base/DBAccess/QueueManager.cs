using System;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public class dbaQueueManager
    {
        public static StatusEnum SelectQueue(DBAccess dba, DateTime dtFrom, DateTime dtTo, string sStatusList, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                SqlCommand oCommand = new SqlCommand("EPG_SP_ReadJobQueue", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@FromDate", dtFrom);
                oCommand.Parameters.AddWithValue("@ToDate", dtTo);
                oCommand.Parameters.AddWithValue("@sList", sStatusList);
                SqlDataReader reader = oCommand.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectQueue", (StatusEnum)99999, ex.Message.ToString());
            }
            return eStatus;

        }
        public static StatusEnum SelectQueue2(DBAccess dba, int nPage, int nRowsPerPage, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                SqlCommand oCommand = new SqlCommand("EPG_SP_ReadJobQueue2", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@intStartRow", ((nPage - 1) * nRowsPerPage) + 1);
                oCommand.Parameters.AddWithValue("@intEndRow", (nPage) * nRowsPerPage);
                SqlDataReader reader = oCommand.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectQueue2", (StatusEnum)99999, ex.Message.ToString());
            }
            return eStatus;

        }

        public static StatusEnum PostCostValues(DBAccess databaseAccess, string jobComment, string jobContextData, out int rowsAffected)
        {
            var job = new PfeJob()
            {
                Context = 0,
                Session = Guid.NewGuid().ToString(),
                UserId = databaseAccess.UserWResID,
                Comment = jobComment,
                ContextData = jobContextData
            };
            rowsAffected = job.Queue(new DbRepository(databaseAccess), new Msmq(@".\private$\Bills"), "basepath");
            return StatusEnum.rsSuccess;
        }

        public static StatusEnum QueueTestJob(DBAccess dba)
        {
            var job = new PfeJob()
            {
                Context = 100001,
                Session = Guid.NewGuid().ToString(),
                UserId = dba.UserWResID,
                Comment = "Test Job",
                ContextData = ""
            };
            job.Queue(new DbRepository(dba), new Msmq(@".\private$\Bills"), "basepath");
            return StatusEnum.rsSuccess;
        }

        public static StatusEnum SelectHeartbeat(DBAccess dba, out DateTime dtHeartbeat)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            const string cmdText = "SELECT ADM_QM_HEARTBEAT_DATE FROM EPG_ADMIN";
            DataTable dt;
            dtHeartbeat = DateTime.MinValue;
            if (dba.SelectData(cmdText, (StatusEnum)99999, out dt) == StatusEnum.rsSuccess)
            {
                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    dtHeartbeat = DBAccess.ReadDateValue(row["ADM_QM_HEARTBEAT_DATE"]);
                }
            }
            return eStatus;
        }

        public static StatusEnum DeleteRowByGuid(DBAccess dba, string sGuid)
        {
            StatusEnum eStatus;
            int lRowsAffected;
            if ((eStatus = dba.DeleteData("DELETE FROM EPG_UPLOADS WHERE UPL_GUID = '" + sGuid + "'", (StatusEnum)98789, out lRowsAffected)) != StatusEnum.rsSuccess) return eStatus;
            if ((eStatus = dba.DeleteData("DELETE FROM EPG_JOB_MSGS WHERE JOB_GUID = '" + sGuid + "'", (StatusEnum)98788, out lRowsAffected)) != StatusEnum.rsSuccess) return eStatus;
            if ((eStatus = dba.DeleteData("DELETE FROM EPG_JOBS WHERE JOB_GUID = '" + sGuid + "'", (StatusEnum)98787, out lRowsAffected)) != StatusEnum.rsSuccess) return eStatus;
            return StatusEnum.rsSuccess;
        }

        public static StatusEnum DeleteCompletedRowsOlderThan1Week(DBAccess dba)
        {
            const string cmdText = "SELECT JOB_GUID FROM EPG_JOBS WHERE JOB_STATUS = -1 AND JOB_COMPLETED < DATEADD(day, -7, GETDATE())";
            StatusEnum eStatus;
            int lRowsAffected;
            if ((eStatus = dba.DeleteData("DELETE FROM EPG_UPLOADS WHERE UPL_GUID IN (" + cmdText + ")", (StatusEnum)98789, out lRowsAffected)) != StatusEnum.rsSuccess) return eStatus;
            if ((eStatus = dba.DeleteData("DELETE FROM EPG_JOB_MSGS WHERE JOB_GUID IN (" + cmdText + ")", (StatusEnum)98788, out lRowsAffected)) != StatusEnum.rsSuccess) return eStatus;
            if ((eStatus = dba.DeleteData("DELETE FROM EPG_JOBS WHERE JOB_GUID IN (" + cmdText + ")", (StatusEnum)98787, out lRowsAffected)) != StatusEnum.rsSuccess) return eStatus;
            return StatusEnum.rsSuccess;
        }

        public static StatusEnum DeleteAllRowsOlderThan1Month(DBAccess dba)
        {
            const string cmdText = "SELECT JOB_GUID FROM EPG_JOBS WHERE JOB_SUBMITTED < DATEADD(month, -1, GETDATE())";
            StatusEnum eStatus;
            int lRowsAffected;
            if ((eStatus = dba.DeleteData("DELETE FROM EPG_UPLOADS WHERE UPL_GUID IN (" + cmdText + ")", (StatusEnum)98789, out lRowsAffected)) != StatusEnum.rsSuccess) return eStatus;
            if ((eStatus = dba.DeleteData("DELETE FROM EPG_JOB_MSGS WHERE JOB_GUID IN (" + cmdText + ")", (StatusEnum)98788, out lRowsAffected)) != StatusEnum.rsSuccess) return eStatus;
            if ((eStatus = dba.DeleteData("DELETE FROM EPG_JOBS WHERE JOB_GUID IN (" + cmdText + ")", (StatusEnum)98787, out lRowsAffected)) != StatusEnum.rsSuccess) return eStatus;
            return StatusEnum.rsSuccess;
        }
    }
}

