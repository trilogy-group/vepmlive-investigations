using System;
using Microsoft.SharePoint;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using System.Data.SqlClient;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V722, Order = 1.0, Description = "Fix Rate Ranges returned by EPG_SP_GetResourceRates")]
    internal class Fix_RateRanges_For_EPG_SP_GetResourceRates : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private readonly string script = @"declare @createoralter varchar(10)
        if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_GetResourceRates')
        begin
            Print 'Creating Stored Procedure EPG_SP_GetResourceRates'
            SET @createoralter = 'CREATE'
        end
        else
        begin
            Print 'Updating Stored Procedure EPG_SP_GetResourceRates'
            SET @createoralter = 'ALTER'
        end
        exec(@createoralter + ' PROCEDURE [dbo].[EPG_SP_GetResourceRates]
         @ResourceEXTID int,
           @PRD_Start varchar(20),
           @PRD_End varchar(20)
        AS
        BEgin
        Declare @BC_UID int=0
        set @BC_UID =(Select top 1  BC_UID From EPGP_COST_XREF  Where WRES_ID=@ResourceEXTID);
        
        with rates as (
        	SELECT
        		ROW_NUMBER() OVER(ORDER BY BC_EFFECTIVE_DATE) AS RN,
        		BC_EFFECTIVE_DATE as StartDate,
        		isnull(LEAD(BC_EFFECTIVE_DATE,1) OVER (ORDER BY BC_EFFECTIVE_DATE),dateadd(year,99,BC_EFFECTIVE_DATE)) AS NextEndDate,
        		bc_rate
        	FROM
        		EPG_COST_CATEGORY_RATE_VALUES where BC_UID = @BC_UID
        ) select cast((BC_RATE) as  decimal(16,2)) as BC_RATE
        from rates
        where isnull(StartDate,dateadd(day,-1,@PRD_Start)) < @PRD_Start and isnull(NextEndDate,dateadd(day,1,@PRD_End)) > @PRD_End
        order by rn
        End
        ')";

        public Fix_RateRanges_For_EPG_SP_GetResourceRates(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
            _spWeb = spWeb;
        }

        public override bool Perform()
        {
            try
            {
                LogTitle(GetWebInfo(Web), 1);
                if (IsPfeSite)
                {
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }
            }
            catch (Exception e)
            {
                LogMessage(e.ToString(), MessageKind.FAILURE, 1);
                return false;
            }
            return true;
        }

        private void UpgradePfeDatabase()
        {
            var connectionProvider = new PfeData.ConnectionProvider();
            LogMessage("Connecting to the database.", 2);
            using (var connection = connectionProvider.CreateConnection(Web))
            {
                connection.ExecuteNonQuery(script);
                LogMessage("EPG_SP_GetResourceRates has been successfully updated.", MessageKind.SUCCESS, 1);
            }
        }
    }


    [UpgradeStep(Version = EPMLiveVersion.V722, Order = 3.0, Description = "Include Named Rate in EPG_SP_GetResourceRates")]
    internal class Include_NamedRate_In_EPG_SP_GetResourceRates : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private readonly string script = @"declare @createoralter varchar(10)
        if not exists (select routine_name from INFORMATION_SCHEMA.routines where routine_name = 'EPG_SP_GetResourceRates')
        begin
            Print 'Creating Stored Procedure EPG_SP_GetResourceRates'
            SET @createoralter = 'CREATE'
        end
        else
        begin
            Print 'Updating Stored Procedure EPG_SP_GetResourceRates'
            SET @createoralter = 'ALTER'
        end
        exec(@createoralter + ' PROCEDURE [dbo].[EPG_SP_GetResourceRates]
         @ResourceEXTID int,
           @PRD_Start varchar(20),
           @PRD_End varchar(20)
        AS
        BEGIN
        Declare @Rate decimal(16,2)

        -- first check for Named Rates
        Declare @RT_UID int=0
        set @RT_UID =(select top 1 rt_uid from EPGP_COST_RATES where wres_id = @ResourceEXTID);

        if (@RT_UID is not null)
        begin
            with rates as (
                SELECT
                    ROW_NUMBER() OVER(ORDER BY RT_EFFECTIVE_DATE) AS RN,
                    RT_EFFECTIVE_DATE as StartDate,
                    isnull(LEAD(RT_EFFECTIVE_DATE,1) OVER (ORDER BY RT_EFFECTIVE_DATE),dateadd(year,99,RT_EFFECTIVE_DATE)) AS NextEndDate,
                    rt_rate
                FROM
                    EPG_RATE_VALUES where RT_UID = @RT_UID
            ) select @Rate= cast((RT_RATE) as  decimal(16,2))
            from rates
            where isnull(StartDate,dateadd(day,-1,@PRD_Start)) < @PRD_Start and isnull(NextEndDate,dateadd(day,1,@PRD_End)) > @PRD_End
            order by rn;

            -- if Named Rate defined, break
            if (@Rate is not null)
            begin
                select @Rate as BC_RATE
                return
            end
        end

        -- if no Named Rate, get the Role Rate
        Declare @BC_UID int=0
        set @BC_UID =(Select top 1  BC_UID From EPGP_COST_XREF  Where WRES_ID=@ResourceEXTID);
        
        with rates as (
            SELECT
                ROW_NUMBER() OVER(ORDER BY BC_EFFECTIVE_DATE) AS RN,
                BC_EFFECTIVE_DATE as StartDate,
                isnull(LEAD(BC_EFFECTIVE_DATE,1) OVER (ORDER BY BC_EFFECTIVE_DATE),dateadd(year,99,BC_EFFECTIVE_DATE)) AS NextEndDate,
                bc_rate
            FROM
                EPG_COST_CATEGORY_RATE_VALUES where BC_UID = @BC_UID
        ) select cast((BC_RATE) as  decimal(16,2)) as BC_RATE
        from rates
        where isnull(StartDate,dateadd(day,-1,@PRD_Start)) < @PRD_Start and isnull(NextEndDate,dateadd(day,1,@PRD_End)) > @PRD_End
        order by rn;
        End
        ')";

        public Include_NamedRate_In_EPG_SP_GetResourceRates(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
            _spWeb = spWeb;
        }

        public override bool Perform()
        {
            try
            {
                LogTitle(GetWebInfo(Web), 1);
                if (IsPfeSite)
                {
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }
            }
            catch (Exception e)
            {
                LogMessage(e.ToString(), MessageKind.FAILURE, 1);
                return false;
            }
            return true;
        }

        private void UpgradePfeDatabase()
        {
            var connectionProvider = new PfeData.ConnectionProvider();
            LogMessage("Connecting to the database.", 2);
            using (var connection = connectionProvider.CreateConnection(Web))
            {
                connection.ExecuteNonQuery(script);
                LogMessage("EPG_SP_GetResourceRates has been successfully updated.", MessageKind.SUCCESS, 1);
            }
        }
    }

    [UpgradeStep(Version = EPMLiveVersion.V722, Order = 4.0, Description = "Improve social stream")]
    internal class ImproveSocialStream2 : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private const string UpgradeScript = @"
ALTER PROCEDURE [dbo].[SS_GetLatestThreads] 
	@UserId INT, 
	@WebUrl NVARCHAR(MAX),
	@Page	INT = 1,
	@Limit	INT = 1000000,
	@ThreadId UNIQUEIDENTIFIER = NULL
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Start INT, @End INT
	
	SET @Start = (@Page - 1) * @Limit
	SET @End =   (@Page * @Limit + 1)
	
	IF @Limit > 1000000 SET @Limit = 1000000;
	 
	SELECT ThreadId, ThreadTitle, ThreadUrl, ThreadKind, ThreadLastActivityOn, ThreadFirstActivityOn, WebId, WebTitle, 
				WebUrl, ListId, ListName, ListIcon, ItemId, TotalActivities, TotalComments
	FROM (
			SELECT	 TOP (@End - 1) 
					ROW_NUMBER() OVER (ORDER BY SS_Threads.LastActivityDateTime DESC) AS RowNum,
					SS_Threads.Id AS ThreadId, SS_Threads.Title AS ThreadTitle, SS_Threads.URL AS ThreadUrl, 
					SS_Threads.Kind AS ThreadKind, SS_Threads.LastActivityDateTime AS ThreadLastActivityOn, 
					SS_Threads.FirstActivityDateTime AS ThreadFirstActivityOn, SS_Threads.WebId, dbo.RPTWeb.WebTitle, 
					dbo.RPTWeb.WebUrl, SS_Threads.ListId, dbo.RPTList.ListName, ReportListIds.ListIcon AS ListIcon, 
					SS_Threads.ItemId, 
					SS_Threads.TotalActivities,
                    SS_Threads.TotalComments, 
					1 AS HasAccess
				 
			FROM	(select distinct * from dbo.ReportListIds) ReportListIds INNER JOIN dbo.RPTList ON ReportListIds.Id = dbo.RPTList.RPTListId RIGHT OUTER JOIN 
					(	SELECT ISNULL(SS_Threads1.TotalActivities, 0) TotalActivities, ISNULL(SS_Threads2.TotalComments, 0) TotalComments, SS_Threads3.*
						FROM
							(	SELECT SS_Threads.Id, COUNT(A1.ID) TotalActivities 
								FROM (SELECT * FROM SS_Threads  WHERE 
								(SS_Threads.Id = @ThreadId OR @ThreadId IS NULL) AND 
								Deleted = 0) SS_Threads
								LEFT OUTER JOIN
								(select * from dbo.SS_Activities where (MassOperation = 0) AND (Kind <> 3 AND Kind <> 4)) a1 
								ON (A1.ThreadId = SS_Threads.Id)
								GROUP BY SS_Threads.Id
								HAVING COUNT(A1.ID) > 0
							) SS_Threads1
							full outer join 
							(	SELECT SS_Threads.Id, COUNT(A2.ID) TotalComments
								FROM (SELECT * FROM SS_Threads  WHERE 
								(SS_Threads.Id = @ThreadId OR @ThreadId IS NULL) AND 
								Deleted = 0) SS_Threads
								left outer join 
								(select * from dbo.SS_Activities where (Kind = 4)) a2 
								ON (A2.ThreadId = SS_Threads.Id)
								GROUP BY SS_Threads.Id
								HAVING COUNT(A2.ID) > 0
							)SS_Threads2
							ON SS_Threads1.ID = SS_Threads2.ID
							INNER JOIN SS_Threads SS_Threads3
							ON SS_Threads1.ID = SS_Threads3.ID OR SS_Threads2.ID = SS_Threads3.ID
					) SS_Threads
					INNER JOIN dbo.RPTWeb ON SS_Threads.WebId = dbo.RPTWeb.WebId ON dbo.RPTList.RPTListId = SS_Threads.ListId
			WHERE   (SS_Threads.Deleted = 0) AND (SS_Threads.Id = @ThreadId OR @ThreadId IS NULL) 
					AND (dbo.RPTWeb.WebUrl = @WebUrl OR dbo.RPTWeb.WebUrl LIKE REPLACE(@WebUrl + '/%', '//', '/'))
					ORDER BY SS_Threads.LastActivityDateTime DESC
					) AS DT1
	WHERE RowNum > @Start AND RowNum < @End
	
END";

        #region Constructors (1) 
        public ImproveSocialStream2(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    LogMessage("Connecting to the database . . .", 2);
                    Guid webAppId = Web.Site.WebApplication.Id;
                    Guid siteId = Web.Site.ID;
                    string rptCnStr = CoreFunctions.getReportingConnectionString(webAppId, siteId);
                    using (var rptCn = new SqlConnection(rptCnStr))
                    {
                        rptCn.Open();

                        #region Stored Procedure Code

                        rptCn.ExecuteNonQuery(UpgradeScript);

                        #endregion

                        LogMessage("Procedure upgraded", MessageKind.SUCCESS, 4);
                    }
                });
            }
            catch (Exception exception)
            {
                var message = exception.InnerException != null
                    ? exception.InnerException.Message
                    : exception.Message;

                LogMessage(message + exception, MessageKind.FAILURE, 4);
                return false;
            }
            return true;
        }

        #endregion
    }
}
