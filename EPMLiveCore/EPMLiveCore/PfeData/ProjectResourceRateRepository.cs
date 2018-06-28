using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.PfeData
{
    public class ProjectResourceRateRepository : IProjectResourceRateRepository
    {
        private const string SelectProjectRatesQuery = "SELECT PROJECT_ID,WRES_ID,PR_EFFECTIVE_DATE,PR_RATE FROM EPG_PROJECT_RATES WHERE PROJECT_ID = @projectID";
        private const string SelectProjectRatesByResourceQuery = "SELECT PROJECT_ID,WRES_ID,PR_EFFECTIVE_DATE,PR_RATE FROM EPG_PROJECT_RATES WHERE PROJECT_ID = @projectID AND WRES_ID = @wresID";
        private const string InsertProjectRateQuery = "INSERT INTO EPG_PROJECT_RATES (PROJECT_ID,WRES_ID,PR_EFFECTIVE_DATE,PR_RATE) OUTPUT INSERTED.ID VALUES(@projectID,@wresID,@effectiveDate,@rate)";
        private const string UpdateProjectRateByResourceAndProjectQuery = "UPDATE EPG_PROJECT_RATES SET PR_RATE = @rate WHERE PROJECT_ID = @projectID AND WRES_ID = @wresID";
        private const string DeleteProjectRateByResourceAndProjectQuery = "DELETE FROM EPG_PROJECT_RATES WHERE PROJECT_ID = @projectID AND WRES_ID = @wresID";
        private const string DeleteProjectRateByProjectQuery = "DELETE FROM EPG_PROJECT_RATES WHERE PROJECT_ID = @projectID AND WRES_ID NOT IN ({0})";

        private const string ProjectIdParameter = "@projectID";
        private const string ResourceIdParameter = "@wresID";
        private const string EffectiveDateParameter = "@effectiveDate";
        private const string RateParameter = "@rate";
        private const string ResourceIdColumn = "WRES_ID";
        private const string EffectiveDateColumn = "PR_EFFECTIVE_DATE";
        private const string RateColumn = "PR_RATE";

        private readonly IConnectionProvider _connectionProvider;

        public ProjectResourceRateRepository()
        {
            _connectionProvider = new ConnectionProvider();
        }

        public bool DeleteRates(SPWeb web, int projectId, int resourceId)
        {
            // this method does not support effective date, will reset all person per project rates
            using (var connection = CreateConnection(web))
            {
                using (var sqlCommand = new SqlCommand(DeleteProjectRateByResourceAndProjectQuery, connection))
                {
                    sqlCommand.Parameters.AddWithValue(ProjectIdParameter, projectId);
                    sqlCommand.Parameters.AddWithValue(ResourceIdParameter, resourceId);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            return true;
        }

        public bool DeleteAllRates(SPWeb web, int projectId, int[] exceptResourceIds)
        {
            // this method does not support effective date, will reset all person per project rates
            using (var connection = CreateConnection(web))
            {
                var exclude = exceptResourceIds.Length > 0 ? string.Join(",", exceptResourceIds) : "-1";
                using (var sqlCommand = new SqlCommand(string.Format(DeleteProjectRateByProjectQuery, exclude), connection))
                {
                    sqlCommand.Parameters.AddWithValue(ProjectIdParameter, projectId);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            return true;
        }

        public ProjectResourceRate GetRate(SPWeb web, DateTime date, int projectId, int resourceId)
        {
            var rates = GetRates(web, projectId, resourceId);
            var rate = rates.LastOrDefault(x => x.EffectiveDate <= date);
            return rate;
        }

        public List<ProjectResourceRate> GetRates(SPWeb web, int projectId, int resourceId)
        {
            return GetRatesInternal(web, projectId, resourceId);
        }

        public bool SaveRate(SPWeb web, int projectId, int resourceId, decimal rateValue)
        {
            // this method does not support effective date, will reset rates
            using (var connection = CreateConnection(web))
            {
                using (var sqlCommandUpdate = new SqlCommand(UpdateProjectRateByResourceAndProjectQuery, connection))
                {
                    // if there is a valid id, update
                    sqlCommandUpdate.Parameters.AddWithValue(ProjectIdParameter, projectId);
                    sqlCommandUpdate.Parameters.AddWithValue(ResourceIdParameter, resourceId);
                    sqlCommandUpdate.Parameters.AddWithValue(RateParameter, rateValue);
                    var rowsAffected = sqlCommandUpdate.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        // if no updates, insert new
                        using (var sqlCommandInsert = new SqlCommand(InsertProjectRateQuery, connection))
                        {
                            sqlCommandInsert.Parameters.AddWithValue(ProjectIdParameter, projectId);
                            sqlCommandInsert.Parameters.AddWithValue(ResourceIdParameter, resourceId);
                            sqlCommandInsert.Parameters.AddWithValue(RateParameter, rateValue);
                            sqlCommandInsert.Parameters.AddWithValue(EffectiveDateParameter, DBNull.Value);
                            sqlCommandInsert.ExecuteScalar();
                        }
                    }
                }
            }

            return true;
        }

        private SqlConnection CreateConnection(SPWeb web)
        {
            return _connectionProvider.CreateConnection(web);
        }

        private List<ProjectResourceRate> GetRatesInternal(SqlConnection connection, int projectId, int? resourceId)
        {
            var results = new List<ProjectResourceRate>();

            // define query
            var query = resourceId != null ? SelectProjectRatesByResourceQuery : SelectProjectRatesQuery;
            using (var sqlCommand = new SqlCommand(query, connection))
            {
                // set SQL query parameters (project id is mandatory, resource is optional)
                sqlCommand.Parameters.AddWithValue(ProjectIdParameter, projectId);
                if (resourceId != null)
                {
                    sqlCommand.Parameters.AddWithValue(ResourceIdParameter, resourceId);
                }

                // get & parse results
                var reader = sqlCommand.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var rateValue = Convert.ToDecimal(reader[RateColumn]);
                        var effectiveDateValue = reader[EffectiveDateColumn] != DBNull.Value
                                                     ? (DateTime)reader[EffectiveDateColumn]
                                                     : (DateTime?)null;
                        var resourceIdValue = Convert.ToInt32(reader[ResourceIdColumn]);
                        results.Add(
                            new ProjectResourceRate()
                            {
                                ProjectId = projectId,
                                ResourceId = resourceIdValue,
                                EffectiveDate = effectiveDateValue ?? DateTime.MinValue,
                                Rate = rateValue
                            });
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            // order by EffectiveDate ASC is important and is expected by other functions, for first rate is always expected the base rate with effective date = DateTime.MinValue
            return results.OrderBy(x => x.EffectiveDate).ToList();
        }

        private List<ProjectResourceRate> GetRatesInternal(SPWeb web, int projectId, int resourceId)
        {
            using (var connection = CreateConnection(web))
            {
                return GetRatesInternal(connection, projectId, resourceId);
            }
        }
    }
}
