using System;
using System.Data.SqlClient;
using EPMLiveCore.SocialEngine.Entities;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class ActivityManager : BaseManager
    {
        #region Constructors (1) 

        public ActivityManager(SPWeb contextWeb) : base(contextWeb) { }

        #endregion Constructors 

        #region Methods (7) 

        // Public Methods (7) 

        public bool ActivityExists(ObjectKind objectKind, ActivityKind activityKind, Guid webId)
        {
            return ActivityExists(objectKind, activityKind, webId, null, null);
        }

        public bool ActivityExists(ObjectKind objectKind, ActivityKind activityKind, Guid webId, Guid listId)
        {
            return ActivityExists(objectKind, activityKind, webId, listId, null);
        }

        public bool ActivityExists(ObjectKind objectKind, ActivityKind activityKind,
            Guid webId, Guid? listId, int? itemId)
        {
            string sql = @"SELECT COUNT(dbo.SS_Activities.Id) AS Total FROM dbo.SS_Activities
                                    INNER JOIN dbo.SS_Threads ON dbo.SS_Activities.ThreadId = dbo.SS_Threads.Id
                                    GROUP BY dbo.SS_Threads.Kind, dbo.SS_Activities.Kind, dbo.SS_Threads.WebId, dbo.SS_Threads.ListId, dbo.SS_Threads.ItemId
                                    HAVING (dbo.SS_Threads.Kind = @ObjectKind) AND (dbo.SS_Activities.Kind = @ActivityKind)
                                       AND (dbo.SS_Threads.WebId = @WebId) AND (dbo.SS_Threads.ListId = @ListId) AND (dbo.SS_Threads.ItemId = @ItemId)";

            if (!listId.HasValue) sql = sql.Replace("= @ListId", "IS NULL");
            if (!itemId.HasValue) sql = sql.Replace("= @ItemId", "IS NULL");

            using (var sqlCommand = new SqlCommand(sql, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@ObjectKind", objectKind);
                sqlCommand.Parameters.AddWithValue("@ActivityKind", activityKind);
                sqlCommand.Parameters.AddWithValue("@WebId", webId);
                sqlCommand.Parameters.AddWithValue("@ListId", listId.HasValue ? (object) listId : DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@ItemId", itemId.HasValue ? (object) itemId : DBNull.Value);

                object activityCount = sqlCommand.ExecuteScalar();

                if (activityCount == null || activityCount == DBNull.Value) return false;
                return (int) activityCount > 0;
            }
        }

        public void EnqueueActivity(Guid siteId, Guid webId, Guid listId, int userId, DateTime activityTime,
            DateTime relatedActivityTime)
        {
            const string GET_QUEUED_ACTIVITY_SQL = @"
                SELECT  TOP (1) ActivityQueueId, ItemCount
                FROM    dbo.ActivityQueue
                WHERE   (ListId = @ListId) AND (WebId = @WebId) AND (UserId = @UserId) AND (PostTime = @RelatedActivityTime)";

            Guid queuedActivityId = Guid.Empty;
            int itemCount = 0;

            using (SqlConnection sqlConnection = EPMLiveSqlConnection)
            {
                using (var sqlCommand = new SqlCommand(GET_QUEUED_ACTIVITY_SQL, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@WebId", webId);
                    sqlCommand.Parameters.AddWithValue("@ListId", listId);
                    sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    sqlCommand.Parameters.AddWithValue("@RelatedActivityTime", relatedActivityTime);

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        queuedActivityId = reader.GetGuid(0);
                        itemCount = reader.GetInt32(1);
                    }
                }

                if (queuedActivityId == Guid.Empty)
                {
                    const string INSERT_SQL =
                        @"INSERT INTO dbo.ActivityQueue (SiteId, WebId, ListId, UserId, PostTime, ItemCount) VALUES (@SiteId, @WebId, @ListId, @UserId, @ActivityTime, 2)";

                    using (var sqlCommand = new SqlCommand(INSERT_SQL, SqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@SiteId", siteId);
                        sqlCommand.Parameters.AddWithValue("@WebId", webId);
                        sqlCommand.Parameters.AddWithValue("@ListId", listId);
                        sqlCommand.Parameters.AddWithValue("@UserId", userId);
                        sqlCommand.Parameters.AddWithValue("@ActivityTime", activityTime);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    const string UPDATE_SQL =
                        @"UPDATE dbo.ActivityQueue SET ItemCount = @ItemCount AND PostTime = @ActivityTime WHERE ActivityQueueId = @Id";

                    using (var sqlCommand = new SqlCommand(UPDATE_SQL, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ItemCount", ++itemCount);
                        sqlCommand.Parameters.AddWithValue("@ActivityTime", activityTime);
                        sqlCommand.Parameters.AddWithValue("@Id", queuedActivityId);

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                sqlConnection.Close();
            }
        }

        public Activity FindRelatedActivity(Guid listId, int itemId, DateTime date, TimeSpan interval)
        {
            const string SQL = @"
                SELECT TOP (1) dbo.SS_Activities.Id, dbo.SS_Activities.MassOperation, dbo.SS_Activities.Date
                       FROM    dbo.SS_Threads INNER JOIN dbo.SS_Activities ON dbo.SS_Threads.Id = dbo.SS_Activities.ThreadId
                       WHERE   (dbo.SS_Threads.ListId = @ListId) AND (dbo.SS_Threads.ItemId = @ItemId) 
                               AND (dbo.SS_Activities.Date >= @Date) AND (dbo.SS_Activities.Kind < 3)
                       ORDER BY dbo.SS_Activities.Date DESC";

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@ListId", listId);
                sqlCommand.Parameters.AddWithValue("@ItemId", itemId);
                sqlCommand.Parameters.AddWithValue("@Date", date - interval);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    return new Activity
                    {
                        Id = reader.GetGuid(0),
                        IsMassOperation = reader.GetBoolean(1),
                        Date = reader.GetDateTime(2)
                    };
                }
            }

            return null;
        }

        public void FlagMassOperation(Guid id)
        {
            const string SQL = @"UPDATE SS_Activities SET MassOperation = 1 WHERE Id = @Id";

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public Activity RegisterActivity(Activity activity)
        {
            const string SQL =
                @"INSERT INTO SS_Activities (Id, Data, Kind, Date, UserId, ThreadId) VALUES (@Id, @Data, @Kind, @UserId, @ThreadId)";

            activity.Id = Guid.NewGuid();

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", activity.Id);
                sqlCommand.Parameters.AddWithValue("@Data", (object) activity.Data ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@Kind", activity.Kind);
                sqlCommand.Parameters.AddWithValue("@Date", activity.Date);
                sqlCommand.Parameters.AddWithValue("@UserId", activity.UserId);
                sqlCommand.Parameters.AddWithValue("@ThreadId", activity.Thread.Id);

                sqlCommand.ExecuteNonQuery();
            }

            return activity;
        }

        #endregion Methods 
    }
}