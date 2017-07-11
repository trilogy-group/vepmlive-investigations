using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V621, Order = 2.0, Description = "New SSRS sync job type to TIMERJOBTYPES table.")]
    internal class AddNewSSRSSyncJobType : UpgradeStep
    {
        public AddNewSSRSSyncJobType(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {

        }

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            bool result = true;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);

                    string epmLiveCnStr = CoreFunctions.getConnectionString(webAppId);
                    using (var epmLiveCn = new SqlConnection(epmLiveCnStr))
                    {
                        epmLiveCn.Open();

                        #region ViewCode
                        epmLiveCn.ExecuteNonQuery(@"IF NOT EXISTS (SELECT * FROM [dbo].[TIMERJOBTYPES] where [JOBTYPE_ID]=14) 
BEGIN 
	INSERT [dbo].[TIMERJOBTYPES] ([JOBTYPE_ID], [NetAssembly], [NetClass], [Title], [Priority]) 
	VALUES (14, N'EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', N'EPMLiveCore.Jobs.SSRS.SyncJob', N'SSRS Sync Job', 20) 
END ");
                        #endregion

                        LogMessage("New Job type (SSRS Sync) sucessfully added to TIMERJOBTYPES table.", MessageKind.SUCCESS, 4);
                    }
                }
                catch (Exception exception)
                {
                    string message = exception.InnerException != null
                        ? exception.InnerException.Message
                        : exception.Message;

                    LogMessage(message, MessageKind.FAILURE, 4);

                    result = false;
                }
            });

            return result;
        }
    }
}
