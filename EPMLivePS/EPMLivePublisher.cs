using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.SharePoint;
using System.IO;
using System.Data;
using System.Collections;
using PSLibrary = Microsoft.Office.Project.Server.Library;
using Microsoft.SharePoint.Administration;
using System.Collections.Generic;

namespace EPMLiveEnterprise
{

    [WebService(Namespace = "http://epmlive.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class EPMLivePublisher : System.Web.Services.WebService
    {
        public class CustomField
        {
            public string name;
            public string displayName;
            public string wssFieldName;
            public bool locked;
            public bool visible;
            public bool editable;
            public SPFieldType fieldType;
            public int fieldCategory;
        };
        public class UpdateFieldItem
        {
            public string displayName;
            public string value;
            public int fieldId;
            public string internalFieldName;
            public Guid fieldGuid;
        };
        public class UpdateTaskItem
        {
            public string taskname;
            public string taskuid;
            public string startDate;
            public string finishDate;
            public string percentComplete;
            public string notes;
            public int listItemId;
            public UpdateFieldItem[] updatefields;
            public string taskHierarchy;
        };
        public class TaskApprovalItem
        {
            public int listItemId;
            public int approvalStatus;
            public string approvalNotes;
            public string taskuid;
        };
        public EPMLivePublisher()
        {

        }
        [WebMethod]
        public int getVersion()
        {
            return 3;
        }
        [WebMethod]
        public string getFileVersion()
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            System.Reflection.AssemblyName assn = ass.GetName();
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(assn.CodeBase.Replace("file:///", "").Replace("/", "\\")).FileVersion;
        }
        [WebMethod]
        public void saveTaskFields(CustomField[] cfs, string[] delFields)
        {
            saveFields("Task Center", cfs, delFields);
        }
        [WebMethod]
        public void saveProjectFields(CustomField[] cfs, string[] delFields)
        {
            saveFields("Project Center", cfs, delFields);
        }
        [WebMethod]
        public CustomField[] getTaskCustomFields()
        {
            return getCustomFields("Task Center", 5, SPContext.Current.Site.Url);
        }
        [WebMethod]
        public CustomField[] getTaskCustomFields2(string projectServerUrl)
        {
            return getCustomFields("Task Center", 5, projectServerUrl);
        }
        [WebMethod]
        public CustomField[] getProjectCustomFields()
        {
            return getCustomFields("Project Center", 9, SPContext.Current.Site.Url);
        }
        [WebMethod]
        public CustomField[] getProjectCustomFields2(string projectServerUrl)
        {
            return getCustomFields("Project Center", 9, projectServerUrl);
        }
        [WebMethod]
        public string getProjectSite(Guid projectUID)
        {
            SPSite site = SPContext.Current.Site;

            try
            {
                //WebSvcWssInterop.WssInterop wssInterop = new WebSvcWssInterop.WssInterop();

                //wssInterop.Url = site.Url + "/_vti_bin/psi/wssinterop.asmx";

                //wssInterop.Credentials = System.Net.CredentialCache.DefaultCredentials;

                //WebSvcWssInterop.ProjectWSSInfoDataSet ds = wssInterop.ReadWssData(projectUID);

                //if (ds.ProjWssInfo.Count > 0)
                //{
                //    return ds.ProjWssInfo[0].PROJECT_WORKSPACE_URL;
                //}

                //site.Close();

                string url = "";
    
                SPSecurity.RunWithElevatedPrivileges(delegate(){
                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select weburl from publishercheck where projectguid=@projectguid",cn);
                    cmd.Parameters.AddWithValue("@projectguid", projectUID);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        url = dr.GetString(0);
                    }
                    dr.Close();

                    cn.Close();
                });

                return url;
            }
            catch (Exception ex)
            {
                string username = HttpContext.Current.User.Identity.Name;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                    myLog.WriteEntry("Error in getProjectSite(User: " + username + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                });
                site.Close();
                return "";
            }
        }
        private SPSite getWebUpgraded(SPSite site)
        {
            //SPUserToken token = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                site = new SPSite(site.ID);
                //foreach (SPUser u in s.RootWeb.AllUsers)
                //{
                //    if (u.IsSiteAdmin)
                //    {
                //        token = u.UserToken;
                //        break;
                //    }
                //}
                //s.Close();
            });

            return site;
        }
        [WebMethod]
        public string getDefaultPublishURL()
        {
            SPSite site = getWebUpgraded(SPContext.Current.Site);

            try
            {
                string url = getEnterpriseSetting("DefaultURL");

                if (url == "")
                {

                    //WebSvcWssInterop.WssInterop wssInterop = new WebSvcWssInterop.WssInterop();

                    //wssInterop.Url = site.Url + "/_vti_bin/psi/wssinterop.asmx";

                    //site.Close();

                    //wssInterop.Credentials = System.Net.CredentialCache.DefaultCredentials;

                    WssInteropDerived wssInterop = EPMLiveHelperClasses.GetWssInteropDerivedObject(site.Url);
                    //WssInteropDerived wssInterop = new WssInteropDerived();
                    //wssInterop.Url = site.Url + "/_vti_bin/psi/wssinterop.asmx";
                    //wssInterop.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                    //wssInterop.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(site.Url);
                    //wssInterop.EnforceWindowsAuth = true;

                    site.Close();

                    WebSvcWssInterop.WssSettingsDataSet dsCurrentWssInfo = wssInterop.ReadWssSettings();
                    WebSvcWssInterop.WssSettingsDataSet.WssAdminRow adminRow = dsCurrentWssInfo.WssAdmin[0];

                    return adminRow.WADMIN_DEFAULT_SITE_COLLECTION;
                }
                else
                    return url;

            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                    myLog.WriteEntry("Error in getDefaultPublishURL(User: " + HttpContext.Current.User.Identity.Name + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                });
                site.Close();
                return "";
            }
        }
        [WebMethod]
        public bool createSite(string url, string projectName)
        {
            return createSiteWithTemplate(url, projectName, "");
        }
        [WebMethod]
        public bool createSiteWithTemplate(string url, string projectName, string template)
        {
            SPUserToken token = null;

            string username = HttpContext.Current.User.Identity.Name;

            SPSite site = SPContext.Current.Site;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPSite s = new SPSite(site.ID);
                foreach (SPUser u in s.RootWeb.AllUsers)
                {
                    if (u.IsSiteAdmin)
                    {
                        token = u.UserToken;
                        break;
                    }
                }
                s.Close();
            });
            string interopUrl = site.Url;
            Guid siteId = site.ID;
            string server = site.Url.Replace(site.ServerRelativeUrl, "");
            site.Close();
            //site = new SPSite(site.ID, token);

            //string siteUrl = "";
            bool success = false;
            try
            {
                //WebSvcWssInterop.WssInterop wssInterop = new WebSvcWssInterop.WssInterop();

                //wssInterop.Url = interopUrl + "/_vti_bin/psi/wssinterop.asmx";

                //wssInterop.Credentials = System.Net.CredentialCache.DefaultCredentials;

                WssInteropDerived wssInterop = EPMLiveHelperClasses.GetWssInteropDerivedObject(interopUrl);
                //WssInteropDerived wssInterop = new WssInteropDerived();
                //wssInterop.Url = interopUrl + "/_vti_bin/psi/wssinterop.asmx";
                //wssInterop.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //wssInterop.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(interopUrl);
                //wssInterop.EnforceWindowsAuth = true;

                WebSvcWssInterop.WssSettingsDataSet dsCurrentWssInfo = wssInterop.ReadWssSettings();
                WebSvcWssInterop.WssSettingsDataSet.WssAdminRow adminRow = dsCurrentWssInfo.WssAdmin[0];
                

                string baseURL = "";
                string realURL = url;//.Substring(1);
                int slash = realURL.LastIndexOf("/");
                if (slash > 0)
                {
                    baseURL = realURL.Substring(0, slash);
                }
                
                realURL = realURL.Substring(slash + 1);

                if (!baseURL.Contains("http://"))
                {
                    baseURL = server + "/" + adminRow.WADMIN_DEFAULT_SITE_COLLECTION + baseURL;
                }

                using (SPSite pubSite = new SPSite(baseURL))
                {
                    using (SPWeb pubWeb = pubSite.OpenWeb())
                    {
                        try
                        {
                            if (pubWeb.Url.ToLower() == baseURL.ToLower())
                            {
                                //SPWeb pubWeb = site.RootWeb;
                                //if(baseURL != "")
                                //    pubWeb = site.OpenWeb(baseURL);

                                //try
                                //{
                                //wssInterop.CreateWssSite(projectUID, adminRow.WADMIN_CURRENT_STS_SERVER_UID, url, adminRow.WADMIN_STS_TEMPLATE_LCID, adminRow.WADMIN_STS_TEMPLATE_ID);
                                SPWeb web;
                                
                                pubSite.AllowUnsafeUpdates = true;

                                if (template == "")
                                    web = pubWeb.Webs.Add(realURL, projectName, "", (uint)adminRow.WADMIN_STS_TEMPLATE_LCID, adminRow.WADMIN_STS_TEMPLATE_ID, true, false);
                                else
                                    web = pubWeb.Webs.Add(realURL, projectName, "", (uint)adminRow.WADMIN_STS_TEMPLATE_LCID, template, true, false);

                                web.AllowUnsafeUpdates = true;
                                //}
                                //catch { }

                                //WebSvcWssInterop.ProjectWSSInfoDataSet ds = wssInterop.ReadWssData(projectUID);
                                //siteUrl = ds.ProjWssInfo[0].PROJECT_WORKSPACE_URL.Replace(ds.ProjWssInfo[0].PROJECT_WORKSPACE_VSERVER_URL, "");

                                //SPWeb web = site.OpenWeb(url);

                                web.Navigation.TopNavigationBar.Navigation.UseShared = true;

                                web.Update();

                                string aowner = "";
                                string amember = "";
                                string avisitor = "";
                                string strEPMLiveGroupsPermAssignments = "";
                                SPSecurity.RunWithElevatedPrivileges(delegate()
                                {
                                    using (SPWeb w = SPContext.Current.Web)
                                    {
                                        Guid lockweb = EPMLiveCore.CoreFunctions.getLockedWeb(w);
                                        if (lockweb != Guid.Empty)
                                        {
                                            using (SPWeb lweb = w.Site.OpenWeb(lockweb))
                                            {
                                                aowner = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveNewProjectRoleOwners");
                                                amember = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveNewProjectRoleMembers");
                                                avisitor = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveNewProjectRoleVisitors");
                                                strEPMLiveGroupsPermAssignments = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveGroupsPermAssignments");
                                            }
                                        }
                                    }
                                });

                                SPUser owner = pubSite.RootWeb.AllUsers[username];
                                SPMember newOwner = null;
                                //=========Owner Group========================
                                SPRole roll = web.Roles["Full Control"];
                                if (aowner != "")
                                {
                                    web.AssociatedOwnerGroup = web.SiteGroups.GetByID(int.Parse(aowner));
                                    roll.AddGroup(web.SiteGroups.GetByID(int.Parse(aowner)));
                                    newOwner = web.SiteGroups.GetByID(int.Parse(aowner));
                                }
                                else
                                {
                                    try
                                    {
                                        web.SiteGroups.Add(web.Title + " Administrators", owner, owner, "");
                                    }
                                    catch (Exception) { }
                                    web.Update();
                                    web.AssociatedOwnerGroup = GetSiteGroup(web, web.Title + " Administrators");
                                    roll.AddGroup(web.SiteGroups[web.Title + " Administrators"]);
                                    newOwner = web.SiteGroups[web.Title + " Administrators"];
                                }

                                

                                //=========Member Group========================
                                if (amember != "")
                                {
                                    web.AssociatedMemberGroup = web.SiteGroups.GetByID(int.Parse(amember));
                                    roll = web.Roles["Contribute"];
                                    roll.AddGroup(web.SiteGroups.GetByID(int.Parse(amember)));
                                }
                                else
                                {
                                    try
                                    {
                                        web.SiteGroups.Add(web.Title + " Members", newOwner, owner, "");
                                    }
                                    catch (Exception) { }
                                    web.Update();
                                    web.AssociatedMemberGroup = GetSiteGroup(web, web.Title + " Members");
                                    roll = web.Roles["Contribute"];
                                    roll.AddGroup(web.SiteGroups[web.Title + " Members"]);
                                }
                                //=========Visitor Group========================
                                if (avisitor != "")
                                {
                                    web.AssociatedVisitorGroup = web.SiteGroups.GetByID(int.Parse(avisitor));
                                    roll = web.Roles["Read"];
                                    roll.AddGroup(web.SiteGroups.GetByID(int.Parse(avisitor)));
                                }
                                else
                                {
                                    try
                                    {
                                        web.SiteGroups.Add(web.Title + " Visitors", newOwner, owner, "");
                                    }
                                    catch (Exception) { }
                                    web.Update();
                                    web.AssociatedVisitorGroup = GetSiteGroup(web, web.Title + " Visitors");
                                    roll = web.Roles["Read"];
                                    roll.AddGroup(web.SiteGroups[web.Title + " Visitors"]);
                                }

                                web.Update();

                                if (strEPMLiveGroupsPermAssignments.Length > 1)
                                {

                                    string[] strOuter = strEPMLiveGroupsPermAssignments.Split(new string[] { "|~|" }, StringSplitOptions.None);
                                    foreach (string strInner in strOuter)
                                    {
                                        string[] strInnerMost = strInner.Split('~');
                                        SPGroup spGroup = web.SiteGroups.GetByID(Convert.ToInt32(strInnerMost[0]));


                                        //Persist groups & permissions to the database
                                        if (spGroup != null)
                                        {
                                            SPRoleAssignment spRA = new SPRoleAssignment(spGroup);
                                            spRA.RoleDefinitionBindings.Add(web.RoleDefinitions.GetById(Convert.ToInt32(strInnerMost[1])));
                                            web.RoleAssignments.Add(spRA);
                                        }

                                    }
                                }


                                success = true;

                                try
                                {
                                    SPSecurity.RunWithElevatedPrivileges(delegate()
                                    {
                                        ProjectWorkspaceSynch pws = new ProjectWorkspaceSynch(siteId, web.Url, new Guid(), username);
                                        pws.processProjectCenter();
                                        pws.processTaskCenter();
                                    });
                                }
                                catch (Exception ex)
                                {
                                    SPSecurity.RunWithElevatedPrivileges(delegate()
                                    {
                                        EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                                        myLog.WriteEntry("Error in createSite Synch Workspace: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                                    });
                                    success = false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                                myLog.WriteEntry("Error in createSite(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                            });
                            success = false;
                        }
                    }
                }
            
             }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                    myLog.WriteEntry("Error in createSite(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                });
                success = false;
            }
            return success;
        }

        private SPGroup GetSiteGroup(SPWeb web, string name)
        {
            foreach (SPGroup group in web.SiteGroups)
                if (group.Name.ToLower() == name.ToLower())
                    return group;
            return null;
        }

        [WebMethod]
        public bool isTaskUpdates(Guid projectGuid)
        {
            bool isUpdates = false;
            SPWeb web = SPContext.Current.Web;
            try
            {
                //WebSvcProject.Project pSvc = new EPMLiveEnterprise.WebSvcProject.Project();
                ProjectDerived pSvc = EPMLiveHelperClasses.GetProjectDerivedObject(web.Site.Url);
                //ProjectDerived pSvc = new ProjectDerived();
                //pSvc.Url = web.Site.Url + "/_vti_bin/psi/project.asmx";
                //pSvc.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //pSvc.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(web.Site.Url);
                //pSvc.EnforceWindowsAuth = true;
                //pSvc.UseDefaultCredentials = true;

                WebSvcProject.ProjectDataSet pds = pSvc.ReadProject(projectGuid, WebSvcProject.DataStoreEnum.PublishedStore);
                string projectname = pds.Project[0].PROJ_NAME;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SqlConnection cn = null;
                    try
                    {
                        cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("SELECT transuid FROM publishercheck where projectguid=@projectguid", cn);
                        cmd.Parameters.AddWithValue("@projectguid", projectGuid);
                        SqlDataReader drPubCheck = cmd.ExecuteReader();

                        if (drPubCheck.Read())
                        {
                            Guid transuid = drPubCheck.GetGuid(0);
                            drPubCheck.Close();

                            SPList list = web.Lists["Task Center"];

                            SPQuery query = new SPQuery();
                            query.Query = "<Where><And><Eq><FieldRef Name='Project'/><Value Type='Text'>" + projectname + "</Value></Eq><Neq><FieldRef Name='transuid'/><Value Type='Text'>" + transuid.ToString() + "</Value></Neq></And></Where>";

                            if (list.GetItems(query).Count > 0)
                                isUpdates = true;

                        }
                    }
                    catch (Exception ex)
                    {
                        EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                        myLog.WriteEntry("Error in isTaskUpdates(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);

                        try
                        {
                            cn.Close();
                        }
                        catch { }
                    }
                });
            }
            catch (Exception ex)
            {
                EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                myLog.WriteEntry("Error in isTaskUpdates(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
            }
            web.Close();
            return isUpdates;
        }
        [WebMethod]
        public int getPublishType(Guid projectGuid)
        {
            SPWeb web = SPContext.Current.Web;
            
            SqlConnection cn = null;
            int pubType = 0;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                    cn.Open();
                });

                SqlCommand cmd = new SqlCommand("SELECT pubtype from PUBLISHERCHECK where projectguid=@projectguid", cn);
                cmd.Parameters.AddWithValue("@projectguid", projectGuid);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    pubType = dr.GetInt32(0);
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                 EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                 myLog.WriteEntry("Error in setApprovedTasks(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                });
            }
            web.Close();
            return pubType;
        }
        [WebMethod]
        public void setApprovedTasks(TaskApprovalItem[] taskItems, Guid projectGuid)
        {
            SPWeb psweb = SPContext.Current.Web;

            SqlConnection cn = null;

            string url = getProjectSite(projectGuid);

            SPSite site = new SPSite(url);
            SPWeb web = site.OpenWeb();

            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(psweb.Site.WebApplication.Id));
                    cn.Open();
                });

                SqlCommand cmd = new SqlCommand("SELECT transuid from PUBLISHERCHECK where projectguid=@projectguid", cn);
                cmd.Parameters.AddWithValue("@projectguid", projectGuid);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Guid transuid = dr.GetGuid(0);
                    dr.Close();

                    SPList list = web.Lists["Task Center"];

                    foreach (TaskApprovalItem ta in taskItems)
                    {
                        try
                        {
                            SPListItem li = list.GetItemById(ta.listItemId);
                            if(ta.approvalStatus == 2)
                                li["Publisher_x0020_Approval_x0020_S"] = "Approved";
                            else
                                li["Publisher_x0020_Approval_x0020_S"] = "Rejected";
                            li["Publisher_x0020_Approval_x0020_C"] = ta.approvalNotes;
                            try
                            {
                                li["taskuid"] = ta.taskuid;// li["taskuid"].ToString();
                            }
                            catch { }
                            li["transuid"] = transuid.ToString();
                            li.Update();
                        }
                        catch (Exception ex)
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                                myLog.WriteEntry("Error in setApprovedTasks() updating list item: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                            });
                        }
                    }

                }
                else
                    dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                    myLog.WriteEntry("Error in setApprovedTasks(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                });
            }
            psweb.Close();
            web.Close();
        }
        [WebMethod]
        public UpdateTaskItem[] getUpdates(string projectGuid)
        {
            UpdateTaskItem[] updates = new UpdateTaskItem[0];

            SPWeb psweb = SPContext.Current.Web;
            string url = getProjectSite(new Guid(projectGuid));

            SPSite site = new SPSite(url);
            SPWeb web = site.OpenWeb();

            try
            {
                //WebSvcProject.Project pSvc = new EPMLiveEnterprise.WebSvcProject.Project();
                //pSvc.Url = psweb.Url + "/_vti_bin/psi/project.asmx";
                //pSvc.UseDefaultCredentials = true;
                //WebSvcCustomFields.CustomFields svcCF = new EPMLiveEnterprise.WebSvcCustomFields.CustomFields();
                //svcCF.Url = psweb.Url + "/_vti_bin/psi/customfields.asmx";
                //svcCF.UseDefaultCredentials = true;

                ProjectDerived pSvc = EPMLiveHelperClasses.GetProjectDerivedObject(psweb.Url);
                //ProjectDerived pSvc = new ProjectDerived();
                //pSvc.Url = psweb.Url + "/_vti_bin/psi/project.asmx";
                //pSvc.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //pSvc.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(psweb.Url);
                //pSvc.EnforceWindowsAuth = true;

                CustomFieldsDerived svcCF = EPMLiveHelperClasses.GetCustomFieldsDerivedObject(psweb.Url);
                //CustomFieldsDerived svcCF = new CustomFieldsDerived();
                //svcCF.Url = psweb.Url + "/_vti_bin/psi/customfields.asmx";
                //svcCF.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //svcCF.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(psweb.Url);
                //svcCF.EnforceWindowsAuth = true;

                WebSvcCustomFields.CustomFieldDataSet cfDs = svcCF.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));

                WebSvcProject.ProjectDataSet pds = pSvc.ReadProject(new Guid(projectGuid), WebSvcProject.DataStoreEnum.PublishedStore);
                string projectname = pds.Project[0].PROJ_NAME;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    SqlConnection cn = null;
                    try
                    {
                        cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(psweb.Site.WebApplication.Id));
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("SELECT transuid FROM publishercheck where projectguid=@projectguid", cn);
                        cmd.Parameters.AddWithValue("@projectguid", projectGuid);
                        SqlDataReader drPubCheck = cmd.ExecuteReader();

                        if (drPubCheck.Read())
                        {
                            Guid transuid = drPubCheck.GetGuid(0);
                            drPubCheck.Close();

                            SPList list = web.Lists["Task Center"];

                            ArrayList alFields = new ArrayList();
                            
                            Dictionary<string, Dictionary<string, string>> fieldProperties = null;

                            EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

                            if (gSettings.DisplaySettings != "")
                                fieldProperties = EPMLiveCore.ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);

                            foreach (SPField f in list.Fields)
                            {
                                string editable = "";
                                try
                                {
                                    editable = fieldProperties[f.InternalName]["Editable"];
                                    editable = editable.Split(";".ToCharArray())[0].ToLower();
                                }
                                catch { }

                                if (editable != "never" && f.Reorderable)
                                {
                                    if (f.ShowInEditForm == null)
                                        alFields.Add(f.Id);
                                    else
                                        if (f.ShowInEditForm == true)
                                            alFields.Add(f.Id);
                                }
                            }

                            UpdateFieldItem[] ufsTemp = new UpdateFieldItem[alFields.Count];
                            int goodCount = 0;
                            for (int i = 0; i < alFields.Count; i++)
                            {
                                SPField f = list.Fields[new Guid(alFields[i].ToString())];

                                cmd = new SqlCommand("SELECT fieldname,wssfieldname FROM CUSTOMFIELDS where wssfieldname like @wssfieldname", cn);
                                cmd.Parameters.AddWithValue("@wssfieldname", f.InternalName);
                                SqlDataReader drField = cmd.ExecuteReader();
                                if (drField.Read())
                                {
                                    //if (drField.GetString(1) != "StartDate" && drField.GetString(1) != "DueDate")
                                    if(f.Type != SPFieldType.Calculated)
                                    {
                                        ufsTemp[goodCount] = new UpdateFieldItem();
                                        ufsTemp[goodCount].displayName = f.Title;
                                        ufsTemp[goodCount].value = "";
                                        int temp = 0;
                                        if (f.InternalName.Length > 3 && int.TryParse(f.InternalName.Substring(3), out temp))
                                        {
                                            WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] dr = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select("MD_PROP_ID=" + temp.ToString());
                                            if (dr.Length > 0)
                                            {
                                                ufsTemp[goodCount].fieldId = temp;
                                                ufsTemp[goodCount].internalFieldName = "";
                                            }
                                            else
                                            {
                                                ufsTemp[goodCount].fieldId = 0;
                                                ufsTemp[goodCount].internalFieldName = "pjTask" + fixFieldName(drField.GetString(1));
                                            }
                                        }
                                        else
                                        {
                                            ufsTemp[goodCount].fieldId = 0;
                                            ufsTemp[goodCount].internalFieldName = "pjTask" + fixFieldName(drField.GetString(1));
                                        }

                                        ufsTemp[goodCount].fieldGuid = f.Id;
                                        goodCount++;
                                    }
                                }
                                else
                                {
                                    if (f.InternalName.Length > 3)
                                    {
                                        string fieldName = f.InternalName.Substring(3);
                                        int temp = 0;
                                        if (int.TryParse(fieldName, out temp))
                                        {
                                            WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[] dr = (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select("MD_PROP_ID=" + fieldName);
                                            if (dr.Length > 0)
                                            {
                                                ufsTemp[goodCount] = new UpdateFieldItem();
                                                ufsTemp[goodCount].displayName = f.Title;
                                                ufsTemp[goodCount].value = "";
                                                ufsTemp[goodCount].fieldId = int.Parse(fieldName);
                                                ufsTemp[goodCount].internalFieldName = "";
                                                ufsTemp[goodCount].fieldGuid = f.Id;
                                                goodCount++;
                                            }
                                        }
                                    }
                                }
                                drField.Close();
                            }

                            
                            cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='TimesheetHoursField'", cn);
                            SqlDataReader dReader = cmd.ExecuteReader();
                            if (dReader.Read())
                            {
                                try
                                {
                                    string tsHours = dReader.GetString(0);
                                    if (tsHours != "")
                                    {
                                        if (tsHours == "251658250")
                                        {
                                            SPField f = list.Fields.GetFieldByInternalName("TimesheetHours");
                                            ufsTemp[goodCount] = new UpdateFieldItem();
                                            ufsTemp[goodCount].displayName = f.Title;
                                            ufsTemp[goodCount].value = "";
                                            ufsTemp[goodCount].fieldId = 0;
                                            ufsTemp[goodCount].internalFieldName = "pjTaskActualWork";
                                            ufsTemp[goodCount].fieldGuid = f.Id;
                                            goodCount++;
                                        }
                                        else
                                        {
                                            SPField f = list.Fields.GetFieldByInternalName("TimesheetHours");
                                            string fieldName = f.InternalName.Substring(3);
                                            ufsTemp[goodCount] = new UpdateFieldItem();
                                            ufsTemp[goodCount].displayName = f.Title;
                                            ufsTemp[goodCount].value = "";
                                            ufsTemp[goodCount].fieldId = int.Parse(tsHours);
                                            ufsTemp[goodCount].internalFieldName = "";
                                            ufsTemp[goodCount].fieldGuid = f.Id;
                                            goodCount++;
                                        }
                                    }
                                }
                                catch { }
                            }
                            dReader.Close();

                            UpdateFieldItem[] ufs = new UpdateFieldItem[goodCount];
                            for (int i = 0; i < goodCount; i++)
                            {
                                ufs[i] = ufsTemp[i];
                            }

                            SPQuery query = new SPQuery();
                            query.Query = "<Where><And><Eq><FieldRef Name='Project'/><Value Type='Text'>" + projectname + "</Value></Eq><Neq><FieldRef Name='transuid'/><Value Type='Text'>" + transuid.ToString() + "</Value></Neq></And></Where>";

                            ArrayList alListItems = new ArrayList();

                            foreach (SPListItem li in list.GetItems(query))
                            {
                                alListItems.Add(li.ID);
                            }

                            updates = new UpdateTaskItem[alListItems.Count];

                            for (int i = 0; i < alListItems.Count; i++)
                            {
                                SPListItem li = list.GetItemById(int.Parse(alListItems[i].ToString()));
                                updates[i] = new UpdateTaskItem();
                                updates[i].taskname = li.Title;
                                try
                                {
                                    updates[i].taskuid = li["taskuid"].ToString();
                                }
                                catch { }
                                updates[i].startDate = getDate(li,"StartDate");
                                updates[i].finishDate = getDate(li,"DueDate");

                                if (li["Notes"] != null)
                                {
                                    string notes =  li["Notes"].ToString();
                                    notes = notes.Replace("<div>", "").Replace("</div>","");
                                    updates[i].notes = notes;
                                }
                                else
                                    updates[i].notes = "";
                                float pct = 0;
                                try
                                {
                                    pct = float.Parse(li["PercentComplete"].ToString()) * (float)100;
                                }catch{}
                                updates[i].percentComplete = pct.ToString();
                                try
                                {
                                    updates[i].taskHierarchy = li[li.ParentList.Fields.GetFieldByInternalName("TaskHierarchy").Id].ToString();
                                }
                                catch { }
                                updates[i].updatefields = new UpdateFieldItem[ufs.Length];
                                updates[i].listItemId = li.ID;

                                for (int j = 0; j < ufs.Length; j++)
                                {
                                    updates[i].updatefields[j] = new UpdateFieldItem();
                                    updates[i].updatefields[j].displayName = ufs[j].displayName;
                                    updates[i].updatefields[j].fieldGuid = ufs[j].fieldGuid;
                                    updates[i].updatefields[j].fieldId = ufs[j].fieldId;
                                    updates[i].updatefields[j].internalFieldName = ufs[j].internalFieldName.Replace("_x0020_","");

                                    if (li[updates[i].updatefields[j].fieldGuid] != null)
                                    {
                                        SPField f = li.Fields[updates[i].updatefields[j].fieldGuid];
                                        if (f.Type == SPFieldType.DateTime)
                                        {
                                            updates[i].updatefields[j].value = getDate(li, f.InternalName);
                                        }
                                        else if (f.Type == SPFieldType.Currency)
                                        {
                                            string money = li[updates[i].updatefields[j].fieldGuid].ToString();

                                            try
                                            {
                                                money = float.Parse(money).ToString("0.00");
                                            }
                                            catch { }

                                            updates[i].updatefields[j].value = money;
                                        }
                                        else if (f.Type == SPFieldType.Boolean)
                                        {
                                            if(bool.Parse(li[f.Id].ToString()))
                                            {
                                                updates[i].updatefields[j].value = "Yes";
                                            }
                                            else
                                            {
                                                updates[i].updatefields[j].value = "No";
                                            }
                                        }
                                        else if (f.Type == SPFieldType.Number)
                                        {
                                            if (f.SchemaXml.ToUpper().Contains("PERCENTAGE=\"TRUE\""))
                                            {
                                                pct = 0;
                                                try
                                                {
                                                    pct = float.Parse(li[updates[i].updatefields[j].fieldGuid].ToString()) * (float)100;
                                                }
                                                catch { }
                                                updates[i].updatefields[j].value = pct.ToString();
                                            }
                                            else
                                            {
                                                updates[i].updatefields[j].value = li[updates[i].updatefields[j].fieldGuid].ToString();
                                            }
                                        }
                                        else
                                        {
                                            updates[i].updatefields[j].value = li[updates[i].updatefields[j].fieldGuid].ToString();
                                        }
                                    }
                                }
                            }
                        }
                        else
                            drPubCheck.Close();

                        cn.Close();

                    }
                    catch (Exception ex)
                    {
                        EventLog myLog = new EventLog("EPM Live", ".", "Publisher Check WS");
                        myLog.WriteEntry("Error in getUpdates() projectuid (" + projectGuid + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);

                        try
                        {
                            cn.Close();
                        }
                        catch { }
                    }

                });
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                    myLog.WriteEntry("Error in getUpdates(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                });
            }
            psweb.Close();
            web.Close();
            site.Close();
            return updates;
        }
        private string fixFieldName(string field)
        {
            switch (field)
            {
                case "StartDate":
                    return "Start";
                case "DueDate":
                    return "Finish";
            };
            return field;
        }
        private string getDate(SPListItem li, string fieldName)
        {
            if (li.Fields.GetFieldByInternalName(fieldName).SchemaXml.IndexOf("Format=\"DateTime\"") > 0)
            {
                return li[fieldName].ToString();
            }
            else
            {
                string date = li[fieldName].ToString();
                try
                {
                    date = DateTime.Parse(date).ToShortDateString();
                }
                catch { }
                return date;
            }
        }
        private void saveFields(string listName, CustomField[] cfs, string[] delFields)
        {
            SPWeb web = SPContext.Current.Web;
            try
            {
                SPList list = web.Lists[listName];

                foreach (CustomField cf in cfs)
                {
                    if (list.Fields.ContainsField(cf.wssFieldName))
                    {
                        SPField f = list.Fields.GetFieldByInternalName(cf.wssFieldName);
                        f.ShowInEditForm = cf.editable;
                        f.ShowInNewForm = cf.editable;
                        f.Update();
                    }
                    else
                    {
                        list.Fields.Add(cf.wssFieldName, cf.fieldType, false);

                        SPField f = list.Fields[cf.wssFieldName];
                        f.Title = cf.displayName;
                        f.ShowInEditForm = cf.editable;
                        f.ShowInNewForm = cf.editable;
                        f.Update();

                    }
                }
                foreach (string s in delFields)
                {
                    try
                    {
                        list.Fields.Delete(s);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                    myLog.WriteEntry("Error in getCustomFields(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                });
            }

            web.Close();
        }
        private CustomField[] getCustomFields(string listName, int visibleCol, string projectServerURL)
        {
            ArrayList arrCF = new ArrayList();
            Hashtable hshCurFields = new Hashtable();
            Hashtable hshDBFields = new Hashtable();

            SPSite site = SPContext.Current.Site;
            SPWeb web = SPContext.Current.Web;

            try
            {

                SPSite psSite = new SPSite(projectServerURL);
                Guid psSiteID = psSite.ID;
                string scn = EPMLiveCore.CoreFunctions.getConnectionString(psSite.WebApplication.Id);
                psSite.Close();

                SPList list = web.Lists[listName];
                foreach (SPField f in list.Fields)
                {
                    hshCurFields.Add(f.InternalName, f.ShowInEditForm);
                }

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SqlConnection cn = new SqlConnection(scn);
                    cn.Open();

                    //Read Standard and Custom Fields
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMFIELDS WHERE fieldcategory = 1 OR fieldcategory=2 or fieldcategory=3", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        CustomField cf = new CustomField();
                        cf.displayName = dr.GetString(2);
                        cf.editable = dr.GetBoolean(1);
                        cf.fieldCategory = dr.GetInt32(3);
                        cf.locked = dr.GetBoolean(visibleCol);
                        cf.visible = dr.GetBoolean(visibleCol);
                        cf.wssFieldName = dr.GetString(4);
                        cf.fieldType = getFieldType(dr.GetString(7));

                        if (hshCurFields.Contains(cf.wssFieldName) && cf.visible == false)
                        {
                            cf.visible = true;
                            if (hshCurFields[cf.wssFieldName] == null)
                                cf.editable = true;
                            else
                                cf.editable = (bool)hshCurFields[cf.wssFieldName];
                        }

                        arrCF.Add(cf);

                        hshDBFields.Add(cf.wssFieldName, "");
                    }
                    dr.Close();

                    //Read Enterprise Fields
                    //WebSvcCustomFields.CustomFields svcCF = new EPMLiveEnterprise.WebSvcCustomFields.CustomFields();
                    //svcCF.Url = projectServerURL + "/_vti_bin/psi/customfields.asmx";
                    //svcCF.UseDefaultCredentials = true;
                    CustomFieldsDerived svcCF = EPMLiveHelperClasses.GetCustomFieldsDerivedObject(projectServerURL);
                    //CustomFieldsDerived svcCF = new CustomFieldsDerived();
                    //svcCF.Url = projectServerURL + "/_vti_bin/psi/customfields.asmx";
                    //svcCF.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                    //svcCF.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(projectServerURL);
                    //svcCF.EnforceWindowsAuth = true;

                    WebSvcCustomFields.CustomFieldDataSet dsF = svcCF.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));
                    for (int i = 0; i < dsF.CustomFields.Count; i++)
                    {
                        WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow customField = dsF.CustomFields[i];

                        string wssField = "ENT" + customField.MD_PROP_ID.ToString();

                        if (!hshDBFields.Contains(wssField))
                        {
                            CustomField cf = new CustomField();
                            cf.displayName = customField.MD_PROP_NAME;
                            cf.editable = false;
                            cf.fieldCategory = 3;
                            cf.locked = false;
                            cf.visible = false;
                            cf.wssFieldName = wssField;

                            if (customField.IsMD_LOOKUP_TABLE_UIDNull())
                                cf.fieldType = getFieldTypeFromCF(((PSLibrary.PropertyType)customField.MD_PROP_TYPE_ENUM).ToString());
                            else
                                cf.fieldType = SPFieldType.Choice;

                            if (hshCurFields.Contains(cf.wssFieldName) && cf.visible == false)
                            {
                                cf.visible = true;
                                cf.editable = (bool)hshCurFields[cf.wssFieldName];
                            }

                            arrCF.Add(cf);
                        }
                    }
                    cn.Close();
                });

            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                    myLog.WriteEntry("Error in getCustomFields(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                });
            }

            web.Close();
            site.Close();

            CustomField[] cfs = new CustomField[arrCF.Count];
            int counter = 0;
            foreach (CustomField f in arrCF)
            {
                cfs[counter++] = f;
            }

            return cfs;
        }

        

        private SPFieldType getFieldTypeFromCF(string fieldType)
        {
            switch (fieldType)
            {
                case "NumberEng96":
                    return SPFieldType.Number;
                case "CostEng96":
                    return SPFieldType.Currency;
                case "StringEng96":
                    return SPFieldType.Text;
                case "YesNoEng96":
                    return SPFieldType.Boolean;
                case "DurationEng96":
                    return SPFieldType.Number;
                case "StartDateEng96":
                    return SPFieldType.DateTime;
                case "CHOICE":
                    return SPFieldType.Choice;
            }
            return SPFieldType.Text;
        }
        private SPFieldType getFieldType(string fieldType)
        {
            switch (fieldType)
            {
                case "CURRENCY":
                    return SPFieldType.Currency;
                case "NUMBER":
                    return SPFieldType.Number;
                case "DATETIME":
                    return SPFieldType.DateTime;
                case "TEXT":
                    return SPFieldType.Text;
                case "BOOLEAN":
                    return SPFieldType.Boolean;
                case "CHOICE":
                    return SPFieldType.Choice;
                case "DURATION":
                    return SPFieldType.Number;
            }
            return SPFieldType.Text;
        }
        [WebMethod]
        public string[] getAllTaskEnterpriseFieldList()
        {
            ArrayList arrList = new ArrayList();

            SPWeb web = SPContext.Current.Web;

            string url = web.Url;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                //WebSvcCustomFields.CustomFields svcCF = new EPMLiveEnterprise.WebSvcCustomFields.CustomFields();
                //svcCF.Url = url + "/_vti_bin/psi/customfields.asmx";
                //svcCF.UseDefaultCredentials = true;
                CustomFieldsDerived svcCF = EPMLiveHelperClasses.GetCustomFieldsDerivedObject(url);
                //CustomFieldsDerived svcCF = new CustomFieldsDerived();
                //svcCF.Url = url + "/_vti_bin/psi/customfields.asmx";
                //svcCF.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                //svcCF.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(url);
                //svcCF.EnforceWindowsAuth = true;

                WebSvcCustomFields.CustomFieldDataSet dsF = svcCF.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));

                foreach(WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow cfr in dsF.CustomFields)
                {
                    arrList.Add("ENT" + cfr.MD_PROP_ID.ToString());
                }
            });

            string []ret = new string[arrList.Count];
                
            for(int i = 0;i<arrList.Count;i++)
            {
                ret[i] = (string)arrList[i];
            }

            return ret;
        }
        [WebMethod]
        public string[] getAllProjectEnterpriseFieldList()
        {
            string[] ret = new string[0];
            string username = "";
            try
            {
                ArrayList arrList = new ArrayList();

                SPWeb web = SPContext.Current.Web;

                string url = web.Url;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    username = "Context: [" + HttpContext.Current.User.Identity.Name + "] Windows [" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "]";

                    //WebSvcCustomFields.CustomFields svcCF = new EPMLiveEnterprise.WebSvcCustomFields.CustomFields();
                    //svcCF.Url = url + "/_vti_bin/psi/customfields.asmx";
                    //svcCF.UseDefaultCredentials = true;
                    CustomFieldsDerived svcCF = EPMLiveHelperClasses.GetCustomFieldsDerivedObject(url);
                    //CustomFieldsDerived svcCF = new CustomFieldsDerived();
                    //svcCF.Url = url + "/_vti_bin/psi/customfields.asmx";
                    //svcCF.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                    //svcCF.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(url);
                    //svcCF.EnforceWindowsAuth = true;

                    WebSvcCustomFields.CustomFieldDataSet dsF = svcCF.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.ProjectEntity.UniqueId));

                    foreach (WebSvcCustomFields.CustomFieldDataSet.CustomFieldsRow cfr in dsF.CustomFields)
                    {
                        arrList.Add("ENT" + cfr.MD_PROP_ID.ToString());
                    }
                });

                ret = new string[arrList.Count];

                for (int i = 0; i < arrList.Count; i++)
                {
                    ret[i] = (string)arrList[i];
                }

            }
            catch(Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                    myLog.WriteEntry("Error in getAllProjectEnterpriseFieldList() username (" + username + "): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                });
            }
            return ret;
        }
        [WebMethod]
        public bool publish(Guid projectUid, int pubType, string url)
        {
            bool bRet = false;
            Guid siteid = SPContext.Current.Site.ID;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = null;
                try
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                    cn.Open();

                    //WebSvcProject.Project svcProject = new WebSvcProject.Project();
                    //svcProject.Url = SPContext.Current.Site.Url + "/_vti_bin/psi/project.asmx";
                    //svcProject.UseDefaultCredentials = true;
                    ProjectDerived svcProject = EPMLiveHelperClasses.GetProjectDerivedObject(SPContext.Current.Site.Url);
                    //ProjectDerived svcProject = new ProjectDerived();
                    //svcProject.Url = SPContext.Current.Site.Url + "/_vti_bin/psi/project.asmx";
                    //svcProject.Credentials = EPMLiveHelperClasses.GetNetworkCredential();
                    //svcProject.CookieContainer = EPMLiveHelperClasses.GetLogonCookie(SPContext.Current.Site.Url);
                    //svcProject.EnforceWindowsAuth = true;

                    WebSvcProject.ProjectDataSet pds = svcProject.ReadProject(projectUid, WebSvcProject.DataStoreEnum.WorkingStore);
                    string projectname = pds.Project[0].PROJ_NAME;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM publishercheck where projectguid=@projectguid", cn);
                    cmd.Parameters.AddWithValue("@projectguid", projectUid);
                    SqlDataReader drPubCheck = cmd.ExecuteReader();

                    if (drPubCheck.Read())
                    {
                        drPubCheck.Close();
                        cmd = new SqlCommand("UPDATE publishercheck set checkbit=1,pubType=@pubType,weburl=@weburl,projectname=@projectname,percentcomplete=1,status=1,laststatusdate=getdate() where projectguid=@projectguid", cn);
                        cmd.Parameters.AddWithValue("@projectguid", projectUid);
                        cmd.Parameters.AddWithValue("@pubtype", pubType);
                        cmd.Parameters.AddWithValue("@weburl", url);
                        cmd.Parameters.AddWithValue("@projectname", projectname);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        drPubCheck.Close();
                        cmd = new SqlCommand("INSERT INTO publishercheck (projectguid,checkbit,pubType,weburl, projectname,percentcomplete,status,laststatusdate) VALUES (@projectguid,1,@pubtype,@weburl,@projectname,1,1,GETDATE())", cn);
                        cmd.Parameters.AddWithValue("@projectguid", projectUid);
                        cmd.Parameters.AddWithValue("@pubtype", pubType);
                        cmd.Parameters.AddWithValue("@weburl", url);
                        cmd.Parameters.AddWithValue("@projectname", projectname);
                        cmd.ExecuteNonQuery();
                    }

                    //svcProject.QueuePublish(Guid.NewGuid(), projectUid, true, null); // Munjal --- Try to trigger Publish event!!

                    cn.Close();
                    bRet = true;
                }
                catch (Exception ex)
                {
                    EventLog myLog = new EventLog("EPM Live", ".", "Publisher Check WS");
                    myLog.WriteEntry("Error: " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);

                    try
                    {
                        cn.Close();
                    }
                    catch { }
                    bRet = false;
                }
            });
            return bRet;
        }
        [WebMethod]
        public string[] getSiteTemplates()
        {
            ArrayList arrValidTemplates = new ArrayList();
            using (SPSite site = SPContext.Current.Site)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    try
                    {
                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='ValidTemplates'", cn);
                        SqlDataReader dReader = cmd.ExecuteReader();
                        if (dReader.Read())
                        {
                            string[] strValidtemplates = dReader.GetString(0).Split('|');
                            foreach (string template in strValidtemplates)
                            {
                                arrValidTemplates.Add(template);
                            }
                        }
                        dReader.Close();

                        cn.Close();
                    }
                    catch (Exception ex1)
                    {
                        EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                        myLog.WriteEntry("Error getting valid templates(): " + ex1.Message, EventLogEntryType.Error, 1000);
                    }
                });
            }

            SPWebTemplateCollection sptemps = SPContext.Current.Site.RootWeb.GetAvailableWebTemplates(1033);
            
            SortedList sl = new SortedList();
            
            int counter = 0;
            foreach (SPWebTemplate webTemplate in sptemps)
            {
                if (!webTemplate.IsHidden)
                    if (arrValidTemplates.Contains(webTemplate.Title))
                        sl.Add(webTemplate.Title + "|" + webTemplate.Name, "");
            }
            string[] templates = new string[sl.Count];
            foreach(DictionaryEntry de in sl)
            {
                templates[counter++] = de.Key.ToString();
            }
            return templates;
        }
        [WebMethod]
        public string getEnterpriseSetting(string setting)
        {
            string ret = "";
            Guid siteId = SPContext.Current.Site.ID;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='" + setting + "'", cn);
                    SqlDataReader dReader = cmd.ExecuteReader();
                    if (dReader.Read())
                    {
                        ret = dReader.GetString(0);
                    }
                    dReader.Close();
                    cn.Close();
                });
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    EventLog myLog = new EventLog("EPM Live", ".", "Publisher WS");
                    myLog.WriteEntry("Error in getEnterpriseSetting(): " + ex.Message + ex.StackTrace, EventLogEntryType.Error, 1000);
                });
            }
            return ret;
        }
    }
}