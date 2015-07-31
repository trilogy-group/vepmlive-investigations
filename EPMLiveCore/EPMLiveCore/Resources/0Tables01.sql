
---------------TABLE: EPMLive_Log----------------------
if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'EPMLive_Log' and column_name = 'timerjobuid')
begin

	if exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPMLive_Log')
	begin
		DROP TABLE EPMLive_log
		Print '     Dropping EPM Live Log'
	end
	

end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EPMLive_Log')
	begin
		print 'Creating Table EPMLive_Log'
		
		CREATE TABLE [dbo].[EPMLIVE_LOG](
			[loguid] [uniqueidentifier] NULL DEFAULT (newid()),
			[timerjobuid] [uniqueidentifier] NULL,
			[result] [varchar](50) NULL,
			[resulttext] [ntext] NULL,
			[dtlogged] [datetime] NULL DEFAULT (getdate())
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table EPMLive_Log'
		
	end
---------------TABLE: FEATUREUSERS----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'FEATUREUSERS')
	begin
		print 'Creating Table FEATUREUSERS'
		
		CREATE TABLE [dbo].[FEATUREUSERS](
		[featureuserid] [uniqueidentifier] NULL DEFAULT (newid()),
		[featureid] [int] NULL,
		[username] [varchar](500) NULL
		) ON [PRIMARY]

	end
else
	begin
		Print 'Updating Table FEATUREUSERS'

		
	end

---------------TABLE: RPTDATABASES----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RPTDATABASES')
	begin
		print 'Creating Table RPTDATABASES'
		
		CREATE TABLE [dbo].[RPTDATABASES](
		[SiteId] [uniqueidentifier] NOT NULL,
		[WebApplicationId] [uniqueidentifier] NOT NULL,
		[Url] [nvarchar](100) NOT NULL,
		[DatabaseServer] [nvarchar](50) NOT NULL,
		[DatabaseName] [nvarchar](50) NOT NULL,
		[Username] [nvarchar](200) NULL,
		[Password] [nvarchar](200) NULL,
		[SAccount] [bit] NULL
		) ON [PRIMARY]

	end
else
	begin
		Print 'Updating Table RPTDATABASES'

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'RPTDATABASES' and column_name = 'Username')
		begin
			Print '     Add Column Username'
			ALTER TABLE RPTDATABASES
			ADD [Username] [nvarchar](200) NULL
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'RPTDATABASES' and column_name = 'Password')
		begin
			Print '     Add Column Password'
			ALTER TABLE RPTDATABASES
			ADD [Password] [nvarchar](200) NULL
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'RPTDATABASES' and column_name = 'SAccount')
		begin
			Print '     Add Column SAccount'
			ALTER TABLE RPTDATABASES
			ADD [SAccount] [bit] NULL
		end
		
	end

---------------TABLE: RESINFO----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RESINFO')
	begin
		print 'Creating Table RESINFO'
		CREATE TABLE [dbo].[RESINFO](
		[Project] [nvarchar](255) NULL,
		[Title] [nvarchar](255) NULL,
		[AssignedTo] [nvarchar](255) NULL,
		[StartDate] [datetime] NULL,
		[DueDate] [datetime] NULL,
		[ItemType] [nvarchar](255) NULL,
		[Status] [nvarchar](255) NULL,
		[Work] [float] NULL,
		[SiteId] [uniqueidentifier] NULL
		) ON [PRIMARY]


	end
else
	begin
		Print 'Updating Table RESINFO'
	end

---------------TABLE: RESLINK----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RESLINK')
	begin
		print 'Creating Table RESLINK'
		CREATE TABLE [dbo].[RESLINK](
		[weburl] [nvarchar](255) NULL,
		[resurl] [nvarchar](255) NULL,
		[siteid] [uniqueidentifier] NULL,
		[nonworkdays] [nvarchar](15) NULL,
		[workhours] [float] NULL
		) ON [PRIMARY]

	end
else
	begin
		Print 'Updating Table RESLINK'
		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'RESLINK' and column_name = 'nonworkdays')
		begin
			Print '     Add Column nonworkdays'
			ALTER TABLE RESLINK
			ADD [nonworkdays] [nvarchar](15) NULL
		end
		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'RESLINK' and column_name = 'workhours')
		begin
			Print '     Add Column workhours'
			ALTER TABLE RESLINK
			ADD [workhours] [float] NULL
		end
	end

---------------TABLE: VERSIONS----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'VERSIONS')
	begin
		print 'Creating Table VERSIONS'
		CREATE TABLE [dbo].[VERSIONS](
			[VERSION] [varchar](10) NULL,
			[dtInstalled] [datetime] NULL
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table VERSIONS'
	end


-------------TABLE: QUEUE----------------------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'QUEUE')
	begin
		print 'Creating Table QUEUE'

		CREATE TABLE [dbo].[QUEUE](
			[queueuid] [uniqueidentifier] NOT NULL DEFAULT (newid()),
			[timerjobuid] [uniqueidentifier] NULL,
			[percentComplete] [int] NOT NULL,
			[status] [int] NOT NULL DEFAULT ((0)),
			[dtcreated] [datetime] NULL DEFAULT (getdate()),
			[dtstarted] [datetime] NULL,
			[dtfinished] [datetime] NULL,
			[userid] [int] NULL
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table QUEUE'
		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'QUEUE' and column_name = 'userid')
		begin
			Print '     Add Column workhours'
			ALTER TABLE QUEUE
			ADD [userid] [int] NULL
		end
				
	end


-------------TABLE: TIMERJOBS----------------------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TIMERJOBS')
	begin
		print 'Creating Table TIMERJOBS'

		CREATE TABLE [dbo].[TIMERJOBS](
			[timerjobuid] [uniqueidentifier] NOT NULL DEFAULT (newid()),
			[jobname] [varchar](255) NULL,
			[siteguid] [uniqueidentifier] NULL,
			[webguid] [uniqueidentifier] NULL,
			[listguid] [uniqueidentifier] NULL,
			[itemid] [int] NULL,
			[jobtype] [int] NULL,
			[enabled] [bit] NULL,
			[runtime] [int] NULL,
			[scheduletype] [int] NULL,
			[days] [varchar](50) NULL,
			[jobdata] [ntext] NULL,
			[lastqueuecheck] [datetime] NULL,
			[key] [varchar](255) NULL,
			[parentjobuid] [uniqueidentifier] NULL,
		 CONSTRAINT [PK_TIMERJOBS] PRIMARY KEY CLUSTERED 
		(
			[timerjobuid] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table TIMERJOBS'
		
		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TIMERJOBS' and column_name = 'itemid')
		begin
			Print '     Add Column itemid'
			ALTER TABLE TIMERJOBS
			ADD [itemid] [int] NULL
		end
		
		if (select data_type FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TIMERJOBS' and column_name = 'jobdata') = 'varchar'
		begin
			Print '     Update Column jobdata'
			ALTER TABLE TIMERJOBS
			ALTER COLUMN [jobdata] [ntext]
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TIMERJOBS' and column_name = 'key')
		begin
			Print '     Add Column itemid'
			ALTER TABLE TIMERJOBS
			ADD [key] [varchar](255) NULL
		end

	end

-------------TimerJobTypes--------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TIMERJOBTYPES')
	begin
		print 'Creating Table TIMERJOBTYPES'
		
		CREATE TABLE [dbo].[TIMERJOBTYPES](
			[JOBTYPE_ID] [int] NULL,
			[NetAssembly] [varchar](255) NULL,
			[NetClass] [varchar](255) NULL,
			[Title] [varchar](50) NULL,
			[Priority] [int] NULL
		)

end
else
begin
	print 'Updating Table TIMERJOBTYPES'

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TIMERJOBTYPES' and column_name = 'Priority')
		begin
			Print '     Add Column Priority'
			ALTER TABLE TIMERJOBTYPES
			ADD [Priority] [int] NULL
		end
	
end


--------------------PERSONALIZATIONS-----------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'PERSONALIZATIONS')
	begin
		print 'Creating Table PERSONALIZATIONS'
		CREATE TABLE [dbo].[PERSONALIZATIONS](
			[Id] [uniqueidentifier] NOT NULL,
			[Key] [nvarchar](255) NOT NULL,
			[Value] [nvarchar](max) NULL,
			[UserId] [nvarchar](255) NULL,
			[SiteId] [uniqueidentifier] NULL,
			[WebId] [uniqueidentifier] NULL,
			[ListId] [uniqueidentifier] NULL,
			[ItemId] [int] NULL,
			[FK] [uniqueidentifier] NULL,
		 CONSTRAINT [PK_PERSONALIZATIONS] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
		ALTER TABLE [dbo].[PERSONALIZATIONS] ADD  CONSTRAINT [DF_PERSONALIZATIONS_Id]  DEFAULT (newid()) FOR [Id]

end
else
begin
	print 'Updating Table PERSONALIZATIONS'

	if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'PERSONALIZATIONS' and column_name = 'FK')
	begin
		alter table PERSONALIZATIONS
		ADD [FK] [uniqueidentifier] NULL
	end
end

---------------------EMAILTEMPLATES-----------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'EMAILTEMPLATES')
begin
	print 'Creating Table EMAILTEMPLATES'

	CREATE TABLE [dbo].[EMAILTEMPLATES](
	[EmailId] [int] NULL,
	[Body] [varchar](max) NULL,
	[Subject] [varchar](max) NULL,
	[Title] [varchar](255) NULL
	)

end
else
begin
	print 'Updating Table EMAILTEMPLATES'
end

--------------------------NOTIFICATIONS----------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'NOTIFICATIONS')
begin
	print 'Creating Table NOTIFICATIONS'

	CREATE TABLE [dbo].[NOTIFICATIONS](
	[ID] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Title] [nvarchar](255) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[Type] [smallint] NOT NULL,
	[SiteCreationDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL DEFAULT (getdate()),
	[SiteID] [uniqueidentifier] NULL,
	[WebID] [uniqueidentifier] NULL,
	[ListID] [uniqueidentifier] NULL,
	[ItemID] [int] NULL,
	[Emailed] [bit] NULL DEFAULT ((0)),
	CONSTRAINT [PK_NOTIFICATIONS] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	)
end
else
begin
	print 'Updating Table NOTIFICATIONS'
end


-----------------------------------TAGS------------------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TAGS')
	begin
		
		print 'Creating Table Tags'

		CREATE TABLE [dbo].[Tags](
		  [TagId] [uniqueidentifier] NOT NULL DEFAULT (newid()) ,
		  [Name] [nvarchar](50) NULL,
		  [Type] [int] NULL,
		  [ResourceId] [int] NULL,
		  SiteId [uniqueidentifier] NULL,
		CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
		(
			  [TagId] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]


end
else
begin

	print 'Updating Table Tags'

end

-------------------------TAGORDERS-------------------------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TAGORDERS')
	begin
		
		print 'Creating Table TagOrders'

		CREATE TABLE [dbo].[TagOrders](
		  [TagOrderId] [uniqueidentifier] NOT NULL DEFAULT (newid()) ,
		  [TagId] [uniqueidentifier] NOT NULL,
		  [ListId] [uniqueidentifier] NOT NULL,
		  [ItemId] [int] NOT NULL,
		  [TagOrder] [int] NOT NULL,
		CONSTRAINT [PK_TagOrders] PRIMARY KEY CLUSTERED 
		(
			  [TagOrderId] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
		CONSTRAINT [UK_TagOrders_TagId_ListId_ItemId] UNIQUE NONCLUSTERED 
		(
			  [TagId] ASC,
			  [ListId] ASC,
			  [ItemId] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

end
else
begin

	print 'Updating Table TagOrders'


end

-------------------------INT_COLUMNS-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_COLUMNS')
	begin
		
		print 'Creating Table INT_COLUMNS'

		CREATE TABLE [dbo].[INT_COLUMNS](
			[INT_COLUMN_ID] [uniqueidentifier] NOT NULL DEFAULT (newid()),
			[INT_LIST_ID] [uniqueidentifier] NULL,
			[SharePointColumn] [varchar](255) NULL,
			[IntegrationColumn] [varchar](255) NULL,
			[Setting] [int] NULL
		) ON [PRIMARY]


end
else
begin

	print 'Updating Table INT_COLUMNS'


end

-------------------------INT_EVENTs-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_EVENTS')
	begin
		
		print 'Creating Table INT_EVENTS'

		CREATE TABLE [dbo].[INT_EVENTS](
			[INT_EVENT_ID] [uniqueidentifier] NULL DEFAULT (newid()),
			[LIST_ID] [uniqueidentifier] NULL,
			[ITEM_ID] [int] NULL,
			[INTITEM_ID] [varchar](255) NULL,
			[COL_ID] [int] NULL,
			[STATUS] [int] NULL,
			[QUEUE] [varchar](255) NULL,
			[EVENT_TIME] [datetime] NULL DEFAULT (getdate()),
			[DIRECTION] [int] NULL,
			[TYPE] [int] NULL,
			[DATA] [ntext] null
		) ON [PRIMARY]


end 
else
begin

	print 'Updating Table INT_EVENTS'

	if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'INT_EVENTS' and column_name = 'DATA')
	begin
		alter table INT_EVENTS
		ADD [DATA] [ntext] NULL
	end

end

-------------------------INT_IP-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_IP')
	begin
		
		print 'Creating Table INT_IP'

		CREATE TABLE [dbo].[INT_IP](
			[INT_IP_ID] [uniqueidentifier] NULL DEFAULT (newid()),
			[DTLOGGED] [datetime] NULL DEFAULT (getdate()),
			[IP] [varchar](50) NULL,
			[INTKEY] [varchar](255) NULL
		) ON [PRIMARY]


end
else
begin

	print 'Updating Table INT_IP'


end


-------------------------INT_LISTS-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_LISTS')
	begin
		
		print 'Creating Table INT_LISTS'

		CREATE TABLE [dbo].[INT_LISTS](
			[INT_LIST_ID] [uniqueidentifier] NOT NULL DEFAULT (newid()),
			[MODULE_ID] [uniqueidentifier] NOT NULL,
			[LIST_ID] [uniqueidentifier] NULL,
			[WEB_ID] [uniqueidentifier] NULL,
			[SITE_ID] [uniqueidentifier] NULL,
			[INT_COLID] [int] NULL,
			[PRIORITY] [int] NULL,
			[SITE_PRIORITY] [int] NULL,
			[PARENT_LIST_ID] [uniqueidentifier] NULL,
			[INT_KEY] [varchar](255) NULL,
			[LIVEOUTGOING] [bit] NULL,
			[LIVEINCOMING] [bit] NULL,
			[TIMEOUTGOING] [bit] NULL,
			[TIMEINCOMING] [bit] NULL,
			[ACTIVE] [bit] NULL DEFAULT ((0)),
			[LASTSYNCH] [datetime] NULL
		) ON [PRIMARY]


end
else
begin

	print 'Updating Table INT_LISTS'


end


-------------------------INT_LOG-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_LOG')
	begin
		
		print 'Creating Table INT_LOG'

		CREATE TABLE [dbo].[INT_LOG](
			[INT_LOG_ID] [uniqueidentifier] NULL DEFAULT (newid()),
			[INT_LIST_ID] [uniqueidentifier] NULL,
			[LIST_ID] [uniqueidentifier] NULL,
			[LOGTYPE] [int] NULL,
			[LOGTEXT] [varchar](max) NULL,
			[DTLOGGED] [datetime] NULL DEFAULT (getdate())
		) ON [PRIMARY]


end
else
begin

	print 'Updating Table INT_LOG'


end

-------------------------INT_MODULES-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_MODULES')
	begin
		
		print 'Creating Table INT_MODULES'

		CREATE TABLE [dbo].[INT_MODULES](
		[MODULE_ID] [uniqueidentifier] NOT NULL,
		[NetAssembly] [varchar](8000) NOT NULL,
		[NetClass] [varchar](255) NOT NULL,
		[Title] [varchar](50) NOT NULL,
		[Description] [varchar](8000) NULL,
		[Icon] [varchar](50) NULL,
		[CustomProps] [varchar](max) NULL,
		[AvailableOnline] [bit] NULL,
		[INT_CAT_ID] [uniqueidentifier] NULL
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


end
else
begin

	print 'Updating Table INT_MODULES'

	if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'INT_MODULES' and column_name = 'INT_CAT_ID')
	begin
		alter table INT_MODULES
		ADD [INT_CAT_ID] [uniqueidentifier] NULL
	end
end

------------------------INT_CATEGORY--------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_CATEGORY')
	begin
		
		print 'Creating Table INT_CATEGORY'

		CREATE TABLE [dbo].[INT_CATEGORY](
			[INT_CAT_ID] [uniqueidentifier] NOT NULL,
			[CATEGORY] [varchar](255) NULL,
			[ICON] [varchar](50) NULL,
			[ORDERBY] [int] NULL
		) ON [PRIMARY]
end
else
begin

	print 'Updating Table INT_CATEGORY'

end

-------------------------INT_PROPS-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_PROPS')
	begin
		
		print 'Creating Table INT_PROPS'

		CREATE TABLE [dbo].[INT_PROPS](
			[INT_PROP_ID] [uniqueidentifier] NULL DEFAULT (newid()),
			[INT_LIST_ID] [uniqueidentifier] NULL,
			[PROPERTY] [varchar](50) NULL,
			[VALUE] [varchar](max) NULL
		) ON [PRIMARY]


end
else
begin

	print 'Updating Table INT_PROPS'

	ALTER TABLE INT_PROPS
	ALTER COLUMN [VALUE] [varchar](max) NULL
end

-------------------------INT_PROPS-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_CHECK')
	begin
		
		print 'Creating Table INT_CHECK'

		CREATE TABLE [dbo].[INT_CHECK](
			[INT_ITEM_CHECK] [uniqueidentifier] NULL DEFAULT (newid()),
			[INT_LIST_ID] [uniqueidentifier] NULL,
			[ITEM_ID] [int] NULL,
			[CHECKBIT] [bit] NULL,
			[CHECKTIME] [datetime] NULL
		) ON [PRIMARY]


end
else
begin

	print 'Updating Table INT_CHECK'


end





-------------------------PLANNERLINK-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'PLANNERLINK')
	begin
		
		print 'Creating Table PLANNERLINK'
		
		CREATE TABLE [dbo].[PLANNERLINK](
			[PlannerLink_Id] [uniqueidentifier] NULL DEFAULT (newid()),
			[PlannerID] [varchar](255) NULL,
			[SourceProjectID] [int] NULL,
			[SourceTaskID] [varchar](50) NULL,
			[DestProjectID] [int] NULL,
			[DestTaskID] [varchar](50) NULL,
			[Predecessors] [varchar](50) NULL,
			[Successors] [varchar](50) NULL,
			[Linked] [bit] NULL
		) ON [PRIMARY]


end
else
begin

	print 'Updating Table PLANNERLINK'


end

-------------------------ITEMSEC-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'ITEMSEC')
	begin
		
		print 'Creating Table ITEMSEC'
		
		

		CREATE TABLE [dbo].[ITEMSEC](
			[ITEM_SEC_ID] [uniqueidentifier] NULL DEFAULT (newid()),
			[SITE_ID] [uniqueidentifier] NULL,
			[WEB_ID] [uniqueidentifier] NULL,
			[LIST_ID] [uniqueidentifier] NULL,
			[ITEM_ID] [int] NULL,
			[USER_ID] [int] NULL,
			[dtadded] [datetime] NULL DEFAULT (getdate()),
			[PRIORITY] [int] NULL DEFAULT ((1)),
			[QUEUE] [varchar](255) NULL,
			[STATUS] [int] NULL DEFAULT ((0)),
			[resulttext] [ntext] NULL,
		) ON [PRIMARY]

end
else
begin

	print 'Updating Table ITEMSEC'

	if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'ITEMSEC' and column_name = 'PRIORITY')
	begin
		alter table ITEMSEC
		ADD [PRIORITY] [int] NULL DEFAULT ((1))
	end

	if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'ITEMSEC' and column_name = 'STATUS')
	begin
		alter table ITEMSEC
		ADD [STATUS] [int] NULL DEFAULT ((0))
	end
	
	if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'ITEMSEC' and column_name = 'resulttext')
	begin
		alter table ITEMSEC
		ADD [resulttext] [ntext] NULL
	end

end


-----------------------------INT_AUTH-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_AUTH')
	begin
		
		print 'Creating Table INT_AUTH'

		
		CREATE TABLE [dbo].[INT_AUTH](
			[AUTH_ID] [uniqueidentifier] NULL,
			[username] [varchar](255) NULL,
			[email] [varchar](500) NULL,
			[datetime] [datetime] NULL
		) ON [PRIMARY]

end
else
begin

	print 'Updating Table INT_AUTH'


end

-----------------------------INT_CONTROLS-----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'INT_CONTROLS')
	begin
		
		print 'Creating Table INT_CONTROLS'

		CREATE TABLE [dbo].[INT_CONTROLS](
			[INT_CONTROL_ID] [uniqueidentifier] NULL DEFAULT (newid()),
				[INT_LIST_ID] [uniqueidentifier] NULL,
				[CONTROL] [varchar](255) NULL,
				[LOCAL] [bit] NULL,
				[TITLE] [varchar](255) NULL,
				[IMAGE] [varchar](255) NULL,
				[GLOBAL] [bit] NULL,
				[WINDOWSTYLE] [int] NULL
		) ON [PRIMARY]
end
else
begin

	print 'Updating Table INT_CONTROLS'


end


-----------------------------FRF-------------------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'FRF')
	begin
		
		print 'Creating Table FRF'

		
		CREATE TABLE [dbo].[FRF](
                [FRF_ID] [uniqueidentifier] NOT NULL default newid(),
                [SITE_ID] [uniqueidentifier] NULL,
                [WEB_ID] [uniqueidentifier] NULL,
                [LIST_ID] [uniqueidentifier] NULL,
                [ITEM_ID] [int] NULL,
                [USER_ID] [int] NULL,
                [Title] [varchar](max) NULL,
                [Icon] [varchar](50) NULL,
                [Type] [int] NULL,
                [F_String] [varchar](max) NULL,
                [F_Date] [datetime] NULL,
                [F_Int] [int] NULL,
			CONSTRAINT [PK_FRF] PRIMARY KEY CLUSTERED 
			(
							[FRF_ID] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
			) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

end
else
begin

	print 'Updating Table FRF'


end

-----------------Izenda------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'IzendaAdHocReports')
	begin
		
		print 'Creating Table Reports'
	
		CREATE TABLE [dbo].[IzendaAdHocReports](
			[Name] [nvarchar](255) NULL,
			[Xml] [ntext] NULL,
			[CreatedDate] [datetime] NULL,
			[ModifiedDate] [datetime] NULL,
			[TenantID] [nvarchar](255) NULL,
			[Thumbnail] [varbinary](max) NULL
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
		
end
else
begin

	print 'Updating Table Reports'


end


-----------------PLATFORMINTEGRATIONS------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'PLATFORMINTEGRATIONS')
	begin
		
		print 'Creating Table PLATFORMINTEGRATIONS'
	
		CREATE TABLE [dbo].[PLATFORMINTEGRATIONS](
			[PlatformIntegrationId] [uniqueidentifier] NULL,
			[ListId] [uniqueidentifier] NULL,
			[IntegrationKey] [varchar](255) NULL,
			[IntegrationUrl] [varchar](2000) NULL
		)
		
end
else
begin

	print 'Updating Table PLATFORMINTEGRATIONS'


end
-----------------PLATFORMINTEGRATIONLOG------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'PLATFORMINTEGRATIONLOG')
	begin
		
		print 'Creating Table PLATFORMINTEGRATIONLOG'
	
		CREATE TABLE [dbo].[PLATFORMINTEGRATIONLOG](
			[LOG_ID] [uniqueidentifier] NULL DEFAULT (newid()),
			[PlatformIntegrationId] [uniqueidentifier] NULL,
			[DTLOGGED] [datetime] NULL,
			[MESSAGE] [ntext] NULL,
			[LOGLEVEL] [int] NULL
		)
		
end
else
begin

	print 'Updating Table PLATFORMINTEGRATIONLOG'


end

-----------------PLATFORMINTEGRATIONControlS------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'PLATFORMINTEGRATIONCONTROLS')
	begin
		
		print 'Creating Table PLATFORMINTEGRATIONCONTROLS'
		
		CREATE TABLE [dbo].[PLATFORMINTEGRATIONCONTROLS](
			[PLATFORMCONTROLID] [uniqueidentifier] NULL,
			[PlatformIntegrationId] [uniqueidentifier] NULL,
			[ControlId] [varchar](255) NULL,
			[DisplayName] [varchar](255) NULL,
			[Image] [varchar](255) NULL,
			[Global] [bit] NULL,
			[ButtonStyle] [varchar](50) NULL,
			[WindowStyle] [varchar](50) NULL
		) ON [PRIMARY]
		
end
else
begin

	print 'Updating Table PLATFORMINTEGRATIONCONTROLS'


end


-----------------ROLLUPQUEUE------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'ROLLUPQUEUE')
	begin
		
		print 'Creating Table ROLLUPQUEUE'
		
		CREATE TABLE [dbo].[ROLLUPQUEUE](
			[EventId] [uniqueidentifier] NULL DEFAULT (newid()),
			[SiteId] [uniqueidentifier] NULL,
			[WebId] [uniqueidentifier] NULL,
			[ListId] [uniqueidentifier] NULL,
			[ItemId] [int] NULL,
			[EventTime] [datetime] NULL,
			[Status] [int] NULL,
			[QueueServer] [varchar](255) NULL,
			[ErrorLog] [ntext] NULL
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
		
end
else
begin

	print 'Updating Table ROLLUPQUEUE'


end

-----------------LOGS------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'Logs')
	begin
		
		print 'Creating Table Logs'
		
		CREATE TABLE [dbo].[Logs](
			[Id] [uniqueidentifier] NOT NULL,
			[Component] [nvarchar](255) NOT NULL,
			[Message] [nvarchar](max) NOT NULL,
			[StackTrace] [nvarchar](max) NULL,
			[Details] [nvarchar](max) NULL,
			[Kind] [tinyint] NOT NULL,
			[WebId] [uniqueidentifier] NULL,
			[UserId] [int] NULL,
			[DateTime] [datetime2](7) NOT NULL,
		 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

		ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_Id]  DEFAULT (newid()) FOR [Id]
		ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_DateTime]  DEFAULT (getdate()) FOR [DateTime]
end
else
begin

	print 'Updating Table Logs'


end

-------------------------Constraints-----------------

if not exists(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME = 'FK_EPMLIVE_LOG_TIMERJOBS')
begin
	ALTER TABLE [dbo].[EPMLIVE_LOG]  WITH CHECK ADD  CONSTRAINT [FK_EPMLIVE_LOG_TIMERJOBS] FOREIGN KEY([timerjobuid])
	REFERENCES [dbo].[TIMERJOBS] ([timerjobuid])
	ON UPDATE CASCADE
	ON DELETE CASCADE

end

ALTER TABLE [dbo].[EPMLIVE_LOG] CHECK CONSTRAINT [FK_EPMLIVE_LOG_TIMERJOBS]

if not exists(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME = 'FK_QUEUE_TIMERJOBS')
begin
	ALTER TABLE [dbo].[QUEUE]  WITH CHECK ADD  CONSTRAINT [FK_QUEUE_TIMERJOBS] FOREIGN KEY([timerjobuid])
	REFERENCES [dbo].[TIMERJOBS] ([timerjobuid])
	ON UPDATE CASCADE
	ON DELETE CASCADE
end

ALTER TABLE [dbo].[QUEUE] CHECK CONSTRAINT [FK_QUEUE_TIMERJOBS]