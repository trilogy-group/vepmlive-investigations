declare @createoralter varchar(10)
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSgetTSHoursPM')
begin
    Print 'Creating Stored Procedure spTSgetTSHoursPM'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSgetTSHoursPM'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSgetTSHoursPM]

@username varchar(255),
@siteguid uniqueidentifier,
@period_id int

AS
BEGIN

SELECT     dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSITEMHOURS.TS_ITEM_DATE, dbo.TSITEMHOURS.TS_ITEM_HOURS, dbo.TSITEM.TS_ITEM_UID, 
                      COALESCE (dbo.TSTYPE.TSTYPE_ID, 0) AS TSTYPE_ID
FROM         dbo.TSITEMHOURS FULL OUTER JOIN
                      dbo.TSTYPE RIGHT OUTER JOIN
                      dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID ON dbo.TSTYPE.SITE_UID = dbo.TSTIMESHEET.SITE_UID ON 
                      dbo.TSITEMHOURS.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID AND dbo.TSITEMHOURS.TS_ITEM_TYPE_ID = dbo.TSTYPE.TSTYPE_ID
WHERE period_id=@period_id and tstimesheet.site_uid = @siteguid and username like @username AND TS_ITEM_TYPE_ID<>0
UNION
SELECT     dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSITEMHOURS.TS_ITEM_DATE, dbo.TSITEMHOURS.TS_ITEM_HOURS, 
                      dbo.TSITEM.TS_ITEM_UID, TSTYPE_ID=0
FROM         dbo.TSITEMHOURS FULL OUTER JOIN
                      dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID ON dbo.TSITEMHOURS.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID
WHERE period_id=@period_id and tstimesheet.site_uid = @siteguid and username like @username AND TS_ITEM_TYPE_ID=0


SELECT     dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSITEM.TS_ITEM_UID, dbo.TSNOTES.TS_ITEM_DATE, dbo.TSNOTES.TS_ITEM_NOTES
FROM         dbo.TSNOTES INNER JOIN
                      dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID ON dbo.TSNOTES.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID
WHERE period_id=@period_id and tstimesheet.site_uid = @siteguid and username like @username

END
')
