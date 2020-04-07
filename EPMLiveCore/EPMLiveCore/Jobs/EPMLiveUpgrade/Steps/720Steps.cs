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
    [UpgradeStep(Version = EPMLiveVersion.V720, Order = 1.0, Description = "Optimize number of SQL calls on EPGP_COST_CATEGORIES during report refresh")]
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
        private readonly string DropProcedure_EPG_SP_RPT_GetCostCategories = @"
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES 
           WHERE ROUTINE_NAME = 'EPG_SP_RPT_GetCostCategories' 
             AND ROUTINE_SCHEMA = 'dbo' 
             AND ROUTINE_TYPE = 'PROCEDURE')
EXEC ('DROP PROCEDURE dbo.EPG_SP_RPT_GetCostCategories')
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
                connection.ExecuteNonQuery(DropProcedure_EPG_SP_RPT_GetCostCategories);
                LogMessage("Drop Procedure EPG_SP_RPT_GetCostCategories.", MessageKind.SUCCESS, 1);
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


    [UpgradeStep(Version = EPMLiveVersion.V720, Order = 2.0, Description = "Improve social stream")]
    internal class ImproveSocialStream : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private const string UpgradeScript = @"
ALTER PROCEDURE [dbo].[SS_GetLatestThreads] 
	@UserId INT, 
	@WebUrl NVARCHAR(MAX),
	@Page	INT = 1,
	@Limit	INT = 1000000,
	@ThreadId UNIQUEIDENTIFIER = NULL
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Start INT, @End INT
	
	SET @Start = (@Page - 1) * @Limit
	SET @End =   (@Page * @Limit + 1)
	
	IF @Limit > 1000000 SET @Limit = 1000000;
	 
	SELECT ThreadId, ThreadTitle, ThreadUrl, ThreadKind, ThreadLastActivityOn, ThreadFirstActivityOn, WebId, WebTitle, 
				WebUrl, ListId, ListName, ListIcon, ItemId, TotalActivities, TotalComments
	FROM (
			SELECT	TOP (@End - 1)
					ROW_NUMBER() OVER (ORDER BY SS_Threads.LastActivityDateTime DESC) AS RowNum,
					SS_Threads.Id AS ThreadId, SS_Threads.Title AS ThreadTitle, SS_Threads.URL AS ThreadUrl, 
					SS_Threads.Kind AS ThreadKind, SS_Threads.LastActivityDateTime AS ThreadLastActivityOn, 
					SS_Threads.FirstActivityDateTime AS ThreadFirstActivityOn, SS_Threads.WebId, dbo.RPTWeb.WebTitle, 
					dbo.RPTWeb.WebUrl, SS_Threads.ListId, dbo.RPTList.ListName, dbo.ReportListIds.ListIcon AS ListIcon, 
					SS_Threads.ItemId, 
					SS_Threads.TotalActivities,
                    SS_Threads.TotalComments, 
					1 AS HasAccess
							 
			FROM	dbo.ReportListIds INNER JOIN dbo.RPTList ON dbo.ReportListIds.Id = dbo.RPTList.RPTListId RIGHT OUTER JOIN 
							
					(	SELECT ISNULL(SS_Threads1.TotalActivities, 0) TotalActivities, ISNULL(SS_Threads2.TotalComments, 0) TotalComments, SS_Threads3.*
						FROM
							(	SELECT SS_Threads.Id, COUNT(A1.ID) TotalActivities 
								FROM (SELECT * FROM SS_Threads  WHERE 
								(SS_Threads.Id = @ThreadId OR @ThreadId IS NULL) AND 
								Deleted = 0) SS_Threads
								LEFT OUTER JOIN
								(select * from dbo.SS_Activities where (MassOperation = 0) AND (Kind <> 3 AND Kind <> 4)) a1 
								ON (A1.ThreadId = SS_Threads.Id)
								GROUP BY SS_Threads.Id
								HAVING COUNT(A1.ID) > 0
							) SS_Threads1
							full outer join 
							(	SELECT SS_Threads.Id, COUNT(A2.ID) TotalComments
								FROM (SELECT * FROM SS_Threads  WHERE 
								(SS_Threads.Id = @ThreadId OR @ThreadId IS NULL) AND 
								Deleted = 0) SS_Threads
								left outer join 
								(select * from dbo.SS_Activities where (Kind = 4)) a2 
								ON (A2.ThreadId = SS_Threads.Id)
								GROUP BY SS_Threads.Id
								HAVING COUNT(A2.ID) > 0
							)SS_Threads2
							ON SS_Threads1.ID = SS_Threads2.ID
							INNER JOIN SS_Threads SS_Threads3
							ON SS_Threads1.ID = SS_Threads3.ID OR SS_Threads2.ID = SS_Threads3.ID
					) SS_Threads
					INNER JOIN dbo.RPTWeb ON SS_Threads.WebId = dbo.RPTWeb.WebId ON dbo.RPTList.RPTListId = SS_Threads.ListId
			WHERE   (SS_Threads.Deleted = 0) AND (SS_Threads.Id = @ThreadId OR @ThreadId IS NULL) 
					AND (dbo.RPTWeb.WebUrl = @WebUrl OR dbo.RPTWeb.WebUrl LIKE REPLACE(@WebUrl + '/%', '//', '/'))
					ORDER BY SS_Threads.LastActivityDateTime DESC
					) AS DT1
	WHERE RowNum > @Start AND RowNum < @End
	
END";

        #region Constructors (1) 
        public ImproveSocialStream(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

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

                        #region Store Procedure Code

                        rptCn.ExecuteNonQuery(UpgradeScript);

                        #endregion

                        LogMessage("Procedure upgraded", MessageKind.SUCCESS, 4);
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
}
