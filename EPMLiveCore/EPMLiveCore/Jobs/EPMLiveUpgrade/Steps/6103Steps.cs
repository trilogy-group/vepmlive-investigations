using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V610, Order = 3.0,
        Description = "New columns LastSubmittedByName and LastSubmittedByUser added to reporting source sp")]
    internal class NewLastSubmitedColumnsAddedToReportingSourceSp : UpgradeStep
    {
        public NewLastSubmitedColumnsAddedToReportingSourceSp(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
        }

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;

            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    LogMessage("Connecting to the database . . .", 2);

                    string epmLiveCnStr = CoreFunctions.getConnectionString(webAppId);
                    using (var epmLiveCn = new SqlConnection(epmLiveCnStr))
                    {
                        epmLiveCn.Open();

                        var definition = epmLiveCn.GetSpDefinition("dbo.spTSAllData");
                        var versionMarker = "v6.1.0";
                        if (definition != null && !definition.Contains(versionMarker))
                        {
                            #region ViewCode

                            epmLiveCn.ExecuteNonQuery($@"ALTER PROC [dbo].[spTSAllData]
	@siteuid uniqueidentifier
AS
BEGIN
-- {versionMarker}
declare @colname varchar(255)
declare @cols varchar(MAX)

set @cols = ''

DECLARE colsCursors CURSOR FOR 
SELECT distinct columnname
from vwmeta
where site_id = @siteuid
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

	set @sql = 'SELECT Username, [Resource Name], [Item Name], LIST_UID, ITEM_ID, [Project], [ProjectID], [Item Type], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '' - '' + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status],[PM Approval Status],[Approval Notes], [lastmodifiedbyn] as [Last Modified By], [LastSubmittedByName] as [Last Submitted By], [TS_ITEM_NOTES] as [Item Notes], APPROVAL_DATE as [Approval Date] '
	set @sql = @sql + @cols
	set @sql = @sql + ', [Item UID], [Timesheet UID] FROM '
	set @sql = @sql + '(SELECT Username, [Resource Name], [Item UID], [Item Name], LIST_UID, ITEM_ID, [Project], [ProjectID], [Item Type], [Timesheet UID], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], [Submitted], [Approval Status],[PM Approval Status],[Approval Notes],[lastmodifiedbyn], [LastSubmittedByName], [TS_ITEM_NOTES], [APPROVAL_DATE], columnname, columnvalue,site_id
	FROM vwmeta Where hours > 0) ps
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

	set @sql = 'SELECT Username, [Resource Name], [Item Name], [Project], [ProjectID], [Item Type], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '' - '' + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status],[PM Approval Status],[Approval Notes], [lastmodifiedbyn] as [Last Modified By], [LastSubmittedByName] as [Last Submitted By], [TS_ITEM_NOTES], [APPROVAL_DATE] from vwmeta where hours > 0 and site_id = ''' + convert(varchar(50),@siteuid) + ''''

end

--print @sql
--print @cols

exec(@sql)
END");

                            #endregion

                            LogMessage("LastSubmittedByName columns added to the spTSAllData", MessageKind.SUCCESS, 4);
                        }
                        else
                        {
                            LogMessage("LastSubmittedByName columns already exists in the spTSAllData", MessageKind.SKIPPED, 4);
                        }
                    }
                });

                return true;
            }
            catch (Exception exception)
            {
                string message = exception.InnerException != null
                    ? exception.InnerException.Message
                    : exception.Message;

                LogMessage(message, MessageKind.FAILURE, 4);

                return false;
            }
        }
    }
}