using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V600, Order = 1.0, Description = "Update Izenda AdHoc Reports")]
    internal class UpdateIzendaAdHocReports : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public UpdateIzendaAdHocReports(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    SPList izendaReports = _spWeb.Lists.TryGetList("IzendaReports");

                    if (izendaReports != null)
                    {
                        LogMessage("Connecting to the database.", 2);
                        string connectionString = CoreFunctions.getConnectionString(webAppId);
                        using (var sqlConnection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                LogMessage("Checking for reports to update.", 2);
                                sqlConnection.Open();
                                using (var sqlDataAdapter = new SqlDataAdapter(@"select Name, TenantID from IzendaAdHocReports where name in ('Projects\Project Costs', 'Projects\Project Financials') and[xml] like '%LeftConditionColumn=""\[dbo].\[EPG_RPT_Cost].\[PeriodUID]"" RightConditionTable=""\[dbo].\[EPG_RPT_Calendar]"" RightConditionColumn=""\[dbo].\[EPG_RPT_Calendar].\[PeriodUID]%' Escape '\'", sqlConnection))
                                {
                                    var dtReportsToUpdate = new DataTable();
                                    sqlDataAdapter.Fill(dtReportsToUpdate);


                                    if (dtReportsToUpdate != null & dtReportsToUpdate.Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in dtReportsToUpdate.Rows)
                                        {
                                            using (var sqlCommand = new SqlCommand(@"update IzendaAdHocReports set[xml] = replace(cast([Xml] as nvarchar(max)), 'LeftConditionColumn=""[dbo].[EPG_RPT_Cost].[PeriodUID]"" RightConditionTable=""[dbo].[EPG_RPT_Calendar]"" RightConditionColumn=""[dbo].[EPG_RPT_Calendar].[PeriodUID]', 'LeftConditionColumn = ""[dbo].[EPG_RPT_Cost].[CalendarID]"" RightConditionTable = ""[dbo].[EPG_RPT_Calendar]"" RightConditionColumn = ""[dbo].[EPG_RPT_Calendar].[CalendarID]') where name = @name and tenantid = @tenantid", sqlConnection))
                                            {
                                                sqlCommand.CommandType = CommandType.Text;
                                                sqlCommand.Parameters.AddWithValue("@name", Convert.ToString(dr[0]));
                                                sqlCommand.Parameters.AddWithValue("@tenantid", Convert.ToString(dr[1]));
                                                sqlCommand.ExecuteNonQuery();
                                            }
                                        }
                                        LogMessage("Reports updated successfully.", MessageKind.SUCCESS, 2);
                                    }
                                    else
                                    {
                                        LogMessage("Reports already updated.", MessageKind.SKIPPED, 2);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                LogMessage(e.ToString(), MessageKind.FAILURE, 4);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
            });
            return true;
        }

        #endregion
    }
}
