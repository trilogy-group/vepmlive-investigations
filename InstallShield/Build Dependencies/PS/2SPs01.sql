declare @createoralter varchar(10)
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spCheckFields')
begin
    Print 'Creating Stored Procedure spCheckFields'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spCheckFields'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spCheckFields]

as

begin

SELECT     *
FROM         CustomFields
WHERE     (editable = 1)
and visible=1
END')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spHideField')
begin
    Print 'Creating Stored Procedure spHideField'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spHideField'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spHideField]

@fieldname varchar(255),
@isPj bit,
@type int

AS
BEGIN

if @isPj = 1
begin
	update customfields set pjvisible = 0 where fieldname=@fieldname
end
else
begin
	update customfields set visible = 0 where fieldname=@fieldname
end

declare @visible bit
declare @pjvisible bit

set @visible = 0
set @pjvisible = 0

select @visible=visible, @pjvisible=pjvisible from customfields where fieldname=@fieldname

if @visible = 0 and @pjvisible = 0 and (@type = 3)
begin

	delete from customfields where fieldname=@fieldname

end


END')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRetrieveProjGuid')
begin
    Print 'Creating Stored Procedure spRetrieveProjGuid'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRetrieveProjGuid'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRetrieveProjGuid]

@webid varchar(255)	

as

begin

SELECT     projectguid, pubType
FROM         publishercheck
WHERE     (webguid = @webid)
END')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spRetrieveWebURL')
begin
    Print 'Creating Stored Procedure spRetrieveWebURL'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spRetrieveWebURL'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spRetrieveWebURL]

@projid varchar(255)	

as

SELECT     weburl
FROM         publishercheck
WHERE     (projectguid = @projid)')
 
if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'spShowField')
begin
    Print 'Creating Stored Procedure spShowField'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure spShowField'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[spShowField]

@fieldname varchar(255),
@displayname varchar(255),
@wssfieldname varchar(255),
@fieldtype varchar(255),
@assnfieldname varchar(255),
@isPj bit,
@fieldcategory int,
@assnupdatefield varchar(255) = null

AS
BEGIN

declare @fname varchar(255)

set @fname = ''''

select @fname=fieldname from customfields where fieldname=@fieldname

if @fname = ''''
begin

	if @isPj = 1
	begin
		INSERT INTO customfields (fieldname,editable,displayname,fieldcategory,wssfieldname,pjvisible,fieldtype,assnfieldname,assnupdatecolumnid)
		VALUES (@fieldname,0,@displayname,@fieldcategory,@wssfieldname,1,@fieldtype,@assnfieldname,@assnupdatefield)
	end
	else
	begin
		INSERT INTO customfields (fieldname,editable,displayname,fieldcategory,wssfieldname,visible,fieldtype,assnfieldname,assnupdatecolumnid)
		VALUES (@fieldname,0,@displayname,@fieldcategory,@wssfieldname,1,@fieldtype,@assnfieldname,@assnupdatefield)
	end

end
else
begin

	if @isPj = 1
	begin
		update customfields set pjvisible = 1 where fieldname=@fieldname
	end
	else
	begin
		update customfields set visible = 1 where fieldname=@fieldname
	end


end

END
')
 
