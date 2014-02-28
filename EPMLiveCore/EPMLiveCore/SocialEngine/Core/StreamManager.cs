using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class StreamManager : BaseManager
    {
        #region Constructors (1) 

        public StreamManager(SPWeb contextWeb) : base(contextWeb) { }

        #endregion Constructors 

        #region Methods (4) 

        // Public Methods (2) 

        public void AddUsers(Guid streamId, int[] userIds)
        {
            Parallel.ForEach(userIds, userId =>
            {
                const string SQL = @"
                    IF NOT EXISTS (SELECT StreamId FROM SS_StreamUsers WHERE StreamId = @StreamId AND UserId = @UserId)
                    BEGIN
                        INSERT INTO SS_StreamUsers (StreamId, UserId) VALUES (@StreamId, @UserId)
                    END";

                using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@StreamId", streamId);
                    sqlCommand.Parameters.AddWithValue("@UserId", userId);

                    sqlCommand.ExecuteNonQuery();
                }
            });
        }

        public Guid GetGlobalStreamId(Guid webId)
        {
            Guid streamId = FetchGlobalStreamId(webId);

            if (streamId != Guid.Empty) return streamId;

            AddGlobalStream(webId);
            return FetchGlobalStreamId(webId);
        }

        // Private Methods (2) 

        private void AddGlobalStream(Guid webId)
        {
            const string SQL = @"INSERT INTO SS_Streams (WebId) VALUES (@WebId)";

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@WebId", webId);
                sqlCommand.ExecuteNonQuery();
            }
        }

        private Guid FetchGlobalStreamId(Guid webId)
        {
            const string SQL = @"SELECT Id FROM SS_Streams WHERE WebId = @WebId AND ListId IS NULL";

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@WebId", webId);

                object streamId = sqlCommand.ExecuteScalar();

                if (streamId != null && streamId != DBNull.Value) return (Guid) streamId;
                return Guid.Empty;
            }
        }

        #endregion Methods 
    }
}