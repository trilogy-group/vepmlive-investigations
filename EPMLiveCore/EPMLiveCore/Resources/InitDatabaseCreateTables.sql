
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RPTGROUPUSER')
	begin
		
		print 'Creating Table RPTGROUPUSER'

		CREATE TABLE [dbo].[RPTGROUPUSER](
		[RPTGROUPUSERID] [uniqueidentifier] NULL,
		[SITEID] [uniqueidentifier] NULL,
		[GROUPID] [int] NULL,
		[USERID] [int] NULL
		) ON [PRIMARY]

		ALTER TABLE [dbo].[RPTGROUPUSER] ADD  CONSTRAINT [DF_RPTGROUPUSER_RPTGROUPUSERID]  DEFAULT (newid()) FOR [RPTGROUPUSERID]
	end
else
	begin

		print 'Updating Table RPTGROUPUSER'


	end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RPTITEMGROUPS')
	begin
		
		print 'Creating Table RPTITEMGROUPS'

		CREATE TABLE [dbo].[RPTITEMGROUPS](
		[RPTIEMGROUPID] [uniqueidentifier] NULL,
		[SITEID] [uniqueidentifier] NULL,
		[LISTID] [uniqueidentifier] NULL,
		[ITEMID] [int] NULL,
		[GROUPID] [int] NULL,
		[SECTYPE] [int] NULL
		) ON [PRIMARY]

		ALTER TABLE [dbo].[RPTITEMGROUPS] ADD  CONSTRAINT [DF_RPTITEMGROUPS_RPTIEMGROUPID]  DEFAULT (newid()) FOR [RPTIEMGROUPID]

	end
else
	begin

		print 'Updating Table RPTITEMGROUPS'
	end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RPTLog')
	begin
		
		print 'Creating Table RPTLog'

		CREATE TABLE [dbo].[RPTLog](
			[RPTListId] [uniqueidentifier] NULL,
			[ListName] [nvarchar](500) NULL,
			[ShortMessage] [ntext] NOT NULL,
			[LongMessage] [ntext] NULL,
			[Level] int NOT NULL,
			[Type] [int] NOT NULL,
			[Timestamp] [datetime] NOT NULL,
			[timerjobguid] uniqueidentifier NULL
		) ON [PRIMARY]

		ALTER TABLE [dbo].[RPTLog] ADD  CONSTRAINT [DF_RPTLog_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
end
else
begin

	print 'Updating Table RPTLog'



end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RPTList')
	begin
		
		print 'Creating Table RPTList'

		CREATE TABLE [dbo].[RPTList](
			[RPTListId] [uniqueidentifier] NOT NULL,
			[ListName] [nvarchar](50) NOT NULL,
			[SiteId] [uniqueidentifier] NOT NULL,
			[TableName] [nvarchar](50) NOT NULL,
			[TableNameSnapshot] [nvarchar](50) NOT NULL,
			[System] [bit] NOT NULL,
			[ResourceList] [bit] NOT NULL,
		 CONSTRAINT [PK_RPTList] PRIMARY KEY CLUSTERED 
		(
			[RPTListId] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
end
else
begin

	print 'Updating Table RPTList'


end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RPTColumn')
	begin
		
		print 'Creating Table RPTColumn'

		CREATE TABLE [dbo].[RPTColumn](
			[RPTListId] [uniqueidentifier] NOT NULL,
			[ColumnName] [nvarchar](50) NOT NULL,
			[ColumnType] [nvarchar](50) NOT NULL,
			[ColumnSize] [int] NOT NULL,
			[SharePointType] [nvarchar](50) NOT NULL,
			[InternalName] [nvarchar](50) NOT NULL,
			[DisplayName] [nvarchar](500) NOT NULL
		) ON [PRIMARY]

		ALTER TABLE [dbo].[RPTColumn]  WITH CHECK ADD  CONSTRAINT [FK_RPTColumn_RPTList] FOREIGN KEY([RPTListId])
		REFERENCES [dbo].[RPTList] ([RPTListId])
		ON UPDATE CASCADE
		ON DELETE CASCADE

		ALTER TABLE [dbo].[RPTColumn] CHECK CONSTRAINT [FK_RPTColumn_RPTList]

end
else
begin

	print 'Updating Table RPTColumn'


end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'Version')
	begin
		
		print 'Creating Table Version'

		CREATE TABLE [dbo].[Version](
			[Version] [nvarchar](100) NOT NULL,
			[Installed On] [datetime] NOT NULL,
		)
end
else
begin

	print 'Updating Table Version'


end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RPTWork')
	begin
		
		print 'Creating Table RPTWork'

		CREATE TABLE [dbo].[RPTWork](
		  [ID] [uniqueidentifier] ROWGUIDCOL  NULL,
		  [SiteID] [uniqueidentifier] NULL,
		  [ListID] [uniqueidentifier] NULL,
		  [AssignedTo] [int] NULL,
		  [Work] [float] NULL,
		  [Date] [datetime] NULL,
		  [ItemID] [int] NULL
		) ON [PRIMARY]

		ALTER TABLE [dbo].[RPTWork] ADD  CONSTRAINT [DF_Assignments_ID]  DEFAULT (newid()) FOR [ID]

end
else
begin

	print 'Updating Table RPTWork'


end

if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RPTReslink')
	begin
		
		print 'Creating Table RPTReslink'

		CREATE TABLE [dbo].[RPTReslink](
			  [SiteID] [uniqueidentifier] NULL,
			  [WebURL] [nchar](255) NULL,
			  [ListID] [uniqueidentifier] NULL
		) ON [PRIMARY]

end
else
begin

	print 'Updating Table RPTReslink'


end



if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RPTSettings')
	begin
		
		print 'Creating Table RPTSettings'

		CREATE TABLE [dbo].[RPTSettings](
			[SiteID] [uniqueidentifier] NOT NULL,
			[NonWorkingDays] [nchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
			[WorkHours] [int] NULL,
			[TableCount] [int] IDENTITY(0,1) NOT NULL,
			[SiteName] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
			[SiteUrl] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
		) ON [PRIMARY]

end
else
begin

	print 'Updating Table RPTSettings'


end


if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'RPTPeriods')
	begin
		
		print 'Creating Table RPTPeriods'

		CREATE TABLE [dbo].[RPTPeriods](
			  [PeriodID] [uniqueidentifier] NOT NULL,
			  [SiteId] [uniqueidentifier] NULL,
			  [Title] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
			  [PeriodDate] [datetime] NULL,
			  [DateArchived] [datetime] NULL,
			  [Enabled] [bit] NULL,
			  [ListNames] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
			  [timerjobguid] uniqueidentifier NULL,
		 CONSTRAINT [PK_RPTPeriod] PRIMARY KEY CLUSTERED 
		(
			[PeriodID] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

end
else
begin

	print 'Updating Table RPTPeriods'

if exists (select column_name FROM INFORMATION_SCHEMA.COLUMNS where table_name = 'RPTPeriods' and column_name = 'ListNames')
                                begin
                                                Print 'Updating Column ListNames'
                                                ALTER TABLE RPTPeriods 
			         ALTER COLUMN ListNames nvarchar(MAX)
                                end

end


execute('INSERT INTO Version VALUES(@version,getdate())')



declare @createoralter varchar(10)
------------------------------View: VWRPTLastProcessed---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'VWRPTLastProcessed')
begin
    Print 'Creating View VWRPTLastProcessed'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View VWRPTLastProcessed'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[VWRPTLastProcessed]
AS
	SELECT     RPTListId, Type, MAX(Timestamp) AS LastProcessed
	FROM         dbo.RPTLog
	GROUP BY RPTListId, Type
')
 
 ------------------------------View: VWRPTMaxErrorLevel---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'VWRPTMaxErrorLevel')
begin
    Print 'Creating View VWRPTMaxErrorLevel'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View VWRPTMaxErrorLevel'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[VWRPTMaxErrorLevel]
AS
	SELECT     RPTListId, MAX([Level]) AS MaxErrorLevel, Type
	FROM         dbo.RPTLog
	GROUP BY RPTListId, Type
')


------------------------------View: VWRPTLogSummary---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'VWRPTLogSummary')
begin
    Print 'Creating View VWRPTLogSummary'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View VWRPTLogSummary'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[VWRPTLogSummary]
AS
	SELECT     MAX(dbo.RPTLog.[Level]) AS MostRecentLevel, dbo.VWRPTLastProcessed.LastProcessed, dbo.VWRPTLastProcessed.RPTListId, dbo.VWRPTLastProcessed.Type, 
						  dbo.VWRPTMaxErrorLevel.MaxErrorLevel AS MaxLogLevel
	FROM       dbo.RPTLog INNER JOIN
						  dbo.VWRPTLastProcessed ON dbo.RPTLog.RPTListId = dbo.VWRPTLastProcessed.RPTListId AND dbo.RPTLog.Type = dbo.VWRPTLastProcessed.Type AND 
						  dbo.RPTLog.Timestamp = dbo.VWRPTLastProcessed.LastProcessed INNER JOIN
						  dbo.VWRPTMaxErrorLevel ON dbo.RPTLog.RPTListId = dbo.VWRPTMaxErrorLevel.RPTListId AND dbo.RPTLog.Type = dbo.VWRPTMaxErrorLevel.Type
	GROUP BY   dbo.VWRPTLastProcessed.Type, dbo.VWRPTLastProcessed.LastProcessed, dbo.VWRPTLastProcessed.RPTListId, dbo.RPTLog.[Level], 
                      dbo.VWRPTMaxErrorLevel.MaxErrorLevel
')

------------------------------View: VWRPTListSummary---------------------------
if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'VWRPTListSummary')
begin
    Print 'Creating View VWRPTListSummary'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating View VWRPTListSummary'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' VIEW [dbo].[VWRPTListSummary]
AS
SELECT     l.RPTListId, l.ListName, l.SiteId, l.TableName, l.TableNameSnapshot, l.System, l.ResourceList, ISNULL(t1.MaxLogLevel, - 1) AS Type1Max, 
                      ISNULL(t1.MostRecentLevel, - 1) AS Type1Latest, ISNULL(t2.MaxLogLevel, - 1) AS Type2Max, ISNULL(t2.MostRecentLevel, - 1) AS Type2Latest, 
                      ISNULL(t3.MaxLogLevel, - 1) AS Type3Max, ISNULL(t3.MostRecentLevel, - 1) AS Type3Latest
FROM         dbo.RPTList AS l LEFT OUTER JOIN
                      dbo.VWRPTLogSummary AS t1 ON t1.RPTListId = l.RPTListId AND t1.Type = 1 LEFT OUTER JOIN
                      dbo.VWRPTLogSummary AS t2 ON t2.RPTListId = l.RPTListId AND t2.Type = 2 LEFT OUTER JOIN
                      dbo.VWRPTLogSummary AS t3 ON t3.RPTListId = l.RPTListId AND t3.Type = 3
')
 
 

 



