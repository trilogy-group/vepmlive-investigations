using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Transactions;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V718, Order = 1.0, Description = "Improve index on LSTMyWork")]
    internal class AlterLSTMyWorkIndex : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private const string UpgradeScript = @"
IF EXISTS (SELECT * FROM sys.indexes WHERE [object_id] = OBJECT_ID('dbo.LSTMyWork') AND [name] = 'IX_LSTMyWork_ListId_ItemID') 
BEGIN
    DROP INDEX [IX_LSTMyWork_ListId_ItemID] ON [dbo].[LSTMyWork];
END;
IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='IX_LSTMyWork_ListId_ItemID_AssignedToID' AND object_id = OBJECT_ID('dbo.LSTMyWork'))
BEGIN
	CREATE INDEX [IX_LSTMyWork_ListId_ItemID_AssignedToID] ON [dbo].[LSTMyWork] ([ListId], [ItemId], [AssignedToID]) WITH (FILLFACTOR=80);
END";

        #region Constructors (1) 
        public AlterLSTMyWorkIndex(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    LogMessage("Connecting to the database . . .", 2);
                    Guid webAppId = Web.Site.WebApplication.Id;
                    Guid siteId = Web.Site.ID;
                    string rptCnStr = CoreFunctions.getReportingConnectionString(webAppId, siteId);
                    using (var rptCn = new SqlConnection(rptCnStr))
                    {
                        rptCn.Open();

                        #region Index Code

                        rptCn.ExecuteNonQuery(UpgradeScript);

                        #endregion

                        LogMessage("Index IX_LSTMyWork_ListId_ItemID_AssignedToID has been created on LSTMyWork.", MessageKind.SUCCESS, 4);
                    }
                });
            }
            catch (Exception exception)
            {
                var message = exception.InnerException != null
                    ? exception.InnerException.Message
                    : exception.Message;

                LogMessage(message + exception, MessageKind.FAILURE, 4);
                return false;
            }
            return true;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V718, Order = 2.0, Description = "Add missing index on RPTColumn")]
    internal class AddIndex_RPTColumn_IX_RPTColumn_RPTListId : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private const string UpgradeScript = @"
if not exists(select * from sys.indexes where name = 'IX_RPTColumn_RPTListId')
begin
	CREATE INDEX [IX_RPTColumn_RPTListId] ON [dbo].[RPTColumn] ([RPTListId], [ColumnName]) INCLUDE ([SharePointType])
end";

        #region Constructors (1) 
        public AddIndex_RPTColumn_IX_RPTColumn_RPTListId(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    LogMessage("Connecting to the database . . .", 2);
                    Guid webAppId = Web.Site.WebApplication.Id;
                    Guid siteId = Web.Site.ID;
                    string rptCnStr = CoreFunctions.getReportingConnectionString(webAppId, siteId);
                    using (var rptCn = new SqlConnection(rptCnStr))
                    {
                        rptCn.Open();

                        #region Index Code

                        rptCn.ExecuteNonQuery(UpgradeScript);

                        #endregion

                        LogMessage("Index IX_RPTColumn_RPTListId has been created on RPTColumn.", MessageKind.SUCCESS, 4);
                    }
                });
            }
            catch (Exception exception)
            {
                var message = exception.InnerException != null
                    ? exception.InnerException.Message
                    : exception.Message;

                LogMessage(message + exception, MessageKind.FAILURE, 4);
                return false;
            }
            return true;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V718, Order = 3.0, Description = "Add missing index on EPGP_COST_CATEGORIES")]
    internal class AddIndex_EPGPCostCategories_IX_EPGP_COST_CATEGORIES_BC_ID : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private readonly string CreateIndexScript = @"
if not exists(select * from sys.indexes where object_id = OBJECT_ID('dbo.EPGP_COST_CATEGORIES') and name = 'IX_EPGP_COST_CATEGORIES_BC_ID')
begin
	CREATE INDEX [IX_EPGP_COST_CATEGORIES_BC_ID] ON [dbo].[EPGP_COST_CATEGORIES] ([BC_ID])
end
";
        public AddIndex_EPGPCostCategories_IX_EPGP_COST_CATEGORIES_BC_ID(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        public override bool Perform()
        {
            try
            {
                LogTitle(GetWebInfo(Web), 1);
                if (IsPfeSite)
                {
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }
            }
            catch (Exception e)
            {
                LogMessage(e.ToString(), MessageKind.FAILURE, 1);
                return false;
            }
            return true;
        }

        private void UpgradePfeDatabase()
        {
            var connectionProvider = new PfeData.ConnectionProvider();
            LogMessage("Connecting to the database.", 2);
            using (var connection = connectionProvider.CreateConnection(Web))
            {
                connection.ExecuteNonQuery(CreateIndexScript);
                LogMessage("Index IX_EPGP_COST_CATEGORIES_BC_ID ON EPGP_COST_CATEGORIES has been successfully created.", MessageKind.SUCCESS, 1);
            }
        }
    }

    [UpgradeStep(Version = EPMLiveVersion.V718, Order = 4.0, Description = "Add missing index on EPG_RESOURCEPLANS_HOURS")]
    internal class AddIndex_EPGResourcePlansHours_IX_EPG_RESOURCEPLANS_HOURS_CMT_UID_PRD_ID_CMH_PENDING : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private readonly string CreateIndexScript = @"
if not exists(select * from sys.indexes where [object_id] = OBJECT_ID('dbo.EPG_RESOURCEPLANS_HOURS') AND name = 'IX_EPG_RESOURCEPLANS_HOURS_CMT_UID_PRD_ID_CMH_PENDING')
begin
	CREATE NONCLUSTERED INDEX [IX_EPG_RESOURCEPLANS_HOURS_CMT_UID_PRD_ID_CMH_PENDING] ON [dbo].[EPG_RESOURCEPLANS_HOURS]	
    (	
	    [CMT_UID] ASC,
	    [PRD_ID] ASC,
	    [CMH_PENDING] ASC
    )	
    INCLUDE ([CMH_HOURS], [CMH_REVENUES],[CMH_FTES],[CMH_MODE],[CMH_ENTEREDBY])	
end
";
        public AddIndex_EPGResourcePlansHours_IX_EPG_RESOURCEPLANS_HOURS_CMT_UID_PRD_ID_CMH_PENDING(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        public override bool Perform()
        {
            try
            {
                LogTitle(GetWebInfo(Web), 1);
                if (IsPfeSite)
                {
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }
            }
            catch (Exception e)
            {
                LogMessage(e.ToString(), MessageKind.FAILURE, 1);
                return false;
            }
            return true;
        }

        private void UpgradePfeDatabase()
        {
            var connectionProvider = new PfeData.ConnectionProvider();
            LogMessage("Connecting to the database.", 2);
            using (var connection = connectionProvider.CreateConnection(Web))
            {
                connection.ExecuteNonQuery(CreateIndexScript);
                LogMessage("Index IX_EPG_RESOURCEPLANS_HOURS_CMT_UID_PRD_ID_CMH_PENDING ON EPG_RESOURCEPLANS_HOURS has been successfully created.", MessageKind.SUCCESS, 1);
            }
        }
    }

    [UpgradeStep(Version = EPMLiveVersion.V718, Order = 5.0, Description = "Optimize number of SQL calls on EPGP_COST_CATEGORIES during report refresh")]
    internal class OptimizeCallsEPGPCostCategories : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private readonly string AlterView_EPG_VW_RPT_Availability = @"
ALTER VIEW [dbo].[EPG_VW_RPT_Availability]
AS
SELECT     TOP (100) PERCENT dbo.EPG_VW_RPT_ListDepartments.Department, dbo.EPG_VW_RPT_ListDepartments.[Department Full Name], cc.[Cost Category] AS Role, 
                      cc.[Cost Category Full Name] AS [Role Full Name], dbo.EPG_RESOURCES.RES_NAME AS Resource, dbo.EPGP_CAPACITY_VALUES.CS_AVAIL AS Availability, 
                      dbo.EPGP_CAPACITY_VALUES.WRES_ID AS ResourceID, dbo.EPGP_CAPACITY_VALUES.CB_ID AS CalendarID, 
                      dbo.EPGP_CAPACITY_VALUES.BD_PERIOD AS PeriodID, CAST(dbo.EPGP_CAPACITY_VALUES.CB_ID AS varchar(3)) 
                      + CAST(dbo.EPGP_CAPACITY_VALUES.BD_PERIOD AS varchar(3)) AS PeriodUID, cc.CostCategoryUID
FROM         dbo.EPGP_CAPACITY_VALUES INNER JOIN
                      dbo.EPG_RESOURCES ON dbo.EPGP_CAPACITY_VALUES.WRES_ID = dbo.EPG_RESOURCES.WRES_ID INNER JOIN
                      dbo.EPGP_COST_XREF ON dbo.EPGP_CAPACITY_VALUES.WRES_ID = dbo.EPGP_COST_XREF.WRES_ID INNER JOIN
                      dbo.EPG_VW_RPT_ListCostCategory AS cc ON dbo.EPGP_COST_XREF.BC_UID = cc.CostCategoryUID INNER JOIN
                      dbo.EPG_VW_RPT_ListDepartments ON dbo.EPG_RESOURCES.WRES_RP_DEPT = dbo.EPG_VW_RPT_ListDepartments.LV_UID
ORDER BY Resource
";
        private readonly string CreateProcedure_EPG_SP_RPT_GetCostCategories = @"
CREATE PROCEDURE [dbo].[EPG_SP_RPT_GetCostCategories]
AS
	SET NOCOUNT ON	
	SELECT BC_ID, BC_NAME, BC_LEVEL, BC_UID INTO #CostCategories01 FROM EPGP_COST_CATEGORIES;
	WITH C1 AS (
		SELECT BC_ID, BC_LEVEL, 	
		ISNULL(LAG(BC_LEVEL) OVER(ORDER BY BC_ID, BC_LEVEL), 0) P_BC_LEVEL
		FROM  #CostCategories01  	
	), C2 AS (
		SELECT BC_ID, BC_LEVEL, P_BC_LEVEL,	
		SUM(CASE WHEN BC_LEVEL > 1 AND BC_LEVEL = P_BC_LEVEL THEN 0 ELSE 1 END) OVER(ORDER BY BC_ID, BC_LEVEL ROWS UNBOUNDED PRECEDING) Category
		FROM C1
	), C3 AS (
		SELECT MAX(BC_ID) P_BC_ID, BC_LEVEL, Category FROM C2 GROUP BY Category, BC_LEVEL 
	)
	SELECT * INTO #CostCategories02 FROM C3;	

	SELECT BC_ID, BC_NAME, BC_LEVEL, BC_UID,
		CASE WHEN BC_LEVEL = 1 THEN 0 ELSE 
			(SELECT MAX(CC02.P_BC_ID) FROM #CostCategories02 CC02 WHERE CC02.P_BC_ID < CC01.BC_ID AND CC02.BC_LEVEL < CC01.BC_LEVEL) 
		END P_BC_ID
	INTO #CostCategories03
	FROM #CostCategories01 CC01;
	
	WITH  CostCategories01 AS (
		SELECT BC_ID, BC_NAME, BC_LEVEL, BC_UID, P_BC_ID
		FROM #CostCategories03 CC01
	), CostCategories02 AS (
		SELECT BC_ID, BC_NAME, BC_LEVEL, BC_UID, CONVERT(NVARCHAR(1024), BC_NAME) FullName, CONVERT(NVARCHAR(255), '') ParentUniqueName
		FROM CostCategories01 
		WHERE P_BC_ID = 0 
		UNION ALL
		SELECT CC01.BC_ID, CC01.BC_NAME, CC01.BC_LEVEL, CC01.BC_UID, CONVERT(NVARCHAR(1024), FullName + N'.' + CC01.BC_NAME), CONVERT(NVARCHAR(255), CC02.BC_NAME)
		FROM CostCategories01 CC01 
		INNER JOIN CostCategories02 CC02 ON CC02.BC_ID = CC01.P_BC_ID
	)
	SELECT  BC_ID, BC_NAME, BC_LEVEL, BC_UID, FullName, ParentUniqueName
	FROM CostCategories02;
	
	DROP TABLE #CostCategories01;
	DROP TABLE #CostCategories02;
	DROP TABLE #CostCategories03;
";

        private readonly string AlterProcedure_EPG_SP_RPT_GetCost = @"
ALTER PROCEDURE [dbo].[EPG_SP_RPT_GetCost]
AS
	SET NOCOUNT ON	
	CREATE TABLE #CostCategories (BC_ID int, BC_NAME varchar(255),BC_LEVEL int, BC_UID int, FullName nvarchar(1024), ParentUniqueName nvarchar(255));
	INSERT INTO #CostCategories (BC_ID, BC_NAME,BC_LEVEL, BC_UID, FullName, ParentUniqueName)
	EXECUTE [dbo].[EPG_SP_RPT_GetCostCategories];

	SELECT  p.PROJECT_NAME AS [Project Name]
        ,ct.CT_NAME AS [Cost Type]
		,cc.BC_NAME [Cost Category]
		,cc.FullName [Cost Category Full Name]
		,cv.BD_VALUE AS Qty
		,cv.BD_COST AS Cost
		,cv.CB_ID AS CalendarID
		,cv.BD_PERIOD AS PeriodID
		,cv.CB_ID * 1000  + cv.BD_PERIOD  AS PeriodUID
		,cv.PROJECT_ID AS ProjectID
		,cv.CT_ID AS CostTypeID
		,cv.BC_UID AS CostCategoryUID
		,cv.BD_IS_SUMMARY AS IsSummary
	FROM dbo.EPGP_COST_VALUES AS cv 
	LEFT OUTER JOIN #CostCategories AS cc 
		ON cv.BC_UID = cc.BC_UID
	LEFT OUTER JOIN dbo.EPGP_PROJECTS AS p 
		ON cv.PROJECT_ID = p.PROJECT_ID 
	LEFT OUTER JOIN dbo.EPGP_COST_TYPES AS ct 
		ON cv.CT_ID = ct.CT_ID
	ORDER BY ProjectID, [Cost Type]
	
	DROP TABLE #CostCategories;
";

        private readonly string AlterProcedure_EPG_SP_RPT_GetListCostCategory = @"
ALTER PROCEDURE [dbo].[EPG_SP_RPT_GetListCostCategory]
AS
    SET NOCOUNT ON	
    CREATE TABLE #CostCategories (BC_ID int, BC_NAME varchar(255),BC_LEVEL int, BC_UID int, FullName nvarchar(1024), ParentUniqueName nvarchar(255));
    INSERT INTO #CostCategories (BC_ID, BC_NAME,BC_LEVEL, BC_UID, FullName, ParentUniqueName)
	    EXECUTE [dbo].[EPG_SP_RPT_GetCostCategories];

    SELECT [Cost Category], c2.FullName [Cost Category Full Name], CostCategoryID, CostCategoryUID, c1.BC_LEVEL, BC_UOM, BC_ROLE, MC_UID, CA_UID, c2.ParentUniqueName 
    FROM EPG_VW_RPT_ListCostCategory c1 INNER JOIN #CostCategories c2 ON c1.CostCategoryUID = c2.BC_UID

    DROP TABLE #CostCategories;
";

        private readonly string AlterProcedure_EPG_SP_RPT_GetAvailability = @"
ALTER PROCEDURE [dbo].[EPG_SP_RPT_GetAvailability]
AS
    SET NOCOUNT ON	
    CREATE TABLE #CostCategories (BC_ID int, BC_NAME varchar(255),BC_LEVEL int, BC_UID int, FullName nvarchar(1024), ParentUniqueName nvarchar(255));
    INSERT INTO #CostCategories (BC_ID, BC_NAME,BC_LEVEL, BC_UID, FullName, ParentUniqueName)
    EXECUTE [dbo].[EPG_SP_RPT_GetCostCategories];

    SELECT Department, [Department Full Name], Role, CC.FullName [Role Full Name],
	    Resource, Availability, ResourceID, CalendarID, PeriodID, PeriodUID, [EPG_VW_RPT_Availability].[CostCategoryUID]
    FROM [EPG_VW_RPT_Availability] INNER JOIN #CostCategories CC ON CC.BC_UID = [EPG_VW_RPT_Availability].[CostCategoryUID];

    DROP TABLE #CostCategories;
";

        private readonly string AlterProcedure_EPG_SP_RPT_GetResources = @"
ALTER PROCEDURE [dbo].[EPG_SP_RPT_GetResources]
AS
    SET NOCOUNT ON	
    CREATE TABLE #CostCategories (BC_ID int, BC_NAME varchar(255),BC_LEVEL int, BC_UID int, FullName nvarchar(1024), ParentUniqueName nvarchar(255));
    INSERT INTO #CostCategories (BC_ID, BC_NAME,BC_LEVEL, BC_UID, FullName, ParentUniqueName)
	    EXECUTE [dbo].[EPG_SP_RPT_GetCostCategories];

    SELECT [Resource Name], [User Name], [RP Department], [RP Department Full Name], [Role], cc.FullName [Role Full Name], [NT Logon],
	    [Can Login], [Available From], [Available To], [Email], [Inactive], [Resource], [Generic], [ResourceID],
	    [DepartmentID], [RoleUID], [WRES_EXT_UID]
    FROM [dbo].[EPG_VW_RPT_Resources] LEFT OUTER JOIN #CostCategories cc ON [dbo].[EPG_VW_RPT_Resources].[RoleUID] = cc.BC_UID

    DROP TABLE #CostCategories;
";

        public OptimizeCallsEPGPCostCategories(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        public override bool Perform()
        {
            try
            {
                LogTitle(GetWebInfo(Web), 1);
                if (IsPfeSite)
                {
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }
            }
            catch (Exception e)
            {
                LogMessage(e.ToString(), MessageKind.FAILURE, 1);
                LogMessage("Rollback transaction of this step.", 1);
                return false;
            }
            return true;
        }

        private void UpgradePfeDatabase()
        {
            var connectionProvider = new PfeData.ConnectionProvider();
            LogMessage("Connecting to the database.", 2);
            using (TransactionScope scope = new TransactionScope())
            using (var connection = connectionProvider.CreateConnection(Web))
            {
                connection.ExecuteNonQuery(AlterView_EPG_VW_RPT_Availability);
                LogMessage("Alter View EPG_VW_RPT_Availability.", MessageKind.SUCCESS, 1);
                connection.ExecuteNonQuery(CreateProcedure_EPG_SP_RPT_GetCostCategories);
                LogMessage("Create Procedure EPG_SP_RPT_GetCostCategories.", MessageKind.SUCCESS, 1);
                connection.ExecuteNonQuery(AlterProcedure_EPG_SP_RPT_GetCost);
                LogMessage("Alter Procedure EPG_SP_RPT_GetCost.", MessageKind.SUCCESS, 1);
                connection.ExecuteNonQuery(AlterProcedure_EPG_SP_RPT_GetListCostCategory);
                LogMessage("Alter Procedure EPG_SP_RPT_GetListCostCategory.", MessageKind.SUCCESS, 1);
                connection.ExecuteNonQuery(AlterProcedure_EPG_SP_RPT_GetAvailability);
                LogMessage("Alter Procedure EPG_SP_RPT_GetAvailability.", MessageKind.SUCCESS, 1);
                connection.ExecuteNonQuery(AlterProcedure_EPG_SP_RPT_GetResources);
                LogMessage("Alter Procedure EPG_SP_RPT_GetResources.", MessageKind.SUCCESS, 1);

                scope.Complete();
            }
        }
    }
}
