using System;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public class PfeJob
    {
        public string Comment { get; internal set; }

        public int Context { get; internal set; }

        public string ContextData { get; internal set; }

        public string Session { get; internal set; }

        public int UserId { get; internal set; }

        public int Queue(DBAccess pfeDatabase)
        {
            var query = "INSERT INTO EPG_JOBS(JOB_GUID, JOB_CONTEXT, JOB_SESSION ,WRES_ID, JOB_SUBMITTED,JOB_STATUS, JOB_COMMENT, JOB_CONTEXT_DATA) VALUES(@JOB_GUID,@JOB_CONTEXT,@JOB_SESSION,@WRES_ID,@JOB_SUBMITTED,@JOB_STATUS,@JOB_COMMENT,@JOB_CONTEXT_DATA)";
            var sqlCommand = new SqlCommand(query, pfeDatabase.Connection, pfeDatabase.Transaction);
            sqlCommand.Parameters.AddWithValue("@JOB_GUID", Guid.NewGuid());
            sqlCommand.Parameters.AddWithValue("@JOB_CONTEXT", Context);
            sqlCommand.Parameters.AddWithValue("@JOB_SESSION", Session);
            sqlCommand.Parameters.AddWithValue("@WRES_ID", UserId);
            sqlCommand.Parameters.AddWithValue("@JOB_SUBMITTED", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@JOB_STATUS", 0);
            sqlCommand.Parameters.AddWithValue("@JOB_COMMENT", Comment);
            sqlCommand.Parameters.AddWithValue("@JOB_CONTEXT_DATA", ContextData);
            return sqlCommand.ExecuteNonQuery();
        }
    }
}