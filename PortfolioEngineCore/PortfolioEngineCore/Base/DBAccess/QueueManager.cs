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
        public static StatusEnum PostCostValues(DBAccess dba, string sComment, string sData, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            const string sCommand = "INSERT INTO EPG_JOBS(JOB_GUID,JOB_CONTEXT,JOB_SESSION,WRES_ID,JOB_SUBMITTED,JOB_STATUS,JOB_COMMENT,JOB_CONTEXT_DATA) VALUES(@JOB_GUID,@JOB_CONTEXT,@JOB_SESSION,@WRES_ID,@JOB_SUBMITTED,@JOB_STATUS,@JOB_COMMENT,@JOB_CONTEXT_DATA)";

            SqlCommand cmd = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
            cmd.Parameters.AddWithValue("@JOB_GUID", Guid.NewGuid());
            //    qjcCustom = 0
            cmd.Parameters.AddWithValue("@JOB_CONTEXT", 0);
            cmd.Parameters.AddWithValue("@JOB_SESSION", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@WRES_ID", dba.UserWResID);
            cmd.Parameters.AddWithValue("@JOB_SUBMITTED", DateTime.Now);
            cmd.Parameters.AddWithValue("@JOB_STATUS", 0); // For now let 0 mean Not Started
            cmd.Parameters.AddWithValue("@JOB_COMMENT", sComment);
            cmd.Parameters.AddWithValue("@JOB_CONTEXT_DATA", sData);
            lRowsAffected = cmd.ExecuteNonQuery();
            return eStatus;
        }
        public static StatusEnum QueueTestJob(DBAccess dba)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            const string sCommand = "INSERT INTO EPG_JOBS(JOB_GUID,JOB_CONTEXT,JOB_SESSION,WRES_ID,JOB_SUBMITTED,JOB_STATUS,JOB_COMMENT,JOB_CONTEXT_DATA) VALUES(@JOB_GUID,@JOB_CONTEXT,@JOB_SESSION,@WRES_ID,@JOB_SUBMITTED,@JOB_STATUS,@JOB_COMMENT,@JOB_CONTEXT_DATA)";

            SqlCommand cmd = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
            cmd.Parameters.AddWithValue("@JOB_GUID", Guid.NewGuid());
            //    qjcCustom = 0
            cmd.Parameters.AddWithValue("@JOB_CONTEXT", 100001);
            cmd.Parameters.AddWithValue("@JOB_SESSION", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@WRES_ID", dba.UserWResID);
            cmd.Parameters.AddWithValue("@JOB_SUBMITTED", DateTime.Now);
            cmd.Parameters.AddWithValue("@JOB_STATUS", 0); // For now let 0 mean Not Started
            cmd.Parameters.AddWithValue("@JOB_COMMENT", "Test Job");
            cmd.Parameters.AddWithValue("@JOB_CONTEXT_DATA", "");
            cmd.ExecuteNonQuery();
            return eStatus;
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
    }
}

