using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using PSLibrary = Microsoft.Office.Project.Server.Library;
using Microsoft.SharePoint;

namespace EPMLiveEnterprise
{
    public class EPMLiveHelperClasses
    {


        public static string getProjectServerPublishedConnectionString(Guid pwaSiteGuid)
        {
            string key = "";

                using (SPSite site = new SPSite(pwaSiteGuid))
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        key = EPMLiveCore.CoreFunctions.getConfigSetting(web, "epmlivepubcn");
                    }
                }

            if (key == "")
                key = "Server=SERVERNAME;Database=ProjectServer_Published;Trusted_Connection=True";
            return key;

        }

        public static void setProjectServerPublishedConnectionString(Guid pwaSiteGuid, string conn)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(pwaSiteGuid))
                {
                    site.AllowUnsafeUpdates = true;
                    using (SPWeb web = site.RootWeb)
                    {
                        web.AllowUnsafeUpdates = true;
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "epmlivepubcn", conn);
                    }
                }
            });


        }

        public static Guid GetResourceGuidByWindowsAccount(string ls_name)
        {
            string errLoc = "";
            try
            {
                WebSvcResource.Resource res = new WebSvcResource.Resource();
                WebSvcResource.ResourceDataSet lo_resDS = new WebSvcResource.ResourceDataSet();
                res.Credentials = System.Net.CredentialCache.DefaultCredentials;

                string nameColumn = lo_resDS.Resources.WRES_ACCOUNTColumn.ColumnName;

                string resUID = lo_resDS.Resources.RES_UIDColumn.ColumnName;

                PSLibrary.Filter.FieldOperationType equal = PSLibrary.Filter.FieldOperationType.Equal;
                PSLibrary.Filter lo_filter = new PSLibrary.Filter();

                lo_filter.FilterTableName = lo_resDS.Resources.TableName;
                lo_filter.Fields.Add(new PSLibrary.Filter.Field(resUID));
                lo_filter.Criteria = new PSLibrary.Filter.FieldOperator(equal, nameColumn, ls_name);
                errLoc = "ReadResources()";
                lo_resDS = res.ReadResources(lo_filter.GetXml(), false);
                errLoc = "Returning Guid";
                return (Guid)lo_resDS.Tables[lo_resDS.Resources.TableName].Rows[0][0];
            }
            catch (Exception ex)
            {
                EventLog myLog = new EventLog("EPM Live", ".", "EPM Live Helper");
                myLog.WriteEntry("Error at GetResourceGuidByWindowsAccount: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 401);
                return new Guid();
            }
        }

    }
}
