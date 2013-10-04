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
      CREATE TABLE #Groups (GroupId INT)
	  INSERT INTO #Groups (GroupId) SELECT GROUPID FROM dbo.RPTGROUPUSER WHERE (USERID = @UserId) AND (SITEID = @SiteId)
    
      SELECT DISTINCT SiteId, ItemWebId, ItemListId, ItemId, ParentWebId, WebId, WebUrl, WebTitle,
            CASE 
                  WHEN @UserId = 1073741823 THEN 1 
                  WHEN (WebId IN (SELECT WEBID FROM dbo.RPTWEBGROUPS 
                        WHERE (SECTYPE = 1) AND (GROUPID IN (SELECT GroupId FROM #Groups)) 
                        OR (SECTYPE = 0) AND (GROUPID = @UserId))) THEN 1
                  ELSE 0 
            END AS HasAccess
      FROM RPTWeb WHERE SiteId = @SiteId
END');

