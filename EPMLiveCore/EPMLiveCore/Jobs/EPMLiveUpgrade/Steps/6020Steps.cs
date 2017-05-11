using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V610, Order = 3.0, Description = "New email templates to accomplish a new feature: the non-team member time allocation notification.")]
    internal class NewEmailNotificationsTemplates : UpgradeStep
    {
        public NewEmailNotificationsTemplates(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {

        }

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);

                    string epmLiveCnStr = CoreFunctions.getConnectionString(webAppId);
                    using (var epmLiveCn = new SqlConnection(epmLiveCnStr))
                    {
                        try
                        {
                            epmLiveCn.Open();

                            #region ViewCode
                            epmLiveCn.ExecuteNonQuery(@"if not exists (select * from EMAILTEMPLATES where EmailId=16)
                                                        begin
                                                        insert into EMAILTEMPLATES(EmailId, Body, Subject, Title)
                                                        values (16, '<html>
                                                        <body>
                                                        <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr>
                                                        <td style=""font-size:14px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">You are being notified that {Qty_Hours} hour(s) has/have been charged to the {Project_Name} project. <br/>The user responsible for booking this time is <u><a href=""mailto:{Resource_Email}"" style=""font-size:14px;color:#3366CC;"">{CurUser_Name}</a></u>. The user is not currently assigned to the Project Team.</td>
                                                        </tr>
                                                        <tr><td>&nbsp;</td></tr>

                                                        <tr><td><hr></td></tr>
                                                        <tr>
                                                        <td style=""font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">Powered by EPM Live :)</td>
                                                        </tr>
                                                        </table>
                                                        </body>
                                                        </html>', 'Time has been booked to {Project_Name} project by an outside user.', 'Non Project Team Member Timesheet Allocation Notification')
                                                        end

                                                        if not exists (select * from [EMAILTEMPLATES] where [EmailId]=17)
                                                        begin
                                                        INSERT INTO [dbo].[EMAILTEMPLATES] ([EmailId],[Body],[Subject],[Title])
                                                        VALUES 
                                                        (
                                                        17,
                                                        '<html>
                                                        <body>
                                                            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                                <tr>
                                                                    <td style=""font-size:20px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">{CurUser_Name} has charged {Hours} timesheet hour(s) to <a href=""{Project_Url}"" style=""font-size:20px;color:#3366CC;"">{Project_Name}</a>.</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style=""font-size:20px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">{CurUser_Name} is not currently part of the project team.</td>
                                                                </tr>
                                                                <tr><td>&nbsp;</td></tr>
                                                                <tr>
                                                                    <td style=""font-size:14px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">If you have any questions regarding the assignment you can contact {CurUser_Name} at <u><a href=""mailto:{CurUser_Email}"" style=""font-size:14px;color:#3366CC;"">{CurUser_Email}</a></u>.</td>
                                                                </tr>
                                                                <tr><td>&nbsp;</td></tr>
                                                                <tr><td><hr></td></tr>
                                                                <tr>
                                                                    <td style=""font-size:10px;color:#666666;font-family:Lucida Grande,Arial Unicode MS,sans-serif"">Powered by EPM Live :)</td>
                                                                </tr>
                                                            </table>
                                                        </body>
                                                        </html>
                                                        ',
                                                        '{CurUser_Name} allocated time on {Project_Name}',
                                                        'Time Allocation')
                                                        end");
                            #endregion

                            LogMessage("New templates sucessfully added to EMAILTEMPLATES (case they don't exist already).", MessageKind.SUCCESS, 4);
                        }
                        finally
                        {
                            epmLiveCn.Close();
                        }
                    }
                }
                catch (Exception exception)
                {
                    string message = exception.InnerException != null
                        ? exception.InnerException.Message
                        : exception.Message;

                    LogMessage(message, MessageKind.FAILURE, 4);
                }
            });

            return true;
        }
    }
}
