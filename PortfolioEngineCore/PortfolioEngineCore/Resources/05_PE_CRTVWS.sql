declare @createoralter varchar(10)
 
------------------------------View: EPG_VW_RPT_ListRoles---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_RPT_ListRoles')
begin
    Print 'Creating View EPG_VW_RPT_ListRoles'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_RPT_ListRoles'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_RPT_ListRoles]
AS
SELECT     TOP (100) PERCENT dbo.EPGP_LOOKUP_VALUES.LV_FULLVALUE AS Role, dbo.EPGP_LOOKUP_VALUES.LOOKUP_UID, dbo.EPGP_LOOKUP_VALUES.LV_UID, 
                      dbo.EPGP_LOOKUP_VALUES.LV_ID, dbo.EPGP_LOOKUP_VALUES.LV_LEVEL, dbo.EPGP_LOOKUP_VALUES.LV_INACTIVE, 
                      dbo.EPGP_LOOKUP_VALUES.LV_EXT_UID
FROM         dbo.EPGP_LOOKUP_VALUES INNER JOIN
                      dbo.EPGP_LOOKUP_TABLES ON dbo.EPGP_LOOKUP_VALUES.LOOKUP_UID = dbo.EPGP_LOOKUP_TABLES.LOOKUP_UID INNER JOIN
                      dbo.EPG_ADMIN ON dbo.EPGP_LOOKUP_TABLES.LOOKUP_UID = dbo.EPG_ADMIN.ADM_ROLE_CODE
ORDER BY Role

')
 

 
------------------------------View: EPG_VW_RPT_ListDepartments---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_RPT_ListDepartments')
begin
    Print 'Creating View EPG_VW_RPT_ListDepartments'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_RPT_ListDepartments'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_RPT_ListDepartments]
AS
SELECT     dbo.EPGP_LOOKUP_VALUES.LV_VALUE AS Department, dbo.EPGP_LOOKUP_VALUES.LV_FULLVALUE AS [Department Full Name], 
                      dbo.EPG_RESOURCES.RES_NAME AS [Resource Manager], dbo.EPGP_LOOKUP_VALUES.LV_ID AS OrderID, dbo.EPGP_LOOKUP_VALUES.LV_LEVEL AS LevelID, 
                      dbo.EPG_RESOURCES.WRES_ID AS ResourceManagerID, dbo.EPGP_LOOKUP_VALUES.LV_INACTIVE, dbo.EPGP_LOOKUP_VALUES.LV_UID, 
                      dbo.EPGP_LOOKUP_VALUES.LV_EXT_UID
FROM         dbo.EPG_RESOURCES INNER JOIN
                      dbo.EPG_RES_MANAGERS ON dbo.EPG_RESOURCES.WRES_ID = dbo.EPG_RES_MANAGERS.WRES_ID RIGHT OUTER JOIN
                      dbo.EPGP_LOOKUP_VALUES INNER JOIN
                      dbo.EPGP_LOOKUP_TABLES ON dbo.EPGP_LOOKUP_VALUES.LOOKUP_UID = dbo.EPGP_LOOKUP_TABLES.LOOKUP_UID INNER JOIN
                      dbo.EPG_ADMIN ON dbo.EPGP_LOOKUP_TABLES.LOOKUP_UID = dbo.EPG_ADMIN.ADM_RPE_DEPT_CODE ON 
                      dbo.EPG_RES_MANAGERS.CODE_UID = dbo.EPGP_LOOKUP_VALUES.LV_UID

')
 
------------------------------View: EPG_VW_RPT_ListCostCategory---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_RPT_ListCostCategory')
begin
    Print 'Creating View EPG_VW_RPT_ListCostCategory'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_RPT_ListCostCategory'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_RPT_ListCostCategory]
AS
SELECT     TOP (100) PERCENT BC_NAME AS [Cost Category], dbo.EPG_FN_RPT_GetCostCategoryFullName(BC_ID, BC_NAME) AS [Cost Category Full Name], 
                      BC_ID AS CostCategoryID, BC_UID AS CostCategoryUID, BC_LEVEL, BC_UOM, BC_ROLE, MC_UID, CA_UID, dbo.EPG_FN_RPT_GetParentUniqueName(BC_ID) 
                      AS ParentUniqueName
FROM         dbo.EPGP_COST_CATEGORIES
ORDER BY CostCategoryID

')


------------------------------View: EPG_VW_RPT_Availability---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_RPT_Availability')
begin
    Print 'Creating View EPG_VW_RPT_Availability'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_RPT_Availability'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_RPT_Availability]
AS
SELECT     TOP (100) PERCENT dbo.EPG_VW_RPT_ListDepartments.Department, dbo.EPG_VW_RPT_ListDepartments.[Department Full Name], cc.[Cost Category] AS Role, 
                      cc.[Cost Category Full Name] AS [Role Full Name], dbo.EPG_RESOURCES.RES_NAME AS Resource, dbo.EPGP_CAPACITY_VALUES.CS_AVAIL AS Availability, 
                      dbo.EPGP_CAPACITY_VALUES.WRES_ID AS ResourceID, dbo.EPGP_CAPACITY_VALUES.CB_ID AS CalendarID, 
                      dbo.EPGP_CAPACITY_VALUES.BD_PERIOD AS PeriodID, CAST(dbo.EPGP_CAPACITY_VALUES.CB_ID AS varchar(3)) 
                      + CAST(dbo.EPGP_CAPACITY_VALUES.BD_PERIOD AS varchar(3)) AS PeriodUID
FROM         dbo.EPGP_CAPACITY_VALUES INNER JOIN
                      dbo.EPG_RESOURCES ON dbo.EPGP_CAPACITY_VALUES.WRES_ID = dbo.EPG_RESOURCES.WRES_ID INNER JOIN
                      dbo.EPGP_COST_XREF ON dbo.EPGP_CAPACITY_VALUES.WRES_ID = dbo.EPGP_COST_XREF.WRES_ID INNER JOIN
                      dbo.EPG_VW_RPT_ListCostCategory AS cc ON dbo.EPGP_COST_XREF.BC_UID = cc.CostCategoryUID INNER JOIN
                      dbo.EPG_VW_RPT_ListDepartments ON dbo.EPG_RESOURCES.WRES_RP_DEPT = dbo.EPG_VW_RPT_ListDepartments.LV_UID
ORDER BY Resource

')
 
------------------------------View: EPG_VW_RPT_Calendar---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_RPT_Calendar')
begin
    Print 'Creating View EPG_VW_RPT_Calendar'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_RPT_Calendar'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_RPT_Calendar]
AS
SELECT     TOP (100) PERCENT dbo.EPGP_COST_BREAKDOWNS.CB_NAME AS [Calendar Name], dbo.EPG_PERIODS.PRD_NAME AS [Period Name], 
                      dbo.EPG_PERIODS.PRD_START_DATE AS [Start Date], dbo.EPG_PERIODS.PRD_FINISH_DATE AS [Finish Date], dbo.EPG_PERIODS.PRD_IS_CLOSED, 
                      CASE WHEN dbo.EPG_ADMIN.ADM_PORT_COMMITMENTS_CB_ID = dbo.EPGP_COST_BREAKDOWNS.CB_ID THEN ''Yes'' ELSE ''No'' END AS RPCalendar, 
                      dbo.EPGP_COST_BREAKDOWNS.CB_ID AS CalendarID, dbo.EPG_PERIODS.PRD_ID AS PeriodID, CONVERT(int, 
                      CAST(dbo.EPGP_COST_BREAKDOWNS.CB_ID AS varchar(3)) + CAST(dbo.EPG_PERIODS.PRD_ID AS varchar(3))) AS PeriodUID
FROM         dbo.EPGP_COST_BREAKDOWNS INNER JOIN
                      dbo.EPG_PERIODS ON dbo.EPGP_COST_BREAKDOWNS.CB_ID = dbo.EPG_PERIODS.CB_ID LEFT OUTER JOIN
                      dbo.EPG_ADMIN ON dbo.EPGP_COST_BREAKDOWNS.CB_ID = dbo.EPG_ADMIN.ADM_PORT_COMMITMENTS_CB_ID
ORDER BY [Calendar Name], PeriodID

')
 
------------------------------View: EPG_VW_RPT_CapacityPlanner---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_RPT_CapacityPlanner')
begin
    Print 'Creating View EPG_VW_RPT_CapacityPlanner'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_RPT_CapacityPlanner'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_RPT_CapacityPlanner]
AS
SELECT     TOP (100) PERCENT cc.[Cost Category], dbo.EPG_VW_RPT_ListDepartments.Department, dbo.EPG_VW_RPT_ListDepartments.[Department Full Name], 
                      dbo.EPG_VW_RPT_ListRoles.Role, dbo.EPGP_PROJECTS.PROJECT_NAME AS [Project Name], dbo.EPG_RESOURCES.RES_NAME AS Resource, 
                      rph.CMH_HOURS / 100. AS Hours, 
                      CASE rp.CMT_STATUS WHEN 1 THEN ''Requirement'' WHEN 256 THEN ''Commitment'' WHEN 512 THEN ''Commitment Cancelled'' ELSE ''No Status'' END AS Status, 
                      rph.CMH_FTES, rp.CMT_RATE, rp.CMT_TOTAL_COST, rp.CMT_CALC_TOTAL_COST, rp.CMT_RATE_PRD_ID, rp.CMT_RATETYPE_UID, rp.CMT_STATUS, 
                      rp.CMT_TIMESTAMP, rp.RP_GROUP, rp.RP_ACTIVE_COMMITMENT, rp.RP_RM_STATUS, rp.RP_PM_STATUS, rp.CMT_START_DATE, rp.CMT_FINISH_DATE, 
                      rp.CMT_ALLOCATION, rp.CMT_ALLOCATION_MODE, rp.CMT_ENTEREDBY_WRES_ID, rp.CMT_MAJORCATEGORY, rp.CMT_DESC, rp.CMT_RT_UID, 
                      rp.PROJECT_ID AS ProjectID, rp.WRES_ID AS ResourceID, rph.PRD_ID AS PeriodID, dbo.EPG_VW_RPT_Calendar.RPCalendar, 
                      dbo.EPG_VW_RPT_Calendar.[Period Name], rp.CMT_ROLE, rp.CMT_DEPT, dbo.EPG_VW_RPT_Calendar.CalendarID, dbo.EPG_VW_RPT_Calendar.PeriodUID,dbo.epgp_rp_category_values.cat_text_1 AS CustomTextField1,dbo.epgp_rp_category_values.cat_text_2 AS CustomTextField2,dbo.epgp_rp_category_values.cat_text_3 AS CustomTextField3,dbo.epgp_rp_category_values.cat_text_4 AS CustomTextField4,dbo.epgp_rp_category_values.cat_text_5 AS CustomTextField5,dbo.epgp_rp_category_values.cat_code_1 AS CustomCodeField1,dbo.epgp_rp_category_values.cat_code_2 AS CustomCodeField2,dbo.epgp_rp_category_values.cat_code_3 AS CustomCodeField3,dbo.epgp_rp_category_values.cat_code_4 AS CustomCodeField4,dbo.epgp_rp_category_values.cat_code_5 AS CustomCodeField5     
FROM         dbo.EPG_VW_RPT_ListDepartments INNER JOIN
                      dbo.EPG_RESOURCEPLANS_HOURS AS rph INNER JOIN
                      dbo.EPG_RESOURCEPLANS AS rp ON rph.CMT_UID = rp.CMT_UID ON dbo.EPG_VW_RPT_ListDepartments.LV_UID = rp.CMT_DEPT INNER JOIN
                      dbo.EPG_VW_RPT_ListCostCategory AS cc ON rp.PARENT_BC_UID = cc.CostCategoryUID INNER JOIN
                      dbo.EPG_VW_RPT_ListRoles ON rp.CMT_ROLE = dbo.EPG_VW_RPT_ListRoles.LV_UID INNER JOIN
                      dbo.EPGP_PROJECTS ON rp.PROJECT_ID = dbo.EPGP_PROJECTS.PROJECT_ID INNER JOIN
                      dbo.EPG_RESOURCES ON rp.WRES_ID = dbo.EPG_RESOURCES.WRES_ID INNER JOIN
                      dbo.EPG_VW_RPT_Calendar ON rph.PRD_ID = dbo.EPG_VW_RPT_Calendar.PeriodID
       LEFT JOIN dbo.epgp_rp_category_values 
              ON dbo.epgp_rp_category_values.cat_cmt_uid = rp.cmt_uid                       
WHERE     (dbo.EPG_VW_RPT_Calendar.RPCalendar = ''Yes'') AND (dbo.EPGP_PROJECTS.PROJECT_MARKED_DELETION = 0) 
  
')
 
------------------------------View: EPG_VW_RPT_Cost---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_RPT_Cost')
begin
    Print 'Creating View EPG_VW_RPT_Cost'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_RPT_Cost'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_RPT_Cost]
AS
SELECT     TOP (100) PERCENT p.PROJECT_NAME AS [Project Name], ct.CT_NAME AS [Cost Type], cc.[Cost Category], cc.[Cost Category Full Name], cv.BD_VALUE AS Qty, 
                      cv.BD_COST AS Cost, cv.CB_ID AS CalendarID, cv.BD_PERIOD AS PeriodID, CONVERT(int, CAST(cv.CB_ID AS varchar(3)) + CAST(cv.BD_PERIOD AS varchar(3))) 
                      AS PeriodUID, cv.PROJECT_ID AS ProjectID, cv.CT_ID AS CostTypeID, cv.BC_UID AS CostCategoryUID, cv.BD_IS_SUMMARY AS IsSummary
FROM         dbo.EPGP_COST_VALUES AS cv LEFT OUTER JOIN
                      dbo.EPG_VW_RPT_ListCostCategory AS cc ON cv.BC_UID = cc.CostCategoryUID LEFT OUTER JOIN
                      dbo.EPGP_PROJECTS AS p ON cv.PROJECT_ID = p.PROJECT_ID LEFT OUTER JOIN
                      dbo.EPGP_COST_TYPES AS ct ON cv.CT_ID = ct.CT_ID
ORDER BY ProjectID, [Cost Type]

')
 
------------------------------View: EPG_VW_RPT_ListCostTypes---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_RPT_ListCostTypes')
begin
    Print 'Creating View EPG_VW_RPT_ListCostTypes'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_RPT_ListCostTypes'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_RPT_ListCostTypes]
AS
SELECT     TOP (100) PERCENT CT_NAME AS [Cost Type], CT_ID AS CostTypeID, CT_CB_ID AS CalendarID, CT_EDIT_MODE
FROM         dbo.EPGP_COST_TYPES
ORDER BY [Cost Type]

')
------------------------------View: EPG_VW_RPT_Projects---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_RPT_Projects')
begin
    Print 'Creating View EPG_VW_RPT_Projects'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_RPT_Projects'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_RPT_Projects]
AS
SELECT     TOP (100) PERCENT p.PROJECT_NAME AS [Project Name], CONVERT(varchar(10), p.PROJECT_START_DATE, 101) AS [Start Date], CONVERT(varchar(10), 
                      p.PROJECT_FINISH_DATE, 101) AS [Finish Date], p.PROJECT_PERCENT_COMPLETE AS [Percent Complete], p.PROJECT_STATUS AS Status, CONVERT(varchar(10), 
                      p.PROJECT_CREATED, 101) AS [Created Date], p.PROJECT_PRIORITY AS Priority, p.PROJECT_MARKED_DELETION, r1.RES_NAME AS [Created By], 
                      r2.RES_NAME AS [Project Owner], r3.RES_NAME AS [Project Manager], r4.RES_NAME AS [Project Plan Owner], p.PROJECT_ID AS ProjectID, 
                      p.PROJECT_EXT_UID
FROM         dbo.EPGP_PROJECTS AS p LEFT OUTER JOIN
                      dbo.EPG_RESOURCES AS r4 ON p.PROJECT_PLAN_OWNER = r4.WRES_ID LEFT OUTER JOIN
                      dbo.EPG_RESOURCES AS r3 ON p.PROJECT_MANAGER = r3.WRES_ID LEFT OUTER JOIN
                      dbo.EPG_RESOURCES AS r2 ON p.PROJECT_OWNER = r2.WRES_ID LEFT OUTER JOIN
                      dbo.EPG_RESOURCES AS r1 ON p.PROJECT_CREATEDBY = r1.WRES_ID
ORDER BY [Project Name]

')
 
------------------------------View: EPG_VW_RPT_Resources---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_RPT_Resources')
begin
    Print 'Creating View EPG_VW_RPT_Resources'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_RPT_Resources'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_RPT_Resources]
AS
SELECT     TOP (100) PERCENT dbo.EPG_RESOURCES.RES_NAME AS [Resource Name], dbo.EPG_RESOURCES.WRES_NT_ACCOUNT AS [User Name], 
                      dbo.EPGP_LOOKUP_VALUES.LV_VALUE AS [RP Department], dbo.EPGP_LOOKUP_VALUES.LV_FULLVALUE AS [RP Department Full Name], cc.[Cost Category] AS Role, 
                      cc.[Cost Category Full Name] AS [Role Full Name], CASE WRES_USE_NT_LOGON WHEN 0 THEN ''No'' ELSE ''Yes'' END AS [NT Logon], 
                      CASE WRES_CAN_LOGIN WHEN 0 THEN ''No'' ELSE ''Yes'' END AS [Can Login], dbo.EPG_RESOURCES.WRES_AVAILABLEFROM AS [Available From], 
                      dbo.EPG_RESOURCES.WRES_AVAILABLETO AS [Available To], dbo.EPG_RESOURCES.WRES_EMAIL AS Email, 
                      CASE WRES_INACTIVE WHEN 0 THEN ''No'' ELSE ''Yes'' END AS Inactive, CASE WRES_IS_RESOURCE WHEN 0 THEN ''No'' ELSE ''Yes'' END AS Resource, 
                      CASE WRES_IS_GENERIC WHEN 0 THEN ''No'' ELSE ''Yes'' END AS Generic, dbo.EPG_RESOURCES.WRES_ID AS ResourceID, 
                      dbo.EPG_RESOURCES.WRES_RP_DEPT AS DepartmentID, cc.CostCategoryUID AS RoleUID, dbo.EPG_RESOURCES.WRES_EXT_UID
FROM         dbo.EPG_VW_RPT_ListCostCategory AS cc INNER JOIN
                      dbo.EPGP_COST_XREF ON cc.CostCategoryUID = dbo.EPGP_COST_XREF.BC_UID RIGHT OUTER JOIN
                      dbo.EPG_RESOURCES LEFT OUTER JOIN
                      dbo.EPGP_LOOKUP_VALUES ON dbo.EPG_RESOURCES.WRES_RP_DEPT = dbo.EPGP_LOOKUP_VALUES.LV_UID ON 
                      dbo.EPGP_COST_XREF.WRES_ID = dbo.EPG_RESOURCES.WRES_ID
ORDER BY [Resource Name]

')
 
--------------------------------------------------------------
------------------------------View: EPG_VW_PortfolioCustomFields---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPG_VW_PortfolioCustomFields')
begin
    Print 'Creating View EPG_VW_PortfolioCustomFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View EPG_VW_PortfolioCustomFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[EPG_VW_PortfolioCustomFields]
AS

-- ****************************************************************************************************
-- EPGP_PROJECT_INT_VALUES
-- ****************************************************************************************************
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_001'' as ColumnName, convert(varchar(255), PI_001) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_002'' as ColumnName, convert(varchar(255), PI_002) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_003'' as ColumnName, convert(varchar(255), PI_003) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_004'' as ColumnName, convert(varchar(255), PI_004) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_005'' as ColumnName, convert(varchar(255), PI_005) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_006'' as ColumnName, convert(varchar(255), PI_006) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_007'' as ColumnName, convert(varchar(255), PI_007) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_008'' as ColumnName, convert(varchar(255), PI_008) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_009'' as ColumnName, convert(varchar(255), PI_009) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_010'' as ColumnName, convert(varchar(255), PI_010) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_011'' as ColumnName, convert(varchar(255), PI_011) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_012'' as ColumnName, convert(varchar(255), PI_012) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_013'' as ColumnName, convert(varchar(255), PI_013) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_014'' as ColumnName, convert(varchar(255), PI_014) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_015'' as ColumnName, convert(varchar(255), PI_015) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_016'' as ColumnName, convert(varchar(255), PI_016) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_017'' as ColumnName, convert(varchar(255), PI_017) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_018'' as ColumnName, convert(varchar(255), PI_018) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_019'' as ColumnName, convert(varchar(255), PI_019) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_020'' as ColumnName, convert(varchar(255), PI_020) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_021'' as ColumnName, convert(varchar(255), PI_021) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_022'' as ColumnName, convert(varchar(255), PI_022) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_023'' as ColumnName, convert(varchar(255), PI_023) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_024'' as ColumnName, convert(varchar(255), PI_024) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_025'' as ColumnName, convert(varchar(255), PI_025) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_026'' as ColumnName, convert(varchar(255), PI_026) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_027'' as ColumnName, convert(varchar(255), PI_027) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_028'' as ColumnName, convert(varchar(255), PI_028) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_029'' as ColumnName, convert(varchar(255), PI_029) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_030'' as ColumnName, convert(varchar(255), PI_030) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_031'' as ColumnName, convert(varchar(255), PI_031) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_032'' as ColumnName, convert(varchar(255), PI_032) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_033'' as ColumnName, convert(varchar(255), PI_033) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_034'' as ColumnName, convert(varchar(255), PI_034) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_035'' as ColumnName, convert(varchar(255), PI_035) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_036'' as ColumnName, convert(varchar(255), PI_036) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_037'' as ColumnName, convert(varchar(255), PI_037) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_038'' as ColumnName, convert(varchar(255), PI_038) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_039'' as ColumnName, convert(varchar(255), PI_039) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_040'' as ColumnName, convert(varchar(255), PI_040) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_041'' as ColumnName, convert(varchar(255), PI_041) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_042'' as ColumnName, convert(varchar(255), PI_042) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_043'' as ColumnName, convert(varchar(255), PI_043) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_044'' as ColumnName, convert(varchar(255), PI_044) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_045'' as ColumnName, convert(varchar(255), PI_045) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_046'' as ColumnName, convert(varchar(255), PI_046) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_047'' as ColumnName, convert(varchar(255), PI_047) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_048'' as ColumnName, convert(varchar(255), PI_048) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_049'' as ColumnName, convert(varchar(255), PI_049) as Value
from  EPGP_PROJECT_INT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_INT_VALUES'' as TableName, ''PI_050'' as ColumnName, convert(varchar(255), PI_050) as Value
from  EPGP_PROJECT_INT_VALUES
union

-- ****************************************************************************************************
-- EPGP_PROJECT_TEXT_VALUES
-- ****************************************************************************************************
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_001'' as ColumnName, PT_001 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_002'' as ColumnName, PT_002 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_003'' as ColumnName, PT_003 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_004'' as ColumnName, PT_004 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_005'' as ColumnName, PT_005 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_006'' as ColumnName, PT_006 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_007'' as ColumnName, PT_007 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_008'' as ColumnName, PT_008 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_009'' as ColumnName, PT_009 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_010'' as ColumnName, PT_010 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_011'' as ColumnName, PT_011 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_012'' as ColumnName, PT_012 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_013'' as ColumnName, PT_013 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_014'' as ColumnName, PT_014 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_015'' as ColumnName, PT_015 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_016'' as ColumnName, PT_016 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_017'' as ColumnName, PT_017 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_018'' as ColumnName, PT_018 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_019'' as ColumnName, PT_019 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_020'' as ColumnName, PT_020 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_021'' as ColumnName, PT_021 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_022'' as ColumnName, PT_022 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_023'' as ColumnName, PT_023 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_024'' as ColumnName, PT_024 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_025'' as ColumnName, PT_025 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_026'' as ColumnName, PT_026 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_027'' as ColumnName, PT_027 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_028'' as ColumnName, PT_028 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_029'' as ColumnName, PT_029 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_030'' as ColumnName, PT_030 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_031'' as ColumnName, PT_031 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_032'' as ColumnName, PT_032 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_033'' as ColumnName, PT_033 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_034'' as ColumnName, PT_034 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_035'' as ColumnName, PT_035 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_036'' as ColumnName, PT_036 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_037'' as ColumnName, PT_037 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_038'' as ColumnName, PT_038 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_039'' as ColumnName, PT_039 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_040'' as ColumnName, PT_040 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_041'' as ColumnName, PT_041 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_042'' as ColumnName, PT_042 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_043'' as ColumnName, PT_043 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_044'' as ColumnName, PT_044 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_045'' as ColumnName, PT_045 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_046'' as ColumnName, PT_046 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_047'' as ColumnName, PT_047 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_048'' as ColumnName, PT_048 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_049'' as ColumnName, PT_049 as Value
from  EPGP_PROJECT_TEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_TEXT_VALUES'' as TableName, ''PT_050'' as ColumnName, PT_050 as Value
from  EPGP_PROJECT_TEXT_VALUES
union

-- ****************************************************************************************************
-- EPGP_PROJECT_NTEXT_VALUES
-- ****************************************************************************************************
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_001'' as ColumnName, Convert(varchar(max), PN_001) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_002'' as ColumnName, Convert(varchar(max), PN_002) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_003'' as ColumnName, Convert(varchar(max), PN_003) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_004'' as ColumnName, Convert(varchar(max), PN_004) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_005'' as ColumnName, Convert(varchar(max), PN_005) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_006'' as ColumnName, Convert(varchar(max), PN_006) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_007'' as ColumnName, Convert(varchar(max), PN_007) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_008'' as ColumnName, Convert(varchar(max), PN_008) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_009'' as ColumnName, Convert(varchar(max), PN_009) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_010'' as ColumnName, Convert(varchar(max), PN_010) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_011'' as ColumnName, Convert(varchar(max), PN_011) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_012'' as ColumnName, Convert(varchar(max), PN_012) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_013'' as ColumnName, Convert(varchar(max), PN_013) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_014'' as ColumnName, Convert(varchar(max), PN_014) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_015'' as ColumnName, Convert(varchar(max), PN_015) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_016'' as ColumnName, Convert(varchar(max), PN_016) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_017'' as ColumnName, Convert(varchar(max), PN_017) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_018'' as ColumnName, Convert(varchar(max), PN_018) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_019'' as ColumnName, Convert(varchar(max), PN_019) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_020'' as ColumnName, Convert(varchar(max), PN_020) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_021'' as ColumnName, Convert(varchar(max), PN_021) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_022'' as ColumnName, Convert(varchar(max), PN_022) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_023'' as ColumnName, Convert(varchar(max), PN_023) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_024'' as ColumnName, Convert(varchar(max), PN_024) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_025'' as ColumnName, Convert(varchar(max), PN_025) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_026'' as ColumnName, Convert(varchar(max), PN_026) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_027'' as ColumnName, Convert(varchar(max), PN_027) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_028'' as ColumnName, Convert(varchar(max), PN_028) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_029'' as ColumnName, Convert(varchar(max), PN_029) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_030'' as ColumnName, Convert(varchar(max), PN_030) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_031'' as ColumnName, Convert(varchar(max), PN_031) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_032'' as ColumnName, Convert(varchar(max), PN_032) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_033'' as ColumnName, Convert(varchar(max), PN_033) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_034'' as ColumnName, Convert(varchar(max), PN_034) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_035'' as ColumnName, Convert(varchar(max), PN_035) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_036'' as ColumnName, Convert(varchar(max), PN_036) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_037'' as ColumnName, Convert(varchar(max), PN_037) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_038'' as ColumnName, Convert(varchar(max), PN_038) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_039'' as ColumnName, Convert(varchar(max), PN_039) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_040'' as ColumnName, Convert(varchar(max), PN_040) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_041'' as ColumnName, Convert(varchar(max), PN_041) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_042'' as ColumnName, Convert(varchar(max), PN_042) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_043'' as ColumnName, Convert(varchar(max), PN_043) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_044'' as ColumnName, Convert(varchar(max), PN_044) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_045'' as ColumnName, Convert(varchar(max), PN_045) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_046'' as ColumnName, Convert(varchar(max), PN_046) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_047'' as ColumnName, Convert(varchar(max), PN_047) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_048'' as ColumnName, Convert(varchar(max), PN_048) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_049'' as ColumnName, Convert(varchar(max), PN_049) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_NTEXT_VALUES'' as TableName, ''PN_050'' as ColumnName, Convert(varchar(max), PN_050) as Value
from  EPGP_PROJECT_NTEXT_VALUES
union

-- ****************************************************************************************************
-- EPGP_PROJECT_DEC_VALUES
-- ****************************************************************************************************
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_001'' as ColumnName, Convert(varchar(255), cast(PC_001 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_002'' as ColumnName, Convert(varchar(255), cast(PC_002 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_003'' as ColumnName, Convert(varchar(255), cast(PC_003 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_004'' as ColumnName, Convert(varchar(255), cast(PC_004 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_005'' as ColumnName, Convert(varchar(255), cast(PC_005 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_006'' as ColumnName, Convert(varchar(255), cast(PC_006 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_007'' as ColumnName, Convert(varchar(255), cast(PC_007 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_008'' as ColumnName, Convert(varchar(255), cast(PC_008 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_009'' as ColumnName, Convert(varchar(255), cast(PC_009 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_010'' as ColumnName, Convert(varchar(255), cast(PC_010 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_011'' as ColumnName, Convert(varchar(255), cast(PC_011 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_012'' as ColumnName, Convert(varchar(255), cast(PC_012 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_013'' as ColumnName, Convert(varchar(255), cast(PC_013 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_014'' as ColumnName, Convert(varchar(255), cast(PC_014 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_015'' as ColumnName, Convert(varchar(255), cast(PC_015 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_016'' as ColumnName, Convert(varchar(255), cast(PC_016 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_017'' as ColumnName, Convert(varchar(255), cast(PC_017 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_018'' as ColumnName, Convert(varchar(255), cast(PC_018 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_019'' as ColumnName, Convert(varchar(255), cast(PC_019 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_020'' as ColumnName, Convert(varchar(255), cast(PC_020 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_021'' as ColumnName, Convert(varchar(255), cast(PC_021 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_022'' as ColumnName, Convert(varchar(255), cast(PC_022 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_023'' as ColumnName, Convert(varchar(255), cast(PC_023 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_024'' as ColumnName, Convert(varchar(255), cast(PC_024 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_025'' as ColumnName, Convert(varchar(255), cast(PC_025 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_026'' as ColumnName, Convert(varchar(255), cast(PC_026 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_027'' as ColumnName, Convert(varchar(255), cast(PC_027 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_028'' as ColumnName, Convert(varchar(255), cast(PC_028 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_029'' as ColumnName, Convert(varchar(255), cast(PC_029 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_030'' as ColumnName, Convert(varchar(255), cast(PC_030 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_031'' as ColumnName, Convert(varchar(255), cast(PC_031 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_032'' as ColumnName, Convert(varchar(255), cast(PC_032 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_033'' as ColumnName, Convert(varchar(255), cast(PC_033 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_034'' as ColumnName, Convert(varchar(255), cast(PC_034 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_035'' as ColumnName, Convert(varchar(255), cast(PC_035 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_036'' as ColumnName, Convert(varchar(255), cast(PC_036 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_037'' as ColumnName, Convert(varchar(255), cast(PC_037 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_038'' as ColumnName, Convert(varchar(255), cast(PC_038 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_039'' as ColumnName, Convert(varchar(255), cast(PC_039 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_040'' as ColumnName, Convert(varchar(255), cast(PC_040 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_041'' as ColumnName, Convert(varchar(255), cast(PC_041 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_042'' as ColumnName, Convert(varchar(255), cast(PC_042 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_043'' as ColumnName, Convert(varchar(255), cast(PC_043 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_044'' as ColumnName, Convert(varchar(255), cast(PC_044 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_045'' as ColumnName, Convert(varchar(255), cast(PC_045 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_046'' as ColumnName, Convert(varchar(255), cast(PC_046 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_047'' as ColumnName, Convert(varchar(255), cast(PC_047 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_048'' as ColumnName, Convert(varchar(255), cast(PC_048 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_049'' as ColumnName, Convert(varchar(255), cast(PC_049 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DEC_VALUES'' as TableName, ''PC_050'' as ColumnName, Convert(varchar(255), cast(PC_050 as decimal(18,2))) as Value
from  EPGP_PROJECT_DEC_VALUES
union

-- ****************************************************************************************************
-- EPGP_PROJECT_DATE_VALUES
-- ****************************************************************************************************
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_001'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_001,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_002'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_002,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_003'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_003,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_004'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_004,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_005'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_005,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_006'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_006,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_007'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_007,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_008'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_008,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_009'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_009,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_010'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_010,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_011'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_011,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_012'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_012,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_013'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_013,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_014'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_014,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_015'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_015,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_016'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_016,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_017'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_017,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_018'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_018,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_019'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_019,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_020'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_020,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_021'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_021,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_022'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_022,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_023'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_023,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_024'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_024,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_025'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_025,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_026'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_026,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_027'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_027,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_028'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_028,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_029'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_029,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_030'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_030,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_031'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_031,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_032'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_032,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_033'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_033,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_034'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_034,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_035'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_035,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_036'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_036,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_037'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_037,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_038'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_038,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_039'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_039,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_040'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_040,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_041'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_041,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_042'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_042,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_043'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_043,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_044'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_044,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_045'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_045,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_046'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_046,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_047'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_047,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_048'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_048,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_049'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_049,126)) as Value
from  EPGP_PROJECT_DATE_VALUES
union
select Project_ID as ProjectID, ''EPGP_PROJECT_DATE_VALUES'' as TableName, ''PD_050'' as ColumnName, Convert(varchar(255), CONVERT(char(10), PD_050,126)) as Value
from  EPGP_PROJECT_DATE_VALUES

GO
')