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
 
