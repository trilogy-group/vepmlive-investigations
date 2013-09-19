declare @createoralter varchar(10)
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'Split')
begin
    Print 'Creating Function Split'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function Split'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[Split]
(
@ItemList NVARCHAR(MAX),
@delimiter CHAR(2)
)
RETURNS @IDTable TABLE (Item NVARCHAR(255) collate database_default )
AS
BEGIN
DECLARE @tempItemList NVARCHAR(MAX)
SET @tempItemList = @ItemList

DECLARE @i INT
DECLARE @Item NVARCHAR(MAX)

SET @tempItemList = REPLACE (@tempItemList, @delimiter, @delimiter)
SET @i = CHARINDEX(@delimiter, @tempItemList)

WHILE (LEN(@tempItemList) > 0)
BEGIN
IF @i = 0
SET @Item = @tempItemList
ELSE
SET @Item = LEFT(@tempItemList, @i - 1)

INSERT INTO @IDTable(Item) VALUES(@Item)

IF @i = 0
SET @tempItemList = ''''
ELSE
SET @tempItemList = RIGHT(@tempItemList, LEN(@tempItemList) - (@i + 1))

SET @i = CHARINDEX(@delimiter, @tempItemList) 
END
RETURN
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'SP_GetListParam')
begin
    Print 'Creating Stored Procedure SP_GetListParam'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure SP_GetListParam'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[SP_GetListParam]
	
@URL nvarchar(255)

AS
BEGIN

DECLARE @siteid as nvarchar(255)
	
SET @siteid = (SELECT siteid FROM dbo.RESLINK WHERE RESLINK.weburl = @URL)
	
SELECT DISTINCT ItemType FROM ResInfo WHERE Siteid = @siteid ORDER BY ItemType ASC

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'SP_GetPoolURL')
begin
    Print 'Creating Stored Procedure SP_GetPoolURL'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure SP_GetPoolURL'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[SP_GetPoolURL]

@URL nvarchar(255)

AS

BEGIN
	
	if not exists (select * from RESLINK where weburl = @URL)
	BEGIN
		SELECT '''' as siteid,'''' as resurl,'''' as nonworkdays,'''' as workhours
	END
	ELSE
	BEGIN		
		SELECT siteid,resurl,CASE (SELECT nonworkdays FROM dbo.RESLINK WHERE RESLINK.weburl = @URL) WHEN '''' THEN ''NA'' ELSE nonworkdays END as nonworkdays,workhours FROM dbo.RESLINK WHERE RESLINK.weburl = @URL
	END

END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'SP_GetResResults')
begin
    Print 'Creating Stored Procedure SP_GetResResults'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure SP_GetResResults'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[SP_GetResResults]

@from datetime,
@to datetime,
@scope nvarchar(255),
@resources varchar (MAX),
@siteid uniqueidentifier
	
AS

BEGIN

DECLARE @dtDate as datetime
DECLARE @iDaysCount as integer
DECLARE @iCount as integer
DECLARE @dtCurrDate as datetime

create table #days
(
	days_id int,
	date datetime
)
create table #resources
(
	res_name nvarchar(50)
)
create table #resresults
(
	res_name nvarchar(50),
	dtdate datetime
)
create table #results1
(
    project nvarchar(255),
    title nvarchar(255),
	assignedto nvarchar(255),
    startdate datetime,
    duedate datetime,
    workdate datetime,
    itemtype nvarchar(50),
    itemstatus nvarchar(50),
    work float
    
)


Set @iDaysCount = datediff("d",@from,@to) + 1
Set @dtCurrDate = @from
Set @iCount = 1

WHILE @iCount < @iDaysCount + 1
BEGIN

	INSERT INTO #days VALUES (@iCount,@dtCurrDate)
	SET @iCount = @iCount + 1
	SET @dtCurrDate = DATEADD("d",1,@dtCurrDate)

END

DECLARE @ResName as nvarchar(50)
DECLARE ResCursor CURSOR FOR 
	
SELECT DISTINCT AssignedTo FROM RESINFO

OPEN ResCursor

FETCH NEXT FROM ResCursor INTO @ResName

WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO #resources VALUES (@ResName)
		FETCH NEXT FROM ResCursor INTO  @ResName
	END
CLOSE ResCursor   
DEALLOCATE ResCursor

insert #resresults
SELECT #resources.res_name,#days.date FROM #days INNER JOIN #resources ON #days.days_id >=0
WHERE #resources.res_name IN (SELECT Item FROM dbo.Split (@Resources, '';#''))

insert #results1
SELECT RESINFO.Project as Project, RESINFO.Title as Title,RESINFO.AssignedTo as AssignedTo,RESINFO.StartDate as StartDate,RESINFO.DueDate as DueDate,#resresults.dtdate AS WorkDate,RESINFO.ItemType as ItemType,RESINFO.Status as ItemStatus,RESINFO.Work as Work
FROM #resresults INNER JOIN RESINFO ON CONVERT(datetime,#resresults.dtdate,101) BETWEEN CONVERT(datetime,RESINFO.StartDate,101) AND CONVERT(datetime,RESINFO.DueDate,101) AND RESINFO.AssignedTo = #resresults.res_name
WHERE ItemType IN (SELECT Item FROM dbo.Split (@Scope, '';#'')) AND RESINFO.AssignedTo IN (SELECT Item FROM dbo.Split (@Resources, '';#'')) AND RESINFO.siteid = @siteid

SELECT #results1.project as Project,#results1.title as Title,#resresults.res_name as AssignedTo,#results1.startdate as StartDate,#results1.duedate as DueDate,#resresults.dtdate as WorkDate,#results1.itemtype as ItemType,#results1.itemstatus as ItemStatus,#results1.work as Work,DATEADD(dd, 1 - DATEPART(dw, #resresults.dtdate),#resresults.dtdate) as WeekDate,month(#resresults.dtdate) as MonthNum,year(#resresults.dtdate) AS YearNum
FROM #resresults LEFT JOIN #results1 ON CONVERT(datetime,#resresults.dtdate,101) = CONVERT(datetime,#results1.workdate,101) AND #results1.assignedto = #resresults.res_name
ORDER BY #resresults.dtdate ASC


drop table #resresults
drop table #results1
drop table #days
drop table #resources

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spCheckFields')
begin
    Print 'Creating Stored Procedure spCheckFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spCheckFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spCheckFields]

as

begin

SELECT     *
FROM         CustomFields
WHERE     (editable = 1)
and visible=1
END')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spHideField')
begin
    Print 'Creating Stored Procedure spHideField'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spHideField'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spHideField]

@fieldname varchar(255),
@isPj bit,
@type int

AS
BEGIN

if @isPj = 1
begin
	update customfields set pjvisible = 0 where fieldname=@fieldname
end
else
begin
	update customfields set visible = 0 where fieldname=@fieldname
end

declare @visible bit
declare @pjvisible bit

set @visible = 0
set @pjvisible = 0

select @visible=visible, @pjvisible=pjvisible from customfields where fieldname=@fieldname

if @visible = 0 and @pjvisible = 0 and (@type = 3)
begin

	delete from customfields where fieldname=@fieldname

end


END')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spINTGetQueue')
begin
    Print 'Creating Stored Procedure spINTGetQueue'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spINTGetQueue'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spINTGetQueue]

@servername varchar(255)

AS
BEGIN

;WITH CTE AS 
( 
SELECT TOP 1 * 
FROM INT_EVENTS 
WHERE STATUS = 0 and QUEUE is null
order by event_time
) 
UPDATE CTE SET QUEUE=@servername

SELECT DISTINCT 
                      dbo.INT_EVENTS.INT_EVENT_ID, dbo.INT_EVENTS.LIST_ID, dbo.INT_EVENTS.ITEM_ID, dbo.INT_EVENTS.COL_ID, dbo.INT_EVENTS.STATUS, 
                      dbo.INT_EVENTS.QUEUE, dbo.INT_EVENTS.EVENT_TIME, dbo.INT_LISTS.WEB_ID, dbo.INT_LISTS.SITE_ID, dbo.INT_EVENTS.DIRECTION, dbo.INT_EVENTS.TYPE, dbo.INT_EVENTS.INTITEM_ID
FROM         dbo.INT_EVENTS INNER JOIN
                      dbo.INT_LISTS ON dbo.INT_EVENTS.LIST_ID = dbo.INT_LISTS.LIST_ID
WHERE STATUS = 0 and QUEUE = @servername

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'SPIntSetProperty')
begin
    Print 'Creating Stored Procedure SPIntSetProperty'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure SPIntSetProperty'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE SPIntSetProperty

@intlistid uniqueidentifier,
@property varchar(255),
@value varchar(255)

AS
BEGIN
	
	declare @count int
	set @count = 0
	
	select @count = COUNT(*) from INT_PROPS where INT_LIST_ID=@intlistid and [PROPERTY] = @property
	
	if @count = 0
	begin
		insert into INT_PROPS (INT_LIST_ID, PROPERTY, VALUE) VALUES (@intlistid, @property, @value)
	end 
	else
	begin
	
		update INT_PROPS set VALUE=@value where INT_LIST_ID=@intlistid and PROPERTY = @property
	
	end
	
	
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spNDeleteNotification')
begin
    Print 'Creating Stored Procedure spNDeleteNotification'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spNDeleteNotification'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spNDeleteNotification]

@listid uniqueidentifier,
@itemid int

AS
BEGIN

delete from PERSONALIZATIONS where FK in (SELECT ID from NOTIFICATIONS where ListID=@listid and ItemID=@itemid)
delete from NOTIFICATIONS where ListID=@listid and ItemID=@itemid

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spNGetNotifications')
begin
    Print 'Creating Stored Procedure spNGetNotifications'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spNGetNotifications'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spNGetNotifications] 
      -- Add the parameters for the stored procedure here
      @UserName NVARCHAR(255),
      @UserId NVARCHAR(255),
      @SiteId UNIQUEIDENTIFIER, 
      @SiteCreationDateTime DATETIME,
      @IsUserSiteCollectionAdmin BIT = 0,
      @NotificationStatus VARCHAR(4) = ''ALL'',
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
    
    IF @NotificationStatus = ''NEW'' SET @GetRead = 0
    ELSE IF @NotificationStatus = ''OLD'' SET @GetRead = 1
    
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
                                                      WHERE ([Key] = ''Notifications'') AND (UserId = @UserName)))
                  
                  OPEN NotificationCursor
                 FETCH NEXT FROM NotificationCursor INTO @NotificationId
                  
                  WHILE @@FETCH_STATUS = 0
                  BEGIN
                        EXECUTE dbo.spNTranslateNotificationToPersonalization @NotificationId, @UserId, @UserName
                        FETCH NEXT FROM NotificationCursor INTO @NotificationId
                  END
                  
                  CLOSE NotificationCursor
                  DEALLOCATE NotificationCursor
            
                  SELECT ID, Title, Message, CAST(Type AS INT) AS Type, CAST(CreatedBy AS INT) AS CreatedBy, SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, NotificationRead, PersonalizationID, 
                           PersonalizationSiteID, UserName 
                  FROM
                  (
                        SELECT            TOP (COALESCE(@Limit, @MaxInt)) ROW_NUMBER() OVER(ORDER BY CreatedAt) AS Row, ID, Title, Message, Type, CreatedBy, SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, NotificationRead, PersonalizationID, 
                                          PersonalizationSiteID, UserName
                        FROM        (SELECT           ID, Title, Message, Type, CreatedBy, SiteCreationDateTime AS SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, 
                                                            NotificationRead, PersonalizationID, PersonalizationSiteID, UserName
                                          FROM       dbo.vwNotifications
                                          WHERE            (Type = 0) AND ((UserName = @UserName) OR (UserName = @UserId)) AND 
                                                                  (SiteID = ''00000000-0000-0000-0000-000000000000'' OR SiteID IS NULL OR SiteID = @SiteId) AND 
                                                                  (SiteCreationDate IS NULL OR @SiteCreationDate <= SiteCreationDate) OR
                                                            (Type = 1) AND ((UserName = @UserName) OR (UserName = @UserId)) AND 
                                                                  (SiteID = ''00000000-0000-0000-0000-000000000000'' OR SiteID IS NULL OR SiteID = @SiteId) AND 
                                                                  (SiteCreationDate IS NULL OR @SiteCreationDate <= SiteCreationDate) OR
                                                            (Type > 1) AND 
                                                                  (SiteCreationDate IS NULL OR @SiteCreationDate <= SiteCreationDate) AND 
                                                                  ((UserName = @UserName) OR (UserName = @UserId)) AND 
                                                                  (PersonalizationSiteID = ''00000000-0000-0000-0000-000000000000'' OR PersonalizationSiteID IS NULL OR PersonalizationSiteID = @SiteId)) AS Notifications
                        WHERE       (@GetRead = 0) AND (NotificationRead = 0 OR NotificationRead IS NULL) OR
                                          (@GetRead = 1) AND (NotificationRead = 1) OR 
                                          (@GetRead IS NULL) AND (NotificationRead IN (0, 1) OR NotificationRead IS NULL)
                  ) AS Notifications
                  WHERE Row BETWEEN COALESCE(@FirstPage, 0) AND COALESCE(@LastPage, @MaxInt)
            END
      ELSE
            BEGIN
                  DECLARE NotificationCursor CURSOR FAST_FORWARD FOR
                        SELECT      ID 
                        FROM  dbo.NOTIFICATIONS 
                        WHERE Type = 0 AND 
                                    (ID NOT IN (SELECT      FK 
                                                      FROM  dbo.PERSONALIZATIONS
                                                      WHERE ([Key] = ''Notifications'') AND (UserId = @UserName)))
                  
                  OPEN NotificationCursor
                  FETCH NEXT FROM NotificationCursor INTO @NotificationId
                  
                  WHILE @@FETCH_STATUS = 0
                  BEGIN
                        EXECUTE dbo.spNTranslateNotificationToPersonalization @NotificationId, @UserId, @UserName
                        FETCH NEXT FROM NotificationCursor INTO @NotificationId
                  END
                  
                  CLOSE NotificationCursor
                  DEALLOCATE NotificationCursor
                  
                  SELECT ID, Title, Message, CAST(Type AS INT) AS Type, CAST(CreatedBy AS INT) AS CreatedBy, SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, NotificationRead, PersonalizationID, 
                           PersonalizationSiteID, UserName 
                  FROM
                  (
                        SELECT            TOP (COALESCE(@Limit, 2147483647)) ROW_NUMBER() OVER(ORDER BY CreatedAt) AS Row, ID, Title, Message, Type, CreatedBy, SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, NotificationRead, PersonalizationID, 
                                          PersonalizationSiteID, UserName
                        FROM        (SELECT           ID, Title, Message, Type, CreatedBy, SiteCreationDateTime AS SiteCreationDate, CreatedAt, SiteID, WebID, ListID, ItemID, Emailed, Flags, UserEmailed, 
                                                            NotificationRead, PersonalizationID, PersonalizationSiteID, UserName
                                          FROM       dbo.vwNotifications
                                          WHERE            (Type = 0) AND ((UserName = @UserName) OR (UserName = @UserId)) AND 
                                                                  (SiteID = ''00000000-0000-0000-0000-000000000000'' OR SiteID IS NULL OR SiteID = @SiteId) AND 
                                                                  (SiteCreationDate IS NULL OR @SiteCreationDate <= SiteCreationDate) OR
                                                            (Type > 1) AND 
                                                                  (SiteCreationDate IS NULL OR @SiteCreationDate <= SiteCreationDate) AND 
                                                                  ((UserName = @UserName) OR (UserName = @UserId)) AND 
                                                                  (PersonalizationSiteID = ''00000000-0000-0000-0000-000000000000'' OR PersonalizationSiteID IS NULL OR PersonalizationSiteID = @SiteId)) AS Notifications
                        WHERE       (@GetRead = 0) AND (NotificationRead = 0 OR NotificationRead IS NULL) OR
                                          (@GetRead = 1) AND (NotificationRead = 1) OR 
                                          (@GetRead IS NULL) AND (NotificationRead IN (0, 1) OR NotificationRead IS NULL)
                        ) AS Notifications
                  WHERE Row BETWEEN COALESCE(@FirstPage, 0) AND COALESCE(@LastPage, @MaxInt)
            END
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spNSetBit')
begin
    Print 'Creating Stored Procedure spNSetBit'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spNSetBit'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spNSetBit]

@userid varchar(255),
@FK uniqueidentifier,
@index int,
@val bit

AS
BEGIN

declare @value varchar(max)
declare @newval varchar(max)
set @newval = ''''
select @value=value from PERSONALIZATIONS where FK=@FK and UserId = @userid

Declare @counter int

Set @counter = 1

While @counter <= LEN(@value)

Begin

    if @counter = @index 
    begin
		set @newval = @newval + convert(varchar(1), @val)
    end
    else
    begin
		set @newval = @newval + Substring(@value, @counter, 1)
    end
    
     

    Set @counter = @counter + 1

End

update PERSONALIZATIONS set Value=@newval where FK=@FK and UserId = @userid


END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spNTranslateNotificationToPersonalization')
begin
    Print 'Creating Stored Procedure spNTranslateNotificationToPersonalization'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spNTranslateNotificationToPersonalization'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spNTranslateNotificationToPersonalization] 
	-- Add the parameters for the stored procedure here
	@NotificationId UNIQUEIDENTIFIER,
	@UserId NVARCHAR(255),
	@UserName NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    IF NOT EXISTS(SELECT Id FROM dbo.PERSONALIZATIONS WHERE ([Key] = ''Notifications'') AND (FK = @NotificationId) AND ((UserId = @UserName) OR (UserId = @UserId)))
	BEGIN
		DECLARE @User NVARCHAR(255)
		IF (SELECT dbo.NOTIFICATIONS.Type FROM dbo.NOTIFICATIONS WHERE dbo.NOTIFICATIONS.ID = @NotificationId) > 1
			SET @User = @UserId
		ELSE
			SET @User = @UserName
		
		INSERT INTO dbo.PERSONALIZATIONS ([Key], Value, UserId, FK) VALUES (''Notifications'', ''00'', @User, @NotificationId)
	END
END


')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spQueueTimerJobs')
begin
    Print 'Creating Stored Procedure spQueueTimerJobs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spQueueTimerJobs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spQueueTimerJobs]

AS
BEGIN

declare @dtRun datetime 
declare @hour int
declare @dayofweek int
declare @day int

set @dtRun = GETDATE()
set @hour = DATEPART(HOUR, @dtRun)
set @dayofweek = DATEPART(weekday , @dtRun) - 1
set @day = DATEPART(DAY, @dtRun)

-------------------------------------Monthly Jobs--------------------------------------
update TIMERJOBS set lastqueuecheck = @dtRun
WHERE
(lastqueuecheck is null or DATEDIFF(HOUR, lastqueuecheck, @dtRun) > 23)
AND (runtime = @hour)
AND ([days] = @day)
AND scheduletype = 3
-------------------------------------Daily Jobs--------------------------------------
update TIMERJOBS set lastqueuecheck = @dtRun
WHERE
(lastqueuecheck is null or DATEDIFF(MINUTE, lastqueuecheck, @dtRun) > 60)
AND (runtime = @hour)
AND ([days] is null or [days] like ''%'' + convert(char(1), @dayofweek) + ''%'')	
AND scheduletype = 2
-------------------------------------Hourly Jobs--------------------------------------
update TIMERJOBS set lastqueuecheck = @dtRun
WHERE
(lastqueuecheck is null or DATEDIFF(MINUTE, lastqueuecheck, @dtRun) > 59)
AND (enabled = 1) 
AND scheduletype = 1
-------------------------------------Delete old jobs----------------------------------
delete from TIMERJOBS where timerjobuid in (select timerjobuid from vwQueueTimerLog where DateAdd(day, 1, dtfinished) < GETDATE() and scheduletype = 0)

-------------------------------------Transfer to Queue----------------------------------

Declare @timerjobuid uniqueidentifier
Declare @parentjobuid uniqueidentifier
declare @jobtype int

DECLARE Cursor1 CURSOR FOR 
	SELECT timerjobuid, jobtype, parentjobuid
	FROM vwQueueTimerLog
	WHERE lastqueuecheck = @dtRun
	AND (status = 2 or status is null)
	
OPEN Cursor1

FETCH NEXT FROM Cursor1 
INTO @timerjobuid, @jobtype, @parentjobuid

WHILE @@FETCH_STATUS = 0
BEGIN

	declare @parentid uniqueidentifier
	set @parentid = null
	
	select @parentid = timerjobuid from vwQueueTimerLog
		where timerjobuid = @parentjobuid and lastqueuecheck = @dtRun
	
	delete from QUEUE where timerjobuid = @timerjobuid
	
	if @parentid is null
	begin
	
		insert into QUEUE (timerjobuid, [status], percentComplete) VALUES (@timerjobuid, 0, 0)
	
	end
	else
	begin
	
		insert into QUEUE (timerjobuid, [status], percentComplete) VALUES (@timerjobuid, 1, 0)
	
	end


	FETCH NEXT FROM Cursor1 
	INTO @timerjobuid, @jobtype, @parentjobuid

 END
 
 CLOSE Cursor1
DEALLOCATE Cursor1
------------------------------------------------------------------------------------------------------


END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRetrieveProjGuid')
begin
    Print 'Creating Stored Procedure spRetrieveProjGuid'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRetrieveProjGuid'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRetrieveProjGuid]

@webid varchar(255)	

as

begin

SELECT     projectguid, pubType
FROM         publishercheck
WHERE     (webguid = @webid)
END')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRetrieveWebURL')
begin
    Print 'Creating Stored Procedure spRetrieveWebURL'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRetrieveWebURL'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRetrieveWebURL]

@projid varchar(255)	

as

SELECT     weburl
FROM         publishercheck
WHERE     (projectguid = @projid)')



if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spSecGetQueue')
begin
    Print 'Creating Stored Procedure spSecGetQueue'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spSecGetQueue'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spSecGetQueue]

@servername varchar(255),
@maxthreads varchar(2)

AS
BEGIN

declare @sql varchar(MAX)

set @sql = '';WITH CTE AS 
( 
SELECT TOP '' + @maxthreads + '' * 
FROM ITEMSEC 
WHERE QUEUE is null and STATUS = 0
order by case when USER_ID=1073741823 then 1 else 0 end, priority, dtadded
) 
UPDATE CTE SET QUEUE='''''' + @servername + ''''''''


exec(@sql)


SELECT * FROM ITEMSEC WHERE QUEUE = @servername and status = 0

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spShowField')
begin
    Print 'Creating Stored Procedure spShowField'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spShowField'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spShowField]

@fieldname varchar(255),
@displayname varchar(255),
@wssfieldname varchar(255),
@fieldtype varchar(255),
@assnfieldname varchar(255),
@isPj bit,
@fieldcategory int,
@assnupdatefield varchar(255) = null

AS
BEGIN

declare @fname varchar(255)

set @fname = ''''

select @fname=fieldname from customfields where fieldname=@fieldname

if @fname = ''''
begin

	if @isPj = 1
	begin
		INSERT INTO customfields (fieldname,editable,displayname,fieldcategory,wssfieldname,pjvisible,fieldtype,assnfieldname,assnupdatecolumnid)
		VALUES (@fieldname,0,@displayname,@fieldcategory,@wssfieldname,1,@fieldtype,@assnfieldname,@assnupdatefield)
	end
	else
	begin
		INSERT INTO customfields (fieldname,editable,displayname,fieldcategory,wssfieldname,visible,fieldtype,assnfieldname,assnupdatecolumnid)
		VALUES (@fieldname,0,@displayname,@fieldcategory,@wssfieldname,1,@fieldtype,@assnfieldname,@assnupdatefield)
	end

end
else
begin

	if @isPj = 1
	begin
		update customfields set pjvisible = 1 where fieldname=@fieldname
	end
	else
	begin
		update customfields set visible = 1 where fieldname=@fieldname
	end


end

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSAllData')
begin
    Print 'Creating Stored Procedure spTSAllData'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSAllData'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[spTSAllData]
                @siteuid uniqueidentifier
AS
declare @colname varchar(255)
declare @cols varchar(MAX)

set @cols = ''''


DECLARE colsCursors CURSOR FOR 
SELECT distinct columnname
from vwmeta
where site_id = @siteuid
OPEN colsCursors

FETCH NEXT FROM colsCursors 
INTO @colname

WHILE @@FETCH_STATUS = 0
BEGIN

set @cols = @cols + '',['' + @colname + '']''

FETCH NEXT FROM colsCursors 
INTO @colname

END

CLOSE colsCursors
DEALLOCATE colsCursors


if @cols <> ''''
begin
	declare @sql varchar(MAX)

	set @sql = ''SELECT Username, [Resource Name], [Item Name], [Project], [Item Type], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '''' - '''' + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status], [Approval Notes], [lastmodifiedbyn] as [Last Modified By], [TS_ITEM_NOTES] as [Item Notes]''


	set @sql = @sql + @cols
	set @sql = @sql + '', [Item UID], [Timesheet UID] FROM ''
	set @sql = @sql + ''(SELECT Username, [Resource Name], [Item UID], [Item Name], [Project], [Item Type], [Timesheet UID], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], [Submitted], [Approval Status], [Approval Notes],[lastmodifiedbyn], [TS_ITEM_NOTES], columnname, columnvalue,site_id
	FROM vwmeta ) ps
	PIVOT
	(
	min (columnvalue)
	FOR columnname IN
	(''

	set @sql = @sql + substring(@cols,2,len(@cols)-1)

	set @sql = @sql + '')''
	set @sql = @sql + '') AS pvt where site_id = '''''' + convert(varchar(50),@siteuid) + ''''''''

end
else
begin

	set @sql = ''SELECT Username, [Resource Name], [Item Name], [Project], [Item Type], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '''' - '''' + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status], [Approval Notes], [lastmodifiedbyn] as [Last Modified By], [TS_ITEM_NOTES] from vwmeta where site_id = '''''' + convert(varchar(50),@siteuid) + ''''''''

end


--print @sql
--print @cols

exec(@sql)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSData')
begin
    Print 'Creating Stored Procedure spTSData'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSData'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[spTSData]
	@siteuid uniqueidentifier,
	@username varchar(MAX),
	@start datetime,
	@end datetime
AS

declare @colname varchar(255)
declare @cols varchar(MAX)

set @cols = ''''


DECLARE colsCursors CURSOR FOR 
SELECT distinct columnname
FROM         dbo.TSTIMESHEET INNER JOIN
                      dbo.TSITEM ON dbo.TSTIMESHEET.TS_UID = dbo.TSITEM.TS_UID INNER JOIN
                      dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID
WHERE site_uid = @siteuid

OPEN colsCursors

FETCH NEXT FROM colsCursors 
INTO @colname

WHILE @@FETCH_STATUS = 0
BEGIN

set @cols = @cols + '',['' + @colname + '']''

FETCH NEXT FROM colsCursors 
INTO @colname

END

CLOSE colsCursors
DEALLOCATE colsCursors



declare @sql varchar(MAX)

if @cols <> ''''
begin

	set @sql = ''SELECT Username, [Resource Name], [Item Name], [Project], [Item Type], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '''' - '''' + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status], [Approval Notes], [lastmodifiedbyn] as [Last Modified By], [TS_ITEM_NOTES] as [Item Notes]''


	set @sql = @sql + @cols
	set @sql = @sql + '', [Item UID], [Timesheet UID] FROM ''
	set @sql = @sql + ''(SELECT Username, [Resource Name], [Item UID], [Item Name], [Project], [Item Type], [Timesheet UID], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], [Submitted], [Approval Status], [Approval Notes],[lastmodifiedbyn], [TS_ITEM_NOTES], columnname, columnvalue,site_id
	FROM vwmeta ) ps
	PIVOT
	(
	min (columnvalue)
	FOR columnname IN
	(''

	set @sql = @sql + substring(@cols,2,len(@cols)-1)

	set @sql = @sql + '')''
	set @sql = @sql + '') AS pvt where username in (SELECT Item FROM dbo.Split ('''''' + @username + '''''', '''';#'''')) and [Date] >= '''''' + convert(varchar(50),@start,102) + '''''' and [Date] <= '''''' + convert(varchar(50),@end,102) + '''''' and site_id = '''''' + convert(varchar(50),@siteuid) + ''''''''
end
else
begin

	set @sql = ''SELECT Username, [Resource Name], [Item Name], [Project], [Item Type], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '''' - '''' + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status], [Approval Notes], [lastmodifiedbyn] as [Last Modified By], [TS_ITEM_NOTES] from vwmeta where site_id = '''''' + convert(varchar(50),@siteuid) + ''''''''

end
--print @sql
--print @cols

exec(@sql)
')
 


if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSGetApprovedTimesheets')
begin
    Print 'Creating Stored Procedure spTSGetApprovedTimesheets'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSGetApprovedTimesheets'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSGetApprovedTimesheets]

@siteguid uniqueidentifier,
@dtapproved datetime

AS
BEGIN

SELECT     USERNAME, PROJECT_ID, WEB_UID, TS_ITEM_DATE, 
                      SUM(TS_ITEM_HOURS) as TotalHours, PERIOD_START, PERIOD_END, PROJECT_LIST_UID, 
                      TYPEID, TSTYPE_NAME, LIST, LIST_UID
FROM (
SELECT     dbo.TSTIMESHEET.USERNAME, case when PROJECT_ID = 0 then ITEM_ID else dbo.TSITEM.PROJECT_ID end as PROJECT_ID, dbo.TSITEM.WEB_UID, dbo.TSITEMHOURS.TS_ITEM_DATE, 
                      dbo.TSITEMHOURS.TS_ITEM_HOURS, dbo.TSPERIOD.PERIOD_START, dbo.TSPERIOD.PERIOD_END, case when PROJECT_LIST_UID IS NULL then LIST_UID else dbo.TSITEM.PROJECT_LIST_UID end as PROJECT_LIST_UID, 
                      COALESCE (dbo.TSTYPE.TYPEID, 1) AS TYPEID, dbo.TSTYPE.TSTYPE_NAME, LIST, LIST_UID
FROM         dbo.TSTIMESHEET INNER JOIN
                      dbo.TSITEM ON dbo.TSTIMESHEET.TS_UID = dbo.TSITEM.TS_UID INNER JOIN
                      dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID INNER JOIN
                      dbo.TSPERIOD ON dbo.TSTIMESHEET.PERIOD_ID = dbo.TSPERIOD.PERIOD_ID AND dbo.TSTIMESHEET.SITE_UID = dbo.TSPERIOD.SITE_ID LEFT OUTER JOIN
                      dbo.TSTYPE ON dbo.TSTIMESHEET.SITE_UID = dbo.TSTYPE.SITE_UID AND dbo.TSITEMHOURS.TS_ITEM_TYPE_ID = dbo.TSTYPE.TSTYPE_ID
        where TSTIMESHEET.SITE_UID = @siteguid and APPROVAL_DATE >= @dtapproved              
                      ) AS A
GROUP BY PROJECT_ID, TS_ITEM_DATE, USERNAME, WEB_UID, PERIOD_START, 
                      PERIOD_END, PROJECT_LIST_UID, TYPEID, TSTYPE_NAME, PROJECT_LIST_UID, PROJECT_ID, LIST, LIST_UID
ORDER BY USERNAME, PERIOD_START


END
')

if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSGetPeriodsForSite')
begin
    Print 'Creating Stored Procedure spTSGetPeriodsForSite'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSGetPeriodsForSite'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSGetPeriodsForSite]

@siteid nvarchar(50)

AS
BEGIN

SELECT     DISTINCT tsperiod.period_id, convert(varchar(15),[Period_Start],107) + '' - '' + convert(varchar(15),[Period_End],107) as [Period], [Period_Start], [Period_End],
	 case when [Period_Start] <= DateAdd(Day, Datediff(Day,0, GetDate()), 0) AND [Period_End] >= DateAdd(Day, Datediff(Day,0, GetDate()), 0) then 1 else 0 end as CurPeriod
FROM         dbo.TSPERIOD
where site_id = @siteid and LOCKED = 0
order by period_id

END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSGetPeriodsInfo')
begin
    Print 'Creating Stored Procedure spTSGetPeriodsInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSGetPeriodsInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSGetPeriodsInfo]

@siteid uniqueidentifier

AS
BEGIN

create table #allts
(
	period_id int,
	tscount int
)

create table #subts
(
	period_id int,
	tscount int
)


insert #allts
SELECT     PERIOD_ID, COUNT(TS_UID) AS tscount
FROM         dbo.TSTIMESHEET
WHERE site_uid = @siteid
GROUP BY PERIOD_ID 

insert #subts
SELECT     PERIOD_ID, COUNT(TS_UID) AS tscount
FROM         dbo.TSTIMESHEET
where submitted = 1 and site_uid = @siteid
GROUP BY PERIOD_ID

SELECT     tsperiod.period_id, period_start, period_end, tsperiod.locked, coalesce(#allts.tscount,0) as saved, coalesce(#subts.tscount,0) as submitted
FROM         dbo.TSPERIOD left outer JOIN
                      #allts ON TSPERIOD.PERIOD_ID = #allts.PERIOD_ID left outer JOIN
                      #subts ON TSPERIOD.PERIOD_ID = #subts.PERIOD_ID
where site_id = @siteid
order by period_id

drop table #allts
drop table #subts

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSGetProjectsHours')
begin
    Print 'Creating Stored Procedure spTSGetProjectsHours'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSGetProjectsHours'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSGetProjectsHours]

@tsuid uniqueidentifier,
@approved bit

AS
BEGIN

if @approved = 1
begin

	SELECT     COALESCE (dbo.TSITEM.PROJECT_ID, '''') AS project_id, SUM(TSITEMHOURS_1.TS_ITEM_HOURS) AS Hours, dbo.TSITEM.WEB_UID, dbo.TSITEM.PROJECT_LIST_UID, 
                      SUM(TSITEMHOURS_1.TS_ITEM_HOURS) AS Expr1
FROM         dbo.TSITEMHOURS AS TSITEMHOURS_1 INNER JOIN
                      dbo.TSITEM AS TSITEM_1 ON TSITEMHOURS_1.TS_ITEM_UID = TSITEM_1.TS_ITEM_UID INNER JOIN
                      dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID ON TSITEM_1.WEB_UID = dbo.TSITEM.WEB_UID AND 
                      TSITEM_1.LIST_UID = dbo.TSITEM.LIST_UID AND TSITEM_1.ITEM_ID = dbo.TSITEM.ITEM_ID
	WHERE     (TSTIMESHEET.TS_UID = @tsuid) AND (dbo.TSTIMESHEET.APPROVAL_STATUS = 1)
	GROUP BY dbo.TSITEM.PROJECT_id, dbo.TSITEM.WEB_UID, dbo.TSTIMESHEET.APPROVAL_STATUS, dbo.TSITEM.PROJECT_LIST_UID

end
else
begin

	SELECT     COALESCE (dbo.TSITEM.PROJECT_ID, '''') AS project_id, SUM(TSITEMHOURS_1.TS_ITEM_HOURS) AS Hours, dbo.TSITEM.WEB_UID, dbo.TSITEM.PROJECT_LIST_UID, 
                      SUM(TSITEMHOURS_1.TS_ITEM_HOURS) AS Expr1
FROM         dbo.TSITEMHOURS AS TSITEMHOURS_1 INNER JOIN
                      dbo.TSITEM AS TSITEM_1 ON TSITEMHOURS_1.TS_ITEM_UID = TSITEM_1.TS_ITEM_UID INNER JOIN
                      dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID ON TSITEM_1.WEB_UID = dbo.TSITEM.WEB_UID AND 
                      TSITEM_1.LIST_UID = dbo.TSITEM.LIST_UID AND TSITEM_1.ITEM_ID = dbo.TSITEM.ITEM_ID
	WHERE     (TSTIMESHEET.TS_UID = @tsuid) 
	GROUP BY dbo.TSITEM.PROJECT_id, dbo.TSITEM.WEB_UID, dbo.TSTIMESHEET.APPROVAL_STATUS, dbo.TSITEM.PROJECT_LIST_UID
end
end')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSGetSubmittedHoursForItem')
begin
    Print 'Creating Stored Procedure spTSGetSubmittedHoursForItem'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSGetSubmittedHoursForItem'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[spTSGetSubmittedHoursForItem]

@siteguid uniqueidentifier,
@listuid uniqueidentifier,
@itemid int

AS
BEGIN


SELECT     SUM(dbo.TSITEMHOURS.TS_ITEM_HOURS) AS hours, dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID
FROM         dbo.TSITEMHOURS INNER JOIN
                      dbo.TSITEM ON dbo.TSITEMHOURS.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
WHERE     (SITE_UID = @siteguid) and list_uid=@listuid and item_id=@itemid and (dbo.TSTIMESHEET.SUBMITTED = 1)
GROUP BY dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID


END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSGetTimesheet')
begin
    Print 'Creating Stored Procedure spTSGetTimesheet'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSGetTimesheet'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSGetTimesheet]

@tsuid uniqueidentifier

AS
BEGIN

--0------------------TSUID-------------------
select @tsuid as tsuid

--1--------------------Timesheet---------------------
select * from TSTIMESHEET where TS_UID = @tsuid

--2--------------------Item---------------------
select * from TSITEM where TS_UID = @tsuid

--3--------------------Hours---------------------
SELECT     dbo.TSITEMHOURS.TS_ITEM_DATE, dbo.TSITEMHOURS.TS_ITEM_HOURS, dbo.TSITEMHOURS.TS_ITEM_TYPE_ID, dbo.TSTYPE.TSTYPE_NAME, dbo.TSTYPE.TYPEID, dbo.TSITEM.TS_ITEM_UID
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID LEFT OUTER JOIN
                      dbo.TSTYPE ON dbo.TSTIMESHEET.SITE_UID = dbo.TSTYPE.SITE_UID AND dbo.TSITEMHOURS.TS_ITEM_TYPE_ID = dbo.TSTYPE.TSTYPE_ID
where TSTIMESHEET.TS_UID = @tsuid
--4--------------------Notes---------------------
SELECT     dbo.TSNOTES.TS_ITEM_UID, dbo.TSNOTES.TS_ITEM_DATE, dbo.TSNOTES.TS_ITEM_NOTES
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID INNER JOIN
                      dbo.TSNOTES ON dbo.TSITEM.TS_ITEM_UID = dbo.TSNOTES.TS_ITEM_UID
WHERE TSTIMESHEET.TS_UID = @tsuid
--5-------------------Meta-----------------------
SELECT     dbo.TSMETA.TS_ITEM_UID, dbo.TSMETA.ColumnName, dbo.TSMETA.DisplayName, dbo.TSMETA.ColumnValue, dbo.TSMETA.ListName
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID INNER JOIN
                      dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID
WHERE TSTIMESHEET.TS_UID = @tsuid
--6-------------------Other Hours
SELECT     SUM(dbo.TSITEMHOURS.TS_ITEM_HOURS) AS OtherHours, TSITEM_1.LIST_UID, TSITEM_1.ITEM_ID
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID INNER JOIN
                      dbo.TSITEM AS TSITEM_1 ON dbo.TSITEM.LIST_UID = TSITEM_1.LIST_UID AND dbo.TSITEM.ITEM_ID = TSITEM_1.ITEM_ID INNER JOIN
                      dbo.TSITEMHOURS ON TSITEM_1.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET AS TSTIMESHEET_1 ON TSITEM_1.TS_UID = TSTIMESHEET_1.TS_UID
WHERE     (dbo.TSTIMESHEET.TS_UID = @tsuid) AND (TSTIMESHEET_1.TS_UID <> @tsuid)
GROUP BY TSITEM_1.LIST_UID, TSITEM_1.ITEM_ID
--7---------------------Types
SELECT     dbo.TSTYPE.TSTYPE_ID, dbo.TSTYPE.TSTYPE_NAME, dbo.TSTYPE.TYPEID
FROM         dbo.TSTIMESHEET INNER JOIN
                      dbo.TSTYPE ON dbo.TSTIMESHEET.SITE_UID = dbo.TSTYPE.SITE_UID
WHERE     (dbo.TSTIMESHEET.TS_UID = @tsuid)
--8---------------------Period Info
SELECT     dbo.TSPERIOD.PERIOD_START, dbo.TSPERIOD.PERIOD_END, dbo.TSPERIOD.LOCKED
FROM         dbo.TSTIMESHEET INNER JOIN
                      dbo.TSPERIOD ON dbo.TSTIMESHEET.PERIOD_ID = dbo.TSPERIOD.PERIOD_ID AND dbo.TSTIMESHEET.SITE_UID = dbo.TSPERIOD.SITE_ID
WHERE     (dbo.TSTIMESHEET.TS_UID = @tsuid)
--9---------------------StopWatch
SELECT     dbo.TSSW.STARTED, TSITEM.TS_ITEM_UID
FROM         dbo.TSTIMESHEET INNER JOIN
                      dbo.TSITEM ON dbo.TSTIMESHEET.TS_UID = dbo.TSITEM.TS_UID INNER JOIN
                      dbo.TSSW ON dbo.TSITEM.TS_ITEM_UID = dbo.TSSW.TSITEMUID INNER JOIN
                      dbo.TSUSER ON dbo.TSSW.USER_ID = dbo.TSUSER.USER_ID AND dbo.TSTIMESHEET.USERNAME = dbo.TSUSER.USERNAME
WHERE     (dbo.TSTIMESHEET.TS_UID = @tsuid)
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSGetTotalHoursForItem')
begin
    Print 'Creating Stored Procedure spTSGetTotalHoursForItem'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSGetTotalHoursForItem'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[spTSGetTotalHoursForItem]

@siteguid uniqueidentifier,
@listuid uniqueidentifier,
@itemid int

AS
BEGIN


SELECT     COALESCE (SUM(dbo.TSITEMHOURS.TS_ITEM_HOURS), 0) AS hours
FROM         dbo.TSITEMHOURS INNER JOIN
                      dbo.TSITEM ON dbo.TSITEMHOURS.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
WHERE     (SITE_UID = @siteguid) and list_uid=@listuid and item_id=@itemid

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSGetTSForSite')
begin
    Print 'Creating Stored Procedure spTSGetTSForSite'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSGetTSForSite'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSGetTSForSite]

@username varchar(255),
@siteguid uniqueidentifier,
@period_id int

AS
BEGIN

SELECT     dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSITEM.TS_ITEM_UID, TSITEM.Title, TSITEM.Project, TSITEM.List
FROM         dbo.TSTIMESHEET INNER JOIN
                      dbo.TSITEM ON dbo.TSTIMESHEET.TS_UID = dbo.TSITEM.TS_UID
where period_id=@period_id and site_uid = @siteguid and username like @username
order by web_uid,list_uid


END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSgetTSHours')
begin
    Print 'Creating Stored Procedure spTSgetTSHours'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSgetTSHours'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSgetTSHours]

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

where period_id=@period_id and tstimesheet.site_uid = @siteguid and username like @username AND TS_ITEM_TYPE_ID<>0
UNION
SELECT     dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSITEMHOURS.TS_ITEM_DATE, dbo.TSITEMHOURS.TS_ITEM_HOURS, 
                      dbo.TSITEM.TS_ITEM_UID, TSTYPE_ID=0
FROM         dbo.TSITEMHOURS FULL OUTER JOIN
                      dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID ON dbo.TSITEMHOURS.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID
where period_id=@period_id and tstimesheet.site_uid = @siteguid and username like @username AND TS_ITEM_TYPE_ID=0


SELECT     dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSITEM.TS_ITEM_UID, dbo.TSNOTES.TS_ITEM_DATE, dbo.TSNOTES.TS_ITEM_NOTES
FROM         dbo.TSNOTES INNER JOIN
                      dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID ON dbo.TSNOTES.TS_ITEM_UID = dbo.TSITEM.TS_ITEM_UID
where period_id=@period_id and tstimesheet.site_uid = @siteguid and username like @username

SELECT     dbo.TSITEM.TS_ITEM_UID, dbo.TSITEM.WEB_UID, dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_TYPE, dbo.TSITEM.ITEM_ID, dbo.TSITEM.TITLE, 
                      dbo.TSITEM.PROJECT, dbo.TSITEM.LIST
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
WHERE     (dbo.TSTIMESHEET.PERIOD_ID = @period_id) AND (dbo.TSTIMESHEET.SITE_UID = @siteguid) AND (dbo.TSTIMESHEET.USERNAME LIKE @username)

SELECT     SUM(Hours) AS hours, LIST_UID, ITEM_ID
FROM         dbo.vwTSHoursByTask
WHERE     (PERIOD_ID <> @period_id OR username <> @username) AND (SITE_UID = @siteguid)
GROUP BY LIST_UID, ITEM_ID

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSGetTSMeta')
begin
    Print 'Creating Stored Procedure spTSGetTSMeta'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSGetTSMeta'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSGetTSMeta]

@username varchar(255),
@siteguid uniqueidentifier,
@period_id int

AS
BEGIN

SELECT     dbo.TSITEM.LIST_UID, dbo.TSITEM.ITEM_ID, dbo.TSMETA.ColumnName, dbo.TSMETA.ColumnValue
FROM         dbo.TSITEM INNER JOIN
                      dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID AND dbo.TSITEM.LIST = dbo.TSMETA.ListName INNER JOIN
                      dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID
where period_id=@period_id and site_uid = @siteguid and username like @username

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSReportDataFromVwMeta')
begin
    Print 'Creating Stored Procedure spTSReportDataFromVwMeta'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSReportDataFromVwMeta'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[spTSReportDataFromVwMeta]
	@siteuid nvarchar(50),
	@username varchar(MAX),
	@department varchar(MAX),
	@approvalStatus varchar(100),
	@periodID varchar(4000),
	@project varchar(MAX) = NULL
AS

declare @colname varchar(255)
declare @cols nvarchar(MAX)

-- Create source table for query 
SELECT     dbo.vwMeta.USERNAME AS Username, dbo.vwMeta.[Resource Name], dbo.vwMeta.[Item UID], 
				  dbo.vwMeta.[Item Name], dbo.vwMeta.PROJECT AS Project, dbo.vwMeta.ColumnName, 
				  dbo.vwMeta.DisplayName, dbo.vwMeta.ColumnValue, dbo.vwMeta.[Item Type], dbo.vwMeta.[Timesheet UID], 
				  dbo.vwMeta.[Period Id], dbo.vwMeta.SITE_ID, dbo.vwMeta.List, dbo.vwMeta.Date, 
				  dbo.vwMeta.Hours, dbo.vwMeta.[Type Id], dbo.vwMeta.[Type Name], 
				  dbo.vwMeta.[Period Start], dbo.vwMeta.[Period End], 
				  dbo.vwMeta.Submitted, 
				  dbo.vwMeta.[Approval Status],
				  dbo.vwMeta.[Approval Notes]
INTO #TempTimesheetData
FROM   dbo.vwMeta 
WHERE (@username IS NULL OR dbo.vwMeta.Username IN (SELECT Item FROM dbo.Split(@username, '';#'')))
	AND (@siteuid = dbo.vwMeta.SITE_ID)
	AND (@periodID IS NULL OR dbo.vwMeta.[PERIOD ID] in (SELECT Item FROM dbo.Split(@periodID, '';#'')))
	AND (@department IS NULL OR dbo.vwMeta.ColumnName <> ''Resource_Department'' OR (dbo.vwMeta.ColumnName = ''Resource_Department'' AND (dbo.vwMeta.ColumnValue IN (SELECT Item FROM dbo.Split(@department, '';#'')))))
	AND (@approvalStatus IS NULL OR dbo.vwMeta.[Approval Status] IN (SELECT Item FROM dbo.Split(@approvalStatus, '';#'')))
	AND (@project IS NULL OR dbo.vwMeta.PROJECT IN (SELECT Item FROM dbo.Split(@project, '';#'')))
	AND (dbo.vwMeta.Submitted = ''Yes'' )

IF(@@RowCount < 1)
BEGIN
	SELECT * FROM #TempTimesheetData
	--SELECT '''' AS Username, '''' AS [Resource Name], '''' AS [Item Name], '''' AS [Project], '''' AS [Item Type], '''' AS [Period Id], '''' AS List, '''' AS [Date], 0 AS [Hours], '''' AS [Type Id], '''' AS [Type Name], '''' AS [Period Start], '''' AS [Period End], '''' as [Period Name], '''' AS [Submitted], '''' AS [Approval Status], '''' AS [Approval Notes], '''' AS [Resource_StandardRate], '''' AS [Resource_Department], '''' AS [Resource_Role]
END
ELSE
BEGIN

set @cols = ''''

DECLARE colsCursors CURSOR FOR 
SELECT distinct columnname
from vwmeta
where site_id = @siteuid
OPEN colsCursors

FETCH NEXT FROM colsCursors 
INTO @colname

WHILE @@FETCH_STATUS = 0
BEGIN

set @cols = @cols + '',['' + @colname + '']''

FETCH NEXT FROM colsCursors 
INTO @colname
END

CLOSE colsCursors
DEALLOCATE colsCursors

declare @sql varchar(MAX)

set @sql = ''SELECT Username, [Resource Name], [Item Name], [Project], [Item Type], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '''' - '''' + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status], [Approval Notes] '' --, [NoteDate], [Notes] ''

--print @sql

set @sql = @sql + @cols
set @sql = @sql + '', [Item UID], [Timesheet UID] FROM ''
set @sql = @sql + ''(SELECT Username, [Resource Name], [Item UID], [Item Name], [Project], [Item Type], [Timesheet UID], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], [Submitted], [Approval Status], [Approval Notes], columnname, columnvalue,site_id FROM #TempTimesheetData )
 ps PIVOT
(
min (columnvalue)
FOR columnname IN
(''

--print @sql

set @sql = @sql + substring(@cols,2,len(@cols)-1)
--print ''2nd to last:'' + @sql

set @sql = @sql + '')''
if(@username IS NOT NULL)
BEGIN
	--set @sql = @sql + '') AS pvt where username in (SELECT Item FROM dbo.Split ('''''' + @username + '''''', '''';#'''')) and [Date] >= '''''' + convert(varchar(50),@start,102) + '''''' and [Date] <= '''''' + convert(varchar(50),@end,102) + '''''' and site_id = '''''' + convert(varchar(50),@siteuid) + ''''''''
	set @sql = @sql + '') AS pvt'' 
END
ELSE
BEGIN
	--set @sql = @sql + '') AS pvt where [Date] >= '''''' + convert(varchar(50),@start,102) + '''''' and [Date] <= '''''' + convert(varchar(50),@end,102) + '''''' and site_id = '''''' + convert(varchar(50),@siteuid) + ''''''''
	set @sql = @sql + '') AS pvt''
END
--set @sql = @sql + ''	WHERE '''''' + @department + '''''' IS NULL OR (Resource_Department IN (SELECT Item FROM dbo.Split('''''' + @department + '''''', '''';#'''')))''

--print ''Last sec:'' + @sql
--print @sql

exec(@sql)

END

DROP TABLE #TempTimesheetData
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSReportDataWithNotes')
begin
    Print 'Creating Stored Procedure spTSReportDataWithNotes'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSReportDataWithNotes'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[spTSReportDataWithNotes]
	@siteuid nvarchar(50),
	@username varchar(MAX),
	@timesheetType varchar(MAX),
	@approvalStatus varchar(100),
	@periodID varchar(4000)
AS

declare @colname varchar(255)
declare @cols nvarchar(MAX)

-- Create source table for query 
SELECT     dbo.TSTIMESHEET.USERNAME AS Username, dbo.TSTIMESHEET.RESOURCENAME AS [Resource Name], dbo.TSITEM.TS_ITEM_UID AS [Item UID], 
				  dbo.TSITEM.TITLE AS [Item Name], dbo.TSITEM.PROJECT AS Project, coalesce(dbo.TSMETA.ListName + ''_'' + dbo.TSMETA.ColumnName,''TempColumn'') AS ColumnName, 
				  dbo.TSMETA.DisplayName, dbo.TSMETA.ColumnValue, dbo.TSITEM.ITEM_TYPE AS [Item Type], dbo.TSITEM.TS_UID AS [Timesheet UID], 
				  dbo.TSPERIOD.PERIOD_ID AS [Period Id], dbo.TSPERIOD.SITE_ID, dbo.TSITEM.LIST AS List, dbo.TSITEMHOURS.TS_ITEM_DATE AS Date, 
				  dbo.TSITEMHOURS.TS_ITEM_HOURS AS Hours, dbo.TSITEMHOURS.TS_ITEM_TYPE_ID AS [Type Id], dbo.TSTYPE.TSTYPE_NAME AS [Type Name], 
				  dbo.TSPERIOD.PERIOD_START AS [Period Start], dbo.TSPERIOD.PERIOD_END AS [Period End], 
				  CASE dbo.TSTIMESHEET.SUBMITTED WHEN 0 THEN ''No'' WHEN 1 THEN ''Yes'' END AS Submitted, 
				  CASE dbo.TSTIMESHEET.APPROVAL_STATUS WHEN 0 THEN ''Pending'' WHEN 1 THEN ''Approved'' WHEN 2 THEN ''Rejected'' END AS [Approval Status],
				  CONVERT(varchar(8000), COALESCE (dbo.TSTIMESHEET.APPROVAL_NOTES, '''')) AS [Approval Notes]
				  ,dbo.TSNOTES.TS_ITEM_DATE AS [NoteDate], dbo.TSNOTES.TS_ITEM_NOTES AS [Notes], dbo.TSTIMESHEET.LASTMODIFIEDBYN AS [LastModifiedBy]
INTO #TempTimesheetData
FROM   dbo.TSITEM INNER JOIN
		  dbo.TSTIMESHEET ON dbo.TSITEM.TS_UID = dbo.TSTIMESHEET.TS_UID --INNER JOIN
		  INNER JOIN dbo.TSPERIOD ON dbo.TSTIMESHEET.PERIOD_ID = dbo.TSPERIOD.PERIOD_ID AND 
		  dbo.TSTIMESHEET.SITE_UID = dbo.TSPERIOD.SITE_ID INNER JOIN
		  dbo.TSITEMHOURS ON dbo.TSITEM.TS_ITEM_UID = dbo.TSITEMHOURS.TS_ITEM_UID LEFT OUTER JOIN
		  dbo.TSMETA ON dbo.TSITEM.TS_ITEM_UID = dbo.TSMETA.TS_ITEM_UID LEFT OUTER JOIN
		  dbo.TSTYPE ON dbo.TSTIMESHEET.SITE_UID = dbo.TSTYPE.SITE_UID AND dbo.TSITEMHOURS.TS_ITEM_TYPE_ID = dbo.TSTYPE.TSTYPE_ID
		  LEFT OUTER JOIN dbo.TSNOTES ON dbo.TSITEM.TS_ITEM_UID = dbo.TSNOTES.TS_ITEM_UID
			AND dbo.TSNOTES.TS_ITEM_DATE = dbo.TSITEMHOURS.TS_ITEM_DATE
WHERE (@username IS NULL OR dbo.TSTIMESHEET.USERNAME IN (SELECT Item FROM dbo.Split(@username, '';#'')))
	AND (@siteuid = dbo.TSTIMESHEET.SITE_UID)
	AND (@timesheetType IS NULL OR @timesheetType = ''0'' OR dbo.TSTYPE.TSTYPE_ID IN (SELECT Item FROM dbo.Split(@timesheetType, '';#'')))
	AND (@approvalStatus IS NULL OR dbo.TSTIMESHEET.APPROVAL_STATUS IN (SELECT Item FROM dbo.Split(@approvalStatus, '';#'')))
	AND (@periodID IS NULL OR dbo.TSPERIOD.PERIOD_ID in (SELECT Item FROM dbo.Split(@periodID, '';#'')))
	AND (dbo.TSTIMESHEET.SUBMITTED = 1)

IF(@@RowCount < 1)
BEGIN
	RETURN 0
END
ELSE
BEGIN


set @cols = ''''

DECLARE colsCursors CURSOR FOR 
SELECT distinct columnname
FROM #TempTimesheetData --vwMeta
WHERE site_id = @siteuid
OPEN colsCursors

FETCH NEXT FROM colsCursors 
INTO @colname

WHILE @@FETCH_STATUS = 0
BEGIN

set @cols = @cols + '',['' + @colname + '']''

FETCH NEXT FROM colsCursors 
INTO @colname
END

CLOSE colsCursors
DEALLOCATE colsCursors

--print ''COLS:'' + @cols

declare @sql varchar(MAX)

set @sql = ''SELECT Username, [Resource Name], [Item Name], [Project], [Item Type], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '''' - '''' + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status], [Approval Notes], [NoteDate], CAST([Notes] AS NVARCHAR(MAX)) AS "Notes", [LastModifiedBy] ''

--print @sql


set @sql = @sql + @cols
set @sql = @sql + '', [Item UID], [Timesheet UID] FROM ''
set @sql = @sql + ''(SELECT Username, [Resource Name], [Item UID], [Item Name], [Project], [Item Type], [Timesheet UID], [Period Id], List, [Date], [Hours], [Type Id], [Type Name], [Period Start], [Period End], [Submitted], [Approval Status], [Approval Notes], [NoteDate], CAST([Notes] AS NVARCHAR(MAX)) AS "Notes", [LastModifiedBy], columnname, columnvalue,site_id FROM #TempTimesheetData )
 ps PIVOT
(
min (columnvalue)
FOR columnname IN
(''

--print @sql

set @sql = @sql + substring(@cols,2,len(@cols)-1)
--print ''2nd to last:'' + @sql

set @sql = @sql + '')''
if(@username IS NOT NULL)
BEGIN
	--set @sql = @sql + '') AS pvt where username in (SELECT Item FROM dbo.Split ('''''' + @username + '''''', '''';#'''')) and [Date] >= '''''' + convert(varchar(50),@start,102) + '''''' and [Date] <= '''''' + convert(varchar(50),@end,102) + '''''' and site_id = '''''' + convert(varchar(50),@siteuid) + ''''''''
	set @sql = @sql + '') AS pvt ORDER BY [Item UID], [Date]'' 
END
ELSE
BEGIN
	--set @sql = @sql + '') AS pvt where [Date] >= '''''' + convert(varchar(50),@start,102) + '''''' and [Date] <= '''''' + convert(varchar(50),@end,102) + '''''' and site_id = '''''' + convert(varchar(50),@siteuid) + ''''''''
	set @sql = @sql + '') AS pvt ORDER BY [Item UID], [Date]''
END

--print @sql

exec(@sql)

END

DROP TABLE #TempTimesheetData
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSResourceData')
begin
    Print 'Creating Stored Procedure spTSResourceData'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSResourceData'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[spTSResourceData]
	@siteuid uniqueidentifier,
	@username varchar(MAX),
	@periodid varchar(5000)
AS

declare @colname varchar(255)
declare @cols nvarchar(4000)

set @cols = ''''

DECLARE colsCursors CURSOR FOR 
SELECT distinct columnname
FROM vwTSTimesheetResourceMeta
WHERE site_id = @siteuid

OPEN colsCursors

FETCH NEXT FROM colsCursors 
INTO @colname

WHILE @@FETCH_STATUS = 0
BEGIN

set @cols = @cols + '',['' + @colname + '']''

FETCH NEXT FROM colsCursors 
INTO @colname

END

CLOSE colsCursors
DEALLOCATE colsCursors

declare @sql varchar(8000)

set @sql = ''SELECT Username, [Resource Name], [Period Id], [Period Start], [Period End], convert(varchar(15),[Period Start],107) + '''' - '''' + convert(varchar(15),[Period End],107) as [Period Name], [Submitted], [Approval Status], [Approval Notes], Hours ''

set @sql = @sql + @cols
set @sql = @sql + '', [Timesheet UID] FROM ''
set @sql = @sql + ''(SELECT Username, [Resource Name], [Timesheet UID], [Period Id], [Period Start], [Period End], [Submitted], [Approval Status], [Approval Notes], columnname, columnvalue,site_id, hours
FROM vwTSTimesheetResourceMeta ) ps
PIVOT
(
min (columnvalue)
FOR columnname IN
(''

set @sql = @sql + substring(@cols,2,len(@cols)-1)

set @sql = @sql + '')''
set @sql = @sql + '') AS pvt where username in (SELECT Item FROM dbo.Split ('''''' + @username + '''''', '''';#'''')) and convert(varchar(10),[period id]) in (SELECT Item FROM dbo.Split ('''''' + @periodid + '''''', '''';#'''')) and site_id = '''''' + convert(varchar(50),@siteuid) + ''''''''

--print @sql

exec(@sql)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSSetUser')
begin
    Print 'Creating Stored Procedure spTSSetUser'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSSetUser'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSSetUser]

@siteid uniqueidentifier,
@username varchar(255),
@name varchar(255),
@userid int

AS
BEGIN

declare @tsuseruid uniqueidentifier

select @tsuseruid = tsuseruid from tsuser where USERNAME = @username

if @tsuseruid IS NULL
begin

	INSERT INTO TSUSER (SITE_UID, USER_ID, USERNAME, NAME) VALUES (@siteid, @userid, @username, @name)

end
else
begin

	UPDATE TSUSER set username=@username, name=@name, user_id=@userid where tsuseruid=@tsuseruid

end

END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spTSTypes')
begin
    Print 'Creating Stored Procedure spTSTypes'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spTSTypes'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spTSTypes]
	@siteuid nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF EXISTS (SELECT TSTYPE_ID FROM dbo.TSTYPE WHERE SITE_UID=@siteuid)
	BEGIN
		SELECT TSTYPE_ID, TSTYPE_NAME
		FROM dbo.TSTYPE
		WHERE SITE_UID=@siteuid
		ORDER BY TSTYPE_NAME
	END
	ELSE
	BEGIN	
		SELECT 0 AS ''TSTYPE_ID'',''[NA]'' AS ''TSTYPE_NAME''     
	END
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spVAddOrUpdatePersonalView')
begin
    Print 'Creating Stored Procedure spVAddOrUpdatePersonalView'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spVAddOrUpdatePersonalView'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spVAddOrUpdatePersonalView]
      -- Add the parameters for the stored procedure here
      @Key NVARCHAR(255),
      @Value NVARCHAR(MAX),
      @UserId INT,
      @WebId UNIQUEIDENTIFIER,
      @SiteId UNIQUEIDENTIFIER
AS
BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET NOCOUNT ON;

    -- Insert statements for procedure here
    DELETE FROM dbo.PERSONALIZATIONS 
      WHERE       dbo.PERSONALIZATIONS.[Key] = @Key AND 
                        dbo.PERSONALIZATIONS.UserId = CAST(@UserId AS NVARCHAR(255)) AND 
                        dbo.PERSONALIZATIONS.WebId = @WebId AND 
                        dbo.PERSONALIZATIONS.SiteId = @SiteId
                        
      INSERT INTO dbo.PERSONALIZATIONS ([Key], Value, UserId, WebId, SiteId) VALUES (@Key, @Value, @UserId, @WebId, @SiteId)
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spVGetPersonalView')
begin
    Print 'Creating Stored Procedure spVGetPersonalView'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spVGetPersonalView'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spVGetPersonalView]
      -- Add the parameters for the stored procedure here
      @Key NVARCHAR(255),
      @UserId INT,
      @WebId UNIQUEIDENTIFIER,
      @SiteId UNIQUEIDENTIFIER
AS
BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET NOCOUNT ON;

    -- Insert statements for procedure here
      SELECT      dbo.PERSONALIZATIONS.Value FROM dbo.PERSONALIZATIONS 
      WHERE dbo.PERSONALIZATIONS.[Key] = @Key AND dbo.PERSONALIZATIONS.UserId = @UserId AND dbo.PERSONALIZATIONS.WebId = @WebId AND dbo.PERSONALIZATIONS.SiteId = @SiteId
END
')
 
 if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spAddAuth')
begin
    Print 'Creating Stored Procedure spAddAuth'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spAddAuth'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spAddAuth]

@authid uniqueidentifier,
@username varchar(255),
@email varchar(500)

AS
BEGIN

delete from INT_AUTH where username=@username

delete from INT_AUTH where DATEDIFF(mi, datetime, GETDATE()) > 60

INSERT INTO INT_AUTH (AUTH_ID, Username, Email, DateTime) VALUES (@authid, @username, @email, GETDATE())

END

')