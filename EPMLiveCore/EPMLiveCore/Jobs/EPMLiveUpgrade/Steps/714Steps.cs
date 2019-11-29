using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using System.Collections.Generic;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V714, Order = 1.0, Description = "Fix workspace center query")]
    internal class UpdateWorkspaceCenterQuery : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public UpdateWorkspaceCenterQuery(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    LogMessage("Connecting to the database . . .", 2);
                    Guid webAppId = Web.Site.WebApplication.Id;
                    Guid SiteId = Web.Site.ID;
                    string rptCnStr = CoreFunctions.getReportingConnectionString(webAppId, SiteId);
                    using (var rptCn = new SqlConnection(rptCnStr))
                    {
                        rptCn.Open();

                        #region Index Code

                        rptCn.ExecuteNonQuery($@"
ALTER PROCEDURE [dbo].[spGetWorkspaces]
        @UserId AS INT,
        @SiteId AS UNIQUEIDENTIFIER,
        @View AS varchar(50)  
AS
BEGIN
    SET NOCOUNT ON;

	CREATE TABLE #Groups (GroupId INT)
	INSERT INTO #Groups (GroupId) SELECT GROUPID FROM dbo.RPTGROUPUSER WHERE (USERID = @UserId) AND (SITEID = @SiteId)
  
	Declare @TmpUserId AS INT
	IF @UserId = 1073741823
	BEGIN
		SET @TmpUserId = 1
	END
	ELSE
	BEGIN
		SET @TmpUserId = @UserId
	END
	
    
	SELECT DISTINCT 
	dbo.RPTWeb.SiteId,dbo.RPTWeb.Webtitle,(CASE WHEN T3.GroupId is null THEN '(Private)' ELSE '(Public)' END)+ dbo.RPTWeb.WebDescription  WebDescription,dbo.RPTWeb.WebId,dbo.RPTWeb.Members,dbo.RPTWeb.WebUrl,dbo.LSTResourcepool.SharePointAccountText,
	
	CASE 
		WHEN @UserId = 1073741823 THEN 1 
		WHEN T1.SECTYPE = 1 AND T2.GroupId is not null
		OR T1.SECTYPE = 0 AND T1.GROUPID = @UserId THEN 1
	ELSE 0 
	END AS HasAccess
	FROM dbo.RPTWeb  INNER JOIN dbo.LSTResourcepool ON @UserId = dbo.LSTResourcepool.SharePointAccountID 
	LEFT OUTER JOIN dbo.RPTWEBGROUPS T1
	ON  dbo.RPTWeb.WebId = T1.WebID
	LEFT OUTER JOIN #Groups T2 
	on  T1.GROUPID = T2.GROUPID 
	LEFT OUTER JOIN dbo.RPTWEBGROUPS T3
	ON dbo.RPTWeb.ParentWebId = T3.WebID
	AND  T3.GroupID = T1.GroupID
	WHERE dbo.RPTWeb.SiteId = @SiteId 
	AND dbo.RPTWeb.ParentWebId <> '00000000-0000-0000-0000-000000000000'
	AND (@UserId = 1073741823 
		OR (T1.SECTYPE = 1 AND T2.GroupId is not null 
			OR T1.SECTYPE = 0 AND T1.GROUPID = @UserId)
			AND 
			(@View = 'AllItems'
			OR @View = 'MyWorkspace' and T3.GroupId is null)
	)
	order by dbo.RPTWeb.WebTitle  
END												  
                        ");

                        #endregion

                        LogMessage("Procedure spGetWorkspaces has been updated.", MessageKind.SUCCESS, 4);

                    }
                });


            }
            catch (Exception exception)
            {
                string message = exception.InnerException != null
                    ? exception.InnerException.Message
                    : exception.Message;

                LogMessage(message, MessageKind.FAILURE, 4);
                return false;
            }
            return true;
        }

        #endregion
    }


    [UpgradeStep(Version = EPMLiveVersion.V714, Order = 2.0, Description = "Add trigger to prevent duplicate PFE jobs")]
    internal class AddDuplicateJobsTrigger : UpgradeStep
    {
        private SPWeb _spWeb;
        private const string TriggerDropScript = @"
IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[EPG_JOBS_Cancel_PCV_Job_Insert]'))
DROP TRIGGER [dbo].[EPG_JOBS_Cancel_PCV_Job_Insert]
";
        private const string TriggerCreateScript = @"
/****** Object:  Trigger [dbo].[EPG_JOBS_Cancel_PCV_Job_Insert]    Script Date: 11/18/2019 10:30:30 PM ******/
CREATE TRIGGER [dbo].[EPG_JOBS_Cancel_PCV_Job_Insert]
   ON  [dbo].[EPG_JOBS]
   INSTEAD OF INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO EPG_JOBS 
	SELECT DISTINCT 
	[JOB_GUID]
      ,[JOB_AFTER_GUID]
      ,[JOB_CONTEXT]
      ,[JOB_SESSION]
      ,[WRES_ID]
      ,[JOB_SUBMITTED]
      ,[JOB_STARTED]
      ,[JOB_COMPLETED]
      ,[JOB_ERRORCODE]
      ,[JOB_STATUS]
      ,[JOB_COMMENT]
      ,cast([JOB_CONTEXT_DATA] as nvarchar(max))
      ,cast([JOB_CONTEXT_RESULT] as nvarchar(max))
	 FROM INSERTED
	WHERE cast(job_context_data as nvarchar(max)) <> N'<Request><EPKSet><EPKAuth></EPKAuth><EPKProcess><RequestNo>5</RequestNo></EPKProcess></EPKSet></Request>'
	OR NOT EXISTS(SELECT 1 FROM EPG_JOBS WHERE cast(job_context_data as nvarchar(max)) = N'<Request><EPKSet><EPKAuth></EPKAuth><EPKProcess><RequestNo>5</RequestNo></EPKProcess></EPKSet></Request>' AND job_status = 0)
	
END

ALTER TABLE [dbo].[EPG_JOBS] ENABLE TRIGGER [EPG_JOBS_Cancel_PCV_Job_Insert]

";
        #region Constructors (1) 
        public AddDuplicateJobsTrigger(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

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
                LogMessage(e.Message, MessageKind.FAILURE, 1);
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
                connection.ExecuteNonQuery(TriggerDropScript);
                LogMessage("Trigger dropped.", MessageKind.SUCCESS, 1);
                connection.ExecuteNonQuery(TriggerCreateScript);
                LogMessage("Trigger created.", MessageKind.SUCCESS, 1);
            }
        }
        #endregion
    }
}
