using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using EPMLiveCore.Helpers;
using EPMLiveCore.SocialEngine.Entities;

namespace EPMLiveCore.SocialEngine.Core
{
    internal partial class ThreadManager : BaseManager
    {
        public ThreadManager(DBConnectionManager dbConnectionManager) : base(dbConnectionManager) { }

        public void AssociateStreams(Thread thread, Guid[] streamIds)
        {
            Guard.ArgumentIsNotNull(streamIds, nameof(streamIds));
            Guard.ArgumentIsNotNull(thread, nameof(thread));

            foreach (var streamId in streamIds)
            {
                const string Sql = @"
                    IF NOT EXISTS (SELECT StreamId FROM SS_Streams_Threads WHERE StreamId = @StreamId AND ThreadId = @ThreadId)
                    BEGIN
                        INSERT INTO SS_Streams_Threads (StreamId, ThreadId) VALUES (@StreamId, @ThreadId)
                    END";

                using (var sqlCommand = GetSqlCommand(Sql))
                {
                    sqlCommand.Parameters.AddWithValue(StreamIdText, streamId);
                    sqlCommand.Parameters.AddWithValue(ThreadIdText, thread.Id);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void CleanupCommenters(Thread thread, IEnumerable<int> validCommenters)
        {
            Guard.ArgumentIsNotNull(validCommenters, nameof(validCommenters));
            Guard.ArgumentIsNotNull(thread, nameof(thread));

            var commenters = validCommenters.ToArray();
            const string Sql = @"SELECT UserId, Role FROM SS_ThreadUsers WHERE ThreadId = @ThreadId";

            using (var sqlCommand = GetSqlCommand(Sql))
            {
                sqlCommand.Parameters.AddWithValue(ThreadIdText, thread.Id);

                var dt = new DataTable();
                dt.Load(sqlCommand.ExecuteReader());

                var userRoles = dt.AsEnumerable();

                foreach (var dataRow in userRoles)
                {
                    var userId = (int)dataRow[UserId];

                    if (commenters.Contains(userId))
                    {
                        continue;
                    }

                    var role = (UserRole)Enum.Parse(typeof(UserRole), dataRow[Role].ToString(), false);

                    if (role.Has(UserRole.Commenter))
                    {
                        UpdateUserRole(thread.Id, userId, role.Remove(UserRole.Commenter), true);
                    }
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
            var sql = @"SELECT Id FROM SS_Threads WHERE WebId = @WebId AND ListId = @ListId AND ItemId = @ItemId AND Kind = @Kind";

            if (!listId.HasValue)
            {
                sql = sql.Replace("= @ListId", IsNullText);
            }

            if (!itemId.HasValue)
            {
                sql = sql.Replace("= @ItemId", IsNullText);
            }

            if (!objectKind.HasValue)
            {
                sql = sql.Replace(" AND Kind = @Kind", string.Empty);
            }

            using (var sqlCommand = GetSqlCommand(sql))
            {
                sqlCommand.Parameters.AddWithValue(WebIdText, webId);
                sqlCommand.Parameters.AddWithValue(
                    ListIdText,
                    listId.HasValue
                        ? (object)listId.Value
                        : DBNull.Value);
                sqlCommand.Parameters.AddWithValue(
                    ItemIdText,
                    itemId.HasValue
                        ? (object)itemId.Value
                        : DBNull.Value);
                sqlCommand.Parameters.AddWithValue(
                    KindText,
                    objectKind.HasValue
                        ? (object)objectKind.Value
                        : DBNull.Value);

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader.GetGuid(0);
                    }

                    reader.Close();
                }
            }
        }

        public void RemoveUserRoles(Guid threadId, IDictionary<int, UserRole> rolesToRemove)
        {
            Guard.ArgumentIsNotNull(rolesToRemove, nameof(rolesToRemove));

            foreach (var user in rolesToRemove)
            {
                var userId = user.Key;
                var existingRole = GetUserRole(threadId, userId);

                if (existingRole?.Has(user.Value) != true)
                {
                    continue;
                }

                var role = existingRole.Value.Remove(user.Value);
                UpdateUserRole(threadId, userId, role, true);
            }
        }

        public void UpdateAssociatedThreads(Guid threadId, IDictionary<Guid, int> associatedListItems)
        {
            Guard.ArgumentIsNotNull(associatedListItems, nameof(associatedListItems));

            const string Sql = @"
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
                using (var sqlCommand = GetSqlCommand(Sql))
                {
                    sqlCommand.Parameters.AddWithValue(ThreadIdText, threadId);
                    sqlCommand.Parameters.AddWithValue(ListIdText, pair.Key);
                    sqlCommand.Parameters.AddWithValue(ItemIdText, pair.Value);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCommenters(Thread thread)
        {
            Guard.ArgumentIsNotNull(thread, nameof(thread));

            var commenters = new List<int>();

            foreach (var user in thread.Users)
            {
                if (user.Role.Has(UserRole.Commenter))
                {
                    commenters.Add(user.Id);
                }

                var existingRole = GetUserRole(thread.Id, user.Id);
                var userExists = existingRole.HasValue;

                if (userExists && existingRole.Value.Has(user.Role))
                {
                    continue;
                }

                user.Role = !userExists
                    ? user.Role
                    : existingRole.Value | user.Role;
                UpdateUserRole(thread.Id, user.Id, user.Role, userExists);
            }
        }

        public void UpdateUsers(Thread thread)
        {
            Guard.ArgumentIsNotNull(thread, nameof(thread));

            var assignees = new List<int>();

            foreach (var user in thread.Users)
            {
                if (user.Role.Has(UserRole.Assignee))
                {
                    assignees.Add(user.Id);
                }

                var existingRole = GetUserRole(thread.Id, user.Id);
                var userExists = existingRole.HasValue;

                if (userExists && existingRole.Value.Has(user.Role))
                {
                    continue;
                }

                user.Role = !userExists
                    ? user.Role
                    : existingRole.Value | user.Role;
                UpdateUserRole(thread.Id, user.Id, user.Role, userExists);
            }

            CleanupAssignees(thread.Id, assignees);
        }

        private void CleanupAssignees(Guid threadId, IList<int> assignees)
        {
            Guard.ArgumentIsNotNull(assignees, nameof(assignees));

            var rolesToRemove = new Dictionary<int, UserRole>();
            const string Sql = @"SELECT Role, UserId FROM SS_ThreadUsers WHERE ThreadId = @ThreadId AND Role >= @Role";
            var dt = new DataTable();

            using (var sqlCommand = GetSqlCommand(Sql))
            {
                sqlCommand.Parameters.AddWithValue(ThreadIdText, threadId);
                sqlCommand.Parameters.AddWithValue(RoleText, UserRole.Assignee);
                dt.Load(sqlCommand.ExecuteReader());
            }

            var roles = dt.AsEnumerable();

            foreach (var userId in from r in roles
                let role = (UserRole)Enum.Parse(typeof(UserRole), r[Role].ToString(), false)
                where role.Has(UserRole.Assignee)
                select (int)r[UserId]
                into userId
                where !assignees.Contains(userId)
                where !rolesToRemove.ContainsKey(userId)
                select userId)
            {
                rolesToRemove.Add(userId, UserRole.Assignee);
            }

            if (rolesToRemove.Any())
            {
                RemoveUserRoles(threadId, rolesToRemove);
            }
        }

        private UserRole? GetUserRole(Guid threadId, int userId)
        {
            const string Sql = @"SELECT TOP (1) Role FROM SS_ThreadUsers WHERE ThreadId = @ThreadId AND UserId = @UserId";

            using (var sqlCommand = GetSqlCommand(Sql))
            {
                sqlCommand.Parameters.AddWithValue(ThreadIdText, threadId);
                sqlCommand.Parameters.AddWithValue(UserIdText, userId);

                var executeScalar = sqlCommand.ExecuteScalar();

                if (executeScalar != null && executeScalar != DBNull.Value)
                {
                    return (UserRole)Enum.Parse(typeof(UserRole), executeScalar.ToString(), false);
                }
            }

            return null;
        }

        private void UpdateUserRole(Guid threadId, int userId, UserRole role, bool userExists)
        {
            if (userExists && role.Is(UserRole.None))
            {
                RemoveThreadUser(threadId, userId);
                return;
            }

            var sql = !userExists
                ? @"INSERT INTO SS_ThreadUsers (ThreadId, UserId, Role) VALUES (@ThreadId, @UserId, @Role)"
                : @"UPDATE SS_ThreadUsers SET Role = @Role WHERE ThreadId = @ThreadId AND UserId = @UserId";

            using (var sqlCommand = GetSqlCommand(sql))
            {
                sqlCommand.Parameters.AddWithValue(ThreadIdText, threadId);
                sqlCommand.Parameters.AddWithValue(UserIdText, userId);
                sqlCommand.Parameters.AddWithValue(RoleText, role);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}