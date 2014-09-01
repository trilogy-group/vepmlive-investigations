declare @createoralter varchar(10)
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_charindex_ex')
begin
    Print 'Creating Function EPG_FN_charindex_ex'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_charindex_ex'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' function dbo.EPG_FN_charindex_ex (@searchar nvarchar(1),@str ntext,@startloc int)
returns int
as
begin
   declare @curpos int, @strlen int, @charval nchar(1)
   set @strlen = datalength(@str)
   set @curpos = @startloc 
   while @curpos <= @strlen
   begin
     if substring(@str,@curpos,1) = @searchar
         break
         set @curpos = @curpos + 1
   end
return @curpos
end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_ConvertGuidListToTable')
begin
    Print 'Creating Function EPG_FN_ConvertGuidListToTable'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_ConvertGuidListToTable'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION dbo.EPG_FN_ConvertGuidListToTable(@ntext ntext)
RETURNS @TokenVals table (TokenVal uniqueidentifier)
AS
BEGIN
  declare @maxStrLen int
  declare @s nvarchar(4000)
  declare @textLen int
  declare @textPos int
  declare @nextTextDelim int
  declare @strLen int
  declare @strPos int
  declare @nextStrDelim int
  declare @val uniqueidentifier

  set @maxStrLen = 4000

  set @textLen = datalength(@ntext) / 2 
  set @textPos = 1

  if (@textLen <= 1) return

  
  While (@textPos <= @textLen)
  Begin
     if ((@textLen - @textPos + 1) > @maxStrLen)
       begin
        set @s = substring(@ntext, @textPos, @maxStrLen)
        
        set @nextTextDelim = charindex('','', @s, @maxStrLen - 10)

        
        if (@nextTextDelim > 0)
           set @s = substring(@s, 1, @nextTextDelim - 1)
        else
           set @nextTextDelim = @maxStrLen + 1	

        set @textPos = @textPos + @nextTextDelim
       end
     Else
       begin
        
        set @s = substring(@ntext, @textPos, @textLen - @textPos + 1)
        set @textPos = @textLen + 1
       end

     
     set @strLen = len(@s)
     set @strPos = 0

     
     While @strPos <= @strLen
     Begin
        
        set @nextStrDelim = charindex('','', @s, @strPos)
        if @nextStrDelim = 0
           set @nextStrDelim = @strLen + 1

        
	
        set @val = substring(@s, @strPos, @nextStrDelim - @strPos)

        
        insert @TokenVals values (@val)

        
        set @strPos = @nextStrDelim + 1
     End 
  End 
RETURN
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_ConvertListToTable')
begin
    Print 'Creating Function EPG_FN_ConvertListToTable'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_ConvertListToTable'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' function dbo.EPG_FN_ConvertListToTable(@str ntext)
returns @TokenVals table (TokenVal int)
as
begin
   declare @strlen int, @curpos int, @val int, @nextcomma int
   set @strlen = datalength(@str)
   set @curpos = 0
-- For each token, load it into the table
       while @curpos <= @strlen
          begin
             set @nextcomma = dbo.EPG_FN_charindex_ex('','', @str, @curpos)
             if @nextcomma = 0
                 set @nextcomma = @strlen + 1
                 set @val = cast(substring(@str,@curpos,@nextcomma - @curpos)   as int)
                 insert @TokenVals values (@val)
                 set @curpos = @nextcomma + 1
          end
return
end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_ConvertWEPIDToTable')
begin
    Print 'Creating Function EPG_FN_ConvertWEPIDToTable'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_ConvertWEPIDToTable'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' function dbo.EPG_FN_ConvertWEPIDToTable(@str ntext)
returns @TokenVals table (TokenVal nvarchar(80))
as
begin
   declare @strlen int, @curpos int, @val nvarchar(80), @nextcomma int
   set @strlen = datalength(@str)
   set @curpos = 0
-- For each token, load it into the table
       while @curpos <= @strlen
          begin
             set @nextcomma = dbo.EPG_FN_charindex_ex('','', @str, @curpos)
             if @nextcomma = 0
                 set @nextcomma = @strlen + 1
                 set @val = rtrim(ltrim(substring(@str,@curpos,@nextcomma - @curpos)))
                 insert @TokenVals values (@val)
                 set @curpos = @nextcomma + 1
          end
return
end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_GetDeptCode')
begin
    Print 'Creating Function EPG_FN_GetDeptCode'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_GetDeptCode'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION dbo.EPG_FN_GetDeptCode()
RETURNS INT
AS
BEGIN
 DECLARE @DeptUID INT
 SELECT @DeptUID = ADM_DEPT_CODE FROM EPG_ADMIN
RETURN @DeptUID
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_GetRoleCode')
begin
    Print 'Creating Function EPG_FN_GetRoleCode'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_GetRoleCode'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION dbo.EPG_FN_GetRoleCode()
RETURNS INT
AS
BEGIN
 DECLARE @RoleUID INT
 SELECT @RoleUID = ADM_ROLE_CODE FROM EPG_ADMIN
RETURN @RoleUID
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_RPT_GetCostCategoryFullName')
begin
    Print 'Creating Function EPG_FN_RPT_GetCostCategoryFullName'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_RPT_GetCostCategoryFullName'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[EPG_FN_RPT_GetCostCategoryFullName](@InBC_ID int, @InName varchar(255))
RETURNS varchar(1000)
AS
BEGIN
	declare @Level_BC_ID int
	declare @Level_BC_ID_Temp int
	declare @FullName varchar(max)
	declare @FullNameTemp varchar(max)

	declare @LevelID int
	declare @LevelIDTemp int

	set @FullName = @InName

	set @LevelIDTemp = 0
	set @LevelID = (select BC_LEVEL from dbo.EPGP_COST_CATEGORIES where BC_ID = @InBC_ID)
	
	if (@LevelID>1)
		set @LevelIDTemp = @LevelID - 1
	else
		set @LevelIDTemp = 1
				
	while (@LevelID - @LevelIDTemp > 0)
	begin	
		set @Level_BC_ID = (select max(bc_id) from dbo.EPGP_COST_CATEGORIES where bc_level = @LevelIDTemp and bc_ID<=@InBC_ID)	
		set @FullNameTemp = (select bc_name from dbo.EPGP_COST_CATEGORIES where BC_ID = @Level_BC_ID)	
		-- build full name
		set @FullName = @FullNameTemp + ''.'' + @FullName
		
		-- move one level up	
		set @LevelID = @LevelIDTemp
		if (@LevelIDTemp>1)
			set @LevelIDTemp = @LevelIDTemp - 1
	 
	 end
	 
	 return @FullName
 
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_RPT_GetCostTypeCustomField')
begin
    Print 'Creating Function EPG_FN_RPT_GetCostTypeCustomField'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_RPT_GetCostTypeCustomField'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[EPG_FN_RPT_GetCostTypeCustomField](@FieldID int)
RETURNS varchar(50)
AS
BEGIN
 DECLARE @CustFieldName varchar(255)
 
 set @CustFieldName = 
 (Select
	CASE @FieldID 
		WHEN 11801 THEN ''OC_01''
		WHEN 11802 THEN ''OC_02'' 
		WHEN 11803 THEN ''OC_03''
		WHEN 11804 THEN ''OC_04''
		WHEN 11805 THEN ''OC_05'' 
		WHEN 11811 THEN ''TEXT_01'' 
		WHEN 11812 THEN ''TEXT_02'' 
		WHEN 11813 THEN ''TEXT_03'' 
		WHEN 11814 THEN ''TEXT_04'' 
		WHEN 11815 THEN ''TEXT_05'' 
		ELSE
			''UNKNOWN'' 
	END) 

	RETURN @CustFieldName

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_RPT_GetFieldName')
begin
    Print 'Creating Function EPG_FN_RPT_GetFieldName'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_RPT_GetFieldName'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[EPG_FN_RPT_GetFieldName](@TableID int, @FieldID int)
RETURNS varchar(50)
AS
BEGIN
 DECLARE @FieldName varchar(100)
 DECLaRE @FieldNumber varchar(3)
  
 if @FieldID < 10
	set @FieldNumber = ''00'' + Convert(varchar(1), @FieldID)
 else
	set @FieldNumber = ''0'' + CONVERT(varchar(2), @FieldID)
	
 -- Get field name
 --set @FieldName = (select FIELD_PREFIX from EPMLive_CUSTOM_TABLE_LIST where table_ID = @TableID)
 
 set @FieldName = 
(Select
	CASE @TableID 
		WHEN 101 THEN ''RI_''
		WHEN 102 THEN ''RT_'' 
		WHEN 103 THEN ''RC_''
		WHEN 105 THEN ''RD_''
		WHEN 151 THEN ''MVR_UID''
		WHEN 201 THEN ''PI_'' 
		WHEN 202 THEN ''PT_'' 
		WHEN 203 THEN ''PC_'' 
		WHEN 205 THEN ''PD_'' 		
		ELSE
			''UNKNOWN'' 
	END)
  
RETURN rtrim(@FieldName) + ltrim(@FieldNumber)

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_RPT_GetMultiValue')
begin
    Print 'Creating Function EPG_FN_RPT_GetMultiValue'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_RPT_GetMultiValue'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[EPG_FN_RPT_GetMultiValue]
( 
    @WRES_ID int,
    @FIELD_ID varchar(10) 
) 
RETURNS VARCHAR(8000) 
AS 
BEGIN 
    DECLARE @r VARCHAR(8000) 
      
	SELECT @r = ISNULL(@r+'', '', '''') + dbo.EPGP_LOOKUP_VALUES.LV_FULLVALUE
	FROM   dbo.EPGC_RESOURCE_MV_VALUES INNER JOIN
		   dbo.EPGP_LOOKUP_VALUES ON dbo.EPGC_RESOURCE_MV_VALUES.MVR_UID = dbo.EPGP_LOOKUP_VALUES.LV_UID
	WHERE  (dbo.EPGC_RESOURCE_MV_VALUES.WRES_ID = @WRES_ID) AND (dbo.EPGC_RESOURCE_MV_VALUES.MVR_FIELD_ID = @FIELD_ID)      
                 
    RETURN @r 
END 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_RPT_GetParentUniqueName')
begin
    Print 'Creating Function EPG_FN_RPT_GetParentUniqueName'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_RPT_GetParentUniqueName'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[EPG_FN_RPT_GetParentUniqueName](@InBC_ID int)
RETURNS varchar(1000)
AS
BEGIN
	declare @Parent_BC_ID int	
	declare @ParentUniqueName varchar(max)
	declare @LevelID int
	declare @LevelIDTemp int

	set @LevelIDTemp = 0
	set @LevelID = (select BC_LEVEL from dbo.EPGP_COST_CATEGORIES where BC_ID = @InBC_ID)
	
	if (@LevelID>1)
	begin
		set @LevelIDTemp = @LevelID - 1
		set @Parent_BC_ID = (select max(bc_id) from dbo.EPGP_COST_CATEGORIES where bc_level = @LevelIDTemp and bc_ID<=@InBC_ID)	
		set @ParentUniqueName = (select bc_name from dbo.EPGP_COST_CATEGORIES where BC_ID = @Parent_BC_ID)			
	end
	else
		set @ParentUniqueName = ''''

	 
	return @ParentUniqueName
 
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_FN_RPT_GetTableName')
begin
    Print 'Creating Function EPG_FN_RPT_GetTableName'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function EPG_FN_RPT_GetTableName'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[EPG_FN_RPT_GetTableName](@TableID int)
RETURNS varchar(50)
AS
BEGIN
 DECLARE @TableName varchar(100)
 --set @TableName = (select TABLE_NAME from EPMLive_CUSTOM_TABLE_LIST where table_ID = @TableID)
 set @TableName = 
(Select
	CASE @TableID 
		WHEN 101 THEN ''EPGC_RESOURCE_INT_VALUES''
		WHEN 102 THEN ''EPGC_RESOURCE_TEXT_VALUES'' 
		WHEN 103 THEN ''EPGC_RESOURCE_DEC_VALUES''
		WHEN 105 THEN ''EPGC_RESOURCE_DATE_VALUES''
		WHEN 151 THEN ''EPGC_RESOURCE_MV_VALUES''
		WHEN 201 THEN ''EPGP_PROJECT_INT_VALUES'' 
		WHEN 202 THEN ''EPGP_PROJECT_TEXT_VALUES'' 
		WHEN 203 THEN ''EPGP_PROJECT_DEC_VALUES'' 
		WHEN 205 THEN ''EPGP_PROJECT_DATE_VALUES'' 	
		ELSE
			''UNKNOWN'' 
	END) 	
 
RETURN @TableName

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PFE_FN_CheckUserSecurityClearance')
begin
    Print 'Creating Function PFE_FN_CheckUserSecurityClearance'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function PFE_FN_CheckUserSecurityClearance'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[PFE_FN_CheckUserSecurityClearance] 
(
      -- Add the parameters for the function here
      @Username NVARCHAR(255),
      @SecurityLevel INT
)
RETURNS BIT
AS
BEGIN
      DECLARE @HasAccess BIT
      SET @HasAccess = 0
 
      IF EXISTS (SELECT dbo.EPG_RESOURCES.WRES_ID FROM dbo.EPG_RESOURCES WHERE dbo.EPG_RESOURCES.WRES_ID = 1 AND dbo.EPG_RESOURCES.WRES_NT_ACCOUNT = @Username) RETURN 1   
      IF EXISTS
      (
            SELECT     dbo.EPG_GROUP_PERMISSIONS.GROUP_ID
            FROM         dbo.EPG_PERMISSIONS INNER JOIN
                      dbo.EPG_GROUP_PERMISSIONS ON dbo.EPG_PERMISSIONS.PERM_UID = dbo.EPG_GROUP_PERMISSIONS.PERM_UID LEFT OUTER JOIN
                      dbo.EPG_GROUP_MEMBERS INNER JOIN
                      dbo.EPG_GROUPS ON dbo.EPG_GROUP_MEMBERS.GROUP_ID = dbo.EPG_GROUPS.GROUP_ID INNER JOIN
                      dbo.EPG_RESOURCES ON dbo.EPG_GROUP_MEMBERS.MEMBER_UID = dbo.EPG_RESOURCES.WRES_ID ON 
                      dbo.EPG_GROUP_PERMISSIONS.GROUP_ID = dbo.EPG_GROUPS.GROUP_ID
            WHERE     (dbo.EPG_GROUP_PERMISSIONS.PERM_UID = @SecurityLevel) AND (dbo.EPG_RESOURCES.WRES_NT_ACCOUNT = @Username)
      ) SET @HasAccess = 1
      
      RETURN @HasAccess
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PFE_FN_GenerateNewResourceId')
begin
    Print 'Creating Function PFE_FN_GenerateNewResourceId'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function PFE_FN_GenerateNewResourceId'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' FUNCTION [dbo].[PFE_FN_GenerateNewResourceId] ()
RETURNS INT
AS
BEGIN
	RETURN (SELECT MAX(WRES_ID) AS MaxId FROM dbo.EPG_RESOURCES) + 1
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PPM_FN_ConvertListToTable')
begin
    Print 'Creating Function PPM_FN_ConvertListToTable'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Function PPM_FN_ConvertListToTable'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' function dbo.PPM_FN_ConvertListToTable(@str ntext)
returns @TokenVals table (TokenVal int)
as
begin
   declare @strlen int, @curpos int, @val int, @nextcomma int
   set @strlen = datalength(@str)
   set @curpos = 0
-- For each token, load it into the table
       while @curpos <= @strlen
          begin
             set @nextcomma = dbo.EPG_FN_charindex_ex('','', @str, @curpos)
             if @nextcomma = 0
                 set @nextcomma = @strlen + 1
                 set @val = cast(substring(@str,@curpos,@nextcomma - @curpos)   as int)
                 insert @TokenVals values (@val)
                 set @curpos = @nextcomma + 1
          end
return
end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_AddPlanResourcesToTeam')
begin
    Print 'Creating Stored Procedure EPG_SP_AddPlanResourcesToTeam'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_AddPlanResourcesToTeam'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_AddPlanResourcesToTeam
  @ProjectID int
AS
/* we were seeing many teams containing invalid entries */
Delete From EPGP_TEAMS Where WRES_ID Not In (Select WRES_ID From EPG_RESOURCES)
INSERT INTO EPGP_TEAMS ( [PROJECT_ID], [WRES_ID] )
SELECT DISTINCT [PROJECT_ID], [WRES_ID]
FROM   EPG_RESOURCEPLANS
WHERE  WRES_ID > 0 AND CMT_STATUS = 256 AND RP_ACTIVE_COMMITMENT = 1 AND PROJECT_ID = @ProjectID AND WRES_ID NOT IN (SELECT WRES_ID FROM EPGP_TEAMS WHERE PROJECT_ID = @ProjectID)

-- Update the RES_IN_PLAN flag
UPDATE EPGP_TEAMS SET RES_IN_PLAN = 0 WHERE PROJECT_ID = @ProjectID
UPDATE EPGP_TEAMS SET RES_IN_PLAN = 1 WHERE PROJECT_ID = @ProjectID AND WRES_ID IN (SELECT DISTINCT WRES_ID FROM EPG_RESOURCEPLANS WHERE WRES_ID > 0 AND CMT_STATUS = 256 AND RP_ACTIVE_COMMITMENT = 1 AND PROJECT_ID = @ProjectID)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CheckUserGlobalPermission')
begin
    Print 'Creating Stored Procedure EPG_SP_CheckUserGlobalPermission'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CheckUserGlobalPermission'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CheckUserGlobalPermission
   @WResID INT,
   @PermUID INT
AS
SELECT TOP 1 GP.PERM_UID,GM.MEMBER_UID
  FROM EPG_GROUP_PERMISSIONS GP
  LEFT JOIN EPG_GROUP_MEMBERS GM ON (GP.GROUP_ID = GM.GROUP_ID)
 WHERE GP.PERM_UID = @PermUID AND GM.MEMBER_UID = @WResID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CleanCatAvailAdmin')
begin
    Print 'Creating Stored Procedure EPG_SP_CleanCatAvailAdmin'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CleanCatAvailAdmin'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CleanCatAvailAdmin
  @CTID INT
AS
 Delete From EPGP_COST_VALUES
  Where CT_ID = @CTID And BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_AVAIL_CATEGORIES Where CT_ID = @CTID)
 Delete From EPGP_COST_DETAILS
  Where CT_ID = @CTID And BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_AVAIL_CATEGORIES Where CT_ID = @CTID)
 Delete From EPGP_DETAIL_VALUES
  Where CT_ID = @CTID And BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_AVAIL_CATEGORIES Where CT_ID = @CTID)
 Delete From EPGP_PROJECT_CT_STATUS
  Where CT_ID = @CTID And BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_AVAIL_CATEGORIES Where CT_ID = @CTID)
 Delete From EPGP_MODEL_TARGET_DETAILS
  Where (CT_ID = @CTID) 
    And BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_AVAIL_CATEGORIES Where CT_ID = @CTID)
 Delete   EPGP_MODEL_TARGET_VALUES
  From EPGP_MODEL_TARGET_VALUES
  left join EPGP_MODEL_TARGET_DETAILS On EPGP_MODEL_TARGET_DETAILS.TARGET_ID=EPGP_MODEL_TARGET_VALUES.TARGET_ID 
          And EPGP_MODEL_TARGET_DETAILS.TARGET_UID=EPGP_MODEL_TARGET_VALUES.TARGET_UID
  Where EPGP_MODEL_TARGET_DETAILS.TARGET_ID Is NULL
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CleanCTAdmin')
begin
    Print 'Creating Stored Procedure EPG_SP_CleanCTAdmin'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CleanCTAdmin'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CleanCTAdmin
AS
 Delete from EPGP_COST_BREAKDOWN_ATTRIBS 
  Where BA_BC_UID Not In (Select BC_UID From EPGP_COST_CATEGORIES)
 Delete from EPGP_COST_BREAKDOWN_ATTRIBS 
  Where BA_PRD_ID Not In (Select PRD_ID From EPG_PERIODS Where CB_ID=EPGP_COST_BREAKDOWN_ATTRIBS.CB_ID)
 Delete From EPGP_COST_XREF
  Where BC_UID Not In (Select CA_UID From EPGP_CATEGORIES)
 Delete From EPGP_AVAIL_CATEGORIES
  Where BC_UID Not In (Select BC_UID From EPGP_COST_CATEGORIES)
  
 Delete From EPGP_COST_VALUES
  Where BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_COST_CATEGORIES)
 Delete From EPGP_COST_DETAILS
  Where BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_COST_CATEGORIES)
 Delete From EPGP_DETAIL_VALUES
  Where BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_COST_CATEGORIES)
 Delete From EPGP_MODEL_DETAIL_VALUES
  Where BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_COST_CATEGORIES)
 Delete From EPGP_MODEL_COST_DETAILS
  Where BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_COST_CATEGORIES)  
 Delete From EPGP_PROJECT_CT_STATUS
  Where BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_COST_CATEGORIES)
 Delete From EPGP_MODEL_TARGET_DETAILS
  Where BC_UID <> 0 And BC_UID Not In (Select BC_UID From EPGP_COST_CATEGORIES)
 Delete   EPGP_MODEL_TARGET_VALUES
  From EPGP_MODEL_TARGET_VALUES
  left join EPGP_MODEL_TARGET_DETAILS On EPGP_MODEL_TARGET_DETAILS.TARGET_ID=EPGP_MODEL_TARGET_VALUES.TARGET_ID 
          And EPGP_MODEL_TARGET_DETAILS.TARGET_UID=EPGP_MODEL_TARGET_VALUES.TARGET_UID
  Where EPGP_MODEL_TARGET_DETAILS.TARGET_ID Is NULL

Delete From EPGP_COST_VALUES
    Where BD_PERIOD Not In (Select PRD_ID From EPG_PERIODS Where CB_ID=EPGP_COST_VALUES.CB_ID)
 Delete From EPGP_DETAIL_VALUES
    Where BD_PERIOD Not In (Select PRD_ID From EPG_PERIODS Where CB_ID=EPGP_DETAIL_VALUES.CB_ID)
 Delete From EPGP_MODEL_DETAIL_VALUES
    Where BD_PERIOD Not In (Select PRD_ID From EPG_PERIODS Where CB_ID=EPGP_MODEL_DETAIL_VALUES.CB_ID)
 Delete From EPGP_MODEL_TARGET_VALUES
    Where BD_PERIOD Not In (Select PRD_ID From EPG_PERIODS 
         Where CB_ID=(Select Top 1 CB_ID From EPGP_MODEL_TARGET_VALUES
           Left Join EPGP_MODEL_TARGETS On EPGP_MODEL_TARGETS.TARGET_ID=EPGP_MODEL_TARGET_VALUES.TARGET_ID))
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CleanModelAdmin')
begin
    Print 'Creating Stored Procedure EPG_SP_CleanModelAdmin'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CleanModelAdmin'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CleanModelAdmin
   @ModelUID INT
AS
 Delete From EPGP_MODEL_DETAIL_VALUES Where MODEL_UID = @ModelUID And MODEL_VERSION_UID Not In (Select MODEL_VERSION_UID From EPGP_MODEL_VERSIONS Where MODEL_UID = @ModelUID)
 Delete From EPGP_MODEL_COST_DETAILS Where MODEL_UID = @ModelUID And  MODEL_VERSION_UID Not In (Select MODEL_VERSION_UID From EPGP_MODEL_VERSIONS Where MODEL_UID = @ModelUID)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CleanPeriodAdmin')
begin
    Print 'Creating Stored Procedure EPG_SP_CleanPeriodAdmin'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CleanPeriodAdmin'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CleanPeriodAdmin
  @CBID INT
AS
  BEGIN
   DECLARE @MinPeriod INT 
   DECLARE @MaxPeriod INT 
   Select @MaxPeriod = Max (PRD_ID) From EPG_PERIODS Where CB_ID = @CBID
   Select @MinPeriod = Min (PRD_ID) From EPG_PERIODS Where CB_ID = @CBID
 
   Delete   EPGP_MODEL_TARGET_VALUES
     From EPGP_MODEL_TARGET_VALUES
       left join EPGP_MODEL_TARGETS On EPGP_MODEL_TARGETS.TARGET_ID=EPGP_MODEL_TARGET_VALUES.TARGET_ID 
     Where (EPGP_MODEL_TARGETS.TARGET_ID Is NULL Or EPGP_MODEL_TARGETS.CB_ID=@CBID) And (BD_PERIOD < @MinPeriod or BD_PERIOD > @MaxPeriod)
   Delete From EPGP_MODEL_DETAIL_VALUES Where CB_ID = @CBID And (BD_PERIOD < @MinPeriod or BD_PERIOD > @MaxPeriod)
   Delete From EPGP_COST_VALUES Where CB_ID = @CBID And (BD_PERIOD < @MinPeriod or BD_PERIOD > @MaxPeriod)
   Delete From EPGP_DETAIL_VALUES Where CB_ID = @CBID And (BD_PERIOD < @MinPeriod or BD_PERIOD > @MaxPeriod)
   Delete EPG_RESOURCEPLANS_HOURS
      From EPG_RESOURCEPLANS_HOURS
       Inner Join EPG_ADMIN On EPG_Admin.ADM_PORT_COMMITMENTS_CB_ID=@CBID
       Where (PRD_ID < @MinPeriod or PRD_ID > @MaxPeriod)
   Delete From EPGP_PI_PROGS_FISCAL Where CB_ID = @CBID And (PERIOD_ID < @MinPeriod or PERIOD_ID > @MaxPeriod)
   Delete EPGP_CAPACITY_VALUES
     From EPGP_CAPACITY_VALUES
       Inner Join EPG_ADMIN On EPG_Admin.ADM_PORT_COMMITMENTS_CB_ID=@CBID
       Where (BD_PERIOD < @MinPeriod or BD_PERIOD > @MaxPeriod)
   Delete EPGP_CAPACITY_SETVALUES
     From EPGP_CAPACITY_SETVALUES
       Inner Join EPG_ADMIN On EPG_Admin.ADM_PORT_COMMITMENTS_CB_ID=@CBID
       Where (BD_PERIOD < @MinPeriod or BD_PERIOD > @MaxPeriod)
   Delete From EPGP_COST_BREAKDOWN_ATTRIBS Where CB_ID = @CBID And (BA_PRD_ID < @MinPeriod or BA_PRD_ID > @MaxPeriod)

  END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CleanPortAdmin')
begin
    Print 'Creating Stored Procedure EPG_SP_CleanPortAdmin'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CleanPortAdmin'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CleanPortAdmin
AS
 Delete from EPGP_STAGE_FIELDS 
  Where ((STAGE_ID NOT IN (Select STAGE_ID From EPGP_STAGES)) OR (FIELD_ID NOT IN (Select FIELD_ID From EPGP_LAYOUT_FIELDS)))
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CleanWECharges')
begin
    Print 'Creating Stored Procedure EPG_SP_CleanWECharges'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CleanWECharges'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CleanWECharges
AS
 Delete EPG_WE_CHARGES From EPG_WE_CHARGES 
  Left Join EPG_WE_ACTUALHOURS On EPG_WE_ACTUALHOURS.WEH_CHG_UID=EPG_WE_CHARGES.WEC_CHG_UID 
  Where WEH_CHG_UID Is NULL
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ClearDeletedListValue')
begin
    Print 'Creating Stored Procedure EPG_SP_ClearDeletedListValue'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ClearDeletedListValue'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ClearDeletedListValue
AS
Delete From EPGP_PROG_INT_VALUES 
 Where PROG_UID Not In (Select LV_UID From EPGP_LOOKUP_VALUES)
Delete From EPGP_PROG_DEC_VALUES 
 Where PROG_UID Not In (Select LV_UID From EPGP_LOOKUP_VALUES)
Delete From EPGP_PROG_DATE_VALUES 
 Where PROG_UID Not In (Select LV_UID From EPGP_LOOKUP_VALUES)
Delete From EPGP_PROG_TEXT_VALUES 
 Where PROG_UID Not In (Select LV_UID From EPGP_LOOKUP_VALUES)
Delete From EPGP_PROG_NTEXT_VALUES 
 Where PROG_UID Not In (Select LV_UID From EPGP_LOOKUP_VALUES)
Delete From EPGP_COST_CATEGORIES 
 Where (MC_UID <> 0) And (MC_UID Not In (Select LV_UID From EPGP_LOOKUP_VALUES))
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ClearPV')
begin
    Print 'Creating Stored Procedure EPG_SP_ClearPV'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ClearPV'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ClearPV
   @WPROJID INT
AS
 Delete From EPGX_PROJ_INT_VALUES Where WPROJ_ID = @WPROJID
 Delete From EPGX_PROJ_DEC_VALUES Where WPROJ_ID = @WPROJID
 Delete From EPGX_PROJ_DATE_VALUES Where WPROJ_ID = @WPROJID
 Delete From EPGX_PROJ_NTEXT_VALUES Where WPROJ_ID = @WPROJID
 Delete From EPGX_PROJ_TEXT_VALUES Where WPROJ_ID = @WPROJID
 --Delete From EPGX_EV_TASK_BCWP Where WPROJ_ID = @WPROJID
 --Delete From EPGX_EV_TASK_BCWS Where WPROJ_ID = @WPROJID
 --Delete From EPGX_EV_TASK_FORC Where WPROJ_ID = @WPROJID
 Delete From EPGX_PROJECT_TASKS Where WPROJ_ID = @WPROJID
 Delete From EPGX_PROJECT_RESOURCES Where WPROJ_ID = @WPROJID
 Delete From EPGX_PROJECT_ASSN Where WPROJ_ID = @WPROJID
 Delete From EPGX_PROJECT_LOGIC Where WPROJ_ID = @WPROJID
 Delete From EPGX_PROJECT_TSWORK Where WPROJ_ID = @WPROJID
 --Delete From EPGX_PROJECT_PDWORK Where WPROJ_ID = @WPROJID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CopyCostValues')
begin
    Print 'Creating Stored Procedure EPG_SP_CopyCostValues'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CopyCostValues'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CopyCostValues
  @ProjectID INT,
  @CB_ID INT,
  @FromCT INT,
  @ToCT INT
AS
	delete from EPGP_DETAIL_VALUES where CB_ID=@CB_ID and CT_ID=@ToCT and PROJECT_ID=@ProjectID
	delete from EPGP_COST_DETAILS where CB_ID=@CB_ID and CT_ID=@ToCT and PROJECT_ID=@ProjectID
	delete from EPGP_COST_VALUES where CB_ID=@CB_ID and CT_ID=@ToCT and PROJECT_ID=@ProjectID
	delete from EPGP_PROJECT_CT_STATUS where CB_ID=@CB_ID and CT_ID=@ToCT and PROJECT_ID=@ProjectID

	insert into EPGP_COST_DETAILS(CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_SEQ,OC_01,OC_02,OC_03,OC_04,OC_05,TEXT_01,TEXT_02,TEXT_03,TEXT_04,TEXT_05,RT_UID)
	select CB_ID, @ToCT as CT_ID,PROJECT_ID,BC_UID,BC_SEQ,OC_01,OC_02,OC_03,OC_04,OC_05,TEXT_01,TEXT_02,TEXT_03,TEXT_04,TEXT_05,RT_UID
		from EPGP_COST_DETAILS where CB_ID=@CB_ID and CT_ID=@FromCT and PROJECT_ID=@ProjectID

	insert into EPGP_DETAIL_VALUES(CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_SEQ,BD_PERIOD,BD_VALUE,BD_COST)
	select CB_ID, @ToCT as CT_ID,PROJECT_ID,BC_UID,BC_SEQ,BD_PERIOD,BD_VALUE,BD_COST
		from EPGP_DETAIL_VALUES where CB_ID=@CB_ID and CT_ID=@FromCT and PROJECT_ID=@ProjectID

	insert into EPGP_COST_VALUES(CB_ID,CT_ID,PROJECT_ID,BC_UID,BD_PERIOD,BD_VALUE,BD_COST,BD_BATCH,BD_IS_SUMMARY)
	select CB_ID,@ToCT as CT_ID,PROJECT_ID,BC_UID,BD_PERIOD,BD_VALUE,BD_COST,''Copy Cost Values:'' + Convert(Varchar,Getdate()) as BD_BATCH,BD_IS_SUMMARY
		from EPGP_COST_VALUES where CB_ID=@CB_ID and CT_ID=@FromCT and PROJECT_ID=@ProjectID

	insert into EPGP_PROJECT_CT_STATUS(CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_STATUS)
	select CB_ID,@ToCT as CT_ID,PROJECT_ID,BC_UID,1 as BC_STATUS
		from EPGP_PROJECT_CT_STATUS where CB_ID=@CB_ID and CT_ID=@FromCT and PROJECT_ID=@ProjectID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CopyPV')
begin
    Print 'Creating Stored Procedure EPG_SP_CopyPV'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CopyPV'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CopyPV
   @FromWPROJID INT,
   @ToWPROJID INT
AS
 Insert Into EPGX_PROJECT_TASKS (WPROJ_ID, TASK_UID, TASK_ID, TASK_NAME, TASK_OUTLINE_LEVEL, TASK_TYPE, TASK_IS_EXTERNAL, TASK_IS_SUMMARY, 
                      TASK_IS_MILESTONE, TASK_MILESTONE_LEVEL, TASK_PRIORITY, TASK_START_DATE, TASK_FINISH_DATE, TASK_TOTAL_SLACK, 
                      TASK_BASELINE_START_DATE, TASK_BASELINE_FINISH_DATE, TASK_ACTUAL_START_DATE, TASK_ACTUAL_FINISH_DATE, 
                      TASK_PERCENT_WORKCOMPLETE, TASK_WORK, TASK_ACT_WORK, TASK_REM_WORK, TASK_COST, TASK_ACT_COST, TASK_REM_COST, 
                      TASK_CHARGENUMBER, TASK_CHARGESTATUS, TASK_MAJORCATEGORY, TASK_SUBPROJECTFILE, TASK_RESOURCES, TASK_DURATION, 
                      TASK_REMAINING_DURATION, TASK_CTEXT1, TASK_CTEXT2, TASK_CTEXT3, TASK_CTEXT4, TASK_CTEXT5, TASK_CTEXT6, TASK_CTEXT7, 
                      TASK_CTEXT8, TASK_CTEXT9, TASK_CTEXT10, TASK_CTEXT11, TASK_CTEXT12, TASK_CTEXT13, TASK_CTEXT14, TASK_CTEXT15, TASK_CTEXT16, 
                      TASK_CTEXT17, TASK_CTEXT18, TASK_CTEXT19, TASK_CTEXT20, TASK_FLAG1, TASK_FLAG2, TASK_FLAG3, TASK_FLAG4, TASK_FLAG5, 
                      TASK_FLAG6, TASK_FLAG7, TASK_FLAG8, TASK_FLAG9, TASK_FLAG10, TASK_NUMBER1, TASK_NUMBER2, TASK_NUMBER3, TASK_NUMBER4, 
                      TASK_NUMBER5, TASK_NUMBER6, TASK_NUMBER7, TASK_NUMBER8, TASK_NUMBER9, TASK_NUMBER10,
                      TASK_EV_WBS_NAME, TASK_EV_METHOD, TASK_EV_SUPP_DATA, TASK_EV_PERCENT_COMPLETE)
  SELECT    @ToWPROJID, TASK_UID, TASK_ID, TASK_NAME, TASK_OUTLINE_LEVEL, TASK_TYPE, TASK_IS_EXTERNAL, TASK_IS_SUMMARY, 
                      TASK_IS_MILESTONE, TASK_MILESTONE_LEVEL, TASK_PRIORITY, TASK_START_DATE, TASK_FINISH_DATE, TASK_TOTAL_SLACK, 
                      TASK_BASELINE_START_DATE, TASK_BASELINE_FINISH_DATE, TASK_ACTUAL_START_DATE, TASK_ACTUAL_FINISH_DATE, 
                      TASK_PERCENT_WORKCOMPLETE, TASK_WORK, TASK_ACT_WORK, TASK_REM_WORK, TASK_COST, TASK_ACT_COST, TASK_REM_COST, 
                      TASK_CHARGENUMBER, TASK_CHARGESTATUS, TASK_MAJORCATEGORY, TASK_SUBPROJECTFILE, TASK_RESOURCES, TASK_DURATION, 
                      TASK_REMAINING_DURATION, TASK_CTEXT1, TASK_CTEXT2, TASK_CTEXT3, TASK_CTEXT4, TASK_CTEXT5, TASK_CTEXT6, TASK_CTEXT7, 
                      TASK_CTEXT8, TASK_CTEXT9, TASK_CTEXT10, TASK_CTEXT11, TASK_CTEXT12, TASK_CTEXT13, TASK_CTEXT14, TASK_CTEXT15, TASK_CTEXT16, 
                      TASK_CTEXT17, TASK_CTEXT18, TASK_CTEXT19, TASK_CTEXT20, TASK_FLAG1, TASK_FLAG2, TASK_FLAG3, TASK_FLAG4, TASK_FLAG5, 
                      TASK_FLAG6, TASK_FLAG7, TASK_FLAG8, TASK_FLAG9, TASK_FLAG10, TASK_NUMBER1, TASK_NUMBER2, TASK_NUMBER3, TASK_NUMBER4, 
                      TASK_NUMBER5, TASK_NUMBER6, TASK_NUMBER7, TASK_NUMBER8, TASK_NUMBER9, TASK_NUMBER10,
                      TASK_EV_WBS_NAME, TASK_EV_METHOD, TASK_EV_SUPP_DATA, TASK_EV_PERCENT_COMPLETE
 FROM        EPGX_PROJECT_TASKS WHERE     (WPROJ_ID = @FromWPROJID)

 Insert Into EPGX_PROJ_INT_VALUES (WPROJ_ID, PROJECT_ID, XI_001, XI_002, XI_003, XI_004, XI_005, XI_006, XI_007, XI_008, XI_009, XI_010, XI_011, XI_012, XI_013, XI_014, XI_015, 
                      XI_016, XI_017, XI_018, XI_019, XI_020, XI_021, XI_022, XI_023, XI_024, XI_025, XI_026, XI_027, XI_028, XI_029, XI_030, XI_031, XI_032, XI_033, 
                      XI_034, XI_035, XI_036, XI_037, XI_038, XI_039, XI_040, XI_041, XI_042, XI_043, XI_044, XI_045, XI_046, XI_047, XI_048, XI_049, XI_050)
 SELECT    @ToWPROJID, PROJECT_ID, XI_001, XI_002, XI_003, XI_004, XI_005, XI_006, XI_007, XI_008, XI_009, XI_010, XI_011, XI_012, XI_013, XI_014, XI_015, 
                      XI_016, XI_017, XI_018, XI_019, XI_020, XI_021, XI_022, XI_023, XI_024, XI_025, XI_026, XI_027, XI_028, XI_029, XI_030, XI_031, XI_032, XI_033, 
                      XI_034, XI_035, XI_036, XI_037, XI_038, XI_039, XI_040, XI_041, XI_042, XI_043, XI_044, XI_045, XI_046, XI_047, XI_048, XI_049, XI_050
 FROM        EPGX_PROJ_INT_VALUES WHERE     (WPROJ_ID = @FromWPROJID)
  
Insert Into EPGX_PROJ_DEC_VALUES (WPROJ_ID, PROJECT_ID, XC_001, XC_002, XC_003, XC_004, XC_005, XC_006, XC_007, XC_008, XC_009, XC_010, XC_011, XC_012, XC_013, XC_014,
                       XC_015, XC_016, XC_017, XC_018, XC_019, XC_020, XC_021, XC_022, XC_023, XC_024, XC_025, XC_026, XC_027, XC_028, XC_029, XC_030, 
                      XC_031, XC_032, XC_033, XC_034, XC_035, XC_036, XC_037, XC_038, XC_039, XC_040, XC_041, XC_042, XC_043, XC_044, XC_045, XC_046, 
                      XC_047, XC_048, XC_049, XC_050)
 SELECT    @ToWPROJID, PROJECT_ID, XC_001, XC_002, XC_003, XC_004, XC_005, XC_006, XC_007, XC_008, XC_009, XC_010, XC_011, XC_012, XC_013, XC_014,
                       XC_015, XC_016, XC_017, XC_018, XC_019, XC_020, XC_021, XC_022, XC_023, XC_024, XC_025, XC_026, XC_027, XC_028, XC_029, XC_030, 
                      XC_031, XC_032, XC_033, XC_034, XC_035, XC_036, XC_037, XC_038, XC_039, XC_040, XC_041, XC_042, XC_043, XC_044, XC_045, XC_046, 
                      XC_047, XC_048, XC_049, XC_050
 FROM        EPGX_PROJ_DEC_VALUES WHERE     (WPROJ_ID = @FromWPROJID)
 
 Insert Into EPGX_PROJ_DATE_VALUES (WPROJ_ID, PROJECT_ID, XD_001, XD_002, XD_003, XD_004, XD_005, XD_006, XD_007, XD_008, XD_009, XD_010, XD_011, XD_012, XD_013, 
                      XD_014, XD_015, XD_016, XD_017, XD_018, XD_019, XD_020, XD_021, XD_022, XD_023, XD_024, XD_025, XD_026, XD_027, XD_028, XD_029, 
                      XD_030, XD_031, XD_032, XD_033, XD_034, XD_035, XD_036, XD_037, XD_038, XD_039, XD_040, XD_041, XD_042, XD_043, XD_044, XD_045, 
                      XD_046, XD_047, XD_048, XD_049, XD_050)
 SELECT    @ToWPROJID, PROJECT_ID, XD_001, XD_002, XD_003, XD_004, XD_005, XD_006, XD_007, XD_008, XD_009, XD_010, XD_011, XD_012, XD_013, 
                      XD_014, XD_015, XD_016, XD_017, XD_018, XD_019, XD_020, XD_021, XD_022, XD_023, XD_024, XD_025, XD_026, XD_027, XD_028, XD_029, 
                      XD_030, XD_031, XD_032, XD_033, XD_034, XD_035, XD_036, XD_037, XD_038, XD_039, XD_040, XD_041, XD_042, XD_043, XD_044, XD_045, 
                      XD_046, XD_047, XD_048, XD_049, XD_050
 FROM        EPGX_PROJ_DATE_VALUES WHERE     (WPROJ_ID = @FromWPROJID)
 
 Insert Into EPGX_PROJ_NTEXT_VALUES (WPROJ_ID, PROJECT_ID, XN_001, XN_002, XN_003, XN_004, XN_005, XN_006, XN_007, XN_008, XN_009, XN_010, XN_011, XN_012, XN_013, 
                      XN_014, XN_015, XN_016, XN_017, XN_018, XN_019, XN_020, XN_021, XN_022, XN_023, XN_024, XN_025, XN_026, XN_027, XN_028, XN_029, 
                      XN_030, XN_031, XN_032, XN_033, XN_034, XN_035, XN_036, XN_037, XN_038, XN_039, XN_040, XN_041, XN_042, XN_043, XN_044, XN_045, 
                      XN_046, XN_047, XN_048, XN_049, XN_050)
 SELECT    @ToWPROJID, PROJECT_ID, XN_001, XN_002, XN_003, XN_004, XN_005, XN_006, XN_007, XN_008, XN_009, XN_010, XN_011, XN_012, XN_013, 
                      XN_014, XN_015, XN_016, XN_017, XN_018, XN_019, XN_020, XN_021, XN_022, XN_023, XN_024, XN_025, XN_026, XN_027, XN_028, XN_029, 
                      XN_030, XN_031, XN_032, XN_033, XN_034, XN_035, XN_036, XN_037, XN_038, XN_039, XN_040, XN_041, XN_042, XN_043, XN_044, XN_045, 
                      XN_046, XN_047, XN_048, XN_049, XN_050
 FROM        EPGX_PROJ_NTEXT_VALUES WHERE     (WPROJ_ID = @FromWPROJID)
 
 Insert Into EPGX_PROJ_TEXT_VALUES (WPROJ_ID, PROJECT_ID, XT_001, XT_002, XT_003, XT_004, XT_005, XT_006, XT_007, XT_008, XT_009, XT_010, XT_011, XT_012, XT_013, XT_014, 
                      XT_015, XT_016, XT_017, XT_018, XT_019, XT_020, XT_021, XT_022, XT_023, XT_024, XT_025, XT_026, XT_027, XT_028, XT_029, XT_030, XT_031, 
                      XT_032, XT_033, XT_034, XT_035, XT_036, XT_037, XT_038, XT_039, XT_040, XT_041, XT_042, XT_043, XT_044, XT_045, XT_046, XT_047, XT_048, 
                      XT_049, XT_050)
 SELECT    @ToWPROJID, PROJECT_ID, XT_001, XT_002, XT_003, XT_004, XT_005, XT_006, XT_007, XT_008, XT_009, XT_010, XT_011, XT_012, XT_013, XT_014, 
                      XT_015, XT_016, XT_017, XT_018, XT_019, XT_020, XT_021, XT_022, XT_023, XT_024, XT_025, XT_026, XT_027, XT_028, XT_029, XT_030, XT_031, 
                      XT_032, XT_033, XT_034, XT_035, XT_036, XT_037, XT_038, XT_039, XT_040, XT_041, XT_042, XT_043, XT_044, XT_045, XT_046, XT_047, XT_048, 
                      XT_049, XT_050                      
  FROM       EPGX_PROJ_TEXT_VALUES WHERE     (WPROJ_ID = @FromWPROJID)
 
 Insert Into EPGX_PROJECT_RESOURCES (WPROJ_ID, WRES_ID, EXRES_ID, EXRES_NAME, EXRES_NT_ACCOUNT, EXRES_EMAIL)
  SELECT     @ToWPROJID, WRES_ID, EXRES_ID, EXRES_NAME, EXRES_NT_ACCOUNT, EXRES_EMAIL
  FROM       EPGX_PROJECT_RESOURCES WHERE     (WPROJ_ID = @FromWPROJID)
 
 Insert Into EPGX_PROJECT_ASSN (WPROJ_ID, TASK_UID, WRES_ID, LOCAL_WRES_ID, ASSN_START_DATE, ASSN_FINISH_DATE, ASSN_WORK, ASSN_PERCENTWORKCOMPLETE)
 SELECT    @ToWPROJID, TASK_UID, WRES_ID, LOCAL_WRES_ID, ASSN_START_DATE, ASSN_FINISH_DATE, ASSN_WORK, ASSN_PERCENTWORKCOMPLETE
 FROM       EPGX_PROJECT_ASSN WHERE     (WPROJ_ID = @FromWPROJID)
 
 Insert Into EPGX_PROJECT_LOGIC (WPROJ_ID, LG_TASK_SUCC_UID, LG_TASK_PRED_UID, LG_LAG, LG_LAG_TYPE)
  SELECT    @ToWPROJID, LG_TASK_SUCC_UID, LG_TASK_PRED_UID, LG_LAG, LG_LAG_TYPE
  FROM       EPGX_PROJECT_LOGIC WHERE     (WPROJ_ID = @FromWPROJID)
 
 Insert Into EPGX_PROJECT_TSWORK (WPROJ_ID, WRES_ID, EXRES_ID, TSWORK_MAJORCATEGORY, TSWORK_DATE, TSWORK_WORK)
  SELECT    @ToWPROJID, WRES_ID, EXRES_ID, TSWORK_MAJORCATEGORY, TSWORK_DATE, TSWORK_WORK
  FROM       EPGX_PROJECT_TSWORK WHERE     (WPROJ_ID = @FromWPROJID)
 
 --Insert Into EPGX_PROJECT_PDWORK (WPROJ_ID, WRES_ID, EXRES_ID, TASK_UID, PDWORK_PRD_ID, PDWORK_WORK)
 -- SELECT    @ToWPROJID, WRES_ID, EXRES_ID, TASK_UID, PDWORK_PRD_ID, PDWORK_WORK
 -- FROM       EPGX_PROJECT_PDWORK WHERE     (WPROJ_ID = @FromWPROJID)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CountActualUsers')
begin
    Print 'Creating Stored Procedure EPG_SP_CountActualUsers'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CountActualUsers'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CountActualUsers
AS
--SELECT COUNT(*) as ActualUsers 
--  FROM EPG_RESOURCES
-- WHERE WRES_IS_RESOURCE = 0 and WRES_CAN_LOGIN = 1

--SELECT COUNT(*) as PoolUsers 
--  FROM EPG_RESOURCES
-- WHERE WRES_INACTIVE = 0 and WRES_IS_RESOURCE = 1
 
declare @count1 int
set @count1 = 0
(SELECT @count1 = COUNT(*)
  FROM EPG_RESOURCES
 WHERE WRES_IS_RESOURCE = 0 and WRES_CAN_LOGIN = 1 AND WRES_ID <> 1)

declare @count2 int
set @count2 = 0
(SELECT @count2 =  COUNT(*)
  FROM EPG_RESOURCES
 WHERE WRES_INACTIVE = 0 and WRES_IS_RESOURCE = 1 AND WRES_ID <> 1)
 
SELECT @count1 + @count2 as ActualResourceCount

SELECT COUNT(*) as ActualUserCount 
  FROM EPG_RESOURCES
 WHERE WRES_CAN_LOGIN = 1 AND WRES_ID <> 1

SELECT COUNT(*) as ActualEVUsers 
  FROM EPG_GROUP_MEMBERS
  left join EPG_RESOURCES WR on MEMBER_UID = WR.WRES_ID
 WHERE WRES_IS_RESOURCE = 1 and WRES_CAN_LOGIN = 1 and GROUP_ID in (select GROUP_ID from EPG_GROUP_PERMISSIONS where PERM_UID = 3044)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_CountUserMessages')
begin
    Print 'Creating Stored Procedure EPG_SP_CountUserMessages'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_CountUserMessages'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_CountUserMessages
  @WResID int
AS
-- NB This SP must match EPG020
/* read all timesheet notes for me as a TS user */
/* read all timesheet notes for me as a deptmgr */
/* read all timesheet notes for me as a projmgr */
/* read all timesheet notes for me as a PI mgr */
/* read all resource plan notes for me as a PI mgr */
/* read all resource plan notes for me as a dept mgr */
/* read all resource plan notes for me as a resource */
--SELECT COUNT(*) as UserMessageCount 
--  FROM EPG_NOTE_THREADS NT
--  WHERE NT_ACCEPTED = 0 
--    AND (((NT_CONTEXT = 1 OR NT_CONTEXT = 4 OR NT_CONTEXT = 9) AND NT_INDEX_2 = @WResID)
--     OR   (NT_CONTEXT = 2 AND NT_INDEX_2 IN (SELECT CODE_UID FROM EPG_TS_APPROVERS WHERE WRES_ID=@WResID))
--     OR  ((NT_CONTEXT = 3 OR NT_CONTEXT = 5) AND NT_INDEX_2 IN (SELECT WPROJ_ID FROM EPGX_PROJECT_VERSIONS WHERE PROJECT_ID IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_PLAN_OWNER=@WResID)))
--     OR   (NT_CONTEXT = 6 AND NT_INDEX_2 IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MANAGER=@WResID))
--     OR   (NT_CONTEXT = 7 AND NT_INDEX_2 IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MANAGER=@WResID))
--     OR  (NT_CONTEXT = 8 AND NT_INDEX_2 IN (SELECT CODE_UID FROM EPG_RES_MANAGERS WHERE WRES_ID=@WResID))
--     OR  (NT_CONTEXT = 10 AND NT_INDEX_1 = @WResID))
--SELECT 0 as UserMessageCount 
SELECT COUNT(NT_UID) as UserMessageCount 
  FROM EPG_NOTE_THREADS NT
  WHERE NT_ACCEPTED = 0 
    AND (((NT_CONTEXT = 1 OR NT_CONTEXT = 4 OR NT_CONTEXT = 9) AND NT_INDEX_2 = @WResID)
     OR   (NT_CONTEXT = 2 AND NT_INDEX_2 IN (SELECT CODE_UID FROM EPG_TS_APPROVERS WHERE WRES_ID=@WResID))
     OR  ((NT_CONTEXT = 3 OR NT_CONTEXT = 5) AND NT_INDEX_2 IN (SELECT WPROJ_ID FROM EPGX_PROJECT_VERSIONS WHERE PROJECT_ID IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_PLAN_OWNER=@WResID)))
     OR   (NT_CONTEXT = 6 AND NT_INDEX_2 IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MANAGER=@WResID))
     OR   (NT_CONTEXT = 7 AND NT_INDEX_2 IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MANAGER=@WResID))
     OR  (NT_CONTEXT = 8 AND NT_INDEX_2 IN (SELECT CODE_UID FROM EPG_RES_MANAGERS WHERE WRES_ID=@WResID))
     OR  (NT_CONTEXT = 10 AND NT_INDEX_1 = @WResID))
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DBANotesManagement')
begin
    Print 'Creating Stored Procedure EPG_SP_DBANotesManagement'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DBANotesManagement'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DBANotesManagement
  @Mode INT
AS
-- EPG_NOTES and EPG_NOTE_THREAD context descriptions
-- NT_CONTEXT               NT_INDEX_1  NT_INDEX_2  NT_INDEX_3
-- 01 TS User               TS_UID      WRES_ID
-- 02 TS Dept Mgr           TS_UID      WRES_ID
-- 03 TS Proj Mgr           TS_UID      WPROJ_ID
-- 04 Taskstatus User		TKS_UID     WRES_ID
-- 05 Taskstatus Proj Mgr   TKS_UID     WPROJ_ID
-- 06 TS Portfolio Mgr      TS_UID      PROJECT_ID
-- 07 RP PI Mgr             PROJECT_ID  PROJECT_ID  CMT_UID
-- 08 RP Resource Mgr       PROJECT_ID  CODE_UID    CMT_UID
-- 09 RP Resource           PROJECT_ID  WRES_ID     CMT_UID
-- 10 General User          WRES_ID

if (@Mode = 0)
	-- Mode = 0 = return system notification information
	begin
		SELECT COUNT(*) as NotesCount FROM EPG_NOTES
	end
else if (@Mode = 1)
	-- Mode = 1 = Delete redundant notifications
	begin
		--DELETE TS Note threads where TS has been deleted
		DELETE FROM EPG_NOTE_THREADS
		 WHERE NT_CONTEXT IN (1,2,3,6) AND NT_INDEX_1 NOT IN (SELECT TS_UID FROM EPG_TS_TIMESHEETS)

		--DELETE Taskstatus Note threads where TaskStatus has been deleted
		DELETE FROM EPG_NOTE_THREADS
		 WHERE NT_CONTEXT IN (4,5) AND NT_INDEX_1 NOT IN (SELECT TKS_UID FROM EPG_TASKSTATUS)

		--DELETE Resource Plan Note threads where Project has been deleted
		DELETE FROM EPG_NOTE_THREADS
		 WHERE NT_CONTEXT IN (7,8,9) AND NT_INDEX_1 NOT IN (SELECT PROJECT_ID FROM EPGP_PROJECTS)

		--DELETE Resource Plan Note threads where plan row has been deleted
		DELETE FROM EPG_NOTE_THREADS
		 WHERE NT_CONTEXT IN (7,8,9) AND NT_INDEX_3 NOT IN (SELECT CMT_UID FROM EPG_RESOURCEPLANS)

		--DELETE General Note threads where resource has been deleted
		DELETE FROM EPG_NOTE_THREADS
		 WHERE NT_CONTEXT = 10 AND NT_INDEX_1 NOT IN (SELECT WRES_ID FROM EPG_RESOURCES)

		--DELETE Notes which have been orphaned
		DELETE FROM EPG_NOTES
		 WHERE NOTE_UID NOT IN (SELECT NT_NOTE_UID FROM EPG_NOTE_THREADS)
	end
else if (@Mode = 2)
	-- Mode = 2 = Delete accepted notifications
	begin
		--SELECT/DELETE specific note threads which have been accepted
		--NB. Must leave some note threads to preserve notes for existing objects
		--DELETE TS Note threads before date
		DELETE FROM EPG_NOTE_THREADS
		 WHERE NT_CONTEXT IN (2,3,6) AND NT_ACCEPTED = 1

		--DELETE Taskstatus Note threads
		DELETE FROM EPG_NOTE_THREADS
		 WHERE NT_CONTEXT = 5 AND NT_ACCEPTED = 1

		--DELETE Resource plan Note threads
		SELECT COUNT(*) as RPNoteThreadsOlderThan30Days FROM EPG_NOTE_THREADS
		  LEFT JOIN EPG_NOTES ON (NT_NOTE_UID = NOTE_UID)
		 WHERE NT_CONTEXT IN (7,8) AND NT_ACCEPTED = 1

		--DELETE Resource Note threads before date
		DELETE FROM EPG_NOTE_THREADS
		 WHERE NT_CONTEXT = 10 AND NT_ACCEPTED = 1

		--DELETE Notes which have been orphaned
		DELETE FROM EPG_NOTES
		 WHERE NOTE_UID NOT IN (SELECT NT_NOTE_UID FROM EPG_NOTE_THREADS)
	end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteALTAvails')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteALTAvails'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteALTAvails'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteALTAvails
  @sDeptList NTEXT,
  @sResList NTEXT,
  @StartPeriod INT,
  @DeptMode int
AS
   Delete from EPGP_ALT_CAPACITY_VALUES Where BD_PERIOD >= @StartPeriod And WRES_ID In (Select TokenVal From EPG_FN_ConvertListToTable(@sResList))
   if (@DeptMode > 0)
     Delete from EPGP_ALT_CAPACITY_VALUES Where BD_PERIOD >= @StartPeriod And WRES_DEPT In (Select TokenVal From EPG_FN_ConvertListToTable(@sDeptList))
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteAvails')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteAvails'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteAvails'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteAvails
  @sDeptList NTEXT,
  @sResList NTEXT
AS
delete from EPGP_CAPACITY_VALUES 
where WRES_DEPT in (Select TokenVal From EPG_FN_ConvertListToTable(@sDeptList)) 

-- and guys who have moved into a selected dept since last Calc Avail
delete from EPGP_CAPACITY_VALUES 
from EPGP_CAPACITY_VALUES ECV
join EPG_RESOURCES ER on ER.WRES_ID=ECV.WRES_ID and ER.WRES_RP_DEPT 
in (Select TokenVal From EPG_FN_ConvertListToTable(@sDeptList))
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteChunks')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteChunks'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteChunks'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteChunks
   @WresID INT
AS
DELETE FROM EPG_CHUNKER WHERE WRES_ID = @WresID Or DATEDIFF(hour,CHUNK_DATE,GETDATE()) > 1
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteCustomField')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteCustomField'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteCustomField'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteCustomField
   @FieldID INT
AS
 DELETE FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=@FieldID
 DELETE FROM EPGP_RD_FIELDS Where FIELD_ID=@FieldID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteInvalidDelegates')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteInvalidDelegates'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteInvalidDelegates'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteInvalidDelegates
AS
-- Delegate values:
--    scTimesheet = 1
--    scDepartment = 2
--    scPIPlanOwner = 3
--    scPIManager = 4
--    scResourceManager = 5
--    scPIStageOwner = 6

-- Resource cannot be own delegate
DELETE FROM EPG_DELEGATES
 WHERE WRES_ID = SURR_WRES_ID

-- TS Dept Manager
DELETE FROM EPG_DELEGATES
  FROM EPG_DELEGATES SU
  LEFT JOIN EPG_TS_APPROVERS AP on (SU.SURR_CONTEXT = 2 and SU.SURR_CONTEXT_VALUE = AP.CODE_UID)
  LEFT JOIN EPGP_LOOKUP_VALUES OC ON LV_UID = AP.CODE_UID
 WHERE SU.SURR_CONTEXT = 2 AND SU.WRES_ID <> AP.WRES_ID

-- PI Plan Owner
DELETE FROM EPG_DELEGATES
  FROM EPG_DELEGATES SU
  LEFT JOIN EPGP_PROJECTS PR on (SU.SURR_CONTEXT = 3 and SU.SURR_CONTEXT_VALUE = PR.PROJECT_ID)
 WHERE SU.SURR_CONTEXT = 3 AND SU.WRES_ID <> PR.PROJECT_PLAN_OWNER

-- PI Manager
DELETE FROM EPG_DELEGATES
  FROM EPG_DELEGATES SU
  LEFT JOIN EPGP_PROJECTS PR on (SU.SURR_CONTEXT = 4 and SU.SURR_CONTEXT_VALUE = PR.PROJECT_ID)
 WHERE SU.SURR_CONTEXT = 4 AND SU.WRES_ID <> PR.PROJECT_MANAGER

-- Resource Manager
DELETE FROM EPG_DELEGATES
  FROM EPG_DELEGATES SU
  LEFT JOIN EPG_RES_MANAGERS AP on (SU.SURR_CONTEXT = 5 and SU.SURR_CONTEXT_VALUE = AP.CODE_UID)
 WHERE SU.SURR_CONTEXT = 5 AND SU.WRES_ID <> AP.WRES_ID

-- PI Stage Owner
DELETE FROM EPG_DELEGATES
  FROM EPG_DELEGATES SU
  LEFT JOIN EPGP_PROJECTS PR on (SU.SURR_CONTEXT = 6 and SU.SURR_CONTEXT_VALUE = PR.PROJECT_ID)
 WHERE SU.SURR_CONTEXT = 6 AND SU.WRES_ID <> PR.PROJECT_OWNER

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteModel')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteModel'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteModel'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteModel
   @ModelUID INT
AS
 Delete From EPGP_MODEL_GROUP_SECURITY Where MODEL_UID = @ModelUID
 Delete From EPGP_MODEL_VERSIONS Where MODEL_UID = @ModelUID
 Delete From EPGP_MODEL_PROJECT_DATES Where MODEL_UID = @ModelUID
 Delete From EPGP_MODEL_DETAIL_VALUES Where MODEL_UID = @ModelUID
 Delete From EPGP_MODEL_COST_DETAILS Where MODEL_UID = @ModelUID
 Delete From EPGP_MODEL_CTS Where MODEL_UID = @ModelUID
 Delete From EPGP_MODEL_SCENARIOS Where MODEL_UID = @ModelUID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteOldAvails')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteOldAvails'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteOldAvails'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteOldAvails
AS
BEGIN
 DECLARE @DeptUID INT
 DECLARE @RPCalID INT
 SELECT @DeptUID = ADM_RPE_DEPT_CODE FROM EPG_ADMIN
 SELECT @RPCalID = ADM_PORT_COMMITMENTS_CB_ID FROM EPG_ADMIN
 Delete from EPGP_CAPACITY_VALUES Where CB_ID <> @RPCalID
 Delete from EPGP_CAPACITY_VALUES Where WRES_DEPT Not In (Select LV_UID From EPGP_LOOKUP_VALUES Where LOOKUP_UID=@DeptUID)
 Delete from EPGP_CAPACITY_VALUES Where WRES_ID Not In (Select WRES_ID From EPG_RESOURCES)
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeletePI')
begin
    Print 'Creating Stored Procedure EPG_SP_DeletePI'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeletePI'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeletePI
   @PROJID INT
AS
 Delete From EPGP_PI_WORKITEM_LOGIC Where PROJECT_ID = @PROJID
 Delete From EPGP_PI_WORKITEM_ASSNS Where PROJECT_ID = @PROJID
 Delete From EPGP_PI_WORKITEM_TSWORK Where PROJECT_ID = @PROJID
 Delete From EPGP_PI_WORKITEMS Where PROJECT_ID = @PROJID
 Delete From EPGP_PI_PROGS Where PROJECT_ID = @PROJID
 Delete From EPGP_PI_PROGS_FISCAL Where PROJECT_ID = @PROJID
 Delete From EPG_RESOURCEPLANS_HOURS Where CMT_UID In (Select CMT_UID From EPG_RESOURCEPLANS Where PROJECT_ID = @PROJID)
 Delete From EPGP_RP_CATEGORY_VALUES Where CAT_CMT_UID In (Select CMT_UID From EPG_RESOURCEPLANS Where PROJECT_ID = @PROJID)
 Delete From EPG_RESOURCEPLANS Where PROJECT_ID = @PROJID
 Delete From EPGP_PI_WORK1 Where PROJECT_ID = @PROJID
 Delete From EPGP_PI_WORK2 Where PROJECT_ID = @PROJID
 Delete From EPGP_PROJECT_RESOURCE_SECURITY Where PROJECT_ID = @PROJID 
 Delete From EPGP_PROJECT_GROUP_SECURITY Where PROJECT_ID = @PROJID 
 Delete From EPGP_PROJECT_CT_STATUS Where PROJECT_ID = @PROJID
 Delete From EPGP_COST_DETAILS Where PROJECT_ID = @PROJID 
 Delete From EPGP_DETAIL_VALUES Where PROJECT_ID = @PROJID 
 Delete From EPGP_COST_VALUES Where PROJECT_ID = @PROJID 
 Delete From EPGP_PROJECT_STAGES Where PROJECT_ID = @PROJID 
 Delete From EPG_TS_ACTUALHOURS Where CHG_UID In (Select CHG_UID From EPG_TS_CHARGES Where PROJECT_ID = @PROJID)
 Delete From EPG_TS_CATEGORY_VALUES Where CAT_CHG_UID In (Select CHG_UID From EPG_TS_CHARGES Where PROJECT_ID = @PROJID)
 Delete From EPG_TS_ADJUSTMENTHOURS Where ADJ_UID In (Select ADJ_UID From EPG_TS_CHARGES Where PROJECT_ID = @PROJID)
 Delete From EPG_TS_CHARGES Where PROJECT_ID = @PROJID 
 Delete From EPG_TS_PROGRESS Where PROJECT_ID = @PROJID 
 Delete From EPG_WE_ACTUALHOURS Where WEH_CHG_UID In (Select WEC_CHG_UID From EPG_WE_CHARGES Where PROJECT_ID = @PROJID) 
 Delete From EPG_WE_CHARGES Where PROJECT_ID = @PROJID 
 Delete From EPG_TASKSTATUS Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPG_PROJ_TASKS Where PT_WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGP_PROJECT_INT_VALUES Where PROJECT_ID = @PROJID 
 Delete From EPGP_PROJECT_TEXT_VALUES Where PROJECT_ID = @PROJID 
 Delete From EPGP_PROJECT_DEC_VALUES Where PROJECT_ID = @PROJID 
 Delete From EPGP_PROJECT_NTEXT_VALUES Where PROJECT_ID = @PROJID 
 Delete From EPGP_PROJECT_DATE_VALUES Where PROJECT_ID = @PROJID
 Delete From EPGX_PROJ_DATE_VALUES Where PROJECT_ID=@PROJID
 Delete From EPGX_PROJ_DATE_VALUES Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGX_PROJ_INT_VALUES Where PROJECT_ID=@PROJID
 Delete From EPGX_PROJ_INT_VALUES Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGX_PROJ_TEXT_VALUES Where PROJECT_ID=@PROJID
 Delete From EPGX_PROJ_TEXT_VALUES Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGX_PROJ_NTEXT_VALUES Where PROJECT_ID=@PROJID
 Delete From EPGX_PROJ_NTEXT_VALUES Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGX_PROJ_DEC_VALUES Where PROJECT_ID=@PROJID
 Delete From EPGX_PROJ_DEC_VALUES Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGX_PROJECT_RESOURCES Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGX_PROJECT_ASSN Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGX_PROJECT_LOGIC Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGX_PROJECT_TASKS Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGX_PROJECT_TSWORK Where WPROJ_ID In (Select WPROJ_ID From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID)
 Delete From EPGX_PROJECT_VERSIONS Where PROJECT_ID=@PROJID
 Delete From EPGP_MODEL_DETAIL_VALUES Where PROJECT_ID=@PROJID
 Delete From EPGP_MODEL_COST_DETAILS Where PROJECT_ID=@PROJID
 Delete From EPGP_MODEL_PROJECT_DATES Where PROJECT_ID=@PROJID
 Delete From EPGP_PROJECTS Where PROJECT_ID = @PROJID 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteProgram')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteProgram'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteProgram'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteProgram
   @FieldID INT
AS
 DELETE FROM EPGP_PI_PROGS Where FIELD_ID=@FieldID
 DELETE FROM EPGP_PROG_INFOS Where FIELD_ID=@FieldID
 DELETE FROM EPGP_PI_PROGS_FISCAL Where FIELD_ID=@FieldID
 DELETE FROM EPGP_PROG_DATE_VALUES Where FIELD_ID=@FieldID
 DELETE FROM EPGP_PROG_DEC_VALUES Where FIELD_ID=@FieldID
 DELETE FROM EPGP_PROG_INT_VALUES Where FIELD_ID=@FieldID
 DELETE FROM EPGP_PROG_NTEXT_VALUES Where FIELD_ID=@FieldID
 DELETE FROM EPGP_PROG_TEXT_VALUES Where FIELD_ID=@FieldID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteProjectVersion')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteProjectVersion'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteProjectVersion'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteProjectVersion
   @WPROJID INT
AS
 Delete From EPGX_PROJ_DATE_VALUES Where WPROJ_ID=@WPROJID
 Delete From EPGX_PROJ_INT_VALUES Where WPROJ_ID=@WPROJID
 Delete From EPGX_PROJ_TEXT_VALUES Where WPROJ_ID=@WPROJID
 Delete From EPGX_PROJ_NTEXT_VALUES Where WPROJ_ID=@WPROJID
 Delete From EPGX_PROJ_DEC_VALUES Where WPROJ_ID=@WPROJID
 Delete From EPGX_PROJECT_RESOURCES Where WPROJ_ID=@WPROJID
 Delete From EPGX_PROJECT_ASSN Where WPROJ_ID=@WPROJID
 Delete From EPGX_PROJECT_LOGIC Where WPROJ_ID=@WPROJID
 Delete From EPGX_PROJECT_TASKS Where WPROJ_ID=@WPROJID
 Delete From EPGX_PROJECT_TSWORK Where WPROJ_ID=@WPROJID
 Delete From EPGX_PROJECT_VERSIONS Where WPROJ_ID=@WPROJID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteResource')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteResource'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteResource'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteResource
   @WRESID INT,
   @ReplacementWRESID INT
AS

/* first recast any references we''ve agreed to change */
Update EPGP_PROJECTS Set PROJECT_CREATEDBY = @ReplacementWRESID Where PROJECT_CREATEDBY = @WresID
Update EPGP_PROJECT_STAGES Set STAGE_OWNER = @ReplacementWRESID Where STAGE_OWNER = @WresID
Update EPGP_PROJECT_STAGES Set WRES_ID = @ReplacementWRESID Where WRES_ID = @WresID
Update EPGX_PROJECT_VERSIONS Set PV_IMPORTED_BY = @ReplacementWRESID Where PV_IMPORTED_BY = @WresID 
Update EPG_RESOURCEPLANS Set CMT_ENTEREDBY_WRES_ID = @ReplacementWRESID Where CMT_ENTEREDBY_WRES_ID = @WresID
Update EPG_TS_TIMESHEETS Set TS_SUBMITTED_WRES_ID = @ReplacementWRESID Where TS_SUBMITTED_WRES_ID = @WresID 
Update EPG_TS_TIMESHEETS Set TS_DEPT_WRES_ID = @ReplacementWRESID Where TS_DEPT_WRES_ID = @WresID 
Update EPG_TS_CHARGES Set CHG_PROJ_WRES_ID = @ReplacementWRESID Where CHG_PROJ_WRES_ID = @WresID 
Update EPG_TS_PROGRESS Set TSP_STATUS_WRES_ID = @ReplacementWRESID Where TSP_STATUS_WRES_ID = @WresID 
Update EPG_TS_DEPTS Set TSD_WRES_ID = @ReplacementWRESID Where TSD_WRES_ID = @WresID
Update EPG_TS_ADJUSTMENTS Set ADJ_ADMIN_WRES_ID = @ReplacementWRESID Where ADJ_ADMIN_WRES_ID = @WresID
Update EPG_TASKSTATUS Set WRES_ID = @ReplacementWRESID Where WRES_ID = @WresID 
Update EPG_TASKSTATUS Set TKS_STATUS_WRES_ID = @ReplacementWRESID Where TKS_STATUS_WRES_ID = @WresID 
Update EPG_JOBS Set WRES_ID = @ReplacementWRESID Where WRES_ID = @WresID
Update EPG_JOBS_TIMER Set WRES_ID = @ReplacementWRESID Where WRES_ID = @WresID
Update EPG_UPLOADS Set WRES_ID = @ReplacementWRESID Where WRES_ID = @WresID
Update EPG_NOTES Set NOTE_AUTHOR_WRES_ID = @ReplacementWRESID Where NOTE_AUTHOR_WRES_ID = @WresID

 Delete From EPG_SITEMAP Where WRES_ID = @WRESID
 Delete From EPG_USERINFO Where WRES_ID = @WRESID
 Delete From EPGT_VIEW_SORT Where WRES_ID = @WRESID
 Delete From EPG_DELEGATES Where WRES_ID = @WRESID Or SURR_WRES_ID = @WRESID
 Delete From EPGP_PROJECT_RESOURCE_SECURITY Where WRES_ID = @WRESID
 Delete From EPGP_MODEL_TARGET_VALUES Where TARGET_ID In (Select TARGET_ID From EPGP_MODEL_TARGETS Where WRES_ID = @WRESID)
 Delete From EPGP_MODEL_TARGET_DETAILS Where TARGET_ID In (Select TARGET_ID From EPGP_MODEL_TARGETS Where WRES_ID = @WRESID)
 Delete From EPGP_MODEL_TARGETS Where WRES_ID = @WRESID
 Delete From EPG_NONWORK_HOURS Where WRES_ID = @WRESID
 Delete From EPGP_COST_XREF Where WRES_ID = @WRESID
 Delete From EPGP_COST_RATES Where WRES_ID = @WRESID
 Delete From EPG_MY_RESOURCES Where WRES_ID = @WRESID Or MR_WRES_ID = @WRESID
 Delete From EPGT_LOCALVIEWS Where WRES_ID = @WRESID
 Delete From EPGP_CAPACITY_VALUES Where WRES_ID = @WRESID
 Delete From EPG_RD_VIEWS Where WRES_ID = @WRESID
 Delete From EPG_GROUP_MEMBERS Where MEMBER_UID = @WRESID
 Delete From EPGC_RESOURCE_MV_VALUES Where WRES_ID = @WRESID 
 Delete From EPGC_RESOURCE_INT_VALUES Where WRES_ID = @WRESID 
 Delete From EPGC_RESOURCE_TEXT_VALUES Where WRES_ID = @WRESID 
 Delete From EPGC_RESOURCE_DEC_VALUES Where WRES_ID = @WRESID 
 Delete From EPGC_RESOURCE_NTEXT_VALUES Where WRES_ID = @WRESID 
 Delete From EPGC_RESOURCE_DATE_VALUES Where WRES_ID = @WRESID
 Delete From EPG_DEPT_MANAGERS Where WRES_ID = @WRESID 
 Delete From EPG_RESOURCES Where WRES_ID = @WRESID 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_DeleteTimesheet')
begin
    Print 'Creating Stored Procedure EPG_SP_DeleteTimesheet'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_DeleteTimesheet'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_DeleteTimesheet
   @TSUID INT
AS

DELETE FROM EPG_NOTES
 WHERE NOTE_UID IN (SELECT NT_NOTE_UID FROM EPG_NOTE_THREADS WHERE (NT_CONTEXT = 1 OR NT_CONTEXT = 2 OR NT_CONTEXT = 3 OR NT_CONTEXT = 6)
    AND NT_INDEX_1 = @TSUID)

DELETE FROM EPG_NOTE_THREADS
 WHERE (NT_CONTEXT = 1 OR NT_CONTEXT = 2 OR NT_CONTEXT = 3 OR NT_CONTEXT = 6)
    AND NT_INDEX_1 = @TSUID

DELETE FROM EPG_TS_ADJUSTMENTS
 WHERE ADJ_UID IN (SELECT ADJ_UID FROM EPG_TS_ADJUSTMENTHOURS WHERE TS_UID = @TSUID)

DELETE FROM EPG_TS_ADJUSTMENTHOURS
 WHERE TS_UID = @TSUID

DELETE FROM EPG_TS_PROGRESS
 WHERE TS_UID = @TSUID

DELETE FROM EPG_TS_ACTUALHOURS
 WHERE CHG_UID IN (SELECT CHG_UID FROM EPG_TS_CHARGES WHERE TS_UID = @TSUID)

DELETE FROM EPG_TS_CATEGORY_VALUES
 WHERE CAT_CHG_UID IN (SELECT CHG_UID FROM EPG_TS_CHARGES WHERE TS_UID = @TSUID)

DELETE FROM EPG_TS_CHARGES
 WHERE TS_UID = @TSUID

DELETE FROM EPG_TS_TIMESHEETS
 WHERE TS_UID = @TSUID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_GetCTSecurity')
begin
    Print 'Creating Stored Procedure EPG_SP_GetCTSecurity'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_GetCTSecurity'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_GetCTSecurity
AS
 Select CT_NAME,GROUP_NAME,DS_UID,ds.GROUP_ID,DS_READ,DS_EDIT
  From EPGP_DATA_SECURITY ds
  Inner Join EPGP_COST_TYPES ct on ds.DS_UID = ct.CT_ID
  Inner Join EPG_GROUPS sg on ds.GROUP_ID = sg.GROUP_ID
  Where DS_CONTEXT=2
  Order By CT_NAME,GROUP_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_GetLastAutonumber')
begin
    Print 'Creating Stored Procedure EPG_SP_GetLastAutonumber'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_GetLastAutonumber'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_GetLastAutonumber
AS
select @@IDENTITY as ''AutoNumber'' RETURN
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_GetModelSecurity')
begin
    Print 'Creating Stored Procedure EPG_SP_GetModelSecurity'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_GetModelSecurity'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_GetModelSecurity
  @ModelUID INT
AS
 Select GROUP_NAME,s.GROUP_ID,MODEL_VERSION_UID,VIEW_PERMISSION,EDIT_PERMISSION
  From EPGP_MODEL_GROUP_SECURITY s
  Inner Join EPG_GROUPS g on s.GROUP_ID = g.GROUP_ID
  Where MODEL_UID=@ModelUID
  Order By MODEL_VERSION_UID,GROUP_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_GetNonWorkByPeriod')
begin
    Print 'Creating Stored Procedure EPG_SP_GetNonWorkByPeriod'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_GetNonWorkByPeriod'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_GetNonWorkByPeriod
   @CalID INT,
   @FirstPeriodID INT,
   @LastPeriodID INT,
   @sList NTEXT
AS
 SELECT NWI_ID,PRD_ID,WRES_ID,(SUM(NWH_HOURS)/100) as Hours
  FROM EPG_PERIODS
  INNER JOIN EPG_NONWORK_HOURS ON (NWH_DATE >= PRD_START_DATE and NWH_DATE <= PRD_FINISH_DATE)
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_ID=LT.TokenVal 
  WHERE CB_ID = @CalID AND PRD_ID >= @FirstPeriodID AND PRD_ID <= @LastPeriodID
 GROUP BY PRD_ID,WRES_ID,NWI_ID
 ORDER BY WRES_ID,PRD_ID,NWI_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_GetNonWorkItemNames')
begin
    Print 'Creating Stored Procedure EPG_SP_GetNonWorkItemNames'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_GetNonWorkItemNames'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_GetNonWorkItemNames
   @sList NTEXT
AS
 SELECT NWI_ID,NWI_NAME
  FROM EPG_NONWORK_ITEMS
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on NWI_ID=LT.TokenVal 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_GetPItemSecurity')
begin
    Print 'Creating Stored Procedure EPG_SP_GetPItemSecurity'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_GetPItemSecurity'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_GetPItemSecurity
AS
 Select GROUP_NAME,DS_UID,ds.GROUP_ID
  From EPGP_DATA_SECURITY ds
  Inner Join EPG_GROUPS sg on ds.GROUP_ID = sg.GROUP_ID
  Where DS_CONTEXT=3
  Order By DS_UID,GROUP_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_GetResourcesUserCanView')
begin
    Print 'Creating Stored Procedure EPG_SP_GetResourcesUserCanView'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_GetResourcesUserCanView'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_GetResourcesUserCanView
  @WResID int
AS
	if (@WResID = 1)
		BEGIN
			SELECT DISTINCT WRES_ID FROM EPG_RESOURCES WHERE WRES_DEPT is not null OR WRES_RP_DEPT is not null
		END
	else  
		BEGIN
			SELECT DISTINCT WRES_ID FROM EPG_RESOURCES 
			 WHERE WRES_DEPT IN (SELECT CODE_UID FROM EPG_TS_APPROVERS 
								  WHERE WRES_ID = @WResID)
			UNION
			SELECT WRES_ID FROM EPG_RESOURCES 
			 WHERE WRES_RP_DEPT IN (SELECT CODE_UID FROM EPG_RES_MANAGERS 
								  WHERE WRES_ID = @WResID)
			ORDER BY WRES_ID
		END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_GetViewSecurity')
begin
    Print 'Creating Stored Procedure EPG_SP_GetViewSecurity'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_GetViewSecurity'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_GetViewSecurity
AS
 Select VIEW_TYPE,VIEW_SUBTYPE,VIEW_NAME,GROUP_NAME,DS_UID,vs.GROUP_ID
  From EPGP_DATA_SECURITY vs
  Inner Join EPGT_VIEW_DISPLAY vd on vs.DS_UID = vd.VIEW_UID
  Inner Join EPG_GROUPS sg on vs.GROUP_ID = sg.GROUP_ID
  Where DS_CONTEXT=1
  Order By VIEW_TYPE,VIEW_SUBTYPE,VIEW_NAME,GROUP_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_InsertChunk')
begin
    Print 'Creating Stored Procedure EPG_SP_InsertChunk'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_InsertChunk'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_InsertChunk
   @WresID INT,
   @ChunkID INT,
   @Chunk NTEXT
AS
Insert into EPG_CHUNKER (WRES_ID,CHUNK_ID,CHUNK_DATE,CHUNK)
 VALUES(@WresID,@ChunkID,GETDATE(),@Chunk)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_InsertNewCTStatus')
begin
    Print 'Creating Stored Procedure EPG_SP_InsertNewCTStatus'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_InsertNewCTStatus'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_InsertNewCTStatus
   @CTID INT,
   @CBID INT,
   @PROJID INT,
   @RPCBID INT
AS
Delete from EPGP_PROJECT_CT_STATUS where CB_ID=@CBID And CT_ID=@CTID And (PROJECT_ID=@PROJID Or @PROJID=0)
Insert into EPGP_PROJECT_CT_STATUS (CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_STATUS)
 Select @CBID,CT_ID,PROJECT_ID,BC_UID,BC_STATUS from EPGP_PROJECT_CT_STATUS Where CB_ID=@RPCBID And CT_ID=@CTID And (PROJECT_ID=@PROJID Or @PROJID=0)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_LogicallyDeleteTimesheetsByPeriod')
begin
    Print 'Creating Stored Procedure EPG_SP_LogicallyDeleteTimesheetsByPeriod'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_LogicallyDeleteTimesheetsByPeriod'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_LogicallyDeleteTimesheetsByPeriod
  @PeriodID INT
AS
UPDATE EPG_TS_TIMESHEETS SET TS_DELETED = 1 WHERE PRD_ID = @PeriodID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_PCTCostValues')
begin
    Print 'Creating Stored Procedure EPG_SP_PCTCostValues'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_PCTCostValues'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_PCTCostValues
   @ProjID INT,
   @CBID INT,
   @CTID INT 
AS
 Select BC_UID,BD_PERIOD,PRD_START_DATE,BD_VALUE,BD_COST
  From EPGP_COST_VALUES cv
  Inner Join EPG_PERIODS p On cv.CB_ID = p.CB_ID And cv.BD_PERIOD = p.PRD_ID
  Where cv.CB_ID = @CBID And CT_ID = @CTID And PROJECT_ID=@ProjID
  Order by BC_UID,BD_PERIOD
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_PCTDetailValues')
begin
    Print 'Creating Stored Procedure EPG_SP_PCTDetailValues'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_PCTDetailValues'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_PCTDetailValues
   @ProjID INT,
   @CBID INT,
   @CTID INT 
AS
 Select BC_UID,BC_SEQ,BD_PERIOD,PRD_START_DATE,BD_VALUE,BD_COST
  From EPGP_DETAIL_VALUES cv
  Inner Join EPG_PERIODS p On cv.CB_ID = p.CB_ID And cv.BD_PERIOD = p.PRD_ID
  Where cv.CB_ID = @CBID And CT_ID = @CTID And PROJECT_ID=@ProjID
  Order by BC_UID,BC_SEQ,BD_PERIOD
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_PCTReadCommitments')
begin
    Print 'Creating Stored Procedure EPG_SP_PCTReadCommitments'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_PCTReadCommitments'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_PCTReadCommitments
   @MODE INT,
   @ProjID INT
AS
 If (@MODE=0)
   BEGIN
 Select CMT_DEPT,CMT_RT_UID,CMT_RATETYPE_UID,CMT_MAJORCATEGORY,WRES_ID,BC_UID,PRD_ID,CMH_HOURS,CMH_REVENUES
  From EPG_RESOURCEPLANS_HOURS ch
  Inner Join EPG_RESOURCEPLANS cm On ch.CMT_UID=cm.CMT_UID And(CMT_STATUS=256 and RP_ACTIVE_COMMITMENT=1 and CMH_PENDING=0)
  Where PROJECT_ID=@ProjID
  Order by CMT_DEPT,CMT_RATETYPE_UID,BC_UID,PRD_ID
   END
 Else
   BEGIN  
 Select CMT_DEPT,CMT_RT_UID,CMT_RATETYPE_UID,CMT_MAJORCATEGORY,WRES_ID,BC_UID,PRD_ID,CMH_HOURS,CMH_REVENUES,cv.*
  From EPG_RESOURCEPLANS_HOURS ch
  Inner Join EPG_RESOURCEPLANS cm On ch.CMT_UID=cm.CMT_UID And(CMT_STATUS=256 and RP_ACTIVE_COMMITMENT=1 and CMH_PENDING=0)
  Left Join EPGP_RP_CATEGORY_VALUES cv On cv.CAT_CMT_UID = cm.CMT_UID
  Where PROJECT_ID=@ProjID
  Order by CMT_DEPT,CMT_RATETYPE_UID,BC_UID,PRD_ID
   END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_PCTReadPSWork')
begin
    Print 'Creating Stored Procedure EPG_SP_PCTReadPSWork'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_PCTReadPSWork'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_PCTReadPSWork
   @ProjID INT
AS
/* changed in V45 to use Scheduled Work uploaded from EPM-Live rather than MSP
DECLARE @CurrentVersion INT
SELECT @CurrentVersion = ADM_DEFAULT_PROJ_VERSION_ID FROM EPG_ADMIN
Select PROJECT_ID,WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK
  From EPGX_PROJECT_TSWORK w
  Inner Join EPGX_PROJECT_VERSIONS v On v.WPROJ_ID=w.WPROJ_ID And VERSION_ID=@CurrentVersion
  Where WRES_ID > 0 And PROJECT_ID=@ProjID
  Order by WRES_ID,TSWORK_DATE
  */
 Select PROJECT_ID,WRES_ID,PW_MAJORCATEGORY as TSWORK_MAJORCATEGORY,PW_DATE as TSWORK_DATE,PW_WORK as TSWORK_WORK
  From EPGP_PI_WORK1
  Where WRES_ID > 0 And PROJECT_ID=@ProjID
  union all
  Select PROJECT_ID,WRES_ID,PW_MAJORCATEGORY as TSWORK_MAJORCATEGORY,PW_DATE as TSWORK_DATE,PW_WORK as TSWORK_WORK
  From EPGP_PI_WORK2
  Where WRES_ID > 0 And PROJECT_ID=@ProjID
  Order by WRES_ID,PW_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_PCTReadPSWork_EC')
begin
    Print 'Creating Stored Procedure EPG_SP_PCTReadPSWork_EC'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_PCTReadPSWork_EC'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_PCTReadPSWork_EC
   @ProjID INT
AS
Select PROJECT_ID,WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK
  From EPGP_PROJECT_TSWORK
  Where WRES_ID > 0 And PROJECT_ID=@ProjID
  Order by WRES_ID,TSWORK_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_PCTReadTSValues')
begin
    Print 'Creating Stored Procedure EPG_SP_PCTReadTSValues'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_PCTReadTSValues'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_PCTReadTSValues
   @MODE INT,
   @ProjID INT
AS
 If (@MODE=0)
   BEGIN
 Select WRES_ID,CHG_MAJORCATEGORY,PROJECT_ID,AH_DATE,AH_NORMALHOURS, AH_OVERTIMEHOURS 
  From EPG_TS_ACTUALHOURS ah
  Inner Join EPG_TS_CHARGES ch on ch.CHG_UID = ah.CHG_UID
  Inner Join EPG_TS_TIMESHEETS ts on ts.TS_UID = ch.TS_UID
  Where ch.PROJECT_ID=@ProjID  
   END
 Else
   BEGIN  
 Select WRES_ID,CHG_MAJORCATEGORY,PROJECT_ID,AH_DATE,AH_NORMALHOURS, AH_OVERTIMEHOURS, cv.* 
  From EPG_TS_ACTUALHOURS ah
  Inner Join EPG_TS_CHARGES ch on ch.CHG_UID = ah.CHG_UID
  Inner Join EPG_TS_TIMESHEETS ts on ts.TS_UID = ch.TS_UID
  Left Join EPG_TS_CATEGORY_VALUES cv On cv.CAT_CHG_UID = ch.CHG_UID
  Where ch.PROJECT_ID=@ProjID  
   END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_PCTReadWEActuals')
begin
    Print 'Creating Stored Procedure EPG_SP_PCTReadWEActuals'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_PCTReadWEActuals'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_PCTReadWEActuals
   @ProjID INT
AS
 Select WRES_ID,WEC_MAJORCATEGORY,PROJECT_ID,WEH_DATE,WEH_NORMALHOURS, WEH_OVERTIMEHOURS 
  From EPG_WE_ACTUALHOURS ah
  Inner Join EPG_WE_CHARGES ch on ch.WEC_CHG_UID = ah.WEH_CHG_UID
  Where ch.PROJECT_ID=@ProjID  
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_PCTReadWIWork')
begin
    Print 'Creating Stored Procedure EPG_SP_PCTReadWIWork'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_PCTReadWIWork'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_PCTReadWIWork
   @ProjID INT
AS
 Select WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,TSWORK_REMAINING_WORK
  From EPGP_PI_WORKITEM_TSWORK
  Where PROJECT_ID=@ProjID
  Order by WRES_ID,TSWORK_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_PSWorkPIs')
begin
    Print 'Creating Stored Procedure EPG_SP_PSWorkPIs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_PSWorkPIs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_PSWorkPIs
   @sRList NTEXT
AS
DECLARE @CurrentVersion INT
SELECT @CurrentVersion = ADM_DEFAULT_PROJ_VERSION_ID FROM EPG_ADMIN
Select Distinct v.PROJECT_ID  
 From EPGX_PROJECT_TSWORK w
 Inner Join EPGX_PROJECT_VERSIONS v On v.WPROJ_ID=w.WPROJ_ID And VERSION_ID=@CurrentVersion
 Inner Join EPGP_PROJECTS p On p.PROJECT_ID=v.PROJECT_ID And PROJECT_MARKED_DELETION = 0
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RateTypeUsage')
begin
    Print 'Creating Stored Procedure EPG_SP_RateTypeUsage'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RateTypeUsage'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_RateTypeUsage
   @RateTypeUID INT
AS
 Declare @InUse int
 Declare @RowCount int

SELECT @RowCount = COUNT(*) 
  FROM EPG_RESOURCEPLANS
 WHERE CMT_RATETYPE_UID = @RateTypeUID

SET @InUse = 0
if (@RowCount > 0) SET @InUse = 1

SELECT @InUse as InUse
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadActualWork')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadActualWork'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadActualWork'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadActualWork
/*  Read Actual Work, for now and perhaps for ever just reading WE Actuals
     If need UNION with PfE Actuals then use technique like EPG_SP_ReadPlannedWorkByPeriod_NAX because software expects grouped rows

Public Enum ResCenterRequest (see also EPG_SP_ReadScheduledWork)
    ResourceValuesForPIs = 3  - for one or more PIs - all resources 
    ResourceValuesForResources = 4  - for one or more resources - all PIs
*/
   @Mode INT,
   @FromPeriodID INT,
   @CalID INT,
   @ToPeriodID INT,
   @sList NTEXT,
   @sRList NTEXT
AS 
if (@Mode = 4) 
 Begin
 Select PROJECT_ID,WRES_ID,WEC_MAJORCATEGORY,PRD_ID,Sum(WEH_NORMALHOURS+WEH_OVERTIMEHOURS) As Hours
   From EPG_WE_CHARGES c
   INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on c.WRES_ID=LT2.TokenVal
   Join EPG_WE_ACTUALHOURS w On w.WEH_CHG_UID=c.WEC_CHG_UID
   JOIN EPG_PERIODS PRD on PRD.CB_ID=@CalID and (w.WEH_DATE >= PRD.PRD_START_DATE and w.WEH_DATE <= PRD.PRD_FINISH_DATE)
	WHERE (PRD.PRD_ID >= @FromPeriodID And PRD.PRD_ID <= @ToPeriodID) AND WRES_ID > 0
	GROUP BY c.PROJECT_ID,c.WRES_ID,c.WEC_MAJORCATEGORY,PRD.PRD_ID
	ORDER BY c.PROJECT_ID,c.WRES_ID,c.WEC_MAJORCATEGORY,PRD.PRD_ID
 End 
 else if (@Mode = 3)
 Begin
 Select PROJECT_ID,WRES_ID,WEC_MAJORCATEGORY,PRD_ID,Sum(WEH_NORMALHOURS+WEH_OVERTIMEHOURS) As Hours
   From EPG_WE_CHARGES c
   INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT2 on c.PROJECT_ID=LT2.TokenVal
   Join EPG_WE_ACTUALHOURS w On w.WEH_CHG_UID=c.WEC_CHG_UID
   JOIN EPG_PERIODS PRD on PRD.CB_ID=@CalID and (w.WEH_DATE >= PRD.PRD_START_DATE and w.WEH_DATE <= PRD.PRD_FINISH_DATE)
	WHERE (PRD.PRD_ID >= @FromPeriodID And PRD.PRD_ID <= @ToPeriodID) AND WRES_ID > 0
	GROUP BY c.PROJECT_ID,c.WRES_ID,c.WEC_MAJORCATEGORY,PRD.PRD_ID
	ORDER BY c.PROJECT_ID,c.WRES_ID,c.WEC_MAJORCATEGORY,PRD.PRD_ID
  End
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadAdmin')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadAdmin'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadAdmin'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadAdmin
AS
SELECT * 
  FROM EPG_ADMIN
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadAdminRates')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadAdminRates'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadAdminRates'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadAdminRates
AS
SELECT distinct EPG_RATES.RT_UID,RT_NAME,RT_ID,RT_LEVEL,  
STUFF((SELECT '','' + convert(nvarchar(MAX), RT_EFFECTIVE_DATE ,102) + ''::'' + convert(nvarchar(MAX), RT_RATE )
FROM EPG_RATE_VALUES 
WHERE EPG_RATES.RT_UID = EPG_RATE_VALUES.RT_UID
GROUP BY RT_EFFECTIVE_DATE, RT_RATE
FOR XML PATH('''')) , 1, 1, '''') as rates, 
STUFF((SELECT '','' + convert(nvarchar(MAX), EPGP_COST_RATES.WRES_ID )
FROM EPGP_COST_RATES
JOIN EPG_RESOURCES ON EPGP_COST_RATES.WRES_ID = EPG_RESOURCES.WRES_ID
WHERE EPG_RATES.RT_UID = EPGP_COST_RATES.RT_UID
GROUP BY EPGP_COST_RATES.WRES_ID
FOR XML PATH('''')) , 1, 1, '''') as wres_ids, 
STUFF((SELECT '','' + convert(nvarchar(MAX), EPG_RESOURCES.RES_NAME )
FROM EPGP_COST_RATES
JOIN EPG_RESOURCES ON EPGP_COST_RATES.WRES_ID = EPG_RESOURCES.WRES_ID
WHERE EPG_RATES.RT_UID = EPGP_COST_RATES.RT_UID
GROUP BY EPG_RESOURCES.RES_NAME
FOR XML PATH('''')) , 1, 1, '''') as res_names
FROM EPG_RATES
ORDER BY RT_ID,RT_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadApprovalProjects')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadApprovalProjects'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadApprovalProjects'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadApprovalProjects
  @ApproverWResID int,
  @PeriodID int
AS
SELECT EP.PROJECT_ID,WP.WPROJ_ID,WP.PV_PROJECT_NAME,WR.RES_NAME,WR.WRES_ID,CH.TS_UID,CH.CHG_UID,TS.PRD_ID,TS_SUBMITTED,TS_DEPT_STATUS,TS_MANAGER_LOCKED,TS_TIMESTAMP,TSD_STATUS,WR2.WRES_ID as ProjManagerWResID,WR2.RES_NAME as ProjManagerName
FROM EPGX_PROJECT_VERSIONS WP
LEFT JOIN EPG_TS_CHARGES CH ON (WP.WPROJ_ID = CH.WPROJ_ID AND CH.TS_UID IN (SELECT TS_UID FROM EPG_TS_TIMESHEETS WHERE PRD_ID = @PeriodID))
LEFT JOIN EPG_TS_TIMESHEETS TS ON (CH.TS_UID = TS.TS_UID)
LEFT JOIN EPG_RESOURCES WR ON (TS.WRES_ID = WR.WRES_ID)
LEFT JOIN EPG_TS_DEPTS on (TS.PRD_ID = TSD_PRD_ID and TS_DEPT_UID = TSD_DEPT_UID)
LEFT JOIN EPGP_PROJECTS EP ON (EP.PROJECT_ID = WP.PROJECT_ID)
LEFT JOIN EPG_RESOURCES WR2 on (WR2.WRES_ID = EP.PROJECT_PLAN_OWNER)
WHERE (EP.PROJECT_PLAN_OWNER = @ApproverWResID 
     OR WP.WPROJ_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 3 AND SURR_WRES_ID = @ApproverWResID))
  AND WP.VERSION_ID = (SELECT ADM_TS_PROJ_VERSION_ID FROM EPG_ADMIN)
ORDER BY WP.PV_PROJECT_NAME,WR.WRES_ID

SELECT EP.*,WR.RES_NAME,WR.WRES_ID,CH.TS_UID,CH.CHG_UID,TS.PRD_ID,TS_SUBMITTED,TS_DEPT_STATUS,TS_MANAGER_LOCKED,TS_TIMESTAMP,TSD_STATUS,WR2.WRES_ID as ProjManagerWResID,WR2.RES_NAME as ProjManagerName
FROM EPGP_PROJECTS EP
LEFT JOIN EPG_TS_CHARGES CH ON (EP.PROJECT_ID = CH.PROJECT_ID AND CH.TS_UID IN (SELECT TS_UID FROM EPG_TS_TIMESHEETS WHERE PRD_ID = @PeriodID))
LEFT JOIN EPG_TS_TIMESHEETS TS ON (CH.TS_UID = TS.TS_UID)
LEFT JOIN EPG_RESOURCES WR ON (TS.WRES_ID = WR.WRES_ID)
LEFT JOIN EPG_TS_DEPTS on (TS.PRD_ID = TSD_PRD_ID and TS_DEPT_UID = TSD_DEPT_UID)
LEFT JOIN EPG_RESOURCES WR2 on (WR2.WRES_ID = EP.PROJECT_MANAGER)
WHERE (EP.PROJECT_MANAGER = @ApproverWResID 
     OR EP.PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 4 AND SURR_WRES_ID = @ApproverWResID))
ORDER BY EP.PROJECT_NAME,WR.WRES_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadApprovalResources')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadApprovalResources'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadApprovalResources'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadApprovalResources
  @SelectMode INT,
  @PeriodID INT,
  @sList NTEXT
AS
/* SelectMode = 0 is for closed periods where we are just interested in resources with existing timesheet for period */
/* SelectMode = 1 is for open periods additionally get valid resources without timesheet for period */
if (@SelectMode = 0)
	SELECT WR.RES_NAME,WR.WRES_ID,WRES_DEPT,TS_UID,TS_DEPT_UID,TS_DEPT_NAME,PRD_ID,TS_SUBMITTED,TS_DEPT_STATUS,TS_MANAGER_LOCKED,TS_TIMESTAMP,TS_LIMITS_STATUS
	  FROM EPG_TS_TIMESHEETS TS
	  LEFT JOIN EPG_RESOURCES WR ON (WR.WRES_ID = TS.WRES_ID)
--	 WHERE TS_DEPT_UID IN (select TokenVal from dbo.EPG_FN_ConvertListToTable(@sList)) AND PRD_ID = @PeriodID
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on TS_DEPT_UID=LT.TokenVal
	 WHERE PRD_ID = @PeriodID
	 ORDER BY WR.RES_NAME
else
	SELECT WR.RES_NAME,WR.WRES_ID,WRES_DEPT,TS_UID,TS_DEPT_UID,TS_DEPT_NAME,PRD_ID,TS_SUBMITTED,TS_DEPT_STATUS,TS_MANAGER_LOCKED,TS_TIMESTAMP,TS_LIMITS_STATUS
	  FROM EPG_TS_TIMESHEETS TS
	  LEFT JOIN EPG_RESOURCES WR ON (WR.WRES_ID = TS.WRES_ID)
--	 WHERE TS_DEPT_UID IN (select TokenVal from dbo.EPG_FN_ConvertListToTable(@sList)) AND PRD_ID = @PeriodID
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on TS_DEPT_UID=LT.TokenVal
	 WHERE PRD_ID = @PeriodID
 union
	SELECT WR.RES_NAME,WR.WRES_ID,WRES_DEPT,TS_UID,TS_DEPT_UID,TS_DEPT_NAME,PRD_ID,TS_SUBMITTED,TS_DEPT_STATUS,TS_MANAGER_LOCKED,TS_TIMESTAMP,TS_LIMITS_STATUS
	  FROM EPG_RESOURCES WR
	  LEFT JOIN EPG_TS_TIMESHEETS TS ON (WR.WRES_ID = TS.WRES_ID AND PRD_ID = @PeriodID)
--	 WHERE WRES_CAN_LOGIN = 1 AND WRES_TS_INCLUDE = 1 AND (WRES_DEPT IN (select TokenVal from dbo.EPG_FN_ConvertListToTable(@sList))) AND TS_UID is null
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_DEPT=LT.TokenVal
	 WHERE WRES_CAN_LOGIN = 1 AND WRES_TS_INCLUDE = 1 AND TS_UID is null
	 ORDER BY WR.RES_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadAvailCostFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadAvailCostFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadAvailCostFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadAvailCostFields
AS
   SELECT FL.FIELD_ID,FIELD_NAME,FA_DESC,FA_NAME as DefinedName,FA_LOOKUPONLY,FA_LOOKUP_UID,FA_LEAFONLY,FA_USEFULLNAME,FIELD_SEQUENCE,LOOKUP_NAME
	FROM EPGT_FIELDS FL 
	LEFT JOIN EPGP_FIELD_ATTRIBS FT ON (FL.FIELD_ID = FT.FA_FIELD_ID)
	LEFT JOIN EPGP_LOOKUP_TABLES LT ON (FT.FA_LOOKUP_UID = LT.LOOKUP_UID)
	Where FL.FIELD_ID > 11800 and FL.FIELD_ID < 11820
	ORDER BY FIELD_SEQUENCE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadAvailPortCFs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadAvailPortCFs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadAvailPortCFs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadAvailPortCFs
AS
  Select FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID 
     From EPGC_FIELD_ATTRIBS
     Where (FA_TABLE_ID>200 And FA_TABLE_ID<250) or (FA_TABLE_ID>300 And FA_TABLE_ID<350)
     Order by (FA_TABLE_ID/100),FA_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadAvailPortFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadAvailPortFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadAvailPortFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadAvailPortFields
AS
 SELECT FIELD_ID,FIELD_NAME,FIELD_SEQUENCE,FIELD_FORMAT,FIELD_PORT_FORMAT,FIELD_IN_PORT_REGISTER
	FROM EPGT_FIELDS 
	WHERE FIELD_IN_PORT_REGISTER>0
    Order By FIELD_SEQUENCE	
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadAvailResFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadAvailResFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadAvailResFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadAvailResFields
AS
   SELECT FIELD_ID,FIELD_NAME,FIELD_SEQUENCE,FIELD_FORMAT
	FROM EPGT_RES_FIELDS Where FIELD_DISPLAY=1 
	ORDER BY FIELD_SEQUENCE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadAvailViewCFs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadAvailViewCFs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadAvailViewCFs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadAvailViewCFs
  @VIEWTYPE INT,
  @VIEWSUBTYPE INT
AS
BEGIN
if (@VIEWTYPE = 3)
  begin
    Select FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_LOOKUP_UID,FA_USEFULLNAME
     From EPGC_FIELD_ATTRIBS
     Where FA_TABLE_ID>200 And FA_TABLE_ID<450 And FA_TABLE_ID<>251
     Order by (FA_TABLE_ID/100),FA_NAME
	RETURN
  end
if (@VIEWTYPE = 1)
  begin
	RETURN
  end
if (@VIEWTYPE = 2 and @VIEWSUBTYPE  = 0)
  begin
    Select FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_LOOKUP_UID,FA_USEFULLNAME 
     From EPGC_FIELD_ATTRIBS
     Where (FA_TABLE_ID>200 And FA_TABLE_ID<400 And FA_TABLE_ID<>251)  Or
         (FA_TABLE_ID>800 And FA_TABLE_ID<850)
     Order by (FA_TABLE_ID/100),FA_NAME
	RETURN
  end	
if (@VIEWTYPE = 2 and @VIEWSUBTYPE  > 0)
  begin
    Select FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_LOOKUP_UID,FA_USEFULLNAME 
     From EPGC_FIELD_ATTRIBS
     Where (FA_TABLE_ID>200 And FA_TABLE_ID<400 And FA_TABLE_ID<>251)
     Order by (FA_TABLE_ID/100),FA_NAME
	RETURN
  end	
if (@VIEWTYPE = 4)
  begin
	RETURN
  end
if (@VIEWTYPE = 103)
  begin
    Select FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_LOOKUP_UID,FA_USEFULLNAME 
     From EPGC_FIELD_ATTRIBS
     Where FA_TABLE_ID>200 And FA_TABLE_ID<400 And FA_TABLE_ID<>251
     Order by (FA_TABLE_ID/100),FA_NAME
	RETURN
  end
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadAvailViewFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadAvailViewFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadAvailViewFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadAvailViewFields
  @VIEWTYPE INT,
  @VIEWSUBTYPE INT
AS
BEGIN
if (@VIEWTYPE = 3)
  begin
	SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_SUMMARYTYPE,FIELD_SORTBY,FIELD_FILTERBY,FIELD_SEQUENCE,FIELD_TABLE_ID,FIELD_TABLE_ID_1,FIELD_FORMAT,FIELD_NAME_SQL,FIELD_IN_PORT_REGISTER as Fieldtype
	FROM EPGT_FIELDS
	WHERE FIELD_IN_PORT_REGISTER > 0
	ORDER BY FIELD_SEQUENCE
	RETURN
  end
if (@VIEWTYPE = 2 and @VIEWSUBTYPE  = 0)
  begin
	SELECT FIELD_ID,FIELD_NAME,FIELD_SUMMARYTYPE,FIELD_SORTBY,FIELD_FILTERBY,FIELD_SEQUENCE,FIELD_TABLE_ID,FIELD_TABLE_ID_1,FIELD_FORMAT,FIELD_NAME_SQL,FIELD_IN_PORT_REGISTER as Fieldtype
	FROM EPGT_FIELDS
	WHERE FIELD_IN_PROJ_BROWSER > 0
	ORDER BY FIELD_SEQUENCE
	RETURN
  end	
if (@VIEWTYPE = 2 and @VIEWSUBTYPE  > 0)
  begin
	SELECT FIELD_ID,FIELD_NAME,FIELD_SUMMARYTYPE,FIELD_SORTBY,FIELD_FILTERBY,FIELD_SEQUENCE,FIELD_TABLE_ID,FIELD_TABLE_ID_1,FIELD_FORMAT,FIELD_NAME_SQL,FIELD_IN_PORT_REGISTER as Fieldtype
	FROM EPGT_FIELDS
	WHERE FIELD_IN_PROJLIST_BROWSER > 0
	ORDER BY FIELD_SEQUENCE
	RETURN
  end	
if (@VIEWTYPE = 4)
  begin
	SELECT FA_FIELD_ID,FA_NAME 
	FROM EPGC_FIELD_ATTRIBS
	WHERE FA_FORMAT=8 and FA_TABLE_ID=203
	ORDER BY FA_NAME
	RETURN
  end
if (@VIEWTYPE = 103)
  begin
    SELECT FIELD_ID,FIELD_NAME,FIELD_SUMMARYTYPE,FIELD_SORTBY,FIELD_FILTERBY,FIELD_SEQUENCE,FIELD_TABLE_ID,FIELD_TABLE_ID_1,FIELD_FORMAT,FIELD_NAME_SQL,FIELD_IN_PORT_REGISTER as Fieldtype
	FROM EPGT_FIELDS
    WHERE FIELD_IN_PORT_REGISTER > 0 Or FIELD_IN_PROJ_BROWSER = 1 Or FIELD_IN_PROJLIST_BROWSER > 0
	ORDER BY FIELD_SEQUENCE
RETURN
  end   
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadAvailWSSFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadAvailWSSFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadAvailWSSFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadAvailWSSFields
   @ListID int
AS
   SELECT FIELD_ID,FIELD_NAME,WSS_NAME,WSS_LIST_ID,WSS_FIELD_TP1,FIELD_SEQUENCE,FIELD_FORMAT,FIELD_IN_PROJLIST_BROWSER
	FROM EPGT_FIELDS FL 
	LEFT JOIN EPGP_WSS_FIELD_ATTRIBS FA ON (FL.FIELD_ID = FA.WSS_FIELD_ID) And (WSS_LIST_ID = 0 Or WSS_LIST_ID = @ListID)
	WHERE FIELD_IN_PROJLIST_BROWSER > 0
	ORDER BY FIELD_SEQUENCE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCalendar')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCalendar'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCalendar'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCalendar
  @CalID INT
AS
Select * From EPGP_COST_BREAKDOWNS
   Where CB_ID=@CalID			
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCalendarFTEs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCalendarFTEs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCalendarFTEs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCalendarFTEs
  @CB_ID INT
AS
DECLARE @cols AS NVARCHAR(MAX), @colsas AS NVARCHAR(MAX), @query  AS NVARCHAR(MAX);
select @cols = STUFF((SELECT  '','' 
                        + QUOTENAME(convert(nvarchar,PRD_ID)) 
                    from EPG_PERIODS where CB_ID = @CB_ID order by PRD_ID
            FOR XML PATH(''''), TYPE
            ).value(''.'', ''NVARCHAR(MAX)'') 
        ,1,1,''''); 
select @colsas = STUFF((SELECT  '','' 
                        + QUOTENAME(convert(nvarchar,PRD_ID)) + '' as P'' + convert(nvarchar,PRD_ID) 
                    from EPG_PERIODS where CB_ID = @CB_ID order by PRD_ID
            FOR XML PATH(''''), TYPE
            ).value(''.'', ''NVARCHAR(MAX)'') 
        ,1,1,''''); 
set @query = 
''declare @t as table (BC_UID int,BC_NAME nvarchar(255),BC_ID int,BC_LEVEL int,BA_PRD_ID int,BA_FTE_CONV int); '' +
''insert into @t select BC_UID,BC_NAME,BC_ID,BC_LEVEL,BA_PRD_ID,(BA_FTE_CONV)/100 as BA_FTE_CONV from EPGP_COST_CATEGORIES
left join EPGP_COST_BREAKDOWN_ATTRIBS on (BA_BC_UID = BC_UID AND EPGP_COST_BREAKDOWN_ATTRIBS.CB_ID = '' + convert(nvarchar,@CB_ID) + '')
group by BC_ID, BC_LEVEL,BA_PRD_ID, BC_NAME, BC_UID, BA_FTE_CONV
order by BC_ID, BC_LEVEL,BA_PRD_ID, BC_NAME, BC_UID, BA_FTE_CONV; '' +
''select BC_NAME,BC_UID,BC_ID,BC_LEVEL,'' + @colsas + '' from @t pivot (max(BA_FTE_CONV) for BA_PRD_ID in ('' + @cols + '')) pivotT ORDER BY BC_ID''
execute(@query)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCapacityTargets')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCapacityTargets'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCapacityTargets'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCapacityTargets
  @sList NTEXT
AS
SELECT CS_ID,CS_NAME,DEPT_UID, CS_ROLE_BASED
  From EPGP_CAPACITY_SETS
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on DEPT_UID=LT.TokenVal 
  Order by DEPT_UID,CS_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCapacityValues')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCapacityValues'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCapacityValues'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCapacityValues
  @CalID int,
  @TargetID int,
  @FromPeriodID int,
  @ToPeriodID int,
  @sList NTEXT
AS
if (@TargetID <> 0)
 Begin
	SELECT CS_ID,BD_PERIOD,DEPT_UID,ROLE_ID,CS_AVAIL,CS_FTES
	From EPGP_CAPACITY_SETVALUES
	INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on DEPT_UID=LT.TokenVal 
	WHERE CB_ID = @CalID AND CS_ID = @TargetID
 End
else
 Begin
	SELECT CS_ID,BD_PERIOD,DEPT_UID,ROLE_ID,CS_AVAIL,CS_FTES
	From EPGP_CAPACITY_SETVALUES
	INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on DEPT_UID=LT.TokenVal
	WHERE CB_ID = @CalID AND BD_PERIOD >= @FromPeriodID AND BD_PERIOD <= @ToPeriodID
 End
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCategories')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCategories'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCategories'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCategories
AS
   SELECT *	FROM EPGP_CATEGORIES 
	ORDER BY CA_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCategoriesForCT')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCategoriesForCT'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCategoriesForCT'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCategoriesForCT
   @CTID INT
AS
   SELECT cc.BC_UID,BC_ROLE,BC_ID,BC_LEVEL,BC_NAME,BC_UOM,CT_ID
	FROM EPGP_COST_CATEGORIES cc
	Left Join EPGP_AVAIL_CATEGORIES ac on ac.BC_UID = cc.BC_UID and ac.CT_ID = @CTID
	ORDER BY BC_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCategory')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCategory'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCategory'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCategory
  @FieldID INT
AS
SELECT FIELD_ID,FIELD_NAME,FIELD_FORMAT,FA.*
  FROM EPGT_FIELDS
  left join EPGP_FIELD_ATTRIBS FA on (FIELD_ID = FA_FIELD_ID)
 WHERE FIELD_ID = @FieldID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCategoryItems')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCategoryItems'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCategoryItems'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCategoryItems
AS
   SELECT *	FROM EPGP_COST_CATEGORIES 
	ORDER BY BC_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCategoryUsedCTs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCategoryUsedCTs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCategoryUsedCTs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCategoryUsedCTs
  @BCUID INT
AS
Select  Distinct Top 6 ''Category for Cost Types'' as Type,CT_NAME as Name
 From EPGP_AVAIL_CATEGORIES ac
 Inner Join EPGP_COST_TYPES ct On ct.CT_ID = ac.CT_ID
 Where ac.BC_UID in (Select BC_UID From EPGP_COST_CATEGORIES Where CA_UID=@BCUID)
      UNION
Select Distinct Top 6 ''Role for Resources'' as Type,
	case When (xr.WRES_ID>0) Then RES_NAME 
         When (xr.WRES_ID=0) Then ''Default''
         When (xr.WRES_ID=-1) Then ''Task Only Work''
         When (xr.WRES_ID=-2) Then ''Fixed Cost''
         When (xr.WRES_ID=-3) Then ''Local Labor''
         When (xr.WRES_ID=-4) Then ''Local Material''
         Else ''Unknown'' End as Name
   From EPGP_COST_XREF xr
   Left Join EPG_RESOURCES wr on wr.WRES_ID = xr.WRES_ID
   Where BC_UID = @BCUID
      UNION
Select Distinct Top 6 ''Resource Plans for PIs'' as Type,PROJECT_NAME as Name
   From EPG_RESOURCEPLANS cm
   Left Join EPGP_PROJECTS pr On pr.PROJECT_ID = cm.PROJECT_ID
   Where BC_UID in (Select BC_UID From EPGP_COST_CATEGORIES Where CA_UID=@BCUID)
       Or PARENT_BC_UID in (Select BC_UID From EPGP_COST_CATEGORIES Where CA_UID=@BCUID)
      UNION
Select  Distinct Top 6 ''Category for Model Version'' as Type,MODEL_NAME as Name
 From EPGP_MODEL_COST_DETAILS d
 Inner Join EPGP_MODEL_SCENARIOS s On s.MODEL_UID = d.MODEL_UID
 Where d.BC_UID in (Select BC_UID From EPGP_COST_CATEGORIES Where CA_UID=@BCUID)
      UNION
Select  Distinct Top 6 ''Category for Model Target'' as Type,TARGET_NAME as Name
 From EPGP_MODEL_TARGET_DETAILS d
 Inner Join EPGP_MODEL_TARGETS t On t.TARGET_ID = d.TARGET_ID
 Where d.BC_UID in (Select BC_UID From EPGP_COST_CATEGORIES Where CA_UID=@BCUID)
   Order By Type, Name 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCategoryXref')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCategoryXref'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCategoryXref'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCategoryXref
AS
Select xr.WRES_ID,RES_NAME,BC_UID 
 From EPGP_COST_XREF xr
 Left Join EPG_RESOURCES wr On wr.WRES_ID = xr.WRES_ID
 Where WRES_IS_RESOURCE=1 Or xr.WRES_ID <= 0
 Order By RES_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCBAttribs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCBAttribs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCBAttribs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCBAttribs
   @CBID INT,
   @CodeID INT
AS
IF (@CodeID  < 0)
 BEGIN
SELECT BA_CODE_UID,BA_BC_UID,BA_RATETYPE_UID,BA_PRD_ID,BA_FTE_CONV,BA_RATE
  FROM EPGP_COST_BREAKDOWN_ATTRIBS
  WHERE CB_ID = @CBID
 ORDER BY BA_CODE_UID,BA_RATETYPE_UID,BA_BC_UID,BA_PRD_ID
 END
ELSE
 BEGIN
SELECT BA_BC_UID,BA_RATETYPE_UID,BA_PRD_ID,BA_FTE_CONV,BA_RATE
  FROM EPGP_COST_BREAKDOWN_ATTRIBS
  WHERE CB_ID = @CBID And BA_CODE_UID = @CodeID
 ORDER BY BA_RATETYPE_UID,BA_BC_UID,BA_PRD_ID
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCBAttribsForPeriods')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCBAttribsForPeriods'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCBAttribsForPeriods'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCBAttribsForPeriods
   @CBID INT,
   @FromPeriodID INT,
   @ToPeriodID INT   
AS
SELECT BA_BC_UID,BA_PRD_ID,BA_FTE_CONV
  FROM EPGP_COST_BREAKDOWN_ATTRIBS
  WHERE CB_ID = @CBID And BA_PRD_ID>=@FromPeriodID And BA_PRD_ID<=@ToPeriodID And BA_FTE_CONV<>0
 ORDER BY BA_BC_UID,BA_PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCBUsedProjects')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCBUsedProjects'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCBUsedProjects'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCBUsedProjects
  @CBID INT
AS
Select  Distinct Top 6 CT_NAME,PROJECT_NAME
 From EPGP_COST_VALUES val
 Inner Join  EPGP_PROJECTS proj On val.PROJECT_ID = proj.PROJECT_ID 
 Inner Join  EPGP_COST_TYPES ct On val.CT_ID = ct.CT_ID 
 Where val.CB_ID = @CBID
 Order By PROJECT_NAME,CT_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCFCalcs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCFCalcs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCFCalcs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCFCalcs
AS
 Select CL_UID,CL_SEQ,CL_RESULT,CL_COMPONENT,CL_RATIO,CL_OP,CL_PRI,f1.FA_NAME as ResultName,f2.FA_NAME as ComponentName
  From EPGP_CALCS c
  Join EPGC_FIELD_ATTRIBS f1 On c.CL_RESULT=f1.FA_FIELD_ID
  Left Join EPGC_FIELD_ATTRIBS f2 On c.CL_COMPONENT=f2.FA_FIELD_ID
  Where CL_OBJECT=1
  Order By CL_UID,CL_SEQ
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCompanyHols')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCompanyHols'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCompanyHols'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCompanyHols
  @sList NTEXT,
  @FromDate DATETIME,
  @ToDate DATETIME
AS
 SELECT NWH.GROUP_ID,NWH_DATE,NWH_HOURS
  FROM EPG_GROUP_NONWORK_HOURS NWH
  LEFT JOIN EPG_GROUP_NONWORK_ITEMS GNWI ON GNWI.GROUP_ID = NWH.GROUP_ID
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on NWH.GROUP_ID=LT.TokenVal
  WHERE NWH_DATE >= @FromDate and NWH_DATE <= @ToDate 
  Order By NWH.GROUP_ID,NWH_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCostBreakdowns')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCostBreakdowns'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCostBreakdowns'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCostBreakdowns
AS
SELECT CB_ID,CB_NAME
 FROM EPGP_COST_BREAKDOWNS
 ORDER BY CB_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCostCalcs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCostCalcs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCostCalcs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCostCalcs
  @CTID int
AS
SELECT CL_CT_ID,CL_OP
 FROM EPGP_COST_CALC
 WHERE CT_ID = @CTID
 ORDER BY CL_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCostCategoryWithRoles')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCostCategoryWithRoles'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCostCategoryWithRoles'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCostCategoryWithRoles
AS
SELECT CC.*, LV_VALUE as RoleName
  FROM EPGP_COST_CATEGORIES CC
  LEFT JOIN EPGP_LOOKUP_VALUES ON LV_UID = CC.BC_ROLE
  WHERE BC_UID = CA_UID
  order by BC_ID DESC
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCostTotals')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCostTotals'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCostTotals'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCostTotals
AS
SELECT ctot.CB_ID,ctot.CT_ID,BUDGET_TOTAL_FIELD
 FROM EPGP_BREAKDOWN_COST_TYPES ctot
 Left Join EPGP_COST_TYPES ct on ctot.CT_ID = ct.CT_ID
 Left Join EPGP_COST_BREAKDOWNS cb on ctot.CB_ID = cb.CB_ID
 ORDER BY CT_NAME, CB_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCostTypes')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCostTypes'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCostTypes'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCostTypes
AS
SELECT CT_ID,CT_NAME,CT_EDIT_MODE,INITIAL_LEVEL,CT_CB_ID
 FROM EPGP_COST_TYPES
 ORDER BY CT_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCostValueSetswRole')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCostValueSetswRole'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCostValueSetswRole'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCostValueSetswRole
  @ProjectID INT
AS
Select Distinct cv.CB_ID,cv.CT_ID,CT_NAME,CT_EDIT_MODE,CB_NAME
  From EPGP_COST_VALUES cv
  Inner Join EPGP_COST_TYPES ct On ct.CT_ID = cv.CT_ID
  Inner Join EPGP_COST_BREAKDOWNS cb On cb.CB_ID = cv.CB_ID
   Inner Join EPGP_COST_CATEGORIES cc On cc.BC_UID = cv.BC_UID
  Where Not (BC_ROLE Is NULL Or BC_ROLE = 0) and PROJECT_ID = @ProjectID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCostViewsForWE')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCostViewsForWE'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCostViewsForWE'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCostViewsForWE
AS
 select VIEW_UID,VIEW_NAME 
  From EPGT_COSTVIEW_DISPLAY 
  ORDER BY VIEW_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCTcatsUsedProjects')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCTcatsUsedProjects'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCTcatsUsedProjects'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCTcatsUsedProjects
  @CTID INT,
  @sList NTEXT
AS
Select  Distinct Top 6 CB_NAME,PROJECT_NAME,BC_NAME
 From EPGP_COST_VALUES val
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on val.BC_UID=LT.TokenVal  
 Inner Join  EPGP_PROJECTS proj On val.PROJECT_ID = proj.PROJECT_ID 
 Inner Join  EPGP_COST_BREAKDOWNS cb On val.CB_ID = cb.CB_ID 
 Inner Join  EPGP_COST_CATEGORIES cc On val.BC_UID = cc.BC_UID
 Where val.CT_ID = @CTID
 Order By PROJECT_NAME,CB_NAME,BC_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCTCustomFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCTCustomFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCTCustomFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCTCustomFields
  @CTID INT
AS
Select CT_ID,FIELD_NAME,FA_NAME,FA_LOOKUP_UID,FA_USEFULLNAME,fl.FIELD_ID,CF_EDITABLE,CF_VISIBLE,CF_REQUIRED,CF_IDENTITY,CF_FROZEN
  From EPGT_FIELDS fl 
  Left Join EPGP_COST_CUSTOM_FIELDS cf On fl.FIELD_ID = cf.CF_FIELD_ID and CT_ID = @CTID
  Left Join EPGP_FIELD_ATTRIBS fa On fa.FA_FIELD_ID = fl.FIELD_ID
  Where fl.FIELD_ID > 11800 and fl.FIELD_ID < 11820
  Order By fl.FIELD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCTCustomFilters')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCTCustomFilters'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCTCustomFilters'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCTCustomFilters
  @CTID INT
AS
Select *
  From EPGP_COST_CFFILTER 
   Where CT_ID = @CTID
  Order By CFF_FIELD_ID,CFF_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCTFieldsInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCTFieldsInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCTFieldsInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCTFieldsInfo
AS
   SELECT * 
    FROM EPGP_FIELD_ATTRIBS
    WHERE (FA_FIELD_ID >= 11801 And FA_FIELD_ID <= 11815)
    Order By FA_FIELD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCTs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCTs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCTs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCTs
AS
SELECT CDM_CB_ID,CDM_COST_TYPE_01,CDM_COST_TYPE_02,CDM_COST_TYPE_03,CDM_COST_TYPE_04,CDM_COST_TYPE_05,
   ct1.CT_NAME as CTName01,
   ct2.CT_NAME as CTName02,
   ct3.CT_NAME as CTName03,
   ct4.CT_NAME as CTName04,
   ct5.CT_NAME as CTName05
  FROM EPG_COST_ADMIN
  left Join EPGP_COST_TYPES as ct1 On CDM_COST_TYPE_01=ct1.CT_ID
  left Join EPGP_COST_TYPES as ct2 On CDM_COST_TYPE_02=ct2.CT_ID
  left Join EPGP_COST_TYPES as ct3 On CDM_COST_TYPE_03=ct3.CT_ID
  left Join EPGP_COST_TYPES as ct4 On CDM_COST_TYPE_04=ct4.CT_ID
  left Join EPGP_COST_TYPES as ct5 On CDM_COST_TYPE_05=ct5.CT_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCTsForModel')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCTsForModel'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCTsForModel'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCTsForModel
  @ModelUID INT
AS
Select MODEL_CT_ID,CT_NAME  From EPGP_MODEL_CTS m
  Inner Join EPGP_COST_TYPES c On c.CT_ID=m.MODEL_CT_ID
  Where m.MODEL_UID=@ModelUID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCTUsedCF')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCTUsedCF'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCTUsedCF'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCTUsedCF
  @CFID INT
AS
Select  Distinct Top 6 CT_NAME
 From EPGP_COST_CUSTOM_FIELDS cf
 inner join EPGP_COST_TYPES ct On CT.CT_ID=cf.CT_ID
 Where CF_FIELD_ID=@CFID
 Order By CT_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCTUsedProjects')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCTUsedProjects'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCTUsedProjects'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCTUsedProjects
  @CTID INT
AS
Select  Distinct Top 6 PROJECT_NAME
 From EPGP_COST_VALUES val
 Inner Join  EPGP_PROJECTS proj On val.PROJECT_ID = proj.PROJECT_ID 
 Where val.CT_ID = @CTID
 Order By PROJECT_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCurrentPeriod')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCurrentPeriod'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCurrentPeriod'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCurrentPeriod
AS
SELECT MAX(PRD_ID)
  FROM EPG_TS_TIMESHEETS
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCurrentTimesheetPeriod')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCurrentTimesheetPeriod'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCurrentTimesheetPeriod'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCurrentTimesheetPeriod
AS
DECLARE @lPeriodID INT

SELECT @lPeriodID = Min(PRD_ID) FROM EPG_PERIODS
  WHERE CB_ID = 0 AND PRD_FINISH_DATE > GetDate()
 
if (@lPeriodID is NULL)
  begin
    SELECT @lPeriodID = MIN(PRD_ID)
      FROM EPG_PERIODS WHERE CB_ID = 0
  end

SELECT ''PRD_ID''=@lPeriodID

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCustomFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCustomFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCustomFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCustomFields
  @OrderBy INT
AS
BEGIN
if (@OrderBy = 1)
  begin
	SELECT a.*,LOOKUP_NAME
	  From EPGC_FIELD_ATTRIBS a
	  Left Join EPGP_LOOKUP_TABLES l On l.LOOKUP_UID=a.FA_LOOKUP_UID
	  Order By (FA_TABLE_ID/50),FA_NAME
  end
if (@OrderBy = 2)
  begin
	SELECT a.*,LOOKUP_NAME
	  From EPGC_FIELD_ATTRIBS a
	  Left Join EPGP_LOOKUP_TABLES l On l.LOOKUP_UID=a.FA_LOOKUP_UID
	  Order By FA_NAME
  end
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadCVUsedCapName')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadCVUsedCapName'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadCVUsedCapName'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadCVUsedCapName
  @CSID INT
AS
Select  Distinct Top 6 DEPT_UID
 From EPGP_CAPACITY_SETVALUES val
 Where val.CS_ID = @CSID
 Order By DEPT_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDecCFs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDecCFs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDecCFs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDecCFs
AS
Select FA_FIELD_ID,FA_NAME,FA_TABLE_ID 
 From EPGC_FIELD_ATTRIBS
 Where FA_TABLE_ID=203 or FA_TABLE_ID=202
 Order By FA_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDelegateInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDelegateInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDelegateInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDelegateInfo
   @WResID INT,
   @SurrWResID INT,
   @SurrContext INT
AS
 SELECT *
   FROM EPG_DELEGATES
  WHERE WRES_ID = @WResID AND SURR_WRES_ID = @SurrWResID AND SURR_CONTEXT = @SurrContext
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDelegateRows')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDelegateRows'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDelegateRows'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDelegateRows
   @SurrWResID INT,
   @SurrContext INT
AS
 SELECT SU.*, WR.RES_NAME
   FROM EPG_DELEGATES SU
   LEFT JOIN EPG_RESOURCES WR ON WR.WRES_ID = SU.WRES_ID
  WHERE SURR_WRES_ID = @SurrWResID AND SURR_CONTEXT = @SurrContext
  ORDER BY WR.RES_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDeptCommitments')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDeptCommitments'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDeptCommitments'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDeptCommitments
/*
Public Enum ResCenterRequest
    ResourceValuesForDepts = 1  - for one or more depts
    ResourceValuesForPIsinDept = 2  - for one or more PIs, resources in one or more depts
    ResourceValuesForPIs = 3  - for one or more PIs - all resources
    ResourceValuesForResources = 4  - for one or more resources - all PIs
*/
   @Mode int,
   @sList NTEXT,
   @sPIList NTEXT,
   @sResList NTEXT
AS
if (@Mode = 1) 
 Begin
 Select cm.CMT_UID,cm.RP_GROUP,cm.PROJECT_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_START_DATE,cm.CMT_FINISH_DATE,
    cm.CMT_RATE,rt.RT_NAME,cm.CMT_TOTAL_COST,cm.BC_UID,cm.PARENT_BC_UID,   
    cm.WRES_ID,cm.CMT_STATUS as Status,cm.RP_ACTIVE_COMMITMENT as Commitment,CMT_MAJORCATEGORY,
    CAT_CODE_1,CAT_CODE_2,CAT_CODE_3,CAT_CODE_4,CAT_CODE_5,
    CAT_TEXT_1,CAT_TEXT_2,CAT_TEXT_3,CAT_TEXT_4,CAT_TEXT_5
  From EPG_RESOURCEPLANS cm
  Inner Join EPGP_PROJECTS ex On ex.PROJECT_ID=cm.PROJECT_ID and ex.PROJECT_MARKED_DELETION = 0
  Left Join EPGP_RP_CATEGORY_VALUES cv On cv.CAT_CMT_UID = cm.CMT_UID
  Inner Join dbo.EPG_FN_ConvertListToTable(@sList) LT1 on cm.CMT_DEPT=LT1.TokenVal
  Left Join EPGP_RATE_TYPES rt On cm.CMT_RATETYPE_UID=rt.RT_UID
  Where (cm.CMT_STATUS=256)  
  Order By cm.Project_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_UID
 End
 
else if (@Mode = 2)
 Begin
Select cm.CMT_UID,cm.RP_GROUP,cm.PROJECT_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_START_DATE,cm.CMT_FINISH_DATE,
    cm.CMT_RATE,rt.RT_NAME,cm.CMT_TOTAL_COST,cm.BC_UID,cm.PARENT_BC_UID,   
    cm.WRES_ID,cm.CMT_STATUS as Status,cm.RP_ACTIVE_COMMITMENT as Commitment,CMT_MAJORCATEGORY,
    CAT_CODE_1,CAT_CODE_2,CAT_CODE_3,CAT_CODE_4,CAT_CODE_5,
    CAT_TEXT_1,CAT_TEXT_2,CAT_TEXT_3,CAT_TEXT_4,CAT_TEXT_5
  From EPG_RESOURCEPLANS cm
  Inner Join EPGP_PROJECTS ex On ex.PROJECT_ID=cm.PROJECT_ID and ex.PROJECT_MARKED_DELETION = 0
  Left Join EPGP_RP_CATEGORY_VALUES cv On cv.CAT_CMT_UID = cm.CMT_UID
  Inner Join dbo.EPG_FN_ConvertListToTable(@sList) LT1 on cm.CMT_DEPT=LT1.TokenVal
  Inner Join dbo.EPG_FN_ConvertListToTable(@sPIList) LT2 on cm.PROJECT_ID=LT2.TokenVal
  Left Join EPGP_RATE_TYPES rt On cm.CMT_RATETYPE_UID=rt.RT_UID
  Where (cm.CMT_STATUS=256)  
  Order By cm.Project_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_UID
 End
 
else if (@Mode = 3)
 Begin
 Select cm.CMT_UID,cm.RP_GROUP,cm.PROJECT_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_START_DATE,cm.CMT_FINISH_DATE,
    cm.CMT_RATE,rt.RT_NAME,cm.CMT_TOTAL_COST,cm.BC_UID,cm.PARENT_BC_UID,   
    cm.WRES_ID,cm.CMT_STATUS as Status,cm.RP_ACTIVE_COMMITMENT as Commitment,CMT_MAJORCATEGORY,
    CAT_CODE_1,CAT_CODE_2,CAT_CODE_3,CAT_CODE_4,CAT_CODE_5,
    CAT_TEXT_1,CAT_TEXT_2,CAT_TEXT_3,CAT_TEXT_4,CAT_TEXT_5
  From EPG_RESOURCEPLANS cm
  Inner Join EPGP_PROJECTS ex On ex.PROJECT_ID=cm.PROJECT_ID and ex.PROJECT_MARKED_DELETION = 0
  Left Join EPGP_RP_CATEGORY_VALUES cv On cv.CAT_CMT_UID = cm.CMT_UID
  Inner Join dbo.EPG_FN_ConvertListToTable(@sPIList) LT1 on cm.PROJECT_ID=LT1.TokenVal
  Left Join EPGP_RATE_TYPES rt On cm.CMT_RATETYPE_UID=rt.RT_UID
  Where (cm.CMT_STATUS=256)  
  Order By cm.Project_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_UID
 End
 
else if (@Mode = 4)
 Begin
 Select cm.CMT_UID,cm.RP_GROUP,cm.PROJECT_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_START_DATE,cm.CMT_FINISH_DATE,
    cm.CMT_RATE,rt.RT_NAME,cm.CMT_TOTAL_COST,cm.BC_UID,cm.PARENT_BC_UID,   
    cm.WRES_ID,cm.CMT_STATUS as Status,cm.RP_ACTIVE_COMMITMENT as Commitment,CMT_MAJORCATEGORY,
    CAT_CODE_1,CAT_CODE_2,CAT_CODE_3,CAT_CODE_4,CAT_CODE_5,
    CAT_TEXT_1,CAT_TEXT_2,CAT_TEXT_3,CAT_TEXT_4,CAT_TEXT_5
  From EPG_RESOURCEPLANS cm
  Inner Join EPGP_PROJECTS ex On ex.PROJECT_ID=cm.PROJECT_ID and ex.PROJECT_MARKED_DELETION = 0
  Left Join EPGP_RP_CATEGORY_VALUES cv On cv.CAT_CMT_UID = cm.CMT_UID
  Inner Join dbo.EPG_FN_ConvertListToTable(@sResList) LT1 on (cm.WRES_ID=LT1.TokenVal)
  Left Join EPGP_RATE_TYPES rt On cm.CMT_RATETYPE_UID=rt.RT_UID
  Where (cm.CMT_STATUS=256)  
  Order By cm.Project_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_UID
  
 End
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDeptHours')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDeptHours'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDeptHours'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDeptHours
   @Pending INT,
   @FromPeriodID INT,
   @ToPeriodID INT,
   @sList NTEXT
AS
if (@Pending = 0) 
 Begin
 Select CMT_UID,PRD_ID,CMH_HOURS,CMH_FTES
  From EPG_RESOURCEPLANS_HOURS
  Inner Join dbo.EPG_FN_ConvertListToTable(@sList) LT2 on CMT_UID=LT2.TokenVal
  Where (CMH_PENDING = 0 or CMH_PENDING is NULL) And (PRD_ID >= @FromPeriodID And PRD_ID <= @ToPeriodID) and CMH_HOURS > 0
  Order By CMT_UID,PRD_ID
 End
 
else if (@Pending = 1)
 Begin
 Select CMT_UID,PRD_ID,CMH_HOURS,CMH_FTES
  From EPG_RESOURCEPLANS_HOURS
  Inner Join dbo.EPG_FN_ConvertListToTable(@sList) LT2 on CMT_UID=LT2.TokenVal
  Where (CMH_PENDING = 1) And (PRD_ID >= @FromPeriodID And PRD_ID <= @ToPeriodID) and CMH_HOURS > 0
  Order By CMT_UID,PRD_ID
 End
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDeptPeriod')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDeptPeriod'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDeptPeriod'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDeptPeriod
   @DeptUID INT,
   @PeriodID INT
AS
SELECT *
  FROM EPG_TS_DEPTS
 WHERE TSD_PRD_ID = @PeriodID AND TSD_DEPT_UID = @DeptUID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDeptPeriodStatus')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDeptPeriodStatus'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDeptPeriodStatus'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDeptPeriodStatus
   @DeptUID INT,
   @PeriodID INT
AS
SELECT PRD_IS_CLOSED,TSD_STATUS
  FROM EPG_PERIODS
  LEFT JOIN EPG_TS_DEPTS ON (PRD_ID = TSD_PRD_ID  and TSD_DEPT_UID = @DeptUID)
 WHERE PRD_ID = @PeriodID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDeptPIList')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDeptPIList'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDeptPIList'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDeptPIList
   @sList NTEXT
AS
 Select Distinct c.PROJECT_ID
  From EPG_RESOURCEPLANS c
  Inner Join EPGP_PROJECTS p On p.PROJECT_ID=c.PROJECT_ID And PROJECT_MARKED_DELETION = 0
  Inner Join dbo.EPG_FN_ConvertListToTable(@sList) LT1 on CMT_DEPT=LT1.TokenVal
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDeptResources')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDeptResources'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDeptResources'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDeptResources
  @lDeptUID INT
AS
SELECT WR.WRES_ID,WR.RES_NAME
  FROM EPG_RESOURCES WR
 WHERE WRES_DEPT = @lDeptUID 
   AND WRES_INACTIVE = 0 
   AND WRES_IS_RESOURCE = 1 
  ORDER BY WR.RES_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDeptsResInfos')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDeptsResInfos'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDeptsResInfos'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDeptsResInfos
  @sList NTEXT,
  @DeptMode int
AS
if (@DeptMode = -1)
 Begin
 SELECT WRES_ID,RES_NAME,WRES_DEPT,WRES_RP_DEPT,WRES_IS_RESOURCE,WRES_INACTIVE,WRES_AVAILABLEFROM,WRES_AVAILABLETO
  FROM EPG_RESOURCES 
  Where WRES_IS_RESOURCE=1
 End
else if (@DeptMode = 0)
 Begin
 SELECT WRES_ID,RES_NAME,WRES_DEPT,WRES_RP_DEPT,WRES_IS_RESOURCE,WRES_INACTIVE,WRES_AVAILABLEFROM,WRES_AVAILABLETO
  FROM EPG_RESOURCES 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_DEPT=LT.TokenVal 
 End
Else
 Begin
 SELECT WRES_ID,RES_NAME,WRES_DEPT,WRES_RP_DEPT,WRES_IS_RESOURCE,WRES_INACTIVE,WRES_AVAILABLEFROM,WRES_AVAILABLETO
  FROM EPG_RESOURCES 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_RP_DEPT=LT.TokenVal 
 End
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDeptsResMembers')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDeptsResMembers'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDeptsResMembers'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDeptsResMembers
  @sList NTEXT,
  @DeptMode int,
  @ResourcesOnly int
AS
if (@DeptMode = 0)
 Begin
 
	if (@ResourcesOnly = 0)
	 Begin
	 SELECT WRES_ID
	  FROM EPG_RESOURCES 
	  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_DEPT=LT.TokenVal
	  Where WRES_IS_GENERIC=0
	 End
	else
	 Begin
	 SELECT WRES_ID
	  FROM EPG_RESOURCES 
	  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_DEPT=LT.TokenVal
	  Where WRES_IS_RESOURCE=1
	 End  
  End
 else
  Begin	
	if (@ResourcesOnly = 0)
	 Begin
	 SELECT WRES_ID
	  FROM EPG_RESOURCES 
	  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_RP_DEPT=LT.TokenVal
	  Where WRES_IS_GENERIC=0
	 End
	else
	 Begin
	 SELECT WRES_ID
	  FROM EPG_RESOURCES 
	  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_RP_DEPT=LT.TokenVal
	  Where WRES_IS_RESOURCE=1
	 End  
 End
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadDeptsResources')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadDeptsResources'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadDeptsResources'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadDeptsResources
   @Mode INT,
   @DeptUIDs NTEXT
AS
--	Mode = 0 = TS Depts
--	Mode = 1 = RP Depts
if (@Mode = 0)
    BEGIN
	SELECT WR.WRES_ID,WR.RES_NAME,WRES_DEPT AS DeptUID
	  FROM EPG_RESOURCES WR
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@DeptUIDs) LT on WRES_DEPT=LT.TokenVal
	 WHERE WRES_INACTIVE = 0 AND WRES_IS_RESOURCE = 1
	 ORDER BY WRES_DEPT,WR.RES_NAME
    END
else if (@Mode = 1)
    BEGIN
	SELECT WR.WRES_ID,WR.RES_NAME,WRES_RP_DEPT AS DeptUID
	  FROM EPG_RESOURCES WR
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@DeptUIDs) LT on WRES_RP_DEPT=LT.TokenVal
	 WHERE WRES_INACTIVE = 0 AND WRES_IS_RESOURCE = 1
	 ORDER BY WRES_RP_DEPT,WR.RES_NAME
    END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadEPKViewFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadEPKViewFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadEPKViewFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadEPKViewFields
  @ViewUID INT
AS
SELECT F.FIELD_ID,F.FIELD_TABLE_ID,F.FIELD_NAME_SQL,VF.GRAPHIND_UID
  FROM EPGT_FIELDS F
  left join EPGT_VIEW_FIELDS VF on (F.FIELD_ID = VF.FIELD_ID)
 WHERE VF.VIEW_UID = @ViewUID
 ORDER BY F.FIELD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadEVCategories')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadEVCategories'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadEVCategories'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadEVCategories
AS
SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_FORMAT,FA.*
  FROM EPGT_FIELDS
  left join EPGP_FIELD_ATTRIBS FA on (FIELD_ID = FA_FIELD_ID)
 WHERE FIELD_ID >= 9500 AND FIELD_ID <= 9509 AND FIELD_VIEWTYPE_ID = 5
 ORDER BY FIELD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadExternalLinkInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadExternalLinkInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadExternalLinkInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadExternalLinkInfo
   @Context INT,
   @Status INT
AS
SELECT * FROM EPG_EXT_LINKS WHERE EXL_CONTEXT = @Context AND EXL_STATUS = @Status
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadFieldInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadFieldInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadFieldInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadFieldInfo
  @FieldID int
AS
 if (@FieldID >= 20000) 
   SELECT * FROM EPGC_FIELD_ATTRIBS
    Where FA_FIELD_ID=@FieldID
 else if (@FieldID = 9005)
   SELECT ADM_DEPT_CODE AS FA_LOOKUP_UID FROM EPG_ADMIN
 else if (@FieldID = 9015)
   SELECT ADM_RPE_DEPT_CODE AS FA_LOOKUP_UID FROM EPG_ADMIN
 else
   SELECT * FROM EPGP_FIELD_ATTRIBS
    Where FA_FIELD_ID=@FieldID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadFieldsForWE')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadFieldsForWE'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadFieldsForWE'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadFieldsForWE
  @SelectMode INT
-- SelectMode = 0 Resource fields (Out of EPK)
-- SelectMode = 1 PI fields (Out of EPK)
-- SelectMode = 2 PI fields (Into EPK)
-- SelectMode = 3 WI fields (Out of EPK)
AS
if (@SelectMode = 0)
 SELECT FIELD_ID,FIELD_NAME,FIELD_FORMAT 
  FROM EPGT_RES_FIELDS 
  Where FIELD_EXPORT=1 
   UNION
  Select FA_FIELD_ID as FIELD_ID, FA_NAME as FIELD_NAME, FA_FORMAT as FIELD_FORMAT From EPGC_FIELD_ATTRIBS f 
  Where FA_TABLE_ID > 100 and FA_TABLE_ID < 160 
  ORDER BY FIELD_NAME
else if (@SelectMode = 1)
 Select FA_FIELD_ID as FIELD_ID, FA_NAME as FIELD_NAME, FA_FORMAT as FIELD_FORMAT 
  From EPGC_FIELD_ATTRIBS 
  Where FA_TABLE_ID in (201,202,203,205) And (FA_FIELD_ID In (Select BUDGET_TOTAL_FIELD from EPGP_BREAKDOWN_COST_TYPES)
   or FA_FIELD_ID In (Select DISTINCT CL_RESULT from EPGP_CALCS) 
   or FA_FIELD_ID In (Select ADM_PROJ_RES_HOURS_CFID from EPG_ADMIN)
   or (FA_NAME=''OptimizerFlag'' and FA_FORMAT=13))
  ORDER BY FIELD_NAME
else if (@SelectMode = 2)
 SELECT FIELD_ID,FIELD_NAME,FIELD_FORMAT 
  FROM EPGT_FIELDS 
  Where FIELD_EXPORT=1
   UNION
 Select FA_FIELD_ID as FIELD_ID, FA_NAME as FIELD_NAME, FA_FORMAT as FIELD_FORMAT 
  From EPGC_FIELD_ATTRIBS 
  Where FA_TABLE_ID in (201,202,203,205) 
     And (FA_FIELD_ID NOT In (Select BUDGET_TOTAL_FIELD from EPGP_BREAKDOWN_COST_TYPES) and FA_FIELD_ID NOT In (Select DISTINCT CL_RESULT from EPGP_CALCS))
     And FA_FIELD_ID Not In (Select ADM_PROJ_RES_HOURS_CFID from EPG_ADMIN)
     And Not (FA_NAME =''OptimizerFlag'' and FA_FORMAT=13) 
     And FA_FORMAT <> 4
  ORDER BY FIELD_NAME
else if (@SelectMode = 3)
 SELECT FIELD_ID,FIELD_NAME,FIELD_FORMAT 
  FROM EPGT_FIELDS 
  Where FIELD_EXPORT=2
   UNION
 Select FA_FIELD_ID as FIELD_ID, FA_NAME as FIELD_NAME, FA_FORMAT as FIELD_FORMAT 
  From EPGC_FIELD_ATTRIBS 
  Where FA_TABLE_ID in (801,802,803)
  ORDER BY FIELD_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadFTEs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadFTEs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadFTEs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadFTEs
   @CalID INT,
   @FromPeriodID INT,
   @CostCategoryUIDs NTEXT
AS
SELECT BA_BC_UID as CostCategoryUID, BA_PRD_ID as PeriodID, BA_FTE_CONV as FTE
  FROM EPGP_COST_BREAKDOWN_ATTRIBS
  LEFT JOIN EPGP_COST_CATEGORIES CC ON CC.BC_UID = BA_BC_UID
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@CostCategoryUIDs) LT on BA_BC_UID=LT.TokenVal 
 WHERE CB_ID = @CalID AND BA_PRD_ID >= @FromPeriodID AND BA_RATETYPE_UID = 0 AND BA_CODE_UID = 0
 ORDER BY BA_BC_UID,BA_PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadGenericMembers')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadGenericMembers'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadGenericMembers'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadGenericMembers
AS
 SELECT WRES_ID
  FROM   EPG_RESOURCES
  WHERE  WRES_IS_GENERIC > 0
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadGroup')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadGroup'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadGroup'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadGroup
  @GroupID INT,
  @GroupType INT
AS
SELECT *
  FROM EPG_GROUPS
 WHERE GROUP_ID = @GroupID

/* Resource Permissions */
if (@GroupType = 1)
  begin
    SELECT P.*, GP.PERM_UID as PermissionUID
      FROM EPG_PERMISSIONS P
      LEFT JOIN EPG_GROUP_PERMISSIONS GP on (P.PERM_UID = GP.PERM_UID AND GP.GROUP_ID = @GroupID)
     ORDER BY P.PERM_ID 
  end

/* Company Weekly Work Hours */
if (@GroupType = 10)
  begin
    SELECT WH.*
      FROM EPG_GROUP_WEEKLYHOURS WH
     WHERE GROUP_ID = @GroupID
  end

/* Company Day Non-Work Hours (Holiday) */
if (@GroupType = 11)
  begin
    SELECT *
      FROM EPG_GROUP_NONWORK_ITEMS 
     WHERE GROUP_ID = @GroupID

    SELECT GNWH.*
      FROM EPG_GROUP_NONWORK_HOURS GNWH
      LEFT JOIN EPG_GROUP_NONWORK_ITEMS GNWI ON GNWI.GROUP_ID = GNWH.GROUP_ID
     WHERE GNWH.GROUP_ID = @GroupID
     ORDER BY NWH_DATE 
  end

/* TS Limits */
if (@GroupType = 12)
  begin
    SELECT TL.*
      FROM EPG_GROUP_TSLIMITS TL
     WHERE GROUP_ID = @GroupID
  end

SELECT GM.*, WR.*
  FROM EPG_GROUP_MEMBERS GM
  LEFT JOIN EPG_RESOURCES WR on (WR.WRES_ID = GM.MEMBER_UID)
 WHERE GROUP_ID = @GroupID
 ORDER BY WR.RES_NAME 

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadGroups')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadGroups'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadGroups'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadGroups
   @SelectMode INT,
   @EntityUIDs NTEXT
AS
	if (@SelectMode = 0)
		SELECT *
		  FROM EPG_GROUPS
		 ORDER BY GROUP_ENTITY, GROUP_NAME
	else
		SELECT *
		  FROM EPG_GROUPS
		 INNER JOIN dbo.EPG_FN_ConvertListToTable(@EntityUIDs) LT on GROUP_ENTITY=LT.TokenVal
		 ORDER BY GROUP_ENTITY, GROUP_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadGroupsForMember')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadGroupsForMember'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadGroupsForMember'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadGroupsForMember
   @WresID int
AS
 Select GROUP_NAME,m.GROUP_ID,GROUP_ENTITY 
  From EPG_GROUP_MEMBERS m 
  Inner Join EPG_GROUPS g On m.GROUP_ID = g.GROUP_ID
  Where MEMBER_UID=@WresID 
  Order by GROUP_ENTITY,GROUP_NAME

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadGroupsForMembers')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadGroupsForMembers'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadGroupsForMembers'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadGroupsForMembers
   @GroupType int,
   @MemberList NTEXT
AS
 Select m.GROUP_ID,GROUP_NAME,MEMBER_UID 
  From EPG_GROUP_MEMBERS m 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@MemberList) LT on MEMBER_UID=LT.TokenVal
  Inner Join EPG_GROUPS g On m.GROUP_ID = g.GROUP_ID And GROUP_ENTITY = @GroupType
  Order by MEMBER_UID,GROUP_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadGroupType')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadGroupType'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadGroupType'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadGroupType
   @GroupType int
AS
 Select * 
  From EPG_GROUPS 
  Where GROUP_ENTITY=@GroupType 
  Order by GROUP_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadHomeLinks')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadHomeLinks'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadHomeLinks'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadHomeLinks
  @WResID int
AS
-- This SP returns multiple recordsets
-- return the manager''s details if it isn''t this user. i.e. user acting as delegate
-- Delegate values:
--    scTimesheet = 1
--    scDepartment = 2
--    scPIPlanOwner = 3
--    scPIManager = 4
--    scResourceManager = 5
--    scPIStageOwner = 6
-- Read PI Plan Owner''s (Manager of Project Schedules) PIs
SELECT PROJECT_ID as ProjectID,PROJECT_NAME as ProjectName,null as WResID,null as ResourceName
  FROM EPGP_PROJECTS 
 WHERE PROJECT_PLAN_OWNER=@WResID AND PROJECT_MARKED_DELETION <> 1 
union
SELECT PROJECT_ID as ProjectID,PROJECT_NAME as ProjectName,WRES_ID as WResID,R.RES_NAME as ResourceName
  FROM EPGP_PROJECTS P
  LEFT JOIN EPG_RESOURCES R ON (R.WRES_ID = P.PROJECT_PLAN_OWNER)
 WHERE PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 3 AND SURR_WRES_ID = @WResID) AND PROJECT_MARKED_DELETION <> 1
 ORDER BY PROJECT_NAME

-- Read PI Stage Owner''s PIs
SELECT PROJECT_ID as ProjectID,PROJECT_NAME as ProjectName,null as WResID,null as ResourceName
  FROM EPGP_PROJECTS 
 WHERE PROJECT_OWNER=@WResID AND PROJECT_MARKED_DELETION <> 1 
union
SELECT PROJECT_ID as ProjectID,PROJECT_NAME as ProjectName,WRES_ID as WResID,R.RES_NAME as ResourceName
  FROM EPGP_PROJECTS P
  LEFT JOIN EPG_RESOURCES R ON (R.WRES_ID = P.PROJECT_OWNER)
 WHERE PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 6 AND SURR_WRES_ID = @WResID) AND PROJECT_MARKED_DELETION <> 1
 ORDER BY PROJECT_NAME

-- Read PI Manager''s PIs
SELECT PROJECT_ID as ProjectID,PROJECT_NAME as ProjectName,null as WResID,null as ResourceName
  FROM EPGP_PROJECTS 
 WHERE PROJECT_MANAGER=@WResID AND PROJECT_MARKED_DELETION <> 1 
union
SELECT PROJECT_ID as ProjectID,PROJECT_NAME as ProjectName,WRES_ID as WResID,R.RES_NAME as ResourceName
  FROM EPGP_PROJECTS P
  LEFT JOIN EPG_RESOURCES R ON (R.WRES_ID = P.PROJECT_MANAGER)
 WHERE PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 4 AND SURR_WRES_ID = @WResID) AND PROJECT_MARKED_DELETION <> 1
 ORDER BY PROJECT_NAME

-- Read TS Manager''s Depts
SELECT LV_UID as DeptUID,LV_VALUE as DeptName,0 as Delegated,null as WResID,null as ResourceName
  FROM EPGP_LOOKUP_VALUES OC 
 WHERE LV_UID IN (select CODE_UID FROM EPG_TS_APPROVERS WHERE WRES_ID=@WResID)
union
SELECT LV_UID as DeptUID,LV_VALUE as DeptName,1 as Delegated,TA.WRES_ID as WResID,R.RES_NAME as ResourceName
  FROM EPGP_LOOKUP_VALUES OC 
  LEFT JOIN EPG_TS_APPROVERS TA ON (LV_UID = TA.CODE_UID)
  LEFT JOIN EPG_RESOURCES R ON (R.WRES_ID = TA.WRES_ID)
 WHERE LV_UID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 2 AND SURR_WRES_ID = @WResID)
ORDER BY LV_VALUE

-- Read Res Manager''s Depts
SELECT LV_UID as DeptUID,LV_VALUE as DeptName,0 as Delegated,null as WResID,null as ResourceName
  FROM EPGP_LOOKUP_VALUES OC 
 WHERE LV_UID IN (select CODE_UID FROM EPG_RES_MANAGERS WHERE WRES_ID=@WResID) 
union
SELECT LV_UID as DeptUID,LV_VALUE as DeptName,1 as Delegated,RM.WRES_ID as WResID,R.RES_NAME as ResourceName
  FROM EPGP_LOOKUP_VALUES OC 
  LEFT JOIN EPG_RES_MANAGERS RM ON (LV_UID = RM.CODE_UID)
  LEFT JOIN EPG_RESOURCES R ON (R.WRES_ID = RM.WRES_ID)
 WHERE LV_UID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 5 AND SURR_WRES_ID = @WResID)
ORDER BY LV_VALUE

-- Read Delegated Timesheets
SELECT WR.WRES_ID as WResID, WR.RES_NAME as ResourceName
FROM EPG_DELEGATES SU
LEFT JOIN EPG_RESOURCES WR ON WR.WRES_ID = SU.WRES_ID
WHERE SURR_WRES_ID = @WResID AND SURR_CONTEXT = 1
ORDER BY WR.RES_NAME


')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadInfoForCreateMSProject')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadInfoForCreateMSProject'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadInfoForCreateMSProject'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadInfoForCreateMSProject
   @ProjectID int
AS

SELECT PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_WSS_SITE,PROJECT_OWNER
  FROM EPGP_PROJECTS
 WHERE PROJECT_ID = @ProjectID

SELECT WORKITEM_ID,WORKITEM_SEQ,WORKITEM_NAME,WORKITEM_LEVEL,WORKITEM_START_DATE,WORKITEM_FINISH_DATE,WORKITEM_DURATION,WORKITEM_WORK
  FROM EPGP_PI_WORKITEMS
 WHERE PROJECT_ID = @ProjectID
 ORDER BY WORKITEM_SEQ

SELECT WORKITEM_ID,WRES_ID,WIRES_WORK,WIRES_ACTUALWORK,WIRES_PERCENT_COMPLETE,WIRES_ACTUAL_START_DATE,WIRES_ACTUAL_FINISH_DATE
  FROM EPGP_PI_WORKITEM_ASSNS
 WHERE PROJECT_ID = @ProjectID

SELECT WORKITEM_PRED_ID,WORKITEM_SUCC_ID,WORKITEM_TYPE
  FROM EPGP_PI_WORKITEM_LOGIC 
 WHERE PROJECT_ID = @ProjectID

SELECT DISTINCT WRES_ID
  FROM EPG_RESOURCEPLANS
 WHERE WRES_ID > 0 and PROJECT_ID = @ProjectID

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadInitialisedCustomFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadInitialisedCustomFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadInitialisedCustomFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadInitialisedCustomFields
  @TableID INT,
  @FormatID INT
AS
  Select FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_LOOKUP_UID
     From EPGC_FIELD_ATTRIBS
--     Where FA_TABLE_ID=@TableID And FA_FORMAT=@FormatID and FA_LOOKUP_UID > 0
     Where FA_TABLE_ID=@TableID And FA_FORMAT=@FormatID
     Order by FA_NAME

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadInitialisedPortfolioFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadInitialisedPortfolioFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadInitialisedPortfolioFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadInitialisedPortfolioFields
  @FieldIDFrom INT,
  @FieldIDTo INT
AS
SELECT *
FROM EPGP_FIELD_ATTRIBS
WHERE FA_LOOKUP_UID > 0
AND FA_FIELD_ID >= @FieldIDFrom
AND FA_FIELD_ID <= @FieldIDTo
ORDER BY FA_FIELD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadInvalidDelegates')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadInvalidDelegates'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadInvalidDelegates'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadInvalidDelegates
AS
-- Delegate values:
--    scTimesheet = 1
--    scDepartment = 2
--    scPIPlanOwner = 3
--    scPIManager = 4
--    scResourceManager = 5
--    scPIStageOwner = 6

-- Resource cannot be own delegate
SELECT SU.*, WR.RES_NAME
  FROM EPG_DELEGATES SU
  LEFT JOIN EPG_RESOURCES WR ON WR.WRES_ID = SU.SURR_WRES_ID
 WHERE SU.WRES_ID = SURR_WRES_ID

-- TS Dept Manager
SELECT AP.CODE_UID as DeptUID, LV_VALUE as DeptName, SU.* ,WR.RES_NAME
  FROM EPG_DELEGATES SU
  LEFT JOIN EPG_TS_APPROVERS AP on (SURR_CONTEXT = 2 and SURR_CONTEXT_VALUE = AP.CODE_UID)
  LEFT JOIN EPGP_LOOKUP_VALUES OC ON LV_UID = AP.CODE_UID
  LEFT JOIN EPG_RESOURCES WR ON WR.WRES_ID = SU.SURR_WRES_ID
 WHERE SURR_CONTEXT = 2 AND SU.WRES_ID <> AP.WRES_ID

-- PI Plan Owner
SELECT PROJECT_ID, PROJECT_NAME, SU.* ,WR.RES_NAME
  FROM EPG_DELEGATES SU
  LEFT JOIN EPGP_PROJECTS PR on (SURR_CONTEXT = 3 and SURR_CONTEXT_VALUE = PR.PROJECT_ID)
  LEFT JOIN EPG_RESOURCES WR ON WR.WRES_ID = SU.SURR_WRES_ID
 WHERE SURR_CONTEXT = 3 AND SU.WRES_ID <> PROJECT_PLAN_OWNER

-- PI Manager
SELECT PROJECT_ID, PROJECT_NAME, SU.* ,WR.RES_NAME
  FROM EPG_DELEGATES SU
  LEFT JOIN EPGP_PROJECTS PR on (SURR_CONTEXT = 4 and SURR_CONTEXT_VALUE = PR.PROJECT_ID)
  LEFT JOIN EPG_RESOURCES WR ON WR.WRES_ID = SU.SURR_WRES_ID
 WHERE SURR_CONTEXT = 4 AND SU.WRES_ID <> PROJECT_MANAGER

-- Resource Manager
SELECT AP.CODE_UID as DeptUID, LV_VALUE as DeptName, SU.* ,WR.RES_NAME
  FROM EPG_DELEGATES SU
  LEFT JOIN EPG_RES_MANAGERS AP on (SURR_CONTEXT = 5 and SURR_CONTEXT_VALUE = AP.CODE_UID)
  LEFT JOIN EPGP_LOOKUP_VALUES OC ON LV_UID = AP.CODE_UID
  LEFT JOIN EPG_RESOURCES WR ON WR.WRES_ID = SU.SURR_WRES_ID
 WHERE SURR_CONTEXT = 5 AND SU.WRES_ID <> AP.WRES_ID

-- PI Stage Owner
SELECT PROJECT_ID, PROJECT_NAME, SU.* ,WR.RES_NAME
  FROM EPG_DELEGATES SU
  LEFT JOIN EPGP_PROJECTS PR on (SURR_CONTEXT = 6 and SURR_CONTEXT_VALUE = PR.PROJECT_ID)
  LEFT JOIN EPG_RESOURCES WR ON WR.WRES_ID = SU.SURR_WRES_ID
 WHERE SURR_CONTEXT = 6 AND SU.WRES_ID <> PROJECT_OWNER

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadJobQueue')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadJobQueue'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadJobQueue'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadJobQueue
   @FromDate DATETIME,
   @ToDate DATETIME,
   @sList NTEXT
AS
SELECT J.*, R.RES_NAME, JM.JMG_TIMESTAMP, JM.JMG_MESSAGE
  FROM EPG_JOBS J
  LEFT JOIN EPG_RESOURCES R ON J.WRES_ID = R.WRES_ID
  LEFT JOIN EPG_JOB_MSGS JM ON JM.JOB_GUID = J.JOB_GUID
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on JOB_STATUS=LT.TokenVal
 WHERE JOB_SUBMITTED >= @FromDate AND JOB_SUBMITTED <= @ToDate   
 ORDER BY JOB_SUBMITTED DESC, JMG_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadJobQueue2')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadJobQueue2'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadJobQueue2'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadJobQueue2
  @intStartRow int,
  @intEndRow int
AS
 
DECLARE @query AS NVARCHAR(MAX);
 
set @query = ''WITH pages AS (SELECT ROW_NUMBER() OVER(ORDER BY JOB_SUBMITTED DESC, JMG_UID) as RowNumber, J.*, R.RES_NAME, JM.JMG_TIMESTAMP, JM.JMG_MESSAGE '' +
'' FROM EPG_JOBS J '' + 
'' LEFT JOIN EPG_RESOURCES R ON J.WRES_ID = R.WRES_ID '' + 
'' LEFT JOIN EPG_JOB_MSGS JM ON JM.JOB_GUID = J.JOB_GUID '' + 
'' INNER JOIN dbo.EPG_FN_ConvertListToTable(N''''-2,-1,0,1'''') LT on JOB_STATUS=LT.TokenVal ) '' + 
'' SELECT * FROM pages WHERE RowNumber BETWEEN '' + convert(nvarchar,@intStartRow) + '' AND '' + convert(nvarchar,@intEndRow);

execute(@query)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadListFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadListFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadListFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadListFields
   @ListID int,
   @sList NTEXT
AS
SELECT WSS_LIST_ID,WSS_FIELD_ID,WSS_NAME,WSS_FIELD_TP1
 FROM EPGP_WSS_FIELD_ATTRIBS
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WSS_FIELD_ID=LT.TokenVal And (WSS_LIST_ID = 0 Or WSS_LIST_ID = @ListID)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadListItems')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadListItems'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadListItems'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadListItems
   @LookupUID INT
AS
   SELECT LV_UID,LV_VALUE,LV_ID,LV_LEVEL,LV_INACTIVE
	FROM EPGP_LOOKUP_VALUES 
	WHERE LOOKUP_UID = @LookupUID
	ORDER BY LV_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadListofAttribs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadListofAttribs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadListofAttribs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadListofAttribs
   @CBID int,
   @sCatList NTEXT
AS
SELECT BA_BC_UID, BA_PRD_ID, BA_FTE_CONV,BA_RATE FROM EPGP_COST_BREAKDOWN_ATTRIBS
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sCatList) LT on BA_BC_UID=LT.TokenVal 
 WHERE CB_ID = @CBID
 Order By BA_BC_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadListofXrefs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadListofXrefs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadListofXrefs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadListofXrefs
   @sResList NTEXT
AS
SELECT * FROM EPGP_COST_XREF
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sResList) LT on WRES_ID=LT.TokenVal 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadListTypes')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadListTypes'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadListTypes'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadListTypes
AS
SELECT WSS_LIST_ID,WSS_TP_TITLE,WSS_BASE_TYPE,WSS_DESC
 FROM EPGP_WSS_LISTS
 ORDER BY WSS_TP_TITLE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadLogicallyDeletedTimesheets')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadLogicallyDeletedTimesheets'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadLogicallyDeletedTimesheets'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadLogicallyDeletedTimesheets
AS
SELECT TS_UID, TS.PRD_ID, TS.WRES_ID, RES_NAME, PRD_NAME
  FROM EPG_TS_TIMESHEETS TS
LEFT JOIN EPG_PERIODS P ON (P.PRD_ID = TS.PRD_ID AND CB_ID = 0)
LEFT JOIN EPG_RESOURCES R ON (R.WRES_ID = TS.WRES_ID)
 WHERE TS_DELETED = 1 AND TS.PRD_ID <= (SELECT CB_LOCK_TO FROM EPGP_COST_BREAKDOWNS WHERE CB_ID = 0)
 ORDER BY TS.PRD_ID, R.RES_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadLookupInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadLookupInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadLookupInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadLookupInfo
   @LookupUID INT
AS
SELECT *
 FROM EPGP_LOOKUP_TABLES
 WHERE LOOKUP_UID = @LookupUID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadLookupList')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadLookupList'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadLookupList'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadLookupList
AS
SELECT *
 FROM EPGP_LOOKUP_TABLES
 ORDER BY LOOKUP_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadLookupValues')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadLookupValues'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadLookupValues'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadLookupValues
   @sList NTEXT
AS
SELECT LOOKUP_UID,LV_UID,LV_VALUE
  FROM EPGP_LOOKUP_VALUES
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on LV_UID=LT.TokenVal 
 ORDER BY LV_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadLookupValuesByLookup')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadLookupValuesByLookup'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadLookupValuesByLookup'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadLookupValuesByLookup
   @sList NTEXT
AS
SELECT LOOKUP_UID,LV_UID,LV_FULLVALUE
  FROM EPGP_LOOKUP_VALUES
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on LOOKUP_UID=LT.TokenVal 
 ORDER BY LV_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadLTUsedinViews')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadLTUsedinViews'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadLTUsedinViews'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadLTUsedinViews
  @LTID INT
AS
Select  Top 6 VIEW_NAME,VIEW_UID
 From EPGT_VIEW_DISPLAY
 Where VIEW_TYPE = 2 and VIEW_SUBTYPE = @LTID
 Order By VIEW_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadMailInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadMailInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadMailInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadMailInfo
AS
 SELECT *
   FROM EPG_MAIL_ADMIN
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadManagerDepts')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadManagerDepts'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadManagerDepts'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadManagerDepts
  @ApproverWResID int
AS
   SELECT LV_UID as DeptUID,LV_VALUE as DeptName
     FROM EPGP_LOOKUP_VALUES OC 
    WHERE (LV_UID IN (select CODE_UID FROM EPG_TS_APPROVERS WHERE WRES_ID=@ApproverWResID) 
       OR LV_UID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 2 AND SURR_WRES_ID = @ApproverWResID))
    ORDER BY LV_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadManagerDeptsStatus')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadManagerDeptsStatus'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadManagerDeptsStatus'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadManagerDeptsStatus
  @ApproverWResID int,
  @PeriodID int
AS

Declare @EGProjID int
/*select @EGProjID=PROJ_ID from MSP_PROJECTS where PROJ_TYPE=2*/

if (@ApproverWResID > 0)
 begin
   SELECT LV.LV_UID as DeptUID,LV.LV_VALUE as DeptName,TSD_STATUS,TSD_TIMESTAMP,TSA.WRES_ID as DeptManagerWResID,WR.RES_NAME as DeptManagerName
     FROM EPGP_LOOKUP_VALUES LV 
     left join EPG_TS_DEPTS on (@PeriodID = TSD_PRD_ID and LV.LV_UID = TSD_DEPT_UID)
     left join EPG_TS_APPROVERS TSA on (LV.LV_UID = TSA.CODE_UID)
     left join EPG_RESOURCES WR on (WR.WRES_ID = TSA.WRES_ID)
    WHERE (LV.LV_UID IN (select CODE_UID FROM EPG_TS_APPROVERS WHERE WRES_ID=@ApproverWResID) 
	OR LV.LV_UID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 2 AND SURR_WRES_ID = @ApproverWResID))
      AND LV.LOOKUP_UID = (SELECT ADM_DEPT_CODE FROM EPG_ADMIN)
   return
 end

SELECT LV.LV_UID as DeptUID,LV.LV_VALUE as DeptName,TSD_STATUS,TSD_TIMESTAMP,TSA.WRES_ID as DeptManagerWResID,WR.RES_NAME as DeptManagerName
  FROM EPGP_LOOKUP_VALUES LV 
  left join EPG_TS_DEPTS on (@PeriodID = TSD_PRD_ID and LV.LV_UID = TSD_DEPT_UID)
  left join EPG_TS_APPROVERS TSA on (LV.LV_UID = TSA.CODE_UID)
  left join EPG_RESOURCES WR on (WR.WRES_ID = TSA.WRES_ID)
 WHERE LV.LOOKUP_UID = (SELECT ADM_DEPT_CODE FROM EPG_ADMIN)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadManagerProjs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadManagerProjs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadManagerProjs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadManagerProjs
  @ApproverWResID int
AS
SELECT WP.WPROJ_ID
FROM EPGX_PROJECT_VERSIONS WP
LEFT JOIN EPGP_PROJECTS P ON (P.PROJECT_ID = WP.PROJECT_ID)
WHERE (P.PROJECT_PLAN_OWNER = @ApproverWResID 
     OR WP.WPROJ_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 3 AND SURR_WRES_ID = @ApproverWResID))
ORDER BY WP.WPROJ_ID

SELECT EP.PROJECT_ID
FROM EPGP_PROJECTS EP
WHERE (EP.PROJECT_MANAGER = @ApproverWResID 
     OR EP.PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 4 AND SURR_WRES_ID = @ApproverWResID))
ORDER BY EP.PROJECT_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadManagerResDepts')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadManagerResDepts'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadManagerResDepts'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadManagerResDepts
  @ApproverWResID int
AS
   SELECT LV_UID as DeptUID,LV_VALUE as DeptName
     FROM EPGP_LOOKUP_VALUES OC 
    WHERE (LV_UID IN (select CODE_UID FROM EPG_RES_MANAGERS WHERE WRES_ID=@ApproverWResID) 
       OR LV_UID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 5 AND SURR_WRES_ID = @ApproverWResID))
    ORDER BY LV_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadManagerResDeptsA')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadManagerResDeptsA'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadManagerResDeptsA'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadManagerResDeptsA
  @ApproverWResID int
AS
   SELECT LV_UID as DeptUID,LV_VALUE as DeptName, CANREAD, CANWRITE
     FROM EPGP_LOOKUP_VALUES OC
     Inner Join EPG_DEPT_MANAGERS M On OC.LV_UID=M.CODE_UID 
    WHERE WRES_ID=@ApproverWResID 
    ORDER BY LV_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadManagerResDeptsB')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadManagerResDeptsB'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadManagerResDeptsB'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadManagerResDeptsB
  @ApproverWResID int
AS
   SELECT LV_UID as DeptUID,LV_VALUE as DeptName
     FROM EPGP_LOOKUP_VALUES OC 
    WHERE (LV_UID IN (select CODE_UID FROM EPG_RES_MANAGERS WHERE WRES_ID=@ApproverWResID) 
       OR LV_UID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 5 AND SURR_WRES_ID = @ApproverWResID)
       OR LV_UID IN (SELECT CODE_UID FROM EPG_DEPT_MANAGERS WHERE WRES_ID = @ApproverWResID))
    ORDER BY LV_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadManagersCombinedResources')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadManagersCombinedResources'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadManagersCombinedResources'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadManagersCombinedResources
  @ApproverWResID int
AS
	SELECT DISTINCT WR.WRES_ID,WR.RES_NAME
	  FROM EPG_RESOURCES WR
	 WHERE WRES_INACTIVE = 0 AND WRES_IS_RESOURCE = 1 
       AND WRES_DEPT IN (SELECT LV_UID FROM EPGP_LOOKUP_VALUES OC 
	                      WHERE (LV_UID IN (SELECT CODE_UID FROM EPG_TS_APPROVERS 
                                             WHERE WRES_ID=@ApproverWResID) 
	                         OR LV_UID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES 
                                             WHERE SURR_CONTEXT = 2 AND SURR_WRES_ID = @ApproverWResID)))
    UNION
	SELECT WR.WRES_ID,WR.RES_NAME
	  FROM EPG_RESOURCES WR
	 WHERE WRES_INACTIVE = 0 AND WRES_IS_RESOURCE = 1 
       AND WRES_RP_DEPT IN (SELECT LV_UID FROM EPGP_LOOKUP_VALUES OC 
                             WHERE (LV_UID IN (select CODE_UID FROM EPG_RES_MANAGERS 
                                                WHERE WRES_ID=@ApproverWResID) 
                                OR LV_UID IN (SELECT SURR_CONTEXT_VALUE FROM EPG_DELEGATES 
                                                WHERE SURR_CONTEXT = 5 AND SURR_WRES_ID = @ApproverWResID)))
	 ORDER BY WR.RES_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadMasterReq')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadMasterReq'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadMasterReq'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadMasterReq
/*  Read Requirements - i.e. Master rows for plan items
Public Enum ResCenterRequest
    ResourceValuesForDepts = 1  - for one or more depts
    ResourceValuesForPIsinDept = 2  - for one or more PIs, resources in one or more depts
    ResourceValuesForPIs = 3  - for one or more PIs - all resources
*/
   @Mode int,
   @sList NTEXT,
   @sPIList NTEXT
AS
if (@Mode = 1) 
 Begin
 Select cm.CMT_UID,cm.PROJECT_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_START_DATE,cm.CMT_FINISH_DATE,cm.CMT_RATE,rt.RT_NAME,
    cm.BC_UID,cm.RP_GROUP,cm.PARENT_BC_UID,CMT_MAJORCATEGORY,
    CAT_CODE_1,CAT_CODE_2,CAT_CODE_3,CAT_CODE_4,CAT_CODE_5,
    CAT_TEXT_1,CAT_TEXT_2,CAT_TEXT_3,CAT_TEXT_4,CAT_TEXT_5
  From EPG_RESOURCEPLANS cm
  Inner Join EPGP_PROJECTS ex On ex.PROJECT_ID=cm.PROJECT_ID and ex.PROJECT_MARKED_DELETION = 0
  Left Join EPGP_RP_CATEGORY_VALUES cv On cv.CAT_CMT_UID = cm.CMT_UID
  Inner Join dbo.EPG_FN_ConvertListToTable(@sList) LT1 on cm.CMT_DEPT=LT1.TokenVal
  Left Join EPGP_RATE_TYPES rt On cm.CMT_RATETYPE_UID=rt.RT_UID
  Where cm.CMT_STATUS=1
  Order By cm.Project_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_UID 
 End
 
else if (@Mode = 2)
 Begin
 Select cm.CMT_UID,cm.PROJECT_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_START_DATE,cm.CMT_FINISH_DATE,cm.CMT_RATE,rt.RT_NAME,
    cm.BC_UID,cm.RP_GROUP,cm.PARENT_BC_UID,CMT_MAJORCATEGORY,
    CAT_CODE_1,CAT_CODE_2,CAT_CODE_3,CAT_CODE_4,CAT_CODE_5,
    CAT_TEXT_1,CAT_TEXT_2,CAT_TEXT_3,CAT_TEXT_4,CAT_TEXT_5
  From EPG_RESOURCEPLANS cm
  Inner Join EPGP_PROJECTS ex On ex.PROJECT_ID=cm.PROJECT_ID and ex.PROJECT_MARKED_DELETION = 0
  Left Join EPGP_RP_CATEGORY_VALUES cv On cv.CAT_CMT_UID = cm.CMT_UID
  Inner Join dbo.EPG_FN_ConvertListToTable(@sList) LT1 on cm.CMT_DEPT=LT1.TokenVal
  Inner Join dbo.EPG_FN_ConvertListToTable(@sPIList) LT2 on cm.PROJECT_ID=LT2.TokenVal
  Left Join EPGP_RATE_TYPES rt On cm.CMT_RATETYPE_UID=rt.RT_UID
  Where cm.CMT_STATUS=1
  Order By cm.Project_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_UID  
 End
 
else if (@Mode = 3)
 Begin
 Select cm.CMT_UID,cm.PROJECT_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_START_DATE,cm.CMT_FINISH_DATE,cm.CMT_RATE,rt.RT_NAME,
    cm.BC_UID,cm.RP_GROUP,cm.PARENT_BC_UID,CMT_MAJORCATEGORY,
    CAT_CODE_1,CAT_CODE_2,CAT_CODE_3,CAT_CODE_4,CAT_CODE_5,
    CAT_TEXT_1,CAT_TEXT_2,CAT_TEXT_3,CAT_TEXT_4,CAT_TEXT_5
  From EPG_RESOURCEPLANS cm
  Inner Join EPGP_PROJECTS ex On ex.PROJECT_ID=cm.PROJECT_ID and ex.PROJECT_MARKED_DELETION = 0
  Left Join EPGP_RP_CATEGORY_VALUES cv On cv.CAT_CMT_UID = cm.CMT_UID
  Inner Join dbo.EPG_FN_ConvertListToTable(@sPIList) LT1 on cm.PROJECT_ID=LT1.TokenVal
  Left Join EPGP_RATE_TYPES rt On cm.CMT_RATETYPE_UID=rt.RT_UID
  Where cm.CMT_STATUS=1
  Order By cm.Project_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_UID  
 End

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadModelFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadModelFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadModelFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadModelFields
AS
Select t.FIELD_ID,t.FIELD_NAME as FieldName,0 as TABLE_ID,FIELD_SELECT
   From EPGT_FIELDS t
   Left Join  EPGP_RD_FIELDS r On t.FIELD_ID=r.FIELD_ID And CONTEXT_ID=101
     Where t.FIELD_ID IN (9901,9902,9904,9911,9928,9950,9922,9925,9930)
     UNION
  Select FA_FIELD_ID,FA_NAME as FieldName,FA_TABLE_ID as TABLE_ID,FIELD_SELECT
   From EPGC_FIELD_ATTRIBS
   Left Join  EPGP_RD_FIELDS On FIELD_ID=FA_FIELD_ID And CONTEXT_ID=101
   Where ((FA_TABLE_ID=201) And (FA_FORMAT=4 or FA_FORMAT=13 or FA_FORMAT=7)) Or
			(FA_TABLE_ID=202) Or
			(FA_TABLE_ID=203) Or
			(FA_TABLE_ID=205)			
   ORDER BY FieldName
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadModels')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadModels'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadModels'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadModels
AS
Select * From EPGP_MODEL_SCENARIOS 
   Order By Model_Name 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadModelVersions')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadModelVersions'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadModelVersions'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadModelVersions
  @ModelUID INT
AS
Select * From EPGP_MODEL_VERSIONS
   Where MODEL_UID=@ModelUID			
   ORDER BY MODEL_VERSION_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadMVsForResources')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadMVsForResources'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadMVsForResources'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadMVsForResources
   @FieldID int,
   @ResList NTEXT
AS
 Select WRES_ID,LV_VALUE 
  From EPGC_RESOURCE_MV_VALUES v
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@ResList) LT on WRES_ID=LT.TokenVal And MVR_FIELD_ID = @FieldID
  Left Join EPGP_LOOKUP_VALUES l On l.LV_UID = v.MVR_UID
  Order by WRES_ID,MVR_SEQ
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadMyPIWork')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadMyPIWork'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadMyPIWork'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadMyPIWork
   @WResID INT,
   @CutoffDate nvarchar(255),
   @sList NTEXT
AS  
SELECT P.PROJECT_ID,P.PROJECT_NAME,WORKITEM_NAME,WORKITEM_MAJORCATEGORY as MajorCategory,asn.WORKITEM_ID,t.WORKITEM_START_DATE,t.WORKITEM_FINISH_DATE,WORKITEM_CHARGENUMBER,WORKITEM_CHARGESTATUS
 FROM EPGP_PI_WORKITEM_ASSNS asn
INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on asn.PROJECT_ID=LT.TokenVal
INNER JOIN EPGP_PI_WORKITEMS t on t.PROJECT_ID = asn.PROJECT_ID and t.WORKITEM_ID = asn.WORKITEM_ID 
 LEFT JOIN EPGP_PROJECTS P ON (P.PROJECT_ID = asn.PROJECT_ID)
WHERE WRES_ID=@WRESID
  and WIRES_PERCENT_COMPLETE<100 and t.WORKITEM_START_DATE < Convert(Datetime,@CutoffDate,102)
order by P.PROJECT_NAME, t.WORKITEM_START_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadMyWork')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadMyWork'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadMyWork'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadMyWork
   @WResID INT,
   @CutoffDate nvarchar(255),
   @sList NTEXT
AS  
SELECT P.PROJECT_ID,P.PROJECT_NAME,PV_PROJECT_NAME AS PROJ_NAME,TASK_NAME,TASK_MAJORCATEGORY as MajorCategory,asn.WPROJ_ID,asn.TASK_UID,TASK_SUBPROJECTFILE,TASK_START_DATE,TASK_FINISH_DATE,TASK_CHARGENUMBER,TASK_CHARGESTATUS
 FROM EPGX_PROJECT_ASSN asn
INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on asn.WPROJ_ID=LT.TokenVal
INNER JOIN EPGX_PROJECT_VERSIONS v on v.WPROJ_ID = asn.WPROJ_ID
INNER JOIN EPGX_PROJECT_TASKS t on t.WPROJ_ID = asn.WPROJ_ID and t.TASK_UID = asn.TASK_UID 
 LEFT JOIN EPGP_PROJECTS P ON (P.PROJECT_ID = v.PROJECT_ID)
WHERE WRES_ID=@WRESID
  and (TASK_IS_EXTERNAL < 1 or TASK_IS_EXTERNAL Is NULL) and ASSN_PERCENTWORKCOMPLETE<100 and ASSN_START_DATE < Convert(Datetime,@CutoffDate,102)
order by P.PROJECT_NAME, TASK_START_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadNonWorkHours')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadNonWorkHours'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadNonWorkHours'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadNonWorkHours
  @WResID int,
  @FromDate DATETIME,
  @ToDate DATETIME
AS
SELECT NWH.*,NWI.NWI_NAME,NWI_CHARGESTATUS,WR.RES_NAME,WR2.RES_NAME as ENTEREDBY_RES_NAME
FROM EPG_NONWORK_HOURS NWH
LEFT JOIN EPG_NONWORK_ITEMS NWI ON (NWH.NWI_ID = NWI.NWI_ID)
LEFT JOIN EPG_RESOURCES WR ON (NWH.WRES_ID = WR.WRES_ID)
LEFT JOIN EPG_RESOURCES WR2 ON (NWH.NWH_ENTEREDBY_WRES_ID = WR2.WRES_ID)
WHERE NWH.WRES_ID = @WResID and NWH_DATE >= @FromDate and NWH_DATE < @ToDate
ORDER BY NWI.NWI_SEQ
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadNonWorkItems')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadNonWorkItems'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadNonWorkItems'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadNonWorkItems
  @WResID int
AS
if (@WResID = 0)
	SELECT * FROM EPG_NONWORK_ITEMS ORDER BY NWI_SEQ
else
	SELECT DISTINCT nwi.*
	FROM EPG_NONWORK_ITEMS nwi
	Left Join EPGP_DATA_SECURITY ds ON ds.DS_UID=nwi.NWI_ID AND DS_CONTEXT=3
	WHERE NWI_IS_ITEM<>1 OR ds.DS_UID is NULL
	UNION
	SELECT DISTINCT nwi.* 
	FROM EPG_NONWORK_ITEMS nwi
	Inner Join EPGP_DATA_SECURITY ds ON ds.DS_UID=nwi.NWI_ID AND DS_CONTEXT=3
	Left Join EPG_GROUP_MEMBERS gm ON ds.GROUP_ID=gm.GROUP_ID
	WHERE MEMBER_UID=@WResID
	ORDER BY NWI_SEQ
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadNotAvailGISpecs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadNotAvailGISpecs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadNotAvailGISpecs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadNotAvailGISpecs
  @VIEWTYPE INT,
  @VIEWSUBTYPE INT
AS
BEGIN
if (@VIEWTYPE = 3)
  begin
    Select Distinct GRAPHIND_UID
    From EPGT_VIEW_GRAPHIND_RULES gr
    Inner Join EPGT_FIELDS fl On fl.FIELD_ID = gr.GRULE_FIELD_ID
    Where GRULE_FIELD_ID > 0 And Not FIELD_IN_PORT_REGISTER > 0
    RETURN
  end
if (@VIEWTYPE = 2 and @VIEWSUBTYPE  = 0)
  begin
    Select Distinct GRAPHIND_UID
    From EPGT_VIEW_GRAPHIND_RULES gr
    Inner Join EPGT_FIELDS fl On fl.FIELD_ID = gr.GRULE_FIELD_ID
	Where GRULE_FIELD_ID > 0 And Not FIELD_IN_PROJ_BROWSER = 1
	RETURN
  end	
if (@VIEWTYPE = 2 and @VIEWSUBTYPE  > 0)
  begin
    Select Distinct GRAPHIND_UID
    From EPGT_VIEW_GRAPHIND_RULES gr
    Inner Join EPGT_FIELDS fl On fl.FIELD_ID = gr.GRULE_FIELD_ID
	Where GRULE_FIELD_ID > 0 And Not FIELD_IN_PROJLIST_BROWSER > 0
	RETURN
  end	
END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadNotesByContext')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadNotesByContext'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadNotesByContext'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadNotesByContext
  @Context int,
  @Index1 int,
  @Index2 int,
  @Index3 int
AS
if @Context = 1 OR @Context = 2 OR @Context = 3 OR @Context = 6
   begin
	/* Context 1 = Timesheet User - Index1 = TS_UID; Index2 = WRES_ID */
	/* Context 2 = Timesheet Department Admin - Index1 = TS_UID; Index2 = DEPT_UID */
	/* Context 3 = Timesheet Project Admin - Index1 = TS_UID; Index2 = WPROJ_ID */
	/* Context 6 = Timesheet Portfolio Admin - Index1 = TS_UID; Index2 = PROJECT_ID */
	SELECT NT.*,EPG_NOTES.*,WR2.RES_NAME as Author
	  FROM EPG_NOTE_THREADS NT
	  left join EPG_NOTES on NT_NOTE_UID = NOTE_UID
	  left join EPG_RESOURCES WR2 on NOTE_AUTHOR_WRES_ID = WR2.WRES_ID
	 WHERE NT_CONTEXT = @Context AND NT_INDEX_1 = @Index1 AND NT_INDEX_2 = @Index2
	 ORDER BY NOTE_TIMESTAMP DESC
   end
if @Context = 4 OR @Context = 5
   begin
	/* Context 4 = Task Status User - Index1 = TKS_UID */
	/* Context 5 = Task Status Project Admin - Index1 = TKS_UID */
	SELECT NT.*,EPG_NOTES.*,WR2.RES_NAME as Author
	  FROM EPG_NOTE_THREADS NT
	  left join EPG_NOTES on NT_NOTE_UID = NOTE_UID
	  left join EPG_RESOURCES WR2 on NOTE_AUTHOR_WRES_ID = WR2.WRES_ID
	 WHERE NT_CONTEXT = @Context AND NT_INDEX_1 = @Index1
	 ORDER BY NOTE_TIMESTAMP DESC
   end
if @Context = 7 OR @Context = 8 OR @Context = 9
   begin
	/* Context 7 = ResourcePlan PI Mgr - Index1 = PROJECT_ID; Index2 = DEPT_UID; Index3 = CMT_UID */
	/* Context 8 = ResourcePlan Res Mgr - Index1 = PROJECT_ID; Index2 = DEPT_UID; Index3 = CMT_UID */
	/* Context 9 = ResourcePlan Resourcer - Index1 = PROJECT_ID; Index2 = WRES_ID; Index3 = CMT_UID */
	SELECT NT.*,EPG_NOTES.*,WR2.RES_NAME as Author
	  FROM EPG_NOTE_THREADS NT
	  left join EPG_NOTES on NT_NOTE_UID = NOTE_UID
	  left join EPG_RESOURCES WR2 on NOTE_AUTHOR_WRES_ID = WR2.WRES_ID
	 WHERE NT_CONTEXT = @Context AND NT_INDEX_1 = @Index1 AND NT_INDEX_2 = @Index2 AND NT_INDEX_3 = @Index3
	 ORDER BY NOTE_TIMESTAMP DESC
   end
if @Context > 9
   begin
	/* ? */
	SELECT NT.*,EPG_NOTES.*,WR2.RES_NAME as Author
	  FROM EPG_NOTE_THREADS NT
	  left join EPG_NOTES on NT_NOTE_UID = NOTE_UID
	  left join EPG_RESOURCES WR2 on NOTE_AUTHOR_WRES_ID = WR2.WRES_ID
	 WHERE NT_CONTEXT = @Context AND NT_INDEX_1 = @Index1 AND NT_INDEX_2 = @Index2 AND NT_INDEX_3 = @Index3
	 ORDER BY NOTE_TIMESTAMP DESC
   end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadNotesByNoteThreadUIDs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadNotesByNoteThreadUIDs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadNotesByNoteThreadUIDs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadNotesByNoteThreadUIDs
   @sList NTEXT
AS
SELECT NT.*,EPG_NOTES.*,WR2.RES_NAME as Author
  FROM EPG_NOTE_THREADS NT
  left join EPG_NOTES on NT_NOTE_UID = NOTE_UID
  left join EPG_RESOURCES WR2 on NOTE_AUTHOR_WRES_ID = WR2.WRES_ID
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on NT_UID=LT.TokenVal 
 ORDER BY NOTE_TIMESTAMP DESC
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadNowPeriod')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadNowPeriod'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadNowPeriod'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadNowPeriod
 @Timenow nvarchar(255)
AS
select PRD_START_DATE,PRD_FINISH_DATE 
 from EPG_Periods 
 where CB_ID = 0 and PRD_START_DATE <= Convert(Datetime,@Timenow,102) and PRD_FINISH_DATE > Convert(Datetime,@Timenow,102)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadNWHForResource')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadNWHForResource'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadNWHForResource'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadNWHForResource
  @WResID int,
  @FromDate DATETIME,
  @ToDate DATETIME
AS
SELECT NWH_DATE,NWH_HOURS
FROM EPG_NONWORK_HOURS
WHERE WRES_ID = @WResID and NWH_DATE >= @FromDate and NWH_DATE <= @ToDate
ORDER BY NWH_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadNWUsedResources')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadNWUsedResources'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadNWUsedResources'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadNWUsedResources
  @NWID INT
AS
Select  Distinct Top 6 RES_NAME
 From EPG_NONWORK_HOURS nw
 Inner Join  EPG_RESOURCES wr On nw.WRES_ID = wr.WRES_ID 
 Where nw.NWI_ID = @NWID
 Order By RES_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPeriod')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPeriod'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPeriod'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPeriod
   @CalID INT,
   @FromPeriodID INT,
   @ToPeriodID INT
AS
SELECT PRD_ID,PRD_NAME,PRD_START_DATE,PRD_FINISH_DATE,PRD_CLOSED_DATE,PRD_CLOSED_NAME,PRD_IS_CLOSED
  FROM EPG_PERIODS
 WHERE CB_ID = @CalID AND PRD_ID >= @FromPeriodID AND PRD_ID <= @ToPeriodID
 ORDER BY PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPeriodByDate')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPeriodByDate'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPeriodByDate'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPeriodByDate
  @CalID INT,
  @FromDate DATETIME,
  @ToDate DATETIME
AS
SELECT PRD_ID,PRD_NAME,PRD_START_DATE,PRD_FINISH_DATE
  FROM EPG_PERIODS
 WHERE CB_ID = @CalID AND PRD_START_DATE >= @FromDate AND PRD_FINISH_DATE <= @ToDate
 ORDER BY PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPeriodCalendars')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPeriodCalendars'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPeriodCalendars'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPeriodCalendars
AS
SELECT CB_ID,CB_NAME
  FROM EPGP_COST_BREAKDOWNS
 ORDER BY CB_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPeriodList')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPeriodList'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPeriodList'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPeriodList
   @CalID INT,
   @sList NTEXT
AS
SELECT PRD_ID,PRD_NAME,PRD_START_DATE,PRD_FINISH_DATE,PRD_CLOSED_DATE,PRD_CLOSED_NAME,PRD_IS_CLOSED
  FROM EPG_PERIODS
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT2 on PRD_ID=LT2.TokenVal
 WHERE CB_ID = @CalID
 ORDER BY PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPeriodPortfolioCommitments')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPeriodPortfolioCommitments'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPeriodPortfolioCommitments'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPeriodPortfolioCommitments
   @Mode INT,
   @PeriodID INT,
   @sList NTEXT
AS
/* 
	Mode = 0 = sList contains PIs 
	Mode = 1 = sList contains WResIDs 
	Mode = 2 = sList contains DeptUIDs 
*/
if (@Mode = 0)
    BEGIN
	SELECT ch.CMT_UID,ch.PRD_ID,CMH_HOURS,cmt.PROJECT_ID,cmt.WRES_ID,WRES_RP_DEPT as DeptUID,cmt.CMT_STATUS as ParentStatus
	  FROM EPG_RESOURCEPLANS_HOURS ch
	  LEFT JOIN EPG_RESOURCEPLANS cmt on (cmt.CMT_UID = ch.CMT_UID AND cmt.CMT_STATUS = 256)
	  LEFT JOIN EPG_RESOURCES wr on (wr.WRES_ID = cmt.WRES_ID)
         INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT2 on cmt.PROJECT_ID=LT2.TokenVal
	 WHERE CMH_PENDING = 0 AND ch.PRD_ID = @PeriodID
	 ORDER BY cmt.WRES_ID,cmt.PROJECT_ID
    END
if (@Mode = 1)
    BEGIN
	SELECT ch.CMT_UID,ch.PRD_ID,CMH_HOURS,cmt.PROJECT_ID,cmt.WRES_ID,WRES_RP_DEPT as DeptUID,cmt.CMT_STATUS as ParentStatus
	  FROM EPG_RESOURCEPLANS_HOURS ch
	  LEFT JOIN EPG_RESOURCEPLANS cmt on (cmt.CMT_UID = ch.CMT_UID AND cmt.CMT_STATUS = 256)
	  LEFT JOIN EPG_RESOURCES wr on (wr.WRES_ID = cmt.WRES_ID)
         INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on wr.WRES_ID=LT.TokenVal
	 WHERE CMH_PENDING = 0 AND ch.PRD_ID = @PeriodID
	 ORDER BY cmt.WRES_ID,cmt.PROJECT_ID
    END
if (@Mode = 2)
    BEGIN
	SELECT ch.CMT_UID,ch.PRD_ID,CMH_HOURS,cmt.PROJECT_ID,cmt.WRES_ID,WRES_RP_DEPT as DeptUID,cmt.CMT_STATUS as ParentStatus
	  FROM EPG_RESOURCEPLANS_HOURS ch
	  LEFT JOIN EPG_RESOURCEPLANS cmt on (cmt.CMT_UID = ch.CMT_UID AND cmt.CMT_STATUS = 256)
	  LEFT JOIN EPG_RESOURCES wr on (wr.WRES_ID = cmt.WRES_ID)
         INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_RP_DEPT=LT.TokenVal
	 WHERE CMH_PENDING = 0 AND ch.PRD_ID = @PeriodID
	 ORDER BY cmt.WRES_ID,cmt.PROJECT_ID
    END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPeriods')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPeriods'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPeriods'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPeriods
   @CalID INT
AS
SELECT PRD_ID,PRD_NAME,PRD_START_DATE,PRD_FINISH_DATE,PRD_CLOSED_DATE,PRD_CLOSED_NAME,PRD_IS_CLOSED
  FROM EPG_PERIODS
 WHERE CB_ID = @CalID
 ORDER BY PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPeriodTimesheets')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPeriodTimesheets'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPeriodTimesheets'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPeriodTimesheets
   @Mode INT,
   @PeriodID INT,
   @TSManagerWResID INT
AS
if (@Mode = 0) 
 Begin
	SELECT TS_UID,PRD_ID,TS.WRES_ID,WR.RES_NAME
	   FROM EPG_TS_TIMESHEETS TS
	   left join EPG_RESOURCES WR on (TS.WRES_ID = WR.WRES_ID)
	  WHERE PRD_ID = @PeriodID
	  ORDER BY WR.RES_NAME
 End
else if (@Mode = 1)
 Begin
	SELECT TS_UID,PRD_ID,TS.WRES_ID,WR.RES_NAME
	   FROM EPG_TS_TIMESHEETS TS
	   left join EPG_RESOURCES WR on (TS.WRES_ID = WR.WRES_ID)
	  WHERE PRD_ID = @PeriodID 
		AND (WR.WRES_DEPT IN (SELECT CODE_UID FROM EPG_TS_APPROVERS WHERE WRES_ID = @TSManagerWResID) 
			OR WR.WRES_DEPT IN (SELECT SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 2 AND SURR_WRES_ID = @TSManagerWResID))
	  ORDER BY WR.RES_NAME
 End
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPICVwRole')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPICVwRole'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPICVwRole'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPICVwRole
  @ProjectID INT,
  @CTID INT,
  @CBID INT
AS
Select BD_PERIOD,BD_VALUE,cc.BC_UID,cc.CA_UID,cc.MC_UID
  From EPGP_COST_VALUES cv
  Inner Join EPGP_COST_CATEGORIES cc On cc.BC_UID = cv.BC_UID and Not (BC_ROLE Is NULL Or BC_ROLE = 0)
  Where CT_ID = @CTID and CB_ID = @CBID and PROJECT_ID = @ProjectID
  Order By cc.BC_UID,BD_PERIOD
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPIsMeInTeam')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPIsMeInTeam'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPIsMeInTeam'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPIsMeInTeam
   @WresID INT
AS
select pj.PROJECT_ID,PROJECT_CHARGENUMBER as ChargeNumber,PROJECT_CHARGESTATUS as ChargeStatus,RES_IN_PLAN 
  FROM EPGP_PROJECTS pj
 inner join EPGP_TEAMS pt on pj.PROJECT_ID = pt.PROJECT_ID and pt.WRES_ID=@WresID
 Where PROJECT_MARKED_DELETION=0 and left(PROJECT_CHARGESTATUS,1) In (''1'',''2'',''4'',''7'')
Union
select pj.PROJECT_ID,PROJECT_CHARGENUMBER as ChargeNumber,PROJECT_CHARGESTATUS as ChargeStatus,1 as RES_IN_PLAN 
  FROM EPGP_PROJECTS pj
 Where PROJECT_MARKED_DELETION=0 and left(PROJECT_CHARGESTATUS,1) = ''3''
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPITeam')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPITeam'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPITeam'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPITeam
   @PROJECT_ID INT
AS
select PROJECT_NAME as PROJ_NAME,RES_NAME
  FROM EPGP_PROJECTS
  Left join EPG_RESOURCES on EPGP_PROJECTS.PROJECT_MANAGER = WRES_ID 
 WHERE PROJECT_ID=@PROJECT_ID

 Select RES_NAME,WRES_EMAIL,WRES_USE_NT_LOGON,WRES_NT_ACCOUNT,RES_IN_PLAN
 from EPGP_TEAMS t
 right join EPG_RESOURCES r on r.WRES_ID = t.WRES_ID
 WHERE t.PROJECT_ID = @PROJECT_ID
 ORDER BY RES_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPIWSSInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPIWSSInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPIWSSInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPIWSSInfo
   @Mode INT,
   @sList NTEXT
AS
if (@Mode = 0)
    BEGIN
	SELECT PROJECT_ID,PROJECT_NAME,PROJECT_WSS_SITE,PROJECT_WSS_SERVER_ID
	  FROM EPGP_PROJECTS P
	 WHERE PROJECT_MARKED_DELETION = 0
    END
if (@Mode = 1)
    BEGIN
	SELECT PROJECT_ID,PROJECT_NAME,PROJECT_WSS_SITE,PROJECT_WSS_SERVER_ID
	  FROM EPGP_PROJECTS P
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT ON PROJECT_ID=LT.TokenVal
	 WHERE PROJECT_MARKED_DELETION = 0
    END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPlannedWorkByPeriod')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPlannedWorkByPeriod'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPlannedWorkByPeriod'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPlannedWorkByPeriod
   @Mode INT,
   @ProjID INT,
   @StartPeriodID INT
AS
-- Mode = 0 = Read Linked Project work . @ProjID = WProjID
-- Mode = 1 = Read WI work . @ProjID = ProjectID
if (@Mode = 0)
	SELECT PRD.PRD_ID,XPT.WRES_ID,TSWORK_MAJORCATEGORY as MajorCategory,SUM(TSWORK_WORK) as Hours
	  FROM EPGX_PROJECT_TSWORK XPT
	  JOIN EPG_PERIODS PRD on PRD.CB_ID=(select ADM_PORT_COMMITMENTS_CB_ID from EPG_ADMIN) and (XPT.TSWORK_DATE >= PRD.PRD_START_DATE and XPT.TSWORK_DATE <= PRD.PRD_FINISH_DATE)
	 WHERE WPROJ_ID = @ProjID AND PRD.PRD_ID >= @StartPeriodID AND WRES_ID > 0
	 GROUP BY XPT.WRES_ID,TSWORK_MAJORCATEGORY,PRD.PRD_ID
	 ORDER BY XPT.WRES_ID,TSWORK_MAJORCATEGORY,PRD.PRD_ID
else if (@Mode = 1)
	SELECT PRD.PRD_ID,XPT.WRES_ID,TSWORK_MAJORCATEGORY as MajorCategory,SUM(TSWORK_WORK) as Hours
	  FROM EPGP_PI_WORKITEM_TSWORK XPT
	  JOIN EPG_PERIODS PRD on PRD.CB_ID=(select ADM_PORT_COMMITMENTS_CB_ID from EPG_ADMIN) and (XPT.TSWORK_DATE >= PRD.PRD_START_DATE and XPT.TSWORK_DATE <= PRD.PRD_FINISH_DATE)
	 WHERE PROJECT_ID = @ProjID AND PRD.PRD_ID >= @StartPeriodID AND WRES_ID > 0
	 GROUP BY XPT.WRES_ID,TSWORK_MAJORCATEGORY,PRD.PRD_ID
	 ORDER BY XPT.WRES_ID,TSWORK_MAJORCATEGORY,PRD.PRD_ID

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPlannedWorkByPeriod_NAX')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPlannedWorkByPeriod_NAX'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPlannedWorkByPeriod_NAX'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPlannedWorkByPeriod_NAX
   @ProjID INT,
   @StartPeriodID INT
AS
	Declare @Work TABLE 
    (
		WRES_ID int,
		PRD_ID int, 
		WORK decimal(25,6)
	)
	INSERT INTO @Work ([PRD_ID],[WRES_ID],[WORK])
		SELECT PRD.PRD_ID,XPT.WRES_ID,SUM(TSWORK_WORK) as Hours
		  FROM EPGX_PROJECT_TSWORK XPT
		  JOIN EPG_PERIODS PRD on PRD.CB_ID=(select ADM_PORT_COMMITMENTS_CB_ID from EPG_ADMIN) and (XPT.TSWORK_DATE >= PRD.PRD_START_DATE and XPT.TSWORK_DATE <= PRD.PRD_FINISH_DATE)
		 WHERE WPROJ_ID = @ProjID AND PRD.PRD_ID >= @StartPeriodID AND WRES_ID > 0
		 GROUP BY XPT.WRES_ID,PRD.PRD_ID
		 ORDER BY XPT.WRES_ID,PRD.PRD_ID

	INSERT INTO @Work ([PRD_ID],[WRES_ID],[WORK])
		SELECT PRD.PRD_ID,XPT.WRES_ID,SUM(TSWORK_WORK) as Hours
		  FROM EPGP_PI_WORKITEM_TSWORK XPT
		  JOIN EPG_PERIODS PRD on PRD.CB_ID=(select ADM_PORT_COMMITMENTS_CB_ID from EPG_ADMIN) and (XPT.TSWORK_DATE >= PRD.PRD_START_DATE and XPT.TSWORK_DATE <= PRD.PRD_FINISH_DATE)
		 WHERE PROJECT_ID = @ProjID AND PRD.PRD_ID >= @StartPeriodID AND WRES_ID > 0
		 GROUP BY XPT.WRES_ID,PRD.PRD_ID
		 ORDER BY XPT.WRES_ID,PRD.PRD_ID

	INSERT INTO @Work ([PRD_ID],[WRES_ID],[WORK])
		Select PRD.PRD_ID,w.WRES_ID,SUM(PW_WORK) as Hours
		 From EPGP_PI_WORK1 w
		 JOIN EPG_PERIODS PRD on PRD.CB_ID=(select ADM_PORT_COMMITMENTS_CB_ID from EPG_ADMIN) and (PW_DATE >= PRD.PRD_START_DATE and PW_DATE <= PRD.PRD_FINISH_DATE)
		WHERE PROJECT_ID = @ProjID AND PRD.PRD_ID >= @StartPeriodID AND WRES_ID > 0   
		Group by w.WRES_ID,PRD.PRD_ID
		Order by w.WRES_ID,PRD.PRD_ID

	INSERT INTO @Work ([PRD_ID],[WRES_ID],[WORK])
		Select PRD.PRD_ID,w.WRES_ID,SUM(PW_WORK) as Hours
		 From EPGP_PI_WORK2 w
		 JOIN EPG_PERIODS PRD on PRD.CB_ID=(select ADM_PORT_COMMITMENTS_CB_ID from EPG_ADMIN) and (PW_DATE >= PRD.PRD_START_DATE and PW_DATE <= PRD.PRD_FINISH_DATE)
		WHERE PROJECT_ID = @ProjID AND PRD.PRD_ID >= @StartPeriodID AND WRES_ID > 0   
		Group by w.WRES_ID,PRD.PRD_ID
		Order by w.WRES_ID,PRD.PRD_ID

	Select PRD_ID,WRES_ID,SUM(WORK) as Hours from @Work
		Group by WRES_ID,PRD_ID
		Order by WRES_ID,PRD_ID

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPMActionChargeUIDs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPMActionChargeUIDs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPMActionChargeUIDs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPMActionChargeUIDs
   @ApproverWResID INT,
   @FromDate DATETIME
AS
-- NB CHG_CANNOT_DELETE flag is being used to filter out unused chargerows on a timesheet
SELECT CH.CHG_UID,TS.WRES_ID,WR.RES_NAME,PE.PRD_ID,PE.PRD_NAME,PE.PRD_IS_CLOSED,EP.PROJECT_NAME,CH.WPROJ_ID,TS.TS_SUBMITTED,TS.TS_TIMESTAMP,TS.TS_DEPT_STATUS,TS.TS_MANAGER_LOCKED,WR2.WRES_ID as ProjManagerWResID,WR2.RES_NAME as ProjManagerName
FROM EPG_TS_CHARGES CH 
LEFT JOIN EPGP_PROJECTS EP ON (EP.PROJECT_ID = CH.PROJECT_ID)
LEFT JOIN EPG_TS_TIMESHEETS TS ON (CH.TS_UID = TS.TS_UID)
LEFT JOIN EPG_RESOURCES WR ON (TS.WRES_ID = WR.WRES_ID)
LEFT JOIN EPG_PERIODS PE ON (PE.PRD_ID = TS.PRD_ID AND CB_ID = 0)
LEFT JOIN EPG_RESOURCES WR2 on (WR2.WRES_ID = EP.PROJECT_PLAN_OWNER)
LEFT JOIN EPG_TS_PROGRESS TSP on (CH.TS_UID = TSP.TS_UID AND CH.PROJECT_ID = TSP.PROJECT_ID AND CH.WPROJ_ID = TSP.WPROJ_ID AND CH.TASK_UID = TSP.TASK_UID)
WHERE ((EP.PROJECT_PLAN_OWNER = @ApproverWResID AND CH.WPROJ_ID > 0)
     OR EP.PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 3 AND SURR_WRES_ID = @ApproverWResID))
  AND TS_SUBMITTED > 0 AND CH.CHG_CANNOT_DELETE = 1 
  AND ((CHG_PROJ_STATUS <> 9 AND PE.PRD_IS_CLOSED <> 1) OR TSP.TSP_STATUS = 0 OR PE.PRD_START_DATE >= @FromDate)
union
SELECT CH.CHG_UID,TS.WRES_ID,WR.RES_NAME,PE.PRD_ID,PE.PRD_NAME,PE.PRD_IS_CLOSED,EP.PROJECT_NAME,CH.WPROJ_ID,TS.TS_SUBMITTED,TS.TS_TIMESTAMP,TS.TS_DEPT_STATUS,TS.TS_MANAGER_LOCKED,WR2.WRES_ID as ProjManagerWResID,WR2.RES_NAME as ProjManagerName
FROM EPG_TS_CHARGES CH 
LEFT JOIN EPGP_PROJECTS EP ON (EP.PROJECT_ID = CH.PROJECT_ID)
LEFT JOIN EPG_TS_TIMESHEETS TS ON (CH.TS_UID = TS.TS_UID)
LEFT JOIN EPG_RESOURCES WR ON (TS.WRES_ID = WR.WRES_ID)
LEFT JOIN EPG_PERIODS PE ON (PE.PRD_ID = TS.PRD_ID AND CB_ID = 0)
LEFT JOIN EPG_RESOURCES WR2 on (WR2.WRES_ID = EP.PROJECT_MANAGER)
LEFT JOIN EPG_TS_PROGRESS TSP on (CH.TS_UID = TSP.TS_UID AND CH.PROJECT_ID = TSP.PROJECT_ID AND CH.WPROJ_ID = TSP.WPROJ_ID AND CH.TASK_UID = TSP.TASK_UID)
WHERE ((EP.PROJECT_MANAGER = @ApproverWResID AND CH.WPROJ_ID = 0)
     OR EP.PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 4 AND SURR_WRES_ID = @ApproverWResID))
  AND TS_SUBMITTED > 0 AND CH.CHG_CANNOT_DELETE = 1 
  AND ((CHG_PROJ_STATUS <> 9 AND PE.PRD_IS_CLOSED <> 1) OR TSP.TSP_STATUS = 0 OR PE.PRD_START_DATE >= @FromDate)
ORDER BY PE.PRD_ID,EP.PROJECT_NAME,CH.WPROJ_ID,TS.WRES_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPortHasTasks')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPortHasTasks'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPortHasTasks'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPortHasTasks
   @Version INT,
   @sList NTEXT
AS
Select PROJECT_ID From EPGX_PROJECT_VERSIONS pv
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on PROJECT_ID=LT.TokenVal
  Where VERSION_ID=@Version
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPortHasWIs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPortHasWIs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPortHasWIs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPortHasWIs
   @sList NTEXT
AS
SELECT Distinct PROJECT_ID From EPGP_PI_WORKITEMS
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on PROJECT_ID=LT.TokenVal
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadPortTabs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadPortTabs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadPortTabs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadPortTabs
AS
   SELECT TAB_ID,TAB_NAME
	FROM EPGP_LAYOUT_PAGES 
	ORDER BY TAB_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadProgramFieldsInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadProgramFieldsInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadProgramFieldsInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadProgramFieldsInfo
AS
   SELECT * 
    FROM EPGP_FIELD_ATTRIBS
    Where (FA_FIELD_ID >= 11001 And FA_FIELD_ID <= 11020)
    Order By FA_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadProjectCreatePIs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadProjectCreatePIs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadProjectCreatePIs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadProjectCreatePIs
   @WResID int
AS
IF (@WResID = 1)
 BEGIN
	SELECT DISTINCT P.PROJECT_ID,PROJECT_NAME,0 as X_LINK
	FROM EPGP_PROJECTS P
	LEFT JOIN EPGX_PROJECT_VERSIONS PV ON P.PROJECT_ID = PV.PROJECT_ID
	WHERE PROJECT_MARKED_DELETION = 0 AND WPROJ_ID IS NULL
	UNION
	SELECT DISTINCT P.PROJECT_ID,PROJECT_NAME,1 as X_LINK
	FROM EPGP_PROJECTS P
	LEFT JOIN EPGX_PROJECT_VERSIONS PV ON P.PROJECT_ID = PV.PROJECT_ID
	WHERE PROJECT_MARKED_DELETION = 0 AND WPROJ_ID IS NOT NULL
	ORDER BY X_LINK,PROJECT_NAME
 END
ELSE
 BEGIN
	SELECT DISTINCT P.PROJECT_ID,PROJECT_NAME,0 as X_LINK
	FROM EPGP_PROJECTS P
	LEFT JOIN EPGX_PROJECT_VERSIONS PV ON P.PROJECT_ID = PV.PROJECT_ID
	WHERE PROJECT_MARKED_DELETION = 0 AND WPROJ_ID IS NULL
	AND (PROJECT_PLAN_OWNER = @WResID OR P.PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 3 AND SURR_WRES_ID = @WResID))
	UNION
	SELECT DISTINCT P.PROJECT_ID,PROJECT_NAME,1 as X_LINK
	FROM EPGP_PROJECTS P
	LEFT JOIN EPGX_PROJECT_VERSIONS PV ON P.PROJECT_ID = PV.PROJECT_ID
	WHERE PROJECT_MARKED_DELETION = 0 AND WPROJ_ID IS NOT NULL
	AND (PROJECT_PLAN_OWNER = @WResID OR P.PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 3 AND SURR_WRES_ID = @WResID))
	ORDER BY X_LINK,PROJECT_NAME
 END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadProjectsMeInTeam')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadProjectsMeInTeam'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadProjectsMeInTeam'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadProjectsMeInTeam
   @VersionID INT,
   @WresID INT
AS
select pv.WPROJ_ID,PV_CHARGENUMBER as ChargeNumber,PROJECT_PLAN_CHARGESTATUS as ChargeStatus,RES_IN_PLAN 
 FROM EPGP_PROJECTS pj	
 inner join EPGX_PROJECT_VERSIONS pv on pj.PROJECT_ID=pv.PROJECT_ID and pv.VERSION_ID=@VersionID
 inner join EPGX_PROJECT_RESOURCES pr on pr.WPROJ_ID = pv.WPROJ_ID and pr.WRES_ID=@WresID
 left join EPGP_TEAMS t on t.PROJECT_ID=pj.PROJECT_ID And t.WRES_ID=pr.WRES_ID
 Where left(PROJECT_PLAN_CHARGESTATUS,1) in (''1'',''2'',''3'',''4'',''6'',''7'')
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadProjectTeam')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadProjectTeam'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadProjectTeam'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadProjectTeam
   @WPROJ_ID INT
AS
select PROJECT_NAME AS PROJ_NAME,RES_NAME
 FROM EPGX_PROJECT_VERSIONS pv
 Left join EPGP_PROJECTS pr on (pv.PROJECT_ID = pr.PROJECT_ID) 
 Left join EPG_RESOURCES on (PROJECT_PLAN_OWNER = WRES_ID)
 WHERE WPROJ_ID=@WPROJ_ID

Select wr.WRES_ID,wr.RES_NAME,WRES_EMAIL,RES_IN_PLAN
 from EPGX_PROJECT_RESOURCES pr
 Inner join EPG_RESOURCES wr on pr.WRES_ID = wr.WRES_ID /*And WRES_IS_GENERIC<>1*/
 Right join EPGX_PROJECT_VERSIONS pv on pv.WPROJ_ID = pr.WPROJ_ID
 Left join EPGP_TEAMS t on t.PROJECT_ID=pv.PROJECT_ID And t.WRES_ID=pr.WRES_ID
 WHERE pr.WPROJ_ID = @WPROJ_ID
 ORDER BY wr.RES_NAME

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadProjectVersionInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadProjectVersionInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadProjectVersionInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadProjectVersionInfo
  @WPROJID INT
AS
SELECT PROJECT_NAME,VERSION_NAME,pv.*
  FROM EPGX_PROJECT_VERSIONS pv
  Inner Join EPGP_PROJECTS p On p.PROJECT_ID = pv.PROJECT_ID
  Inner Join EPGP_VERSIONS v On v.VERSION_ID = pv.VERSION_ID
  Where WPROJ_ID=@WPROJID 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadRate')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadRate'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadRate'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadRate
   @DeptUID INT,
   @CCRoleUID INT,
   @RateTypeUID INT,
   @RatePeriodID INT
AS
SELECT TOP 1 BA_RATE
  FROM EPGP_COST_BREAKDOWN_ATTRIBS
 WHERE CB_ID = (SELECT ADM_PORT_COMMITMENTS_CB_ID FROM EPG_ADMIN) 
   AND BA_BC_UID = @CCRoleUID
   AND BA_RATETYPE_UID = @RateTypeUID
   AND BA_PRD_ID = @RatePeriodID 
   AND (BA_CODE_UID = 0 OR BA_CODE_UID = @DeptUID)
 ORDER BY BA_CODE_UID DESC
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadRates')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadRates'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadRates'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadRates
AS
   SELECT *	FROM EPG_RATES 
	ORDER BY RT_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadRateTypes')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadRateTypes'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadRateTypes'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadRateTypes
AS
  Select *
   From EPGP_RATE_TYPES
   Order By RT_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadRateValues')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadRateValues'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadRateValues'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadRateValues
AS
 Select rc.RT_UID,RT_EFFECTIVE_DATE,RT_RATE,RT_OVERTIME_RATE  
  From EPG_RATE_VALUES rv
  left join EPG_RATES rc On rc.RT_UID=rv.RT_UID
  Order By RT_ID,RT_EFFECTIVE_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadRDCustomFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadRDCustomFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadRDCustomFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadRDCustomFields
  @UserID INT
AS
 Select FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE,FA_LOOKUP_UID
   From EPGP_RD_FIELDS
   Inner JOIN EPGC_FIELD_ATTRIBS ON FIELD_ID=FA_FIELD_ID
   Where CONTEXT_ID=1 And FIELD_SELECT=1
   ORDER BY FA_TABLE_ID,FIELD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadRDFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadRDFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadRDFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadRDFields
  @UserID INT
AS
  Select FA_FIELD_ID,FA_NAME,FA_TABLE_ID,FIELD_SELECT
   From EPGC_FIELD_ATTRIBS
   Left Join  EPGP_RD_FIELDS On FIELD_ID=FA_FIELD_ID And CONTEXT_ID=1
   Where (FA_TABLE_ID=101 Or FA_TABLE_ID=201 Or FA_TABLE_ID=202 Or FA_TABLE_ID=301 Or FA_TABLE_ID=302) And (FA_FORMAT=4 or FA_FORMAT=9)
   ORDER BY FA_TABLE_ID,FA_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResCFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResCFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResCFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResCFields
AS
   SELECT *
	FROM EPGC_FIELD_ATTRIBS
	Where FA_TABLE_ID>100 And FA_TABLE_ID<200
	ORDER BY FA_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResFieldInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResFieldInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResFieldInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResFieldInfo
   @sList NTEXT
AS
  SELECT *
    FROM EPGC_FIELD_ATTRIBS
    INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on FA_FIELD_ID=LT.TokenVal 
  
  SELECT *
    FROM EPGT_RES_FIELDS
    INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on FIELD_ID=LT.TokenVal 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourceAvail')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourceAvail'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourceAvail'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourceAvail
  @CalID int,
  @FromPeriodID int,
  @ToPeriodID int,
  @sList NTEXT
AS
SELECT WRES_ID,BD_PERIOD,CS_AVAIL,CS_OFF 
  From EPGP_CAPACITY_VALUES
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_ID=LT.TokenVal 
 WHERE CB_ID = @CalID AND BD_PERIOD >= @FromPeriodID AND BD_PERIOD <= @ToPeriodID
 Order By WRES_ID,BD_PERIOD
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourceData')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourceData'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourceData'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourceData
 @sList NTEXT
AS
  SELECT gr.WRES_ID,RES_NAME,WRES_DEPT,xr.BC_UID as CCUID,cc.BC_ROLE as RoleUID
   From EPG_RESOURCES gr
   INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_ID=LT.TokenVal 
   LEFT JOIN EPGP_COST_XREF xr ON gr.WRES_ID=xr.WRES_ID
   Left Join EPGP_COST_CATEGORIES cc ON cc.BC_UID=xr.BC_UID
   Order By RES_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourceInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourceInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourceInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourceInfo
   @WResID INT
AS
 SELECT RES_NAME,WRES_EMAIL
   FROM EPG_RESOURCES
  WHERE WRES_ID = @WResID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourceInfos')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourceInfos'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourceInfos'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourceInfos
   @WresID int
AS
 Select rs.*,xr.BC_UID as CCUID,cr.RT_UID 
  From EPG_RESOURCES rs
  LEFT JOIN EPGP_COST_XREF xr ON rs.WRES_ID=xr.WRES_ID
  LEFT JOIN EPGP_COST_RATES cr ON rs.WRES_ID=cr.WRES_ID And cr.TB_UID=0
  Where rs.WRES_ID=@WresID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourcePlans')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourcePlans'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourcePlans'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourcePlans
   @Mode INT,
   @ProjectID INT,
   @DeptUIDs NTEXT
AS
DECLARE @lCodeFieldID INT
SET @lCodeFieldID = dbo.EPG_FN_GetDeptCode()
if (@Mode = 0)
    BEGIN
	SELECT CMT.*,WR.RES_NAME as ResName,WR.WRES_INACTIVE as ResInactive,WR.WRES_RP_DEPT as ResDept,WR2.RES_NAME as PendingResName,WR2.WRES_INACTIVE as PendingResInactive,WR2.WRES_RP_DEPT as PendingResDept,CV.*
	  FROM EPG_RESOURCEPLANS CMT
	  LEFT JOIN EPG_RESOURCES WR ON (WR.WRES_ID = CMT.WRES_ID)
	  LEFT JOIN EPG_RESOURCES WR2 ON (WR2.WRES_ID = CMT.WRES_ID_PENDING)
	  LEFT JOIN EPGP_RP_CATEGORY_VALUES CV on (CMT.CMT_UID = CV.CAT_CMT_UID)
	 WHERE PROJECT_ID = @ProjectID AND PROJECT_ID NOT IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION <> 0)
	 ORDER BY RP_GROUP, CMT_STATUS
    END
if (@Mode = 1)
    BEGIN
	SELECT DISTINCT WR.RES_NAME as ResName,WR.WRES_INACTIVE as ResInactive,WR.WRES_RP_DEPT as ResDept,WR2.RES_NAME as PendingResName,WR2.WRES_INACTIVE as PendingResInactive,WR2.WRES_RP_DEPT as PendingResDept,CMT.*,CV.*
	  FROM EPG_RESOURCEPLANS CMT
	  LEFT JOIN EPG_RESOURCES WR ON (WR.WRES_ID = CMT.WRES_ID)
	  LEFT JOIN EPG_RESOURCES WR2 ON (WR2.WRES_ID = CMT.WRES_ID_PENDING)
	  LEFT JOIN EPGP_RP_CATEGORY_VALUES CV on (CMT.CMT_UID = CV.CAT_CMT_UID)
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@DeptUIDs) LT on CMT.CMT_DEPT=LT.TokenVal 
	 WHERE PROJECT_ID = @ProjectID AND PROJECT_ID NOT IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION <> 0)
	 ORDER BY RP_GROUP, CMT_STATUS
    END
if (@Mode = 2)
    BEGIN
	SELECT DISTINCT WR.RES_NAME as ResName,WR.WRES_INACTIVE as ResInactive,WR.WRES_RP_DEPT as ResDept,WR2.RES_NAME as PendingResName,WR2.WRES_INACTIVE as PendingResInactive,WR2.WRES_RP_DEPT as PendingResDept,CMT.*,CV.*
	  FROM EPG_RESOURCEPLANS CMT
	  LEFT JOIN EPGP_RP_CATEGORY_VALUES CV on (CMT.CMT_UID = CV.CAT_CMT_UID)
	  LEFT JOIN EPG_RESOURCES WR ON (WR.WRES_ID = CMT.WRES_ID)
	  LEFT JOIN EPG_RESOURCES WR2 ON (WR2.WRES_ID = CMT.WRES_ID_PENDING)
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@DeptUIDs) LT on CMT.CMT_DEPT=LT.TokenVal 
	 WHERE PROJECT_ID NOT IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION <> 0)
	 ORDER BY RP_GROUP, CMT_STATUS
    END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourcePlans_NAX')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourcePlans_NAX'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourcePlans_NAX'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourcePlans_NAX
   @Mode INT,
   @ProjectIDs NTEXT,
   @WResIDs NTEXT
AS
DECLARE @lCodeFieldID INT
SET @lCodeFieldID = dbo.EPG_FN_GetDeptCode()
if (@Mode = 0)
    BEGIN
	SELECT CMT.*,WR.RES_NAME as ResName,WR.WRES_INACTIVE as ResInactive,WR.WRES_RP_DEPT as ResDept,WR2.RES_NAME as PendingResName,WR2.WRES_INACTIVE as PendingResInactive,WR2.WRES_RP_DEPT as PendingResDept,CV.*,RPEN_UID
	  FROM EPG_RESOURCEPLANS CMT
	  LEFT JOIN EPG_RESOURCES WR ON (WR.WRES_ID = CMT.WRES_ID)
	  LEFT JOIN EPG_RESOURCES WR2 ON (WR2.WRES_ID = CMT.WRES_ID_PENDING)
	  LEFT JOIN EPGP_RP_CATEGORY_VALUES CV on (CMT.CMT_UID = CV.CAT_CMT_UID)
	  LEFT JOIN EPG_RPE_NOTES RN on (RN.RPEN_CMT_GUID = CMT.CMT_GUID AND RPEN_TO IS NULL)
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@ProjectIDs) LT2 on PROJECT_ID=LT2.TokenVal 
	 WHERE PROJECT_ID NOT IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION <> 0)
	 ORDER BY RP_GROUP, CMT_STATUS
    END
if (@Mode = 1)
    BEGIN
	 SELECT DISTINCT WR.RES_NAME as ResName,WR.WRES_INACTIVE as ResInactive,WR.WRES_RP_DEPT as ResDept,WR2.RES_NAME as PendingResName,WR2.WRES_INACTIVE as PendingResInactive,WR2.WRES_RP_DEPT as PendingResDept,CMT.*,CV.*,RPEN_UID
	   FROM EPG_RESOURCEPLANS CMT
	   LEFT JOIN EPGP_RP_CATEGORY_VALUES CV on (CMT.CMT_UID = CV.CAT_CMT_UID)
	   LEFT JOIN EPG_RESOURCES WR ON (WR.WRES_ID = CMT.WRES_ID)
	   LEFT JOIN EPG_RESOURCES WR2 ON (WR2.WRES_ID = CMT.WRES_ID_PENDING)
	   LEFT JOIN EPG_RPE_NOTES RN on (RN.RPEN_CMT_GUID = CMT.CMT_GUID AND RPEN_TO IS NULL)
      WHERE RP_GROUP IN (SELECT RP_GROUP FROM EPG_RESOURCEPLANS CMT INNER JOIN dbo.EPG_FN_ConvertListToTable(@WResIDs) LT ON (CMT.WRES_ID=LT.TokenVal OR CMT.WRES_ID_PENDING=LT.TokenVal))
        AND PROJECT_ID NOT IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION <> 0) AND CMT.CMT_PRIVATE <> 1
      ORDER BY RP_GROUP, CMT_STATUS
    END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourcePlansHours')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourcePlansHours'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourcePlansHours'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourcePlansHours
   @StartPeriodID INT,
   @sList NTEXT
AS
SELECT *
  FROM EPG_RESOURCEPLANS_HOURS
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on CMT_UID=LT.TokenVal 
 WHERE PRD_ID >= @StartPeriodID
 ORDER BY CMT_UID,CMH_PENDING,PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourceRates')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourceRates'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourceRates'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourceRates
AS
Select cr.WRES_ID,RES_NAME,RT_UID 
 From EPGP_COST_RATES cr                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
 Left Join EPG_RESOURCES wr On wr.WRES_ID = cr.WRES_ID
 Where TB_UID=0 And WRES_IS_RESOURCE=1
 Order By RES_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourcesByNoteContext')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourcesByNoteContext'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourcesByNoteContext'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourcesByNoteContext
  @Context int,
  @Index1 int,
  @Index2 int,
  @Index3 int
AS
if @Context = 1
   begin
	/* Context 1 = Timesheet User - Index1 = TS_UID; Index2 = WRES_ID */
	SELECT WRES_ID,RES_NAME,WRES_EMAIL
	  FROM EPG_RESOURCES WR
	 WHERE WRES_ID = @Index2
	 ORDER BY WRES_ID
   end
if @Context = 2
   begin
	/* Context 2 = Timesheet Department Admin - Index1 = TS_UID; Index2 = DEPT_UID */
	SELECT WRES_ID,RES_NAME,WRES_EMAIL
	  FROM EPG_RESOURCES WR
	 WHERE WRES_ID IN (SELECT WRES_ID FROM EPG_TS_APPROVERS WHERE CODE_UID = @Index2)
	 ORDER BY WRES_ID
   end
if @Context = 3
   begin
	/* Context 3 = Timesheet Project Admin - Index1 = TS_UID; Index2 = WPROJ_ID */
	SELECT WRES_ID,RES_NAME,WRES_EMAIL
	  FROM EPG_RESOURCES WR
	 WHERE WRES_ID IN (SELECT PROJECT_PLAN_OWNER FROM EPGP_PROJECTS WHERE PROJECT_ID IN (SELECT PROJECT_ID FROM EPGX_PROJECT_VERSIONS WHERE WPROJ_ID = @Index2 AND VERSION_ID = (SELECT ADM_TS_PROJ_VERSION_ID FROM EPG_ADMIN)))
	 ORDER BY WRES_ID
   end
if @Context = 4
   begin
	/* Context 4 = Task Status User - Index1 = TKS_UID */
	SELECT WRES_ID,RES_NAME,WRES_EMAIL
	  FROM EPG_RESOURCES WR
	 WHERE WRES_ID IN (SELECT WRES_ID FROM EPG_TASKSTATUS WHERE TKS_UID = @Index1)
	 ORDER BY WRES_ID
   end
if @Context = 5
   begin
	/* Context 5 = Task Status Project Admin - Index1 = TKS_UID */
	SELECT WRES_ID,RES_NAME,WRES_EMAIL
	  FROM EPG_RESOURCES WR
	 WHERE WRES_ID IN (SELECT PROJECT_PLAN_OWNER FROM EPGP_PROJECTS WHERE PROJECT_ID IN (SELECT PROJECT_ID FROM EPGX_PROJECT_VERSIONS WHERE WPROJ_ID IN (SELECT WPROJ_ID FROM EPG_TASKSTATUS WHERE TKS_UID = @Index1) AND VERSION_ID = (SELECT ADM_TS_PROJ_VERSION_ID FROM EPG_ADMIN)))
	 ORDER BY WRES_ID
   end
if @Context = 6
   begin
	/* Context 6 = Timesheet Portfolio Admin - Index1 = TS_UID; Index2 = PROJECT_ID */
	SELECT WRES_ID,RES_NAME,WRES_EMAIL
	  FROM EPG_RESOURCES WR
	 WHERE WRES_ID IN (SELECT PROJECT_MANAGER FROM EPGP_PROJECTS WHERE PROJECT_ID = @Index2)
	 ORDER BY WRES_ID
   end
if @Context = 7
   begin
	/* Context 7 = Resource Plan PI Manager - Index1 = PROJECT_ID; Index2 = PROJECT_ID; Index3 = oPlanRow.UID */
	SELECT WRES_ID,RES_NAME,WRES_EMAIL
	  FROM EPG_RESOURCES WR
	 WHERE WRES_ID IN (SELECT PROJECT_MANAGER FROM EPGP_PROJECTS WHERE PROJECT_ID = @Index2)
	 ORDER BY WRES_ID
   end
if @Context = 8
   begin
	/* Context 8 = Resource Plan Res Manager - Index1 = PROJECT_ID; Index2 = DeptUID; Index3 = oPlanRow.UID */
	SELECT WRES_ID,RES_NAME,WRES_EMAIL
	  FROM EPG_RESOURCES WR
	 WHERE WRES_ID IN (SELECT WRES_ID FROM EPG_RES_MANAGERS WHERE CODE_UID = @Index2)
	 ORDER BY WRES_ID
   end
if @Context = 9
   begin
	/* Context 9 = Resource Plan Resource - Index1 = PROJECT_ID; Index2 = WResID; Index3 = oPlanRow.UID */
	SELECT WRES_ID,RES_NAME,WRES_EMAIL
	  FROM EPG_RESOURCES WR
	 WHERE WRES_ID = @Index2
	 ORDER BY WRES_ID
   end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourcesNonWorkPeriodSummaries')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourcesNonWorkPeriodSummaries'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourcesNonWorkPeriodSummaries'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourcesNonWorkPeriodSummaries
   @WResIDs NTEXT,
   @PeriodID INT
AS

SELECT PRD_ID,NWH.WRES_ID,SUM(NWH_HOURS) as NonWorkHours,NWI.NWI_NAME,NWI.NWI_ID,WRES_DEPT as DeptUID
  FROM EPG_PERIODS
 INNER JOIN EPG_NONWORK_HOURS NWH ON (NWH_DATE >= PRD_START_DATE and NWH_DATE <= PRD_FINISH_DATE)
 INNER JOIN EPG_NONWORK_ITEMS NWI ON (NWH.NWI_ID = NWI.NWI_ID)
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@WResIDs) LT on NWH.WRES_ID=LT.TokenVal 
  LEFT JOIN EPG_RESOURCES wr on (wr.WRES_ID = NWH.WRES_ID)
 WHERE CB_ID = (SELECT ADM_PORT_COMMITMENTS_CB_ID FROM EPG_ADMIN) AND PRD_ID = @PeriodID
 GROUP BY PRD_ID,NWH.WRES_ID,NWI.NWI_NAME,NWI.NWI_ID,WRES_DEPT
 ORDER BY NWH.WRES_ID,PRD_ID,NWI.NWI_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourcesWorkA')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourcesWorkA'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourcesWorkA'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourcesWorkA
   @CalID INT,
   @StartPeriodID INT,
   @WResIDs NTEXT
AS
SELECT PRD_ID,WR.WRES_ID,CS_AVAIL as AvailableHours,CS_OFF as OffHours 
  FROM EPG_PERIODS
 INNER JOIN EPGP_CAPACITY_VALUES CV ON (BD_PERIOD = PRD_ID) and (CV.CB_ID=@CalID)
  LEFT JOIN EPG_RESOURCES WR ON (WR.WRES_ID = CV.WRES_ID)
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@WResIDs) LT on WR.WRES_ID=LT.TokenVal 
 WHERE EPG_PERIODS.CB_ID = @CalID AND PRD_ID >= @StartPeriodID
 ORDER BY WR.WRES_ID,PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourcesWorkB')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourcesWorkB'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourcesWorkB'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourcesWorkB
   @ExcludeProjectID INT,
   @StartPeriodID INT,
   @WResIDs NTEXT
AS
SELECT RPH.PRD_ID,RP.WRES_ID,SUM(CMH_HOURS) as CommittedHours
  FROM EPG_RESOURCEPLANS_HOURS RPH
  LEFT JOIN EPG_RESOURCEPLANS RP ON (RP.CMT_UID = RPH.CMT_UID)
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@WResIDs) LT on RP.WRES_ID=LT.TokenVal
 WHERE RP.PROJECT_ID <> @ExcludeProjectID AND RPH.PRD_ID >= @StartPeriodID AND RP.CMT_STATUS = 256 AND RPH.CMH_PENDING = 0
   AND RP.PROJECT_ID NOT IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION <> 0)
 GROUP BY RPH.PRD_ID,RP.WRES_ID
 ORDER BY RP.WRES_ID,RPH.PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourcesWorkC')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourcesWorkC'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourcesWorkC'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourcesWorkC
   @CalID INT,
   @StartPeriodID INT,
   @WResIDs NTEXT
AS
SELECT PRD_ID,NWH.WRES_ID,SUM(NWH_HOURS) as NonWorkHours
  FROM EPG_PERIODS
 INNER JOIN EPG_NONWORK_HOURS NWH ON (NWH_DATE >= PRD_START_DATE and NWH_DATE <= PRD_FINISH_DATE)
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@WResIDs) LT on NWH.WRES_ID=LT.TokenVal 
 WHERE CB_ID = @CalID AND PRD_ID >= @StartPeriodID
 GROUP BY PRD_ID,NWH.WRES_ID
 ORDER BY NWH.WRES_ID,PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourceValues')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourceValues'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourceValues'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourceValues
   @sList NTEXT
AS
SELECT WRES_ID,RES_NAME
  FROM EPG_RESOURCES
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on WRES_ID=LT.TokenVal 
  ORDER BY WRES_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResourceWorkPattern')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResourceWorkPattern'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResourceWorkPattern'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResourceWorkPattern
  @WResID INT
AS
/* returns 4 recordsets */

DECLARE @GroupID INT

SELECT TOP 1 @GroupID = GROUP_ID
  FROM EPG_GROUPS
 WHERE GROUP_ENTITY = 10 AND GROUP_ID IN (SELECT GM.GROUP_ID FROM EPG_GROUP_MEMBERS GM WHERE MEMBER_UID = @WResID)

SELECT *
  FROM EPG_GROUPS
 WHERE GROUP_ID = @GroupID

SELECT WH.*
  FROM EPG_GROUP_WEEKLYHOURS WH 
 WHERE GROUP_ID = @GroupID

SELECT TOP 1 @GroupID = GROUP_ID
  FROM EPG_GROUPS
 WHERE GROUP_ENTITY = 11 AND GROUP_ID IN (SELECT GM.GROUP_ID FROM EPG_GROUP_MEMBERS GM WHERE MEMBER_UID = @WResID)

SELECT *
  FROM EPG_GROUPS
 WHERE GROUP_ID = @GroupID

SELECT GNWH.*
  FROM EPG_GROUP_NONWORK_HOURS GNWH 
  LEFT JOIN EPG_GROUP_NONWORK_ITEMS GNWI ON GNWI.GROUP_ID = GNWH.GROUP_ID
 WHERE GNWH.GROUP_ID = @GroupID
 ORDER BY NWH_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResRates')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResRates'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResRates'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResRates
AS
 Select *  
  From EPGP_COST_RATES
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadResView')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadResView'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadResView'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadResView
  @ViewUID INT
AS
SELECT VF.FIELD_ID,FIELD_TITLE,FIELD_ALIGN,FIELD_HIDDEN,FIELD_FROZEN,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT
  FROM EPG_VIEW_FIELDS VF
  left join EPGT_RES_FIELDS RF on (VF.FIELD_ID = RF.FIELD_ID)
 WHERE VIEW_UID = @ViewUID
 ORDER BY FIELD_COL_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadRPCategories')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadRPCategories'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadRPCategories'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadRPCategories
AS
SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_FORMAT,FA.*
  FROM EPGT_FIELDS
  left join EPGP_FIELD_ATTRIBS FA on (FIELD_ID = FA_FIELD_ID)
 WHERE FIELD_ID >= 9300 AND FIELD_ID <= 9309 AND FIELD_VIEWTYPE_ID = 4
 ORDER BY FIELD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadRPCustomFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadRPCustomFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadRPCustomFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadRPCustomFields
AS
SELECT FIELD_ID,FIELD_NAME,FA_NAME
  FROM EPGP_FIELD_ATTRIBS
  Inner join EPGT_FIELDS on (FIELD_ID = FA_FIELD_ID)
  Where (FIELD_ID >= 9300 And FIELD_ID <= 9309)
  ORDER BY FIELD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadScheduledWork')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadScheduledWork'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadScheduledWork'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadScheduledWork
/*  Read work, both from Project Schedule AND WIs
Public Enum ResCenterRequest
    ResourceValuesForDepts = 1  - for one or more depts - but a list of resources passed in here - all PIs
    ResourceValuesForPIsinDept = 2  - for one or more PIs, resources in one or more depts - but a list of resources passed in here
    ResourceValuesForPIs = 3  - for one or more PIs - all resources 
    ResourceValuesForResources = 4  - for one or more resources - all PIs
*/
   @Mode INT,
   @FromDate DATETIME,
   @ToDate DATETIME,
   @sList NTEXT,
   @sRList NTEXT
AS
 DECLARE @CurrentVersion INT
 SELECT @CurrentVersion = ADM_DEFAULT_PROJ_VERSION_ID FROM EPG_ADMIN
if (@Mode = 1 Or @Mode = 4) 
 Begin
  Select ''TASK'' as SOURCE,v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,RES_IN_PLAN 
  From EPGX_PROJECT_TSWORK w
  Inner Join EPGX_PROJECT_VERSIONS v On v.WPROJ_ID=w.WPROJ_ID And VERSION_ID=@CurrentVersion
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = v.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN EPGP_TEAMS t On t.PROJECT_ID = v.PROJECT_ID and t.WRES_ID=w.WRES_ID 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where w.WRES_ID > 0 and TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate 
 UNION ALL
  Select ''WI'' as SOURCE,w.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,RES_IN_PLAN 
  From EPGP_PI_WORKITEM_TSWORK w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN EPGP_TEAMS t On t.PROJECT_ID = p.PROJECT_ID and t.WRES_ID=w.WRES_ID 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate 
 UNION ALL
  Select ''W1'' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN 
  From EPGP_PI_WORK1 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate 
 UNION ALL
  Select ''W2'' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN 
  From EPGP_PI_WORK2 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate 
  Order by v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE
 End
else if (@Mode = 2)
 Begin
  Select ''TASK'' as SOURCE,v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,1 as RES_IN_PLAN 
  From EPGX_PROJECT_TSWORK w
  Inner Join EPGX_PROJECT_VERSIONS v On v.WPROJ_ID=w.WPROJ_ID And VERSION_ID=@CurrentVersion
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = v.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN EPGP_TEAMS t On t.PROJECT_ID = v.PROJECT_ID and t.WRES_ID=w.WRES_ID 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where w.WRES_ID > 0 and TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate 
 UNION ALL
  Select ''WI'' as SOURCE,w.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,RES_IN_PLAN 
  From EPGP_PI_WORKITEM_TSWORK w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN EPGP_TEAMS t On t.PROJECT_ID = p.PROJECT_ID and t.WRES_ID=w.WRES_ID
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate 
 UNION ALL
  Select ''W1'' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN 
  From EPGP_PI_WORK1 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate 
 UNION ALL
  Select ''W2'' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN 
  From EPGP_PI_WORK2 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate 
  Order by v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE
 End
 
else if (@Mode = 3)
 Begin
  Select ''TASK'' as SOURCE,v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,1 as RES_IN_PLAN
  From EPGX_PROJECT_TSWORK w
  Inner Join EPGX_PROJECT_VERSIONS v On v.WPROJ_ID=w.WPROJ_ID And VERSION_ID=@CurrentVersion
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = v.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  Where w.WRES_ID > 0 and TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate 
 UNION ALL
  Select ''WI'' as SOURCE,w.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE,TSWORK_WORK,1 as RES_IN_PLAN
  From EPGP_PI_WORKITEM_TSWORK w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  Where TSWORK_DATE >= @FromDate And TSWORK_DATE <= @ToDate  
  UNION ALL
  Select ''W1'' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN
  From EPGP_PI_WORK1 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate  
   UNION ALL
  Select ''W2'' as SOURCE,w.PROJECT_ID,w.WRES_ID,PW_MAJORCATEGORY,PW_DATE,PW_WORK,1 as RES_IN_PLAN
  From EPGP_PI_WORK2 w
  Inner Join EPGP_PROJECTS p on p.PROJECT_ID = w.PROJECT_ID and p.PROJECT_MARKED_DELETION = 0
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT1 on p.PROJECT_ID=LT1.TokenVal
  Where PW_DATE >= @FromDate And PW_DATE <= @ToDate
  Order by v.PROJECT_ID,w.WRES_ID,TSWORK_MAJORCATEGORY,TSWORK_DATE
 End
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadSiteMap')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadSiteMap'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadSiteMap'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadSiteMap
   @WResID INT
AS
-- WRES_ID = null = System menu item
-- WRES_ID = 0    = Corporate added menu item
-- WRES_ID > 0    = User added menu item
if (@WResID = 1) 
   SELECT * FROM EPG_SITEMAP
    WHERE WRES_ID IS NULL OR WRES_ID = 0 OR WRES_ID = 1
    ORDER BY SM_ID
else
   SELECT * FROM EPG_SITEMAP
    WHERE (PERM_UID IS NULL OR PERM_UID IN (SELECT PERM_UID FROM EPG_GROUP_PERMISSIONS WHERE GROUP_ID IN (SELECT GROUP_ID FROM EPG_GROUP_MEMBERS WHERE MEMBER_UID = @WResID)))
      AND (WRES_ID IS NULL OR WRES_ID = 0 OR WRES_ID = @WResID)
    ORDER BY SM_ID

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadSiteMapAdminPages')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadSiteMapAdminPages'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadSiteMapAdminPages'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadSiteMapAdminPages
   @WResID INT
AS
-- WRES_ID = null = System menu item
-- WRES_ID = 0    = Corporate added menu item
-- WRES_ID > 0    = User added menu item
if (@WResID = 1) 
   SELECT * FROM EPG_SITEMAP
    WHERE (WRES_ID IS NULL OR WRES_ID = 0 OR WRES_ID = 1) AND SM_CONTEXT IS NOT NULL
    ORDER BY SM_CONTEXT
else
   SELECT * FROM EPG_SITEMAP
    WHERE (PERM_UID IS NULL OR PERM_UID IN (SELECT PERM_UID FROM EPG_GROUP_PERMISSIONS WHERE GROUP_ID IN (SELECT GROUP_ID FROM EPG_GROUP_MEMBERS WHERE MEMBER_UID = @WResID)))
      AND (WRES_ID IS NULL OR WRES_ID = 0 OR WRES_ID = @WResID) AND SM_CONTEXT IS NOT NULL
    ORDER BY SM_CONTEXT

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadSiteMapForUser')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadSiteMapForUser'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadSiteMapForUser'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadSiteMapForUser
   @WResID INT
AS
   SELECT * FROM EPG_SITEMAP
    WHERE (WRES_ID = @WResID)
    ORDER BY SM_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadStageFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadStageFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadStageFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadStageFields
AS
   SELECT FIELD_ID,STAGE_ID,SF_REQUIRED,SF_EDITABLE,SF_VISIBLE
	FROM EPGP_STAGE_FIELDS 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadStageFollowers')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadStageFollowers'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadStageFollowers'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadStageFollowers
AS
   SELECT WORKFLOW_PATH,STAGE_ID,NEXT_STAGE_ID
	FROM EPGP_NEXT_STAGES 
	ORDER BY WORKFLOW_PATH,NEXT_SEQ
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadStages')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadStages'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadStages'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadStages
AS
   SELECT STAGE_ID,STAGE_NAME
	FROM EPGP_STAGES 
	ORDER BY STAGE_SEQ
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadStageUsedProjects')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadStageUsedProjects'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadStageUsedProjects'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadStageUsedProjects
  @Stage INT
AS
Select Top 3 PROJECT_NAME
 From EPGP_PROJECTS
 Where PROJECT_STAGE_ID = @Stage
 Order By PROJECT_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadStatusPeriod')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadStatusPeriod'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadStatusPeriod'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadStatusPeriod
  @CalID INT,
  @FromDate DATETIME
AS
SELECT Top 1 PRD_ID FROM EPG_PERIODS
 WHERE CB_ID = @CalID AND PRD_FINISH_DATE > @FromDate
 ORDER BY PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadSystemColors')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadSystemColors'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadSystemColors'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadSystemColors
   @Context INT
AS
SELECT *
  FROM EPG_SYSTEM_COLORS
 WHERE REF_CONTEXT = @Context
 ORDER BY REF_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTabFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTabFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTabFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTabFields
AS
  SELECT lf.FIELD_ID,TAB_ID,TABGROUP_ID,LF_SEQ,LF_NAME,LF_DESC,FIELD_NAME,FA_NAME,FA_TABLE_ID
    FROM EPGP_LAYOUT_FIELDS lf
     LEFT join EPGT_FIELDS fl on lf.FIELD_ID = fl.FIELD_ID
     LEFT join EPGC_FIELD_ATTRIBS pa on lf.FIELD_ID = pa.FA_FIELD_ID
    ORDER BY TAB_ID,TABGROUP_ID,LF_SEQ
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTabGroups')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTabGroups'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTabGroups'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTabGroups
AS
   SELECT TAB_ID,TABGROUP_ID,TABGROUP_NAME
	FROM EPGP_LAYOUT_GROUPS 
	ORDER BY TAB_ID,TABGROUP_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTableRowRange')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTableRowRange'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTableRowRange'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTableRowRange
  @sTable NTEXT,
  @sOrderByClause NTEXT,
  @intStartRow int,
  @intEndRow int
AS
 
DECLARE @query AS NVARCHAR(MAX);

set @query = ''WITH pages AS (SELECT ROW_NUMBER() OVER('' + convert(nvarchar(MAX),@sOrderByClause) + '') as RowNumber, * FROM '' + convert(nvarchar(MAX),@sTable) + '') '' + 
''SELECT * FROM pages WHERE RowNumber BETWEEN '' + convert(nvarchar,@intStartRow) + '' AND '' + convert(nvarchar,@intEndRow);

execute(@query)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTargetColors')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTargetColors'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTargetColors'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTargetColors
  @BDUID int
AS
SELECT BAND_ID, BAND_BOT,BAND_TOP,BAND_BACKCOLOR,BAND_NAME
  From EPGT_VIEW_BUDSPEC_BAND
 WHERE BUDSP_UID = @BDUID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTaskStatusApprovalProjects')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTaskStatusApprovalProjects'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTaskStatusApprovalProjects'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTaskStatusApprovalProjects
  @ApproverWResID int
AS
SELECT WPROJ_ID,PV_PROJECT_NAME,P.PROJECT_ID,P.PROJECT_NAME
  FROM EPGX_PROJECT_VERSIONS XPV
  LEFT JOIN EPGP_PROJECTS P ON (P.PROJECT_ID = XPV.PROJECT_ID)
 WHERE (PROJECT_PLAN_OWNER = @ApproverWResID 
    OR XPV.PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 3 AND SURR_WRES_ID = @ApproverWResID))
   AND XPV.VERSION_ID = (SELECT ADM_TS_PROJ_VERSION_ID FROM EPG_ADMIN)
ORDER BY PV_PROJECT_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTaskStatusFieldValuesRows')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTaskStatusFieldValuesRows'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTaskStatusFieldValuesRows'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTaskStatusFieldValuesRows
   @WPROJ_ID INT,
   @TASK_UID INT,
   @WRES_ID INT
AS
    SELECT P.PROJECT_ID,P.PROJECT_NAME,PPS.PV_PROJECT_NAME as PROJ_NAME,TASK.TASK_NAME,WRP.RES_NAME,TASK.TASK_START_DATE,TASK.TASK_FINISH_DATE,TASK.TASK_ACT_WORK,TASK.TASK_REM_WORK
      FROM EPGX_PROJECT_VERSIONS PPS
      LEFT JOIN EPGP_PROJECTS P ON (P.PROJECT_ID = PPS.PROJECT_ID)
      left join EPG_RESOURCES WRP on (WRP.WRES_ID = @WRES_ID)
      left join EPGX_PROJECT_TASKS TASK on (TASK.WPROJ_ID = PPS.WPROJ_ID AND TASK_UID = @TASK_UID)
     WHERE PPS.WPROJ_ID = @WPROJ_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTaskStatusNotesInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTaskStatusNotesInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTaskStatusNotesInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTaskStatusNotesInfo
   @Context int,
   @sList NTEXT
AS
SELECT NT_INDEX_1 as TKS_UID,NOTE_AUTHOR_ROLE
  FROM EPG_NOTE_THREADS
  left join EPG_NOTES on NT_NOTE_UID = NOTE_UID
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on NT_INDEX_1=LT.TokenVal 
  WHERE NT_CONTEXT = @Context
order by NT_INDEX_1,NOTE_TIMESTAMP DESC
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTaskStatusRows')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTaskStatusRows'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTaskStatusRows'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTaskStatusRows
   @Mode INT,
   @sList NTEXT
AS
/* 
	Mode = 0 = Get current rows for sList Resources 
	Mode = 1 = Get history rows for sList Resources 
	Mode = 2 = Get current rows for sList Projects 
	Mode = 3 = Get history rows for sList Projects 
*/

if (@Mode = 0)
  begin
    SELECT TKS.*,PIS.PROJECT_ID,PIS.PROJECT_NAME,PPS.PV_PROJECT_NAME,TASK.TASK_NAME,WRP.RES_NAME,TASK.TASK_START_DATE,TASK.TASK_FINISH_DATE,TASK.TASK_ACT_WORK,TASK.TASK_REM_WORK,PT.*
      FROM EPG_TASKSTATUS TKS
      LEFT JOIN EPGX_PROJECT_VERSIONS PPS ON (PPS.WPROJ_ID = TKS.WPROJ_ID)
	  left join EPGP_PROJECTS PIS on (PIS.PROJECT_ID = PPS.PROJECT_ID)
      left join EPG_RESOURCES WRP on (TKS.WRES_ID = WRP.WRES_ID)
      left join EPGX_PROJECT_TASKS TASK on (TASK.WPROJ_ID = TKS.WPROJ_ID AND TASK.TASK_UID = TKS.TASK_UID)
      left join EPG_PROJ_TASKS PT on (PT_WPROJ_ID = TKS.WPROJ_ID AND PT_TASK_UID = TKS.TASK_UID)
     INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on TKS.WRES_ID=LT.TokenVal
     WHERE TKS.TKS_STATUS <> 1
     ORDER BY TKS.TKS_ID
  end

if (@Mode = 1)
  begin
    SELECT TKS.*,PIS.PROJECT_ID,PIS.PROJECT_NAME,PPS.PV_PROJECT_NAME,TASK.TASK_NAME,WRP.RES_NAME,TASK.TASK_START_DATE,TASK.TASK_FINISH_DATE,TASK.TASK_ACT_WORK,TASK.TASK_REM_WORK,PT.*
      FROM EPG_TASKSTATUS TKS
      LEFT JOIN EPGX_PROJECT_VERSIONS PPS ON (PPS.WPROJ_ID = TKS.WPROJ_ID)
	  left join EPGP_PROJECTS PIS on (PIS.PROJECT_ID = PPS.PROJECT_ID)
      left join EPG_RESOURCES WRP on (TKS.WRES_ID = WRP.WRES_ID)
      left join EPGX_PROJECT_TASKS TASK on (TASK.WPROJ_ID = TKS.WPROJ_ID AND TASK.TASK_UID = TKS.TASK_UID)
      left join EPG_PROJ_TASKS PT on (PT_WPROJ_ID = TKS.WPROJ_ID AND PT_TASK_UID = TKS.TASK_UID)
     INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on TKS.WRES_ID=LT.TokenVal
     WHERE TKS.TKS_STATUS = 1
     ORDER BY TKS.TKS_ID
  end

if (@Mode = 2)
  begin
    SELECT TKS.*,PIS.PROJECT_ID,PIS.PROJECT_NAME,PPS.PV_PROJECT_NAME,TASK.TASK_NAME,WRP.RES_NAME,TASK.TASK_START_DATE,TASK.TASK_FINISH_DATE,TASK.TASK_ACT_WORK,TASK.TASK_REM_WORK,PT.*
      FROM EPG_TASKSTATUS TKS
      LEFT JOIN EPGX_PROJECT_VERSIONS PPS ON (PPS.WPROJ_ID = TKS.WPROJ_ID)
	  left join EPGP_PROJECTS PIS on (PIS.PROJECT_ID = PPS.PROJECT_ID)
      left join EPG_RESOURCES WRP on (TKS.WRES_ID = WRP.WRES_ID)
      left join EPGX_PROJECT_TASKS TASK on (TASK.WPROJ_ID = TKS.WPROJ_ID AND TASK.TASK_UID = TKS.TASK_UID)
      left join EPG_PROJ_TASKS PT on (PT_WPROJ_ID = TKS.WPROJ_ID AND PT_TASK_UID = TKS.TASK_UID)
     INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on TKS.WPROJ_ID=LT.TokenVal
     WHERE TKS.TKS_STATUS <> 1
     ORDER BY PROJECT_NAME,TKS.WRES_ID,TKS.TASK_UID
   end

if (@Mode = 3)
  begin
    SELECT TKS.*,PIS.PROJECT_ID,PIS.PROJECT_NAME,PPS.PV_PROJECT_NAME,TASK.TASK_NAME,WRP.RES_NAME,TASK.TASK_START_DATE,TASK.TASK_FINISH_DATE,TASK.TASK_ACT_WORK,TASK.TASK_REM_WORK,PT.*
      FROM EPG_TASKSTATUS TKS
      LEFT JOIN EPGX_PROJECT_VERSIONS PPS ON (PPS.WPROJ_ID = TKS.WPROJ_ID)
	  left join EPGP_PROJECTS PIS on (PIS.PROJECT_ID = PPS.PROJECT_ID)
      left join EPG_RESOURCES WRP on (TKS.WRES_ID = WRP.WRES_ID)
      left join EPGX_PROJECT_TASKS TASK on (TASK.WPROJ_ID = TKS.WPROJ_ID AND TASK.TASK_UID = TKS.TASK_UID)
      left join EPG_PROJ_TASKS PT on (PT_WPROJ_ID = TKS.WPROJ_ID AND PT_TASK_UID = TKS.TASK_UID)
     INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on TKS.WPROJ_ID=LT.TokenVal
     WHERE TKS.TKS_STATUS = 1
     ORDER BY PROJECT_NAME,TKS.WRES_ID,TKS.TASK_UID
  end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTimerJobs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTimerJobs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTimerJobs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTimerJobs
AS
SELECT JT.*, R.RES_NAME,
	case When (JOT_NEXT_RUN IS NULL) Then ''2030-01-01'' 
         Else JOT_NEXT_RUN End as SortDate  
  FROM EPG_JOBS_TIMER JT
  LEFT JOIN EPG_RESOURCES R ON JT.WRES_ID = R.WRES_ID
 ORDER BY SortDate 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTimesheet')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTimesheet'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTimesheet'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTimesheet
   @WResID INT,
   @PeriodID INT
AS
BEGIN
if (@PeriodID = 0)
 begin
	/* instead of ROWCOUNT 1 could use TOP 1 in select */
    set ROWCOUNT 1
    SELECT TS_UID,PRD_ID,TS_SUBMITTED,TS_SUBMITTED_DATE,TS_SUBMITTED_WRES_ID,TS_DEPT_STATUS,TS_DEPT_DATE,TS_DEPT_WRES_ID,TS_MANAGER_LOCKED,TS_TIMESTAMP,TS_DEPT_UID,TS_DEPT_NAME,TSD_STATUS,WRS.RES_NAME as SubmitUserName,WRD.RES_NAME as DeptUserName
      FROM EPG_TS_TIMESHEETS TS
      left join EPG_TS_DEPTS on (PRD_ID = TSD_PRD_ID and TS_DEPT_UID = TSD_DEPT_UID)
      left join EPG_RESOURCES WRS on (TS_SUBMITTED_WRES_ID = WRS.WRES_ID)
      left join EPG_RESOURCES WRD on (TS_DEPT_WRES_ID = WRS.WRES_ID)
     WHERE TS.WRES_ID = @WResID
  ORDER BY TS_TIMESTAMP DESC
  RETURN
 end

SELECT TS_UID,PRD_ID,TS_SUBMITTED,TS_SUBMITTED_DATE,TS_SUBMITTED_WRES_ID,TS_DEPT_STATUS,TS_DEPT_DATE,TS_DEPT_WRES_ID,TS_MANAGER_LOCKED,TS_TIMESTAMP,TS_DEPT_UID,TS_DEPT_NAME,TSD_STATUS,WRS.RES_NAME as SubmitUserName,WRD.RES_NAME as DeptUserName
   FROM EPG_TS_TIMESHEETS TS
   left join EPG_TS_DEPTS on (PRD_ID = TSD_PRD_ID and TS_DEPT_UID = TSD_DEPT_UID)
   left join EPG_RESOURCES WRS on (TS_SUBMITTED_WRES_ID = WRS.WRES_ID)
   left join EPG_RESOURCES WRD on (TS_DEPT_WRES_ID = WRS.WRES_ID)
  WHERE TS.WRES_ID = @WResID AND PRD_ID = @PeriodID

END
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTimesheetAggregateHours')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTimesheetAggregateHours'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTimesheetAggregateHours'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTimesheetAggregateHours
  @TSUID INT
AS
SELECT PROJECT_ID, WPROJ_ID, TASK_UID, NWI_ID, SUM(AH_NORMALHOURS) as NormalHours, SUM(AH_OVERTIMEHOURS) as OvertimeHours 
FROM EPG_TS_ACTUALHOURS AH
LEFT JOIN EPG_TS_CHARGES CH ON (CH.CHG_UID = AH.CHG_UID)
WHERE TS_UID = @TSUID
 GROUP BY PROJECT_ID, WPROJ_ID, TASK_UID, NWI_ID
 ORDER BY PROJECT_ID, WPROJ_ID, TASK_UID, NWI_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSActualHoursForNonWork')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSActualHoursForNonWork'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSActualHoursForNonWork'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSActualHoursForNonWork
   @FromDate DATETIME,
   @ToDate DATETIME,
   @ExcludePeriodID int,
   @WResID int,
   @NonWorkID int
AS

SELECT AH_NORMALHOURS,AH_OVERTIMEHOURS
 FROM EPG_TS_ACTUALHOURS AH
 LEFT JOIN EPG_TS_CHARGES CH ON (AH.CHG_UID = CH.CHG_UID)
 LEFT JOIN EPG_TS_TIMESHEETS TS ON (CH.TS_UID = TS.TS_UID)
 WHERE TS.WRES_ID = @WResID
 AND CH.NWI_ID = @NonWorkID
 AND TS.PRD_ID <> @ExcludePeriodID
 AND AH_DATE >= @FromDate 
 AND AH_DATE < @ToDate
UNION ALL
SELECT PA_NORMALHOURS as AH_NORMALHOURS,PA_OVERTIMEHOURS as AH_OVERTIMEHOURS
 FROM EPG_TS_PRIOR_ACTUALS PA
 WHERE PA.WRES_ID = @WResID
 AND PA.NWI_ID = @NonWorkID

SELECT SUM(NWH_HOURS) as CommittedHours
  FROM EPG_NONWORK_HOURS NWH
  LEFT JOIN EPG_NONWORK_ITEMS NWI ON (NWI.NWI_ID = NWH.NWI_ID)
 WHERE WRES_ID = @WResID
 AND NWI.NWI_ID = @NonWorkID
 AND NWH_DATE >= @FromDate 
 AND NWH_DATE < @ToDate
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSActualHoursForPI')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSActualHoursForPI'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSActualHoursForPI'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSActualHoursForPI
   @ExcludePeriodID int,
   @WResID int,
   @ProjectID int
AS

SELECT AH_NORMALHOURS,AH_OVERTIMEHOURS,CH.TASK_UID
 FROM EPG_TS_ACTUALHOURS AH
 LEFT JOIN EPG_TS_CHARGES CH ON (AH.CHG_UID = CH.CHG_UID)
 LEFT JOIN EPG_TS_TIMESHEETS TS ON (CH.TS_UID = TS.TS_UID)
 WHERE TS.WRES_ID = @WResID
 AND CH.PROJECT_ID = @ProjectID
 AND TS.PRD_ID <> @ExcludePeriodID
UNION ALL
SELECT PA_NORMALHOURS as AH_NORMALHOURS,PA_OVERTIMEHOURS as AH_OVERTIMEHOURS,PA.TASK_UID
 FROM EPG_TS_PRIOR_ACTUALS PA
 WHERE PA.WRES_ID = @WResID
 AND PA.PROJECT_ID = @ProjectID

SELECT SUM(CMH_HOURS) as CommittedHours
  FROM EPG_RESOURCEPLANS_HOURS CMH
  LEFT JOIN EPG_RESOURCEPLANS CMT ON (CMT.CMT_UID = CMH.CMT_UID AND CMH_PENDING = 0)
 WHERE WRES_ID = @WResID
 AND PROJECT_ID = @ProjectID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSActualHoursForTask')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSActualHoursForTask'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSActualHoursForTask'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSActualHoursForTask
   @WResID int,
   @WProjID int,
   @TaskUID int
AS

SELECT AH_DATE,AH_NORMALHOURS,AH_OVERTIMEHOURS,TSP_STATUS
 FROM EPG_TS_ACTUALHOURS AH
 LEFT JOIN EPG_TS_CHARGES CH ON (AH.CHG_UID = CH.CHG_UID)
 LEFT JOIN EPG_TS_TIMESHEETS TS ON (CH.TS_UID = TS.TS_UID)
 LEFT JOIN EPG_TS_PROGRESS TP ON (CH.TS_UID = TP.TS_UID AND CH.WPROJ_ID = TP.WPROJ_ID AND CH.TASK_UID = TP.TASK_UID AND TP.WPROJ_ID > 0)
 WHERE TS.WRES_ID = @WResID
 AND CH.WPROJ_ID = @WProjID
 AND CH.TASK_UID = @TaskUID
-- AND TSP_STATUS = 1
ORDER BY AH_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSActualHoursForWorkItem')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSActualHoursForWorkItem'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSActualHoursForWorkItem'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSActualHoursForWorkItem
   @WResID int,
   @ProjectID int,
   @TaskUID int
AS

SELECT AH_DATE,AH_NORMALHOURS,AH_OVERTIMEHOURS,TSP_STATUS
 FROM EPG_TS_ACTUALHOURS AH
 LEFT JOIN EPG_TS_CHARGES CH ON (AH.CHG_UID = CH.CHG_UID)
 LEFT JOIN EPG_TS_TIMESHEETS TS ON (CH.TS_UID = TS.TS_UID)
 LEFT JOIN EPG_TS_PROGRESS TP ON (CH.TS_UID = TP.TS_UID AND CH.PROJECT_ID = TP.PROJECT_ID AND CH.TASK_UID = TP.TASK_UID AND TP.WPROJ_ID = 0)
 WHERE TS.WRES_ID = @WResID
 AND CH.PROJECT_ID = @ProjectID
 AND CH.TASK_UID = @TaskUID
 AND CH.WPROJ_ID = 0
-- AND TSP_STATUS = 1
ORDER BY AH_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSActualHoursForWProj')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSActualHoursForWProj'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSActualHoursForWProj'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSActualHoursForWProj
   @ExcludePeriodID int,
   @WResID int,
   @WProjID int
AS

SELECT AH_NORMALHOURS,AH_OVERTIMEHOURS,CH.TASK_UID
 FROM EPG_TS_ACTUALHOURS AH
 LEFT JOIN EPG_TS_CHARGES CH ON (AH.CHG_UID = CH.CHG_UID)
 LEFT JOIN EPG_TS_TIMESHEETS TS ON (CH.TS_UID = TS.TS_UID)
 WHERE TS.WRES_ID = @WResID
 AND CH.WPROJ_ID = @WProjID
 AND TS.PRD_ID <> @ExcludePeriodID
UNION ALL
SELECT PA_NORMALHOURS as AH_NORMALHOURS,PA_OVERTIMEHOURS as AH_OVERTIMEHOURS,PA.TASK_UID
 FROM EPG_TS_PRIOR_ACTUALS PA
 WHERE PA.WRES_ID = @WResID
 AND PA.WPROJ_ID = @WProjID

SELECT SUM(CMH_HOURS) as CommittedHours
  FROM EPG_RESOURCEPLANS_HOURS CMH
  LEFT JOIN EPG_RESOURCEPLANS CMT ON (CMT.CMT_UID = CMH.CMT_UID AND CMH_PENDING = 0)
  LEFT JOIN EPGX_PROJECT_VERSIONS PV ON (PV.PROJECT_ID = CMT.PROJECT_ID)
 WHERE WRES_ID = @WResID
 AND WPROJ_ID = @WProjID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSAdjustmentDetails')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSAdjustmentDetails'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSAdjustmentDetails'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSAdjustmentDetails
   @TSUID INT
AS
   SELECT EP.PROJECT_NAME,EPW.WORKITEM_NAME,PPS.PV_PROJECT_NAME,PTS.TASK_NAME,PT.PT_PROJ_NAME,PT.PT_TASK_NAME,NWI.NWI_NAME,TSH.*,CH.*
     FROM EPG_TS_ADJUSTMENTHOURS TSH
     LEFT JOIN EPG_TS_ADJUSTMENTS TSA ON (TSA.ADJ_UID = TSH.ADJ_UID)
     LEFT JOIN EPG_TS_TIMESHEETS TS ON (TSH.TS_UID = TS.TS_UID)
     LEFT JOIN EPG_TS_CHARGES CH ON (TSH.TS_UID = CH.TS_UID AND TSH.CHG_UID = CH.CHG_UID)
     LEFT JOIN EPGX_PROJECT_VERSIONS PPS ON (PPS.WPROJ_ID = CH.WPROJ_ID AND CH.WPROJ_ID > 0)
     LEFT JOIN EPGX_PROJECT_TASKS PTS ON (PTS.WPROJ_ID = CH.WPROJ_ID AND PTS.TASK_UID = CH.TASK_UID AND CH.TASK_UID > 0)
     LEFT JOIN EPG_PROJ_TASKS PT ON (PT_WPROJ_ID = CH.WPROJ_ID AND PT_TASK_UID = CH.TASK_UID)
     LEFT JOIN EPG_NONWORK_ITEMS NWI ON (NWI.NWI_ID = CH.NWI_ID AND CH.NWI_ID > 0)
     LEFT JOIN EPGP_PROJECTS EP ON (EP.PROJECT_ID = CH.PROJECT_ID AND CH.PROJECT_ID > 0)
     LEFT JOIN EPGP_PI_WORKITEMS EPW ON (EPW.PROJECT_ID = CH.PROJECT_ID AND EPW.WORKITEM_ID = CH.TASK_UID)
    WHERE TSH.TS_UID  = @TSUID
    ORDER BY TSH.CHG_UID,TSH.ADJ_UID,TSH.ADH_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSAdjustmentSummaries')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSAdjustmentSummaries'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSAdjustmentSummaries'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSAdjustmentSummaries
   @Mode INT,
   @TSManagerWResID INT,
   @MaxRows INT
AS
if (@Mode = 0) 
 Begin
   SET ROWCOUNT @MaxRows
   SELECT TSA.ADJ_UID,TS.TS_UID,ADJ_TIMESTAMP,TS.PRD_ID,PRD.PRD_NAME,ADJ_ADMIN_WRES_ID, WR.RES_NAME as AdminName,TS.WRES_ID,WR2.RES_NAME as OwnerName,ADH_HOURS_FROM,ADH_HOURS_TO,ADH_OT_HOURS_FROM,ADH_OT_HOURS_TO,ADJ_COMMENTS
     FROM EPG_TS_ADJUSTMENTS TSA
     LEFT JOIN EPG_TS_ADJUSTMENTHOURS TSH ON (TSA.ADJ_UID = TSH.ADJ_UID)
     LEFT JOIN EPG_RESOURCES WR ON (TSA.ADJ_ADMIN_WRES_ID = WR.WRES_ID)
     LEFT JOIN EPG_TS_TIMESHEETS TS ON (TSH.TS_UID = TS.TS_UID)
     LEFT JOIN EPG_PERIODS PRD ON (PRD.PRD_ID = TS.PRD_ID AND PRD.CB_ID = 0)
     LEFT JOIN EPG_RESOURCES WR2 on (TS.WRES_ID = WR2.WRES_ID)
    ORDER BY TSA.ADJ_UID DESC, TS.TS_UID 
   SET ROWCOUNT 0
 End
else if (@Mode = 1)
 Begin
   SET ROWCOUNT @MaxRows
   SELECT TSA.ADJ_UID,TS.TS_UID,ADJ_TIMESTAMP,TS.PRD_ID,PRD.PRD_NAME,ADJ_ADMIN_WRES_ID, WR.RES_NAME as AdminName,TS.WRES_ID,WR2.RES_NAME as OwnerName,ADH_HOURS_FROM,ADH_HOURS_TO,ADH_OT_HOURS_FROM,ADH_OT_HOURS_TO,ADJ_COMMENTS
     FROM EPG_TS_ADJUSTMENTS TSA
     LEFT JOIN EPG_TS_ADJUSTMENTHOURS TSH ON (TSA.ADJ_UID = TSH.ADJ_UID)
     LEFT JOIN EPG_RESOURCES WR ON (TSA.ADJ_ADMIN_WRES_ID = WR.WRES_ID)
     LEFT JOIN EPG_TS_TIMESHEETS TS ON (TSH.TS_UID = TS.TS_UID)
     LEFT JOIN EPG_PERIODS PRD ON (PRD.PRD_ID = TS.PRD_ID AND PRD.CB_ID = 0)
     LEFT JOIN EPG_RESOURCES WR2 on (TS.WRES_ID = WR2.WRES_ID)
	WHERE (WR2.WRES_DEPT IN (SELECT CODE_UID FROM EPG_TS_APPROVERS WHERE WRES_ID = @TSManagerWResID) 
			OR WR2.WRES_DEPT IN (SELECT SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 2 AND SURR_WRES_ID = @TSManagerWResID))
    ORDER BY TSA.ADJ_UID DESC, TS.TS_UID 
   SET ROWCOUNT 0
 End
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSCategories')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSCategories'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSCategories'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSCategories
AS
SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_FORMAT,FA.*
  FROM EPGT_FIELDS
  left join EPGP_FIELD_ATTRIBS FA on (FIELD_ID = FA_FIELD_ID)
 WHERE FIELD_ID >= 9100 AND FIELD_ID <= 9109 AND FIELD_VIEWTYPE_ID = 1
 ORDER BY FIELD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSChargeRowActualHours')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSChargeRowActualHours'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSChargeRowActualHours'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSChargeRowActualHours
   @ChargeUID INT
AS
SELECT AH_DATE,AH_NORMALHOURS,AH_OVERTIMEHOURS
  FROM EPG_TS_ACTUALHOURS
 WHERE CHG_UID = @ChargeUID
 ORDER BY AH_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSChargeRows')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSChargeRows'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSChargeRows'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSChargeRows
   @Mode  INT,
   @sList NTEXT
AS
--   @Mode = 0 means sList = comma separated list of TS_UIDs
--   @Mode = 1 means sList = comma separated list of CHG_UIDs
if (@Mode = 0)
  begin
--	SELECT CH.*,PIS.PROJECT_NAME,PTS.TASK_NAME,PTS.TASK_START_DATE,PTS.TASK_FINISH_DATE,PTS.TASK_ACT_WORK,PTS.TASK_REM_WORK,WRP.RES_NAME as CHG_PROJ_RES_NAME,CHG_ADJUSTED,CV.*,TSP_PCT_COMP,TSP_REM_WORK,TSP_EXPECTED_FINISH_DATE,TSP_STATUS
	SELECT CH.*,PIS.PROJECT_NAME,WPV.PV_PROJECT_NAME,PTS.TASK_NAME,PTS.TASK_START_DATE,PTS.TASK_FINISH_DATE,PTS.TASK_ACT_WORK,PTS.TASK_REM_WORK,WRP.RES_NAME as CHG_PROJ_RES_NAME,CHG_ADJUSTED,CV.*,TSP_PCT_COMP,TSP_REM_WORK,TSP_EXPECTED_FINISH_DATE,TSP_STATUS
	 FROM EPG_TS_CHARGES CH
	  left join EPGX_PROJECT_VERSIONS WPV on (WPV.WPROJ_ID = CH.WPROJ_ID)
	  left join EPGP_PROJECTS PIS on (PIS.PROJECT_ID = CH.PROJECT_ID)
	  left join EPGX_PROJECT_TASKS PTS on (PTS.WPROJ_ID = CH.WPROJ_ID AND PTS.TASK_UID = CH.TASK_UID)
	  left join EPG_RESOURCES WRP on (CHG_PROJ_WRES_ID = WRP.WRES_ID)
	  left join EPG_TS_CATEGORY_VALUES CV on (CH.CHG_UID = CV.CAT_CHG_UID)
	  left join EPG_TS_PROGRESS TSP on (CH.TS_UID = TSP.TS_UID AND CH.PROJECT_ID = TSP.PROJECT_ID AND CH.WPROJ_ID = TSP.WPROJ_ID AND CH.TASK_UID = TSP.TASK_UID)
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on CH.TS_UID=LT.TokenVal
	 ORDER BY CH.TS_UID,CHG_ID
  end
else if (@Mode = 1)
  begin
--	SELECT CH.*,PIS.PROJECT_NAME,PTS.TASK_NAME,PTS.TASK_START_DATE,PTS.TASK_FINISH_DATE,PTS.TASK_ACT_WORK,PTS.TASK_REM_WORK,WRP.RES_NAME as CHG_PROJ_RES_NAME,CHG_ADJUSTED,CV.*,TSP_PCT_COMP,TSP_REM_WORK,TSP_EXPECTED_FINISH_DATE,TSP_STATUS
	SELECT CH.*,PIS.PROJECT_NAME,WPV.PV_PROJECT_NAME,PTS.TASK_NAME,PTS.TASK_START_DATE,PTS.TASK_FINISH_DATE,PTS.TASK_ACT_WORK,PTS.TASK_REM_WORK,WRP.RES_NAME as CHG_PROJ_RES_NAME,CHG_ADJUSTED,CV.*,TSP_PCT_COMP,TSP_REM_WORK,TSP_EXPECTED_FINISH_DATE,TSP_STATUS
	  FROM EPG_TS_CHARGES CH
	  left join EPGX_PROJECT_VERSIONS WPV on (WPV.WPROJ_ID = CH.WPROJ_ID)
	  left join EPGP_PROJECTS PIS on (PIS.PROJECT_ID = CH.PROJECT_ID)
	  left join EPGX_PROJECT_TASKS PTS on (PTS.WPROJ_ID = CH.WPROJ_ID AND PTS.TASK_UID = CH.TASK_UID)
	  left join EPG_RESOURCES WRP on (CHG_PROJ_WRES_ID = WRP.WRES_ID)
	  left join EPG_TS_CATEGORY_VALUES CV on (CH.CHG_UID = CV.CAT_CHG_UID)
	  left join EPG_TS_PROGRESS TSP on (CH.TS_UID = TSP.TS_UID AND CH.PROJECT_ID = TSP.PROJECT_ID AND CH.WPROJ_ID = TSP.WPROJ_ID AND CH.TASK_UID = TSP.TASK_UID)
	 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on CH.CHG_UID=LT.TokenVal
	 ORDER BY CH.TS_UID,CHG_ID
  end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSLimits')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSLimits'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSLimits'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSLimits
   @WResID INT
AS
SELECT GROUP_NAME,GROUP_NOTES,GL.*
  FROM EPG_GROUPS GR
  LEFT JOIN EPG_GROUP_MEMBERS GM ON (GM.GROUP_ID = GR.GROUP_ID)
  LEFT JOIN EPG_GROUP_TSLIMITS GL ON (GL.GROUP_ID = GR.GROUP_ID)
 WHERE GR.GROUP_ENTITY = 12 AND GM.MEMBER_UID = @WResID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSNonWorkHours')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSNonWorkHours'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSNonWorkHours'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSNonWorkHours
  @WResID int,
  @FromDate DATETIME,
  @ToDate DATETIME
AS
SELECT WH.*
  FROM EPG_GROUP_WEEKLYHOURS WH 
 WHERE WH.GROUP_ID = (SELECT TOP 1 GRM.GROUP_ID FROM EPG_GROUP_MEMBERS GRM LEFT JOIN EPG_GROUPS GRP ON (GRP.GROUP_ID = GRM.GROUP_ID)
                       WHERE GROUP_ENTITY = 10 and MEMBER_UID = @WResID)

SELECT NWI.NWI_ID,NWI_NAME,NWH_DATE,NWH_HOURS,NWI_CHARGESTATUS,NWI_CHARGENUMBER,NWI_MAJORCATEGORY
FROM EPG_NONWORK_HOURS NWH
LEFT JOIN EPG_NONWORK_ITEMS NWI ON (NWH.NWI_ID = NWI.NWI_ID)
WHERE NWH_DATE >= @FromDate and NWH_DATE <= @ToDate and NWH.WRES_ID = @WResID
union
SELECT NWI.NWI_ID,GRP.GROUP_NAME as NWI_NAME,NWH_DATE,NWH_HOURS,''1'' as NWI_CHARGESTATUS,NWI_CHARGENUMBER,NWI_MAJORCATEGORY
FROM EPG_GROUP_NONWORK_HOURS NWH
LEFT JOIN EPG_GROUP_NONWORK_ITEMS NWI ON (NWH.GROUP_ID = NWI.GROUP_ID)
LEFT JOIN EPG_GROUPS GRP ON (GRP.GROUP_ID = NWI.GROUP_ID)
WHERE NWH_DATE >= @FromDate and NWH_DATE <= @ToDate 
  AND NWH.GROUP_ID = (SELECT TOP 1 GRM.GROUP_ID FROM EPG_GROUP_MEMBERS GRM LEFT JOIN EPG_GROUPS GRP ON (GRP.GROUP_ID = GRM.GROUP_ID)
                       WHERE GROUP_ENTITY = 11 and MEMBER_UID = @WResID)
ORDER BY NWI.NWI_ID,NWH_DATE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSNonWorkItemsInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSNonWorkItemsInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSNonWorkItemsInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSNonWorkItemsInfo
   @sList NTEXT
AS

SELECT NWI.NWI_ID,NWI_NAME,NWI_CHARGENUMBER
  FROM EPG_NONWORK_ITEMS NWI
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on NWI.NWI_ID=LT.TokenVal 
union
SELECT NWI.NWI_ID,GRP.GROUP_NAME as NWI_NAME,NWI_CHARGENUMBER
FROM EPG_GROUP_NONWORK_ITEMS NWI
LEFT JOIN EPG_GROUPS GRP ON (GRP.GROUP_ID = NWI.GROUP_ID)
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on NWI.NWI_ID=LT.TokenVal 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSnRPCustomFieldsForCT')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSnRPCustomFieldsForCT'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSnRPCustomFieldsForCT'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSnRPCustomFieldsForCT
AS
Select FIELD_NAME,FA_NAME,FA_LOOKUP_UID,FA_USEFULLNAME,fl.FIELD_ID
  From EPGT_FIELDS fl 
  Left Join EPGP_FIELD_ATTRIBS fa On fa.FA_FIELD_ID = fl.FIELD_ID
  Where (fl.FIELD_ID >= 9100 and fl.FIELD_ID <= 9109) or (fl.FIELD_ID >= 9300 and fl.FIELD_ID <= 9309)
  Order By fl.FIELD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSPeriodsEligibleForDeletion')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSPeriodsEligibleForDeletion'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSPeriodsEligibleForDeletion'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSPeriodsEligibleForDeletion
AS
SELECT * 
  FROM EPG_PERIODS P
  LEFT JOIN EPGP_COST_BREAKDOWNS C ON (P.CB_ID = C.CB_ID)
 WHERE P.CB_ID = 0 
   AND PRD_IS_CLOSED = 1 
   AND (SELECT Count(*) FROM EPG_TS_TIMESHEETS T WHERE T.PRD_ID = P.PRD_ID AND TS_DELETED = 0) > 0
   AND CB_LOCK_TO >= P.PRD_ID
 ORDER BY PRD_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSPortfolioInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSPortfolioInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSPortfolioInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSPortfolioInfo
   @Version INT,
   @sList NTEXT
AS
SELECT p.*,WPROJ_ID
 FROM EPGP_PROJECTS p
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on p.PROJECT_ID=LT.TokenVal
 Left Join EPGX_PROJECT_VERSIONS pv On pv.PROJECT_ID=p.PROJECT_ID And VERSION_ID=@Version 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSPortfolioWorkItem')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSPortfolioWorkItem'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSPortfolioWorkItem'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSPortfolioWorkItem
   @PI int
AS
SELECT Distinct TASK_UID 
 FROM EPG_TS_CHARGES
 WHERE PROJECT_ID = @PI And TASK_UID > 0
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSPortfolioWorkItemInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSPortfolioWorkItemInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSPortfolioWorkItemInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSPortfolioWorkItemInfo
   @sList NTEXT
AS
SELECT PR.PROJECT_NAME,WI.*
 FROM EPG_TS_CHARGES CH
 LEFT JOIN EPGP_PROJECTS PR ON (CH.PROJECT_ID = PR.PROJECT_ID)
 LEFT JOIN EPGP_PI_WORKITEMS WI ON (CH.PROJECT_ID = WI.PROJECT_ID AND CH.TASK_UID = WI.WORKITEM_ID)
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on CH.CHG_UID=LT.TokenVal 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadTSTransactions')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadTSTransactions'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadTSTransactions'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadTSTransactions
  @WResID int
AS
-- NB This SP must match EPG273
/* read all timesheet notes for me as a TS user */
/* read all timesheet notes for me as a deptmgr */
/* read all timesheet notes for me as a projmgr */
/* read all timesheet notes for me as a PI mgr */
/* read all resource plan notes for me as a PI mgr */
/* read all resource plan notes for me as a dept mgr */
/* read all resource plan notes for me as a resource */
SELECT NT.* , EPG_NOTES.*,WR.RES_NAME as Author,PRD_NAME,TS.PRD_ID,WR.RES_NAME as UserName
  FROM EPG_NOTE_THREADS NT
  left join EPG_NOTES on NT_NOTE_UID = NOTE_UID
  left join EPG_RESOURCES WR on NOTE_AUTHOR_WRES_ID = WR.WRES_ID
  left join EPG_TS_TIMESHEETS TS on (NT_INDEX_1 = TS.TS_UID AND NT_CONTEXT <> 4 AND NT_CONTEXT <> 5)
  left join EPG_PERIODS PE on PE.PRD_ID = TS.PRD_ID AND PE.CB_ID = 0
  WHERE NT_ACCEPTED = 0 
    AND (((NT_CONTEXT = 1 OR NT_CONTEXT = 4 OR NT_CONTEXT = 9) AND NT_INDEX_2 = @WResID)
     OR   (NT_CONTEXT = 2 AND NT_INDEX_2 IN (SELECT CODE_UID FROM EPG_TS_APPROVERS WHERE WRES_ID=@WResID))
     OR  ((NT_CONTEXT = 3 OR NT_CONTEXT = 5) AND NT_INDEX_2 IN (SELECT WPROJ_ID FROM EPGX_PROJECT_VERSIONS WHERE PROJECT_ID IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_PLAN_OWNER=@WResID)))
     OR   (NT_CONTEXT = 6 AND NT_INDEX_2 IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MANAGER=@WResID))
     OR   (NT_CONTEXT = 7 AND NT_INDEX_2 IN (SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MANAGER=@WResID))
     OR  (NT_CONTEXT = 8 AND NT_INDEX_2 IN (SELECT CODE_UID FROM EPG_RES_MANAGERS WHERE WRES_ID=@WResID))
     OR  (NT_CONTEXT = 10 AND NT_INDEX_1 = @WResID))
ORDER BY NOTE_TIMESTAMP DESC

/* Read in the Portfolio Today info as a second recordset */
SELECT PROJECT_ID,PROJECT_NAME FROM EPGP_PROJECTS WHERE (PROJECT_OWNER=@WResID OR PROJECT_MANAGER=@WResID) AND PROJECT_MARKED_DELETION <> 1 ORDER BY PROJECT_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedCB')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedCB'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedCB'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedCB
  @CBID INT
AS
Select  ''1. Used For Resource Planning'' as Type,'' '' as Name
 From EPG_ADMIN 
 Where ADM_PORT_COMMITMENTS_CB_ID = @CBID
      UNION
Select Distinct Top 6 ''2. Calendar for Model'' as Type,MODEL_NAME as Name
   From EPGP_MODEL_SCENARIOS
   Where MODEL_CB_ID = @CBID
      UNION
Select Distinct Top 6 ''3. Input Calendar for Cost Type'' as Type,CT_NAME as Name
   From EPGP_COST_TYPES
   Where CT_CB_ID = @CBID
   Order By Type, Name 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedCF')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedCF'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedCF'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedCF
  @FieldID INT
AS
 Select ''Portfolio Tab'' as UsedMessage, TAB_NAME as UsedData
 From EPGP_LAYOUT_FIELDS a
 Join EPGP_LAYOUT_PAGES b On a.TAB_ID = b.TAB_ID
 Where FIELD_ID = @FieldID
Union
 Select Top 5 ''Portfolio View'' as UsedMessage, VIEW_NAME as UsedData
  From EPGT_VIEW_FIELDS a
  Join EPGT_VIEW_DISPLAY b On a.VIEW_UID = b.VIEW_UID
 Where FIELD_ID = @FieldID
Union
 Select Top 5 ''Mapped Field'' as UsedMessage, ''Check Field Mapping page in Administrator section of sitemap'' as UsedData
  From EPG_EXT_MAPPING a
 Where EXM_EPK_FIELD_ID = @FieldID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedCostViews')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedCostViews'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedCostViews'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedCostViews
  @UID INT
AS
select Distinct Top 6 VIEW_NAME
 From EPGT_VIEW_DISPLAY
 Where COSTVIEW_UID = @UID
 Order By VIEW_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedCT')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedCT'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedCT'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedCT
  @CTID INT
AS
Select Distinct Top 6 ''Used in Calculation Cost Type'' as Type,CT_NAME as Name
  From EPGP_COST_CALC cc
  Inner Join EPGP_COST_TYPES ct On ct.CT_ID = cc.CT_ID
  Where cc.CL_CT_ID = @CTID
      UNION
Select Distinct Top 6 ''Cost Type for Model'' as Type,MODEL_NAME as Name
   From EPGP_MODEL_CTS c
   Join EPGP_MODEL_SCENARIOS s On s.MODEL_UID=c.MODEL_UID
   Where MODEL_CT_ID = @CTID
   Order By Type, Name 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedGantts')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedGantts'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedGantts'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedGantts
  @UID INT
AS
select Distinct Top 6 VIEW_NAME
 From EPGT_VIEW_DISPLAY
 Where GANTT_UID = @UID
 Order By VIEW_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedGIs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedGIs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedGIs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedGIs
  @UID INT
AS
select Distinct Top 6 VIEW_NAME
 From EPGT_VIEW_FIELDS
 Inner Join EPGT_VIEW_DISPLAY On EPGT_VIEW_FIELDS.VIEW_UID = EPGT_VIEW_DISPLAY.VIEW_UID
 Where GRAPHIND_UID = @UID
 Order By VIEW_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedGroupMembers')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedGroupMembers'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedGroupMembers'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedGroupMembers
  @GroupUID INT
AS
Select  Distinct Top 3 ''Group used for Resource'' as Type,RES_NAME as Name
 From EPG_GROUP_MEMBERS g
 Inner Join EPG_RESOURCES r On g.MEMBER_UID = r.WRES_ID
 Where GROUP_ID=@GroupUID
   Order By Name 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedGroups')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedGroups'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedGroups'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedGroups
  @UID INT
AS
select Distinct Top 6 VIEW_NAME
 From EPGT_VIEW_DISPLAY
 Where GROUP_UID = @UID
 Order By VIEW_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedListValue')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedListValue'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedListValue'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedListValue
  @LV_UID INT
AS
 Select Top 3 ''Resource TS Department'' as UsedMessage, RES_NAME as UsedData
  From EPG_RESOURCES
  Where WRES_DEPT=@LV_UID
Union
 Select Top 3 ''Resource RP Department'' as UsedMessage, RES_NAME as UsedData
  From EPG_RESOURCES
  Where WRES_RP_DEPT=@LV_UID
--Union
-- Select Top 3 ''OBS in WBS Structure'' as UsedMessage, PROJECT_NAME + ''    '' + WBS_FULL_NAME as UsedData
--  From EPGP_EV_WBS w
--  Inner Join EPGP_PROJECTS pi On pi.PROJECT_ID=w.PROJECT_ID
--  Where WBS_OBS=@LV_UID
Union
 Select Top 3 ''PI Workflow Path'' as UsedMessage, PROJECT_NAME as UsedData
  From EPGP_PROJECTS
  Where PROJECT_WORKFLOW=@LV_UID
Union
 Select Top 3 ''Portfolio Program'' as UsedMessage, LV_VALUE  + ''    '' + PROJECT_NAME As UsedData
  From EPGP_PI_PROGS p
   Inner Join EPGP_LOOKUP_VALUES lv On lv.LV_UID=p.PROG_UID
   Inner Join EPGP_PROJECTS pi On pi.PROJECT_ID=p.PROJECT_ID
  Where PROG_UID=@LV_UID
Union
 Select Top 1 ''Cost Categories'' as UsedMessage, ''Resource Role'' As UsedData
  From EPGP_COST_CATEGORIES
  Where BC_ROLE=@LV_UID
Union
 Select  Distinct Top 3 ''Major Category for Cost Type'' as UsedMessage,CT_NAME as UsedData
  From EPGP_AVAIL_CATEGORIES ac
  Inner Join EPGP_COST_TYPES ct On ct.CT_ID = ac.CT_ID
  Where ac.BC_UID IN (Select BC_UID From EPGP_COST_CATEGORIES Where MC_UID=@LV_UID)
Union
 Select ''System Admin'' as UsedMessage, ''Default Workflow Path'' As UsedData
  From EPG_ADMIN
  Where ADM_WORKFLOW_PATH=@LV_UID
Union
  Select TOP 1 ''System Admin'' as UsedMessage, ''Workflow Path'' as UsedData
   From EPGP_NEXT_STAGES
   Where WORKFLOW_PATH=@LV_UID
Union
 Select ''System Admin'' as UsedMessage, ''Default Major Category'' As UsedData
  From EPG_ADMIN
  Where ADM_MC_DEFAULT=@LV_UID
   
/* following checks for Program Data removed as get into catch 22 because editing lookup is how a program is deleted */
/*Union
 Select Top 3 ''Program Data (int)'' as UsedMessage, LV_VALUE As UsedData
  From EPGP_PROG_INT_VALUES iv
   Inner Join EPGP_LOOKUP_VALUES lv On lv.LV_UID=iv.PROG_UID
  Where PROG_UID=@LV_UID*/
/* did check all 5 tables but they are created in a group so no point*/
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedLookups')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedLookups'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedLookups'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedLookups
  @LookupUID INT
AS
 Select Top 3 
    case When (FA_TABLE_ID>100 And FA_TABLE_ID<200) then ''Resource Custom Field'' 
     When (FA_TABLE_ID>200 And FA_TABLE_ID<300) then ''Portfolio Custom Field''
     When (FA_TABLE_ID>300 And FA_TABLE_ID<400) then ''Project Custom Field''
     When (FA_TABLE_ID>800 And FA_TABLE_ID<850) then ''Task/WI Custom Field''
     ELSE ''Custom Field'' End as UsedMessage, 
     FA_NAME as UsedData
 From EPGC_FIELD_ATTRIBS
 Where FA_LOOKUP_UID = @LookupUID
Union
 Select ''System Admin'' as UsedMessage, ''TS Department Code'' as UsedData
  From EPG_ADMIN
  Where ADM_DEPT_CODE=@LookupUID
Union
 Select ''System Admin'' as UsedMessage, ''RP Department Code'' as UsedData
  From EPG_ADMIN
  Where ADM_RPE_DEPT_CODE=@LookupUID
Union
 Select ''System Admin'' as UsedMessage, ''Role Code'' as UsedData
  From EPG_ADMIN
  Where ADM_ROLE_CODE=@LookupUID
Union
 Select ''System Admin'' as UsedMessage, ''Workflow Path'' as UsedData
  From EPG_ADMIN
  Where ADM_WORKFLOW_LOOKUP=@LookupUID
Union
 Select ''System Admin'' as UsedMessage, ''Major Category'' as UsedData
  From EPG_ADMIN
  Where ADM_MC_LOOKUP=@LookupUID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedRates')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedRates'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedRates'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedRates
  @RTUID INT
AS
Select  Distinct Top 6 ''Rate for Resources'' as Type,RES_NAME as Name
 From EPGP_COST_RATES cr
 Inner Join EPG_RESOURCES r On cr.WRES_ID = r.WRES_ID
 Where cr.RT_UID = @RTUID
   Order By Type, Name 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedResource1')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedResource1'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedResource1'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedResource1
  @WresID INT
AS
Select  Distinct Top 3 ''01.Stage Owner for PI'' as Type,PROJECT_NAME as Name
 From EPGP_PROJECTS Where PROJECT_OWNER = @WresID
      UNION
Select Distinct Top 3 ''02.Item Manager for PI'' as Type,PROJECT_NAME as Name
 From EPGP_PROJECTS Where PROJECT_MANAGER = @WresID
      UNION
Select Distinct Top 3 ''03.Project Schedule owner for PI'' as Type,PROJECT_NAME as Name
 From EPGP_PROJECTS Where PROJECT_PLAN_OWNER = @WresID
      UNION
Select Distinct Top 3 ''04.Timesheet'' as Type,''Period='' + Convert(varchar,PRD_ID) as Name
 From EPG_TS_TIMESHEETS Where WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''05.TS Approver'' as Type,LV_VALUE as Name From EPG_TS_APPROVERS a 
 Join EPGP_LOOKUP_VALUES v On a.CODE_UID=v.LV_UID Where WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''06.Resource Manager'' as Type,LV_VALUE as Name From EPG_RES_MANAGERS a 
 Join EPGP_LOOKUP_VALUES v On a.CODE_UID=v.LV_UID Where WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''07.Resource Plan'' as Type,PROJECT_NAME as Name From EPG_RESOURCEPLANS c 
 join EPGP_PROJECTS p On c.PROJECT_ID=p.PROJECT_ID Where WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''08.WI Assignment'' as Type,PROJECT_NAME as Name From EPGP_PI_WORKITEM_ASSNS a 
 join EPGP_PROJECTS p On a.PROJECT_ID=p.PROJECT_ID Where WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''09.PS Team'' as Type,PROJECT_NAME as Name From EPGX_PROJECT_RESOURCES r 
 join EPGX_PROJECT_VERSIONS v On r.WPROJ_ID=v.WPROJ_ID 
 join EPGP_PROJECTS p On v.PROJECT_ID=p.PROJECT_ID Where WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''10.Task Assignment'' as Type,PROJECT_NAME as Name From EPGX_PROJECT_ASSN t 
 join EPGX_PROJECT_VERSIONS v On t.WPROJ_ID=v.WPROJ_ID 
 join EPGP_PROJECTS p On v.PROJECT_ID=p.PROJECT_ID Where WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''11.Program Manager'' as Type,LV_VALUE as Name From EPGP_PROG_INFOS p 
 Join EPGP_LOOKUP_VALUES v On p.PROG_UID=v.LV_UID Where PROG_MANAGER = @WresID
      UNION
Select Distinct Top 3 ''12.Scheduled Work'' as Type,PROJECT_NAME as Name From EPGP_PI_WORK2 w 
 join EPGP_PROJECTS p On w.PROJECT_ID=p.PROJECT_ID Where WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''13.List Work'' as Type,PROJECT_NAME as Name From EPGP_PI_WORK1 w
 join EPGP_PROJECTS p On w.PROJECT_ID=p.PROJECT_ID Where WRES_ID = @WresID

   Order By Type, Name 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedResource2')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedResource2'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedResource2'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedResource2
  @WresID INT
AS
Select  Distinct Top 3 ''01.Created PI'' as Type,PROJECT_NAME as Name From EPGP_PROJECTS 
 Where PROJECT_CREATEDBY = @WresID
      UNION
Select Distinct Top 3 ''02.Prior Stage Owner for PI'' as Type,PROJECT_NAME as Name From EPGP_PROJECT_STAGES s 
 join EPGP_PROJECTS p On s.PROJECT_ID=p.PROJECT_ID
 Where s.STAGE_OWNER = @WresID
      UNION
Select Distinct Top 3 ''03.Changed stage for PI'' as Type,PROJECT_NAME as Name From EPGP_PROJECT_STAGES s 
 join EPGP_PROJECTS p On s.PROJECT_ID=p.PROJECT_ID
 Where s.WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''04.Imported Project Schedule'' as Type,PROJECT_NAME as Name From EPGX_PROJECT_VERSIONS v 
 join EPGP_PROJECTS p On v.PROJECT_ID=p.PROJECT_ID 
 Where PV_IMPORTED_BY = @WresID
      UNION
Select Distinct Top 3 ''05.Entered Resource Plan'' as Type,PROJECT_NAME as Name From EPG_RESOURCEPLANS c 
 join EPGP_PROJECTS p On c.PROJECT_ID=p.PROJECT_ID 
 Where CMT_ENTEREDBY_WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''06.Submitted Timesheet'' as Type,RES_NAME + '' for Period='' + Convert(varchar,PRD_ID) as Name From EPG_TS_TIMESHEETS t 
 join EPG_RESOURCES r On t.WRES_ID=r.WRES_ID 
 Where TS_SUBMITTED_WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''07.Department Approval'' as Type,RES_NAME + '' for Period='' + Convert(varchar,PRD_ID) as Name From EPG_TS_TIMESHEETS t 
 join EPG_RESOURCES r On t.WRES_ID=r.WRES_ID 
 Where TS_DEPT_WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''08.Project Approval'' as Type,RES_NAME + '' for Period='' + Convert(varchar,PRD_ID) as Name From EPG_TS_CHARGES c 
join EPG_TS_TIMESHEETS t On t.TS_UID=c.TS_UID 
join EPG_RESOURCES r On t.WRES_ID=r.WRES_ID 
 Where CHG_PROJ_WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''09.Applied Status'' as Type,PROJECT_NAME as Name From EPG_TS_PROGRESS t 
 join EPGP_PROJECTS p On t.PROJECT_ID=p.PROJECT_ID 
 Where TSP_STATUS_WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''10.Status Department'' as Type,TSD_DEPT_NAME as Name From EPG_TS_DEPTS 
 Where TSD_WRES_ID = @WresID
       UNION
Select Distinct Top 3 ''11.Adjustment'' as Type,''TS Adjustment on '' + Convert(varchar,ADJ_TIMESTAMP) as Name From EPG_TS_ADJUSTMENTS 
 Where ADJ_ADMIN_WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''12.Task Status information'' as Type,PV_PROJECT_NAME as Name From EPG_TASKSTATUS s 
 join EPGX_PROJECT_VERSIONS v On v.WPROJ_ID=v.WPROJ_ID 
 Where WRES_ID = @WresID
      UNION
Select Distinct Top 3 ''13.Applied Task Status'' as Type,PV_PROJECT_NAME as Name From EPG_TASKSTATUS s 
 join EPGX_PROJECT_VERSIONS v On v.WPROJ_ID=s.WPROJ_ID 
 Where TKS_STATUS_WRES_ID = @WresID
       UNION
Select Distinct Top 3 ''14.Submitted Job'' as Type,Convert(varchar,JOB_SUBMITTED) as Name From EPG_JOBS 
 Where WRES_ID = @WresID
       UNION
Select Distinct Top 3 ''15.Submitted Timer Job'' as Type,''Last Run '' + Convert(varchar,JOT_LAST_RUN) as Name From EPG_JOBS_TIMER 
 Where WRES_ID = @WresID
       UNION
Select Distinct Top 3 ''16.Uploaded Job'' as Type,Convert(varchar,UPL_TIMESTAMP) as Name From EPG_UPLOADS 
 Where WRES_ID = @WresID
       UNION
Select Distinct Top 3 ''17.Note'' as Type,Convert(varchar,NOTE_TIMESTAMP) as Name From EPG_NOTES 
 Where NOTE_AUTHOR_WRES_ID = @WresID
   Order By Type, Name 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedShortcuts')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedShortcuts'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedShortcuts'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedShortcuts
  @SHID INT
AS
select Distinct Top 6 VIEW_NAME
 From EPGT_VIEW_FILTERS
 Inner Join EPG_SHORTCUTS On EPG_SHORTCUTS.SHC_UID = EPGT_VIEW_FILTERS.FILTER_SHORTCUT
 Inner Join EPGT_VIEW_DISPLAY On EPGT_VIEW_FILTERS.VIEW_UID = EPGT_VIEW_DISPLAY.VIEW_UID
 Where FILTER_SHORTCUT = @SHID
 Order By VIEW_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsedVersions')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsedVersions'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsedVersions'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsedVersions
  @VerUID INT
AS
  Select ''1'' as MessageOrder,''System Admin'' as UsedMessage, ''Timesheet Version'' as UsedData
   From EPG_ADMIN
   Where ADM_TS_PROJ_VERSION_ID=@VerUID
 --Union
 -- Select ''1'' as MessageOrder,''System Admin'' as UsedMessage, ''Earned Value Version'' as UsedData
 --  From EPG_ADMIN
 --  Where ADM_EV_VERSION_ID=@VerUID
 Union
  Select Top 5  ''2'' as MessageOrder,''Project Version'' as UsedMessage,PROJECT_NAME as UsedData
   From EPGX_PROJECT_VERSIONS v
   Left Join EPGP_PROJECTS p On p.PROJECT_ID=v.PROJECT_ID
   Where VERSION_ID = @VerUID
  Order By MessageOrder
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUserByName')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUserByName'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUserByName'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUserByName
   @UserName nvarchar(255)
AS
SELECT WRES_ID
  FROM EPG_RESOURCES
 WHERE Lower(RES_NAME) = Lower(@UserName)
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUserByNTLogon')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUserByNTLogon'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUserByNTLogon'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUserByNTLogon
   @NTLogon nvarchar(255)
AS
SELECT WRES_ID,RES_NAME
  FROM EPG_RESOURCES
 WHERE Lower(WRES_NT_ACCOUNT) = Lower(@NTLogon) AND WRES_USE_NT_LOGON = 1
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUserByWResID')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUserByWResID'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUserByWResID'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUserByWResID
   @WResID INT
AS
 SELECT WRES_ID,RES_NAME,WRES_TS_INCLUDE,WRES_PR_INCLUDE,WRES_DEPT as DeptUID,LV_VALUE as DeptName
   FROM EPG_RESOURCES WR
   LEFT JOIN EPGP_LOOKUP_VALUES ON (LV_UID = WRES_DEPT)
  WHERE WRES_ID = @WResID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUserJobs')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUserJobs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUserJobs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUserJobs
  @Mode INT,
  @WResID INT
AS
   if (@Mode = 0)
      begin
		SELECT JU.*, R.RES_NAME
		  FROM EPG_JOBS_USER JU
		  LEFT JOIN EPG_RESOURCES R ON JU.WRES_ID = R.WRES_ID
		 ORDER BY JOU_UID

		SELECT *
		  FROM EPG_JOBS_USER_GROUPS
		 ORDER BY JOU_UID 
      end
   else
      begin
		SELECT DISTINCT JU.*
		  FROM EPG_JOBS_USER JU
		  LEFT JOIN EPG_RESOURCES R ON JU.WRES_ID = R.WRES_ID
		  LEFT JOIN EPG_JOBS_USER_GROUPS JUG ON JU.JOU_UID = JUG.JOU_UID
		 WHERE JUG.GROUP_ID IN (SELECT GROUP_ID FROM EPG_GROUP_MEMBERS WHERE MEMBER_UID = @WResID)
		 ORDER BY JU.JOU_UID
      end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadUsersDelegates')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadUsersDelegates'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadUsersDelegates'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadUsersDelegates
   @WResID INT
AS
-- Delegate values:
--    scTimesheet = 1
--    scDepartment = 2
--    scPIPlanOwner = 3
--    scPIManager = 4
--    scResourceManager = 5
--    scPIStageOwner = 6
SELECT SU.*, WR.RES_NAME
  FROM EPG_DELEGATES SU
  LEFT JOIN EPG_RESOURCES WR ON WR.WRES_ID = SU.SURR_WRES_ID
 WHERE SU.WRES_ID = @WResID and SURR_CONTEXT = 0
 ORDER BY SU.SURR_ID

SELECT SU.*
  FROM EPG_DELEGATES SU
 WHERE SU.WRES_ID = @WResID and SURR_CONTEXT = 1
 ORDER BY SU.SURR_ID

SELECT AP.CODE_UID as DeptUID, LV_VALUE as DeptName, SU.*
  FROM EPG_TS_APPROVERS AP 
  LEFT JOIN EPGP_LOOKUP_VALUES OC ON LV_UID = AP.CODE_UID
  LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 2 and SURR_CONTEXT_VALUE = AP.CODE_UID and SU.WRES_ID = @WResID
 WHERE AP.WRES_ID=@WResID
 ORDER BY AP.CODE_UID, SU.SURR_ID

-- PI Plan Owner Delegates
SELECT PROJECT_ID, PROJECT_NAME, SU.*
  FROM EPGP_PROJECTS 
  LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 3 and SURR_CONTEXT_VALUE = PROJECT_ID and SU.WRES_ID = @WResID
 WHERE PROJECT_PLAN_OWNER=@WResID
 ORDER BY PROJECT_NAME, SU.SURR_ID

SELECT AP.CODE_UID as DeptUID, LV_VALUE as DeptName, SU.*
  FROM EPG_RES_MANAGERS AP 
  LEFT JOIN EPGP_LOOKUP_VALUES OC ON LV_UID = AP.CODE_UID
  LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 5 and SURR_CONTEXT_VALUE = AP.CODE_UID and SU.WRES_ID = @WResID
 WHERE AP.WRES_ID=@WResID
 ORDER BY AP.CODE_UID, SU.SURR_ID

-- PI Manager Delegates
SELECT PROJECT_ID, PROJECT_NAME, SU.*
  FROM EPGP_PROJECTS 
  LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4 and SURR_CONTEXT_VALUE = PROJECT_ID and SU.WRES_ID = @WResID
 WHERE PROJECT_MANAGER=@WResID
 ORDER BY PROJECT_NAME, SU.SURR_ID

-- PI Stage Owner Delegates
SELECT PROJECT_ID, PROJECT_NAME, SU.*
  FROM EPGP_PROJECTS 
  LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 6 and SURR_CONTEXT_VALUE = PROJECT_ID and SU.WRES_ID = @WResID
 WHERE PROJECT_OWNER=@WResID
 ORDER BY PROJECT_NAME, SU.SURR_ID

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadVersionInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadVersionInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadVersionInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadVersionInfo
  @VerUID INT
AS
SELECT *
  FROM EPGP_VERSIONS
  Where VERSION_ID=@VerUID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadVersions')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadVersions'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadVersions'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadVersions
AS
SELECT *
  FROM EPGP_VERSIONS
 ORDER BY VERSION_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadView')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadView'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadView'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadView
  @ViewTypeID INT,
  @ViewUID INT
AS
SELECT VF.FIELD_ID,FIELD_TITLE,FIELD_ALIGN,FIELD_HIDDEN,FIELD_FROZEN,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT
  FROM EPG_VIEW_FIELDS VF
  left join EPGT_FIELDS TSF on (VF.FIELD_ID = TSF.FIELD_ID AND TSF.FIELD_VIEWTYPE_ID = @ViewTypeID)
 WHERE VIEW_UID = @ViewUID
 ORDER BY FIELD_COL_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadViewFieldDefinitions')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadViewFieldDefinitions'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadViewFieldDefinitions'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadViewFieldDefinitions
  @ViewTypeID INT,
  @ViewUID INT
AS
SELECT VF.FIELD_ID,FIELD_TITLE,FIELD_ALIGN,FIELD_HIDDEN,FIELD_FROZEN,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT,FA_FIELD_ID,FA_LOOKUP_UID,FA_LEAFONLY,FA_USEFULLNAME,FA_VALUE_UNIQUE,FA_ADMIN
  FROM EPG_VIEW_FIELDS VF
  left join EPGT_FIELDS TSF on (TSF.FIELD_ID = VF.FIELD_ID AND FIELD_VIEWTYPE_ID = @ViewTypeID)
  left join EPGP_FIELD_ATTRIBS FA on (TSF.FIELD_ID = FA_FIELD_ID)
 WHERE VIEW_UID = @ViewUID
 ORDER BY FIELD_COL_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadViewGraphIndRules')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadViewGraphIndRules'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadViewGraphIndRules'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadViewGraphIndRules
   @sList NTEXT
AS
 SELECT GR.GRAPHIND_UID, GRULE_ID,GRULE_TEXT_VALUE,GRULE_DATE_VALUE,GRULE_NUMBER_VALUE,GRULE_FIELD_ID,GRULE_VALUE_TYPE,GRULE_OP,GRULE_GRAPHIND_IND,GRAPHIND_MODE as GRULE_MODE,GRULE_TEXTCOLOR,GRULE_BACKCOLOR
  FROM EPGT_VIEW_GRAPHIND_RULES GR
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on GRAPHIND_UID=LT.TokenVal
 Left JOIN EPGT_VIEW_GRAPHIND GI on GI.GRAPHIND_UID = GR.GRAPHIND_UID
 ORDER BY GR.GRAPHIND_UID,GRULE_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadViewsForWE')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadViewsForWE'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadViewsForWE'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadViewsForWE
AS
 select VIEW_UID,VIEW_NAME 
  From EPGT_VIEW_DISPLAY 
  Where VIEW_TYPE=3 And VIEW_SUBTYPE=0 
  ORDER BY VIEW_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadViewTypeFields')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadViewTypeFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadViewTypeFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadViewTypeFields
   @ViewTypeID INT
AS
SELECT TSF.*,FA_NAME
  FROM EPGT_FIELDS TSF
  left join EPGP_FIELD_ATTRIBS on (FIELD_ID = FA_FIELD_ID)
 WHERE TSF.FIELD_VIEWTYPE_ID = @ViewTypeID
 ORDER BY FIELD_SEQUENCE
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadWorkHours')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadWorkHours'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadWorkHours'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadWorkHours
  @sList NTEXT
AS
 SELECT GROUP_ID,GROUP_HOURS_MON,GROUP_HOURS_TUE,GROUP_HOURS_WED,GROUP_HOURS_THU,GROUP_HOURS_FRI,GROUP_HOURS_SAT,GROUP_HOURS_SUN
  FROM EPG_GROUP_WEEKLYHOURS 
  INNER JOIN dbo.EPG_FN_ConvertListToTable(@sList) LT on GROUP_ID=LT.TokenVal 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadWSSAdmin')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadWSSAdmin'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadWSSAdmin'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadWSSAdmin
AS
SELECT *
  FROM EPG_WSS_ADMIN

SELECT WS.*
  FROM EPG_WSS_SERVERS WS
  ORDER BY WS.WSS_SERVER_ID

SELECT DBS.*
  FROM EPG_WSS_SERVER_DBS DBS
  ORDER BY DBS.WSS_SERVER_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_ReadWSSInfo')
begin
    Print 'Creating Stored Procedure EPG_SP_ReadWSSInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_ReadWSSInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_ReadWSSInfo
AS
 SELECT WSA_CURRENT_WSS_SERVER_ID,WSA_TEMPLATE_LCID,WSA_TEMPLATE_ID,WSA_PRIMARY_OWNER_EMAIL,WSA_SECONDARY_OWNER_NAME,WSA_SECONDARY_OWNER_EMAIL
   FROM EPG_WSS_ADMIN
 
 SELECT *
   FROM EPG_WSS_SERVERS
  ORDER BY WSS_SERVER_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RemoveMajorCategories')
begin
    Print 'Creating Stored Procedure EPG_SP_RemoveMajorCategories'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RemoveMajorCategories'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_RemoveMajorCategories
AS
 Update EPG_TS_CHARGES Set CHG_MAJORCATEGORY=NULL
 Update EPGP_PROJECTS Set PROJECT_MAJORCATEGORY=NULL
 Update EPG_NONWORK_ITEMS Set NWI_MAJORCATEGORY=NULL
 Update EPG_RESOURCEPLANS Set CMT_MAJORCATEGORY=NULL
 Update EPGP_PI_WORKITEMS Set WORKITEM_MAJORCATEGORY=NULL
 Update EPGP_PI_WORKITEM_TSWORK Set TSWORK_MAJORCATEGORY=NULL
 Update EPGP_WI_FRAGMENT_DATA Set WORKITEM_MAJORCATEGORY=NULL
 Update EPG_GROUP_NONWORK_ITEMS Set NWI_MAJORCATEGORY=NULL
 Update EPGX_PROJECT_VERSIONS Set PV_MAJORCATEGORY=NULL
 Update EPGX_PROJECT_TASKS Set TASK_MAJORCATEGORY=NULL
 Update EPGX_PROJECT_TSWORK Set TSWORK_MAJORCATEGORY=NULL
 
 select PROJECT_ID,WRES_ID,TSWORK_DATE,sum(TSWORK_WORK) as TSWORK_WORK,sum(TSWORK_REMAINING_WORK) as TSWORK_REMAINING_WORK,null as TSWORK_MAJORCATEGORY
  into #TempTSwork
  from EPGP_PI_WORKITEM_TSWORK
  group by PROJECT_ID,WRES_ID,TSWORK_DATE
 delete from EPGP_PI_WORKITEM_TSWORK
 insert into EPGP_PI_WORKITEM_TSWORK (PROJECT_ID,WRES_ID,TSWORK_DATE,TSWORK_WORK,TSWORK_REMAINING_WORK,TSWORK_MAJORCATEGORY) 
  select PROJECT_ID,WRES_ID,TSWORK_DATE,TSWORK_WORK,TSWORK_REMAINING_WORK,TSWORK_MAJORCATEGORY from #TempTSwork
 drop table #TempTSwork
 
 select WPROJ_ID,WRES_ID,EXRES_ID,TSWORK_DATE,sum(TSWORK_WORK) as TSWORK_WORK,null as TSWORK_MAJORCATEGORY
  into #TempTSworkX
  from EPGX_PROJECT_TSWORK
  group by WPROJ_ID,WRES_ID,EXRES_ID,TSWORK_DATE
 delete from EPGX_PROJECT_TSWORK
 insert into EPGX_PROJECT_TSWORK (WPROJ_ID,WRES_ID,EXRES_ID,TSWORK_DATE,TSWORK_WORK,TSWORK_MAJORCATEGORY)
  select WPROJ_ID,WRES_ID,EXRES_ID,TSWORK_DATE,TSWORK_WORK,TSWORK_MAJORCATEGORY from #TempTSworkX
 drop table #TempTSworkX
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_ADMIN')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_ADMIN'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_ADMIN'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_ADMIN]

AS

CREATE TABLE #TableAdmin(LastRefreshDate datetime)

insert into #TableAdmin(LastRefreshDate) Values(GETDATE())

select * from #TableAdmin
drop table #TableAdmin
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_DB_TABLES')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_DB_TABLES'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_DB_TABLES'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_DB_TABLES]

AS

-- **** Tables to create in PfE Reporting DB
-- SQL Source = stored proc name
-- SQL Target = user table-name defined
CREATE TABLE #TableList(SQLSource varchar(100), SQLTarget varchar(100))

-- list tables
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetListCostCategory'', ''EPG_RPT_List_CostCategories'')
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetListCostTypes'', ''EPG_RPT_List_CostTypes'')
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetListDepartments'', ''EPG_RPT_List_Departments'')
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetListRoles'', ''EPG_RPT_List_Roles'')
-- tables
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetAvailability'', ''EPG_RPT_Availability'')
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetCalendar'', ''EPG_RPT_Calendar'')
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetCapacitityPlanner'', ''EPG_RPT_CapacityPlanner'')
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetCost'', ''EPG_RPT_Cost'')
--insert into #TableList(SQLSource, SQLTarget)
--Values(''EPG_SP_RPT_GetCostDetails'', ''EPG_RPT_CostValues'')
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetCostDetailValues'', ''EPG_RPT_CostDetail'')
-- tables - temp tables -- do not rename target table names. 
-- these tables are joined to create a single table for 
-- resources = EPG_RPT_Resources and projects = EPG_RPT_Projects
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetResources'', ''EPG_RPT_ResourcesTMP'')
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetResourcesCustom'', ''EPG_RPT_ResourcesCustomTMP'')
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetProjects'', ''EPG_RPT_ProjectsTMP'')
insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_GetProjectsCustom'', ''EPG_RPT_ProjectsCustomTMP'')

insert into #TableList(SQLSource, SQLTarget)
Values(''EPG_SP_RPT_ADMIN'', ''EPG_RPT_ADMIN'')

-- return all tables to create
select * from #TableList
drop table #TableList
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetAvailability')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetAvailability'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetAvailability'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetAvailability]

AS

select * from EPG_VW_RPT_Availability

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetCalendar')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetCalendar'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetCalendar'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetCalendar]

AS

select * from EPG_VW_RPT_Calendar

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetCapacitityPlanner')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetCapacitityPlanner'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetCapacitityPlanner'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetCapacitityPlanner]

AS

select * from EPG_VW_RPT_CapacityPlanner

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetCost')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetCost'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetCost'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetCost]

AS

select * from EPG_VW_RPT_Cost

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetCostDetailValues')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetCostDetailValues'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetCostDetailValues'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetCostDetailValues]

AS

declare @sSQL as varchar(max)
declare @sSQLWhere as varchar(max)

declare @CF_ID int
declare @FA_NAME varchar(100)
declare @FA_LOOKUP_UID int
declare @CustomField varchar(10)

-- build query parts
set @sSQL = '' SELECT cv.CB_ID AS CalendarID, cv.PROJECT_ID AS ProjectID,  cv.CT_ID AS CostTypeID, cv.BC_UID AS CostCategoryUID, cv.BD_PERIOD AS PeriodID, ''+ 
		    '' cv.BD_VALUE AS Qty, cv.BD_COST AS Cost, cv.BD_IS_SUMMARY AS IsSummary, dv.BC_SEQ AS Sequence, dv.BD_VALUE AS DETAILED_Qty, ''+ 
		    '' dv.BD_COST AS DETAILED_Cost''
		  
set @sSQLWhere = '' FROM dbo.EPGP_COST_DETAILS AS cd ''+ 
				  '' INNER JOIN dbo.EPGP_DETAIL_VALUES AS dv ON cd.CB_ID = dv.CB_ID ''+ 
				  '' AND cd.CT_ID = dv.CT_ID AND cd.PROJECT_ID = dv.PROJECT_ID ''+ 
				  '' AND cd.BC_UID = dv.BC_UID AND cd.BC_SEQ = dv.BC_SEQ ''+ 
				  '' RIGHT OUTER JOIN dbo.EPGP_COST_VALUES AS cv ON dv.CB_ID = cv.CB_ID ''+ 
				  '' AND dv.CT_ID = cv.CT_ID AND dv.PROJECT_ID = cv.PROJECT_ID ''+ 
				  '' AND dv.BC_UID = cv.BC_UID AND dv.BD_PERIOD = cv.BD_PERIOD ''
		  

/*
set @sSQL = ''SELECT  cd.CB_ID AS CalendarID, dv.BD_PERIOD as PeriodID, cd.CT_ID AS CostTypeID, cd.PROJECT_ID AS ProjectID, ''+ 
            ''cd.BC_UID AS CostCategoryUID, cd.BC_SEQ, dv.BD_VALUE, dv.BD_COST''
                      
set @sSQLWhere = '' FROM  dbo.EPGP_COST_DETAILS AS cd '' +
				 '' INNER JOIN dbo.EPGP_DETAIL_VALUES AS dv ON cd.CB_ID = dv.CB_ID '' +
                 '' AND cd.CT_ID = dv.CT_ID AND cd.PROJECT_ID = dv.PROJECT_ID '' +
                 '' AND cd.BC_UID = dv.BC_UID AND cd.BC_SEQ = dv.BC_SEQ ''
*/
DECLARE tableCursors CURSOR FOR 

  -- get cost type custom fields
	SELECT DISTINCT cf.CF_ID, fa.FA_NAME, fa.FA_LOOKUP_UID, 
	dbo.EPG_FN_RPT_GetCostTypeCustomField(cf.CF_ID) AS CustomField
	FROM  dbo.EPGP_COST_CUSTOM_FIELDS AS cf INNER JOIN
          dbo.EPGP_FIELD_ATTRIBS AS fa ON cf.CF_FIELD_ID = fa.FA_FIELD_ID

OPEN tableCursors

FETCH NEXT FROM tableCursors 
INTO @CF_ID, @FA_NAME, @FA_LOOKUP_UID, @CustomField

WHILE @@FETCH_STATUS = 0
BEGIN

	-- build column query
	if (LEFT(@CustomField, 2) = ''OC'') -- OC
		set @sSQL = @sSQL + '', lv'' + @CustomField	+ ''.LV_FULLVALUE as ['' + @FA_NAME + '']''
	else -- text
		set @sSQL = @sSQL + '', cd.'' + @CustomField	+ '' as ['' + @FA_NAME + '']''
		
	-- build where clause
	if @FA_LOOKUP_UID>0
		set @sSQLWhere = @sSQLWhere + '' LEFT OUTER JOIN dbo.EPGP_LOOKUP_VALUES AS lv'' + @CustomField + '' ON lv'' + @CustomField + ''.LV_UID = cd.'' + @CustomField	
	
	FETCH NEXT FROM tableCursors 
	INTO @CF_ID, @FA_NAME, @FA_LOOKUP_UID, @CustomField

END

CLOSE tableCursors
DEALLOCATE tableCursors

-- *** execute sql string
Exec(@sSQL + @sSQLWhere)
--print  @sSQL + @sSQLWhere


')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetListCostCategory')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetListCostCategory'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetListCostCategory'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetListCostCategory]

AS

select * from EPG_VW_RPT_ListCostCategory

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetListCostTypes')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetListCostTypes'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetListCostTypes'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetListCostTypes]

AS

select * from EPG_VW_RPT_ListCostTypes 

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetListDepartments')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetListDepartments'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetListDepartments'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetListDepartments]

AS

select * from EPG_VW_RPT_ListDepartments

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetListRoles')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetListRoles'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetListRoles'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetListRoles]

AS

select * from EPG_VW_RPT_ListRoles 

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetProjects')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetProjects'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetProjects'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetProjects]

AS

select * from EPG_VW_RPT_Projects

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetProjectsCustom')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetProjectsCustom'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetProjectsCustom'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetProjectsCustom]

AS

declare @sSQL as varchar(max)
declare @sSQLWhere as varchar(max)
declare @TableID int
declare @TableName varchar(100)

-- build query parts
set @sSQL = ''SELECT dbo.EPGP_PROJECTS.PROJECT_ID as ProjectID ''
set @sSQLWhere = '' FROM dbo.EPGP_PROJECTS ''

DECLARE tableCursors CURSOR FOR 

  -- get distinct portfolio custom tables
  SELECT distinct FA_TABLE_ID, dbo.EPG_FN_RPT_GetTableName(FA_TABLE_ID) as TableName
  FROM [dbo].[EPGC_FIELD_ATTRIBS]
  where FA_TABLE_ID >= 200 and FA_TABLE_ID <= 210 -- portfolio custom tables
  group by FA_TABLE_ID 

OPEN tableCursors

FETCH NEXT FROM tableCursors 
INTO @TableID, @TableName

WHILE @@FETCH_STATUS = 0
BEGIN
	-- 
	declare @FA_NAME as varchar(255)
	declare @FA_LOOKUPONLY as int 
	declare @FA_LOOKUP_UID as int 
	declare @FA_LEAFONLY as int 
	declare @FA_FIELD_IN_TABLE as varchar(255)
	declare @FA_FORMAT as int 
     
	DECLARE colsCursors CURSOR FOR 

	-- select field for a specific custom table
	SELECT [FA_NAME],[FA_LOOKUPONLY],[FA_LOOKUP_UID],[FA_LEAFONLY]
      ,dbo.EPG_FN_RPT_GetFieldName(@TableID, FA_FIELD_IN_TABLE) as [FA_FIELD_IN_TABLE] 
      ,[FA_FORMAT]
	  FROM [dbo].[EPGC_FIELD_ATTRIBS]
	  where FA_TABLE_ID = @TableID 
	  order by FA_FIELD_IN_TABLE  

	OPEN colsCursors

	FETCH NEXT FROM colsCursors 
	INTO @FA_NAME, @FA_LOOKUPONLY, @FA_LOOKUP_UID, @FA_LEAFONLY, @FA_FIELD_IN_TABLE, @FA_FORMAT

	WHILE @@FETCH_STATUS = 0
	BEGIN		  
		-- build column query
		set @sSQL = @sSQL + '', dbo.'' + @TableName + ''.'' + @FA_FIELD_IN_TABLE	+ '' as ['' + @FA_NAME + '']''	
		    
	FETCH NEXT FROM colsCursors 
	INTO @FA_NAME, @FA_LOOKUPONLY, @FA_LOOKUP_UID, @FA_LEAFONLY, @FA_FIELD_IN_TABLE, @FA_FORMAT

	END

	CLOSE colsCursors
	DEALLOCATE colsCursors

	-- build where clause
	set @sSQLWhere = @sSQLWhere + '' INNER JOIN dbo.'' + @TableName + '' ON dbo.EPGP_PROJECTS.PROJECT_ID = dbo.'' + @TableName + ''.PROJECT_ID''

FETCH NEXT FROM tableCursors 
INTO @TableID, @TableName

END

CLOSE tableCursors
DEALLOCATE tableCursors

-- *** execute sql string
Exec(@sSQL + @sSQLWhere)
--print  @sSQL + @sSQLWhere






')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetResources')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetResources'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetResources'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetResources]

AS

select * from EPG_VW_RPT_Resources

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_RPT_GetResourcesCustom')
begin
    Print 'Creating Stored Procedure EPG_SP_RPT_GetResourcesCustom'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_RPT_GetResourcesCustom'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROC [dbo].[EPG_SP_RPT_GetResourcesCustom]

AS

declare @sSQL as varchar(max)
declare @sSQLWhere as varchar(max)
declare @sSQLOC as varchar(max)
declare @TableID int
declare @TableName varchar(100)

-- build query parts
set @sSQL = ''SELECT dbo.EPG_RESOURCES.WRES_ID as ResourceID ''
set @sSQLWhere = '' dbo.EPG_RESOURCES ''
set @sSQLOC = '' ''  -- used for outline codes joins

DECLARE tableCursors CURSOR FOR 

  -- get distinct portfolio custom tables
  SELECT distinct FA_TABLE_ID, dbo.EPG_FN_RPT_GetTableName(FA_TABLE_ID) as TableName
  FROM [dbo].[EPGC_FIELD_ATTRIBS]
  where FA_TABLE_ID >= 100 and FA_TABLE_ID <= 200 -- resource custom tables
  group by FA_TABLE_ID 

OPEN tableCursors

FETCH NEXT FROM tableCursors 
INTO @TableID, @TableName

WHILE @@FETCH_STATUS = 0
BEGIN
	-- 
	declare @FA_NAME as varchar(255)
	declare @FA_LOOKUPONLY as int 
	declare @FA_LOOKUP_UID as int 
	declare @FA_LEAFONLY as int 
	declare @FA_FIELD_IN_TABLE_NAME as varchar(255)
	declare @FA_FORMAT as int 
	declare @FA_FIELD_ID as varchar(10)
     
	DECLARE colsCursors CURSOR FOR 

	-- select field for a specific custom table
	SELECT [FA_NAME],[FA_LOOKUPONLY],[FA_LOOKUP_UID],[FA_LEAFONLY]
      ,dbo.EPG_FN_RPT_GetFieldName(@TableID, FA_FIELD_IN_TABLE) as [FA_FIELD_IN_TABLE_NAME] 
      ,[FA_FORMAT],FA_FIELD_ID
	  FROM [dbo].[EPGC_FIELD_ATTRIBS]
	  where FA_TABLE_ID = @TableID 
	  order by FA_FIELD_IN_TABLE  

	OPEN colsCursors

	FETCH NEXT FROM colsCursors 
	INTO @FA_NAME, @FA_LOOKUPONLY, @FA_LOOKUP_UID, @FA_LEAFONLY, @FA_FIELD_IN_TABLE_NAME, @FA_FORMAT, @FA_FIELD_ID

	WHILE @@FETCH_STATUS = 0
	BEGIN	
		-- *** build column query
		if @FA_LOOKUPONLY = 1 and @TableID = 101 -- integer table
		begin
		   -- Outline Code lookup value
		   set @sSQL = @sSQL + '', lv'' + @FA_FIELD_IN_TABLE_NAME + ''.LV_FULLVALUE as ['' + @FA_NAME + '']''
		   
		   -- Outline Code SQL where part		                         
		   set @sSQLOC = @sSQLOC + '' LEFT OUTER JOIN dbo.EPGP_LOOKUP_VALUES AS lv'' +  @FA_FIELD_IN_TABLE_NAME + '' ON lv'' +  @FA_FIELD_IN_TABLE_NAME + ''.LV_UID = dbo.'' + @TableName + ''.'' + @FA_FIELD_IN_TABLE_NAME		   
		end			
		else if @TableID = 151  -- multivalue table
			set @sSQL = @sSQL + '', dbo.EPG_FN_RPT_GetMultiValue(dbo.EPG_RESOURCES.WRES_ID, '' + @FA_FIELD_ID + '') as ['' + @FA_NAME + '']''		
		else -- all other tables			
			set @sSQL = @sSQL + '', dbo.'' + @TableName + ''.'' + @FA_FIELD_IN_TABLE_NAME	+ '' as ['' + @FA_NAME + '']''
			   
	FETCH NEXT FROM colsCursors 
	INTO @FA_NAME, @FA_LOOKUPONLY, @FA_LOOKUP_UID, @FA_LEAFONLY, @FA_FIELD_IN_TABLE_NAME, @FA_FORMAT, @FA_FIELD_ID

	END

	CLOSE colsCursors
	DEALLOCATE colsCursors

	-- build where clause	
	if @TableID <> 151
		set @sSQLWhere = @sSQLWhere + '' LEFT OUTER JOIN dbo.'' + @TableName + '' ON dbo.EPG_RESOURCES.WRES_ID = dbo.'' + @TableName + ''.WRES_ID''

FETCH NEXT FROM tableCursors 
INTO @TableID, @TableName

END

CLOSE tableCursors
DEALLOCATE tableCursors

-- *** execute sql string
Exec(@sSQL + '' FROM '' + @sSQLWhere + @sSQLOC)
--print @sSQL + '' FROM '' + @sSQLWhere + @sSQLOC

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_SelectChunk')
begin
    Print 'Creating Stored Procedure EPG_SP_SelectChunk'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_SelectChunk'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_SelectChunk
   @WresID INT,
   @ChunkID INT
AS
SELECT CHUNK FROM EPG_CHUNKER WHERE WRES_ID = @WresID AND CHUNK_ID = @ChunkID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_SelectResources')
begin
    Print 'Creating Stored Procedure EPG_SP_SelectResources'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_SelectResources'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_SelectResources
   @WResID INT,
   @SelectMode INT,
   @SelectText NTEXT,
   @CodeUID INT,
   @sList NTEXT,
   @GroupID INT
AS
if (@SelectMode = 0)
  begin
    SELECT DISTINCT WR.WRES_ID,WR.RES_NAME,MR_NOTES,MR_SEQ
      FROM EPG_MY_RESOURCES MR
      LEFT JOIN EPG_RESOURCES WR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = @WResID
      WHERE MR_WRES_ID = @WResID AND WR.WRES_INACTIVE = 0
     ORDER BY MR_SEQ
  end
else if (@CodeUID = 0 and @GroupID = 0)
  begin
    SELECT DISTINCT WR.WRES_ID,WR.RES_NAME,MR_NOTES,MR_SEQ
      FROM EPG_RESOURCES WR
      LEFT JOIN EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = @WResID
     WHERE WR.WRES_INACTIVE = 0 AND RES_NAME like @SelectText
     ORDER BY WR.RES_NAME
  end
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_UsingTimesheet')
begin
    Print 'Creating Stored Procedure EPG_SP_UsingTimesheet'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_UsingTimesheet'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_UsingTimesheet
AS
Select
  Case When (ADM_PORT_CHARGESTATUS_CFID>0 Or ADM_PROJ_CHARGESTATUS_CFID>0 Or ADM_TASK_CHARGESTATUS_CFID>0) Then 1
       Else 0 End as UsingTimesheet
  From EPG_ADMIN
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_WIWorkPIs')
begin
    Print 'Creating Stored Procedure EPG_SP_WIWorkPIs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPG_SP_WIWorkPIs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPG_SP_WIWorkPIs
   @sRList NTEXT
AS
Select Distinct w.PROJECT_ID  
 From EPGP_PI_WORKITEM_TSWORK w
 Inner Join EPGP_PROJECTS p On p.PROJECT_ID=w.PROJECT_ID And PROJECT_MARKED_DELETION = 0
 INNER JOIN dbo.EPG_FN_ConvertListToTable(@sRList) LT2 on w.WRES_ID=LT2.TokenVal
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPK_SP_ReadNonWorkColors')
begin
    Print 'Creating Stored Procedure EPK_SP_ReadNonWorkColors'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPK_SP_ReadNonWorkColors'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPK_SP_ReadNonWorkColors
AS
SELECT *
  FROM EPK_SYSTEM_COLORS
 WHERE REF_ID >= 101 AND REF_ID <= 112
 ORDER BY REF_ID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPK_SP_ReadRoleUsedRPs')
begin
    Print 'Creating Stored Procedure EPK_SP_ReadRoleUsedRPs'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure EPK_SP_ReadRoleUsedRPs'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.EPK_SP_ReadRoleUsedRPs
  @BCUID INT
AS
Select Distinct Top 5 ''Resource Plans for PIs'' as Type,PROJECT_NAME as Name
   From EPG_RESOURCEPLANS cm
   Left Join EPGP_PROJECTS pr On pr.PROJECT_ID = cm.PROJECT_ID
   Where BC_UID = @BCUID Or PARENT_BC_UID = @BCUID
   Order By Type, Name 
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PFE_SP_GenerateDataTicket')
begin
    Print 'Creating Stored Procedure PFE_SP_GenerateDataTicket'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure PFE_SP_GenerateDataTicket'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[PFE_SP_GenerateDataTicket] 
	@Data NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;

    DECLARE @Id UNIQUEIDENTIFIER = NEWID()
	
	INSERT INTO [dbo].[EPG_DATA_CACHE] ([DC_TICKET],[DC_TIMESTAMP],[DC_DATA]) VALUES(@Id, GETDATE(), @Data)
	
	SELECT @Id
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PFE_SP_GetCustomFieldValues')
begin
    Print 'Creating Stored Procedure PFE_SP_GetCustomFieldValues'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure PFE_SP_GetCustomFieldValues'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[PFE_SP_GetCustomFieldValues]
	@ResourceId INT,
	@Fields NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;

    DECLARE @Query NVARCHAR(MAX) = ''
    
		SELECT	dbo.EPG_RESOURCES.WRES_ID, '' + @Fields + ''
		FROM    dbo.EPGC_RESOURCE_DATE_VALUES RIGHT OUTER JOIN
				dbo.EPG_RESOURCES ON dbo.EPGC_RESOURCE_DATE_VALUES.WRES_ID = dbo.EPG_RESOURCES.WRES_ID LEFT OUTER JOIN
				dbo.EPGC_RESOURCE_NTEXT_VALUES ON dbo.EPG_RESOURCES.WRES_ID = dbo.EPGC_RESOURCE_NTEXT_VALUES.WRES_ID LEFT OUTER JOIN
				dbo.EPGC_RESOURCE_TEXT_VALUES ON dbo.EPG_RESOURCES.WRES_ID = dbo.EPGC_RESOURCE_TEXT_VALUES.WRES_ID LEFT OUTER JOIN
				dbo.EPGC_RESOURCE_DEC_VALUES ON dbo.EPG_RESOURCES.WRES_ID = dbo.EPGC_RESOURCE_DEC_VALUES.WRES_ID LEFT OUTER JOIN
				dbo.EPGC_RESOURCE_INT_VALUES ON dbo.EPG_RESOURCES.WRES_ID = dbo.EPGC_RESOURCE_INT_VALUES.WRES_ID
		WHERE	(dbo.EPG_RESOURCES.WRES_ID = @ResourceId)
    
    ''
    
    EXEC sp_executesql @Query, N''@ResourceId INT'', @ResourceId
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PFE_SP_GetResourceIdBy')
begin
    Print 'Creating Stored Procedure PFE_SP_GetResourceIdBy'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure PFE_SP_GetResourceIdBy'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[PFE_SP_GetResourceIdBy]
	@Col NVARCHAR(255),
	@Value NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;

    DECLARE @Query NVARCHAR(MAX) = ''SELECT [WRES_ID] FROM [dbo].[EPG_RESOURCES] WHERE CAST(['' + @Col + ''] AS NVARCHAR(MAX)) = @Value''
    EXEC sp_executesql @Query, N''@Value NVARCHAR(MAX)'', @Value
END

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PFE_SP_UpdateResourceCostCategory')
begin
    Print 'Creating Stored Procedure PFE_SP_UpdateResourceCostCategory'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure PFE_SP_UpdateResourceCostCategory'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[PFE_SP_UpdateResourceCostCategory]
	@ResourceId INT,
	@CostCategoryId INT
AS
BEGIN
	SET NOCOUNT ON;
	
    DELETE FROM [dbo].[EPGP_COST_XREF] WHERE [WRES_ID] = @ResourceId
    INSERT INTO [dbo].[EPGP_COST_XREF] ([WRES_ID], [BC_UID]) VALUES(@ResourceId, @CostCategoryId)
END


')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PPM_SP_ReadAdmin')
begin
    Print 'Creating Stored Procedure PPM_SP_ReadAdmin'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure PPM_SP_ReadAdmin'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.PPM_SP_ReadAdmin
AS
SELECT * 
  FROM EPG_ADMIN
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PPM_SP_ReadCostViewsForWE')
begin
    Print 'Creating Stored Procedure PPM_SP_ReadCostViewsForWE'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure PPM_SP_ReadCostViewsForWE'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.PPM_SP_ReadCostViewsForWE
AS
 select VIEW_UID,VIEW_NAME 
  From EPGT_COSTVIEW_DISPLAY 
  ORDER BY VIEW_NAME
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PPM_SP_ReadLookupValuesByLookup')
begin
    Print 'Creating Stored Procedure PPM_SP_ReadLookupValuesByLookup'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure PPM_SP_ReadLookupValuesByLookup'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.PPM_SP_ReadLookupValuesByLookup
   @sList NTEXT
AS
SELECT LOOKUP_UID,LV_UID,LV_FULLVALUE
  FROM EPGP_LOOKUP_VALUES
 INNER JOIN dbo.PPM_FN_ConvertListToTable(@sList) LT on LOOKUP_UID=LT.TokenVal 
 ORDER BY LV_UID
')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PPM_SP_ReadSiteMap')
begin
    Print 'Creating Stored Procedure PPM_SP_ReadSiteMap'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure PPM_SP_ReadSiteMap'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.PPM_SP_ReadSiteMap
   @WResID INT
AS
-- WRES_ID = null = System menu item
-- WRES_ID = 0    = Corporate added menu item
-- WRES_ID > 0    = User added menu item
if (@WResID = 1) 
   SELECT * FROM EPG_SITEMAP
    --WHERE SM_CONTEXT IS NULL AND (WRES_ID IS NULL OR WRES_ID = 0 OR WRES_ID = 1)
    WHERE (WRES_ID IS NULL OR WRES_ID = 0 OR WRES_ID = 1)
    ORDER BY SM_ID
else
   SELECT * FROM EPG_SITEMAP
    --WHERE SM_CONTEXT IS NULL AND (PERM_UID IS NULL OR PERM_UID IN (SELECT PERM_UID FROM EPG_GROUP_PERMISSIONS WHERE GROUP_ID IN (SELECT GROUP_ID FROM EPG_GROUP_MEMBERS WHERE MEMBER_UID = @WResID)))
    WHERE (PERM_UID IS NULL OR PERM_UID IN (SELECT PERM_UID FROM EPG_GROUP_PERMISSIONS WHERE GROUP_ID IN (SELECT GROUP_ID FROM EPG_GROUP_MEMBERS WHERE MEMBER_UID = @WResID)))
      AND (WRES_ID IS NULL OR WRES_ID = 0 OR WRES_ID = @WResID)
    ORDER BY SM_ID

')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'PPM_SP_ReadSiteMapAdminPages')
begin
    Print 'Creating Stored Procedure PPM_SP_ReadSiteMapAdminPages'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure PPM_SP_ReadSiteMapAdminPages'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE dbo.PPM_SP_ReadSiteMapAdminPages
   @WResID INT
AS
-- WRES_ID = null = System menu item
-- WRES_ID = 0    = Corporate added menu item
-- WRES_ID > 0    = User added menu item
if (@WResID = 1) 
   SELECT * FROM EPG_SITEMAP
    WHERE (WRES_ID IS NULL OR WRES_ID = 0 OR WRES_ID = 1) AND SM_CONTEXT IS NOT NULL
    ORDER BY SM_CONTEXT
else
   SELECT * FROM EPG_SITEMAP
    WHERE (PERM_UID IS NULL OR PERM_UID IN (SELECT PERM_UID FROM EPG_GROUP_PERMISSIONS WHERE GROUP_ID IN (SELECT GROUP_ID FROM EPG_GROUP_MEMBERS WHERE MEMBER_UID = @WResID)))
      AND (WRES_ID IS NULL OR WRES_ID = 0 OR WRES_ID = @WResID) AND SM_CONTEXT IS NOT NULL
    ORDER BY SM_CONTEXT

')
 
