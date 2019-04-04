using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V703, Order = 2.0, Description = "Insert alloction notifier job type")]
    internal class AllocationNotification : UpgradeStep
    {
        public AllocationNotification(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
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
                        epmLiveCn.ExecuteNonQuery(@"IF NOT EXISTS (SELECT * FROM [dbo].[TIMERJOBTYPES] where [JOBTYPE_ID]=33) 
                                    BEGIN 
	                                    INSERT [dbo].[TIMERJOBTYPES] ([JOBTYPE_ID], [NetAssembly], [NetClass], [Title], [Priority]) 
	                                    VALUES (33, N'TimeSheets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5', 
                                        N'TimeSheets.AllocationNotificationJob', N'Allocation Notification', 50) 
                                    END ");
                        #endregion

                        LogMessage("New Job type (Allocation noification) sucessfully added to TIMERJOBTYPES table.", MessageKind.SUCCESS, 4);
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
