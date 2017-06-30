using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V610, Order = 5.0, Description = "New PreviousPName column on LSTProjectCenter table to store previous project name.")]
    internal class NewPreviousProjectNameColumn : UpgradeStep
    {
        public NewPreviousProjectNameColumn(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
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

                    var DAO = new ReportHelper.EPMData(Web.Site.ID);
                    using (DAO.GetClientReportingConnection)
                    {                        
                        #region ViewCode
                        DAO.GetClientReportingConnection.ExecuteNonQuery(@"IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'PreviousPName' AND Object_ID = Object_ID(N'LSTProjectCenter'))
                                                    BEGIN
	                                                    ALTER TABLE [LSTProjectCenter] ADD [PreviousPName] NVARCHAR(512) NULL;
	                                                    EXEC('UPDATE [LSTProjectCenter] SET [PreviousPName]=[TITLE];');
                                                    END");
                        #endregion

                        LogMessage("New PreviousPName column sucessfully added to LSTProjectCenter.", MessageKind.SUCCESS, 4);
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
