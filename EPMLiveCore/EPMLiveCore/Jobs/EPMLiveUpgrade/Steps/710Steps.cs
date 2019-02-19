using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;

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

    [UpgradeStep(Version = EPMLiveVersion.V710, Order = 2.0, Description = "Disable throttling for the task center list")]
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
                        list.Update();

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

    [UpgradeStep(Version = EPMLiveVersion.V710, Order = 3.0, Description = "Updating My Work table")]
    internal class AddUpdateMyWorkColumn : UpgradeStep
    {
        public AddUpdateMyWorkColumn(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    if (!CheckColumn())
                    {
                        AddColumn();
                        LogMessage("IsAssignment column added", MessageKind.SUCCESS, 4);
                    }
                    else
                    {
                        LogMessage("IsAssignment column already exists", MessageKind.SKIPPED, 4);
                    }
                    LogMessage("Updating value to the database . . .", 2);
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
            });
            return true;
        }

        private void AddColumn()
        {
            using (SPSite eleSite = new SPSite(Web.Url))
            {
                eleSite.AllowUnsafeUpdates = true;
                using (SPWeb eleWeb = eleSite.OpenWeb())
                {
                    eleWeb.AllowUnsafeUpdates = true;
                    SPList list = eleWeb.Lists["My Work"];
                    string id = list.Fields.Add("IsAssignment", SPFieldType.Boolean, false);
                    SPField spfield = (SPField)list.Fields.GetField(id);
                    spfield.Hidden = true;
                    spfield.Update();
                    SPView view = list.DefaultView;
                    view.ViewFields.Add("IsAssignment");
                    view.Update();
                    eleWeb.AllowUnsafeUpdates = false;
                }
                eleSite.AllowUnsafeUpdates = false;
            }

        }
        private bool CheckColumn()
        {
            using (SPWeb mySite = Web.Site.OpenWeb())
            {
                var list = mySite.Lists["My Work"];
                return list.Fields.ContainsField("IsAssignment");
            }
        }
    }

    [UpgradeStep(Version = EPMLiveVersion.V710, Order = 4.0, Description = "Add unique Contraints on RPTWEBGROUPS ")]
    internal class AddRPTWEBGROUPSUniqueContraints_710 : UpgradeStep
    {
        private const string ContraintName = "UQ_RPTWEBGROUPS_SITEID_WEBID_GROUPID";
        public AddRPTWEBGROUPSUniqueContraints_710(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);
                    string connectionString = CoreFunctions.getReportingConnectionString(Web.Site.WebApplication.Id, Web.Site.ID);
                    AddConstraint(connectionString);
                    LogMessage("Constraint updated in the Database..", 2);
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
            });
            return true;
        }

        private void AddConstraint(string connectionString)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(string.Format(@"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS   WHERE CONSTRAINT_NAME='{0}'))
                                                                BEGIN
                                                                       WITH CTE
                                                                            AS (SELECT ROW_NUMBER() OVER (PARTITION BY SITEID,WEBID,GROUPID
                                                                                                              ORDER BY (SELECT 0)) RN
                                                                                FROM   [dbo].[RPTWEBGROUPS])
                                                                       DELETE FROM CTE
                                                                       WHERE  RN > 1;
                                                                       ALTER TABLE [dbo].[RPTWEBGROUPS] ADD  CONSTRAINT {0} UNIQUE (SITEID,WEBID,GROUPID)
                                                                END", ContraintName), con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    [UpgradeStep(Version = EPMLiveVersion.V710, Order = 5.0, Description = "Unregister EPMLive Regitery From Application Folder")]
    internal class UnregisterEPMLiveRegitery : UpgradeStep
    {
        private const string EventLogApplicationRegistryKeyPath = @"SYSTEM\CurrentControlSet\services\eventlog\Application";
        private const string EventLogEventLogRegistryKeyPath = @"SYSTEM\CurrentControlSet\services\eventlog";
        private const string EPMLiveRegistryKeyPrefix = @"EPM Live";
        
        public UnregisterEPMLiveRegitery(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
        }

        public override bool Perform()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                SPFarm farm = SPFarm.Local.Farm;
                if (farm != null)
                {
                    foreach (SPServer server in farm.Servers)
                    {
                        ProcessRegisteryKeys(server);
                    }
                }
            });
            return true;
        }

        private void ProcessRegisteryKeys(SPServer server)
        {
            try
            {
                var baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, server.Address);
                var key = Registry.LocalMachine.OpenSubKey(EventLogApplicationRegistryKeyPath);
                foreach (var subKeyName in key.GetSubKeyNames())
                {
                    var productKey = key.OpenSubKey(subKeyName);
                    var EPkey = productKey.Name.Substring(productKey.Name.LastIndexOf("\\") + 1);
                    if (EPkey.Contains(EPMLiveRegistryKeyPrefix))
                    {
                        DeRegisterKey(baseKey, EPkey);
                    }
                }
                RegisterKey(baseKey, EPMLiveRegistryKeyPrefix);
                LogMessage($"Registries process successed for {server.Address}", MessageKind.SUCCESS, 4);
            }
            catch (Exception exception)
            {
                LogMessage($"Registries process failed for server :  {server.Address}, Error: {exception.ToString()}", MessageKind.FAILURE, 4);
            }
        }

        private void DeRegisterKey(RegistryKey baseKey, string key)
        {
            if (baseKey != null)
            {
                var eventLogKey = baseKey.OpenSubKey(EventLogApplicationRegistryKeyPath, true);
                if (eventLogKey != null)
                {
                    var loggingServiceKey = eventLogKey.OpenSubKey(key);
                    if (loggingServiceKey != null)
                    {
                        eventLogKey.DeleteSubKey(key);
                    }
                }
            }
        }

        private void RegisterKey(RegistryKey baseKey, string key)
        {
            if (baseKey != null)
            {
                var eventLogKey = baseKey.OpenSubKey(EventLogEventLogRegistryKeyPath, true);
                if (eventLogKey != null)
                {
                    var loggingServiceKey = eventLogKey.OpenSubKey(key);
                    if (loggingServiceKey == null)
                    {
                        loggingServiceKey = eventLogKey.CreateSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree);
                        loggingServiceKey.SetValue("EventMessageFile", @"C:\Windows\Microsoft.NET\Framework\v2.0.50727\EventLogMessages.dll", RegistryValueKind.String);
                    }
                }
            }
        }
    }
}
