using System;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveCore.PfeData
{
    public class ProjectRepository : IProjectRepository
    {
        private const string GetProjectIdByExternalId = "SELECT TOP 1 PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_EXT_UID = @PROJECT_EXT_UID";
        private const string ProjectExternalIdParameter = "@PROJECT_EXT_UID";
        private const string ProjectIdColumn = "PROJECT_ID";
        
        private readonly IConnectionProvider _connectionProvider;

        public ProjectRepository()
        {
            _connectionProvider = new ConnectionProvider();
        }

        public int FindProjectId(SPWeb web, Guid listId, int id)
        {
            using (var connection = CreateConnection(web))
            {
                return FindProjectId(connection, web.ID, listId, id);
            }
        }

        private int FindProjectId(SqlConnection connection, Guid webId, Guid listId, int id)
        {
            var projectId = 0;

            using (var sqlCommand = new SqlCommand(GetProjectIdByExternalId, connection))
            {
                var externalId = $"{webId}.{listId}.{id:0}";
                sqlCommand.Parameters.AddWithValue(ProjectExternalIdParameter, externalId);
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        projectId = Convert.ToInt32(reader[ProjectIdColumn]);
                    }
                }
            }

            return projectId;
        }

        private SqlConnection CreateConnection(SPWeb web)
        {
            return _connectionProvider.CreateConnection(web);
        }
    }
}