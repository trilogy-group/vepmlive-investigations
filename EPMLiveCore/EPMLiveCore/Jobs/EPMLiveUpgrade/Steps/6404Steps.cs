using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EPMLiveCore.API.ProjectDiscountRate;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;

using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V640, Order = 4, Description = "Adding Discount Rate feature to SharePoint")]
    internal class DiscountRatePerProjectInstall64 : UpgradeStep
    {
        private const string VersionMarker = "v6.4.0.4";
        private const string ProjectsTableName = "EPGP_PROJECTS";
        private const string ProjectDiscountRateColumnName = "PROJECT_DISCOUNT_RATE";
        private const string ProjectAddDiscountRateColumnQuery = @"ALTER TABLE EPGP_PROJECTS ADD PROJECT_DISCOUNT_RATE decimal(5, 4) NULL";
        private const string DetailValuesTableName = "EPGP_DETAIL_VALUES";
        private const string DetailValuesDiscountRateColumnName = "BD_DISCOUNT_RATE";
        private const string DetailValuesAddDiscountRateColumnQuery = @"ALTER TABLE EPGP_DETAIL_VALUES ADD BD_DISCOUNT_RATE decimal(5, 4) NULL";
        private const string ProjectCenterConfigSetting = "EPMLiveWPProjectCenter";
        private const string DetailValuesDiscountValueColumnName = "BD_DISCOUNT_VALUE";
        private const string DetailValuesAddDiscountValueColumnQuery = @"ALTER TABLE EPGP_DETAIL_VALUES ADD BD_DISCOUNT_VALUE decimal(25, 6) NULL";
        private const string DetailValuesStoredProcedureName = "dbo.EPG_SP_PCTDetailValues";
        private const string DetailValuesStoredProcedureUpdateQuery = @"ALTER PROCEDURE dbo.EPG_SP_PCTDetailValues
/*
   Changes Log:
		2018/07/24: Included columns used for project discount rate feature (EPMLCID-19885). Upgrade step marker: v6.4.0.4
*/
   @ProjID INT,
   @CBID INT,
   @CTID INT 
AS
 Select BC_UID,BC_SEQ,BD_PERIOD,PRD_START_DATE,BD_VALUE,BD_COST,BD_DISCOUNT_RATE,BD_DISCOUNT_VALUE
  From EPGP_DETAIL_VALUES cv
  Inner Join EPG_PERIODS p On cv.CB_ID = p.CB_ID And cv.BD_PERIOD = p.PRD_ID
  Where cv.CB_ID = @CBID And CT_ID = @CTID And PROJECT_ID=@ProjID
  Order by BC_UID,BC_SEQ,BD_PERIOD
";

        private const string ProjectRatesGetMaintenanceRecordCountQuery = @"SELECT 101 as TOSET_MAINKEY, tblExpected.CB_ID, tblExpected.CT_ID, GETDATE() as dt FROM 
(SELECT CB_ID, CT_ID FROM EPGP_COST_VALUES_TOSET WHERE (TOSET_MAINKEY = 101)) AS tblCurrent RIGHT OUTER JOIN 
(SELECT TOSET_MAINKEY, CB_ID, CT_ID FROM EPGP_COST_VALUES_TOSET AS EPGP_COST_VALUES_TOSET_1 WHERE (TOSET_MAINKEY IN (1, 31))) AS tblExpected 
ON tblCurrent.CB_ID = tblExpected.CB_ID AND tblCurrent.CT_ID = tblExpected.CT_ID
WHERE (tblCurrent.CB_ID IS NULL) AND (tblCurrent.CT_ID IS NULL)";

        private const string ProjectRatesPopulateMaintenanceRecordsQuery = @"INSERT INTO [EPGP_COST_VALUES_TOSET]
([TOSET_MAINKEY],[CB_ID],[CT_ID],[CV_TIMESTAMP]) " + ProjectRatesGetMaintenanceRecordCountQuery;


        public DiscountRatePerProjectInstall64(SPWeb web, bool isPfeSite)
            : base(web, isPfeSite)
        {
        }

        public override bool Perform()
        {
            try
            {
                LogTitle(GetWebInfo(Web), 1);

                if (IsPfeSite)
                {
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }

                SPSecurity.RunWithElevatedPrivileges(UpgradeSharePoint);
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 1);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Upgrades the pfe database:
        ///  * Create column for projects table - column will be used as source for calculations in PFE instead of sharepoint list
        ///  * Create discount columns in detail values table - will help us on server side recalculations when discount rate is changed, so we will not have to find original rate
        ///  * Update stored procedure used to get cost detail values from VB6 code
        ///  * Populate configuration details table with missing data (partially data already populated by 6.4.0.1 step)
        /// </summary>
        private void UpgradePfeDatabase()
        {
            var connectionProvider = new PfeData.ConnectionProvider();
            LogMessage("Connecting to the database.", 2);
            using (var connection = connectionProvider.CreateConnection(Web))
            {
                AddTableColumn(connection, ProjectsTableName, ProjectDiscountRateColumnName, ProjectAddDiscountRateColumnQuery);
                AddTableColumn(connection, DetailValuesTableName, DetailValuesDiscountRateColumnName, DetailValuesAddDiscountRateColumnQuery);
                AddTableColumn(connection, DetailValuesTableName, DetailValuesDiscountValueColumnName, DetailValuesAddDiscountValueColumnQuery);

                UpdateStoredProcedure(connection, DetailValuesStoredProcedureName, DetailValuesStoredProcedureUpdateQuery);

                AddMissingConfigurationRecords(connection);

                LogMessage("PFE Database is ready to use with discount rate per project feature.", MessageKind.SUCCESS, 1);
            }
        }

        /// <summary>
        /// Upgrades the share point projec center list by adding new Discount Rate column.
        /// When called for root site, will iterate upgrade action for all child sub-sites.
        /// </summary>
        private void UpgradeSharePoint()
        {
            var siteId = Web.Site.ID;
            var webId = Web.ID;

            // ensure feature is installed in web
            LogMessage($"Processing web {Web.Url}", 1);
            UpgradeSharePoint(siteId, webId, 1);
            
            if (!Web.IsRootWeb)
            {
                // if not a root web do not try update child webs
                // all sub-sites can only be updated when calling upgrade to root site
                return;
            }

            var childWebIds = GetChildWebIds(siteId, webId);

            foreach (var web in childWebIds)
            {
                LogMessage($"Processing child web {web.Value}", 1);
                UpgradeSharePoint(siteId, web.Key, 2);
            }

            LogMessage("SharePoint site is ready to use with discount rate per project feature.", MessageKind.SUCCESS, 1);
        }

        /// <summary>
        /// Upgrades the SharePoint web - adds discount rate column to project center list.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <param name="webId">The web identifier.</param>
        /// <param name="level">The level.</param>
        private void UpgradeSharePoint(Guid siteId, Guid webId, int level)
        {
            using (var site = new SPSite(siteId))
            {
                using (var web = site.OpenWeb(webId))
                {
                    web.AllowUnsafeUpdates = true;
                    try
                    {
                        // try get lists to process and if could not get then log error
                        var setting = CoreFunctions.getConfigSetting(web, ProjectCenterConfigSetting);
                        if (string.IsNullOrWhiteSpace(setting))
                        {
                            LogMessage($"Could not find project list configuration {ProjectCenterConfigSetting}.", MessageKind.SKIPPED, level);
                            return;
                        }

                        var list = web.Lists.TryGetList(setting);
                        if (list == null)
                        {
                            LogMessage($"Could not find project list with name {setting}.", MessageKind.SKIPPED, level);
                            return;
                        }

                        // found list, can update it by adding new Discount Rate column
                        AddListColumn(list,
                            ProjectDiscountRateService.ProjectDiscountRateColumn,
                            ProjectDiscountRateService.ProjectDiscountRateColumnTitle,
                            ProjectDiscountRateService.ProjectDiscountRateColumnDescription,
                            level + 1);
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
        }

        private void AddListColumn(SPList list, string internalName, string title, string description, int level)
        {
            if (list.Fields.ContainsField(internalName))
            {
                LogMessage($"Column '{internalName}' already exists in list {list.Title}.", MessageKind.SKIPPED, level);
                return;
            }

            var field = (SPFieldNumber)list.Fields.CreateNewField(SPFieldType.Number.ToString(), internalName);
            list.Fields.Add(field);
            list.Update();

            field = (SPFieldNumber)list.Fields.GetFieldByInternalName(internalName);
            field.Title = title;
            field.Description = description;
            field.ShowInEditForm = true;
            field.ShowInNewForm = true;
            field.DefaultValue = "0";
            field.ShowAsPercentage = true;
            field.MinimumValue = 0;
            field.MaximumValue = 1;

            field.Update();

            LogMessage($"Column '{internalName}' added to list {list.Title}.", MessageKind.SUCCESS, level);
        }

        private void AddTableColumn(SqlConnection connection, string table, string column, string query)
        {
            var columnExists = connection.ColumnExist(table, column);
            if (!columnExists)
            {
                connection.ExecuteNonQuery(query);
                LogMessage($"{column} column added to {table} table.", MessageKind.SUCCESS, 2);
            }
            else
            {
                LogMessage($"{column} column already exists in {table}.", MessageKind.SKIPPED, 2);
            }
        }

        private void AddMissingConfigurationRecords(SqlConnection connection)
        {
            var rowsMissing = connection.ExecuteReader(ProjectRatesGetMaintenanceRecordCountQuery, reader => reader.HasRows);
            if (rowsMissing)
            {
                connection.ExecuteNonQuery(ProjectRatesPopulateMaintenanceRecordsQuery);
                LogMessage("Added configuration records.", MessageKind.SUCCESS, 2);
            }
            else
            {
                LogMessage("Configuration records already exists.", MessageKind.SKIPPED, 2);
            }
        }

        private void UpdateStoredProcedure(SqlConnection connection, string name, string updateQuery)
        {
            var definition = connection.GetSpDefinition(name);
            if (definition != null && !definition.Contains(VersionMarker))
            {
                connection.ExecuteNonQuery(updateQuery);
                LogMessage($"{name} procedure updated.", MessageKind.SUCCESS, 2);
            }
            else
            {
                LogMessage($"{name} already have been updated.", MessageKind.SKIPPED, 2);
            }
        }

        private Dictionary<Guid, string> GetChildWebIds(Guid siteId, Guid rootWebId)
        {
            // ensure feature is enabled in all child sites
            var childWebIds = new Dictionary<Guid, string>();
            using (var site = new SPSite(siteId))
            {
                foreach (SPWeb web in site.AllWebs)
                {
                    if (web.ID != rootWebId)
                    {
                        childWebIds.Add(web.ID, web.Url);
                    }
                }
            }

            return childWebIds;
        }
    }
}