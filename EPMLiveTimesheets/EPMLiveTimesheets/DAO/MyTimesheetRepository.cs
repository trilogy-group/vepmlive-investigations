using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TimeSheets.DAO
{
    public class MyTimesheetRepository : IDisposable
    {
        private bool disposedValue = false;

        public MyTimesheetRepository(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public SqlConnection Connection { get; }

        public DataTable GetPeriodsForSite(Guid siteId)
        {
            using (var command = new SqlCommand("spTSGetPeriodsForSite", Connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@siteid", siteId);

                var data = new DataSet();

                var adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                return data.Tables[0];
            }
        }

        internal string GetTypes(Guid siteId, MyTimesheetProperties properties)
        {
            var typeStrings = new StringBuilder();
            using (var command = new SqlCommand("SELECT TSTYPE_ID, TSTYPE_NAME FROM TSTYPE where SITE_UID=@siteid", Connection))
            {
                command.Parameters.AddWithValue("@siteid", siteId);

                using (var types = command.ExecuteReader())
                {
                    while (types.Read())
                    {
                        int id = types.GetInt32(0);
                        properties.ColumnType = 2;
                        typeStrings.Append($",T{id}: '{types.GetString(1)}'");

                    }
                }
            }
            return typeStrings.ToString();
        }

        internal void SetStatus(Guid siteId, string userName, MyTimesheetProperties properties)
        {
            properties.IsLocked = false;
            var query = "SELECT submitted, approval_status, locked FROM TSTIMESHEET where SITE_UID=@siteid and period_id=@period and username=@username";
            using (var command = new SqlCommand(query, Connection))
            {
                command.Parameters.AddWithValue("@siteid", siteId);
                command.Parameters.AddWithValue("@period", properties.PeriodId);
                command.Parameters.AddWithValue("@username", userName);

                using (var timeSheets = command.ExecuteReader())
                {
                    if (timeSheets.Read())
                    {
                        if (timeSheets.GetBoolean(2))
                        {
                            properties.IsLocked = true;
                        }

                        if (timeSheets.GetBoolean(0))
                        {
                            if (timeSheets.GetInt32(1) == 1)
                            {
                                properties.Status = "Approved";
                                if (!properties.Settings.DisableApprovals)
                                {
                                    properties.IsLocked = true;
                                }
                            }
                            else if (timeSheets.GetInt32(1) == 2)
                            {
                                properties.Status = "Rejected";
                            }
                            else
                            {
                                properties.Status = "Submitted";
                            }
                        }
                    }
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Connection?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
}
