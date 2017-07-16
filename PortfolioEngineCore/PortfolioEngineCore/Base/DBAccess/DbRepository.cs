using System;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public class DbRepository : IDbRepository
    {
        private readonly DBAccess pfeDatabase;

        public DbRepository(DBAccess pfeDatabase)
        {
            this.pfeDatabase = pfeDatabase;
        }

        public int QueuePfeJob(PfeJob job)
        {
            var query = "INSERT INTO EPG_JOBS(JOB_GUID, JOB_CONTEXT, JOB_SESSION ,WRES_ID, JOB_SUBMITTED,JOB_STATUS, JOB_COMMENT, JOB_CONTEXT_DATA) VALUES(@JOB_GUID,@JOB_CONTEXT,@JOB_SESSION,@WRES_ID,@JOB_SUBMITTED,@JOB_STATUS,@JOB_COMMENT,@JOB_CONTEXT_DATA)";
            var sqlCommand = new SqlCommand(query, pfeDatabase.Connection, pfeDatabase.Transaction);
            sqlCommand.Parameters.AddWithValue("@JOB_GUID", Guid.NewGuid());
            sqlCommand.Parameters.AddWithValue("@JOB_CONTEXT", job.Context);
            sqlCommand.Parameters.AddWithValue("@JOB_SESSION", job.Session);
            sqlCommand.Parameters.AddWithValue("@WRES_ID", job.UserId);
            sqlCommand.Parameters.AddWithValue("@JOB_SUBMITTED", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@JOB_STATUS", 0);
            sqlCommand.Parameters.AddWithValue("@JOB_COMMENT", job.Comment);
            sqlCommand.Parameters.AddWithValue("@JOB_CONTEXT_DATA", job.ContextData);
            return sqlCommand.ExecuteNonQuery();
        }
    }
}