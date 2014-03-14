using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EPMLiveCore.SocialEngine.Entities;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class ActivityManager : BaseManager
    {
        #region Constructors (1) 

        public ActivityManager(SPWeb contextWeb) : base(contextWeb) { }

        #endregion Constructors 

        #region Methods (11) 

        // Public Methods (11) 

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
            return ActivityExists(objectKind, activityKind, webId, listId, itemId, null);
        }

        public bool ActivityExists(ObjectKind objectKind, ActivityKind activityKind,
            Guid webId, Guid? listId, int? itemId, string activityKey)
        {
            string sql = @"SELECT COUNT(dbo.SS_Activities.Id) AS Total FROM dbo.SS_Activities
                                    INNER JOIN dbo.SS_Threads ON dbo.SS_Activities.ThreadId = dbo.SS_Threads.Id
                                    GROUP BY dbo.SS_Threads.Kind, dbo.SS_Activities.Kind, dbo.SS_Threads.WebId, 
                                             dbo.SS_Threads.ListId, dbo.SS_Threads.ItemId, dbo.SS_Activities.ActivityKey
                                    HAVING (dbo.SS_Threads.Kind = @ObjectKind) AND (dbo.SS_Activities.Kind = @ActivityKind)
                                       AND (dbo.SS_Threads.WebId = @WebId) AND (dbo.SS_Threads.ListId = @ListId) 
                                       AND (dbo.SS_Threads.ItemId = @ItemId) AND (dbo.SS_Activities.ActivityKey = @Key)";

            if (!listId.HasValue) sql = sql.Replace("= @ListId", "IS NULL");
            if (!itemId.HasValue) sql = sql.Replace("= @ItemId", "IS NULL");
            if (string.IsNullOrEmpty(activityKey)) sql = sql.Replace("= @Key", "IS NULL");

            using (var sqlCommand = new SqlCommand(sql, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@ObjectKind", objectKind);
                sqlCommand.Parameters.AddWithValue("@ActivityKind", activityKind);
                sqlCommand.Parameters.AddWithValue("@WebId", webId);
                sqlCommand.Parameters.AddWithValue("@ListId", listId.HasValue ? (object) listId : DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@ItemId", itemId.HasValue ? (object) itemId : DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@Key", string.IsNullOrEmpty(activityKey) ? DBNull.Value : (object) activityKey);

                object activityCount = sqlCommand.ExecuteScalar();

                if (activityCount == null || activityCount == DBNull.Value) return false;
                return (int) activityCount > 0;
            }
        }

        public void DeleteActivity(Dictionary<string, object> filters)
        {
            IEnumerable<string> where = filters.Keys.Select(key => string.Format(@"{0} = @{0}", key));
            string sql = string.Format(@"DELETE FROM SS_Activities WHERE {0}", string.Join(" AND ", where));

            using (var sqlCommand = new SqlCommand(sql, SqlConnection))
            {
                foreach (var pair in filters)
                {
                    sqlCommand.Parameters.AddWithValue("@" + pair.Key, pair.Value);
                }

                sqlCommand.ExecuteNonQuery();
            }
        }

        public void EnqueueActivity(Guid siteId, Guid webId, Guid listId, int userId, DateTime activityTime,
            DateTime relatedActivityTime)
        {
            const string GET_QUEUED_ACTIVITY_SQL = @"
                SELECT   TOP (1) ActivityQueueId, ItemCount
                FROM     dbo.ActivityQueue
                WHERE    (ListId = @ListId) AND (WebId = @WebId) AND (UserId = @UserId) AND (PostTime >= @RelatedActivityTime)
                ORDER BY PostTime DESC";

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

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            queuedActivityId = reader.GetGuid(0);
                            itemCount = reader.GetInt32(1);
                        }

                        reader.Close();
                    }
                }

                if (queuedActivityId == Guid.Empty)
                {
                    const string INSERT_SQL =
                        @"INSERT INTO dbo.ActivityQueue (SiteId, WebId, ListId, UserId, PostTime, ItemCount) VALUES (@SiteId, @WebId, @ListId, @UserId, @ActivityTime, 2)";

                    using (var sqlCommand = new SqlCommand(INSERT_SQL, sqlConnection))
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
                        @"UPDATE dbo.ActivityQueue SET ItemCount = @ItemCount, PostTime = @ActivityTime WHERE ActivityQueueId = @Id";

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

        public Activity FindRelatedActivity(Guid listId, int userId, DateTime date, TimeSpan interval)
        {
            const string SQL = @"
                SELECT  TOP (1) dbo.SS_Activities.Id, dbo.SS_Activities.MassOperation, dbo.SS_Activities.Date
                FROM    dbo.SS_Threads INNER JOIN dbo.SS_Activities ON dbo.SS_Threads.Id = dbo.SS_Activities.ThreadId
                WHERE   (dbo.SS_Threads.ListId = @ListId) AND (dbo.SS_Activities.Date >= @Date) 
                            AND (dbo.SS_Activities.Kind < 3) AND (dbo.SS_Activities.UserId = @UserId)
                ORDER BY dbo.SS_Activities.Date DESC";

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@ListId", listId);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                sqlCommand.Parameters.AddWithValue("@Date", date - interval);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Activity
                        {
                            Id = reader.GetGuid(0),
                            IsMassOperation = reader.GetBoolean(1),
                            Date = reader.GetDateTime(2)
                        };
                    }

                    reader.Close();
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

        public IEnumerable<Activity> GetActivities(Thread thread, IEnumerable<ActivityKind> activityKinds)
        {
            string sql = string.Format(@"SELECT * FROM SS_Activities WHERE ThreadId = @ThreadId AND Kind IN ({0})",
                string.Join(",", activityKinds.Select(ak => (int) ak).ToArray()));

            using (var sqlCommand = new SqlCommand(sql, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@ThreadId", thread.Id);

                var dt = new DataTable();
                dt.Load(sqlCommand.ExecuteReader());

                if (dt.Rows.Count > 0)
                {
                    EnumerableRowCollection<DataRow> activities = dt.AsEnumerable();

                    foreach (DataRow r in activities)
                    {
                        var activity = new Activity
                        {
                            Id = (Guid) r["Id"],
                            Kind = (ActivityKind) r["Kind"],
                            Date = (DateTime) r["Date"],
                            UserId = (int) r["UserId"],
                            IsMassOperation = (bool) r["MassOperation"]
                        };

                        object key = r["ActivityKey"];
                        if (key != null && key != DBNull.Value)
                        {
                            activity.Key = (string) key;
                        }

                        object data = r["Data"];
                        if (data != null && data != DBNull.Value)
                        {
                            activity.SetData(data, true);
                        }

                        activity.Thread = thread;

                        yield return activity;
                    }
                }
                else
                {
                    yield return null;
                }
            }
        }

        public Activity RegisterActivity(Activity activity)
        {
            const string SQL =
                @"INSERT INTO SS_Activities (Id, ActivityKey, Data, Kind, Date, UserId, ThreadId) VALUES (@Id, @Key, @Data, @Kind, @Date, @UserId, @ThreadId)";

            activity.Id = Guid.NewGuid();

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", activity.Id);
                sqlCommand.Parameters.AddWithValue("@Key", (object) activity.Key ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@Data", activity.GetData(true) ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@Kind", activity.Kind);
                sqlCommand.Parameters.AddWithValue("@Date", activity.Date);
                sqlCommand.Parameters.AddWithValue("@UserId", activity.UserId);
                sqlCommand.Parameters.AddWithValue("@ThreadId", activity.Thread.Id);

                sqlCommand.ExecuteNonQuery();
            }

            return activity;
        }

        public void UpdateActivity(Dictionary<string, object> data, Dictionary<string, object> filters)
        {
            IEnumerable<string> values = data.Keys.Select(key => string.Format(@"{0} = @{0}", key));
            IEnumerable<string> where = filters.Keys.Select(key => string.Format(@"{0} = @{0}", key));

            string sql = string.Format(@"UPDATE SS_Activities SET {0} WHERE {1}",
                string.Join(",", values), string.Join(" AND ", where));

            using (var sqlCommand = new SqlCommand(sql, SqlConnection))
            {
                foreach (var pair in data)
                {
                    sqlCommand.Parameters.AddWithValue("@" + pair.Key, pair.Value);
                }

                foreach (var pair in filters)
                {
                    sqlCommand.Parameters.AddWithValue("@" + pair.Key, pair.Value);
                }

                sqlCommand.ExecuteNonQuery();
            }
        }

        #endregion Methods 
    }
}