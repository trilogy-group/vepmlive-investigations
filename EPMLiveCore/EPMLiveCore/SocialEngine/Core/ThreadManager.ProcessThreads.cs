using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using EPMLiveCore.Helpers;
using Thread = EPMLiveCore.SocialEngine.Entities.Thread;

namespace EPMLiveCore.SocialEngine.Core
{
    internal partial class ThreadManager
    {
        public void DeleteThread(Thread thread)
        {
            Guard.ArgumentIsNotNull(thread, nameof(thread));

            const string Sql = @"UPDATE SS_Threads SET Deleted = 1 WHERE Id = @Id";

            using (var sqlCommand = GetSqlCommand(Sql))
            {
                sqlCommand.Parameters.AddWithValue(IdText, thread.Id);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteThreads(IEnumerable<Guid> threadIds)
        {
            Guard.ArgumentIsNotNull(threadIds, nameof(threadIds));

            var ids = threadIds.Select(threadId => $@"'{threadId}'").Distinct().ToArray();
            var sql = $@"UPDATE SS_Threads SET Deleted = 1 WHERE Id IN ({string.Join(",", ids)})";

            using (var sqlCommand = GetSqlCommand(sql))
            {
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

        public Thread GetThread(Guid webId, Guid? listId, int? itemId, string[] properties = null, bool bringDeleted = false)
        {
            var columns = new List<string> { IdField };

            if (properties != null)
            {
                columns.AddRange(properties);
            }

            var sql =
                $@"SELECT TOP 1 {string.Join(",", columns.Distinct())} FROM SS_Threads WHERE WebId = @WebId AND ListId = @ListId AND ItemId = @ItemId AND Deleted = @Deleted";

            if (!listId.HasValue)
            {
                sql = sql.Replace("= @ListId", IsNullText);
            }

            if (!itemId.HasValue)
            {
                sql = sql.Replace("= @ItemId", IsNullText);
            }

            using (var sqlCommand = GetSqlCommand(sql))
            {
                sqlCommand.Parameters.AddWithValue(WebIdText, webId);
                sqlCommand.Parameters.AddWithValue(
                    ListIdText,
                    listId.HasValue
                        ? (object)listId
                        : DBNull.Value);
                sqlCommand.Parameters.AddWithValue(
                    ItemIdText,
                    itemId.HasValue
                        ? (object)itemId
                        : DBNull.Value);
                sqlCommand.Parameters.AddWithValue(
                    DeletedText,
                    bringDeleted
                        ? 1
                        : 0);

                using (var reader = sqlCommand.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count <= 0)
                    {
                        return null;
                    }

                    var thread = new Thread();
                    var row = dataTable.Rows[0];

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        var value = row[column.ColumnName];

                        switch (column.ColumnName)
                        {
                            case IdField:
                                thread.Id = (Guid)value;
                                break;
                            case "Title":
                                thread.Title = value as string;
                                break;
                            case "URL":
                                thread.Url = value as string;
                                break;
                            case "Kind":
                                thread.Kind = (ObjectKind)value;
                                break;
                            case "LastActivityDateTime":

                                if (value != null && value != DBNull.Value)
                                {
                                    thread.LastActivityDateTime = (DateTime)value;
                                }

                                break;
                            case "FirstActivityDateTime":
                                thread.FirstActivityDateTime = (DateTime)value;
                                break;
                            case "WebId":
                                thread.WebId = (Guid?)value;
                                break;
                            case "ListId":

                                if (value != null && value != DBNull.Value)
                                {
                                    thread.ListId = (Guid?)value;
                                }

                                break;
                            case "ItemId":

                                if (value != null && value != DBNull.Value)
                                {
                                    thread.ItemId = (int?)value;
                                }

                                break;
                            case "Deleted":

                                if ((int)value == 1)
                                {
                                    thread.Deleted = true;
                                }

                                break;
                            default:
                                Trace.WriteLine($"Unexpected value: {column.ColumnName}");
                                break;
                        }
                    }

                    return thread;
                }
            }
        }

        public Thread SaveThread(Thread thread)
        {
            Guard.ArgumentIsNotNull(thread, nameof(thread));

            return thread.Id != Guid.Empty
                ? UpdateThread(thread)
                : CreateThread(thread);
        }

        private Thread CreateThread(Thread thread)
        {
            Guard.ArgumentIsNotNull(thread, nameof(thread));

            thread.Id = Guid.NewGuid();

            var sql = @"INSERT INTO SS_Threads (Id, Title, URL, Kind, FirstActivityDateTime, WebId, ListId, ItemId) 
                        VALUES (@Id, @Title, @URL, @Kind, @FirstActivityDateTime, @WebId, @ListId, @ItemId)";

            if (string.IsNullOrWhiteSpace(thread.Url))
            {
                sql = sql.Replace(", URL", string.Empty).Replace("@URL, ", string.Empty);
            }

            using (var sqlCommand = GetSqlCommand(sql))
            {
                sqlCommand.Parameters.AddWithValue(IdText, thread.Id);
                sqlCommand.Parameters.AddWithValue(TitleText, thread.Title);
                sqlCommand.Parameters.AddWithValue(KindText, thread.Kind);
                sqlCommand.Parameters.AddWithValue(FirstActivityDateTime, thread.FirstActivityDateTime);
                sqlCommand.Parameters.AddWithValue(WebIdText, thread.WebId);

                if (!string.IsNullOrWhiteSpace(thread.Url))
                {
                    sqlCommand.Parameters.AddWithValue(UrlText, thread.Url);
                }

                sqlCommand.Parameters.AddWithValue(
                    ListIdText,
                    thread.ListId.HasValue
                        ? (object)thread.ListId
                        : DBNull.Value);
                sqlCommand.Parameters.AddWithValue(
                    ItemIdText,
                    thread.ItemId.HasValue
                        ? (object)thread.ItemId
                        : DBNull.Value);

                sqlCommand.ExecuteNonQuery();
            }

            return thread;
        }

        private void RemoveThreadUser(Guid threadId, int userId)
        {
            const string Sql = @"DELETE FROM SS_ThreadUsers WHERE ThreadId = @ThreadId AND UserId = @UserId";

            using (var sqlCommand = GetSqlCommand(Sql))
            {
                sqlCommand.Parameters.AddWithValue(ThreadIdText, threadId);
                sqlCommand.Parameters.AddWithValue(UserIdText, userId);
                sqlCommand.ExecuteNonQuery();
            }
        }

        private Thread UpdateThread(Thread thread)
        {
            Guard.ArgumentIsNotNull(thread, nameof(thread));

            var sql = @"UPDATE SS_Threads SET Title = @Title, URL = @URL WHERE Id = @Id";

            if (string.IsNullOrWhiteSpace(sql))
            {
                sql = sql.Replace(", URL = @URL", string.Empty);
            }

            using (var sqlCommand = GetSqlCommand(sql))
            {
                sqlCommand.Parameters.AddWithValue(IdText, thread.Id);
                sqlCommand.Parameters.AddWithValue(TitleText, thread.Title);

                if (!string.IsNullOrWhiteSpace(thread.Url))
                {
                    sqlCommand.Parameters.AddWithValue(UrlText, thread.Url);
                }

                sqlCommand.ExecuteNonQuery();
            }

            return thread;
        }
    }
}