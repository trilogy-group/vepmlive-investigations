using System;
using System.Collections.Generic;

using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V640, Order = 2, Description = "Adding archive / restore project feature to PFE database")]
    internal class ProjectArchiveRestorePfeInstall64 : UpgradeStep
    {
        private const string ProjectsTableName = "EPGP_PROJECTS";
        private const string ProjectArchivedColumnName = "PROJECT_ARCHIVED";
        private const string VersionMarker = "v6.4.0.2";
        private const string ProjectAddArchivedColumnQuery = @"ALTER TABLE EPGP_PROJECTS ADD PROJECT_ARCHIVED tinyint NULL";
        private const string ReadActualWorkProcedureName = "dbo.EPG_SP_ReadActualWork";
        private const string ReadScheduledWorkProcedureName = "dbo.EPG_SP_ReadScheduledWork";

        private const string ReadActualWorkProcedureUpdateQuery = @"ALTER PROCEDURE dbo.EPG_SP_ReadActualWork
/*  Read Actual Work, for now and perhaps for ever just reading WE Actuals
     If need UNION with PfE Actuals then use technique like EPG_SP_ReadPlannedWorkByPeriod_NAX because software expects grouped rows

Public Enum ResCenterRequest (see also EPG_SP_ReadScheduledWork)
    ResourceValuesForPIs = 3  - for one or more PIs - all resources 
    ResourceValuesForResources = 4  - for one or more resources - all PIs except archived

	Changes Log:
		2018/07/10: Applied filter for archived items (EPMLCID-18197). Upgrade step marker: v6.4.0.2
*/
   @Mode INT,
   @FromPeriodID INT,
   @CalID INT,
   @ToPeriodID INT,
   @sList NTEXT,
   @sRList NTEXT
AS 
if (@Mode = 4) 
 Begin
 Select c.PROJECT_ID,WRES_ID,WEC_MAJORCATEGORY,PRD_ID,Sum(WEH_NORMALHOURS+WEH_OVERTIMEHOURS) As Hours
   From EPG_WE_CHARGES c
   INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on c.WRES_ID=LT2.TokenVal
   Join EPG_WE_ACTUALHOURS w On w.WEH_CHG_UID=c.WEC_CHG_UID
   JOIN EPG_PERIODS PRD on PRD.CB_ID=@CalID and (w.WEH_DATE >= PRD.PRD_START_DATE and w.WEH_DATE <= PRD.PRD_FINISH_DATE)
   INNER JOIN EPGP_PROJECTS p ON c.PROJECT_ID = p.PROJECT_ID AND (p.PROJECT_ARCHIVED = 0 OR p.PROJECT_ARCHIVED IS NULL)
	WHERE (PRD.PRD_ID >= @FromPeriodID And PRD.PRD_ID <= @ToPeriodID) AND WRES_ID > 0
	GROUP BY c.PROJECT_ID,c.WRES_ID,c.WEC_MAJORCATEGORY,PRD.PRD_ID
	ORDER BY c.PROJECT_ID,c.WRES_ID,c.WEC_MAJORCATEGORY,PRD.PRD_ID
 End 
 else if (@Mode = 3)
 Begin
 Select PROJECT_ID,WRES_ID,WEC_MAJORCATEGORY,PRD_ID,Sum(WEH_NORMALHOURS+WEH_OVERTIMEHOURS) As Hours
   From EPG_WE_CHARGES c
   INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT2 on c.PROJECT_ID=LT2.TokenVal
   Join EPG_WE_ACTUALHOURS w On w.WEH_CHG_UID=c.WEC_CHG_UID
   JOIN EPG_PERIODS PRD on PRD.CB_ID=@CalID and (w.WEH_DATE >= PRD.PRD_START_DATE and w.WEH_DATE <= PRD.PRD_FINISH_DATE)
	WHERE (PRD.PRD_ID >= @FromPeriodID And PRD.PRD_ID <= @ToPeriodID) AND WRES_ID > 0
	GROUP BY c.PROJECT_ID,c.WRES_ID,c.WEC_MAJORCATEGORY,PRD.PRD_ID
	ORDER BY c.PROJECT_ID,c.WRES_ID,c.WEC_MAJORCATEGORY,PRD.PRD_ID
  End
";

        private const string ReadScheduledWorkProcedureUpdateQuery = @"ALTER PROCEDURE dbo.EPG_SP_ReadScheduledWork
/*  Read work, both from Project Schedule AND WIs
Public Enum ResCenterRequest
    ResourceValuesForDepts = 1  - for one or more depts - but a list of resources passed in here - all PIs except archived items
    ResourceValuesForPIsinDept = 2  - for one or more PIs, resources in one or more depts - but a list of resources passed in here
    ResourceValuesForPIs = 3  - for one or more PIs - all resources 
    ResourceValuesForResources = 4  - for one or more resources - all PIs except archived items

	Changes Log:
		2018/07/10: Applied filter for archived items (EPMLCID-18197). Upgrade step marker: v6.4.0.2
*/
   @Mode INT,
   @FromDate DATETIME,
   @ToDate DATETIME,
   @sList NTEXT,
   @sRList NTEXT
AS
 DECLARE @CurrentVersion INT
 SELECT @CurrentVersion = ADM_DEFAULT_PROJ_VERSION_ID FROM EPG_ADMIN
if (@Mode = 1 Or @Mode = 4) 
 Begin
  Select 'TASK' as SOURCE,v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,RES_IN_PLAN 
  From EPGX_PROJECT_TSWORK w
  Inner Join EPGX_PROJECT_VERSIONS v On v.WPROJ_ID=w.WPROJ_ID And VERSION_ID=@CurrentVersion
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = v.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0 AND (p.PROJECT_ARCHIVED = 0 OR p.PROJECT_ARCHIVED IS NULL) 
  INNER JOIN EPGP_TEAMS t On t.PROJECT_ID = v.PROJECT_ID and t.WRES_ID=w.WRES_ID 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where w.WRES_ID > 0 and TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate 
 UNION ALL
  Select 'WI' as SOURCE,w.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,RES_IN_PLAN 
  From EPGP_PI_WORKITEM_TSWORK w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0 AND (p.PROJECT_ARCHIVED = 0 OR p.PROJECT_ARCHIVED IS NULL) 
  INNER JOIN EPGP_TEAMS t On t.PROJECT_ID = p.PROJECT_ID and t.WRES_ID=w.WRES_ID 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate 
 UNION ALL
  Select 'W1' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN 
  From EPGP_PI_WORK1 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0 AND (p.PROJECT_ARCHIVED = 0 OR p.PROJECT_ARCHIVED IS NULL) 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate 
 UNION ALL
  Select 'W2' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN 
  From EPGP_PI_WORK2 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0 AND (p.PROJECT_ARCHIVED = 0 OR p.PROJECT_ARCHIVED IS NULL) 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate 
  Order by v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE
 End
else if (@Mode = 2)
 Begin
  Select 'TASK' as SOURCE,v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,1 as RES_IN_PLAN 
  From EPGX_PROJECT_TSWORK w
  Inner Join EPGX_PROJECT_VERSIONS v On v.WPROJ_ID=w.WPROJ_ID And VERSION_ID=@CurrentVersion
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = v.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN EPGP_TEAMS t On t.PROJECT_ID = v.PROJECT_ID and t.WRES_ID=w.WRES_ID 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where w.WRES_ID > 0 and TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate 
 UNION ALL
  Select 'WI' as SOURCE,w.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,RES_IN_PLAN 
  From EPGP_PI_WORKITEM_TSWORK w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN EPGP_TEAMS t On t.PROJECT_ID = p.PROJECT_ID and t.WRES_ID=w.WRES_ID
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate 
 UNION ALL
  Select 'W1' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN 
  From EPGP_PI_WORK1 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate 
 UNION ALL
  Select 'W2' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN 
  From EPGP_PI_WORK2 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate 
  Order by v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE
 End
 
else if (@Mode = 3)
 Begin
  Select 'TASK' as SOURCE,v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,1 as RES_IN_PLAN
  From EPGX_PROJECT_TSWORK w
  Inner Join EPGX_PROJECT_VERSIONS v On v.WPROJ_ID=w.WPROJ_ID And VERSION_ID=@CurrentVersion
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = v.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  Where w.WRES_ID > 0 and TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate 
 UNION ALL
  Select 'WI' as SOURCE,w.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,1 as RES_IN_PLAN
  From EPGP_PI_WORKITEM_TSWORK w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  Where TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate  
  UNION ALL
  Select 'W1' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN
  From EPGP_PI_WORK1 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate  
   UNION ALL
  Select 'W2' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN
  From EPGP_PI_WORK2 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate
  Order by v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE
 End
";

        public ProjectArchiveRestorePfeInstall64(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
        }

        public override bool Perform()
        {
            try
            {
                if (IsPfeSite)
                {
                    LogTitle(GetWebInfo(Web), 1);
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }
                else
                {
                    LogMessage("This is not a PFE site.", MessageKind.SKIPPED, 2);
                }
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 1);
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
                var columnExists = connection.ColumnExist(ProjectsTableName, ProjectArchivedColumnName);
                if (!columnExists)
                {
                    connection.ExecuteNonQuery(ProjectAddArchivedColumnQuery);
                    LogMessage($"{ProjectArchivedColumnName} column added to {ProjectsTableName} table.", MessageKind.SUCCESS, 2);
                }
                else
                {
                    LogMessage($"{ProjectArchivedColumnName} column already exists in {ProjectsTableName}.", MessageKind.SKIPPED, 2);
                }

                var procedures = new Dictionary<string, string>()
                                     {
                                         { ReadActualWorkProcedureName, ReadActualWorkProcedureUpdateQuery },
                                         { ReadScheduledWorkProcedureName, ReadScheduledWorkProcedureUpdateQuery }
                                     };
                foreach (var procedure in procedures)
                {
                    var definition = connection.GetSpDefinition(procedure.Key);
                    if (definition != null && !definition.Contains(VersionMarker))
                    {
                        connection.ExecuteNonQuery(procedure.Value);
                        LogMessage($"{procedure.Key} procedure updated.", MessageKind.SUCCESS, 2);
                    }
                    else
                    {
                        LogMessage($"{procedure.Key} already have been updated.", MessageKind.SKIPPED, 2);
                    }
                }

                LogMessage("PFE Database is ready to use with archive restore project feature.", MessageKind.SUCCESS, 1);
            }
        }
    }
}