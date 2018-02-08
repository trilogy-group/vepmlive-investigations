using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client.WebParts;
using Microsoft.SharePoint.WebPartPages;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V634, Order = 1.0, Description = "Update Timesheet Izenda Reports")]
    internal class UpdateIZendaTSReports : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public UpdateIZendaTSReports(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

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
                                LogMessage("Updating Timesheet Audit Trail reports.", 2);
                                sqlConnection.Open();
                                using (var sqlCommand = new SqlCommand(@"update IzendaAdHocReports set ModifiedDate=GETDATE(), [xml] = replace(replace(
replace(cast([Xml] as nvarchar(max)),'Apr 01|| 2012 - Apr 07|| 2012','...'),'Brandon Baker','...'), '<Selection ColumnName=""[dbo].[RPTTSData].[Resource_TimesheetManager]"" ColumnSql="""" Description=""Timesheet Manager"" Definition="""" FormatString=""{0}"" GroupBy=""False"" OrderType=""NONE"" WidthSettedManually=""True"" Width="""" Visible=""True"" Gradient=""False"" InsertZeroValues=""False"" AggregateFunction=""None"" Justification=""NotSet"" LabelJustification=""NotSet"" Master=""False"" GaugeValuesInCurrencyFormat=""False"" Operator=""None"" AliasTable="""" ShouldBeFormatted=""True"" TargetReport="""" GaugeTargetReport="""" GaugeTargetEffect="""" Url=""example:Page.aspx?id={0}&amp;value={1}"" SubtotalTitle="""" ValueString="""" SubtotalFunction=""DEFAULT"" SubtotalExpression="""" IsItalic=""False"" IsBold=""False"" Highlight=""example: 5 to 6:Blue;7 to 10:Red"" Coefficient="""" ValueRanges=""example: 0 to 10:Under 10;10 to 100:10-100;100 to 10000:100+"" ColumnGroup="""" />', '') where name = @name and tenantid=@tenantid and CreatedDate = ModifiedDate", sqlConnection))
                                { 
                                    sqlCommand.CommandType = CommandType.Text;
                                    sqlCommand.Parameters.AddWithValue("@name", "Timesheets\\Timesheet Audit Trail");
                                    sqlCommand.Parameters.AddWithValue("@tenantid", _spWeb.ID);
                                    int numOfAffectedRows = sqlCommand.ExecuteNonQuery();
                                    LogMessage(numOfAffectedRows + " rows were updated.", 2);
                                }

                                LogMessage("Updating Timesheet Awaiting Approval reports.", 2);
                                using (var sqlCommand = new SqlCommand(@"update IzendaAdHocReports set ModifiedDate=GETDATE(), [xml] = replace(replace(cast([Xml] as nvarchar(max)), '<Criteria Column=""[dbo].[RPTTSData].[Resource_TimesheetManager]"" Not=""False"" FieldFilter=""False"" Operator=""Equals_CheckBoxes"" OrIsBlank=""False"" Description="""" AliasTable="""" Parameter=""True"" Value=""Mike Larscheid"" />', '')
                                ,'<Selection ColumnName=""[dbo].[RPTTSData].[Resource_TimesheetManager]"" ColumnSql="""" Description=""Timesheet Manager"" Definition="""" FormatString=""{0}"" GroupBy=""False"" OrderType=""ASC"" WidthSettedManually=""True"" Width="""" Visible=""True"" Gradient=""False"" InsertZeroValues=""False"" AggregateFunction=""GROUP"" Justification=""NotSet"" LabelJustification=""Center"" Master=""True"" GaugeValuesInCurrencyFormat=""False"" Operator=""None"" AliasTable="""" ShouldBeFormatted=""True"" TargetReport="""" GaugeTargetReport="""" GaugeTargetEffect="""" Url=""example:Page.aspx?id={0}&amp;value={1}"" SubtotalTitle="""" ValueString="""" SubtotalFunction=""DEFAULT"" SubtotalExpression="""" IsItalic=""False"" IsBold=""True"" Highlight=""example: 5 to 6:Blue;7 to 10:Red"" Coefficient="""" ValueRanges=""example: 0 to 10:Under 10;10 to 100:10-100;100 to 10000:100+"" ColumnGroup=""Timesheet Manager"" />', '') where name = @name and tenantid=@tenantid and CreatedDate = ModifiedDate", sqlConnection))
                                {
                                    sqlCommand.CommandType = CommandType.Text;
                                    sqlCommand.Parameters.AddWithValue("@name", "Timesheets\\Timesheet Awaiting Approval");
                                    sqlCommand.Parameters.AddWithValue("@tenantid", _spWeb.ID);
                                    int numOfAffectedRows = sqlCommand.ExecuteNonQuery();
                                    LogMessage(numOfAffectedRows + " rows were updated.", 2);
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

    [UpgradeStep(Version = EPMLiveVersion.V634, Order = 2.0, Description = "Replacing the upland logo URL")]
    internal class ImageWebpartLogoUpdater : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public ImageWebpartLogoUpdater(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Getting home page webparts.", 2);

                    SPFile file = _spWeb.GetFile(_spWeb.Url + "/SitePages/Home.aspx");
                    SPLimitedWebPartManager manager = file.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                    LogMessage("Getting the image webpart.", 2);

                    if (manager.WebParts["g_5fd41ea1_c7df_4b4b_baca_b84b2a33500b"] != null)
                    {
                        var webpart = ((ImageWebPart)manager.WebParts["g_5fd41ea1_c7df_4b4b_baca_b84b2a33500b"]);
                        webpart.ImageLink = _spWeb.ServerRelativeUrl + "/_layouts/15/epmlive/images/epmlivelogo-white.png";

                        _spWeb.AllowUnsafeUpdates = true;

                        LogMessage("Saving the image webpart.", 2);
                        manager.SaveChanges(webpart);
                        LogMessage("URL has been updated successfully.", 2);
                    }
                    else
                    {
                        LogMessage("Home page does not have the image webpart so updating will be skipped.", 2);
                    }
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
                finally
                {
                    _spWeb.AllowUnsafeUpdates = false;
                }
            });
            return true;
        }

        #endregion
    }
}
