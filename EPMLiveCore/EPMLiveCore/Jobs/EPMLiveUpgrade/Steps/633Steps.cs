using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using System;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V633, Order = 1.0, Description = "Update SSRS Resouces Capacity Heat Map Report")]
    internal class UpdateSSRSResoucesCapacityReport : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public UpdateSSRSResoucesCapacityReport(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

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
                        var spfile=_spWeb.GetFile(_spWeb.Url +  "/Report Library/epmlivetl/Resources/Capacity Planning/Resource Capacity Heat Map.rdl");

                        if (spfile.Exists)
                        {
                            LogMessage("Updating the Resource Capacity Heat Map report.", 2);

                            byte[] byteArrayFileContentsBefore = spfile.OpenBinary();

                            if (byteArrayFileContentsBefore.Length > 0)
                            {
                                string strReportContentsBefore = enc.GetString(byteArrayFileContentsBefore);

                                if (!strReportContentsBefore.Contains("cp.[PROJECT NAME], '' AS PROJECT_MANAGER") &&
                                !strReportContentsBefore.Contains("AND cp.PeriodID = cal.PeriodID\r\nwhere"))
                                    LogMessage("Resource Capacity Heat Map report is already up-to-date", 2);
                                else
                                {
                                    string strReportContentsAfter = strReportContentsBefore.Substring(strReportContentsBefore.IndexOf('<')).Replace("cp.[PROJECT NAME], '' AS PROJECT_MANAGER", "cp.[PROJECT NAME], ProjectManagersText AS PROJECT_MANAGER");
                                    strReportContentsAfter = strReportContentsAfter.Replace("AND cp.PeriodID = cal.PeriodID\r\nwhere", "AND cp.PeriodID = cal.PeriodID\r\nINNER JOIN LSTProjectCenter on cp.projectid = LSTProjectCenter.ID\r\nwhere");

                                    byte[] byteArrayFileContentsAfter = null;
                                    if (!strReportContentsAfter.Equals(""))
                                    {
                                        byteArrayFileContentsAfter = enc.GetBytes(strReportContentsAfter);
                                        spfile.SaveBinary(byteArrayFileContentsAfter); //save to the file.
                                        LogMessage("Resource Capacity Heat Map report updated succesfully", 2);
                                    }
                                    else
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
            });
            return true;
        }

        #endregion
    }

}
