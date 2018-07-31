using System;
using System.Data.SqlClient;

namespace PortfolioEngineCore.Base.DBAccess
{
    public static class ProjectDiscountRates
    {
        private const string ProjectDiscountRateUpdateQuery = "UPDATE EPGP_PROJECTS SET PROJECT_DISCOUNT_RATE = @PROJECT_DISCOUNT_RATE WHERE PROJECT_ID = @PROJECT_ID";
        private const string ProjectDiscountRateSelectQuery = "SELECT PROJECT_DISCOUNT_RATE FROM EPGP_PROJECTS WHERE PROJECT_ID = @PROJECT_ID";
        private const string ProjectDiscountRateParameter = "@PROJECT_DISCOUNT_RATE";
        private const string ProjectIdParameter = "@PROJECT_ID";

        /// <summary>
        /// Updates the project discount rate in PFE database projects table.
        /// </summary>
        /// <param name="dba">The database connection object.</param>
        /// <param name="pid">The project identifier.</param>
        /// <param name="discountRate">The discount rate.</param>
        public static void UpdateProjectDiscountRate(PortfolioEngineCore.DBAccess dba, int pid, string discountRate)
        {
            using (var command = new SqlCommand(ProjectDiscountRateUpdateQuery, dba.Connection))
            {
                command.Parameters.AddWithValue(ProjectDiscountRateParameter, discountRate);
                command.Parameters.AddWithValue(ProjectIdParameter, pid);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the project discount rate.
        /// </summary>
        /// <param name="dba">The database connection object.</param>
        /// <param name="pid">The project identifier.</param>
        public static decimal GetProjectDiscountRate(PortfolioEngineCore.DBAccess dba, int pid)
        {
            var result = 0m;
            using (var command = new SqlCommand(ProjectDiscountRateSelectQuery, dba.Connection))
            {
                command.Parameters.AddWithValue(ProjectIdParameter, pid);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = SqlDb.ReadDecimalValue(reader[0]);
                    }
                }
            }

            return result;
        }
    }
}