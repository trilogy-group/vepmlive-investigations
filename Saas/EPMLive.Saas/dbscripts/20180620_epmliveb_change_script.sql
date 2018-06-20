IF OBJECT_ID(N'dbo.ACCOUNT', N'U') IS NOT NULL AND NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = N'secondary_owner_id' AND TABLE_NAME = N'ACCOUNT')
BEGIN
	print 'Adding secondary_owner_id field'
	-- create secondary owner field
	ALTER TABLE ACCOUNT
	ADD [secondary_owner_id] [uniqueidentifier] NULL

	IF OBJECT_ID(N'dbo.2010SP_GetSiteAccountNums') IS NOT NULL 
	BEGIN
		-- only update procedure when new field was created
		print 'Updating 2010SP_GetSiteAccountNums procedure'
		EXEC ('ALTER PROCEDURE [dbo].[2010SP_GetSiteAccountNums]

@siteid uniqueidentifier,
@contractLevel int

AS
BEGIN

	declare @isTrial int
	declare @isExpired bit
	declare @daysleft int
	declare @dtCreated datetime
	declare @monthsfree int
	declare @dtEndDate datetime
	declare @accountRef int
	declare @maxUsers int
	declare @maxOrderUsers int
	declare @userCount int
	declare @accountId uniqueidentifier
	declare @userid uniqueidentifier
	declare @accountOwnerName varchar(255)
	declare @externalid uniqueidentifier
	declare @accountDesc varchar(8000)
	declare @ownerusername varchar(500)
	declare @billingtype int
	declare @owneremail varchar(1000)
	declare @maxOrderDisk int
	declare @lockusers bit
	declare @accountSecondaryOwnerId uniqueidentifier
	declare @accountSecondaryOwnerLogin varchar(500)
	
	select @externalid = account_external_site_id
	from account_external_sites where siteguid = @siteid

	if @externalid is null
	begin
		SELECT     
		@isTrial = dbo.ACCOUNT.inTrial,
		@dtCreated=dtCreated, 
		@monthsfree=monthsfree, 
		@accountRef=account_ref,
		@maxUsers=maxusers,
		@accountId=account.account_id,
		@userid = account.owner_id,
		@accountSecondaryOwnerId = account.secondary_owner_id,
		@billingtype = coalesce(billingtype,0),
		@accountDesc = accountdescription,
		@lockusers = coalesce(lockusers, 0)
		FROM         dbo.ACCOUNT_SITES INNER JOIN
							  dbo.ACCOUNT ON dbo.ACCOUNT_SITES.account_id = dbo.ACCOUNT.account_id
		where siteguid = @siteid

		SELECT     @userCount =COUNT(dbo.ACCOUNT_USERS.account_user_guid)
		FROM         dbo.ACCOUNT INNER JOIN
							  dbo.ACCOUNT_USERS ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_USERS.account_id INNER JOIN
							  dbo.ACCOUNT_SITES ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_SITES.account_id
		WHERE     siteguid=@siteid and account_users.deleted is null
		and dbo.ACCOUNT_USERS.user_id not in (select [uid] from ACCOUNT_USER_EXCLUDE)
	end
	else
	begin
			SELECT     
		@isTrial = dbo.ACCOUNT.inTrial,
		@dtCreated=dtCreated, 
		@monthsfree=monthsfree, 
		@accountRef=account_ref,
		@maxUsers=maxusers,
		@accountId=account.account_id,
		@userid = account.owner_id,
		@accountSecondaryOwnerId = account.secondary_owner_id,
		@billingtype = coalesce(billingtype,0),
		@accountDesc = accountdescription,
		@lockusers = coalesce(lockusers, 0)
		FROM         dbo.ACCOUNT_EXTERNAL_SITES INNER JOIN
							  dbo.ACCOUNT ON dbo.ACCOUNT_EXTERNAL_SITES.account_id = dbo.ACCOUNT.account_id
		where siteguid = @siteid

		SELECT     @userCount =COUNT(dbo.ACCOUNT_USERS.account_user_guid)
		FROM         dbo.ACCOUNT INNER JOIN
                      dbo.ACCOUNT_USERS ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_USERS.account_id INNER JOIN
                      dbo.ACCOUNT_EXTERNAL_SITES ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id LEFT OUTER JOIN
                      dbo.ACCOUNT_USER_EXCLUDE ON dbo.ACCOUNT_USERS.user_id = dbo.ACCOUNT_USER_EXCLUDE.uid
		WHERE     siteguid=@siteid and account_users.deleted is null
		 and dbo.ACCOUNT_USER_EXCLUDE.uid is null
	end

	declare @groupid int

	set @groupid = 1

		SELECT     TOP (1) @groupid = dbo.CONTRACTLEVEL_TITLES.GroupId
		FROM         dbo.ACCOUNT_EXTERNAL_SITES INNER JOIN
							  dbo.ACCOUNT ON dbo.ACCOUNT_EXTERNAL_SITES.account_id = dbo.ACCOUNT.account_id INNER JOIN
							  dbo.ORDERS ON dbo.ACCOUNT.account_ref = dbo.ORDERS.account_ref INNER JOIN
							  dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId INNER JOIN
							  dbo.CONTRACTLEVEL_TITLES ON dbo.CONTRACTLEVELS.contractlevel = dbo.CONTRACTLEVEL_TITLES.CONTRACTLEVEL
		WHERE     (dbo.ACCOUNT_EXTERNAL_SITES.siteguid = @siteid) AND (dbo.ORDERS.expiration > GETDATE()) AND (dbo.CONTRACTLEVEL_TITLES.GroupId = 2)

	if @groupid = 2
	begin
		
		SELECT     TOP (1) @contractLevel = dbo.CONTRACTLEVELS.contractlevel
		FROM         dbo.ACCOUNT_EXTERNAL_SITES INNER JOIN
							  dbo.ACCOUNT ON dbo.ACCOUNT_EXTERNAL_SITES.account_id = dbo.ACCOUNT.account_id INNER JOIN
							  dbo.ORDERS ON dbo.ACCOUNT.account_ref = dbo.ORDERS.account_ref INNER JOIN
							  dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId INNER JOIN
							  dbo.CONTRACTLEVEL_TITLES ON dbo.CONTRACTLEVELS.contractlevel = dbo.CONTRACTLEVEL_TITLES.CONTRACTLEVEL
		WHERE     (dbo.ACCOUNT_EXTERNAL_SITES.siteguid = @siteid) AND (dbo.ORDERS.expiration > GETDATE()) AND (dbo.CONTRACTLEVEL_TITLES.GroupId = 2)
		order by dbo.CONTRACTLEVELS.contractlevel desc

	end

	set @maxOrderUsers = 0

	select @maxOrderUsers = sum(quantity)
	FROM         dbo.ORDERS INNER JOIN dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId
	where account_ref=@accountRef
	and  (expiration = ''12/31/9999 11:59:59 PM'' OR DATEADD(day,15,expiration) >= GETDATE()) and contractLevel = @contractLevel

	select @maxOrderDisk = sum(diskspace)
	FROM         dbo.ORDERS INNER JOIN dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId
	where account_ref=@accountRef
	and  (expiration = ''12/31/9999 11:59:59 PM'' OR DATEADD(day,1,expiration) >= GETDATE()) and contractLevel = @contractLevel and diskspace is not null

	set @dtEndDate = dateadd(month,@monthsfree ,@dtCreated)
		
	set @daysLeft = DATEDIFF(d,GETDATE(),@dtEndDate)

	if @maxOrderUsers = 0 or @maxOrderUsers is null
	begin
		
		set @isTrial = 1

		if @daysLeft <= 0
		begin
			set @isExpired = 1
		end
		else
		begin
			set @isExpired = 0
		end
	
	end
	else
	begin

		set @isTrial = 0

		set @maxUsers = @maxOrderUsers

		if @userCount > @maxUsers and @billingtype <> 2 and @maxUsers >= 0 and @groupid <> 2
		begin
			set @isExpired = 1
		end
		else
		begin
			set @isExpired = 0
		end
	
	end

	
if @daysLeft < 0
begin
	set @daysLeft = 0
end

SELECT @accountOwnerName = USERS.firstname + '' '' + USERS.lastname, @ownerusername = users.username, @owneremail = USERS.email FROM USERS where [uid] = @userid
SELECT @accountSecondaryOwnerLogin = users.username FROM USERS where [uid] = @accountSecondaryOwnerId

select
coalesce(@maxUsers,0) as maxUsers,
@userCount  as userCount,
@accountid as accountid,
@userid as userid,
@isTrial as inTrial,
@accountOwnerName as accountOwnerName,
@isExpired as isExpired,
@daysLeft as daysLeft,
@dtCreated as trialStart,
@dtEndDate as trialExpiration,
@accountRef as accountref,
@billingtype as billingtype,
@accountDesc as accountdesc,
@ownerusername as ownerusername,
@owneremail as owneremail,
@maxOrderDisk as maxDisk,
@lockusers as lockusers,
@accountSecondaryOwnerLogin as accountSecondaryOwnerLogin --17

END')
	END
END
GO
