using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EPMLiveCore.SocialEngine.Entities;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class ThreadManager : BaseManager
    {
        #region Constructors (1) 

        public ThreadManager(DBConnectionManager dbConnectionManager) : base(dbConnectionManager) { }

        #endregion Constructors 

        #region Methods (22) 

        // Public Methods (16) 

        public void AssociateStreams(Thread thread, Guid[] streamIds)
        {
            foreach (Guid streamId in streamIds)
            {
                const string SQL = @"
                    IF NOT EXISTS (SELECT StreamId FROM SS_Streams_Threads WHERE StreamId = @StreamId AND ThreadId = @ThreadId)
                    BEGIN
                        INSERT INTO SS_Streams_Threads (StreamId, ThreadId) VALUES (@StreamId, @ThreadId)
                    END";

                using (SqlCommand sqlCommand = GetSqlCommand(SQL))
                {
                    sqlCommand.Parameters.AddWithValue("@StreamId", streamId);
                    sqlCommand.Parameters.AddWithValue("@ThreadId", thread.Id);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void CleanupCommenters(Thread thread, IEnumerable<int> validCommenters)
        {
            int[] commenters = validCommenters.ToArray();

            const string SQL = @"SELECT UserId, Role FROM SS_ThreadUsers WHERE ThreadId = @ThreadId";

            using (SqlCommand sqlCommand = GetSqlCommand(SQL))
            {
                sqlCommand.Parameters.AddWithValue("@ThreadId", thread.Id);

                var dt = new DataTable();
                dt.Load(sqlCommand.ExecuteReader());

                EnumerableRowCollection<DataRow> userRoles = dt.AsEnumerable();

                foreach (DataRow r in userRoles)
                {
                    var userId = (int) r["UserId"];

                    if (commenters.Contains(userId)) continue;

                    var role = (UserRole) Enum.Parse(typeof (UserRole), r["Role"].ToString(), false);

                    if (role.Has(UserRole.Commenter))
                    {
                        UpdateUserRole(thread.Id, userId, role.Remove(UserRole.Commenter), true);
                    }
                }
            }
        }

        public void DeleteThread(Thread thread)
        {
            const string SQL = @"UPDATE SS_Threads SET Deleted = 1 WHERE Id = @Id";

            using (SqlCommand sqlCommand = GetSqlCommand(SQL))
            {
                sqlCommand.Parameters.AddWithValue("@Id", thread.Id);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteThreads(IEnumerable<Guid> threadIds)
        {
            string[] ids = threadIds.Select(threadId => string.Format(@"'{0}'", threadId)).Distinct().ToArray();

            string sql = @"UPDATE SS_Threads SET Deleted = 1 WHERE Id IN (" + string.Join(",", ids) + ")";

            using (SqlCommand sqlCommand = GetSqlCommand(sql))
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

            using (SqlCommand sqlCommand = GetSqlCommand(sql))
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
                            case "FirstActivityDateTime":
                                thread.FirstActivityDateTime = (DateTime) value;
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

            using (SqlCommand sqlCommand = GetSqlCommand(sql))
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

        public void RemoveUserRoles(Guid threadId, Dictionary<int, UserRole> rolesToRemove)
        {
            foreach (var user in rolesToRemove)
            {
                int userId = user.Key;

                UserRole? existingRole = GetUserRole(threadId, userId);

                if (!existingRole.HasValue || !existingRole.Value.Has(user.Value)) continue;

                UserRole role = existingRole.Value.Remove(user.Value);
                UpdateUserRole(threadId, userId, role, true);
            }
        }

        public Thread SaveThread(Thread thread)
        {
            return thread.Id != Guid.Empty ? UpdateThread(thread) : CreateThread(thread);
        }

        public void UpdateAssociatedThreads(Guid threadId, Dictionary<Guid, int> associatedListItems)
        {
            const string SQL = @"
                IF NOT EXISTS (SELECT Id FROM SS_AssociatedThreads WHERE ThreadId = @ThreadId AND ListId = @ListId)
                BEGIN
                    INSERT INTO SS_AssociatedThreads (ThreadId, ListId, ItemId) VALUES (@ThreadId, @ListId, @ItemId)
                END
                ELSE
                BEGIN
                    UPDATE SS_AssociatedThreads SET ItemId = @ItemId WHERE ThreadId = @ThreadId AND ListId = @ListId
                END
            ";

            foreach (var pair in associatedListItems)
            {
                using (SqlCommand sqlCommand = GetSqlCommand(SQL))
                {
                    sqlCommand.Parameters.AddWithValue("@ThreadId", threadId);
                    sqlCommand.Parameters.AddWithValue("@ListId", pair.Key);
                    sqlCommand.Parameters.AddWithValue("@ItemId", pair.Value);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCommenters(Thread thread)
        {
            var commenters = new List<int>();

            foreach (User user in thread.Users)
            {
                if (user.Role.Has(UserRole.Commenter)) commenters.Add(user.Id);

                UserRole? existingRole = GetUserRole(thread.Id, user.Id);

                bool userExists = existingRole.HasValue;

                if (userExists && existingRole.Value.Has(user.Role)) continue;

                user.Role = !userExists ? user.Role : existingRole.Value | user.Role;
                UpdateUserRole(thread.Id, user.Id, user.Role, userExists);
            }
        }

        public void UpdateUsers(Thread thread)
        {
            var assignees = new List<int>();

            foreach (User user in thread.Users)
            {
                if (user.Role.Has(UserRole.Assignee)) assignees.Add(user.Id);

                UserRole? existingRole = GetUserRole(thread.Id, user.Id);

                bool userExists = existingRole.HasValue;

                if (userExists && existingRole.Value.Has(user.Role)) continue;

                user.Role = !userExists ? user.Role : existingRole.Value | user.Role;
                UpdateUserRole(thread.Id, user.Id, user.Role, userExists);
            }

            CleanupAssignees(thread.Id, assignees);
        }

        // Private Methods (6) 

        private void CleanupAssignees(Guid threadId, List<int> assignees)
        {
            var rolesToRemove = new Dictionary<int, UserRole>();

            const string SQL = @"SELECT Role, UserId FROM SS_ThreadUsers WHERE ThreadId = @ThreadId AND Role >= @Role";

            var dt = new DataTable();

            using (SqlCommand sqlCommand = GetSqlCommand(SQL))
            {
                sqlCommand.Parameters.AddWithValue("@ThreadId", threadId);
                sqlCommand.Parameters.AddWithValue("@Role", UserRole.Assignee);

                dt.Load(sqlCommand.ExecuteReader());
            }

            EnumerableRowCollection<DataRow> roles = dt.AsEnumerable();

            foreach (int userId in from r in roles
                let role = (UserRole) Enum.Parse(typeof (UserRole), r["Role"].ToString(), false)
                where role.Has(UserRole.Assignee)
                select (int) r["UserId"]
                into userId
                where !assignees.Contains(userId)
                where !rolesToRemove.ContainsKey(userId)
                select userId)
            {
                rolesToRemove.Add(userId, UserRole.Assignee);
            }

            if (rolesToRemove.Count > 0) RemoveUserRoles(threadId, rolesToRemove);
        }

        private Thread CreateThread(Thread thread)
        {
            thread.Id = Guid.NewGuid();

            const string SQL =
                @"INSERT INTO SS_Threads (Id, Title, URL, Kind, FirstActivityDateTime, WebId, ListId, ItemId) 
                                    VALUES (@Id, @Title, @URL, @Kind, @FirstActivityDateTime, @WebId, @ListId, @ItemId)";

            using (SqlCommand sqlCommand = GetSqlCommand(SQL))
            {
                sqlCommand.Parameters.AddWithValue("@Id", thread.Id);
                sqlCommand.Parameters.AddWithValue("@Title", thread.Title);
                sqlCommand.Parameters.AddWithValue("@URL", thread.Url);
                sqlCommand.Parameters.AddWithValue("@Kind", thread.Kind);
                sqlCommand.Parameters.AddWithValue("@FirstActivityDateTime", thread.FirstActivityDateTime);
                sqlCommand.Parameters.AddWithValue("@WebId", thread.WebId);
                sqlCommand.Parameters.AddWithValue("@ListId",
                    thread.ListId.HasValue ? (object) thread.ListId : DBNull.Value);
                sqlCommand.Parameters.AddWithValue("@ItemId",
                    thread.ItemId.HasValue ? (object) thread.ItemId : DBNull.Value);

                sqlCommand.ExecuteNonQuery();
            }

            return thread;
        }

        private UserRole? GetUserRole(Guid threadId, int userId)
        {
            const string SQL =
                @"SELECT TOP (1) Role FROM SS_ThreadUsers WHERE ThreadId = @ThreadId AND UserId = @UserId";

            using (SqlCommand sqlCommand = GetSqlCommand(SQL))
            {
                sqlCommand.Parameters.AddWithValue("@ThreadId", threadId);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);

                object er = sqlCommand.ExecuteScalar();
                if (er != null && er != DBNull.Value)
                {
                    return (UserRole) Enum.Parse(typeof (UserRole), er.ToString(), false);
                }
            }

            return null;
        }

        private void RemoveThreadUser(Guid threadId, int userId)
        {
            const string SQL = @"DELETE FROM SS_ThreadUsers WHERE ThreadId = @ThreadId AND UserId = @UserId";

            using (SqlCommand sqlCommand = GetSqlCommand(SQL))
            {
                sqlCommand.Parameters.AddWithValue("@ThreadId", threadId);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);

                sqlCommand.ExecuteNonQuery();
            }
        }

        private Thread UpdateThread(Thread thread)
        {
            const string SQL = @"UPDATE SS_Threads SET Title = @Title, URL = @URL WHERE Id = @Id";

            using (SqlCommand sqlCommand = GetSqlCommand(SQL))
            {
                sqlCommand.Parameters.AddWithValue("@Id", thread.Id);
                sqlCommand.Parameters.AddWithValue("@Title", thread.Title);
                sqlCommand.Parameters.AddWithValue("@URL", thread.Url);

                sqlCommand.ExecuteNonQuery();
            }

            return thread;
        }

        private void UpdateUserRole(Guid threadId, int userId, UserRole role, bool userExists)
        {
            if (userExists && role.Is(UserRole.None))
            {
                RemoveThreadUser(threadId, userId);
                return;
            }

            string sql = !userExists
                ? @"INSERT INTO SS_ThreadUsers (ThreadId, UserId, Role) VALUES (@ThreadId, @UserId, @Role)"
                : @"UPDATE SS_ThreadUsers SET Role = @Role WHERE ThreadId = @ThreadId AND UserId = @UserId";

            using (SqlCommand sqlCommand = GetSqlCommand(sql))
            {
                sqlCommand.Parameters.AddWithValue("@ThreadId", threadId);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                sqlCommand.Parameters.AddWithValue("@Role", role);

                sqlCommand.ExecuteNonQuery();
            }
        }

        #endregion Methods 
    }
}