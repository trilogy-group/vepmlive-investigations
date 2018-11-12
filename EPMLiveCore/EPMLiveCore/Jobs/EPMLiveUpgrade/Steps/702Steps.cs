using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V702, Order = 1, Description = "Updating VWmeta view for rate feature changes")]
    internal class TimeSheetRatePerProjectViewUpdate : UpgradeStep
    {
        public TimeSheetRatePerProjectViewUpdate(SPWeb web, bool isPfeSite)
            : base(web, isPfeSite)
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


                        #region ViewCode

                        epmLiveCn.ExecuteNonQuery($@"ALTER VIEW [dbo].[vwMeta] AS
SELECT dbo.TSTIMESHEET.USERNAME AS Username, dbo.TSTIMESHEET.RESOURCENAME AS [Resource Name], dbo.TSUSER.USER_ID AS SharePointAccountID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSITEM.TS_ITEM_UID AS [Item UID], 
                         dbo.TSITEM.TITLE AS [Item Name], dbo.TSITEM.PROJECT AS Project, dbo.TSITEM.PROJECT_ID AS ProjectID, COALESCE (dbo.TSMETA.ListName + '_' + dbo.TSMETA.ColumnName, 'TempColumn') 
                         AS ColumnName, dbo.TSMETA.DisplayName, dbo.TSMETA.ColumnValue, dbo.TSITEM.ITEM_TYPE AS [Item Type], dbo.TSITEM.TS_UID AS [Timesheet UID], dbo.TSPERIOD.PERIOD_ID AS [Period Id], 
                         dbo.TSPERIOD.SITE_ID, dbo.TSITEM.LIST AS List, dbo.TSITEMHOURS.TS_ITEM_DATE AS Date, dbo.TSITEMHOURS.TS_ITEM_HOURS AS Hours, dbo.TSITEMHOURS.TS_ITEM_TYPE_ID AS [Type Id], 
                         dbo.TSTYPE.TSTYPE_NAME AS [Type Name], dbo.TSPERIOD.PERIOD_START AS [Period Start], dbo.TSPERIOD.PERIOD_END AS [Period End], 
                         CASE dbo.TSTIMESHEET.SUBMITTED WHEN 0 THEN 'No' WHEN 1 THEN 'Yes' END AS Submitted, 
                         CASE dbo.TSTIMESHEET.APPROVAL_STATUS WHEN 0 THEN 'Pending' WHEN 1 THEN 'Approved' WHEN 2 THEN 'Rejected' END AS [Approval Status], 
                         CASE dbo.TSITEM.APPROVAL_STATUS WHEN 0 THEN 'Pending' WHEN 1 THEN 'Approved' WHEN 2 THEN 'Rejected' END AS [PM Approval Status], CONVERT(varchar(8000), 
                         COALESCE (dbo.TSTIMESHEET.APPROVAL_NOTES, '')) AS [Approval Notes], dbo.TSTIMESHEET.LASTMODIFIEDBYN, CONVERT(varchar(MAX), dbo.TSNOTES.TS_ITEM_NOTES) AS TS_ITEM_NOTES, 
                         dbo.TSTIMESHEET.APPROVAL_DATE, COALESCE (dbo.TSTIMESHEET.LastSubmittedByName, dbo.TSTIMESHEET.LASTMODIFIEDBYN) AS LastSubmittedByName, 
                         COALESCE (dbo.TSTIMESHEET.LastSubmittedByUser, dbo.TSTIMESHEET.LASTMODIFIEDBYU) AS LastSubmittedByUser
FROM            dbo.TSITEM INNER JOIN
                         dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID INNER JOIN
                         dbo.TSPERIOD ON dbo.TSTIMESHEET.PERIOD_ID = dbo.TSPERIOD.PERIOD_ID AND dbo.TSTIMESHEET.SITE_UID = dbo.TSPERIOD.SITE_ID INNER JOIN
                         dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID LEFT OUTER JOIN
                         dbo.TSNOTES ON dbo.TSITEM.TS_ITEM_UID = dbo.TSNOTES.TS_ITEM_UID AND dbo.TSITEMHOURS.TS_ITEM_DATE = dbo.TSNOTES.TS_ITEM_DATE LEFT OUTER JOIN
                         dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID LEFT OUTER JOIN
                         dbo.TSTYPE ON dbo.TSTIMESHEET.SITE_UID = dbo.TSTYPE.SITE_UID AND dbo.TSITEMHOURS.TS_ITEM_TYPE_ID = dbo.TSTYPE.TSTYPE_ID LEFT OUTER JOIN
						 dbo.TSUSER ON dbo.TSTIMESHEET.TSUSER_UID = dbo.TSUSER.TSUSERUID
UNION
SELECT        dbo.TSTIMESHEET.USERNAME AS Username, dbo.TSTIMESHEET.RESOURCENAME AS [Resource Name], dbo.TSUSER.USER_ID AS SharePointAccountID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSITEM.TS_ITEM_UID AS [Item UID], 
                         dbo.TSITEM.TITLE AS [Item Name], dbo.TSITEM.PROJECT AS Project, dbo.TSITEM.PROJECT_ID AS ProjectID, COALESCE (dbo.TSMETA.ColumnName, 'TempColumn') AS ColumnName, dbo.TSMETA.DisplayName, 
                         dbo.TSMETA.ColumnValue, dbo.TSITEM.ITEM_TYPE AS [Item Type], dbo.TSITEM.TS_UID AS [Timesheet UID], dbo.TSPERIOD.PERIOD_ID AS [Period Id], dbo.TSPERIOD.SITE_ID, dbo.TSITEM.LIST AS List, 
                         dbo.TSITEMHOURS.TS_ITEM_DATE AS Date, dbo.TSITEMHOURS.TS_ITEM_HOURS AS Hours, dbo.TSITEMHOURS.TS_ITEM_TYPE_ID AS [Type Id], dbo.TSTYPE.TSTYPE_NAME AS [Type Name], 
                         dbo.TSPERIOD.PERIOD_START AS [Period Start], dbo.TSPERIOD.PERIOD_END AS [Period End], CASE dbo.TSTIMESHEET.SUBMITTED WHEN 0 THEN 'No' WHEN 1 THEN 'Yes' END AS Submitted, 
                         CASE dbo.TSTIMESHEET.APPROVAL_STATUS WHEN 0 THEN 'Pending' WHEN 1 THEN 'Approved' WHEN 2 THEN 'Rejected' END AS [Approval Status], 
                         CASE dbo.TSITEM.APPROVAL_STATUS WHEN 0 THEN 'Pending' WHEN 1 THEN 'Approved' WHEN 2 THEN 'Rejected' END AS [PM Approval Status], CONVERT(varchar(8000), 
                         COALESCE (dbo.TSTIMESHEET.APPROVAL_NOTES, '')) AS [Approval Notes], dbo.TSTIMESHEET.LASTMODIFIEDBYN, CONVERT(varchar(MAX), dbo.TSNOTES.TS_ITEM_NOTES) AS Expr1, 
                         dbo.TSTIMESHEET.APPROVAL_DATE, COALESCE (dbo.TSTIMESHEET.LastSubmittedByName, dbo.TSTIMESHEET.LASTMODIFIEDBYN) AS LastSubmittedByName, 
                         COALESCE (dbo.TSTIMESHEET.LastSubmittedByUser, dbo.TSTIMESHEET.LASTMODIFIEDBYU) AS LastSubmittedByUser
FROM            dbo.TSITEM INNER JOIN
                         dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID INNER JOIN
                         dbo.TSPERIOD ON dbo.TSTIMESHEET.PERIOD_ID = dbo.TSPERIOD.PERIOD_ID AND dbo.TSTIMESHEET.SITE_UID = dbo.TSPERIOD.SITE_ID INNER JOIN
                         dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID LEFT OUTER JOIN
                         dbo.TSNOTES ON dbo.TSITEMHOURS.TS_ITEM_DATE = dbo.TSNOTES.TS_ITEM_DATE AND dbo.TSITEM.TS_ITEM_UID = dbo.TSNOTES.TS_ITEM_UID LEFT OUTER JOIN
                         dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID AND dbo.TSITEM.LIST = dbo.TSMETA.ListName LEFT OUTER JOIN
                         dbo.TSTYPE ON dbo.TSTIMESHEET.SITE_UID = dbo.TSTYPE.SITE_UID AND dbo.TSITEMHOURS.TS_ITEM_TYPE_ID = dbo.TSTYPE.TSTYPE_ID LEFT OUTER JOIN
						 dbo.TSUSER ON dbo.TSTIMESHEET.TSUSER_UID = dbo.TSUSER.TSUSERUID
UNION
SELECT        TSTIMESHEET_1.USERNAME, TSTIMESHEET_1.RESOURCENAME AS [Resource Name], TSUSER_1.USER_ID AS SharePointAccountID, TSITEM_1.LIST_UID, TSITEM_1.ITEM_ID, TSITEM_1.TS_ITEM_UID, TSITEM_1.TITLE, TSITEM_1.PROJECT, 
                         TSITEM_1.PROJECT_ID, 'Resource_' + dbo.TSRESMETA.ColumnName AS listcolumnname, dbo.TSRESMETA.DisplayName, 
						 CASE dbo.TSRESMETA.ColumnName WHEN 'StandardRate' THEN (CASE WHEN (TSITEM_1.Rate is null or TSITEM_1.Rate = '') THEN dbo.TSRESMETA.ColumnValue ELSE TSITEM_1.Rate END) ELSE dbo.TSRESMETA.columnvalue  END AS ColumnValue,
						 TSITEM_1.ITEM_TYPE, TSITEM_1.TS_UID,TSTIMESHEET_1.PERIOD_ID, TSTIMESHEET_1.SITE_UID, TSITEM_1.LIST, TSITEMHOURS_1.TS_ITEM_DATE, TSITEMHOURS_1.TS_ITEM_HOURS, TSITEMHOURS_1.TS_ITEM_TYPE_ID, 
                         TSTYPE_1.TSTYPE_NAME, TSPERIOD_1.PERIOD_START AS Start, TSPERIOD_1.PERIOD_END AS [End], CASE TSTIMESHEET_1.SUBMITTED WHEN 0 THEN 'No' WHEN 1 THEN 'Yes' END AS Submitted, 
                         CASE TSTIMESHEET_1.APPROVAL_STATUS WHEN 0 THEN 'Pending' WHEN 1 THEN 'Approved' WHEN 2 THEN 'Rejected' END AS [Approval Status], 
                         CASE TSITEM_1.APPROVAL_STATUS WHEN 0 THEN 'Pending' WHEN 1 THEN 'Approved' WHEN 2 THEN 'Rejected' END AS [PM Approval Status], CONVERT(varchar(8000), 
                         COALESCE (TSTIMESHEET_1.APPROVAL_NOTES, '')) AS [Approval Notes], TSTIMESHEET_1.LASTMODIFIEDBYN, CONVERT(varchar(MAX), dbo.TSNOTES.TS_ITEM_NOTES) AS TS_ITEM_NOTES, 
                         TSTIMESHEET_1.APPROVAL_DATE, COALESCE (TSTIMESHEET_1.LastSubmittedByName, TSTIMESHEET_1.LASTMODIFIEDBYN) AS LastSubmittedByName, COALESCE (TSTIMESHEET_1.LastSubmittedByUser, 
                         TSTIMESHEET_1.LASTMODIFIEDBYU) AS LastSubmittedByUser
FROM            dbo.TSTIMESHEET AS TSTIMESHEET_1 INNER JOIN
                         dbo.TSRESMETA ON TSTIMESHEET_1.TS_UID = dbo.TSRESMETA.TS_UID INNER JOIN
                         dbo.TSITEM AS TSITEM_1 ON TSTIMESHEET_1.TS_UID = TSITEM_1.TS_UID INNER JOIN
                         dbo.TSITEMHOURS AS TSITEMHOURS_1 ON TSITEM_1.TS_ITEM_UID = TSITEMHOURS_1.TS_ITEM_UID INNER JOIN
                         dbo.TSPERIOD AS TSPERIOD_1 ON TSTIMESHEET_1.PERIOD_ID = TSPERIOD_1.PERIOD_ID AND TSTIMESHEET_1.SITE_UID = TSPERIOD_1.SITE_ID LEFT OUTER JOIN
                         dbo.TSNOTES ON TSITEMHOURS_1.TS_ITEM_DATE = dbo.TSNOTES.TS_ITEM_DATE AND TSITEM_1.TS_ITEM_UID = dbo.TSNOTES.TS_ITEM_UID LEFT OUTER JOIN
                  dbo.TSTYPE AS TSTYPE_1 ON TSTIMESHEET_1.SITE_UID = TSTYPE_1.SITE_UID AND TSITEMHOURS_1.TS_ITEM_TYPE_ID = TSTYPE_1.TSTYPE_ID  LEFT OUTER JOIN
						dbo.TSUSER AS TSUSER_1 ON TSTIMESHEET_1.TSUSER_UID = TSUSER_1.TSUSERUID");

                        #endregion

                        LogMessage("TSItem.Rate, Updated the vwMeta view", MessageKind.SUCCESS, 4);

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
