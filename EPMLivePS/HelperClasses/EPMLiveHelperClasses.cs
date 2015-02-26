using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using PSLibrary = Microsoft.Office.Project.Server.Library;
using Microsoft.SharePoint;
using System.Net;

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

        public static CookieContainer GetLogonCookie(string siteUrl)
        {
            // Create an instance of the loginWindows object.
            LoginWindowsDerived loginWindows = new LoginWindowsDerived(siteUrl);
            loginWindows.EnforceWindowsAuth = true;
            loginWindows.Url = siteUrl + "/_vti_bin/psi/LoginWindows.asmx";
            loginWindows.Credentials = GetNetworkCredential();

            loginWindows.CookieContainer = new CookieContainer();

            if (!loginWindows.Login())
            {
                // Login failed; throw an exception.
                throw new UnauthorizedAccessException("Login failed.");
            }
            return loginWindows.CookieContainer;
        }

        public static NetworkCredential GetNetworkCredential()
        {

            return System.Net.CredentialCache.DefaultNetworkCredentials;
        }

        public static CustomFieldsDerived GetCustomFieldsDerivedObject(string siteURL)
        {
            CustomFieldsDerived customFieldDerived = new CustomFieldsDerived(siteURL + "/_vti_bin/PSI/customfields.asmx");
            customFieldDerived.Credentials = GetNetworkCredential();
            customFieldDerived.CookieContainer = GetLogonCookie(siteURL);
            customFieldDerived.EnforceWindowsAuth = true;

            return customFieldDerived;
        }

        public static EventsDerived GetEventsDerivedObject(string siteURL)
        {
            EventsDerived eventsDerived = new EventsDerived(siteURL + "/_vti_bin/PSI/events.asmx");
            eventsDerived.Credentials = GetNetworkCredential();
            eventsDerived.CookieContainer = GetLogonCookie(siteURL);
            eventsDerived.EnforceWindowsAuth = true;

            return eventsDerived;
        }

        public static LookupTableDerived GetLookupTableDerivedObject(string siteURL)
        {
            LookupTableDerived lookupTableDerived = new LookupTableDerived(siteURL + "/_vti_bin/PSI/lookuptable.asmx");
            lookupTableDerived.Credentials = GetNetworkCredential();
            lookupTableDerived.CookieContainer = GetLogonCookie(siteURL);
            lookupTableDerived.EnforceWindowsAuth = true;

            return lookupTableDerived;
        }

        public static ProjectDerived GetProjectDerivedObject(string siteURL)
        {
            ProjectDerived projectDerived = new ProjectDerived(siteURL + "/_vti_bin/PSI/project.asmx");
            projectDerived.Credentials = GetNetworkCredential();
            projectDerived.CookieContainer = GetLogonCookie(siteURL);
            projectDerived.EnforceWindowsAuth = true;

            return projectDerived;
        }

        public static QueueSystemDerived GetQueueSystemDerivedObject(string siteURL)
        {
            QueueSystemDerived queueSystemDerived = new QueueSystemDerived(siteURL + "/_vti_bin/PSI/queuesystem.asmx");
            queueSystemDerived.Credentials = GetNetworkCredential();
            queueSystemDerived.CookieContainer = GetLogonCookie(siteURL);
            queueSystemDerived.EnforceWindowsAuth = true;

            return queueSystemDerived;
        }

        public static ResourceDerived GetResourceDerivedObject(string siteURL)
        {
            ResourceDerived resourceDerived = new ResourceDerived(siteURL + "/_vti_bin/PSI/resource.asmx");
            resourceDerived.Credentials = GetNetworkCredential();
            resourceDerived.CookieContainer = GetLogonCookie(siteURL);
            resourceDerived.EnforceWindowsAuth = true;

            return resourceDerived;
        }

        public static StatusingDerived GetStatusingDerivedObject(string siteURL)
        {
            StatusingDerived statusingDerived = new StatusingDerived(siteURL + "/_vti_bin/PSI/statusing.asmx");
            statusingDerived.Credentials = GetNetworkCredential();
            statusingDerived.CookieContainer = GetLogonCookie(siteURL);
            statusingDerived.EnforceWindowsAuth = true;

            return statusingDerived;
        }
        public static WssInteropDerived GetWssInteropDerivedObject(string siteURL)
        {
            WssInteropDerived wssInteropDerived = new WssInteropDerived(siteURL + "/_vti_bin/PSI/wssinterop.asmx");
            wssInteropDerived.Credentials = GetNetworkCredential();
            wssInteropDerived.CookieContainer = GetLogonCookie(siteURL);
            wssInteropDerived.EnforceWindowsAuth = true;

            return wssInteropDerived;
        }

    }
}
