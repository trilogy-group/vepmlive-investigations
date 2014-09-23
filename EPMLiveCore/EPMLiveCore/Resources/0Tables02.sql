---------------TABLE: TSUSER----------------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSUSER')
	begin
		print 'Creating Table TSUSER'
		
		CREATE TABLE [dbo].[TSUSER](
			[TSUSERUID] [uniqueidentifier] NULL DEFAULT (newid()),
			[SITE_UID] [uniqueidentifier] NULL,
			[USER_ID] [int] NULL,
			[USERNAME] [varchar](255) NULL,
			[NAME] [varchar](255) NULL
		) ON [PRIMARY]
				
	end
else
	begin
		Print 'Updating Table TSUSER'

		
		
	end
---------------TABLE: TSTIMESHEET----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSTIMESHEET')
	begin
		print 'Creating Table TSTIMESHEET'
		CREATE TABLE [dbo].[TSTIMESHEET](
		[TS_UID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_TSTIMESHEET_TS_UID]  DEFAULT (newid()),
		[USERNAME] [varchar](255) NOT NULL,
		[RESOURCENAME] [varchar](5000) NULL,
		[PERIOD_ID] [int] NOT NULL,
		[LOCKED] [bit] NOT NULL CONSTRAINT [DF_TSTIMESHEET_LOCKED]  DEFAULT ((0)),
		[SITE_UID] [uniqueidentifier] NOT NULL,
		[SUBMITTED] [bit] NOT NULL CONSTRAINT [DF_TSTIMESHEET_SUBMITTED]  DEFAULT ((0)),
		[APPROVAL_STATUS] [int] NOT NULL CONSTRAINT [DF_TSTIMESHEET_APPROVAL_STATUS]  DEFAULT ((0)),
		[APPROVAL_NOTES] [text] NULL,
		[LASTMODIFIEDBYU] [varchar](255) NULL,
		[LASTMODIFIEDBYN] [varchar](255) NULL,
		[TSUSER_UID] [uniqueidentifier] NULL,
		[APPROVAL_DATE] datetime NULL,
		 CONSTRAINT [PK_TSTIMESHEET] PRIMARY KEY CLUSTERED 
		(
			[TS_UID] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table TSTIMESHEET'
		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSTIMESHEET' and column_name = 'LASTMODIFIEDBYU')
		begin
			Print '     Add Column LASTMODIFIEDBYU'
			ALTER TABLE TSTIMESHEET
			ADD [LASTMODIFIEDBYU] [varchar](255) NULL
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSTIMESHEET' and column_name = 'LASTMODIFIEDBYN')
		begin
			Print '     Add Column LASTMODIFIEDBYN'
			ALTER TABLE TSTIMESHEET
			ADD [LASTMODIFIEDBYN] [varchar](255) NULL
			
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSTIMESHEET' and column_name = 'APPROVAL_DATE')
		begin
			Print '     Add Column APPROVAL_DATE'
			ALTER TABLE TSTIMESHEET
			ADD [APPROVAL_DATE] datetime NULL
			
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSTIMESHEET' and column_name = 'TSUSER_UID')
		begin
			Print '     Add Column TSUSER_UID'
			ALTER TABLE TSTIMESHEET
			ADD [TSUSER_UID] uniqueidentifier NULL
			
		end
	end

------------------TABLE: TSITEM---------------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSITEM')
	begin
		Print 'Creating Table TSITEM'
		CREATE TABLE [dbo].[TSITEM](
		[TS_UID] [uniqueidentifier] NOT NULL,
		[TS_ITEM_UID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_TSITEMS_TS_ITEM_UID]  DEFAULT (newid()),
		[WEB_UID] [uniqueidentifier] NOT NULL,
		[LIST_UID] [uniqueidentifier] NOT NULL,
		[ITEM_TYPE] [int] NOT NULL,
		[ITEM_ID] [int] NULL,
		[TITLE] [varchar](255) NULL,
		[PROJECT] [varchar](255) NULL,
		[PROJECT_ID] [int] NULL,
		[LIST] [varchar](255) NULL,
		[APPROVAL_STATUS] [int] NOT NULL CONSTRAINT [DF_TSITEM_APPROVAL_STATUS]  DEFAULT ((0)),
		PROJECT_LIST_UID uniqueidentifier NULL,
		ASSIGNEDTOID int NULL,
		CONSTRAINT [PK_TSITEM] PRIMARY KEY CLUSTERED 
		(
		[TS_ITEM_UID] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table TSITEM'
		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSITEM' and column_name = 'APPROVAL_STATUS')
		begin
			Print '     Add Column APPROVAL_STATUS'
			ALTER TABLE TSITEM
			ADD [APPROVAL_STATUS] [int] NOT NULL CONSTRAINT [DF_TSITEM_APPROVAL_STATUS]  DEFAULT ((0))
		end
		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSITEM' and column_name = 'PROJECT_ID')
		begin
			Print '     Add Column PROJECT_ID'
			ALTER TABLE TSITEM
			ADD [PROJECT_ID] [int] NULL
		end
		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSITEM' and column_name = 'PROJECT_LIST_UID')
		begin
			Print '     Add Column PROJECT_LIST_UID'
			ALTER TABLE TSITEM
			ADD PROJECT_LIST_UID uniqueidentifier NULL
			
		end
	end

------------------TABLE: TSITEMHOURS---------------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSITEMHOURS')
	begin
		Print 'Creating Table TSITEMHOURS'
		CREATE TABLE [dbo].[TSITEMHOURS](
		[TS_ITEM_UID] [uniqueidentifier] NOT NULL,
		[TS_ITEM_DATE] [datetime] NOT NULL,
		[TS_ITEM_HOURS] [float] NOT NULL,
		[TS_ITEM_TYPE_ID] [int] NULL
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table TSITEMHOURS'
	end

------------------TABLE: TSMETA---------------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSMETA')
	begin
		Print 'Creating Table TSMETA'
		CREATE TABLE [dbo].[TSMETA](
			TSMETA_UID uniqueidentifier NOT NULL DEFAULT (newid()),
			[TS_ITEM_UID] [uniqueidentifier] NOT NULL,
			[ColumnName] [varchar](255) NOT NULL,
			[DisplayName] [varchar](255) NULL,
			[ColumnValue] [varchar](4000) NULL,
			[ListName] [varchar](255) NULL,
		 CONSTRAINT [PK_TSMETA] PRIMARY KEY CLUSTERED 
		(
			[TS_ITEM_UID] ASC,
			[ColumnName] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table TSMETA'
		
		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSMETA' and column_name = 'TSMETA_UID')
		begin
			Print '     Add Column TSMETA_UID'
			
			if exists (select column_name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where table_name = 'TSMETA' and CONSTRAINT_NAME = 'PK_TSMETA')
			begin
				ALTER TABLE TSMETA
				DROP CONSTRAINT PK_TSMETA
			end
			
			ALTER TABLE TSMETA
			ADD TSMETA_UID uniqueidentifier NOT NULL DEFAULT (newid())
			
			ALTER TABLE TSMETA
			ADD CONSTRAINT [PK_TSMETA] PRIMARY KEY CLUSTERED 
			(
				TSMETA_UID ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
			
		end
		
	end

------------------TABLE: TSNOTES---------------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSNOTES')
	begin
		Print 'Creating Table TSNOTES'
		CREATE TABLE [dbo].[TSNOTES](
			[TS_ITEM_UID] [uniqueidentifier] NULL,
			[TS_ITEM_DATE] [datetime] NULL,
			[TS_ITEM_NOTES] [ntext] NULL
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table TSNOTES'
	end

------------------TABLE: TSPERIOD---------------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSPERIOD')
	begin
		Print 'Creating Table TSPERIOD'
		CREATE TABLE [dbo].[TSPERIOD](
			[PERIOD_ID] [int] NOT NULL,
			[PERIOD_START] [datetime] NOT NULL,
			[PERIOD_END] [datetime] NOT NULL,
			[LOCKED] [bit] NOT NULL CONSTRAINT [DF_TSPERIODS_LOCKED]  DEFAULT ((0)),
			[SITE_ID] [uniqueidentifier] NOT NULL,
		 CONSTRAINT [PK_TSPERIOD] PRIMARY KEY CLUSTERED 
		(
			[PERIOD_ID] ASC,
			[SITE_ID] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table TSPERIOD'
	end

------------------TABLE: TSRESMETA---------------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSRESMETA')
	begin	
		Print 'Creating Table TSRESMETA'
		CREATE TABLE [dbo].[TSRESMETA](
			[RES_META_ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_TSRESMETA_RES_META_ID]  DEFAULT (newid()),
			[TS_UID] [uniqueidentifier] NOT NULL,
			[Username] [nvarchar](50) NOT NULL,
			[ColumnName] [varchar](255) NOT NULL,
			[DisplayName] [varchar](255) NOT NULL,
			[ColumnValue] [varchar](255) NOT NULL,
		 CONSTRAINT [PK_TSRESMETA] PRIMARY KEY CLUSTERED 
		(
			[RES_META_ID] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table TSRESMETA'
	end

------------------TABLE: TSTYPE---------------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSTYPE')
	begin
		Print 'Creating Table TSTYPE'
		CREATE TABLE [dbo].[TSTYPE](
			[TSTYPE_ID] [int] NOT NULL,
			[SITE_UID] [uniqueidentifier] NOT NULL,
			[TSTYPE_NAME] [varchar](50) NULL,
			[TYPEID] [int] NULL DEFAULT ((1)),
		 CONSTRAINT [PK_TSTYPE] PRIMARY KEY CLUSTERED 
		(
			[TSTYPE_ID] ASC,
			[SITE_UID] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table TSTYPE'

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSTYPE' and column_name = 'TYPEID')
		begin
			Print '     Add Column TYPEID'
			ALTER TABLE TSTYPE
			ADD [TYPEID] [int] NULL DEFAULT ((1))
		end
	end


------------------TABLE: TSQUEUE---------------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSQUEUE')
	begin
		Print 'Creating Table TSQUEUE'
		
		CREATE TABLE [dbo].[TSQUEUE](
			[TSQUEUE_ID] [uniqueidentifier] NOT NULL DEFAULT (newid()),
			[TS_UID] [uniqueidentifier] NOT NULL,
			[STATUS] [int] NOT NULL DEFAULT ((0)),
			[JOBTYPE_ID] [int] NOT NULL,
			[RESULTTEXT] [varchar](max) NULL,
			[RESULT] [varchar](50) NULL,
			[USERID] [int] NOT NULL,
			[DTCREATED] [datetime] NULL,
			[DTSTARTED] [datetime] NULL,
			[DTFINISHED] [datetime] NULL,
			[JOBDATA] ntext NULL,
			[QUEUE] [nvarchar](255) NULL,
			[GRIDDATA] ntext NULL,
			[PERCENTCOMPLETE] [int] NULL
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table TSQUEUE'

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSQUEUE' and column_name = 'PERCENTCOMPLETE')
		begin
			Print '     Add Column PERCENTCOMPLETE'
			ALTER TABLE TSQUEUE
			ADD [PERCENTCOMPLETE] [int] NULL
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSQUEUE' and column_name = 'QUEUE')
		begin
			Print '     Add Column Username'
			ALTER TABLE TSQUEUE
			ADD [QUEUE] [nvarchar](255) NULL
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'TSQUEUE' and column_name = 'GRIDDATA')
		begin
			Print '     Add Column Username'
			ALTER TABLE TSQUEUE
			ADD GRIDDATA ntext NULL
		end


		ALTER TABLE TSQUEUE
		ALTER COLUMN JOBDATA ntext
			
	end

---------------TABLE: TSSW----------------------

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'TSSW')
	begin
		print 'Creating Table TSSW'
		
		CREATE TABLE [dbo].[TSSW](
		[TSITEMUID] [uniqueidentifier] NULL,
		[STARTED] [datetime] NULL,
		[USER_ID] [int] NULL
		) ON [PRIMARY]
				
	end
else
	begin
		Print 'Updating Table TSSW'

		
		
	end


--------------------------------------------------------------------
--------------------------Constraints-------------------------------
--------------------------------------------------------------------

if not exists(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME = 'FK_TSITEM_TSTIMESHEET')
begin
	ALTER TABLE [dbo].[TSITEM]  WITH CHECK ADD  CONSTRAINT [FK_TSITEM_TSTIMESHEET] FOREIGN KEY([TS_UID])
	REFERENCES [dbo].[TSTIMESHEET] ([TS_UID])
	ON UPDATE CASCADE
	ON DELETE CASCADE
end


ALTER TABLE [dbo].[TSITEM] CHECK CONSTRAINT [FK_TSITEM_TSTIMESHEET]


if not exists(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME = 'FK_TSITEMHOURS_TSITEM')
begin
	ALTER TABLE [dbo].[TSITEMHOURS]  WITH CHECK ADD  CONSTRAINT [FK_TSITEMHOURS_TSITEM] FOREIGN KEY([TS_ITEM_UID])
	REFERENCES [dbo].[TSITEM] ([TS_ITEM_UID])
	ON UPDATE CASCADE
	ON DELETE CASCADE
end

ALTER TABLE [dbo].[TSITEMHOURS] CHECK CONSTRAINT [FK_TSITEMHOURS_TSITEM]


if not exists(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME = 'FK_TSMETA_TSITEM')
begin
	ALTER TABLE [dbo].[TSMETA]  WITH CHECK ADD  CONSTRAINT [FK_TSMETA_TSITEM] FOREIGN KEY([TS_ITEM_UID])
	REFERENCES [dbo].[TSITEM] ([TS_ITEM_UID])
	ON UPDATE CASCADE
	ON DELETE CASCADE
end

ALTER TABLE [dbo].[TSMETA] CHECK CONSTRAINT [FK_TSMETA_TSITEM]


if not exists(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME = 'FK_TSNOTES_TSITEM')
begin
	ALTER TABLE [dbo].[TSNOTES]  WITH CHECK ADD  CONSTRAINT [FK_TSNOTES_TSITEM] FOREIGN KEY([TS_ITEM_UID])
	REFERENCES [dbo].[TSITEM] ([TS_ITEM_UID])
	ON UPDATE CASCADE
	ON DELETE CASCADE
end

ALTER TABLE [dbo].[TSNOTES] CHECK CONSTRAINT [FK_TSNOTES_TSITEM]


if not exists(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME = 'FK_TSRESMETA_TSTIMESHEET')
begin
	ALTER TABLE [dbo].[TSRESMETA]  WITH CHECK ADD  CONSTRAINT [FK_TSRESMETA_TSTIMESHEET] FOREIGN KEY([TS_UID])
	REFERENCES [dbo].[TSTIMESHEET] ([TS_UID])
	ON UPDATE CASCADE
	ON DELETE CASCADE
end

ALTER TABLE [dbo].[TSRESMETA] CHECK CONSTRAINT [FK_TSRESMETA_TSTIMESHEET]


if not exists(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME = 'FK_TSTIMESHEET_TSPERIOD')
begin
	ALTER TABLE [dbo].[TSTIMESHEET]  WITH CHECK ADD  CONSTRAINT [FK_TSTIMESHEET_TSPERIOD] FOREIGN KEY([PERIOD_ID], [SITE_UID])
	REFERENCES [dbo].[TSPERIOD] ([PERIOD_ID], [SITE_ID])
	ON UPDATE CASCADE
	ON DELETE CASCADE
end

ALTER TABLE [dbo].[TSTIMESHEET] CHECK CONSTRAINT [FK_TSTIMESHEET_TSPERIOD]


--Indexes--

if not exists(select * from sys.indexes where name = 'GA_IDX_TSITEM_1')
begin
	CREATE NONCLUSTERED INDEX [GA_IDX_TSITEM_1] ON [dbo].[TSITEM] (
	[TS_UID] ASC,
	[TS_ITEM_UID] ASC,
	[LIST_UID] ASC,
	[ITEM_ID] ASC
	)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
end


if not exists(select * from sys.indexes where name = 'GA_IDX_TSITEM_2')
begin
	CREATE NONCLUSTERED INDEX [GA_IDX_TSITEM_2] ON [dbo].[TSITEM] (
	[TS_ITEM_UID] ASC,
	[TS_UID] ASC,
	[LIST_UID] ASC,
	[ITEM_ID] ASC
	)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
end

if not exists(select * from sys.indexes where name = 'GA_IDX_TSITEM_3')
begin
	CREATE NONCLUSTERED INDEX [GA_IDX_TSITEM_3] ON [dbo].[TSITEM] (
	[TS_UID] ASC
	)

	INCLUDE ( [TS_ITEM_UID],
	[WEB_UID],
	[LIST_UID],
	[ITEM_TYPE],
	[ITEM_ID],
	[TITLE],
	[PROJECT],
	[LIST]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
end


if not exists(select * from sys.indexes where name = 'GA_IDX_TSITEMHOURS_1')
begin
	CREATE NONCLUSTERED INDEX [GA_IDX_TSITEMHOURS_1] ON [dbo].[TSITEMHOURS] (
	[TS_ITEM_TYPE_ID] ASC,
	[TS_ITEM_UID] ASC,
	[TS_ITEM_DATE] ASC,
	[TS_ITEM_HOURS] ASC
	)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
end

if not exists(select * from sys.indexes where name = 'GA_IDX_TSITEMHOURS_2')
begin
	CREATE NONCLUSTERED INDEX [GA_IDX_TSITEMHOURS_2] ON [dbo].[TSITEMHOURS](
	[TS_ITEM_UID] ASC)
	INCLUDE ( [TS_ITEM_HOURS]) WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
end

if not exists(select * from sys.indexes where name = 'GA_IDX_TSTIMESHEET_1')
begin
	CREATE NONCLUSTERED INDEX [GA_IDX_TSTIMESHEET_1] ON [dbo].[TSTIMESHEET] (
	[PERIOD_ID] ASC,
	[SITE_UID] ASC,
	[USERNAME] ASC,
	[TS_UID] ASC
	)WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
end