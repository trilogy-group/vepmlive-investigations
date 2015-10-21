---------------TABLE: ReportListIds----------------------
IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'ReportListIds')
BEGIN
	PRINT 'Creating Table ReportListIds'
	CREATE TABLE [dbo].[ReportListIds] ( Id uniqueidentifier )
END
 
IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ReportListIds' AND COLUMN_NAME = 'ListIcon')
BEGIN
	PRINT 'Add Column ListIcon'
	ALTER TABLE [dbo].[ReportListIds]
	ADD [ListIcon] [NVARCHAR](100) NULL
END

---------------TABLE: RPTWeb----------------------
IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'RPTWeb')
BEGIN
	PRINT 'Creating Table RPTWeb'
	CREATE TABLE [dbo].[RPTWeb] ([SiteId] uniqueidentifier, [ItemWebId] uniqueidentifier, [ItemListId] uniqueidentifier, [ItemId] int, [ParentWebId] uniqueidentifier, [WebId] uniqueidentifier, [WebUrl] varchar(max), [WebTitle] varchar(max))
END

IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'RPTWeb' AND COLUMN_NAME = 'WebOwnerId')
BEGIN
	PRINT 'Add Column WebOwnerId'
	ALTER TABLE [dbo].[RPTWeb]
	ADD [WebOwnerId] int NULL
END

IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'RPTWeb' AND COLUMN_NAME = 'WebDescription')
BEGIN
	PRINT 'Add Column WebDescription'
	ALTER TABLE [dbo].[RPTWeb]
	ADD [WebDescription] varchar(max) NULL
END

IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'RPTWeb' AND COLUMN_NAME = 'Members')
BEGIN
	PRINT 'Add Column Members'
	ALTER TABLE [dbo].[RPTWeb]
	ADD [Members] int NULL
END

---------------TABLE: RPTWEBGROUPS----------------------
IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'RPTWEBGROUPS')
BEGIN
	PRINT 'Creating Table RPTWEBGROUPS'
	CREATE TABLE [dbo].[RPTWEBGROUPS]( 
        [RPTWEBGROUPID] [uniqueidentifier] NOT NULL, 
        [SITEID] [uniqueidentifier] NULL,
        [WEBID] [uniqueidentifier] NULL, 
        [GROUPID] [int] NULL,
        [SECTYPE] [int] NULL, 
	CONSTRAINT [PK_RPTWEBGROUPS] PRIMARY KEY CLUSTERED([RPTWEBGROUPID] ASC)
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] 
	)ON [PRIMARY] 

	ALTER TABLE [dbo].[RPTWEBGROUPS] ADD  CONSTRAINT [DF_RPTWEBGROUPS_RPTWEBGROUPID]  DEFAULT (newid()) FOR [RPTWEBGROUPID] 

	IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[RPTWEBGROUPS]') AND name = N'PK_RPTWEBGROUPS') 
	ALTER TABLE [dbo].[RPTWEBGROUPS] DROP CONSTRAINT [PK_RPTWEBGROUPS] 

	ALTER TABLE [dbo].[RPTWEBGROUPS] ADD  CONSTRAINT [PK_RPTWEBGROUPS] PRIMARY KEY CLUSTERED( [RPTWEBGROUPID] ASC )
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] 

	CREATE NONCLUSTERED INDEX [IX_RPTWEBGROUPS_GROUPID_SECTYPE] ON [dbo].[RPTWEBGROUPS]( [GROUPID] ASC, [SECTYPE] ASC)
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] 

	CREATE NONCLUSTERED INDEX [IX_RPTWEBGROUPS_GROUPID] ON [dbo].[RPTWEBGROUPS]([GROUPID] ASC)
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] 
	                                    
END

---------------TABLE: SS_Activities----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_Activities')
BEGIN
	PRINT 'Creating Table SS_Activities'
	
	CREATE TABLE [dbo].[SS_Activities] (
		[Id]            UNIQUEIDENTIFIER CONSTRAINT [DF_SS_Activities_Id] DEFAULT (newid()) NOT NULL,
		[ActivityKey]   NVARCHAR (256)   NULL,
		[Data]          NVARCHAR (MAX)   NULL,
		[Kind]          INT              NOT NULL,
		[Date]          DATETIME2 (7)    CONSTRAINT [DF_SS_Activities_Date] DEFAULT (getdate()) NULL,
		[UserId]        INT              NOT NULL,
		[ThreadId]      UNIQUEIDENTIFIER NOT NULL,
		[MassOperation] BIT              CONSTRAINT [DF_SS_Activities_MassOperation] DEFAULT ((0)) NULL,
		CONSTRAINT [PK_SS_Activities] PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [UK_SS_Activities] UNIQUE NONCLUSTERED ([ThreadId] ASC, [Kind] ASC, [UserId] ASC, [Date] ASC)
	);

	EXEC sp_executesql N'
	CREATE TRIGGER [dbo].[UpdateThreadLastActivity] 
	   ON  dbo.SS_Activities 
	   AFTER INSERT,UPDATE
	AS 
	BEGIN
		SET NOCOUNT ON;
		IF (SELECT MassOperation FROM INSERTED) = 0
		BEGIN
			UPDATE SS_Threads SET LastActivityDateTime = (SELECT Date FROM INSERTED) WHERE Id = (SELECT ThreadId FROM INSERTED)
		END
	END'

	EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Created = 0, Updated = 1, Deleted = 2, Bulk Operation = 3, Comment = 4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SS_Activities', @level2type = N'COLUMN', @level2name = N'Kind';
END

---------------TABLE: SS_AssociatedThreads----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_AssociatedThreads')
BEGIN
	PRINT 'Creating Table SS_AssociatedThreads'

	CREATE TABLE [dbo].[SS_AssociatedThreads] (
		[Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_SS_AssociatedThreads_Id] DEFAULT (newid()) NOT NULL,
		[ThreadId] UNIQUEIDENTIFIER NOT NULL,
		[ListId]   UNIQUEIDENTIFIER NOT NULL,
		[ItemId]   INT              NOT NULL,
		CONSTRAINT [PK_SS_AssociatedThreads] PRIMARY KEY CLUSTERED ([Id] ASC)
	);
END

---------------TABLE: SS_Logs----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_Logs')
BEGIN
	PRINT 'Creating Table SS_Logs'
	CREATE TABLE [dbo].[SS_Logs] (
		[Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_SS_Logs_Id] DEFAULT (newid()) NOT NULL,
		[Message]    NVARCHAR (MAX)   NULL,
		[StackTrace] NVARCHAR (MAX)   NULL,
		[Details]    NVARCHAR (MAX)   NULL,
		[Kind]       INT              CONSTRAINT [DF_SS_Logs_Kind] DEFAULT ((0)) NOT NULL,
		[WebId]      UNIQUEIDENTIFIER NULL,
		[UserId]     INT              NULL,
		[DateTime]   DATETIME2 (7)    CONSTRAINT [DF_SS_Logs_DateTime] DEFAULT (getutcdate()) NULL
	);
END

ALTER TABLE [dbo].[SS_Logs] DROP CONSTRAINT [DF_SS_Logs_Kind]
ALTER TABLE [dbo].[SS_Logs] ALTER COLUMN [Kind] INT
ALTER TABLE [dbo].[SS_Logs] ADD  CONSTRAINT [DF_SS_Logs_Kind]  DEFAULT ((0)) FOR [Kind]
ALTER TABLE [dbo].[SS_Logs] DROP CONSTRAINT [DF_SS_Logs_DateTime]
ALTER TABLE [dbo].[SS_Logs] ADD  CONSTRAINT [DF_SS_Logs_DateTime]  DEFAULT (getutcdate()) FOR [DateTime]

---------------TABLE: SS_Streams----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_Streams')
BEGIN
	PRINT 'Creating Table SS_Streams'
	CREATE TABLE [dbo].[SS_Streams] (
		[Id]     UNIQUEIDENTIFIER CONSTRAINT [DF_SS_Streams_Id] DEFAULT (newid()) NOT NULL,
		[WebId]  UNIQUEIDENTIFIER NOT NULL,
		[Title]  NVARCHAR (MAX)   NULL,
		[ListId] UNIQUEIDENTIFIER NULL,
		[ItemId] INT              NULL,
		CONSTRAINT [PK_SS_Streams] PRIMARY KEY CLUSTERED ([Id] ASC)
	);
END

---------------TABLE: SS_Streams_Threads----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_Streams_Threads')
BEGIN
	PRINT 'Creating Table SS_Streams_Threads'
	CREATE TABLE [dbo].[SS_Streams_Threads] (
		[StreamId] UNIQUEIDENTIFIER NOT NULL,
		[ThreadId] UNIQUEIDENTIFIER NOT NULL,
		CONSTRAINT [UK_SS_Streams_Threads] UNIQUE NONCLUSTERED ([StreamId] ASC, [ThreadId] ASC)
	);
END

---------------TABLE: SS_StreamUsers----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_StreamUsers')
BEGIN
	PRINT 'Creating Table SS_StreamUsers'
	CREATE TABLE [dbo].[SS_StreamUsers] (
		[StreamId] UNIQUEIDENTIFIER NOT NULL,
		[UserId]   INT              NOT NULL
	);
END

---------------TABLE: SS_Threads----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_Threads')
BEGIN
	PRINT 'Creating Table SS_Threads'
	CREATE TABLE [dbo].[SS_Threads] (
		[Id]                    UNIQUEIDENTIFIER NOT NULL,
		[Title]                 NVARCHAR (MAX)   NOT NULL,
		[URL]                   NVARCHAR (MAX)   NULL,
		[Kind]                  INT              NOT NULL,
		[LastActivityDateTime]  DATETIME2 (7)    NULL,
		[FirstActivityDateTime] DATETIME2 (7)    NOT NULL,
		[WebId]                 UNIQUEIDENTIFIER NULL,
		[ListId]                UNIQUEIDENTIFIER NULL,
		[ItemId]                INT              NULL,
		[Deleted]               BIT              CONSTRAINT [DF_SS_Threads_Deleted] DEFAULT ((0)) NULL,
		CONSTRAINT [PK_SS_Threads] PRIMARY KEY CLUSTERED ([Id] ASC)
	);

	EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Workspace = 0, List = 1, List Item = 2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SS_Threads', @level2type = N'COLUMN', @level2name = N'Kind';
END

ALTER TABLE dbo.SS_Threads ALTER COLUMN Title NVARCHAR(MAX) NOT NULL

---------------TABLE: SS_ThreadUsers----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_ThreadUsers')
BEGIN
	PRINT 'Creating Table SS_ThreadUsers'
	CREATE TABLE [dbo].[SS_ThreadUsers] (
		[ThreadId] UNIQUEIDENTIFIER NOT NULL,
		[UserId]   INT              NOT NULL,
		[Role]     INT              CONSTRAINT [DF_SS_ThreadUsers_Role] DEFAULT ((0)) NOT NULL,
		CONSTRAINT [UK_SS_ThreadUsers] UNIQUE NONCLUSTERED ([ThreadId] ASC, [UserId] ASC)
	);

	EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Sum of all roles a user belongs to. None = 0, Author = 1, Commenter = 2, Assignee = 4, Liker = 8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SS_ThreadUsers', @level2type = N'COLUMN', @level2name = N'Role';
END

---------------TABLE: SS_AssociatedThreads----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_Transactions')
BEGIN
	PRINT 'Creating Table SS_Transactions'
	CREATE TABLE [dbo].[SS_Transactions] (
		[Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_SS_Transections_Id] DEFAULT (newid()) NOT NULL,
		[WebId]     UNIQUEIDENTIFIER NOT NULL,
		[ListId]    UNIQUEIDENTIFIER NOT NULL,
		[ItemId]    INT              NOT NULL,
		[Component] NVARCHAR (256)   NOT NULL,
		[Time]      DATETIME2 (7)    CONSTRAINT [DF_SS_Transactions_Time] DEFAULT (getdate()) NOT NULL,
		CONSTRAINT [PK_SS_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC)
	);
END

---------------TABLE: SS_AssociatedThreads----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'RPTListInfo')
BEGIN
	PRINT 'Creating Table RPTListInfo'

	CREATE TABLE [dbo].[RPTListInfo](
		[Listid] [uniqueidentifier] NOT NULL,
		[Icon] [varchar](255) NOT NULL
	) ON [PRIMARY]
END

ALTER TABLE RPTList ALTER COLUMN ListName NVARCHAR(500) NOT NULL
ALTER TABLE RPTList ALTER COLUMN TableName NVARCHAR(500) NOT NULL
ALTER TABLE RPTList ALTER COLUMN TableNameSnapshot NVARCHAR(500) NOT NULL

---------------TABLE: RPTPeriods----------------------

IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'RPTPeriods')
BEGIN
	IF EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'RPTPeriods' AND COLUMN_NAME = 'ListNames')
	BEGIN
		Print 'Updating Column ListNames'
                          ALTER TABLE RPTPeriods 
		ALTER COLUMN ListNames nvarchar(MAX)
	END

END


---------------FUNCTION: fnCheckUserAccess----------------------

PRINT 'Creating function fnCheckUserAccess'

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnCheckUserAccess]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
	DROP FUNCTION [dbo].[fnCheckUserAccess]
END

IF NOT  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnCheckUserAccess]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
	EXEC sp_executesql N'
	CREATE FUNCTION [dbo].[fnCheckUserAccess]
	(
		@UserId INT,
		@WebId  UNIQUEIDENTIFIER,
		@ListId UNIQUEIDENTIFIER = NULL,
		@ItemId INT = NULL
	)
	RETURNS BIT
	AS
	BEGIN
		IF @UserId = 1073741823 RETURN 1
	
		IF @ItemId IS NULL
		BEGIN
			IF (@WebId IN (SELECT WEBID FROM dbo.RPTWEBGROUPS WHERE (SECTYPE = 1) AND (GROUPID IN 
					(SELECT GroupId FROM (SELECT GROUPID FROM dbo.RPTGROUPUSER WHERE USERID = @UserId) AS Groups)) 
					OR (SECTYPE = 0) AND (GROUPID = @UserId))) RETURN 1
			RETURN 0
		END
	
		IF (@ItemId IN (SELECT ITEMID FROM dbo.RPTITEMGROUPS WHERE (LISTID = @ListId) AND ((SECTYPE = 1) AND (GROUPID IN 
				(SELECT GroupId FROM (SELECT GROUPID FROM dbo.RPTGROUPUSER WHERE USERID = @UserId) AS Groups)) 
				OR (SECTYPE = 0) AND (GROUPID = @UserId)))) RETURN 1
		RETURN 0
	END'
END

---------------SP: SS_GetLatestThreads----------------------

PRINT 'Creating SP SS_GetLatestThreads'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SS_GetLatestThreads]') AND type in (N'P', N'PC'))
BEGIN
	DROP PROCEDURE [dbo].[SS_GetLatestThreads]
END

EXEC sp_executesql N'
CREATE PROCEDURE [dbo].[SS_GetLatestThreads] 
	@UserId INT, 
	@WebUrl NVARCHAR(MAX),
	@Page	INT = 1,
	@Limit	INT = 1000000,
	@ThreadId UNIQUEIDENTIFIER = NULL
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Start INT, @End INT
	
	SET @Start = (@Page - 1) * @Limit
	SET @End =   (@Page * @Limit + 1)
	
	IF @Limit > 1000000 SET @Limit = 1000000;
	
	SELECT TOP (@End - 1) ThreadId, ThreadTitle, ThreadUrl, ThreadKind, ThreadLastActivityOn, ThreadFirstActivityOn, WebId, WebTitle, 
				WebUrl, ListId, ListName, ListIcon, ItemId, TotalActivities, TotalComments
	FROM (
		SELECT ROW_NUMBER() OVER (ORDER BY ThreadLastActivityOn DESC) AS RowNum,
			ThreadId, ThreadTitle, ThreadUrl, ThreadKind, ThreadLastActivityOn, ThreadFirstActivityOn, WebId, WebTitle, WebUrl, ListId, 
			ListName, ListIcon, ItemId, TotalActivities, TotalComments
			FROM    (SELECT	DISTINCT dbo.SS_Threads.Id AS ThreadId, dbo.SS_Threads.Title AS ThreadTitle, dbo.SS_Threads.URL AS ThreadUrl, 
							dbo.SS_Threads.Kind AS ThreadKind, dbo.SS_Threads.LastActivityDateTime AS ThreadLastActivityOn, 
							dbo.SS_Threads.FirstActivityDateTime AS ThreadFirstActivityOn, dbo.SS_Threads.WebId, dbo.RPTWeb.WebTitle, 
							dbo.RPTWeb.WebUrl, dbo.SS_Threads.ListId, dbo.RPTList.ListName, dbo.ReportListIds.ListIcon AS ListIcon, 
							dbo.SS_Threads.ItemId, 
							(SELECT	COUNT(Id) FROM dbo.SS_Activities WHERE ((ThreadId = dbo.SS_Threads.Id) AND (MassOperation = 0) AND (Kind <> 3 AND Kind <> 4))) AS TotalActivities,
                            (SELECT COUNT(Id) FROM dbo.SS_Activities WHERE (Kind = 4) AND (ThreadId = dbo.SS_Threads.Id)) AS TotalComments, 
							dbo.fnCheckUserAccess(@UserId, dbo.SS_Threads.WebId, dbo.SS_Threads.ListId, dbo.SS_Threads.ItemId) AS HasAccess
					FROM	dbo.ReportListIds INNER JOIN dbo.RPTList ON dbo.ReportListIds.Id = dbo.RPTList.RPTListId RIGHT OUTER JOIN 
							dbo.SS_Threads INNER JOIN dbo.RPTWeb ON dbo.SS_Threads.WebId = dbo.RPTWeb.WebId ON dbo.RPTList.RPTListId = dbo.SS_Threads.ListId
					WHERE   (dbo.SS_Threads.Deleted = 0) AND (dbo.SS_Threads.Id = @ThreadId OR @ThreadId IS NULL) 
							AND (dbo.RPTWeb.WebUrl = @WebUrl OR dbo.RPTWeb.WebUrl LIKE REPLACE(@WebUrl + ''/%'', ''//'', ''/''))) AS DT1
			WHERE   ((HasAccess = 1) OR (HasAccess = 0 AND ThreadKind = 3)) AND (TotalActivities > 0 OR TotalComments > 0)
	) AS Result 
	WHERE RowNum > @Start AND RowNum < @End
	ORDER BY ThreadLastActivityOn DESC
END'

---------------SP: SS_GetLatestActivities----------------------

PRINT 'Creating SP SS_GetLatestActivities'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SS_GetLatestActivities]') AND type in (N'P', N'PC'))
BEGIN
	DROP PROCEDURE [dbo].[SS_GetLatestActivities]
END

EXEC sp_executesql N'
CREATE PROCEDURE [dbo].[SS_GetLatestActivities]
	@UserId INT,
	@ThreadId UNIQUEIDENTIFIER,
	@WebId UNIQUEIDENTIFIER,
	@ListId UNIQUEIDENTIFIER,
	@ItemId INT,
	@KindMin INT = 0,
	@KindMax INT = 100,
	@Page INT = 1,
	@Limit INT = 1000000,
	@Offset DATETIME = NULL,
	@IgnoreAccess BIT = 0
AS
BEGIN
	SET NOCOUNT ON;
	
	IF @Offset IS NULL SET @Offset = GETUTCDATE()

	DECLARE @Start INT, @End INT
	
	SET @Start = (@Page - 1) * @Limit
	SET @End =   (@Page * @Limit + 1);

	SELECT TOP (@End - 1) ActivityId, ActivityKey, ActivityData, ActivityKind, ActivityDate, ActivityIsMassOperation, ThreadId, 
				UserId, UserDisplayName, UserName, UserPicture
	FROM (
		SELECT ROW_NUMBER() OVER (ORDER BY ActivityDate DESC) AS RowNum,
			ActivityId, ActivityKey, ActivityData, ActivityKind, ActivityDate, ActivityIsMassOperation, ThreadId, 
			UserId, UserDisplayName, UserName, UserPicture
			FROM    (SELECT	 dbo.SS_Activities.Id AS ActivityId, dbo.SS_Activities.ActivityKey, dbo.SS_Activities.Data AS ActivityData, 
                     dbo.SS_Activities.Kind AS ActivityKind, dbo.SS_Activities.Date AS ActivityDate, 
                     dbo.SS_Activities.MassOperation AS ActivityIsMassOperation, 
                     dbo.SS_Activities.ThreadId, dbo.SS_Activities.UserId, dbo.LSTUserInformationList.Title AS UserDisplayName, 
                     dbo.LSTUserInformationList.Name AS UserName, dbo.LSTUserInformationList.Picture AS UserPicture, 
                     dbo.fnCheckUserAccess(@UserId, @WebId, @ListId, @ItemId) AS HasAccess
            FROM	 dbo.SS_Activities INNER JOIN dbo.LSTUserInformationList ON dbo.SS_Activities.UserId = dbo.LSTUserInformationList.ID
            WHERE	 dbo.SS_Activities.ThreadId = @ThreadId AND dbo.SS_Activities.Date < @Offset AND
					 dbo.SS_Activities.Kind >= @KindMin AND dbo.SS_Activities.Kind <= @KindMax AND dbo.SS_Activities.Kind <> 3) 
					 AS DT1
			WHERE   (HasAccess = 1) OR (@IgnoreAccess = 1 AND HasAccess = 0)
	) AS Result 
	WHERE RowNum > @Start AND RowNum < @End
	ORDER BY ActivityDate DESC
END'

---------------SP: spGetWorkspaces----------------------

PRINT 'Creating SP spGetWorkspaces'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetWorkspaces]') AND type in (N'P', N'PC'))
BEGIN
	DROP PROCEDURE [dbo].[spGetWorkspaces]
END

EXEC sp_executesql N'
Create PROCEDURE [dbo].[spGetWorkspaces]
      @UserId AS INT,
      @SiteId AS UNIQUEIDENTIFIER,
      @View AS varchar(50)  
AS
BEGIN
      SET NOCOUNT ON;

	CREATE TABLE #Groups (GroupId INT)
	INSERT INTO #Groups (GroupId) SELECT GROUPID FROM dbo.RPTGROUPUSER WHERE (USERID = @UserId) AND (SITEID = @SiteId)
  
	Declare @TmpUserId AS INT
	IF @UserId = 1073741823
	BEGIN
		SET @TmpUserId = 1
	END
	ELSE
	BEGIN
		SET @TmpUserId = @UserId
	END
	
    
	IF @View = ''MyWorkspace''
	BEGIN  
		SELECT DISTINCT dbo.RPTWeb.SiteId,dbo.RPTWeb.Webtitle,dbo.RPTWeb.WebDescription,dbo.RPTWeb.WebId,dbo.RPTWeb.Members,dbo.RPTWeb.WebUrl,dbo.LSTResourcepool.SharePointAccountText,
			CASE 
				WHEN @UserId = 1073741823 THEN 1 
				WHEN (dbo.RPTWeb.WebId IN (SELECT WEBID FROM dbo.RPTWEBGROUPS 
				WHERE (SECTYPE = 1) AND (GROUPID IN (SELECT GroupId FROM #Groups)) 
				OR (SECTYPE = 0) AND (GROUPID = @UserId))) THEN 1
			ELSE 0 
			END AS HasAccess
		FROM dbo.RPTWeb INNER JOIN dbo.LSTResourcepool ON dbo.RPTWeb.WebOwnerId = dbo.LSTResourcepool.SharePointAccountID 
		WHERE dbo.RPTWeb.SiteId = @SiteId AND dbo.RPTWeb.WebOwnerId= @TmpUserId order by dbo.RPTWeb.WebTitle
	END
	ELSE IF @View = ''AllItems''
	BEGIN
		SELECT DISTINCT dbo.RPTWeb.SiteId,dbo.RPTWeb.Webtitle,dbo.RPTWeb.WebDescription,dbo.RPTWeb.WebId,dbo.RPTWeb.Members,dbo.RPTWeb.WebUrl,dbo.LSTResourcepool.SharePointAccountText,
			CASE 
				WHEN @UserId = 1073741823 THEN 1 
				WHEN (dbo.RPTWeb.WebId IN (SELECT WEBID FROM dbo.RPTWEBGROUPS 
				WHERE (SECTYPE = 1) AND (GROUPID IN (SELECT GroupId FROM #Groups)) 
				OR (SECTYPE = 0) AND (GROUPID = @UserId))) THEN 1
			ELSE 0 
			END AS HasAccess
		FROM dbo.RPTWeb 
		INNER JOIN dbo.LSTResourcepool ON dbo.RPTWeb.WebOwnerId = dbo.LSTResourcepool.SharePointAccountID 
		WHERE dbo.RPTWeb.SiteId = @SiteId order by dbo.RPTWeb.WebTitle
	END   
END'

declare @createoralter varchar(10)
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spGetReportListData')
begin
    Print 'Creating Function spGetReportListData'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function spGetReportListData'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + '  PROCEDURE [dbo].[spGetReportListData]

@siteid uniqueidentifier,
@webid uniqueidentifier,
@weburl varchar(255),
@userid	int,
@rollup bit,
@list varchar(255),
@query varchar(5000),
@orderby varchar(5000) = '''',
@page int = 0,
@pagesize int = 0,
@listid uniqueidentifier = null

AS
BEGIN

	declare @sql varchar(MAX)
	declare @table varchar(MAX)
	set @table = null

	set @list = REPLACE(@list, '' '', '''')
	if @list = ''Resources'' 
	begin
		set @table = ''lstResourcePool''
	end
	else
	begin
		if @listid is null
		begin
			set @table = ''lst'' + @list
		end
		else
		begin
			select @table = tablename from rptlist where rptlistid=@listid
			if @table is null
			begin
				set @table = ''lst'' + @list
			end			
		end
	end

	set @table = ''['' + @table + '']''
	declare @sca varchar(255)
	set @sca = ''''
	if @userid = 1073741823
	begin
	
		set @sca = ''insert into #groups (groupid, sectype) VALUES (999999, 1)''
	
	end

	if @rollup = 1
		begin

			declare @tquery varchar(5000)

                  if @weburl = ''/''
                  begin 
                        set @tquery = '' AND (RPTITEMGROUPS.siteid='''''' + CAST(@siteid as varchar(255)) + '''''')''
                  end
                  else
                  begin
                        set @tquery = '' AND (weburl='''''' + @weburl + '''''' or weburl like '''''' + @weburl + ''/%'''')''
                  end
      
                  if @query != ''''
                  begin
                        set @query = @tquery + '' AND '' + @query
                  end
                  else
                  begin
                        set @query = @tquery 
                  end

		end
	else
		begin

			if @query != ''''
				begin
					set @query = '' AND webid='''''' + convert(varchar(50), @webid) + '''''' AND '' + @query
				end
			else
				begin
					set @query = '' AND webid='''''' + convert(varchar(50), @webid) + ''''''''
				end

			
		end

		set @sql = ''from '' + @table + '' where cast(listid as varchar(40)) + cast(itemid as varchar(20)) in (
		SELECT     CAST(dbo.RPTITEMGROUPS.LISTID AS varchar(40)) + CAST(dbo.RPTITEMGROUPS.ITEMID AS varchar(20)) AS Expr1
		FROM         dbo.RPTITEMGROUPS INNER JOIN
                      #Groups as gps ON gps.GROUPID = rptitemgroups.GROUPID
		
		) '' + @query

		if @pagesize <> 0 
		begin

			if @page = 0
			begin
				set @page = 1
			end

			if @orderby = '''' begin
				set @orderby = ''itemid''
			end

			declare @topval int
			set @topval = @page * @pagesize

			

			set @sql = ''
			CREATE TABLE #Groups (GroupId INT, sectype int)
			
			INSERT INTO #Groups (GroupId, sectype) SELECT GROUPID, 1 FROM dbo.RPTGROUPUSER WHERE (USERID = '''''' + convert(varchar(10), @userid) + '''''') AND (SITEID = '''''' + CAST(@siteid as varchar(255)) + '''''')
			
			insert into #groups (groupid, sectype) VALUES ('''''' + convert(varchar(10), @userid) + '''''', 0)
			
			select * INTO #tmp '' + @sql + '';
			
			'' + @sca + ''
			
			;WITH MyCTE AS (
				SELECT top '' + convert(varchar(15),@topval) + '' ROW_NUMBER () OVER  (order by '' + @orderby + '') as RowID,*
				from #tmp
			)
			SELECT *
			FROM MyCTE
			WHERE RowID BETWEEN '' + convert(varchar(15),(@page - 1) * @pagesize + 1) + '' and '' + convert(varchar(15),@topval) 
			+ ''select count(*) from #tmp''
		end
		else
		begin
			set @sql = ''CREATE TABLE #Groups (GroupId INT, sectype int)
			
			INSERT INTO #Groups (GroupId, sectype) SELECT GROUPID, 1 FROM dbo.RPTGROUPUSER WHERE (USERID = '''''' + convert(varchar(10), @userid) + '''''') AND (SITEID = '''''' + CAST(@siteid as varchar(255)) + '''''')
			
			insert into #groups (groupid, sectype) VALUES ('''''' + convert(varchar(10), @userid) + '''''', 0)
			
			'' + @sca + ''
			
			select * '' + @sql;
		
			if @orderby <> '''' begin
			
				set @sql = @sql + '' order by '' + @orderby
			
			end
		end
		
		print @sql
		
	exec(@sql)

	

ENd
')


if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spUpdateStatusFields')
begin
    Print 'Creating Function spUpdateStatusFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function spUpdateStatusFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE spUpdateStatusFields

@listtable varchar(255),
@yellow int = 0,
@red int = 30

AS
BEGIN


declare @cols as bit
set @cols = 1
declare @sql as varchar(MAX)

if exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = @listtable and column_name = ''DueDate'')
begin
      ----------------------Days Overdue------------
      if exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = @listtable and column_name = ''DaysOverdue'')
      begin
            
            set @sql = ''update ['' + @listtable + ''] set daysoverdue = case when duedate > GETDATE() then 0 else DATEDIFF(d, duedate, GETDATE()) end''
            
            exec (@sql)
            
      end
      
      
      ----------------------Due------------
      if exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = @listtable and column_name = ''Due'') AND  exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = @listtable and column_name = ''Status'')
      begin
            
            set @sql = ''update ['' + @listtable + ''] set due = 
                              case 
                              when status = ''''Completed'''' then ''''Completed'''' 
                              when duedate is null then ''''No Due Date''''
                              when DATEDIFF(d, duedate, GETDATE()) > 0 then ''''(1) Overdue''''
                              when DATEDIFF(d, duedate, GETDATE()) = 0 then ''''(2) Due Today''''
                              when DATEDIFF(d, duedate, GETDATE()) = -1 then ''''(3) Due Tomorrow''''
                              when DATEPART(yyyy, duedate) = DATEPART(yyyy, GETDATE()) AND DATEPART(ww, duedate) = DATEPART(ww, GETDATE()) then ''''(4) Due This Week''''
                              when DATEDIFF(d, DATEADD (d , (DATEPART(dw,GETDATE()) - 1) * -1 , GETDATE()), duedate ) < 14 then ''''(5) Due Next Week''''
                              when DATEPART(yyyy, duedate) = DATEPART(yyyy, GETDATE()) AND DATEPART(m, duedate) = DATEPART(m, GETDATE()) then ''''(6) Due This Month''''
                              else ''''(7) Future''''
                              end''
            
            exec (@sql)
            
      end
      
      ----------------------Schedule Status------------
      if exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = @listtable and column_name = ''ScheduleStatus'')
      begin
            
            set @sql = ''update ['' + @listtable + ''] set ScheduleStatus =        
                              case 
                              when duedate IS NULL then ''''GREEN.GIF''''
                              when DATEDIFF(d, duedate, GETDATE()) > '' + CONVERT(varchar(5), @red) + '' then ''''RED.GIF''''
                              when DATEDIFF(d, duedate, GETDATE()) > '' + CONVERT(varchar(5), @yellow) + '' then ''''YELLOW.GIF''''                      
                              else ''''GREEN.GIF''''
                              end''
            exec (@sql)

      end
end


END')



if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRPTLists')
begin
    Print 'Creating Stored Procedure spRPTLists'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRPTLists'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRPTLists] 
@siteID uniqueidentifier,
@ListIDs nvarchar(max) = null,
@Enabled bit,
@timerjobguid uniqueidentifier = NULL 
      
AS
BEGIN

DECLARE @tblLists table(id int identity(1,1),rptlistid uniqueidentifier,listname nvarchar(100),siteid uniqueidentifier,tablename nvarchar(100), tablenamesnapshot nvarchar(100))
DECLARE @ListCount int
DECLARE @ListCounter int
DECLARE @TableName nvarchar(100)
DECLARE @SnapshotTableName nvarchar(100)
DECLARE @PeriodID uniqueidentifier
DECLARE @RPTListID uniqueidentifier
DECLARE @ReportPeriod nvarchar(100)
DECLARE @Title nvarchar(100)
DECLARE @ListName nvarchar(100)
DECLARE @errMsg nvarchar(400)
DECLARE @timestamp datetime

INSERT INTO @tblLists (rptlistid, listname,siteid,tablename,tablenamesnapshot)
(SELECT rptlistid, listname, Siteid , TableName, TableNameSnapshot
FROM [RPTList]
WHERE Siteid = @siteID)
      
IF (@ListIDs IS NULL) -- process ALL lists
BEGIN                               
            --Start Transaction
            BEGIN TRANSACTION 
                  --Start Try
                  BEGIN TRY 
                        --Init. default values  
                        SET @ListName = ''N/A''
                        
                        --Init. Report period and Report Title
                        SET @ReportPeriod = CONVERT(varchar,Getdate(),101)
                        SET @Title = CONVERT(varchar,Getdate(),100) 
                        
                        -- Get list process count
                        SET @ListCount = (SELECT COUNT(*) FROM @tblLists)
                        -- Intit. counter
                        SET @ListCounter = 1          
                        -- Init. new periodID
                        SET @PeriodID = newid() 

                        SET @ListIDs = ''All reporting lists.''                                 
                        -- Insert record into RPTPeriod table
                        INSERT INTO RPTPeriods VALUES(@PeriodID,@SiteID,@Title,@ReportPeriod,GetDate(),@Enabled, @ListIDs,@timerjobguid)                   
                        -- Loop thru snapshot lists
                        WHILE @ListCounter <= @ListCount
                        BEGIN 
                        -- Init. listID 
                              SET @RPTListID = (SELECT rptlistid FROM @tblLists WHERE id = @ListCounter)
                        -- Init. listname
                              SET @ListName = (SELECT listname FROM @tblLists WHERE id = @ListCounter)                       
                        -- Init. list tablename             
                              SET @TableName = (SELECT tablename FROM @tblLists WHERE id = @ListCounter)
                        -- Init. list snapshot tablename
                              SET @SnapshotTableName = (SELECT tablenamesnapshot FROM @tblLists WHERE id = @ListCounter)
                        -- Insert record into RPTPeriodSnapshot table         
                              Exec spRPTPeriodSnapshot @TableName, @SnapshotTableName, @Title, @ReportPeriod, @siteID, @PeriodID, @Enabled
                        -- Insert log ''Success'' record into RPTLog for this list         
                              SET @timestamp = getdate()
                              Exec spRPTLogInsert  @RPTListID, @ListName, ''Snapshot taken successfully.'' , ''All sites processed successfully.'',0,2, @timestamp,@timerjobguid
                        -- Increment counter
                              SET @ListCounter = @ListCounter + 1
                        END   
                  COMMIT TRANSACTION                                    
                  END TRY
                  -- Start Catch/error handling
                  BEGIN CATCH                   
                        BEGIN 
                              -- Rollback tx
                              ROLLBACK TRANSACTION;
                              -- Log error                              
                              SET @errMsg = (SELECT ERROR_MESSAGE() as ErrorMessage)
                              SET @timestamp = getdate()
                              Exec spRPTLogInsert  @RPTListID, @ListName, ''Snapshot SQL Error.'',@errMsg ,1,2, @timestamp,@timerjobguid                       
                        END
                  END CATCH
            END         
ELSE -- process list of lists
BEGIN
      --Start Transaction
            BEGIN TRANSACTION 
                  --Start Try
                  BEGIN TRY 
                        -- table variable that will hold the comma delimited list of lists string values
                        DECLARE @tblListNames table(id int, listid nvarchar(100))

                        --Init. Report period and Report Title
                        SET @ReportPeriod = CONVERT(varchar,Getdate(),101)
                        SET @Title = CONVERT(varchar,Getdate(),100) 

                        -- List name
                        DECLARE @LstName nvarchar(100)                              
                        -- Init. table variable
                        INSERT INTO @tblListNames(id,listid) SELECT * FROM dbo.Split(@ListIDs, '','')
                        -- Init. list count
                        SET @ListCount = (SELECT COUNT(*) FROM @tblListNames)
                        -- Init. list counter
                        SET @ListCounter = 1
                        -- Init. new periodID
                        SET @PeriodID = newid()                                     
                        -- Insert record into RPTPeriod table
                        INSERT INTO RPTPeriods VALUES(@PeriodID,@SiteID,@Title,@ReportPeriod,GetDate(),@Enabled, @ListIDs,@timerjobguid)
                        -- Loop thru snapshot lists
                        WHILE @ListCounter <= @ListCount
                              BEGIN 
									SET @RPTListID = (SELECT listid FROM @tblListNames WHERE id = @ListCounter)                        
                                    SET @LstName = (SELECT listname FROM @tblLists WHERE rptlistid = @RPTListID)
                                    SET @TableName = (SELECT tablename FROM @tblLists WHERE rptlistid = @RPTListID)                                    
                                    SET @SnapshotTableName = (SELECT tablenamesnapshot FROM @tblLists WHERE rptlistid = @RPTListID)
                                    Exec spRPTPeriodSnapshot @TableName, @SnapshotTableName, @Title, @ReportPeriod, @siteID,@PeriodID, @Enabled
                                    -- Insert log ''Success'' record into RPTLog for this list    
                                    SET @timestamp = getdate()     
									Exec spRPTLogInsert  @RPTListID, @LstName, ''Snapshot taken successfully.'' , ''All sites processed successfully.'',0,2, @timestamp,@timerjobguid
                                    SET @ListCounter = @ListCounter + 1
                              END   
                  COMMIT TRANSACTION                              
                  END TRY
                  -- Start Catch/error handling
                  BEGIN CATCH                   
                        BEGIN 
                              -- Rollback tx
                              ROLLBACK TRANSACTION;
                              -- Log error
                              SET @errMsg = (SELECT ERROR_MESSAGE() as ErrorMessage)
                              SET @timestamp = getdate()
                              Exec spRPTLogInsert  @RPTListID, @ListName, ''Snapshot SQL Error.'',@errMsg ,2,2, @timestamp,@timerjobguid                                    
                        END
                  END CATCH
            END         
END

')

if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spGetSnapshotManagementDetails')
begin
    Print 'Creating Stored Procedure spGetSnapshotManagementDetails'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spGetSnapshotManagementDetails'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spGetSnapshotManagementDetails] 
AS
BEGIN

CREATE TABLE #RPTPeriods
(
[Active] nvarchar(256),
[Report Title] nvarchar(512),
[Reporting Period] nvarchar(512),
[Snapshot Date] nvarchar(512),
[Lists] nvarchar(max),
PeriodID nvarchar(512),
siteid nvarchar(512)
)
DECLARE @Active nvarchar(256),@ReportTitle nvarchar(512),@ReportingPeriod nvarchar(512),@SnapshotDate nvarchar(512),@PeriodID nvarchar(512),@siteid nvarchar(512)
DECLARE @Lists varchar(max)
DECLARE curSnapshotData CURSOR FOR SELECT Enabled AS [Active], Title AS [ReportTitle], PeriodDate AS [ReportingPeriod], DateArchived AS [SnapshotDate], 
'''''''' + REPLACE(ListNames,'', '','''''','''''')+'''''''' AS [Lists],periodid,siteid 
FROM RPTPeriods
OPEN curSnapshotData
FETCH NEXT FROM curSnapshotData INTO @Active,@ReportTitle,@ReportingPeriod,@SnapshotDate,@Lists,@PeriodID,@siteid
WHILE   @@FETCH_STATUS = 0   
BEGIN
DECLARE @sql nvarchar(max)
DECLARE @AllListName nvarchar(max)
SET @sql = ''select @AllListName = STUFF((select '''', '''' + ListName FROM RPTList WHERE CONVERT(VARCHAR(max), RPTListId) IN (''+ @Lists +'') FOR XML PATH('''''''')), 1, 1, '''''''')''
EXECUTE sp_executesql @sql, N''@Lists nvarchar(max),@AllListName nvarchar(max) OUTPUT'', @Lists = @Lists, @AllListName = @AllListName OUTPUT
INSERT INTO #RPTPeriods
SELECT @Active,@ReportTitle,@ReportingPeriod,@SnapshotDate,@AllListName,@PeriodID,@siteid
FETCH NEXT FROM curSnapshotData INTO @Active,@ReportTitle,@ReportingPeriod,@SnapshotDate,@Lists,@PeriodID,@siteid
END
CLOSE curSnapshotData
DEALLOCATE curSnapshotData
SELECT * FROM #RPTPeriods

END')
