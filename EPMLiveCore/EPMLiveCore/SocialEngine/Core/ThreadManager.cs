using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EPMLiveCore.SocialEngine.Entities;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class ThreadManager : BaseManager
    {
        #region Constructors (1) 

        public ThreadManager(SPWeb contextWeb) : base(contextWeb) { }

        #endregion Constructors 

        #region Methods (14) 

        // Public Methods (12) 

        public void AddUsers(Thread thread, int[] userIds)
        {
            Parallel.ForEach(userIds, userId =>
            {
                const string SQL = @"
                    IF NOT EXISTS (SELECT ThreadId FROM SS_ThreadUsers WHERE ThreadId = @ThreadId AND UserId = @UserId)
                    BEGIN
                        INSERT INTO SS_ThreadUsers (ThreadId, UserId) VALUES (@ThreadId, @UserId)
                    END";

                using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ThreadId", thread.Id);
                    sqlCommand.Parameters.AddWithValue("@UserId", userId);

                    sqlCommand.ExecuteNonQuery();
                }
            });
        }

        public void AssociateStreams(Thread thread, Guid[] streamIds)
        {
            Parallel.ForEach(streamIds, streamId =>
            {
                const string SQL = @"
                    IF NOT EXISTS (SELECT StreamId FROM SS_Streams_Threads WHERE StreamId = @StreamId AND ThreadId = @ThreadId)
                    BEGIN
                        INSERT INTO SS_Streams_Threads (StreamId, ThreadId) VALUES (@StreamId, @ThreadId)
                    END";

                using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@StreamId", streamId);
                    sqlCommand.Parameters.AddWithValue("@ThreadId", thread.Id);

                    sqlCommand.ExecuteNonQuery();
                }
            });
        }

        public void DeleteThread(Thread thread)
        {
            const string SQL = @"UPDATE SS_Threads SET Deleted = 1 WHERE Id = @Id";

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", thread.Id);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteThreads(IEnumerable<Guid> threadIds)
        {
            const string SQL = @"UPDATE SS_Threads SET Deleted = 1 WHERE Id IN (@Ids)";

            string[] ids = threadIds.Select(threadId => string.Format(@"'{0}'", threadId)).Distinct().ToArray();

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Ids", string.Join(",", ids));
                sqlCommand.ExecuteNonQuery();
            }
        }

        public Thread GetThread(Guid webId, string[] properties = null, bool bringDeleted = false)
        {
            return GetThread(webId, null, null, properties, bringDeleted);
        }

        public Thread GetThread(Guid webId, Guid? listId, string[] properties = null, bool bringDeleted = false)
        {
            return GetThread(webId, listId, null, properties, bringDeleted);
        }

        public Thread GetThread(Guid webId, Guid? listId, int? itemId, string[] properties = null,
            bool bringDeleted = false)
        {
            var columns = new List<string> {"Id"};

            if (properties != null)
            {
                columns.AddRange(properties);
            }

            string sql =
                string.Format(
                    @"SELECT TOP 1 {0} FROM SS_Threads WHERE WebId = @WebId AND ListId = @ListId AND ItemId = @ItemId AND Deleted = @Deleted",
                    string.Join(",", columns.Distinct()));

            if (!listId.HasValue) sql = sql.Replace("= @ListId", "IS NULL");
            if (!itemId.HasValue) sql = sql.Replace("= @ItemId", "IS NULL");

            using (var sqlCommand = new SqlCommand(sql, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@WebId", webId);
                sqlCommand.Parameters.AddWithValue("@ListId", listId.HasValue ? (object) listId : DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@ItemId", itemId.HasValue ? (object) itemId : DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@Deleted", bringDeleted ? 1 : 0);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count <= 0) return null;

                    var thread = new Thread();

                    DataRow row = dataTable.Rows[0];
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        object value = row[column.ColumnName];

                        switch (column.ColumnName)
                        {
                            case "Id":
                                thread.Id = (Guid) value;
                                break;
                            case "Title":
                                thread.Title = value as string;
                                break;
                            case "URL":
                                thread.Url = value as string;
                                break;
                            case "Kind":
                                thread.Kind = (ObjectKind) value;
                                break;
                            case "LastActivityDateTime":
                                if (value != null && value != DBNull.Value)
                                    thread.LastActivityDateTime = (DateTime) value;
                                break;
                            case "WebId":
                                thread.WebId = (Guid?) value;
                                break;
                            case "ListId":
                                if (value != null && value != DBNull.Value) thread.ListId = (Guid?) value;
                                break;
                            case "ItemId":
                                if (value != null && value != DBNull.Value) thread.ItemId = (int?) value;
                                break;
                            case "Deleted":
                                if ((int) value == 1) thread.Deleted = true;
                                break;
                        }

                        reader.Close();
                    }

                    return thread;
                }
            }

            return null;
        }

        public IEnumerable<Guid> GetThreadIds(Guid webId)
        {
            return GetThreadIds(webId, null, null, null);
        }

        public IEnumerable<Guid> GetThreadIds(Guid webId, Guid listId)
        {
            return GetThreadIds(webId, listId, null, null);
        }

        public IEnumerable<Guid> GetThreadIds(Guid webId, Guid listId, int itemId)
        {
            return GetThreadIds(webId, listId, itemId, null);
        }

        public IEnumerable<Guid> GetThreadIds(Guid webId, Guid? listId, int? itemId, ObjectKind? objectKind)
        {
            string sql =
                @"SELECT Id FROM SS_Threads WHERE WebId = @WebId AND ListId = @ListId AND ItemId = @ItemId AND Kind = @Kind";

            if (!listId.HasValue) sql = sql.Replace("= @ListId", "IS NULL");
            if (!itemId.HasValue) sql = sql.Replace("= @ItemId", "IS NULL");
            if (!objectKind.HasValue) sql = sql.Replace(" AND Kind = @Kind", string.Empty);

            using (var sqlCommand = new SqlCommand(sql, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@WebId", webId);
                sqlCommand.Parameters.AddWithValue("@ListId", listId.HasValue ? (object) listId.Value : DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@ItemId", itemId.HasValue ? (object) itemId.Value : DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@Kind",
                    objectKind.HasValue ? (object) objectKind.Value : DBNull.Value);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader.GetGuid(0);
                    }

                    reader.Close();
                }
            }
        }

        public Thread SaveThread(Thread thread)
        {
            return thread.Id != Guid.Empty ? UpdateThread(thread) : CreateThread(thread);
        }

        // Private Methods (2) 

        private Thread CreateThread(Thread thread)
        {
            thread.Id = Guid.NewGuid();

            const string SQL =
                @"INSERT INTO SS_Threads (Id, Title, URL, Kind, WebId, ListId, ItemId) VALUES (@Id, @Title, @URL, @Kind, @WebId, @ListId, @ItemId)";

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", thread.Id);
                sqlCommand.Parameters.AddWithValue("@Title", thread.Title);
                sqlCommand.Parameters.AddWithValue("@URL", thread.Url);
                sqlCommand.Parameters.AddWithValue("@Kind", thread.Kind);
                sqlCommand.Parameters.AddWithValue("@WebId", thread.WebId);
                sqlCommand.Parameters.AddWithValue("@ListId",
                    thread.ListId.HasValue ? (object) thread.ListId : DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@ItemId",
                    thread.ItemId.HasValue ? (object) thread.ItemId : DBNull.Value);

                sqlCommand.ExecuteNonQuery();
            }

            return thread;
        }

        private Thread UpdateThread(Thread thread)
        {
            const string SQL = @"UPDATE INTO SS_Threads SET Title = @Title, SET URL = @URL WHERE Id = @Id";

            using (var sqlCommand = new SqlCommand(SQL, SqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", thread.Id);
                sqlCommand.Parameters.AddWithValue("@Title", thread.Title);
                sqlCommand.Parameters.AddWithValue("@URL", thread.Url);

                sqlCommand.ExecuteNonQuery();
            }

            return thread;
        }

        #endregion Methods 
    }
}