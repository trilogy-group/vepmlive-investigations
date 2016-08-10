---------------TABLE: EPMLive_Log----------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'CUSTOMFIELDS')
	begin
		print 'Creating Table CUSTOMFIELDS'
		CREATE TABLE [dbo].[CUSTOMFIELDS](
		[fieldname] [varchar](255) NOT NULL,
		[editable] [bit] NOT NULL CONSTRAINT [DF_CUSTOMFIELDS_editable]  DEFAULT ((0)),
		[displayName] [varchar](255) NOT NULL,
		[fieldCategory] [int] NOT NULL CONSTRAINT [DF_CUSTOMFIELDS_fieldType]  DEFAULT ((1)),
		[wssFieldName] [varchar](255) NOT NULL,
		[visible] [bit] NULL CONSTRAINT [DF_CUSTOMFIELDS_visible]  DEFAULT ((0)),
		[sealed] [bit] NOT NULL CONSTRAINT [DF_CUSTOMFIELDS_sealed]  DEFAULT ((0)),
		[fieldtype] [varchar](50) NOT NULL,
		[assnfieldname] [varchar](50) NULL,
		[pjvisible] [bit] NOT NULL CONSTRAINT [DF_CUSTOMFIELDS_pjvisible]  DEFAULT ((0)),
		[assnUpdateColumnId] [varchar](255) NULL,
		[multiplier] [int] NOT NULL CONSTRAINT [DF_CUSTOMFIELDS_multiplier]  DEFAULT ((1)),
		 CONSTRAINT [PK_CUSTOMFIELDS] PRIMARY KEY CLUSTERED 
		(
			[wssFieldName] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table CUSTOMFIELDS'
	end



if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'ECONFIG')
	begin
		print 'Creating Table ECONFIG'
		CREATE TABLE [dbo].[ECONFIG](
			[config_id] [varchar](50) NOT NULL CONSTRAINT [DF_ECONFIG_config_id]  DEFAULT (newid()),
			[config_name] [varchar](50) NOT NULL,
			[config_value] [ntext] NOT NULL
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table ECONFIG'
	end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'PUBLISHERCHECK')
	begin
		print 'Creating Table PUBLISHERCHECK'

		CREATE TABLE [dbo].[PUBLISHERCHECK](
			[projectguid] [uniqueidentifier] NULL,
			[webguid] [uniqueidentifier] NULL,
			[checkbit] [bit] NULL CONSTRAINT [DF_publishercheck_checkbit]  DEFAULT ((1)),
			[pubType] [int] NULL CONSTRAINT [DF_publishercheck_pubType]  DEFAULT ((1)),
			[weburl] [varchar](255) NULL,
			[transuid] [uniqueidentifier] NULL,

			[laststatusdate] [datetime] NULL,
			[percentcomplete] [int] NULL,
			[projectname] [varchar](5000) NULL,
			[logtext] [ntext] NULL,
			[status] [int] NULL
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	end
else
	begin
		Print 'Updating Table PUBLISHERCHECK'
	
		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'PUBLISHERCHECK' and column_name = 'laststatusdate')
		begin
			Print '     Add Column laststatusdate'
			ALTER TABLE [PUBLISHERCHECK]
			ADD [laststatusdate] [datetime] NULL
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'PUBLISHERCHECK' and column_name = 'percentcomplete')
		begin
			Print '     Add Column percentcomplete'
			ALTER TABLE [PUBLISHERCHECK]
			ADD [percentcomplete] [int] NULL
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'PUBLISHERCHECK' and column_name = 'projectname')
		begin
			Print '     Add Column projectname'
			ALTER TABLE [PUBLISHERCHECK]
			ADD [projectname] [varchar](5000) NULL
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'PUBLISHERCHECK' and column_name = 'logtext')
		begin
			Print '     Add Column logtext'
			ALTER TABLE [PUBLISHERCHECK]
			ADD [logtext] [ntext] NULL
		end

		if not exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'PUBLISHERCHECK' and column_name = 'status')
		begin
			Print '     Add Column status'
			ALTER TABLE [PUBLISHERCHECK]
			ADD [status] [int] NULL
		end
	
	end
/***************************************************************************/
