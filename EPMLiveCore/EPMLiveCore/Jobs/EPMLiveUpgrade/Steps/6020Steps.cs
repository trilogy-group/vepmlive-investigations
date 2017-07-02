using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V610, Order = 1.0, Description = "New email templates to accomplish a new feature: the non-team member time allocation notification.")]
    internal class NewEmailNotificationsTemplates : UpgradeStep
    {
        public NewEmailNotificationsTemplates(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
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
                        epmLiveCn.ExecuteNonQuery(@"if exists (select * from EMAILTEMPLATES where emailid=16 and [Subject] not like '%Task_Name%')
	delete EMAILTEMPLATES where emailid=16;

if not exists (select * from EMAILTEMPLATES where emailid=16)
begin
	insert into EMAILTEMPLATES ([EmailId], [Body], [Subject], [Title])
	values(16, 
	'<html>
	<body>
	<table width=""100%"" cellpadding=""0"" cellspacing=""0"">
	<tr>
	<td style=""font-size:14px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">You are being notified that {Qty_Hours} hour(s) has/have been charged to the {Item_Name}. <br/>The user responsible for booking this time is <u><a href=""mailto:{Resource_Email}"" style=""font-size:14px;color:#3366CC;"">{CurUser_Name}</a></u>. The user {Reason_Message}.</td>
	</tr>
	<tr><td>&nbsp;</td></tr>
	<tr><td><hr></td></tr>
	<tr>
	<td style=""font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">Powered by EPM Live :)</td>
	</tr>
	</table>
	</body>
	</html>',
	'Time has been booked to {Item_Name} by {Out_Unassigned} user',
	'Email time Allocation - Not a team member');
end


if exists (select * from EMAILTEMPLATES where emailid=17 and [Subject] not like '%Task_Name%')
	delete EMAILTEMPLATES where emailid=17;

if not exists (select * from EMAILTEMPLATES where emailid=17)
begin
	insert into EMAILTEMPLATES ([EmailId], [Body], [Subject], [Title])
	values
	(17,
	'<html>
	<body>
		<table width=""100%"" cellpadding=""0"" cellspacing=""0"">
			<tr>
				<td>{CurUser_Name} has charged {Hours} timesheet hour(s) to {Item_Name}. {CurUser_Name} {Reason_Message}.</td>
			</tr>         
			<tr><td>&nbsp;</td></tr>
			<tr><td><hr></td></tr>
			<tr>
				<td style=""font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">Powered by EPM Live :)</td>
			</tr>
		</table>
	</body>
	</html>',
	'Time has been booked to {Item_Name} by an outside user.',
	'Gen.Notification time Allocation - Not a team member');
end");
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
