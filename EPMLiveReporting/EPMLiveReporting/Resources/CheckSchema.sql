---------------TABLE: ReportListIds----------------------
IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'ReportListIds')
BEGIN
	PRINT 'Creating Table ReportListIds'
	CREATE TABLE [dbo].[ReportListIds] ( Id uniqueidentifier )
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
	CREATE TABLE [dbo].[SS_Activities](
		[Id] [uniqueidentifier] NOT NULL,
		[Data] [nvarchar](max) NULL,
		[Kind] [int] NOT NULL,
		[Date] [datetime2](7) NULL,
		[UserId] [int] NOT NULL,
		[ThreadId] [uniqueidentifier] NOT NULL,
		[MassOperation] [bit] NULL,
	 CONSTRAINT [PK_SS_Activities] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[SS_Activities] ADD  CONSTRAINT [DF_SS_Activities_Id]  DEFAULT (newid()) FOR [Id]

	ALTER TABLE [dbo].[SS_Activities] ADD  CONSTRAINT [DF_SS_Activities_Date]  DEFAULT (getdate()) FOR [Date]

	ALTER TABLE [dbo].[SS_Activities] ADD  CONSTRAINT [DF_SS_Activities_MassOperation]  DEFAULT ((0)) FOR [MassOperation]
END

---------------TABLE: SS_Logs----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_Logs')
BEGIN
	PRINT 'Creating Table SS_Logs'
	CREATE TABLE [dbo].[SS_Logs](
		[Id] [uniqueidentifier] NOT NULL,
		[Message] [nvarchar](max) NULL,
		[StackTrace] [nvarchar](max) NULL,
		[Details] [nvarchar](max) NULL,
		[Kind] [bit] NOT NULL,
		[WebId] [uniqueidentifier] NULL,
		[UserId] [int] NULL,
		[DateTime] [datetime2](7) NULL
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[SS_Logs] ADD  CONSTRAINT [DF_SS_Logs_Id]  DEFAULT (newid()) FOR [Id]

	ALTER TABLE [dbo].[SS_Logs] ADD  CONSTRAINT [DF_SS_Logs_Kind]  DEFAULT ((0)) FOR [Kind]

	ALTER TABLE [dbo].[SS_Logs] ADD  CONSTRAINT [DF_SS_Logs_DateTime]  DEFAULT (getdate()) FOR [DateTime]
END

---------------TABLE: SS_Streams----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_Streams')
BEGIN
	PRINT 'Creating Table SS_Streams'
	CREATE TABLE [dbo].[SS_Streams](
		[Id] [uniqueidentifier] NOT NULL,
		[WebId] [uniqueidentifier] NOT NULL,
		[Title] [nvarchar](max) NULL,
		[ListId] [uniqueidentifier] NULL,
		[ItemId] [int] NULL,
	 CONSTRAINT [PK_SS_Streams] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[SS_Streams] ADD  CONSTRAINT [DF_SS_Streams_Id]  DEFAULT (newid()) FOR [Id]
END

---------------TABLE: SS_Streams_Threads----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_Streams_Threads')
BEGIN
	PRINT 'Creating Table SS_Streams_Threads'
	CREATE TABLE [dbo].[SS_Streams_Threads](
		[StreamId] [uniqueidentifier] NOT NULL,
		[ThreadId] [uniqueidentifier] NOT NULL,
	 CONSTRAINT [UK_SS_Streams_Threads] UNIQUE NONCLUSTERED 
	(
		[StreamId] ASC,
		[ThreadId] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

---------------TABLE: SS_StreamUsers----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_StreamUsers')
BEGIN
	PRINT 'Creating Table SS_StreamUsers'
	CREATE TABLE [dbo].[SS_StreamUsers](
		[StreamId] [uniqueidentifier] NOT NULL,
		[UserId] [int] NOT NULL
	) ON [PRIMARY]
END

---------------TABLE: SS_Threads----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_Threads')
BEGIN
	PRINT 'Creating Table SS_Threads'
	CREATE TABLE [dbo].[SS_Threads](
		[Id] [uniqueidentifier] NOT NULL,
		[Title] [nvarchar](max) NOT NULL,
		[URL] [nvarchar](max) NULL,
		[Kind] [int] NOT NULL,
		[LastActivityDateTime] [datetime2](7) NULL,
		[WebId] [uniqueidentifier] NULL,
		[ListId] [uniqueidentifier] NULL,
		[ItemId] [int] NULL,
		[Deleted] [bit] NULL,
	 CONSTRAINT [PK_SS_Threads] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	ALTER TABLE [dbo].[SS_Threads] ADD  CONSTRAINT [DF_SS_Threads_Deleted]  DEFAULT ((0)) FOR [Deleted]
END

---------------TABLE: SS_ThreadUsers----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_ThreadUsers')
BEGIN
	PRINT 'Creating Table SS_ThreadUsers'
	CREATE TABLE [dbo].[SS_ThreadUsers](
		[ThreadId] [uniqueidentifier] NOT NULL,
		[UserId] [int] NOT NULL,
		[Role] [int] NOT NULL
	) ON [PRIMARY]

	ALTER TABLE [dbo].[SS_ThreadUsers] ADD  CONSTRAINT [DF_SS_ThreadUsers_Role]  DEFAULT ((0)) FOR [Role]
END

---------------TABLE: SS_AssociatedThreads----------------------

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'SS_AssociatedThreads')
BEGIN
	PRINT 'Creating Table SS_AssociatedThreads'
	CREATE TABLE [dbo].[SS_AssociatedThreads](
		[Id] [uniqueidentifier] NOT NULL,
		[ThreadId] [uniqueidentifier] NOT NULL,
		[ListId] [uniqueidentifier] NOT NULL,
		[ItemId] [int] NOT NULL,
	 CONSTRAINT [PK_SS_AssociatedThreads] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[SS_AssociatedThreads] ADD  CONSTRAINT [DF_SS_AssociatedThreads_Id]  DEFAULT (newid()) FOR [Id]
END