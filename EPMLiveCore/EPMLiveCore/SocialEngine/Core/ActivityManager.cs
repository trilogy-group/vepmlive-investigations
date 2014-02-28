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

        #region Methods (4) 

        // Public Methods (4) 

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

        public void RegisterActivity(Activity activity)
        {
            const string SQL =
                @"INSERT INTO SS_Activities (Data, Kind, UserId, ThreadId) VALUES (@Data, @Kind, @UserId, @ThreadId)";

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Data", (object) activity.Data ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@Kind", activity.Kind);
                sqlCommand.Parameters.AddWithValue("@UserId", activity.UserId);
                sqlCommand.Parameters.AddWithValue("@ThreadId", activity.Thread.Id);

                sqlCommand.ExecuteNonQuery();
            }
        }

        #endregion Methods 
    }
}