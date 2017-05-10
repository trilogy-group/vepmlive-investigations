using EPMLiveCore.Infrastructure;
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
    [UpgradeStep(Version = EPMLiveVersion.V600, Order = 2.0, Description = "Updating Resource table")]
    internal class AddUpdateResourcePoolColumn : UpgradeStep
    {
        #region Constructors (1) 

        public AddUpdateResourcePoolColumn(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }
        private const string const_subKey = "SOFTWARE\\Wow6432Node\\EPMLive\\PortfolioEngine\\";

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);

                    string connectionString = CoreFunctions.getReportingConnectionString(Web.Site.WebApplication.Id, Web.Site.ID);

                    if (!CheckColumn())
                    {
                        AddColumn();
                        LogMessage("UserHasPermission column added", MessageKind.SUCCESS, 4);
                    }
                    else
                    {
                        LogMessage("UserHasPermission column already exists", MessageKind.SKIPPED, 4);
                    }
                    LogMessage("Updating value to the database . . .", 2);
                    PopulateColumn(CoreFunctions.getReportingConnectionString(webAppId, Web.Site.ID));
                    //LogMessage("ASSIGNEDTOID column populated", MessageKind.SUCCESS, 4);
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
            });

            return true;
        }

        private void AddColumn()
        {
            using (SPSite eleSite = new SPSite(Web.Url))
            {
                eleSite.AllowUnsafeUpdates = true;
                using (SPWeb eleWeb = eleSite.OpenWeb())
                {
                    eleWeb.AllowUnsafeUpdates = true;
                    SPList list = eleWeb.Lists["Resources"];

                    string id = list.Fields.Add("UserHasPermission", SPFieldType.Boolean, false);
                    SPField spfield = (SPField)list.Fields.GetField(id);

                    spfield.Hidden = true;

                    spfield.Update();
                    SPView view = list.DefaultView;
                    view.ViewFields.Add("UserHasPermission");

                    view.Update();
                    eleWeb.AllowUnsafeUpdates = false;
                }
                eleSite.AllowUnsafeUpdates = false;
            }

        }

        private void PopulateColumn(string reportingCn)
        {

            using (SPWeb mySite = Web.Site.OpenWeb())
            {
                string basePath = CoreFunctions.getConfigSetting(mySite, "epkbasepath");
                bool ResourceLevelPermision = false;
                SPList myList = mySite.Lists["Resources"];
                SPListItemCollection myItems = myList.GetItems();
                foreach (SPListItem item in myItems)
                {
                    int ResourceLevel = Convert.ToInt32(item["ResourceLevel"]);
                    string Title = Convert.ToString(item["Title"]);
                    string UserName = string.Empty;

                    if (ResourceLevel == 2 || ResourceLevel == 3 || item["ResourceLevel"] == null)//null and 2 for full permission 3 for project Manger and null for Developemnt
                        ResourceLevelPermision = true;

                    SPFieldUserValue SpFieldUser = new SPFieldUserValue(item.Web, item["SharePointAccount"].ToString());
                    try
                    {
                        UserName = CoreFunctions.GetRealUserName(SpFieldUser.User.LoginName);
                        bool ResourcePlanPermission = Utilities.CheckEditResourcePlanPermission(basePath, UserName) && ResourceLevelPermision;
                        var newitem = Utilities.ReloadListItem(item);
                        newitem["UserHasPermission"] = ResourcePlanPermission;
                        using (var scope = new DisabledItemEventScope())
                        {
                            newitem.SystemUpdate(false);// false will prevent to update version number and save conflict
                        }
                        LogMessage(string.Format("Updating value for {0}", UserName), 2);
                    }
                    catch (Exception ex)
                    {
                        LogMessage(ex.ToString(), MessageKind.FAILURE, 4);
                    }
                }
            }

        }

        private bool CheckColumn()
        {
            using (SPWeb mySite = Web.Site.OpenWeb())
            {
                var list = mySite.Lists["Resources"];
                return list.Fields.ContainsField("UserHasPermission");
            }

        }

        #endregion

    }
    [UpgradeStep(Version = EPMLiveVersion.V600, Order = 3.0, Description = "Remove Menu item")]
    internal class RemoveMenuItem : UpgradeStep
    {
        private const string SETTINGS_LIST = "EPM Live Settings";
        private SPWeb _spWeb;

        #region Constructors
        public RemoveMenuItem(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }
        #endregion

        #region Overrides of UpgradeStep
        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (var spSite = new SPSite(Web.Site.ID))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb(Web.ID))
                        {
                            if (!spWeb.IsRootWeb)
                            {
                                LogMessage(spWeb.Title + " is not a root web.", MessageKind.SKIPPED, 2);
                                return;
                            }

                            LogMessage("Getting " + SETTINGS_LIST + " list", 2);

                            SPList list = Web.Lists.TryGetList(SETTINGS_LIST);
                            if (list != null)
                            {

                                LogMessage("Remove menu item: Get Started!.", 2);

                                SPQuery jobQueueQuery = new SPQuery();
                                jobQueueQuery.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>Get Started!</Value></Eq></Where>";
                                SPListItemCollection jobListItems = list.GetItems(jobQueueQuery);

                                if (jobListItems != null && jobListItems.Count > 0)
                                {
                                    SPListItem li = jobListItems[0];
                                    li.Delete();

                                    LogMessage("Get started menu item removed.", MessageKind.SUCCESS, 4);
                                }
                                else
                                {
                                    LogMessage("Get started menu item not available.", MessageKind.SKIPPED, 2);
                                }


                            }
                        }
                    }
                });
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 2);
            }
            finally
            {
                try
                {
                    CacheStore.Current.RemoveSafely(Web.Url, new CacheStoreCategory(Web).Navigation);
                }
                catch { }
            }
            return true;
        }

        #endregion
    }
}
