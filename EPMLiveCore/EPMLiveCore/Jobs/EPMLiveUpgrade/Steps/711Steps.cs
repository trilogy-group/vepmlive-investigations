using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V711, Order = 1.0, Description = "Update SSRS Resouces Capacity Heat Map Report")]
    internal class UpdateSSRSResoucesCapacityHeatMapReport : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public UpdateSSRSResoucesCapacityHeatMapReport(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Getting the report library.", 2);
                    SPList reportLibrary = _spWeb.Lists.TryGetList("Report Library");

                    if (reportLibrary != null)
                    {
                        LogMessage("Getting the Resource Capacity Heat Map report.", 2);

                        System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                        var spfile = _spWeb.GetFile(_spWeb.Url + "/Report Library/epmlivetl/Resources/Capacity Planning/Resource Capacity Heat Map.rdl");

                        if (spfile.Exists)
                        {
                            LogMessage("Updating the Resource Capacity Heat Map report.", 2);

                            byte[] byteArrayFileContentsBefore = spfile.OpenBinary();

                            if (byteArrayFileContentsBefore.Length > 0)
                            {
                                string strReportContentsBefore = enc.GetString(byteArrayFileContentsBefore);

                                string strReportContentsAfter = strReportContentsBefore.Replace("union", "union all");

                                byte[] byteArrayFileContentsAfter = null;
                                if (!strReportContentsAfter.Equals(string.Empty))
                                {
                                    _spWeb.AllowUnsafeUpdates = true;
                                    byteArrayFileContentsAfter = enc.GetBytes(strReportContentsAfter);
                                    spfile.SaveBinary(byteArrayFileContentsAfter); //save to the file.
                                    LogMessage("Resource Capacity Heat Map report updated succesfully", 2);
                                }
                                else
                                {
                                    LogMessage("Resource Capacity Heat Map report is empty", MessageKind.FAILURE, 4);
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
                finally
                {
                    _spWeb.AllowUnsafeUpdates = false;
                }
            });
            return true;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V711, Order = 2.0, Description = "Update SSRS Resouces Availability Report")]
    internal class UpdateSSRSResoucesAvailabilityReport : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public UpdateSSRSResoucesAvailabilityReport(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Getting the report library.", 2);
                    SPList reportLibrary = _spWeb.Lists.TryGetList("Report Library");

                    if (reportLibrary != null)
                    {
                        LogMessage("Getting the Resource Availability report.", 2);
                        System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                        var spfile = _spWeb.GetFile(_spWeb.Url + "/Report Library/epmlivetl/Resources/Capacity Planning/Resource Available vs. Planned by Dept.rdl");

                        if (spfile.Exists)
                        {
                            LogMessage("Updating the Availability report.", 2);

                            byte[] byteArrayFileContentsBefore = spfile.OpenBinary();

                            if (byteArrayFileContentsBefore.Length > 0)
                            {
                                string strReportContentsBefore = enc.GetString(byteArrayFileContentsBefore);

                                string strReportContentsAfter = strReportContentsBefore.Replace("union", "union all");

                                byte[] byteArrayFileContentsAfter = null;
                                if (!strReportContentsAfter.Equals(string.Empty))
                                {
                                    _spWeb.AllowUnsafeUpdates = true;
                                    byteArrayFileContentsAfter = enc.GetBytes(strReportContentsAfter);
                                    spfile.SaveBinary(byteArrayFileContentsAfter); //save to the file.
                                    LogMessage("Resource Capacity Heat Map report updated succesfully", 2);
                                }
                                else
                                {
                                    LogMessage("Resource Availability report is empty", MessageKind.FAILURE, 4);
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
                finally
                {
                    _spWeb.AllowUnsafeUpdates = false;
                }
            });
            return true;
        }

        #endregion
    }
}
