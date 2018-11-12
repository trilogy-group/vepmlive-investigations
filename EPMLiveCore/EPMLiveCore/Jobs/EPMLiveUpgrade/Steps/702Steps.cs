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

	[UpgradeStep(Version = EPMLiveVersion.V702, Order = 1, Description = "ALTER SPNGetNotifications")]
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
