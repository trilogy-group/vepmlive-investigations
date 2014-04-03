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
		[Kind]       BIT              CONSTRAINT [DF_SS_Logs_Kind] DEFAULT ((0)) NOT NULL,
		[WebId]      UNIQUEIDENTIFIER NULL,
		[UserId]     INT              NULL,
		[DateTime]   DATETIME2 (7)    CONSTRAINT [DF_SS_Logs_DateTime] DEFAULT (getdate()) NULL
	);
END

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
		[Title]                 NVARCHAR (256)   NOT NULL,
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

---------------FUNCTION: fnCheckUserAccess----------------------

PRINT 'Creating function fnCheckUserAccess'

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
	
		IF (@ItemId IN (SELECT ITEMID FROM dbo.RPTITEMGROUPS WHERE (SECTYPE = 1) AND (GROUPID IN 
				(SELECT GroupId FROM (SELECT GROUPID FROM dbo.RPTGROUPUSER WHERE USERID = @UserId) AS Groups)) 
				OR (SECTYPE = 0) AND (GROUPID = @UserId) AND (LISTID = @ListId))) RETURN 1
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

	DECLARE @Start INT, @End INT, @WebUrlSuffix CHAR
	
	SET @Start = (@Page - 1) * @Limit
	SET @End =   (@Page * @Limit + 1)
	
	SET @WebUrlSuffix = ''/''
	IF @WebUrl = ''/'' SET @WebUrlSuffix = ''''
	
	IF @Limit > 1000000 SET @Limit = 1000000;
	
	WITH Result AS (
		SELECT ROW_NUMBER() OVER (ORDER BY ThreadLastActivityOn DESC) AS RowNum,
			ThreadId, ThreadTitle, ThreadUrl, ThreadKind, ThreadLastActivityOn, ThreadFirstActivityOn, WebId, WebTitle, WebUrl, ListId, 
			ListName, ListIcon, ItemId, TotalActivities, TotalComments
			FROM    (SELECT	dbo.SS_Threads.Id AS ThreadId, dbo.SS_Threads.Title AS ThreadTitle, dbo.SS_Threads.URL AS ThreadUrl, 
							dbo.SS_Threads.Kind AS ThreadKind, dbo.SS_Threads.LastActivityDateTime AS ThreadLastActivityOn, 
							dbo.SS_Threads.FirstActivityDateTime AS ThreadFirstActivityOn, dbo.SS_Threads.WebId, dbo.RPTWeb.WebTitle, 
							dbo.RPTWeb.WebUrl, dbo.SS_Threads.ListId, dbo.RPTList.ListName, dbo.ReportListIds.ListIcon AS ListIcon, 
							dbo.SS_Threads.ItemId, 
							(SELECT	COUNT(Id) FROM dbo.SS_Activities WHERE (Kind <> 4) AND (ThreadId = dbo.SS_Threads.Id)) AS TotalActivities,
                            (SELECT COUNT(Id) FROM dbo.SS_Activities WHERE (Kind = 4) AND (ThreadId = dbo.SS_Threads.Id)) AS TotalComments, 
							dbo.fnCheckUserAccess(@UserId, dbo.SS_Threads.WebId, dbo.SS_Threads.ListId, dbo.SS_Threads.ItemId) AS HasAccess
					FROM	dbo.SS_Threads INNER JOIN dbo.RPTWeb ON dbo.SS_Threads.WebId = dbo.RPTWeb.WebId LEFT OUTER JOIN
							dbo.RPTList ON dbo.SS_Threads.ListId = dbo.RPTList.RPTListId INNER JOIN
							dbo.ReportListIds ON dbo.SS_Threads.ListId = dbo.ReportListIds.Id
					WHERE   (dbo.SS_Threads.Deleted = 0) AND (dbo.SS_Threads.Id = @ThreadId OR @ThreadId IS NULL) 
							AND (dbo.RPTWeb.WebUrl = @WebUrl OR dbo.RPTWeb.WebUrl LIKE @WebUrl + @WebUrlSuffix + ''%'')) AS DT1
			WHERE   (HasAccess = 1)
	) SELECT TOP (@End - 1) ThreadId, ThreadTitle, ThreadUrl, ThreadKind, ThreadLastActivityOn, ThreadFirstActivityOn, WebId, WebTitle, 
							WebUrl, ListId, ListName, ListIcon, ItemId, TotalActivities, TotalComments
	  FROM Result WHERE RowNum > @Start AND RowNum < @End
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
	@Offset DATETIME = NULL
AS
BEGIN
	SET NOCOUNT ON;
	
	IF @Offset IS NULL SET @Offset = GETUTCDATE()

	DECLARE @Start INT, @End INT
	
	SET @Start = (@Page - 1) * @Limit
	SET @End =   (@Page * @Limit + 1);

	WITH Result AS (
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
					 dbo.SS_Activities.Kind >= @KindMin AND dbo.SS_Activities.Kind <= @KindMax) 
					 AS DT1
			WHERE   (HasAccess = 1)
	) SELECT TOP (@End - 1) ActivityId, ActivityKey, ActivityData, ActivityKind, ActivityDate, ActivityIsMassOperation, ThreadId, 
							UserId, UserDisplayName, UserName, UserPicture
	  FROM Result WHERE RowNum > @Start AND RowNum < @End
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
    
	IF @View = ''MyWorkspace''
	BEGIN  
		SELECT DISTINCT dbo.RPTWeb.SiteId,dbo.RPTWeb.Webtitle,dbo.RPTWeb.WebDescription,dbo.RPTWeb.WebId,dbo.RPTWeb.Members,dbo.LSTResourcepool.SharePointAccountText,
			CASE 
				WHEN @UserId = 1073741823 THEN 1 
				WHEN (dbo.RPTWeb.WebId IN (SELECT WEBID FROM dbo.RPTWEBGROUPS 
				WHERE (SECTYPE = 1) AND (GROUPID IN (SELECT GroupId FROM #Groups)) 
				OR (SECTYPE = 0) AND (GROUPID = @UserId))) THEN 1
			ELSE 0 
			END AS HasAccess
		FROM dbo.RPTWeb INNER JOIN dbo.LSTResourcepool ON dbo.RPTWeb.WebOwnerId = dbo.LSTResourcepool.SharePointAccountID 
		WHERE dbo.RPTWeb.SiteId = @SiteId AND dbo.RPTWeb.WebOwnerId= @UserId order by dbo.RPTWeb.WebTitle
	END
	ELSE IF @View = ''AllItems''
	BEGIN
		SELECT DISTINCT dbo.RPTWeb.SiteId,dbo.RPTWeb.Webtitle,dbo.RPTWeb.WebDescription,dbo.RPTWeb.WebId,dbo.RPTWeb.Members,dbo.LSTResourcepool.SharePointAccountText,
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
