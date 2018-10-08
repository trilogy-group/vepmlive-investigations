using System;
using System.Data;
using System.Data.SqlClient;

namespace TimeSheets.WebPageCode
{
    public class DataSetUtils
    {
        public static DataSet CreateDataSet(SqlConnection connection, string sql, object period, Guid siteId )
        {
            using (var command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@period_id", period);
                command.Parameters.AddWithValue("@siteid", siteId);

                var dataSet = new DataSet();
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }

                return dataSet;
            }
        }
    }
}
