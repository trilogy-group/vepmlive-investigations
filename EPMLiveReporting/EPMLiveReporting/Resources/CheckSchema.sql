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
		[Id]                   UNIQUEIDENTIFIER NOT NULL,
		[Title]                NVARCHAR (256)   NOT NULL,
		[URL]                  NVARCHAR (MAX)   NULL,
		[Kind]                 INT              NOT NULL,
		[LastActivityDateTime] DATETIME2 (7)    NULL,
		[WebId]                UNIQUEIDENTIFIER NULL,
		[ListId]               UNIQUEIDENTIFIER NULL,
		[ItemId]               INT              NULL,
		[Deleted]              BIT              CONSTRAINT [DF_SS_Threads_Deleted] DEFAULT ((0)) NULL,
		CONSTRAINT [PK_SS_Threads] PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [UK_SS_Threads] UNIQUE NONCLUSTERED ([WebId] ASC, [ListId] ASC, [ItemId] ASC, [Kind] ASC)
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

