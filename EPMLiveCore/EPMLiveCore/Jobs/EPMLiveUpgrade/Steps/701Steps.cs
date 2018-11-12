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
    [UpgradeStep(Version = EPMLiveVersion.V701, Order = 1, Description = "Updating Project Rate feature to Timesheet")]
    internal class TimeSheetRatePerProjectUpdate : UpgradeStep
    {
        public TimeSheetRatePerProjectUpdate(SPWeb web, bool isPfeSite)
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
						 CASE dbo.TSRESMETA.ColumnName WHEN 'StandardRate' THEN (CASE TSITEM_1.Rate WHEN null THEN dbo.TSRESMETA.ColumnValue ELSE TSITEM_1.Rate END) ELSE dbo.TSRESMETA.columnvalue  END AS ColumnValue,
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

	[UpgradeStep(Version = EPMLiveVersion.V701, Order = 1, Description = "ALTER SPNGetNotifications")]
	internal class SPNGetNotifications : UpgradeStep
	{
		public SPNGetNotifications(SPWeb web, bool isPfeSite)
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
						epmLiveCn.ExecuteNonQuery($@"ALTER PROCEDURE [dbo].[spNGetNotifications] 
      -- Add the parameters for the stored procedure here
      @UserName NVARCHAR(255),
      @UserId NVARCHAR(255),
      @SiteId UNIQUEIDENTIFIER, 
      @SiteCreationDateTime DATETIME,
      @IsUserSiteCollectionAdmin BIT = 0,
      @NotificationStatus VARCHAR(4) = 'ALL',
      @Limit INT = NULL,
      @FirstPage INT = NULL,
      @LastPage INT = NULL
AS
BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    DECLARE @MaxInt INT
    SET @MaxInt = 2147483647
    
    DECLARE @GetRead BIT
    SET @GetRead = NULL
    
    IF @NotificationStatus = 'NEW' SET @GetRead = 0
    ELSE IF @NotificationStatus = 'OLD' SET @GetRead = 1
    
    DECLARE @SiteCreationDate DATETIME
    SET @SiteCreationDate = @SiteCreationDateTime
    --SET @SiteCreationDate = DATEADD(DAY, DATEDIFF(DAY, 0, @SiteCreationDateTime), 0)
    
    DECLARE @NotificationId UNIQUEIDENTIFIER
    
      IF @IsUserSiteCollectionAdmin = 1
            BEGIN
                  DECLARE NotificationCursor CURSOR FAST_FORWARD FOR
                        SELECT      ID 
                        FROM  dbo.NOTIFICATIONS 
                        WHERE (Type = 0 OR Type = 1) AND 
                                    (ID NOT IN (SELECT      FK 
                                                      FROM  dbo.PERSONALIZATIONS
                                                      WHERE ([Key] = 'Notifications') AND (UserId = @UserName)))
                  
                  OPEN NotificationCursor
                 FETCH NEXT FROM NotificationCursor INTO @NotificationId
                  
                  WHILE @@FETCH_STATUS = 0
                  BEGIN
                        EXECUTE dbo.spNTranslateNotificationToPersonalization @NotificationId, @UserId, @UserName
                        FETCH NEXT FROM NotificationCursor INTO @NotificationId
                  END
                  
                  CLOSE NotificationCursor
                  DEALLOCATE NotificationCursor
            
                  DECLARE @sqlStatement NVARCHAR(MAX);

				 SET @sqlStatement = 'SELECT ID, Title, Message, CAST(Type AS INT) AS Type, CAST(CreatedBy AS INT) AS CreatedBy, SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, NotificationRead, PersonalizationID,PersonalizationSiteID, UserName FROM ('
				 SET @sqlStatement =    @sqlStatement  + ' SELECT TOP (COALESCE(@Limit, @MaxInt)) ROW_NUMBER() OVER(ORDER BY CreatedAt) AS Row, ID, Title, Message, Type, CreatedBy, SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, NotificationRead, PersonalizationID, PersonalizationSiteID, UserName'
				 SET @sqlStatement =    @sqlStatement  + ' FROM (SELECT           ID, Title, Message, Type, CreatedBy, SiteCreationDateTime AS SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, NotificationRead, PersonalizationID, PersonalizationSiteID, UserName FROM dbo.vwNotifications WHERE'
				 SET @sqlStatement =    @sqlStatement  + ' (Type = 0) AND ((UserName = @UserName) OR (UserName = @UserId)) AND '
				 SET @sqlStatement =    @sqlStatement  + ' (SiteID = ''00000000-0000-0000-0000-000000000000'' OR SiteID IS NULL OR SiteID = @SiteId) AND '
				 SET @sqlStatement =    @sqlStatement  + ' (SiteCreationDate IS NULL OR @SiteCreationDate <= SiteCreationDate) OR '
				 SET @sqlStatement =    @sqlStatement  + ' (Type = 1) AND ((UserName = @UserName) OR (UserName = @UserId)) AND '
				 SET @sqlStatement =    @sqlStatement  + ' (SiteID = ''00000000-0000-0000-0000-000000000000'' OR SiteID IS NULL OR SiteID = @SiteId) AND '
				 SET @sqlStatement =    @sqlStatement  + ' (SiteCreationDate IS NULL OR @SiteCreationDate <= SiteCreationDate) OR '
				 SET @sqlStatement =    @sqlStatement  + ' (Type > 1) AND '
				 SET @sqlStatement =    @sqlStatement  + ' (SiteCreationDate IS NULL OR @SiteCreationDate <= SiteCreationDate) AND '
				 SET @sqlStatement =    @sqlStatement  + ' ((UserName = @UserName) OR (UserName = @UserId)) AND '
				 SET @sqlStatement =    @sqlStatement  + ' (PersonalizationSiteID = ''00000000-0000-0000-0000-000000000000'' OR PersonalizationSiteID IS NULL OR PersonalizationSiteID = @SiteId)) AS Notifications '
				IF (@GetRead = 0) 
				 SET @sqlStatement =    @sqlStatement  + ' WHERE (NotificationRead = 0 OR NotificationRead IS NULL) '
				IF (@GetRead = 1) 
				 SET @sqlStatement =    @sqlStatement  + ' WHERE (NotificationRead = 1) '
				IF (@GetRead IS NULL) 
				 SET @sqlStatement =    @sqlStatement  + ' WHERE (NotificationRead IN (0, 1) OR NotificationRead IS NULL) '
				SET @sqlStatement =    @sqlStatement  + ' ) AS Notifications WHERE Row BETWEEN COALESCE(@FirstPage, 0) AND COALESCE(@LastPage, @MaxInt)'

				EXEC sp_executesql @sqlStatement, N'@Limit int, @MaxInt int, @FirstPage int,  @LastPage int, @UserName nvarchar, @UserId int, @SiteId uniqueidentifier, @SiteCreationDate datetime ', @Limit, @MaxInt, @FirstPage,  @LastPage, @UserName, @UserId,  @SiteId, @SiteCreationDate

            END
      ELSE
            BEGIN
                  DECLARE NotificationCursor CURSOR FAST_FORWARD FOR
                        SELECT      ID 
                        FROM  dbo.NOTIFICATIONS 
                        WHERE Type = 0 AND 
                                    (ID NOT IN (SELECT      FK 
                                                      FROM  dbo.PERSONALIZATIONS
                                                      WHERE ([Key] = 'Notifications') AND (UserId = @UserName)))
                  
                  OPEN NotificationCursor
                  FETCH NEXT FROM NotificationCursor INTO @NotificationId
                  
                  WHILE @@FETCH_STATUS = 0
                  BEGIN
                        EXECUTE dbo.spNTranslateNotificationToPersonalization @NotificationId, @UserId, @UserName
                        FETCH NEXT FROM NotificationCursor INTO @NotificationId
                  END
                  
                  CLOSE NotificationCursor
                  DEALLOCATE NotificationCursor
                  

					SET @sqlStatement = 'SELECT ID, Title, Message, CAST(Type AS INT) AS Type, CAST(CreatedBy AS INT) AS CreatedBy, SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, NotificationRead, PersonalizationID, PersonalizationSiteID, UserName FROM ( '
					SET @sqlStatement =    @sqlStatement  + ' SELECT TOP (COALESCE(@Limit, 2147483647)) ROW_NUMBER() OVER(ORDER BY CreatedAt) AS Row, ID, Title, Message, Type, CreatedBy, SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, NotificationRead, PersonalizationID, PersonalizationSiteID, UserName FROM ( '
					SET @sqlStatement =    @sqlStatement  + ' SELECT ID, Title, Message, Type, CreatedBy, SiteCreationDateTime AS SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, NotificationRead, PersonalizationID, PersonalizationSiteID, UserName FROM       dbo.vwNotifications WHERE '
					SET @sqlStatement =    @sqlStatement  + ' (Type = 0) AND ((UserName = @UserName) OR (UserName = @UserId)) AND '
					SET @sqlStatement =    @sqlStatement  + ' (SiteID = ''00000000-0000-0000-0000-000000000000'' OR SiteID IS NULL OR SiteID = @SiteId) AND '
					SET @sqlStatement =    @sqlStatement  + ' (SiteCreationDate IS NULL OR @SiteCreationDate <= SiteCreationDate) OR '
					SET @sqlStatement =    @sqlStatement  + ' (Type > 1) AND (SiteCreationDate IS NULL OR @SiteCreationDate <= SiteCreationDate) AND '
					SET @sqlStatement =    @sqlStatement  + ' ((UserName = @UserName) OR (UserName = @UserId)) AND '
					SET @sqlStatement =    @sqlStatement  + ' (PersonalizationSiteID = ''00000000-0000-0000-0000-000000000000'' OR PersonalizationSiteID IS NULL OR PersonalizationSiteID = @SiteId)) AS Notifications '
					IF (@GetRead = 0) 
					SET @sqlStatement =    @sqlStatement  + ' WHERE (NotificationRead = 0 OR NotificationRead IS NULL) '
					IF (@GetRead = 1) 
					SET @sqlStatement =    @sqlStatement  + ' WHERE (NotificationRead = 1) '
					IF (@GetRead IS NULL) 
					SET @sqlStatement =    @sqlStatement  + ' WHERE (NotificationRead IN (0, 1) OR NotificationRead IS NULL) '
					SET @sqlStatement =    @sqlStatement  + ' ) AS Notifications WHERE Row BETWEEN COALESCE(@FirstPage, 0) AND COALESCE(@LastPage, @MaxInt)'
					PRINT @sqlStatement

					EXEC sp_executesql @sqlStatement, N'@Limit int, @MaxInt int, @FirstPage int,  @LastPage int, @UserName nvarchar, @UserId int, @SiteId uniqueidentifier, @SiteCreationDate datetime ', @Limit, @MaxInt, @FirstPage,  @LastPage, @UserName, @UserId,  @SiteId, @SiteCreationDate



            END
END");

						#endregion

						LogMessage("TSItem.Rate, Updated the SPNGetNotifications procedure", MessageKind.SUCCESS, 4);

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
