declare @createoralter varchar(10)
------------------------------View: vwGetProjectStatus---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'vwGetProjectStatus')
begin
    Print 'Creating View vwGetProjectStatus'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View vwGetProjectStatus'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW dbo.vwGetProjectStatus
AS
SELECT     projectguid, projectname, ''<a href="'' + weburl + ''" target="_blank">'' + weburl + ''</a>'' AS weburl, 
                      CASE status WHEN 0 THEN ''Unpublished'' WHEN 1 THEN ''Publishing ('' + CONVERT(varchar(3), percentcomplete) 
                      + ''%)'' WHEN 2 THEN ''Publish Successful'' WHEN 3 THEN ''Published With Errors (Check Log)'' WHEN 4 THEN ''Publish Failed Check Log'' END AS Status,
                       laststatusdate, logtext
FROM         dbo.PUBLISHERCHECK
WHERE     (projectname IS NOT NULL)
')
 
