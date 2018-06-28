using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PortfolioEngineCore.Base.DBAccess
{
    public static class ProjectResourceRates
    {
        private const string SelectProjectRatesQuery = "SELECT PROJECT_ID,WRES_ID,PR_EFFECTIVE_DATE,PR_RATE FROM EPG_PROJECT_RATES WHERE PROJECT_ID = @projectID";
        private const string SelectProjectRatesByResourceQuery = "SELECT PROJECT_ID,WRES_ID,PR_EFFECTIVE_DATE,PR_RATE FROM EPG_PROJECT_RATES WHERE PROJECT_ID = @projectID AND WRES_ID = @wresID";
        private const string ProjectIdParameter = "@projectID";
        private const string ResourceIdParameter = "@wresID";
        private const string ResourceIdColumn = "WRES_ID";
        private const string EffectiveDateColumn = "PR_EFFECTIVE_DATE";
        private const string RateColumn = "PR_RATE";

        public static List<ProjectResourceRate> GetRates(PortfolioEngineCore.DBAccess dba, int projectId)
        {
            return GetRatesInternal(dba, projectId, null);
        }

        private static List<ProjectResourceRate> GetRatesInternal(PortfolioEngineCore.DBAccess dba, int projectId, int? resourceId)
        {
            try
            {
                var results = new List<ProjectResourceRate>();

                // define query
                var query = resourceId.HasValue ? SelectProjectRatesByResourceQuery : SelectProjectRatesQuery;
                using (var sqlCommand = new SqlCommand(query, dba.Connection, dba.Transaction))
                {
                    // set SQL query parameters (project id is mandatory, resource id is optional)
                    sqlCommand.Parameters.AddWithValue(ProjectIdParameter, projectId);
                    if (resourceId.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue(ResourceIdParameter, resourceId);
                    }

                    // get & parse results
                    var reader = sqlCommand.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            var rateValue = SqlDb.ReadDecimalValue(reader[RateColumn]);
                            var effectiveDateValue = SqlDb.ReadNullableDateValue(reader[EffectiveDateColumn]);
                            var resourceIdValue = SqlDb.ReadIntValue(reader[ResourceIdColumn]);
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

                // order by EffectiveDate ASC is important and is expected by other functions, as first rate it is expected to have the base rate with effective date = DateTime.MinValue
                return results.OrderBy(x => x.EffectiveDate).ToList();
            }
            catch (SqlException ex)
            {
                dba.HandleException("ProjectRates.GetRates", StatusEnum.rsDBConnectFailed, ex);
                throw;
            }
        }
    }
}