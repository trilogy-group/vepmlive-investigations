IF EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ACCOUNT_USERS_user_id_deleted' AND object_id = OBJECT_ID('dbo.[ACCOUNT_USERS]'))
BEGIN
    DROP INDEX IX_ACCOUNT_USERS_user_id_deleted ON dbo.[ACCOUNT_USERS]
END
GO

CREATE NONCLUSTERED INDEX IX_ACCOUNT_USERS_user_id_deleted
ON [dbo].[ACCOUNT_USERS] ([user_id],[deleted])
INCLUDE ([account_id],[DETAIL_ID])
GO

IF EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ACCOUNT_USERS_account_id_DETAIL_ID' AND object_id = OBJECT_ID('dbo.[ACCOUNT_USERS]'))
BEGIN
    DROP INDEX IX_ACCOUNT_USERS_account_id_DETAIL_ID ON dbo.[ACCOUNT_USERS]
END
GO

CREATE NONCLUSTERED INDEX IX_ACCOUNT_USERS_account_id_DETAIL_ID
ON [dbo].[ACCOUNT_USERS] ([account_id],[DETAIL_ID])
INCLUDE ([user_id],[deleted])
GO

IF EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ACCOUNT_USER_EXCLUDE_uid' AND object_id = OBJECT_ID('dbo.[ACCOUNT_USER_EXCLUDE]'))
BEGIN
    DROP INDEX IX_ACCOUNT_USER_EXCLUDE_uid ON dbo.[ACCOUNT_USER_EXCLUDE]
END
GO

CREATE NONCLUSTERED INDEX IX_ACCOUNT_USER_EXCLUDE_uid
ON [dbo].[ACCOUNT_USER_EXCLUDE] ([uid])
GO

IF EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ACCOUNT_account_id' AND object_id = OBJECT_ID('dbo.[ACCOUNT]'))
BEGIN
    DROP INDEX IX_ACCOUNT_account_id ON dbo.[ACCOUNT]
END
GO

CREATE NONCLUSTERED INDEX IX_ACCOUNT_account_id
ON [dbo].[ACCOUNT] ([account_id])
INCLUDE ([account_ref],[internalemail])
GO

IF EXISTS(SELECT * FROM sys.indexes WHERE name='IX_ACCOUNT_EXTERNAL_SITES_siteguid' AND object_id = OBJECT_ID('dbo.[ACCOUNT_EXTERNAL_SITES]'))
BEGIN
    DROP INDEX IX_ACCOUNT_EXTERNAL_SITES_siteguid ON dbo.[ACCOUNT_EXTERNAL_SITES]
END
GO

CREATE NONCLUSTERED INDEX [IX_ACCOUNT_EXTERNAL_SITES_siteguid] ON [dbo].[ACCOUNT_EXTERNAL_SITES]
(
	[siteguid] ASC
) INCLUDE (account_id)
GO

declare @createoralter varchar(10)

if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = '2012SP_GetActivationInfo')
begin
    Print 'Creating Stored Procedure 2012SP_GetActivationInfo'
    SET @createoralter = 'CREATE'
end
else
begin
    Print 'Updating Stored Procedure 2012SP_GetActivationInfo'
    SET @createoralter = 'ALTER'
end
exec(@createoralter + ' PROCEDURE [dbo].[2012SP_GetActivationInfo]

@siteid uniqueidentifier,
@username varchar(255)

AS
BEGIN
	
declare @groupid int
set @groupid = 0

SELECT     TOP (1) @groupid = dbo.CONTRACTLEVEL_TITLES.GroupId
FROM         dbo.ACCOUNT_EXTERNAL_SITES INNER JOIN
                      dbo.ACCOUNT ON dbo.ACCOUNT_EXTERNAL_SITES.account_id = dbo.ACCOUNT.account_id INNER JOIN
                      dbo.ORDERS ON dbo.ACCOUNT.account_ref = dbo.ORDERS.account_ref INNER JOIN
                      dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId INNER JOIN
                      dbo.CONTRACTLEVEL_TITLES ON dbo.CONTRACTLEVELS.contractlevel = dbo.CONTRACTLEVEL_TITLES.CONTRACTLEVEL
WHERE     (dbo.ACCOUNT_EXTERNAL_SITES.siteguid = @siteid) AND (dbo.ORDERS.expiration > GETDATE()) AND (dbo.CONTRACTLEVEL_TITLES.GroupId = 2)

if @groupid = 2
begin

	select 3 as activationlevel
	
	SELECT     
			case when DETAILTYPES.EXTERNALUSERS = 1 and (ACCOUNT.internalemail is null or ACCOUNT.internalemail = '''') then 0
			ELSE  MAX(dbo.ORDERDETAIL.quantity * CONTRACTDETAILRES.MULT) end AS Quantity, 
	
	case when DETAILTYPES.EXTERNALUSERS = 1 then dbo.DETAILTYPES.detail_name + '' (Internal Domain: '''''' + account.internalemail + '''''')''
	else dbo.DETAILTYPES.detail_name end AS LevelName, dbo.CONTRACTDETAILRES.FEATURES, 
                      dbo.ORDERDETAIL.detail_type_id AS ResLevel, COUNT(dbo.ACCOUNT_USERS.user_id) AS UserCount
	FROM         dbo.ACCOUNT_EXTERNAL_SITES INNER JOIN
						  dbo.ACCOUNT ON dbo.ACCOUNT_EXTERNAL_SITES.account_id = dbo.ACCOUNT.account_id INNER JOIN
						  dbo.ORDERS ON dbo.ACCOUNT.account_ref = dbo.ORDERS.account_ref INNER JOIN
						  dbo.ORDERDETAIL ON dbo.ORDERS.order_id = dbo.ORDERDETAIL.order_id INNER JOIN
						  dbo.DETAILTYPES ON dbo.ORDERDETAIL.detail_type_id = dbo.DETAILTYPES.detail_type_id INNER LOOP JOIN
						  dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId INNER LOOP JOIN
						  dbo.CONTRACTDETAILRES ON dbo.CONTRACTLEVELS.contractlevel = dbo.CONTRACTDETAILRES.CONTRACTLEVEL AND 
						  dbo.ORDERDETAIL.detail_type_id = dbo.CONTRACTDETAILRES.DETAILTYPE LEFT OUTER JOIN
						  dbo.ACCOUNT_USERS ON dbo.ACCOUNT_EXTERNAL_SITES.account_id = dbo.ACCOUNT_USERS.account_id AND 
						  dbo.ORDERDETAIL.detail_type_id = dbo.ACCOUNT_USERS.DETAIL_ID AND NOT EXISTS (SELECT 1 FROM dbo.ACCOUNT_USER_EXCLUDE WHERE dbo.ACCOUNT_USER_EXCLUDE.[uid] = dbo.ACCOUNT_USERS.[user_id])
	WHERE     (dbo.ACCOUNT_EXTERNAL_SITES.siteguid = @siteid) AND (dbo.ORDERS.expiration > GETDATE())
	AND (dbo.ACCOUNT_USERS.deleted IS NULL)
	GROUP BY dbo.DETAILTYPES.detail_name, dbo.CONTRACTDETAILRES.FEATURES, dbo.ORDERDETAIL.detail_type_id, account.internalemail, DETAILTYPES.EXTERNALUSERS
	order by orderdetail.detail_type_id



	declare @detailid int

	set @detailid = 0



	SELECT     @detailid = tempUsers.DETAIL_ID
		FROM         dbo.ACCOUNT_EXTERNAL_SITES 
			INNER JOIN (select 
		dbo.USERS.[uid], account_id, DETAIL_ID
		FROM dbo.USERS 
			INNER JOIN dbo.ACCOUNT_USERS ON dbo.ACCOUNT_USERS.[user_id] = dbo.USERS.uid
		WHERE dbo.USERS.username = @username and account_users.deleted is null)tempUsers ON
				tempUsers.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id 

		WHERE     (dbo.ACCOUNT_EXTERNAL_SITES.siteguid = @siteid)

	if @detailid = 0 or @detailid is null
	begin
		if exists (SELECT     ACCOUNT_USER_EXCLUDE.[uid]
						FROM         dbo.ACCOUNT_USER_EXCLUDE INNER JOIN
						  dbo.USERS ON dbo.ACCOUNT_USER_EXCLUDE.uid = dbo.USERS.uid where username = @username)
		begin
			select 9999
		end
		else
		begin
			select 0	
		end
	end
	else
	begin
		select @detailid
	end
end
else
begin
	

	declare @cLevel int
	declare @usercount int
	declare @maxusers int

	SELECT     @cLevel = MAX(dbo.CONTRACTLEVELS.contractlevel)
	FROM         dbo.ACCOUNT INNER JOIN
						  dbo.ACCOUNT_EXTERNAL_SITES ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id INNER JOIN
						  dbo.ORDERS ON dbo.ACCOUNT.account_ref = dbo.ORDERS.account_ref INNER JOIN
						  dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId
	WHERE     (dbo.ACCOUNT_EXTERNAL_SITES.siteguid = @siteid) AND (dbo.ORDERS.expiration > GETDATE())


	if @cLevel is not null
	begin

		select 1

		SELECT    @maxusers = COALESCE (SUM(dbo.ORDERS.quantity), 0)
		FROM         dbo.ACCOUNT INNER JOIN
							  dbo.ACCOUNT_EXTERNAL_SITES ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id INNER JOIN
							  dbo.ORDERS ON dbo.ACCOUNT.account_ref = dbo.ORDERS.account_ref INNER JOIN
							  dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId
		WHERE     (dbo.ACCOUNT_EXTERNAL_SITES.siteguid = @siteid) AND (dbo.ORDERS.expiration > GETDATE()) AND 
							  (dbo.CONTRACTLEVELS.contractlevel = 4 or dbo.CONTRACTLEVELS.contractlevel = 2)

		SELECT     @usercount = COUNT(dbo.ACCOUNT_USERS.user_id)
		FROM         dbo.ACCOUNT INNER JOIN
							  dbo.ACCOUNT_EXTERNAL_SITES ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id INNER JOIN
							  dbo.ACCOUNT_USERS ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_USERS.account_id
		WHERE     (dbo.ACCOUNT_EXTERNAL_SITES.siteguid = @siteid) AND account_users.deleted is null and (dbo.ACCOUNT_USERS.user_id NOT IN
								  (SELECT     uid
									FROM          dbo.ACCOUNT_USER_EXCLUDE))

		select @cLevel as level, @usercount as usercount, @maxusers as maxusers


		if exists (SELECT     dbo.ACCOUNT_USERS.user_id
					FROM         dbo.USERS INNER JOIN
						  dbo.ACCOUNT_USERS ON dbo.USERS.uid = dbo.ACCOUNT_USERS.user_id INNER JOIN
						  dbo.ACCOUNT_EXTERNAL_SITES ON dbo.ACCOUNT_USERS.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id where username=@username and siteguid=@siteid and account_users.deleted is null)
		begin
			 select 1
		end
		else
		begin
			if exists (SELECT     ACCOUNT_USER_EXCLUDE.[uid]
				FROM         dbo.ACCOUNT_USER_EXCLUDE INNER JOIN
                  dbo.USERS ON dbo.ACCOUNT_USER_EXCLUDE.uid = dbo.USERS.uid where username = @username)
			begin
				select 1
			end
			else
			begin
				select 0
			end
		end

	end
	else
	begin 
		--Trial Code
		declare @monthsfree int
		declare @dtEndDate datetime
		declare @dtCreated datetime
		declare @daysLeft int

		SELECT     
		@dtCreated=dtCreated, 
		@monthsfree=monthsfree, 
		@maxUsers=maxusers
		
		FROM         dbo.ACCOUNT_External_SITES INNER JOIN
							  dbo.ACCOUNT ON dbo.ACCOUNT_External_SITES.account_id = dbo.ACCOUNT.account_id
		where siteguid = @siteid

		set @dtEndDate = dateadd(month, @monthsfree, @dtCreated)
		
		set @daysLeft = DATEDIFF(d,GETDATE(), @dtEndDate)		

		if @daysLeft <= 0
		begin

			select 0 as activationlevel
		
		end
		else
		begin

			select 2 as activationlevel
	
			SELECT     @usercount = COUNT(dbo.ACCOUNT_USERS.user_id)
			FROM         dbo.ACCOUNT INNER JOIN
								  dbo.ACCOUNT_EXTERNAL_SITES ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id INNER JOIN
								  dbo.ACCOUNT_USERS ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_USERS.account_id
			WHERE     (dbo.ACCOUNT_EXTERNAL_SITES.siteguid = @siteid) AND account_users.deleted is null and (dbo.ACCOUNT_USERS.user_id NOT IN
								  (SELECT     uid
									FROM          dbo.ACCOUNT_USER_EXCLUDE))

			select 4 as level, @usercount as usercount, @maxUsers as maxusers

			if exists (SELECT     dbo.ACCOUNT_USERS.user_id
						FROM         dbo.USERS INNER JOIN
							  dbo.ACCOUNT_USERS ON dbo.USERS.uid = dbo.ACCOUNT_USERS.user_id INNER JOIN
							  dbo.ACCOUNT_EXTERNAL_SITES ON dbo.ACCOUNT_USERS.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id where username=@username and siteguid=@siteid and account_users.deleted is null)
			begin
				 select 1
			end
			else
			begin

				if exists (SELECT     ACCOUNT_USER_EXCLUDE.[uid]
					FROM         dbo.ACCOUNT_USER_EXCLUDE INNER JOIN
                      dbo.USERS ON dbo.ACCOUNT_USER_EXCLUDE.uid = dbo.USERS.uid where username = @username)
				begin
					select 1
				end
				else
				begin
					select 0
				end
			end

		end
	end
end





END

')