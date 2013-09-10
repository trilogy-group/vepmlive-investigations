DECLARE @creatoralter varchar(10)
IF NOT EXISTS (SELECT routine_name FROM INFORMATION_SCHEMA.routines WHERE routine_name = 'spGetWebs')
BEGIN
    PRINT 'Creating Stored Procedure spGetWebs'
    SET @creatoralter = 'CREATE'
END
ELSE
BEGIN
    PRINT 'Updating Stored Procedure spGetWebs'
    SET @creatoralter = 'ALTER'
END
EXEC(@creatoralter + ' PROCEDURE [dbo].[spGetWebs]
      -- Add the parameters for the stored procedure here
      @UserId AS INT,
      @SiteId AS UNIQUEIDENTIFIER
AS
BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET NOCOUNT ON;

    -- Insert statements for procedure here
      SELECT DISTINCT SiteId, ItemWebId, ItemListId, ItemId, ParentWebId, WebId, WebUrl, WebTitle,
            CASE 
                  WHEN @UserId = 1073741823 THEN 1 
                  WHEN (SELECT COUNT(*) FROM dbo.RPTWeb 
                              INNER JOIN dbo.RPTWEBGROUPS ON dbo.RPTWeb.SiteId = dbo.RPTWEBGROUPS.SITEID AND dbo.RPTWeb.WebId = dbo.RPTWEBGROUPS.WEBID 
                              LEFT OUTER JOIN dbo.RPTGROUPUSER ON dbo.RPTWEBGROUPS.SITEID = dbo.RPTGROUPUSER.SITEID AND dbo.RPTWEBGROUPS.GROUPID = dbo.RPTGROUPUSER.GROUPID
                              WHERE ((SECTYPE = 0) AND (dbo.RPTWEBGROUPS.GROUPID = @UserId)) OR ((SECTYPE = 1) AND (USERID = @UserId))) > 0 THEN 1
                  ELSE 0 
            END AS HasAccess
      FROM RPTWeb WHERE SiteId = @SiteId
END');

