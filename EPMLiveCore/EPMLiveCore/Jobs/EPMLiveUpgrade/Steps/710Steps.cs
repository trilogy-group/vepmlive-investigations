using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V710, Order = 1.0, Description = "New email templates to accomplish a new feature: Timesheet rejection mail.")]
    internal class EmailNotificationsUpdateTemplates : UpgradeStep
    {
        public EmailNotificationsUpdateTemplates(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {

        }

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            var result = true;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);

                    string epmLiveCnStr = CoreFunctions.getConnectionString(webAppId);
                    using (var epmLiveCn = new SqlConnection(epmLiveCnStr))
                    {
                        epmLiveCn.Open();
                        epmLiveCn.ExecuteNonQuery(@"IF EXISTS (SELECT * FROM EMAILTEMPLATES WHERE EMAILID=18)
	DELETE EMAILTEMPLATES WHERE EMAILID=18;

if not exists (select * from EMAILTEMPLATES where emailid=18)
BEGIN
	INSERT INTO EMAILTEMPLATES ([EMAILID], [BODY], [SUBJECT], [TITLE])
	VALUES(18, 
	'<html><body><table width=""100%"" cellpadding=""0"" cellspacing=""0""><tr><td style=""font-size:20px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">Dear {TimeSheetUser_Name},<br></td></tr><tr><td>&nbsp;</td></tr><tr><td style=""font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">The following timesheet entries were rejected by {Manager_Name}:</u></td></tr><tr><td>&nbsp;</td></tr><tr><td style=""font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif""><ul>{Element_Entries}</ul></td></tr><tr><td>&nbsp;</td></tr><tr><td style=""font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">Notes : {Manager_Notes}.</td></tr><tr><td>&nbsp;</td></tr><tr><td style=""font-size:12px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">For help, please visit <a href=""http://support.skyvera.com"" style=""font-size:12px;color:#3366CC;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">http://support.skyvera.com</a></td></tr><tr><td><hr></td></tr><tr><td style=""font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">Powered by Skyvera :)</td></tr></table></body></html>',
	'Your timesheet entry was rejected',
	'Email time Allocation - Not a team member');
END"
);
                        LogMessage("New templates sucessfully added to EMAILTEMPLATES (case they don't exist already).", MessageKind.SUCCESS, 4);
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

    [UpgradeStep(Version = EPMLiveVersion.V710, Order = 2, Description = "Disable throttling for the task center list")]
    internal class DisableTaskCenterThrolling : UpgradeStep
    {
        public DisableTaskCenterThrolling(SPWeb web, bool isPfeSite)
            : base(web, isPfeSite)
        {
        }

        private const string TaskCenterListName = "Task Center";
        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    var list = Web.Lists.TryGetList(TaskCenterListName);

                    if (list != null)
                    {
                        list.EnableThrottling = false;

                        LogMessage("Throttling was disabled successfully", MessageKind.SUCCESS, 4);
                    }
                    else
                    {
                        LogMessage("List cannot not found", MessageKind.SKIPPED, 4);
                    }
                });

                return true;
            }
            catch (Exception exception)
            {
                var logException = exception.InnerException ?? exception;
                LogMessage(logException.ToString(), MessageKind.FAILURE, 4);
                return false;
            }
        }

    }
}
