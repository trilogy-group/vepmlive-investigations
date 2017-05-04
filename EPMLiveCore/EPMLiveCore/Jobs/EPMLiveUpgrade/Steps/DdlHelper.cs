using System.Data.SqlClient;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    public static class DdlHelper
    {
        public static bool ColumnExist(this SqlConnection sqlConnection, string tableName, string columnName)
        {
            var sql =
                $@"IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{columnName}' AND [object_id] = OBJECT_ID(N'{tableName}'))
BEGIN
    SELECT 1
END
ELSE SELECT 0";

            using (var sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                        return reader.GetInt32(0) != 1;
                }
            }

            return false;
        }

        public static void AddColumn(this SqlConnection sqlConnection, string tableName, string columnDefinition)
        {
            using (var sqlCommand = new SqlCommand($"ALTER TABLE {tableName} ADD {columnDefinition}", sqlConnection))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}