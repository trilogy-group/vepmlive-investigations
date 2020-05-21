using System;
using Microsoft.SharePoint;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V721, Order = 1.0, Description = "Fix Rate Ranges returned by EPG_SP_GetResourceRates")]
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
}
