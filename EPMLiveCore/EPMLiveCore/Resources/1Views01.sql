declare @createoralter varchar(10)
------------------------------View: vwMeta---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwMeta')
begin
    Print 'Creating View vwMeta'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwMeta'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwMeta
AS
SELECT     dbo.TSTIMESHEET.USERNAME AS Username, dbo.TSTIMESHEET.RESOURCENAME AS [Resource Name], dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSITEM.TS_ITEM_UID AS [Item UID], 
                      dbo.TSITEM.TITLE AS [Item Name], dbo.TSITEM.PROJECT AS Project, COALESCE (dbo.TSMETA.ListName + ''_'' + dbo.TSMETA.ColumnName, ''TempColumn'') 
                      AS ColumnName, dbo.TSMETA.DisplayName, dbo.TSMETA.ColumnValue, dbo.TSITEM.ITEM_TYPE AS [Item Type], dbo.TSITEM.TS_UID AS [Timesheet UID], 
                      dbo.TSPERIOD.PERIOD_ID AS [Period Id], dbo.TSPERIOD.SITE_ID, dbo.TSITEM.LIST AS List, dbo.TSITEMHOURS.TS_ITEM_DATE AS Date, 
                      dbo.TSITEMHOURS.TS_ITEM_HOURS AS Hours, dbo.TSITEMHOURS.TS_ITEM_TYPE_ID AS [Type Id], dbo.TSTYPE.TSTYPE_NAME AS [Type Name], 
                      dbo.TSPERIOD.PERIOD_START AS [Period Start], dbo.TSPERIOD.PERIOD_END AS [Period End], 
                      CASE dbo.TSTIMESHEET.SUBMITTED WHEN 0 THEN ''No'' WHEN 1 THEN ''Yes'' END AS Submitted, 
                      CASE dbo.TSTIMESHEET.APPROVAL_STATUS WHEN 0 THEN ''Pending'' WHEN 1 THEN ''Approved'' WHEN 2 THEN ''Rejected'' END AS [Approval Status],                       
                      CASE dbo.TSITEM.APPROVAL_STATUS WHEN 0 THEN ''Pending'' WHEN 1 THEN ''Approved'' WHEN 2 THEN ''Rejected'' END AS [PM Approval Status],                       
                      CONVERT(varchar(8000), COALESCE (dbo.TSTIMESHEET.APPROVAL_NOTES, '''')) AS [Approval Notes], dbo.TSTIMESHEET.LASTMODIFIEDBYN, 
                      CONVERT(varchar(MAX), dbo.TSNOTES.TS_ITEM_NOTES) AS TS_ITEM_NOTES
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID INNER JOIN
                      dbo.TSPERIOD ON dbo.TSTIMESHEET.PERIOD_ID = dbo.TSPERIOD.PERIOD_ID AND dbo.TSTIMESHEET.SITE_UID = dbo.TSPERIOD.SITE_ID INNER JOIN
                      dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID LEFT OUTER JOIN
                      dbo.TSNOTES ON dbo.TSITEM.TS_ITEM_UID = dbo.TSNOTES.TS_ITEM_UID AND 
                      dbo.TSITEMHOURS.TS_ITEM_DATE = dbo.TSNOTES.TS_ITEM_DATE LEFT OUTER JOIN
                      dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID LEFT OUTER JOIN
                      dbo.TSTYPE ON dbo.TSTIMESHEET.SITE_UID = dbo.TSTYPE.SITE_UID AND dbo.TSITEMHOURS.TS_ITEM_TYPE_ID = dbo.TSTYPE.TSTYPE_ID
UNION
SELECT     dbo.TSTIMESHEET.USERNAME AS Username, dbo.TSTIMESHEET.RESOURCENAME AS [Resource Name], dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSITEM.TS_ITEM_UID AS [Item UID], 
                      dbo.TSITEM.TITLE AS [Item Name], dbo.TSITEM.PROJECT AS Project, COALESCE (dbo.TSMETA.ColumnName, ''TempColumn'') AS ColumnName, 
                      dbo.TSMETA.DisplayName, dbo.TSMETA.ColumnValue, dbo.TSITEM.ITEM_TYPE AS [Item Type], dbo.TSITEM.TS_UID AS [Timesheet UID], 
                      dbo.TSPERIOD.PERIOD_ID AS [Period Id], dbo.TSPERIOD.SITE_ID, dbo.TSITEM.LIST AS List, dbo.TSITEMHOURS.TS_ITEM_DATE AS Date, 
                      dbo.TSITEMHOURS.TS_ITEM_HOURS AS Hours, dbo.TSITEMHOURS.TS_ITEM_TYPE_ID AS [Type Id], dbo.TSTYPE.TSTYPE_NAME AS [Type Name], 
                      dbo.TSPERIOD.PERIOD_START AS [Period Start], dbo.TSPERIOD.PERIOD_END AS [Period End], 
                      CASE dbo.TSTIMESHEET.SUBMITTED WHEN 0 THEN ''No'' WHEN 1 THEN ''Yes'' END AS Submitted, 
                      CASE dbo.TSTIMESHEET.APPROVAL_STATUS WHEN 0 THEN ''Pending'' WHEN 1 THEN ''Approved'' WHEN 2 THEN ''Rejected'' END AS [Approval Status],                       
                      CASE dbo.TSITEM.APPROVAL_STATUS WHEN 0 THEN ''Pending'' WHEN 1 THEN ''Approved'' WHEN 2 THEN ''Rejected'' END AS [PM Approval Status],                       
                      CONVERT(varchar(8000), COALESCE (dbo.TSTIMESHEET.APPROVAL_NOTES, '''')) AS [Approval Notes], dbo.TSTIMESHEET.LASTMODIFIEDBYN, 
                      CONVERT(varchar(MAX), dbo.TSNOTES.TS_ITEM_NOTES) AS Expr1
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID INNER JOIN
                      dbo.TSPERIOD ON dbo.TSTIMESHEET.PERIOD_ID = dbo.TSPERIOD.PERIOD_ID AND dbo.TSTIMESHEET.SITE_UID = dbo.TSPERIOD.SITE_ID INNER JOIN
                      dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID LEFT OUTER JOIN
                      dbo.TSNOTES ON dbo.TSITEMHOURS.TS_ITEM_DATE = dbo.TSNOTES.TS_ITEM_DATE AND 
                      dbo.TSITEM.TS_ITEM_UID = dbo.TSNOTES.TS_ITEM_UID LEFT OUTER JOIN
                      dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID AND dbo.TSITEM.LIST = dbo.TSMETA.ListName LEFT OUTER JOIN
                      dbo.TSTYPE ON dbo.TSTIMESHEET.SITE_UID = dbo.TSTYPE.SITE_UID AND dbo.TSITEMHOURS.TS_ITEM_TYPE_ID = dbo.TSTYPE.TSTYPE_ID
UNION
SELECT     TSTIMESHEET_1.USERNAME, TSTIMESHEET_1.RESOURCENAME AS [Resource Name], TSITEM_1.LIST_UID, TSITEM_1.ITEM_ID, TSITEM_1.TS_ITEM_UID, TSITEM_1.TITLE, TSITEM_1.PROJECT, 
                      ''Resource_'' + dbo.TSRESMETA.ColumnName AS listcolumnname, dbo.TSRESMETA.DisplayName, dbo.TSRESMETA.ColumnValue, TSITEM_1.ITEM_TYPE, 
                      TSITEM_1.TS_UID, TSTIMESHEET_1.PERIOD_ID, TSTIMESHEET_1.SITE_UID, TSITEM_1.LIST, TSITEMHOURS_1.TS_ITEM_DATE, 
                      TSITEMHOURS_1.TS_ITEM_HOURS, TSITEMHOURS_1.TS_ITEM_TYPE_ID, TSTYPE_1.TSTYPE_NAME, TSPERIOD_1.PERIOD_START AS Start, 
                      TSPERIOD_1.PERIOD_END AS [End], CASE TSTIMESHEET_1.SUBMITTED WHEN 0 THEN ''No'' WHEN 1 THEN ''Yes'' END AS Submitted, 
                      CASE TSTIMESHEET_1.APPROVAL_STATUS WHEN 0 THEN ''Pending'' WHEN 1 THEN ''Approved'' WHEN 2 THEN ''Rejected'' END AS [Approval Status],                       
                      CASE TSITEM_1.APPROVAL_STATUS WHEN 0 THEN ''Pending'' WHEN 1 THEN ''Approved'' WHEN 2 THEN ''Rejected'' END AS [PM Approval Status],                       
                      CONVERT(varchar(8000), COALESCE (TSTIMESHEET_1.APPROVAL_NOTES, '''')) AS [Approval Notes], TSTIMESHEET_1.LASTMODIFIEDBYN, CONVERT(varchar(MAX), 
                      dbo.TSNOTES.TS_ITEM_NOTES) AS TS_ITEM_NOTES
FROM         dbo.TSTIMESHEET AS TSTIMESHEET_1 INNER JOIN
                      dbo.TSRESMETA ON TSTIMESHEET_1.TS_UID = dbo.TSRESMETA.TS_UID INNER JOIN
                      dbo.TSITEM AS TSITEM_1 ON TSTIMESHEET_1.TS_UID = TSITEM_1.TS_UID INNER JOIN
                      dbo.TSITEMHOURS AS TSITEMHOURS_1 ON TSITEM_1.TS_ITEM_UID = TSITEMHOURS_1.TS_ITEM_UID INNER JOIN
                      dbo.TSPERIOD AS TSPERIOD_1 ON TSTIMESHEET_1.PERIOD_ID = TSPERIOD_1.PERIOD_ID AND 
                      TSTIMESHEET_1.SITE_UID = TSPERIOD_1.SITE_ID LEFT OUTER JOIN
                      dbo.TSNOTES ON TSITEMHOURS_1.TS_ITEM_DATE = dbo.TSNOTES.TS_ITEM_DATE AND TSITEM_1.TS_ITEM_UID = dbo.TSNOTES.TS_ITEM_UID LEFT OUTER JOIN
                      dbo.TSTYPE AS TSTYPE_1 ON TSTIMESHEET_1.SITE_UID = TSTYPE_1.SITE_UID AND TSITEMHOURS_1.TS_ITEM_TYPE_ID = TSTYPE_1.TSTYPE_ID
')
 
------------------------------View: vwNotifications---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwNotifications')
begin
    Print 'Creating View vwNotifications'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwNotifications'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[vwNotifications]
AS
SELECT     TOP (100) PERCENT dbo.NOTIFICATIONS.ID, dbo.NOTIFICATIONS.Title, dbo.NOTIFICATIONS.Message, dbo.NOTIFICATIONS.Type, dbo.NOTIFICATIONS.CreatedBy, 
                      dbo.NOTIFICATIONS.CreatedAt, dbo.NOTIFICATIONS.SiteCreationDate AS SiteCreationDateTime, DATEADD(DAY, DATEDIFF(DAY, 0, 
                      dbo.NOTIFICATIONS.SiteCreationDate), 0) AS SiteCreationDate, dbo.NOTIFICATIONS.SiteID, dbo.NOTIFICATIONS.WebID, dbo.NOTIFICATIONS.ListID, 
                      dbo.NOTIFICATIONS.ItemID, dbo.NOTIFICATIONS.Emailed, dbo.PERSONALIZATIONS.Value AS Flags, CAST(COALESCE (SUBSTRING(dbo.PERSONALIZATIONS.Value, 1, 
                      1), 0) AS BIT) AS UserEmailed, CAST(COALESCE (SUBSTRING(dbo.PERSONALIZATIONS.Value, 2, 1), 0) AS BIT) AS NotificationRead, 
                      dbo.PERSONALIZATIONS.Id AS PersonalizationID, dbo.PERSONALIZATIONS.SiteId AS PersonalizationSiteID, dbo.PERSONALIZATIONS.UserId AS UserName
FROM         dbo.NOTIFICATIONS LEFT OUTER JOIN
                      dbo.PERSONALIZATIONS ON dbo.NOTIFICATIONS.ID = dbo.PERSONALIZATIONS.FK
WHERE     (dbo.PERSONALIZATIONS.[Key] = N''Notifications'') OR
                      (dbo.PERSONALIZATIONS.[Key] IS NULL)
ORDER BY dbo.NOTIFICATIONS.Type DESC, dbo.NOTIFICATIONS.CreatedAt

')
 
------------------------------View: vwNReadyEmails---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwNReadyEmails')
begin
    Print 'Creating View vwNReadyEmails'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwNReadyEmails'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwNReadyEmails
AS
SELECT     dbo.PERSONALIZATIONS.UserId, dbo.PERSONALIZATIONS.SiteId, dbo.PERSONALIZATIONS.WebId, dbo.PERSONALIZATIONS.ListId, dbo.PERSONALIZATIONS.ItemId, 
                      dbo.NOTIFICATIONS.Title, dbo.NOTIFICATIONS.Message, dbo.NOTIFICATIONS.SiteCreationDate, dbo.NOTIFICATIONS.CreatedBy, dbo.NOTIFICATIONS.CreatedAt, 
                      dbo.PERSONALIZATIONS.FK
FROM         dbo.NOTIFICATIONS INNER JOIN
                      dbo.PERSONALIZATIONS ON dbo.NOTIFICATIONS.ID = dbo.PERSONALIZATIONS.FK
WHERE     (dbo.NOTIFICATIONS.Emailed = 0) AND (SUBSTRING(dbo.PERSONALIZATIONS.Value, 1, 1) = 0) AND (dbo.PERSONALIZATIONS.[Key] = ''Notifications'')
')
 
------------------------------View: vwQueueItems---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwQueueItems')
begin
    Print 'Creating View vwQueueItems'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwQueueItems'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwQueueItems
AS
SELECT     TOP (100) PERCENT dbo.TIMERJOBS.timerjobuid, dbo.TIMERJOBS.jobname, dbo.TIMERJOBS.siteguid, dbo.TIMERJOBS.webguid, 
                      dbo.TIMERJOBS.listguid, dbo.TIMERJOBS.jobtype, dbo.QUEUE.percentComplete, dbo.QUEUE.status, dbo.QUEUE.dtfinished, DATEDIFF(s, 
                      dbo.QUEUE.dtstarted, dbo.QUEUE.dtfinished) AS runtime, dbo.EPMLIVE_LOG.result
FROM         dbo.TIMERJOBS LEFT OUTER JOIN
                      dbo.QUEUE ON dbo.TIMERJOBS.timerjobuid = dbo.QUEUE.timerjobuid LEFT OUTER JOIN
                      dbo.EPMLIVE_LOG ON dbo.TIMERJOBS.timerjobuid = dbo.EPMLIVE_LOG.timerjobuid
WHERE     (DATEADD(d, 1, dbo.QUEUE.dtfinished) >= GETDATE()) OR
                      (dbo.QUEUE.status = 0) OR
                      (dbo.QUEUE.status = 1)
ORDER BY dbo.QUEUE.status
')
 
------------------------------View: vwQueueSiteStats---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwQueueSiteStats')
begin
    Print 'Creating View vwQueueSiteStats'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwQueueSiteStats'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwQueueSiteStats
AS
SELECT     AVG(DATEDIFF(s, dbo.QUEUE.dtstarted, dbo.QUEUE.dtfinished)) AS avgruntime, AVG(DATEDIFF(s, dbo.QUEUE.dtcreated, dbo.QUEUE.dtstarted)) 
                      AS avgqueuetime, MAX(DATEDIFF(s, dbo.QUEUE.dtstarted, dbo.QUEUE.dtfinished)) AS maxruntime, MAX(DATEDIFF(s, dbo.QUEUE.dtcreated, 
                      dbo.QUEUE.dtstarted)) AS maxqueuetime, COUNT(dbo.QUEUE.queueuid) AS jobcount, dbo.TIMERJOBS.siteguid
FROM         dbo.QUEUE INNER JOIN
                      dbo.TIMERJOBS ON dbo.QUEUE.timerjobuid = dbo.TIMERJOBS.timerjobuid
WHERE     (DATEADD(d, 1, dbo.QUEUE.dtfinished) >= GETDATE())
GROUP BY dbo.TIMERJOBS.siteguid
')
 
------------------------------View: vwQueueStats---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwQueueStats')
begin
    Print 'Creating View vwQueueStats'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwQueueStats'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwQueueStats
AS
SELECT     AVG(DATEDIFF(s, dbo.QUEUE.dtstarted, dbo.QUEUE.dtfinished)) AS avgruntime, AVG(DATEDIFF(s, dbo.QUEUE.dtcreated, dbo.QUEUE.dtstarted)) 
                      AS avgqueuetime, MAX(DATEDIFF(s, dbo.QUEUE.dtstarted, dbo.QUEUE.dtfinished)) AS maxruntime, MAX(DATEDIFF(s, dbo.QUEUE.dtcreated, 
                      dbo.QUEUE.dtstarted)) AS maxqueuetime, COUNT(dbo.QUEUE.queueuid) AS jobcount
FROM         dbo.QUEUE RIGHT OUTER JOIN
                      dbo.TIMERJOBS ON dbo.QUEUE.timerjobuid = dbo.TIMERJOBS.timerjobuid
WHERE     (DATEADD(d, 1, dbo.QUEUE.dtfinished) >= GETDATE()) OR
                      (dbo.QUEUE.status = 0) OR
                      (dbo.QUEUE.status = 1)
')
 
------------------------------View: vwQueueTimer---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwQueueTimer')
begin
    Print 'Creating View vwQueueTimer'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwQueueTimer'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwQueueTimer
AS
SELECT     dbo.QUEUE.queueuid, dbo.QUEUE.percentComplete, dbo.QUEUE.status, dbo.QUEUE.dtstarted, dbo.QUEUE.dtfinished, dbo.QUEUE.dtcreated, 
                      dbo.TIMERJOBS.timerjobuid, dbo.TIMERJOBS.jobname, dbo.TIMERJOBS.siteguid, dbo.TIMERJOBS.webguid, dbo.TIMERJOBS.listguid, dbo.TIMERJOBS.jobtype, 
                      dbo.TIMERJOBS.enabled, dbo.TIMERJOBS.runtime, dbo.TIMERJOBS.scheduletype, dbo.TIMERJOBS.days, dbo.TIMERJOBS.jobdata, dbo.TIMERJOBS.lastqueuecheck, 
                      dbo.TIMERJOBS.parentjobuid, dbo.QUEUE.userid, dbo.TIMERJOBTYPES.NetAssembly, dbo.TIMERJOBTYPES.NetClass, dbo.TIMERJOBTYPES.Title, 
                      dbo.TIMERJOBS.[key], dbo.TIMERJOBS.itemid, dbo.TIMERJOBTYPES.Priority
FROM         dbo.QUEUE INNER JOIN
                      dbo.TIMERJOBS ON dbo.QUEUE.timerjobuid = dbo.TIMERJOBS.timerjobuid LEFT OUTER JOIN
                      dbo.TIMERJOBTYPES ON dbo.TIMERJOBS.jobtype = dbo.TIMERJOBTYPES.JOBTYPE_ID
')
 
------------------------------View: vwQueueTimerLog---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwQueueTimerLog')
begin
    Print 'Creating View vwQueueTimerLog'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwQueueTimerLog'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwQueueTimerLog
AS
SELECT     dbo.TIMERJOBS.jobname, dbo.TIMERJOBS.siteguid, dbo.TIMERJOBS.webguid, dbo.TIMERJOBS.listguid, dbo.TIMERJOBS.jobtype, dbo.TIMERJOBS.enabled, 
                      dbo.TIMERJOBS.runtime, dbo.TIMERJOBS.scheduletype, dbo.TIMERJOBS.days, dbo.QUEUE.percentComplete, dbo.QUEUE.status, dbo.QUEUE.dtcreated, 
                      dbo.QUEUE.dtstarted, dbo.QUEUE.dtfinished, dbo.EPMLIVE_LOG.result, dbo.EPMLIVE_LOG.resulttext, dbo.EPMLIVE_LOG.dtlogged, dbo.TIMERJOBS.timerjobuid, 
                      dbo.TIMERJOBS.jobdata, dbo.TIMERJOBS.lastqueuecheck, dbo.TIMERJOBS.parentjobuid, dbo.TIMERJOBS.itemid, dbo.TIMERJOBS.[key], dbo.QUEUE.userid
FROM         dbo.TIMERJOBS LEFT OUTER JOIN
                      dbo.EPMLIVE_LOG ON dbo.TIMERJOBS.timerjobuid = dbo.EPMLIVE_LOG.timerjobuid LEFT OUTER JOIN
                      dbo.QUEUE ON dbo.TIMERJOBS.timerjobuid = dbo.QUEUE.timerjobuid
')
 
------------------------------View: vwResMeta---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwResMeta')
begin
    Print 'Creating View vwResMeta'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwResMeta'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[vwResMeta]
AS
SELECT     dbo.TSRESMETA.Username, resourcename as [Resource Name], dbo.TSRESMETA.ColumnName, dbo.TSRESMETA.DisplayName, dbo.TSRESMETA.ColumnValue, 
                      dbo.TSRESMETA.TS_UID, dbo.TSITEM.TS_ITEM_UID, dbo.TSITEM.PROJECT, dbo.TSITEM.TITLE
FROM         dbo.TSTIMESHEET INNER JOIN
                      dbo.TSRESMETA ON dbo.TSTIMESHEET.TS_UID = dbo.TSRESMETA.TS_UID INNER JOIN
                      dbo.TSITEM ON dbo.TSTIMESHEET.TS_UID = dbo.TSITEM.TS_UID
')
 
------------------------------View: vwTSApprovalNotes---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSApprovalNotes')
begin
    Print 'Creating View vwTSApprovalNotes'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSApprovalNotes'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSApprovalNotes
AS
SELECT     dbo.TSPERIOD.PERIOD_START, dbo.TSPERIOD.PERIOD_END, dbo.TSTIMESHEET.USERNAME, dbo.TSTIMESHEET.APPROVAL_NOTES, 
                      dbo.TSTIMESHEET.TS_UID
FROM         dbo.TSPERIOD INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSPERIOD.PERIOD_ID = dbo.TSTIMESHEET.PERIOD_ID AND dbo.TSPERIOD.SITE_ID = dbo.TSTIMESHEET.SITE_UID
')
 
------------------------------View: vwTSHoursByTask---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSHoursByTask')
begin
    Print 'Creating View vwTSHoursByTask'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSHoursByTask'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSHoursByTask
AS
SELECT     TOP (100) PERCENT dbo.TSITEMHOURS.TS_ITEM_HOURS AS Hours, dbo.TSITEMHOURS.TS_ITEM_DATE, dbo.TSITEM.TS_UID, 
                      dbo.TSTIMESHEET.PERIOD_ID, dbo.TSTIMESHEET.SITE_UID, dbo.TSITEM.TS_ITEM_UID, dbo.TSITEMHOURS.TS_ITEM_TYPE_ID, 
                      dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSTIMESHEET.SUBMITTED, dbo.TSTIMESHEET.USERNAME
FROM         dbo.TSITEMHOURS INNER JOIN
                      dbo.TSITEM ON dbo.TSITEMHOURS.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
ORDER BY dbo.TSITEM.PROJECT
')
 
------------------------------View: vwTSItemHours---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSItemHours')
begin
    Print 'Creating View vwTSItemHours'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSItemHours'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSItemHours
AS
SELECT     dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, 
                      SUM(CASE WHEN tstimesheet.approval_status = 1 THEN dbo.TSITEMHOURS.TS_ITEM_HOURS ELSE 0 END) AS TotalHours, 
                      SUM(CASE WHEN tstimesheet.submitted = 1 THEN dbo.TSITEMHOURS.TS_ITEM_HOURS ELSE 0 END) AS SubmittedHours
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
GROUP BY dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID
')
 
------------------------------View: vwTSItemHoursByMyTS---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSItemHoursByMyTS')
begin
    Print 'Creating View vwTSItemHoursByMyTS'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSItemHoursByMyTS'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSItemHoursByMyTS
AS
SELECT     dbo.TSTIMESHEET.TS_UID, dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, SUM(dbo.TSITEMHOURS.TS_ITEM_HOURS) 
                      AS TotalHours
FROM         dbo.TSITEMHOURS INNER JOIN
                      dbo.TSITEM ON dbo.TSITEMHOURS.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
GROUP BY dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSTIMESHEET.TS_UID
')
 
------------------------------View: vwTSItemHoursByTS---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSItemHoursByTS')
begin
    Print 'Creating View vwTSItemHoursByTS'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSItemHoursByTS'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSItemHoursByTS
AS
SELECT     TOP (100) PERCENT dbo.TSITEM.TS_UID, dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.vwTSItemHours.TotalHours, 
                      dbo.vwTSItemHours.SubmittedHours
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID INNER JOIN
                      dbo.vwTSItemHours ON dbo.TSITEM.WEB_UID = dbo.vwTSItemHours.WEB_UID AND dbo.TSITEM.LIST_UID = dbo.vwTSItemHours.LIST_UID AND 
                      dbo.TSITEM.ITEM_ID = dbo.vwTSItemHours.ITEM_ID
ORDER BY dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID
')
 
------------------------------View: vwTSItemHoursDetails---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSItemHoursDetails')
begin
    Print 'Creating View vwTSItemHoursDetails'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSItemHoursDetails'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[vwTSItemHoursDetails]
AS
SELECT     dbo.TSITEMHOURS.TS_ITEM_UID, dbo.TSITEMHOURS.TS_ITEM_DATE, dbo.TSITEMHOURS.TS_ITEM_HOURS, 
                      dbo.TSITEMHOURS.TS_ITEM_TYPE_ID, dbo.TSITEM.TS_UID, dbo.TSTIMESHEET.USERNAME, dbo.TSNOTES.TS_ITEM_NOTES, dbo.TSITEM.WEB_UID, 
                      dbo.TSITEM.LIST_UID, dbo.TSITEM.LIST, dbo.TSITEM.ITEM_ID
FROM         dbo.TSITEMHOURS INNER JOIN
                      dbo.TSITEM ON dbo.TSITEMHOURS.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID LEFT OUTER JOIN
                      dbo.TSNOTES ON dbo.TSITEM.TS_ITEM_UID = dbo.TSNOTES.TS_ITEM_UID AND dbo.TSITEMHOURS.TS_ITEM_DATE = dbo.TSNOTES.TS_ITEM_DATE
')
 
------------------------------View: vwTSItemMeta---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSItemMeta')
begin
    Print 'Creating View vwTSItemMeta'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSItemMeta'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSItemMeta
AS
SELECT     dbo.TSITEM.TS_ITEM_UID, dbo.TSMETA.ColumnName, dbo.TSMETA.ColumnValue, dbo.TSTIMESHEET.PERIOD_ID, dbo.TSTIMESHEET.SITE_UID
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID AND dbo.TSITEM.LIST = dbo.TSMETA.ListName INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
')
 
------------------------------View: vwTSNotes---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSNotes')
begin
    Print 'Creating View vwTSNotes'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSNotes'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSNotes
AS
SELECT     dbo.TSNOTES.TS_ITEM_UID, dbo.TSNOTES.TS_ITEM_NOTES, dbo.TSNOTES.TS_ITEM_DATE, dbo.TSTIMESHEET.PERIOD_ID, 
                      dbo.TSTIMESHEET.SITE_UID
FROM         dbo.TSNOTES INNER JOIN
                      dbo.TSITEM ON dbo.TSNOTES.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
')
 
------------------------------View: vwTSQueue---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSQueue')
begin
    Print 'Creating View vwTSQueue'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSQueue'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSQueue
AS
SELECT     dbo.TSTIMESHEET.USERNAME, dbo.TSTIMESHEET.RESOURCENAME, dbo.TSTIMESHEET.PERIOD_ID, dbo.TSTIMESHEET.LOCKED, dbo.TSTIMESHEET.SITE_UID, 
                      dbo.TSTIMESHEET.SUBMITTED, dbo.TSTIMESHEET.APPROVAL_STATUS, dbo.TSTIMESHEET.TSUSER_UID, dbo.TSTIMESHEET.APPROVAL_DATE, 
                      dbo.TIMERJOBTYPES.NetAssembly, dbo.TIMERJOBTYPES.NetClass, dbo.TSQUEUE.*
FROM         dbo.TSQUEUE INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSQUEUE.TS_UID = dbo.TSTIMESHEET.TS_UID INNER JOIN
                      dbo.TIMERJOBTYPES ON dbo.TSQUEUE.JOBTYPE_ID = dbo.TIMERJOBTYPES.JOBTYPE_ID
')
 
------------------------------View: vwTSTasks---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSTasks')
begin
    Print 'Creating View vwTSTasks'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSTasks'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSTasks
AS
SELECT     TOP (100) PERCENT dbo.TSTIMESHEET.PERIOD_ID, dbo.TSTIMESHEET.SITE_UID, dbo.TSITEM.TITLE, CASE COALESCE (dbo.TSITEM.PROJECT, 
                      ''No Project'') WHEN '''' THEN ''No Project'' ELSE COALESCE (dbo.TSITEM.PROJECT, ''No Project'') END AS Project, dbo.TSTIMESHEET.TS_UID, 
                      dbo.TSITEM.TS_ITEM_UID, dbo.TSITEM.APPROVAL_STATUS, dbo.TSTIMESHEET.RESOURCENAME, dbo.TSTIMESHEET.USERNAME, 
                      dbo.TSITEM.ITEM_ID, dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID, dbo.TSTIMESHEET.SUBMITTED, dbo.TSITEM.ITEM_TYPE, 
                      COALESCE (SUM(dbo.TSITEMHOURS.TS_ITEM_HOURS), 0) AS TotalHours
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID LEFT OUTER JOIN
                      dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID
GROUP BY dbo.TSTIMESHEET.PERIOD_ID, dbo.TSTIMESHEET.SITE_UID, dbo.TSITEM.TITLE, dbo.TSTIMESHEET.TS_UID, dbo.TSITEM.TS_ITEM_UID, 
                      dbo.TSITEM.APPROVAL_STATUS, dbo.TSTIMESHEET.RESOURCENAME, dbo.TSTIMESHEET.USERNAME, dbo.TSITEM.ITEM_ID, dbo.TSITEM.WEB_UID, 
                      dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_TYPE, dbo.TSITEM.PROJECT, dbo.TSTIMESHEET.SUBMITTED
ORDER BY dbo.TSITEM.PROJECT
')
 
------------------------------View: vwTSTimesheetResourceMeta---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSTimesheetResourceMeta')
begin
    Print 'Creating View vwTSTimesheetResourceMeta'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSTimesheetResourceMeta'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[vwTSTimesheetResourceMeta]
AS
SELECT     dbo.TSTIMESHEET.USERNAME, dbo.TSTIMESHEET.RESOURCENAME AS [Resource Name], dbo.TSTIMESHEET.PERIOD_ID AS [Period Id], 
                      dbo.TSTIMESHEET.SUBMITTED, dbo.TSTIMESHEET.APPROVAL_STATUS AS [Approval Status], CONVERT(varchar(8000), 
                      COALESCE (dbo.TSTIMESHEET.APPROVAL_NOTES, '''')) AS [Approval Notes], COALESCE (dbo.TSRESMETA.ColumnName, ''TempColumn'') 
                      AS ColumnName, dbo.TSRESMETA.ColumnValue, dbo.TSPERIOD.PERIOD_START AS [Period Start], dbo.TSPERIOD.PERIOD_END AS [Period End], 
                      dbo.TSTIMESHEET.TS_UID AS [Timesheet UID], dbo.TSTIMESHEET.SITE_UID AS SITE_ID, SUM(dbo.TSITEMHOURS.TS_ITEM_HOURS) AS Hours
FROM         dbo.TSTIMESHEET INNER JOIN
                      dbo.TSPERIOD ON dbo.TSTIMESHEET.PERIOD_ID = dbo.TSPERIOD.PERIOD_ID AND 
                      dbo.TSTIMESHEET.SITE_UID = dbo.TSPERIOD.SITE_ID INNER JOIN
                      dbo.TSITEM ON dbo.TSTIMESHEET.TS_UID = dbo.TSITEM.TS_UID INNER JOIN
                      dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID LEFT OUTER JOIN
                      dbo.TSRESMETA ON dbo.TSTIMESHEET.TS_UID = dbo.TSRESMETA.TS_UID
GROUP BY dbo.TSTIMESHEET.USERNAME, dbo.TSTIMESHEET.RESOURCENAME, dbo.TSTIMESHEET.PERIOD_ID, dbo.TSTIMESHEET.APPROVAL_STATUS, 
                      CONVERT(varchar(8000), COALESCE (dbo.TSTIMESHEET.APPROVAL_NOTES, '''')), COALESCE (dbo.TSRESMETA.ColumnName, ''TempColumn''), 
                      dbo.TSRESMETA.ColumnValue, dbo.TSPERIOD.PERIOD_START, dbo.TSPERIOD.PERIOD_END, dbo.TSTIMESHEET.TS_UID, 
                      dbo.TSTIMESHEET.SITE_UID, dbo.TSTIMESHEET.SUBMITTED
')
 
------------------------------View: vwTSTimesheetTotals---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSTimesheetTotals')
begin
    Print 'Creating View vwTSTimesheetTotals'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSTimesheetTotals'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[vwTSTimesheetTotals]
AS
SELECT     SUM(dbo.TSITEMHOURS.TS_ITEM_HOURS) AS Hours, dbo.TSITEM.TS_UID, dbo.TSITEMHOURS.TS_ITEM_DATE, dbo.TSTIMESHEET.PERIOD_ID, 
                      dbo.TSTIMESHEET.SITE_UID
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
GROUP BY dbo.TSITEM.TS_UID, dbo.TSITEMHOURS.TS_ITEM_DATE, dbo.TSTIMESHEET.PERIOD_ID, dbo.TSTIMESHEET.SITE_UID
')
 
------------------------------View: vwTSTimesheetWQueue---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSTimesheetWQueue')
begin
    Print 'Creating View vwTSTimesheetWQueue'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSTimesheetWQueue'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSTimesheetWQueue
AS
SELECT     dbo.TSTIMESHEET.TS_UID, dbo.TSTIMESHEET.USERNAME, dbo.TSTIMESHEET.RESOURCENAME, dbo.TSTIMESHEET.PERIOD_ID, dbo.TSTIMESHEET.LOCKED, 
                      dbo.TSTIMESHEET.SITE_UID, dbo.TSTIMESHEET.SUBMITTED, dbo.TSTIMESHEET.APPROVAL_STATUS, dbo.TSTIMESHEET.APPROVAL_NOTES, 
                      dbo.TSTIMESHEET.LASTMODIFIEDBYU, dbo.TSTIMESHEET.LASTMODIFIEDBYN, dbo.TSTIMESHEET.APPROVAL_DATE, dbo.TSTIMESHEET.TSUSER_UID, 
                      dbo.TSQUEUE.JOBTYPE_ID, dbo.TSQUEUE.STATUS AS jobstatus
FROM         dbo.TSTIMESHEET LEFT OUTER JOIN
                      dbo.TSQUEUE ON dbo.TSTIMESHEET.TS_UID = dbo.TSQUEUE.TS_UID
')
 
------------------------------View: vwTSTypes---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwTSTypes')
begin
    Print 'Creating View vwTSTypes'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwTSTypes'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwTSTypes
AS
SELECT     dbo.TSTYPE.TSTYPE_ID, dbo.TSTYPE.SITE_UID, dbo.TSTYPE.TSTYPE_NAME, COUNT(dbo.TSITEMHOURS.TS_ITEM_UID) AS TypeCount
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID RIGHT OUTER JOIN
                      dbo.TSTYPE ON dbo.TSTIMESHEET.SITE_UID = dbo.TSTYPE.SITE_UID AND dbo.TSITEMHOURS.TS_ITEM_TYPE_ID = dbo.TSTYPE.TSTYPE_ID
GROUP BY dbo.TSTYPE.TSTYPE_ID, dbo.TSTYPE.SITE_UID, dbo.TSTYPE.TSTYPE_NAME
')
 
