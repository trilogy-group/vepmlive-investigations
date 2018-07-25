using System;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveCore.PfeData
{
    public class ResourceRepository : IResourceRepository
    {
        private const string GetResourceIdByUsernameQuery = "SELECT TOP 1 WRES_ID FROM EPG_RESOURCES WHERE WRES_NT_ACCOUNT = @WRES_NT_ACCOUNT";
        private const string GetResourceIdByNameQuery = "SELECT TOP 1 WRES_ID FROM EPG_RESOURCES WHERE RES_NAME = @RES_NAME AND WRES_IS_GENERIC = 1"; // only for generic accounts
        private const string ResourceAccountParameter = "@WRES_NT_ACCOUNT";
        private const string ResourceNameParameter = "@RES_NAME";
        private const string ResourceIdColumn = "WRES_ID";
        
        private readonly IConnectionProvider _connectionProvider;

        public ResourceRepository()
        {
            _connectionProvider = new ConnectionProvider();
        }

        public int FindResourceId(SPWeb web, string resourceUsername, string resourceName)
        {
            using (var connection = CreateConnection(web))
            {
                return FindResourceId(connection, resourceUsername, resourceName);
            }
        }

        private int FindResourceId(SqlConnection connection, string resourceUsername, string resourceName)
        {
            var resourceIdValue = 0;
            var useResourceUserName = !string.IsNullOrWhiteSpace(resourceUsername);
            var useResourceName = !useResourceUserName && !string.IsNullOrWhiteSpace(resourceName);

            if (!useResourceUserName && !useResourceName)
            {
                return resourceIdValue;
            }

            using (var sqlCommand = new SqlCommand(useResourceUserName ? GetResourceIdByUsernameQuery : GetResourceIdByNameQuery, connection))
            {
                sqlCommand.Parameters.AddWithValue(useResourceUserName ? ResourceAccountParameter : ResourceNameParameter,
                    useResourceUserName ? resourceUsername : resourceName);
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resourceIdValue = Convert.ToInt32(reader[ResourceIdColumn]);
                    }
                }
            }

            return resourceIdValue;
        }

        private SqlConnection CreateConnection(SPWeb web)
        {
            return _connectionProvider.CreateConnection(web);
        }
    }
}