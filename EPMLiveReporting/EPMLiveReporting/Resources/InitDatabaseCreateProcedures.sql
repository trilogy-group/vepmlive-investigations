IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPTBusinessDays]') AND type in (N'P', N'PC'))
BEGIN
	PRINT '--------------------------------------------------'
    PRINT 'Dropping: spRPTBusinessDays'
	DROP PROCEDURE [dbo].[spRPTBusinessDays]
END

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPTWork2]') AND type in (N'P', N'PC'))
BEGIN
	PRINT '--------------------------------------------------'
	PRINT 'Dropping: spRPTWork2'
	DROP PROCEDURE [dbo].[spRPTWork2]
END

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAddTimerJob]') AND type in (N'P', N'PC'))
BEGIN
	PRINT '--------------------------------------------------'
	PRINT 'Dropping: spAddTimerJob'
	DROP PROCEDURE [dbo].[spAddTimerJob]
END

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateTimerJob]') AND type in (N'P', N'PC'))
BEGIN
	PRINT '--------------------------------------------------'
	PRINT 'Dropping: spUpdateTimerJob'
	DROP PROCEDURE [dbo].[spUpdateTimerJob]
END


declare @createoralter varchar(10)
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'fnCapacity')
begin
    Print 'Creating Function fnCapacity'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function fnCapacity'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[fnCapacity]
(     
      @Day datetime,
      @AssignedTo int
)
RETURNS DECIMAL(10,2)
AS
BEGIN
DECLARE @return as DECIMAL(10,2)
DECLARE @NonWorkingDays as nvarchar(255)

SET @NonWorkingDays = (SELECT dbo.fnGetNonWorkingDays(@AssignedTo))

IF (SELECT CHARINDEX(CONVERT(nvarchar(10),DatePart(WEEKDAY,@Day)), @NonWorkingDays)) > 0
BEGIN
      SET @return = 0
END
ELSE 
BEGIN 
      DECLARE @dow as DECIMAL(10,2)
      SET @dow = (SELECT CASE(DatePart(WEEKDAY,@Day))
      WHEN 1 THEN (SELECT CONVERT(DECIMAL(10,2),SUNDAY) FROM [LSTWorkHours] WHERE ItemId  = (SELECT WorkHoursID FROM [LSTResourcePool] WHERE SharePointAccountID = @AssignedTo))
      WHEN 2 THEN (SELECT CONVERT(DECIMAL(10,2),Monday) FROM [LSTWorkHours] WHERE ItemId = (SELECT WorkHoursID FROM [LSTResourcePool] WHERE SharePointAccountID = @AssignedTo))
      WHEN 3 THEN (SELECT CONVERT(DECIMAL(10,2),Tuesday) FROM [LSTWorkHours] WHERE ItemId = (SELECT WorkHoursID FROM [LSTResourcePool] WHERE SharePointAccountID = @AssignedTo))
      WHEN 4 THEN (SELECT CONVERT(DECIMAL(10,2),Wednesday) FROM [LSTWorkHours] WHERE ItemId = (SELECT WorkHoursID FROM [LSTResourcePool] WHERE SharePointAccountID = @AssignedTo))
      WHEN 5 THEN (SELECT CONVERT(DECIMAL(10,2),Thursday) FROM [LSTWorkHours] WHERE ItemId = (SELECT WorkHoursID FROM [LSTResourcePool] WHERE SharePointAccountID = @AssignedTo))
      WHEN 6 THEN (SELECT CONVERT(DECIMAL(10,2),Friday) FROM [LSTWorkHours] WHERE ItemId = (SELECT WorkHoursID FROM [LSTResourcePool] WHERE SharePointAccountID = @AssignedTo))
      WHEN 7 THEN (SELECT CONVERT(DECIMAL(10,2),Saturday) FROM [LSTWorkHours] WHERE ItemId = (SELECT WorkHoursID FROM [LSTResourcePool] WHERE SharePointAccountID = @AssignedTo))
      END )
      
      SET @return = @dow
      
END


-- Include Holidays --
IF (SELECT COUNT([Date]) FROM LSTHolidays WHERE HolidayScheduleID = (SELECT HolidayScheduleID FROM LSTResourcepool WHERE SharePointAccountID = @AssignedTo) AND [Date] = @Day) > 0
BEGIN
      DECLARE @HolidayHours DECIMAL(10,2)
      SET @HolidayHours = (SELECT [Hours] FROM LSTHolidays WHERE HolidayScheduleID = (SELECT HolidayScheduleID FROM LSTResourcepool WHERE SharePointAccountID = @AssignedTo) AND [Date] = @Day) 
      SET @return = @dow - @HolidayHours
END

-- Include Time Off
DECLARE @Temp TABLE (
ID int,
WorkDetails nvarchar(max),
StartDate datetime )

-- Get all Timeoff records for this specific resource
INSERT INTO @Temp (ID,WorkDetails,StartDate) SELECT ID,WorkDetail,StartDate FROM [LSTTimeOff] WHERE AssignedToID = @AssignedTo AND CONVERT(datetime,@Day,121) BETWEEN StartDate AND DueDate

DECLARE @Id int
DECLARE @DateDiff int
DECLARE @TimeOff nvarchar(max)

WHILE EXISTS(SELECT * From @Temp)
BEGIN
    SELECT Top 1 @Id = ID From @Temp
    
    -- Get difference in days from start date of time off entry to current day in this function
    SET @DateDiff = DateDiff(DD,(SELECT Top 1 CONVERT(datetime,StartDate,101) FROM @Temp),CONVERT(datetime,@Day,101)) + 1
    
    -- Get time off details
    SET @TimeOff = (SELECT Top 1 WorkDetails FROM @Temp)
    
      DECLARE @Pos int
      DECLARE @Loop bit
      DECLARE @SingleDay DECIMAL(10,2)
      DECLARE @Counter int
      
      SET @Counter = 1
      
      SELECT @Loop = CASE WHEN LEN(@TimeOff) > 0 THEN 1 ELSE 0 END
      WHILE (SELECT @Loop) = 1
      BEGIN
            SELECT @Pos = CHARINDEX('','', @TimeOff, 1)
            IF @Pos > 0
            BEGIN
                  SELECT @SingleDay = CONVERT(DECIMAL(10,2),SUBSTRING(@TimeOff, 1, @Pos - 1))
                  SELECT @TimeOff = SUBSTRING(@TimeOff, @Pos + 1, LEN(@TimeOff) - @Pos)
            END
            ELSE
            BEGIN
                  SELECT @SingleDay = CONVERT(DECIMAL(10,2),@TimeOff)
                  SELECT @Loop = 0
            END
            
            IF (@DateDiff = @Counter)
            BEGIN
                SET @return = @return - @SingleDay
            END
            
            SET @Counter = @Counter + 1
            
     END

    DELETE @Temp Where ID = @Id

END

IF (@return < 0)
BEGIN
      SET @return = 0
END

return @return

END  


')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'fnDateSeries')
begin
    Print 'Creating Function fnDateSeries'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function fnDateSeries'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[fnDateSeries] 
               (@StartDate DATETIME, 
                @EndDate   DATETIME) 
RETURNS @Series TABLE([Day] DATETIME) 
AS 
  BEGIN 
    DECLARE  @iDate DATETIME 
    SET @iDate = @StartDate 
     
    WHILE (datediff(DAY,@iDate,@EndDate) >= 0) 
      BEGIN 
        INSERT @Series 
        SELECT @iDate 
         
        SET @iDate = dateadd(DAY,1,@iDate) 
      END 
     
    RETURN 
  END 
  
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'fnGetNonWorkingDays')
begin
    Print 'Creating Function fnGetNonWorkingDays'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function fnGetNonWorkingDays'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[fnGetNonWorkingDays]
(	
	@AssignedTo int
)
RETURNS nvarchar(13) 
AS
BEGIN
	
DECLARE @WorkHours nvarchar(255)
DECLARE @NonWorkingDays nvarchar(13)

DECLARE @TempDays TABLE (DayofWeek varchar(1))

SET @WorkHours = (SELECT WorkHoursID FROM LSTResourcepool WHERE SharePointAccountID = @AssignedTo)
                                                      
IF (SELECT Sunday FROM LSTWorkHours WHERE ItemID = @WorkHours) = 0
BEGIN
INSERT INTO @TempDays (DayofWeek) VALUES (1) 
END
IF (SELECT Monday FROM LSTWorkHours WHERE ItemID = @WorkHours) = 0
BEGIN
INSERT INTO @TempDays (DayofWeek) VALUES (2) 
END
IF (SELECT Tuesday FROM LSTWorkHours WHERE ItemID = @WorkHours) = 0
BEGIN
INSERT INTO @TempDays (DayofWeek) VALUES (3)
END
IF (SELECT Wednesday FROM LSTWorkHours WHERE ItemID = @WorkHours) = 0
BEGIN
INSERT INTO @TempDays (DayofWeek) VALUES (4) 
END
IF (SELECT Thursday FROM LSTWorkHours WHERE ItemID = @WorkHours) = 0
BEGIN
INSERT INTO @TempDays (DayofWeek) VALUES (5) 
END
IF (SELECT Friday FROM LSTWorkHours WHERE ItemID = @WorkHours) = 0
BEGIN
INSERT INTO @TempDays (DayofWeek) VALUES (6) 
END
IF (SELECT Saturday FROM LSTWorkHours WHERE ItemID = @WorkHours) = 0
BEGIN
INSERT INTO @TempDays (DayofWeek) VALUES (7) 
END

SELECT @NonWorkingDays = COALESCE(@NonWorkingDays+ '','' ,'''') + DayofWeek
FROM @TempDays
SET @NonWorkingDays = (SELECT @NonWorkingDays)

	
RETURN @NonWorkingDays	
	
END

')
 
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
	@RowData nvarchar(2000),
	@SplitOn nvarchar(5)
)  
RETURNS @RtnValue table 
(
	Id int identity(1,1),
	Data nvarchar(100)
) 
AS  
BEGIN 
	Declare @Cnt int
	Set @Cnt = 1

	While (Charindex(@SplitOn,@RowData)>0)
	Begin
		Insert Into @RtnValue (data)
		Select 
			Data = ltrim(rtrim(Substring(@RowData,1,Charindex(@SplitOn,@RowData)-1)))

		IF Len(@SplitOn) = 1
		BEGIN
			Set @RowData = Substring(@RowData,Charindex(@SplitOn,@RowData)+1,len(@RowData))
			Set @Cnt = @Cnt + 1
		END
		ELSE
		BEGIN
			Set @RowData = Substring(@RowData,Charindex(@SplitOn,@RowData)+2,len(@RowData))
			Set @Cnt = @Cnt + 2
		END
	End
	
	Insert Into @RtnValue (data)
	Select Data = ltrim(rtrim(@RowData))

	Return
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRPTGetCapacity')
begin
    Print 'Creating Stored Procedure spRPTGetCapacity'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRPTGetCapacity'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRPTGetCapacity] 

@Resources varchar(MAX),
@From datetime,
@To datetime,
@Type nvarchar(50)

AS
BEGIN

declare @value int
declare @pos1 int
declare @pos2 int
declare @sql nvarchar(max)
declare @concatid nvarchar(255)
declare @cap decimal(10,2)
declare @LookupID nvarchar(100)

    CREATE TABLE #Capacity
	( 
    ID nvarchar(max),
    SharePointID int,
    Capacity decimal(10,2),
    [Date] datetime 
	)
	
	DECLARE @Res nvarchar(max)
	DECLARE @Pos INT
	DECLARE @Loop BIT
	Declare @date datetime
	
	SELECT @Loop = CASE WHEN LEN(@Resources) > 0 THEN 1 ELSE 0 END
	WHILE (SELECT @Loop) = 1
	BEGIN
		SELECT @Pos = CHARINDEX('','', @Resources, 1)
		IF @Pos > 0
		BEGIN
			SELECT @Res = SUBSTRING(@Resources, 1, @Pos - 1)
			SELECT @Resources = SUBSTRING(@Resources, @Pos + 1, LEN(@Resources) - @Pos)
		END
		ELSE
		BEGIN
			SELECT @Res = @Resources
			SELECT @Loop = 0
		END
		
		SET @date = @From
		while (@date <= @To)
		begin
		
			IF @Type = ''Days''
			BEGIN
				SET @LookupID = @Res + '';#'' + CONVERT(nvarchar,@date) 
			END 
			ELSE
			IF @Type = ''Weeks''
			BEGIN
				SET @LookupID = @Res + '';#'' + CONVERT(varchar(10),DATEADD(dd, 1 - DATEPART(dw, @date),@date),101) 
			END
			ELSE
			IF @Type = ''Months''
			BEGIN
				SET @LookupID = @Res + '';#'' + CONVERT(nvarchar,MONTH(@date)) + '';#'' + CONVERT(nvarchar,YEAR(@date)) 
			END
			IF @Type = ''Years''
			BEGIN
				SET @LookupID = @Res + '';#'' + CONVERT(nvarchar,YEAR(@date))
			END
			
			SET @cap = dbo.fnCapacity(@date,CONVERT(int,@Res))
			
			INSERT #capacity VALUES(@LookupID,CONVERT(int,@Res),@cap,@date)
			set @date = DATEADD(day,1,@date)
		end
		
	END
	
	SELECT ID,SUM(Capacity) as Capacity
	FROM #Capacity
	GROUP BY ID
	
    drop table #Capacity
   
END



')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRPTGetTotalCapacity')
begin
    Print 'Creating Stored Procedure spRPTGetTotalCapacity'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRPTGetTotalCapacity'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRPTGetTotalCapacity] 


@Resources varchar(MAX),
@From datetime,
@To datetime,
@Type nvarchar(50)

AS
BEGIN

declare @value int
declare @pos1 int
declare @pos2 int
declare @sql nvarchar(max)
declare @concatid nvarchar(255)
declare @cap decimal(10,2)
declare @LookupID nvarchar(100)

    CREATE TABLE #Capacity
	( 
	LookupID nvarchar(100),
    Capacity decimal(10,2),
    [Date] datetime 
	)
	
	DECLARE @Res nvarchar(max)
	DECLARE @Pos INT
	DECLARE @Loop BIT
	Declare @date datetime
	
	SELECT @Loop = CASE WHEN LEN(@Resources) > 0 THEN 1 ELSE 0 END
	WHILE (SELECT @Loop) = 1
	BEGIN
		SELECT @Pos = CHARINDEX('','', @Resources, 1)
		IF @Pos > 0
		BEGIN
			SELECT @Res = SUBSTRING(@Resources, 1, @Pos - 1)
			SELECT @Resources = SUBSTRING(@Resources, @Pos + 1, LEN(@Resources) - @Pos)
		END
		ELSE
		BEGIN
			SELECT @Res = @Resources
			SELECT @Loop = 0
		END
		
		SET @date = @From
		while (@date <= @To)
		begin
		
			IF @Type = ''Days''
			BEGIN
				SET @LookupID = CONVERT(nvarchar,@date,101)
			END 
			ELSE
			IF @Type = ''Weeks''
			BEGIN
				SET @LookupID = CONVERT(nvarchar,DATEADD(dd, 1 - DATEPART(dw, @date),@date),101)
			END
			IF @Type = ''Months''
			BEGIN
				SET @LookupID = CONVERT(nvarchar,MONTH(@date)) + '';#'' + CONVERT(nvarchar,YEAR(@date))
			END
			IF @Type = ''Years''
			BEGIN
				SET @LookupID = CONVERT(nvarchar,YEAR(@date))
			END
			
			SET @cap = dbo.fnCapacity(@date,CONVERT(int,@Res))
			
			INSERT #capacity VALUES(@LookupID,@cap,@date)
			set @date = DATEADD(day,1,@date)
		end
		
	END
	
	SELECT LookupID,SUM(Capacity) as Capacity
	FROM #Capacity
	GROUP BY LookupID
	
    drop table #Capacity
   
END


')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRPTGetWorkingDays')
begin
    Print 'Creating Stored Procedure spRPTGetWorkingDays'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRPTGetWorkingDays'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRPTGetWorkingDays] 


@Start datetime,
@Finish datetime,
@NonWorkingDays nvarchar(max)

AS
BEGIN

DECLARE @WorkingDays as int
DECLARE @day as datetime

SET @day = @Start 
SET @WorkingDays = 0

WHILE @day <= @Finish
BEGIN
	IF (CHARINDEX(CONVERT(nvarchar,DATEPART(DW,@day)),@NonWorkingDays) = 0)
	BEGIN
		SET @WorkingDays = @WorkingDays + 1
	END		
    SET @day = DATEADD(d,1,@day)
END

return @WorkingDays

END

')
 
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
@ListNames nvarchar(max) = null,
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
      
IF (@ListNames IS NULL) -- process ALL lists
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

                        SET @ListNames = ''All reporting lists.''                                 
                        -- Insert record into RPTPeriod table
                        INSERT INTO RPTPeriods VALUES(@PeriodID,@SiteID,@Title,@ReportPeriod,GetDate(),@Enabled, @ListNames,@timerjobguid)                   
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
                        DECLARE @tblListNames table(id int, listname nvarchar(100))

                        --Init. Report period and Report Title
                        SET @ReportPeriod = CONVERT(varchar,Getdate(),101)
                        SET @Title = CONVERT(varchar,Getdate(),100) 

                        -- List name
                        DECLARE @LstName nvarchar(100)                              
                        -- Init. table variable
                        INSERT INTO @tblListNames(id,listname) SELECT * FROM dbo.Split(@ListNames, '','')
                        -- Init. list count
                        SET @ListCount = (SELECT COUNT(*) FROM @tblListNames)
                        -- Init. list counter
                        SET @ListCounter = 1
                        -- Init. new periodID
                        SET @PeriodID = newid()                                     
                        -- Insert record into RPTPeriod table
                        INSERT INTO RPTPeriods VALUES(@PeriodID,@SiteID,@Title,@ReportPeriod,GetDate(),@Enabled, @ListNames,@timerjobguid)
                        -- Loop thru snapshot lists
                        WHILE @ListCounter <= @ListCount
                              BEGIN                         
                                    SET @LstName = (SELECT listname FROM @tblListNames WHERE id = @ListCounter)
                                    SET @TableName = (SELECT tablename FROM @tblLists WHERE listname = @LstName)
                                    SET @RPTListID = (SELECT rptlistid FROM @tblLists WHERE listname = @LstName)
                                    SET @SnapshotTableName = (SELECT tablenamesnapshot FROM @tblLists WHERE listname = @LstName)
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
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRPTLogInsert')
begin
    Print 'Creating Stored Procedure spRPTLogInsert'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRPTLogInsert'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRPTLogInsert] 
@RPTListId uniqueidentifier,
@ListName nvarchar(100),
@ShortMessage nvarchar(500),
@LongMessage ntext,
@Level int,
@Type int,
@Timestamp Datetime,
@timerjobguid uniqueidentifier

AS
BEGIN
      INSERT INTO dbo.RPTLog (RPTListId,ListName,[ShortMessage],[LongMessage],[Level],[Type],[Timestamp],[timerjobguid])
    VALUES(@RPTListId,@ListName,@ShortMessage,@LongMessage,@Level,@Type,@Timestamp,@timerjobguid)
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRPTPeriodSnapshot')
begin
    Print 'Creating Stored Procedure spRPTPeriodSnapshot'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRPTPeriodSnapshot'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRPTPeriodSnapshot] 
@TableName nvarchar(100),
@SnapshotTableName nvarchar(100),
@Title nvarchar(100),
@ReportPeriod Datetime,
@SiteID uniqueidentifier,
@PeriodID uniqueidentifier,
@Enabled bit
AS
BEGIN
	-- Declare dynamic sql string		
	DECLARE @sSQL nvarchar(MAX)

	-- Init. dynamic sql string
	SET @sSQL = ''INSERT INTO ''+@SnapshotTableName+'' SELECT ''''''+CAST(@PeriodID as nvarchar(MAX))+'''''' as periodid, * FROM ''+@TableName 
	
	-- Exec sql script
	EXEC(@sSQL)
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRPTProcessAssignments')
begin
    Print 'Creating Stored Procedure spRPTProcessAssignments'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRPTProcessAssignments'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRPTProcessAssignments] 
@Work as DECIMAL(12,2),
@AssignedTo as nvarchar(MAX),
@Start as datetime,
@Finish as datetime,
@ListID as uniqueidentifier,
@SiteID as uniqueidentifier,
@ItemID as int

AS

BEGIN

SET @Start =  dateadd(day,datediff(day,0,@Start),0);
SET @Finish =  dateadd(day,datediff(day,0,@Finish),0);


/*----------------------- Delete data Begin ------------------------- */

DELETE FROM dbo.RPTWork WHERE ListID = @ListID AND ItemID = @ItemID

/*----------------------- Delete data End ------------------------- */


/*----------------------- Calc Total Working Days Start ------------------------- */

IF @Work IS NULL OR @AssignedTo IS NULL OR @Start IS NULL OR @Finish IS NULL
BEGIN
      RETURN
END
ELSE
BEGIN
      IF @Work = 0 OR @AssignedTo = ''''
      BEGIN
            RETURN
      END
      ELSE
      BEGIN
      
            /*----------------------- Calc Total Working Days End ------------------------- */

            /*----------------------- Insert Data Start ------------------------- */

            DECLARE @DateCounter as datetime
            DECLARE @Day as datetime
            DECLARE @intResources int
            DECLARE @NonWorkingDays VARCHAR(13)
            DECLARE @WorkingDays int
            DECLARE @HolidaySchedule nvarchar(255)
            DECLARE @WorkHours nvarchar(255)
            DECLARE @TempWork as DECIMAL(12,2)
            DECLARE @HolidayHours int
            DECLARE @DayWorkHours int
            DECLARE @TotalHolidayHours DECIMAL(12,2)
            DECLARE @AdditionalWork DECIMAL (12,2)
            DECLARE @HolidayCount int
            SET @intResources = (SELECT COUNT(*) FROM dbo.Split(@AssignedTo,'',''))

            CREATE TABLE #TempDays (DayofWeek varchar(1))
            
            IF @intResources < 2
                  BEGIN
                        
                        /*----------------------- Get @Work and @NonWorkingDays for Resource ------------------------- */
                              
                              SET @WorkHours = (SELECT WorkHoursID FROM LSTResourcepool WHERE SharePointAccountID = @AssignedTo)
                            
                              
                              IF (SELECT Sunday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (1) 
                              END
                              IF (SELECT Monday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (2) 
                              END
                              IF (SELECT Tuesday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (3)
                              END
                              IF (SELECT Wednesday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (4) 
                              END
                              IF (SELECT Thursday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (5) 
                              END
                              IF (SELECT Friday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (6) 
                              END
                              IF (SELECT Saturday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (7) 
                              END
                             
                              SELECT @NonWorkingDays = COALESCE(@NonWorkingDays+'','' ,'''') + DayofWeek
							  FROM #TempDays
							  SET @NonWorkingDays = (SELECT @NonWorkingDays)
							  DELETE #TempDays
							                                
                            
                              EXEC @WorkingDays = spRPTGetWorkingDays @Start, @Finish, @NonWorkingDays
							
							-- Set intial work
							IF @WorkingDays <> 0
							BEGIN
								  SET @Work = @Work/@WorkingDays
							END
							ELSE
							BEGIN
								  SET @Work = 0
							END
                        
                         /*----------------------- End Get @Work and @NonWorkingDays for Resource ------------------------- */
                        
                        -- Setting the total number of holidays within this date range
						SET @HolidayCount = (SELECT COUNT(dbo.LSTHolidays.Hours) FROM dbo.LSTHolidaySchedules INNER JOIN
						dbo.LSTHolidays ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTHolidays.HolidayScheduleID INNER JOIN
						dbo.LSTResourcepool ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTResourcepool.HolidayScheduleID
						WHERE (dbo.LSTResourcepool.SharePointAccountID = @AssignedTo) AND dbo.LSTHolidays.Date BETWEEN @Start AND @Finish)
                        
                        Set @Day = @Start

                        WHILE @Day <= @Finish
                        BEGIN
							  
							  -- if this day is a non working day set work to zero
                              IF (SELECT CHARINDEX(CONVERT(nvarchar(10),DatePart(WEEKDAY,@Day)), @NonWorkingDays)) > 0 
                              BEGIN
                                    INSERT INTO dbo.RPTWork(SiteID,ListID,ItemID,Work,AssignedTo,[Date])
                                    VALUES (@SiteID,@ListID,@ItemID,0.00,@AssignedTo,@Day)      
                              END
                              ELSE
                              BEGIN
									-- if holiday exsists within the date range, we need to adjust work accordingly, otherwise, insert work as usual.
									IF  @HolidayCount > 0
									BEGIN
										SET @HolidayHours = (SELECT dbo.LSTHolidays.Hours FROM dbo.LSTHolidaySchedules INNER JOIN
										dbo.LSTHolidays ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTHolidays.HolidayScheduleID INNER JOIN
										dbo.LSTResourcepool ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTResourcepool.HolidayScheduleID
										WHERE (dbo.LSTResourcepool.SharePointAccountID = @AssignedTo) AND CONVERT(datetime,dbo.LSTHolidays.Date,101) = CONVERT(datetime,@Day,101))
										
										-- if this day is the actual holiday, we need to do a special calc	
										IF @HolidayHours IS NOT NULL
										BEGIN
										    SELECT @DayWorkHours = 
										    CASE DATEPART(DW,@Day) 
										    WHEN 1 THEN Saturday
										    WHEN 2 THEN Monday
										    WHEN 3 THEN Tuesday
										    WHEN 4 Then Wednesday
										    WHEN 5 Then Thursday
										    WHEN 6 Then Friday
										    When 7 Then Saturday
											END			
											FROM dbo.LSTResourcepool INNER JOIN
											dbo.LSTWorkHours ON dbo.LSTResourcepool.WorkHoursID = dbo.LSTWorkHours.ItemId
											WHERE (dbo.LSTResourcepool.SharePointAccountID = @AssignedTo)
										
											SET @TempWork = @DayWorkHours - @HolidayHours
											
											IF @TempWork IS NULL
											BEGIN
												SET @TempWork = 0
											END
											
											INSERT INTO dbo.RPTWork(SiteID,ListID,ItemID,Work,AssignedTo,[Date])
											VALUES (@SiteID,@ListID,@ItemID,@TempWork,@AssignedTo,@Day)
										END
										ELSE
										BEGIN 
											--SET @TotalHolidayHours = (SELECT SUM(dbo.LSTHolidays.Hours) FROM dbo.LSTHolidaySchedules INNER JOIN
											--dbo.LSTHolidays ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTHolidays.HolidayScheduleID INNER JOIN
											--dbo.LSTResourcepool ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTResourcepool.HolidayScheduleID
											--WHERE (dbo.LSTResourcepool.SharePointAccountID = @TempAssignedTo) AND CONVERT(datetime,dbo.LSTHolidays.Date,101) BETWEEN CONVERT(datetime,@Start,101) AND CONVERT(datetime,@Finish,101))
												
											--SET @AdditionalWork = @TotalHolidayHours / (@WorkingDays - @HolidayCount)
											SET @AdditionalWork = (@Work * @HolidayCount) / (@WorkingDays - @HolidayCount)
											SET @TempWork = @Work + @AdditionalWork
													
											-- insert work plus the additional hours spread accross the days to account for the vacation
											INSERT INTO dbo.RPTWork(SiteID,ListID,ItemID,Work,AssignedTo,[Date])
											VALUES (@SiteID,@ListID,@ItemID,@TempWork,@AssignedTo,@Day)
										END
									END
									ELSE
									BEGIN
										-- insert work as usual...no vacation involived in this date range
										INSERT INTO dbo.RPTWork(SiteID,ListID,ItemID,Work,AssignedTo,[Date])
										VALUES (@SiteID,@ListID,@ItemID,CONVERT(DECIMAL(12,2),@Work),@AssignedTo,@Day) 
									END
                              END   
                              SET @Day = DATEADD(Day,1,@Day)
                        END
                  END
            ELSE
                  BEGIN
                        
                        DECLARE @Counter int
                        DECLARE @TempAssignedTo nvarchar(MAX)
                        DECLARE @SplitWork as DECIMAL(12,2) 
                        SET @SplitWork = (@Work/@intResources)
                        SET @Counter = 1
                        
                        WHILE @Counter < @intResources + 1
                        BEGIN 
                               
                              SET @HolidayHours = 0
							  SET @DayWorkHours = 0
							  SET @TotalHolidayHours = 0
							  SET @AdditionalWork = 0
							  SET @HolidayCount = 0
                              
                              SET @TempAssignedTo = (SELECT data FROM dbo.Split(@AssignedTo,'','') WHERE Id = @Counter)
                              
                              SET @WorkHours = (SELECT WorkHoursID FROM LSTResourcepool WHERE SharePointAccountID = @TempAssignedTo)
                              
                              IF (SELECT Sunday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (1) 
                              END
                              IF (SELECT Monday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (2) 
                              END
                              IF (SELECT Tuesday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (3)
                              END
                              IF (SELECT Wednesday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (4) 
                              END
                              IF (SELECT Thursday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (5) 
                              END
                              IF (SELECT Friday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (6) 
                              END
                              IF (SELECT Saturday FROM LSTWorkHours WHERE ItemId = @WorkHours) = 0
                              BEGIN
								INSERT INTO #TempDays (DayofWeek) VALUES (7) 
                              END
                              
                              SELECT @NonWorkingDays = COALESCE(@NonWorkingDays+'','' ,'''') + DayofWeek
							  FROM #TempDays
							  SET @NonWorkingDays = (SELECT @NonWorkingDays)
							  DELETE #TempDays                        
                            
                              EXEC @WorkingDays = spRPTGetWorkingDays @Start, @Finish, @NonWorkingDays
                              
							
							-- Set intial work
							IF @WorkingDays <> 0
							BEGIN
								  SET @Work = @SplitWork/@WorkingDays
							END
							ELSE
							BEGIN
								  SET @Work = 0
							END
							
							 /*----------------------- End Get @Work and @NonWorkingDays for Resource ------------------------- */
                        
							-- Setting the total number of holidays within this date range
							SET @HolidayCount = (SELECT COUNT(dbo.LSTHolidays.Hours) FROM dbo.LSTHolidaySchedules INNER JOIN
							dbo.LSTHolidays ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTHolidays.HolidayScheduleID INNER JOIN
							dbo.LSTResourcepool ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTResourcepool.HolidayScheduleID
							WHERE (dbo.LSTResourcepool.SharePointAccountID = @TempAssignedTo) AND dbo.LSTHolidays.Date BETWEEN @Start AND @Finish)

                              
                              /*  Add */
                              Set @Day = @Start

                              WHILE @Day <= @Finish
                              BEGIN
								  -- if this day is a non working day set work to zero
								  IF (SELECT CHARINDEX(CONVERT(nvarchar(10),DatePart(WEEKDAY,@Day)), @NonWorkingDays)) > 0 
								  BEGIN
										INSERT INTO dbo.RPTWork(SiteID,ListID,ItemID,Work,AssignedTo,[Date])
										VALUES (@SiteID,@ListID,@ItemID,0.00,@TempAssignedTo,@Day)      
								  END
								  ELSE
								  BEGIN
										-- if holiday exsists within the date range, we need to adjust work accordingly, otherwise, insert work as usual.
										IF  @HolidayCount > 0
										BEGIN
											SET @HolidayHours = (SELECT dbo.LSTHolidays.Hours FROM dbo.LSTHolidaySchedules INNER JOIN
											dbo.LSTHolidays ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTHolidays.HolidayScheduleID INNER JOIN
											dbo.LSTResourcepool ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTResourcepool.HolidayScheduleID
											WHERE (dbo.LSTResourcepool.SharePointAccountID = @TempAssignedTo) AND CONVERT(datetime,dbo.LSTHolidays.Date,101) = CONVERT(datetime,@Day,101))
											
											-- if this day is the actual holiday, we need to do a special calc	
											IF @HolidayHours IS NOT NULL
											BEGIN
												SELECT @DayWorkHours = 
												CASE DATEPART(DW,@Day) 
												WHEN 1 THEN Saturday
												WHEN 2 THEN Monday
												WHEN 3 THEN Tuesday
												WHEN 4 Then Wednesday
												WHEN 5 Then Thursday
												WHEN 6 Then Friday
												When 7 Then Saturday
												END			
												FROM dbo.LSTResourcepool INNER JOIN
												dbo.LSTWorkHours ON dbo.LSTResourcepool.WorkHoursID = dbo.LSTWorkHours.ItemId
												WHERE (dbo.LSTResourcepool.SharePointAccountID = @TempAssignedTo)
											
												SET @TempWork = @DayWorkHours - @HolidayHours
												
												IF @TempWork IS NULL
												BEGIN
													SET @TempWork = 0
												END
												
												INSERT INTO dbo.RPTWork(SiteID,ListID,ItemID,Work,AssignedTo,[Date])
												VALUES (@SiteID,@ListID,@ItemID,@TempWork,@TempAssignedTo,@Day)
											END
											ELSE
											BEGIN 
												--SET @TotalHolidayHours = (SELECT SUM(dbo.LSTHolidays.Hours) FROM dbo.LSTHolidaySchedules INNER JOIN
												--dbo.LSTHolidays ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTHolidays.HolidayScheduleID INNER JOIN
												--dbo.LSTResourcepool ON dbo.LSTHolidaySchedules.ItemId = dbo.LSTResourcepool.HolidayScheduleID
												--WHERE (dbo.LSTResourcepool.SharePointAccountID = @TempAssignedTo) AND CONVERT(datetime,dbo.LSTHolidays.Date,101) BETWEEN CONVERT(datetime,@Start,101) AND CONVERT(datetime,@Finish,101))
												
												--SET @AdditionalWork = @TotalHolidayHours / (@WorkingDays - @HolidayCount)
												SET @AdditionalWork = (@Work * @HolidayCount) / (@WorkingDays - @HolidayCount)
												SET @TempWork = @Work + @AdditionalWork
												
												-- insert work plus the additional hours spread accross the days to account for the vacation
												INSERT INTO dbo.RPTWork(SiteID,ListID,ItemID,Work,AssignedTo,[Date])
												VALUES (@SiteID,@ListID,@ItemID,@TempWork,@TempAssignedTo,@Day)
											END
										END
										ELSE
										BEGIN
											-- insert work as usual...no vacation involived in this date range
											INSERT INTO dbo.RPTWork(SiteID,ListID,ItemID,Work,AssignedTo,[Date])
											VALUES (@SiteID,@ListID,@ItemID,CONVERT(DECIMAL(12,2),@Work),@TempAssignedTo,@Day) 
										END
								  END   
								  SET @Day = DATEADD(Day,1,@Day)
                              END
                              SET @Counter = @Counter + 1
                        END
                  END
            END
            
            IF OBJECT_ID(''tempdb..#TempDays'') is not null
            BEGIN
				DROP TABLE #TempDays
			END
            
      END
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRPTWork')
begin
    Print 'Creating Stored Procedure spRPTWork'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRPTWork'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRPTWork]
@URL varchar(MAX),
@SiteID varchar(36),
@Resources varchar(MAX),
@From datetime,
@To datetime,
@Lists varchar(MAX),
@Type nvarchar(50)

AS
BEGIN

DECLARE @sql as nvarchar(max)

CREATE TABLE #Work
( 
    ProjectText nvarchar(max),
    Title nvarchar(max),
    WebUrl nvarchar(max),
    Work float,
    WorkDate varchar(10),
    AssignedTo nvarchar(max),
    AssignedToID int,
    ListType nvarchar(max),
    LookupID nvarchar(100),
    TotalLookupID nvarchar(100),
    MonthNum int,
    WeekNum int,
    [Year] int,
    [MonthName] nvarchar(50),
    WeekDate datetime,
    [Day] datetime,
    [Date] datetime               
)

SET @sql = ''''

SET @sql = @sql + ''INSERT INTO #Work (ProjectText,Title,WebUrl,Work,WorkDate,AssignedTo,AssignedToID,ListType) 
SELECT ISNULL(dbo.LSTMyWork.ProjectText,''''No Project'''') as Project,dbo.LSTMyWork.Title,dbo.LSTMyWork.WebUrl,dbo.RPTWork.[Work], CONVERT(varchar(10),dbo.RPTWork.Date,101) as WorkDate, dbo.LSTResourcepool.Title AS AssignedTo,dbo.LSTResourcepool.SharePointAccountID AS AssignedToID,LSTMyWork.WorkType AS ListType
FROM         
dbo.RPTWork 
INNER JOIN
LSTMyWork ON dbo.RPTWork.ListID = LSTMyWork.ListId 
AND dbo.RPTWork.ItemID = dbo.LSTMyWork.ItemId 
AND dbo.RPTWork.SiteID = dbo.LSTMyWork.SiteId
AND dbo.RPTWork.SiteID = dbo.LSTMyWork.SiteId AND dbo.RPTWork.AssignedTo = dbo.LSTMyWork.AssignedToID
INNER JOIN
dbo.LSTResourcepool ON dbo.RPTWork.AssignedTo = dbo.LSTResourcepool.SharePointAccountID 
WHERE dbo.LSTMyWork.WEBURL LIKE '''''' + @URL + '''''' + ''''/%'''' 
OR '''''' + @URL + '''''' = ''''/'''' 
OR '''''' + @URL + '''''' = dbo.LSTMyWork.WEBURL 
AND dbo.RPTWork.AssignedTo IN ('' + @Resources + '') 
AND dbo.LSTMyWork.WorkType IN (SELECT data FROM dbo.Split('''''' + @Lists + '''''','''',''''))
AND dbo.RPTWork.Date BETWEEN '''''' + CONVERT(varchar(50),@From) + '''''' AND '''''' + CONVERT(varchar(50),@To) + ''''''''

exec (@sql)

DECLARE @Res nvarchar(max)
DECLARE @LookupID nvarchar(100)
DECLARE @TotalLookupID nvarchar(100)
DECLARE @Pos INT
DECLARE @Loop BIT
DECLARE @date datetime

SELECT @Loop = CASE WHEN LEN(@Resources) > 0 THEN 1 ELSE 0 END
WHILE (SELECT @Loop) = 1
BEGIN
	SELECT @Pos = CHARINDEX('','', @Resources, 1)
	IF @Pos > 0
	BEGIN
		SELECT @Res = SUBSTRING(@Resources, 1, @Pos - 1)
		SELECT @Resources = SUBSTRING(@Resources, @Pos + 1, LEN(@Resources) - @Pos)
	END
	ELSE
	BEGIN
		SELECT @Res = @Resources
		SELECT @Loop = 0
	END
	
	SET @date = @From
	WHILE (@date <= @To)
	BEGIN
		SET @LookupID = (SELECT CASE(@Type)
		WHEN ''Days'' THEN @Res + '';#'' + CONVERT(nvarchar,@date)
		WHEN ''Weeks'' THEN @Res + '';#'' + CONVERT(varchar(10),DATEADD(dd, 1 - DATEPART(dw, @date),@date),101)
		WHEN ''Months'' THEN @Res + '';#'' + CONVERT(nvarchar,MONTH(@date)) + '';#'' + CONVERT(nvarchar,YEAR(@date))
		WHEN ''Years'' THEN @Res + '';#'' + CONVERT(nvarchar,YEAR(@date))
		END)
		
		SET @TotalLookupID = (SELECT CASE(@Type)
		WHEN ''Days'' THEN CONVERT(nvarchar,@date,101)
		WHEN ''Weeks'' THEN CONVERT(varchar(10),DATEADD(dd, 1 - DATEPART(dw, @date),@date),101)
		WHEN ''Months'' THEN CONVERT(nvarchar,MONTH(@date)) + '';#'' + CONVERT(nvarchar,YEAR(@date))
		WHEN ''Years'' THEN CONVERT(nvarchar,YEAR(@date))
		END) 
		
		IF NOT EXISTS (SELECT WorkDate FROM #Work WHERE WorkDate = CONVERT(varchar(10),@date,101) AND AssignedToID = @Res)
		BEGIN
			INSERT #Work VALUES(''Other Work'',NULL,NULL,0.00,CONVERT(varchar(10),@date,101),(SELECT Title FROM LSTResourcepool WHERE SharePointAccountID = @Res),CONVERT(int,@Res),NULL,@LookupID,@TotalLookupID,MONTH(@date),{fn WEEK(@date)},YEAR(@date),DATENAME(Month,@date),CONVERT(varchar(10),DATEADD(dd, 1 - DATEPART(dw, @date),@date),101),CONVERT(datetime,@date,101),CONVERT(varchar(10),@date,101))  
		END
		ELSE
		BEGIN
			UPDATE #Work SET LookupID = @LookupID,TotalLookupID = @TotalLookupID,MonthNum = MONTH(@date),WeekNum = {fn WEEK(@date)},[Year] = YEAR(@date), [MonthName] = DATENAME(Month,@date), WeekDate = CONVERT(varchar(10),DATEADD(dd, 1 - DATEPART(dw, @date),@date),101),[Day] = CONVERT(datetime,@date,101),[Date] = CONVERT(varchar(10),@date,101)
			WHERE WorkDate = CONVERT(varchar(10),@date,101) AND AssignedToID = @Res
		END		
	SET @date = DATEADD(day,1,@date)
	END
	
	
END

SELECT * FROM #Work ORDER BY WorkDate

DROP Table #Work

END


')
 

if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spGetReportListData')
begin
    Print 'Creating Stored Procedure spGetReportListData'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spGetReportListData'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spGetReportListData]

@siteid uniqueidentifier,
@webid uniqueidentifier,
@weburl varchar(255),
@userid	int,
@rollup bit,
@list varchar(255),
@query varchar(5000),
@orderby varchar(5000) = ''''

AS
BEGIN

	declare @sql varchar(MAX)

	set @list = REPLACE(@list, '' '', '''')
	if @list = ''lstResources'' 
	begin
		set @list = ''lstResourcePool''
	end

	if @rollup = 1
		begin

			declare @tquery varchar(5000)

                  if @weburl = ''/''
                  begin 
                        set @tquery = '' WHERE (RPTITEMGROUPS.siteid='''''' + CAST(@siteid as varchar(255)) + '''''')''
                  end
                  else
                  begin
                        set @tquery = '' WHERE (weburl='''''' + @weburl + '''''' or weburl like '''''' + @weburl + ''/%'''')''
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
					set @query = '' WHERE webid='''''' + convert(varchar(50), @webid) + '''''' AND '' + @query
				end
			else
				begin
					set @query = '' WHERE webid='''''' + convert(varchar(50), @webid) + ''''''''
				end

			
		end

		set @sql = ''select * from lst'' + @list + '' inner join  (SELECT    DISTINCT lst'' + @list + ''.itemid, lst'' + @list + ''.listid FROM         lst'' + @list + '' INNER JOIN
                      dbo.RPTITEMGROUPS ON lst'' + @list + ''.ListId = dbo.RPTITEMGROUPS.LISTID AND lst'' + @list + ''.ItemId = dbo.RPTITEMGROUPS.ITEMID AND 
                      lst'' + @list + ''.SiteId = dbo.RPTITEMGROUPS.SITEID INNER JOIN
                      dbo.RPTGROUPUSER ON dbo.RPTITEMGROUPS.SITEID = dbo.RPTGROUPUSER.SITEID AND 
                      dbo.RPTITEMGROUPS.GROUPID = dbo.RPTGROUPUSER.GROUPID INNER JOIN
                      dbo.RPTITEMGROUPS AS RPTITEMGROUPS_1 ON lst'' + @list + ''.ItemId = RPTITEMGROUPS_1.ITEMID AND 
                      lst'' + @list + ''.ListId = RPTITEMGROUPS_1.LISTID''

		set @sql = @sql + @query + '' AND ('''''' + convert(varchar(10), @userid) + '''''' = ''''1073741823'''' OR (userid='' + convert(varchar(10), @userid) + '' AND RPTITEMGROUPS.SECTYPE = 1) OR (RPTITEMGROUPS_1.GROUPID='' + convert(varchar(10), @userid) + '' AND RPTITEMGROUPS_1.SECTYPE = 0))) AS DISTINCTITEMS ON lst'' + @list + ''.listid = DISTINCTITEMS.listid AND lst'' + @list + ''.itemid = DISTINCTITEMS.itemid''
			
		if @orderby <> '''' begin
		
			set @sql = @sql + '' order by '' + @orderby
		
		end
			
	exec(@sql)

	print @sql

END
')
 

if not exists (select * from sys.indexes where name = 'ix_listid_itemid')
begin

	CREATE NONCLUSTERED INDEX [ix_listid_itemid]
	ON [dbo].[RPTITEMGROUPS] ([LISTID],[ITEMID])
	INCLUDE ([GROUPID],[SECTYPE])

end