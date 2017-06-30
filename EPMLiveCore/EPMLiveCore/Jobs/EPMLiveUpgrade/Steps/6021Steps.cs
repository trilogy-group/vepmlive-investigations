using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V621, Order = 1.0, Description = "New email templates to accomplish a new feature: Timesheet rejection mail.")]
    internal class EmailNotificationsTemplates : UpgradeStep
    {
        public EmailNotificationsTemplates(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
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
                        epmLiveCn.ExecuteNonQuery(@"if exists (select * from EMAILTEMPLATES where emailid=18)
	delete EMAILTEMPLATES where emailid=18;

if not exists (select * from EMAILTEMPLATES where emailid=18)
begin
	insert into EMAILTEMPLATES ([EmailId], [Body], [Subject], [Title])
	values(18, 
	'<html><body><table width=""100%"" cellpadding=""0"" cellspacing=""0""><tr><td style=""font-size:20px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">Dear {TimeSheetUser_Name},<br></td></tr><tr><td>&nbsp;</td></tr><tr><td style=""font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">The following timesheet entries were rejected by Project Manager:</u></td></tr><tr><td>&nbsp;</td></tr><tr><td style=""font-size:15px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif""><ul>{Element_Entries}</ul></td></tr><tr><td>&nbsp;</td></tr><tr><td style=""font-size:12px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">For help, please visit <a href=""http://support.epmlive.com"" style=""font-size:12px;color:#3366CC;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">http://support.epmlive.com</a></td></tr><tr><td><hr></td></tr><tr><td style=""font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">Powered by EPM Live :)</td></tr></table></body></html>',
	'Your timesheet entry was rejected',
	'Email time Allocation - Not a team member');
end"
);
                        #endregion

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
}
