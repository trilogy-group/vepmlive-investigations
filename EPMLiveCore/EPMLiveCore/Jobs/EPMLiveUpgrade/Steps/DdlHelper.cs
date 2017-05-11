using System;
using System.Data.SqlClient;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    public static class DdlHelper
    {
        public static bool ColumnExist(this SqlConnection sqlConnection, string tableName, string columnName)
        {
            var sql =
                $@"IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{
                        columnName
                    }' AND [object_id] = OBJECT_ID(N'{tableName}'))
BEGIN
    SELECT 1
END
ELSE SELECT 0";

            return ExecuteReader(sqlConnection, sql, reader =>
            {
                if (reader.Read())
                    return reader.GetInt32(0) != 1;
                return false;
            });
        }

        private static T ExecuteReader<T>(SqlConnection sqlConnection, string sql,
            Func<SqlDataReader, T> processReaderFunc)
        {
            using (var sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    return processReaderFunc(reader);
                }
            }
        }

        public static void AddColumn(this SqlConnection sqlConnection, string tableName, string columnDefinition)
        {
            ExecuteNonQuery(sqlConnection, $"ALTER TABLE {tableName} ADD {columnDefinition}");
        }

        public static void ExecuteNonQuery(this SqlConnection sqlConnection, string sql)
        {
            using (var sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static string GetDefinition(this SqlConnection sqlConnection, string objectName, string objType)
        {
            var sql =
                $"select definition from sys.objects o join sys.sql_modules m on m.object_id = o.object_id where o.object_id = object_id('{objectName}')  and o.type = '{objType}'";
            return ExecuteReader(sqlConnection, sql, reader =>
            {
                if (reader.Read())
                    return reader.GetString(0);
                return null;
            });
        }

        public static string GetViewDefinition(this SqlConnection sqlConnection, string viewName)
        {
            return GetDefinition(sqlConnection, viewName, "V");
        }

        public static string GetSpDefinition(this SqlConnection sqlConnection, string spName)
        {
            return GetDefinition(sqlConnection, spName, "P");
        }
    }
}