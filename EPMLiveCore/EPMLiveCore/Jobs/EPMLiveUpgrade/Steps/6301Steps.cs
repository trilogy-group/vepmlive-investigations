using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V630, Order = 2.0,
      Description = "New storeprocedure spTSAllDataRR spTSAllDataRR")]
    internal class ReportingRefreshUpgrade : UpgradeStep
    {

        public ReportingRefreshUpgrade(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
        }

        public override bool Perform()
        {
            try
            {
                Guid webAppId = Web.Site.WebApplication.Id;
                Guid SiteId = Web.Site.ID;
                spTSAllDataRR(webAppId);
                spRefreshTimesheet_V2(webAppId, SiteId);
                return true;
            }
            catch { return false; }
        }

        private void spTSAllDataRR(Guid webAppId)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    LogMessage("Connecting to the database . . .", 2);

                    string epmLiveCnStr = CoreFunctions.getConnectionString(webAppId);
                    using (var epmLiveCn = new SqlConnection(epmLiveCnStr))
                    {
                        epmLiveCn.Open();

                        var definition = epmLiveCn.GetSpDefinition("dbo.spTSAllDataRR");

                        if (definition == null)
                        {
                            #region ViewCode

                            epmLiveCn.ExecuteNonQuery($@"Create PROC [dbo].[spTSAllDataRR]
	@siteuid uniqueidentifier
AS
BEGIN
declare @colname varchar(255)
declare @cols varchar(MAX)

set @cols = ''

IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE  TABLE_NAME = 'TempTSTable'))
BEGIN
  drop table TempTSTable
END

/*
DECLARE colsCursors CURSOR FOR 
SELECT distinct columnname
from vwmeta
where site_id = @siteuid
*/
/* Trial replacement of query (MAW, 2016-10-30) */
DECLARE colsCursors CURSOR FOR 
SELECT distinct IV.columnname
FROM (
SELECT		COALESCE (dbo.TSMETA.ListName + '_' + dbo.TSMETA.ColumnName, 'TempColumn') AS ColumnName
FROM		dbo.TSITEM
INNER JOIN	dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
INNER JOIN	dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID
INNER JOIN	dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID
WHERE		dbo.TSTIMESHEET.SITE_UID = @siteuid
UNION
SELECT		COALESCE (dbo.TSMETA.ColumnName, 'TempColumn') AS ColumnName
FROM		dbo.TSITEM
INNER JOIN	dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
INNER JOIN	dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID
INNER JOIN	dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID AND dbo.TSITEM.LIST = dbo.TSMETA.ListName
WHERE		dbo.TSTIMESHEET.SITE_UID = @siteuid
UNION
SELECT		'Resource_' + dbo.TSRESMETA.ColumnName AS columnname
FROM		dbo.TSTIMESHEET AS TSTIMESHEET_1
INNER JOIN	dbo.TSRESMETA ON TSTIMESHEET_1.TS_UID = dbo.TSRESMETA.TS_UID
INNER JOIN	dbo.TSITEM AS TSITEM_1 ON TSTIMESHEET_1.TS_UID = TSITEM_1.TS_UID
INNER JOIN	dbo.TSITEMHOURS AS TSITEMHOURS_1 ON TSITEM_1.TS_ITEM_UID = TSITEMHOURS_1.TS_ITEM_UID
WHERE TSTIMESHEET_1.SITE_UID = @siteuid
UNION
SELECT		'TempColumn') as IV
order by IV.columnname

OPEN colsCursors

FETCH NEXT FROM colsCursors 
INTO @colname

WHILE @@FETCH_STATUS = 0
BEGIN

set @cols = @cols + ',[' + @colname + ']'

FETCH NEXT FROM colsCursors 
INTO @colname

END

CLOSE colsCursors
DEALLOCATE colsCursors

if @cols <> ''
begin
	declare @sql varchar(MAX)

	set @sql = 'SELECT Username, [Resource Name], [Item Name], LIST_UID, ITEM_ID, [Project], [ProjectID], [Item Type], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '' - ''
 + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status],[PM Approval Status],[Approval Notes], [lastmodifiedbyn] as [Last Modified By], [LastSubmittedByName] as [Last Submitted By], [TS_ITEM_NOTES] as [Item Notes], APPROVAL_DATE as [Approval Date] '
	set @sql = @sql + @cols
	set @sql = @sql + ', [Item UID], [Timesheet UID] into TempTSTable FROM '
	set @sql = @sql + '(SELECT Username, [Resource Name], [Item UID], [Item Name], LIST_UID, ITEM_ID, [Project], [ProjectID], [Item Type], [Timesheet UID], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], [Submitted],
 [Approval Status],[PM Approval Status],[Approval Notes],[lastmodifiedbyn], [LastSubmittedByName], [TS_ITEM_NOTES], [APPROVAL_DATE], columnname, columnvalue,site_id
	FROM vwMeta Where hours > 0) ps
	PIVOT
	(
	min (columnvalue)
	FOR columnname IN
	('

	set @sql = @sql + substring(@cols,2,len(@cols)-1)

	set @sql = @sql + ')'
	set @sql = @sql + ') AS pvt where site_id = ''' + convert(varchar(50),@siteuid) + ''''

end
else
begin

	set @sql = 'SELECT Username, [Resource Name], [Item Name], [Project], [ProjectID], [Item Type], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '' - '' + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status],[PM Approval Status],[Approval Notes], [lastmodifiedbyn] as [Last Modified By], [LastSubmittedByName] as [Last Submitted By], [TS_ITEM_NOTES], [APPROVAL_DATE] into TempTSTable  from vwMeta where hours > 0 and site_id = ''' + convert(varchar(50),@siteuid) + ''''

end
set @sql=@sql+' alter table TempTSTable add rpttsduid uniqueidentifier'
set @sql=@sql+' update TempTSTable set rpttsduid=newid()'

 --print @sql
--print @cols

exec(@sql)
END");

                            #endregion

                            LogMessage("spTSAllDataRR procedure has been created.", MessageKind.SUCCESS, 4);
                        }
                        else
                        {
                            LogMessage("spTSAllDataRR procedure already exists.", MessageKind.SKIPPED, 4);
                        }
                    }
                });


            }
            catch (Exception exception)
            {
                string message = exception.InnerException != null
                    ? exception.InnerException.Message
                    : exception.Message;

                LogMessage(message, MessageKind.FAILURE, 4);

            }
        }

        private void spRefreshTimesheet_V2(Guid webAppId, Guid SiteId)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    LogMessage("Connecting to the database . . .", 2);

                    string rptCnStr = CoreFunctions.getReportingConnectionString(webAppId, SiteId);
                    using (var rptCn = new SqlConnection(rptCnStr))
                    {
                        rptCn.Open();

                        var definition = rptCn.GetSpDefinition("dbo.spRefreshTimesheet_V2");

                        if (definition == null)
                        {
                            #region ViewCode

                            rptCn.ExecuteNonQuery($@"Create PROCEDURE [dbo].[spRefreshTimesheet_V2]
	  @dbname  varchar(50),
	  @siteuid uniqueidentifier,
	  @RPTTSData varchar(20),
	  @WebTitle  varchar(20),
	  @jobUid uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;
Declare @tablecount int = 0
Declare @tstablerowcount int = 0
Declare @SafeRPTDataTableName varchar(20)=''

exec(@dbname+'.[dbo].[spTSAllDataRR]''' + @siteuid + '''')
IF (EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES 
                 WHERE  TABLE_NAME = 'RPTTempTSTable'))
BEGIN
  drop table RPTTempTSTable
END
exec('select * into RPTTempTSTable from '+@dbname+'.[dbo].TempTSTable')
select @tstablerowcount=count(*) from RPTTempTSTable

if @tstablerowcount != 0 

begin 



INSERT INTO dbo.RPTLog VALUES(null,'TimeSheet','Begin deleting existing time sheet data for web: '+@WebTitle,'Begin deleting existing time sheet data for web: '+@WebTitle,0,1,getdate(),@jobUid)
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(@RPTTSData) AND type in (N'U'))EXEC('DROP TABLE '+@RPTTSData)
INSERT INTO dbo.RPTLog VALUES(null,'TimeSheet','Finished deleting existing time sheet data for web: '+@WebTitle,'Finished deleting existing time sheet data for web: '+@WebTitle,0,1,getdate(),@jobUid)

INSERT INTO dbo.RPTLog VALUES(null,'TimeSheet','Recreating and Inserting Data into RPTTSData for web: '+@WebTitle,'Recreating and Inserting Data into RPTTSData for web: '+@WebTitle,0,1,getdate(),@jobUid)
exec('Select * into  '+@RPTTSData+' from  RPTTempTSTable')
INSERT INTO dbo.RPTLog VALUES(null,'TimeSheet','Finished refreshing time sheet data for web:  '+@WebTitle,'Recreating RPTTSData for web: '+@WebTitle,0,1,getdate(),@jobUid)
--Global Table dropped

END
ELSe
Begin
INSERT INTO dbo.RPTLog VALUES(null,'TimeSheet','No time sheet data exists for web:  '+@WebTitle,'No time sheet data exists for web: '+@WebTitle,0,1,getdate(),@jobUid)
END
END");

                            #endregion

                            LogMessage("spRefreshTimesheet_V2 procedure has been created.", MessageKind.SUCCESS, 4);
                        }
                        else
                        {
                            LogMessage("spRefreshTimesheet_V2 procedure already exists.", MessageKind.SKIPPED, 4);
                        }
                    }
                });


            }
            catch (Exception exception)
            {
                string message = exception.InnerException != null
                    ? exception.InnerException.Message
                    : exception.Message;

                LogMessage(message, MessageKind.FAILURE, 4);

            }
        }
    }
}
