using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Web;
using System.Net;

namespace EPMLiveWebParts.Layouts.epmlive
{
    

    public partial class tlwizard : LayoutsPageBase
    {
        [DllImport("advapi32.dll",CharSet=CharSet.Unicode,SetLastError=true)]
        static public extern bool LogonUser(string userName,string domain,string passWord,int logonType,int logonProvider,ref IntPtr accessToken);
        [DllImport("kernel32.dll", CharSet=CharSet.Auto)]
        public static extern  bool CloseHandle(IntPtr handle);

        static int step = 1;
        static string ssrsurl = "";

        private void appendclick(System.Web.UI.WebControls.Button btn)
        {
            btn.Attributes.Add("onclick", "disableButtons(this);" + Page.GetPostBackEventReference(btn).ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!SPContext.Current.Web.CurrentUser.IsSiteAdmin)
            //    Response.Redirect("../accessdenied.aspx");

            
            if (!IsPostBack)
            {
                step = 1;
                if (EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportsUseIntegrated").ToLower() != "true")
                {
                    lblReporting.Visible = true;
                    txtReportServer.Enabled = false;
                    txtReportPassword.Enabled = false;

                    txtReportDatabase.Enabled = false;
                    txtReportUsername.Enabled = false;
                }
                else
                {
                    ssrsurl = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL");

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        string strCon = EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id);
                        if(strCon != "")
                        {
                            SqlConnection cn = new SqlConnection(strCon);
                            cn.Open();

                            SqlCommand cmd = new SqlCommand("SELECT databaseserver,databasename from RPTDATABASES where siteid=@siteid", cn);
                            cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if(dr.Read())
                            {
                                txtReportDatabase.Text = dr.GetString(1);
                                txtReportServer.Text = dr.GetString(0);
                            }
                            else
                            {
                                ssrsurl = "";
                                lblNoReporting.Visible = true;
                                txtReportServer.Enabled = false;
                                txtReportPassword.Enabled = false;
                                txtReportDatabase.Enabled = false;
                                txtReportUsername.Enabled = false;
                                chkWindows.Enabled = false;
                            }
                            dr.Close();

                            try
                            {
                                cmd = new SqlCommand("SELECT clientusername,clientpassword from RPTDATABASES where siteid=@siteid", cn);
                                cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                dr = cmd.ExecuteReader();

                                dr.Read();

                                txtReportPassword.Text = dr.GetString(1);
                                txtReportUsername.Text = dr.GetString(0);
                                hdnSaveReportPassword.Value = dr.GetString(1);
                                txtReportPassword.Enabled = false;
                                txtReportUsername.Enabled = false;
                                chkWindows.Enabled = false;

                                dr.Close();
                            }
                            catch { }

                            cn.Close();
                        }
                        else
                        {
                            ssrsurl = "";
                            lblNoReporting.Visible = true;
                            txtReportServer.Enabled = false;
                            txtReportPassword.Enabled = false;
                            txtReportDatabase.Enabled = false;
                            txtReportUsername.Enabled = false;
                            chkWindows.Enabled = false;
                        }
                    });
                }

                

                appendclick(btnNext1);
                appendclick(bntCancel1);
                appendclick(btnNext2);
                appendclick(btnBack2);
                appendclick(btnCancel2);
                appendclick(btnBack3);
                appendclick(btnFinish);
                appendclick(btnCancel3);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            switch (step)
            {
                case 2:
                    pnl1.Visible = true;
                    pnl2.Visible = false;
                    break;
                case 3:
                    if(ssrsurl != "")
                    {

                        pnl2.Visible = true;
                        pnl3.Visible = false;
                    }
                    else
                    {
                        pnl1.Visible = true;
                        pnl3.Visible = false;
                        step--;
                    }
                    break;
                case 4:
                    pnl3.Visible = true;
                    pnlDone.Visible = false;
                    break;
            }
            step--;
        }

        protected void btnSkip_Click(object sender, EventArgs e)
        {
            ssrsurl = "";
            step++;
            pnl2.Visible = false;
            pnl3.Visible = true;
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            switch (step)
            {
                case 1:
                    step++;
                    if(ssrsurl != "")
                    {
                        pnl1.Visible = false;
                        pnl2.Visible = true;
                        
                    }
                    else
                    {
                        step++;
                        pnl1.Visible = false;
                        pnl3.Visible = true;
                    }
                    break;
                case 2:
                    string cn = "";
                    
                    cn = checkConnection();

                    if(cn == "")
                    {
                        pnl2.Visible = false;
                        pnl3.Visible = true;
                        lblReportingError.Visible = false;
                        hdnReportPassword.Value = txtReportPassword.Text;
                        step++;
                    }
                    else
                    {
                        lblReportingError.Text = cn;
                        lblReportingError.Visible = true;
                    }

                    break;
                case 3:
                    pnl3.Visible = false;
                    pnlDone.Visible = true;
                    step++;
                    break;
                case 4:
                    btnYes_Click(sender, e);
                    step++;
                    break;
            }
            
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            pnlDone.Visible = false;
            pnlProcessing.Visible = true;
            string url = "";
            SPWeb w = SPContext.Current.Web;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(w.Url))
                {
                    using(SPWeb web = site.OpenWeb())
                    {
                        site.AllowUnsafeUpdates = true;
                        web.AllowUnsafeUpdates = true;
                        try
                        {
                            string loc = EPMLiveCore.CoreFunctions.getConfigSetting(web, "epmlivewizardredirect");
                            if(loc != "")
                            {
                                url = ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + loc;
                            }
                            else
                            {
                                SPList list = web.Lists["Configuration Tasks"];
                                url = list.DefaultView.ServerRelativeUrl;
                            }
                        }
                        catch { }

                        processQuickLaunch(web);
                        hideWizard(web);
                        if(ssrsurl != "")
                        {
                            processReports(web);
                        }

                        ProcessNotifications(web);
                        ProcessTimerJob(web);
                        ProcessReportingRefreshJob(web);
                        ProcessBackEndLists(web);
                        ProcessGroups(web, w.CurrentUser);

                        if(rdoYes.Checked)
                        {
                            if(url != "")
                            {
                                if(Request["isdlg"] == "1")
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect", "<script language=\"javascript\">window.parent.location.href='" + url + "';</script>");
                                else
                                    Response.Redirect(url);
                            }
                            else
                            {
                                if(Request["isdlg"] == "1")
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", "<script language=\"javascript\">window.parent.location.href = window.parent.location.href;</script>");
                                else
                                    Response.Redirect(web.ServerRelativeUrl + "/_layouts/settings.aspx");
                            }
                        }
                        else
                        {
                            if(Request["isdlg"] == "1")
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", "<script language=\"javascript\">window.parent.location.href = window.parent.location.href;</script>");
                            else
                                Response.Redirect(web.ServerRelativeUrl + "/_layouts/settings.aspx");
                        }
                    }
                }
            });
        }

        private void ProcessReportingRefreshJob(SPWeb web)
        {
            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn.Open();
            });
            Guid timerjobguid;
            SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=5", cn);
            cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                timerjobguid = dr.GetGuid(0);
                dr.Close();
                cmd = new SqlCommand("UPDATE TIMERJOBS set runtime = @runtime where siteguid=@siteguid and jobtype=5", cn);
                cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                cmd.Parameters.AddWithValue("@runtime", ddlReportingRefresh.SelectedValue);
                cmd.ExecuteNonQuery();
            }
            else
            {
                timerjobguid = Guid.NewGuid();
                dr.Close();
                cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, runtime, scheduletype, webguid) VALUES (@timerjobuid, @siteguid, 5, 'Reporting Refresh', @runtime, 2, @webguid)", cn);
                cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                cmd.Parameters.AddWithValue("@timerjobuid", timerjobguid);
                cmd.Parameters.AddWithValue("@webguid", web.ID.ToString());
                cmd.Parameters.AddWithValue("@runtime", ddlReportingRefresh.SelectedValue);
                cmd.ExecuteNonQuery();
            }

            cn.Close();
        }

        private void ProcessGroups(SPWeb web, SPUser user)
        {
            SPRole roll;

            try
            {
                web.Roles.Add("Contribute2", "Can view, add, update, delete and manage subwebs", web.Roles["Contribute"].PermissionMask | SPRights.ManageSubwebs);
            }
            catch { }
            try
            {
                web.SiteGroups.Add("Administrators", user, user, "");
                roll = web.Roles["Full Control"];
                roll.AddGroup(web.SiteGroups["Administrators"]);
            }
            catch { }

            SPMember newOwner = web.SiteGroups["Administrators"];


            try
            {
                web.SiteGroups.Add("Team Members", newOwner, user, "");
                roll = web.Roles["Contribute"];
                roll.AddGroup(web.SiteGroups["Team Members"]);
            }
            catch { }
            try
            {
                web.SiteGroups.Add("Visitors", newOwner, user, "");
                roll = web.Roles["Read"];
                roll.AddGroup(web.SiteGroups["Visitors"]);
            }
            catch { }

            roll = web.Roles["Contribute2"]; 
            
            try
            {
                web.SiteGroups.Add("Project Managers", newOwner, user, "");
                roll.AddGroup(web.SiteGroups["Project Managers"]);
            }
            catch { }
            try
            {
                web.SiteGroups.Add("Portfolio Managers", newOwner, user, "");
                roll.AddGroup(web.SiteGroups["Portfolio Managers"]);
            }
            catch { }
            try
            {
                web.SiteGroups.Add("Resource Managers", newOwner, user, "");
                roll.AddGroup(web.SiteGroups["Resource Managers"]);
            }
            catch { }
            try
            {
                web.SiteGroups.Add("Executives", newOwner, user, "");
                roll.AddGroup(web.SiteGroups["Executives"]);
            }
            catch { }

            try
            {
                web.AssociatedVisitorGroup = GetSiteGroup(web, "Visitors");
            }
            catch { }
            try
            {
                web.AssociatedOwnerGroup = GetSiteGroup(web, "Administrators");
            }
            catch { }

            try
            {
                web.AssociatedMemberGroup = GetSiteGroup(web, "Team Members");
            }
            catch { }


        }

        static SPGroup GetSiteGroup(SPWeb web, string name)
        {
            foreach(SPGroup group in web.SiteGroups)
                if(group.Name.ToLower() == name.ToLower())
                    return group;
            return null;
        }

        private void ProcessBackEndLists(SPWeb web)
        {
            ProcessBackEndList(web, "Roles");
            ProcessBackEndList(web, "WorkHours");
            ProcessBackEndList(web, "Non Work");
            ProcessBackEndList(web, "HolidaySchedules");
            ProcessBackEndList(web, "Departments");
        }

        private void ProcessBackEndList(SPWeb web, string slist)
        {
            SPList list = web.Lists.TryGetList(slist);
            if(list != null)
            {
                try
                {
                    list.Items[0].Update();
                }
                catch { }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlDone.Visible = false;
            pnl1.Visible = false;
            pnl2.Visible = false;

            SPWeb web = SPContext.Current.Web;
            processQuickLaunch(web);
            //hideWizard(web);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", "<script language=\"javascript\">SP.UI.ModalDialog.commonModalDialogClose(0, '');</script>");
        }

        private void ProcessTimerJob(SPWeb web)
        {
            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn.Open();
            });
            Guid timerjobguid;
            SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=2", cn);
            cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                timerjobguid = dr.GetGuid(0);
                dr.Close();
                cmd = new SqlCommand("UPDATE TIMERJOBS set runtime = @runtime where siteguid=@siteguid and jobtype=2", cn);
                cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                cmd.Parameters.AddWithValue("@runtime", ddlTimerRunTime.SelectedValue);
                cmd.ExecuteNonQuery();
            }
            else
            {
                timerjobguid = Guid.NewGuid();
                dr.Close();
                cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, runtime, scheduletype, webguid) VALUES (@timerjobuid, @siteguid, 2, 'Today Fix/Res Plan', @runtime, 2, @webguid)", cn);
                cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                cmd.Parameters.AddWithValue("@timerjobuid", timerjobguid);
                cmd.Parameters.AddWithValue("@webguid", web.ID.ToString());
                cmd.Parameters.AddWithValue("@runtime", ddlTimerRunTime.SelectedValue);
                cmd.ExecuteNonQuery();
            }


            ////=========================Res Plan Job================
            //cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=1", cn);
            //cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
            //dr = cmd.ExecuteReader();

            //string planlists = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResPlannerLists");

            //if(dr.Read())
            //{
            //    dr.Close();
            //    cmd = new SqlCommand("UPDATE TIMERJOBS set enabled = @enabled, parentjobuid=@parentjobuid where siteguid=@siteguid and jobtype=1", cn);
            //    cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
            //    cmd.Parameters.AddWithValue("@enabled", (planlists.Length > 0));
            //    cmd.Parameters.AddWithValue("@parentjobuid", timerjobguid);
            //    cmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    dr.Close();
            //    cmd = new SqlCommand("INSERT INTO TIMERJOBS (siteguid, jobtype, jobname, enabled, scheduletype,webguid, parentjobuid) VALUES (@siteguid, 1, 'Res Plan', @enabled, 1,@webguid,@parentjobuid)", cn);
            //    cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
            //    cmd.Parameters.AddWithValue("@webguid", web.ID.ToString());
            //    cmd.Parameters.AddWithValue("@enabled", (planlists.Length > 0));
            //    cmd.Parameters.AddWithValue("@parentjobuid", timerjobguid);

            //    cmd.ExecuteNonQuery();
            //}
            cn.Close();
        }

        private void ProcessNotifications(SPWeb web)
        {
            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn.Open();
            });

            SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=3", cn);
            cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                dr.Close();
                cmd = new SqlCommand("UPDATE TIMERJOBS set runtime = @runtime where siteguid=@siteguid and jobtype=3", cn);
                cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                cmd.Parameters.AddWithValue("@runtime", ddlNotificationRunTime.SelectedValue);
                cmd.ExecuteNonQuery();
            }
            else
            {
                dr.Close();
                cmd = new SqlCommand("INSERT INTO TIMERJOBS (siteguid, jobtype, jobname, runtime, scheduletype, webguid) VALUES (@siteguid, 3, 'Notifications', @runtime, 2, @webguid)", cn);
                cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                cmd.Parameters.AddWithValue("@webguid", web.ID.ToString());
                cmd.Parameters.AddWithValue("@runtime", ddlNotificationRunTime.SelectedValue);
                cmd.ExecuteNonQuery();
            }

            cn.Close();
        }

        private void processQuickLaunch(SPWeb web)
        {
            EPMLiveCore.WorkEngineAPI.GenerateQuickLaunchFromApp("", web);

            foreach (Microsoft.SharePoint.Navigation.SPNavigationNode nd in web.Navigation.TopNavigationBar)
            {
                nd.Update();
            }
            web.Update();
        }

        private string checkConnection()
        {
            try
            {
                if (chkWindows.Checked)
                {
                    string error = "";

                    SPSecurity.RunWithElevatedPrivileges(delegate(){
                        string username = txtReportUsername.Text;
                        string domain = "";

                        try
                        {
                            username = txtReportUsername.Text.Split('\\')[1];
                            domain = txtReportUsername.Text.Split('\\')[0];
                        }
                        catch { }
                        string password = txtReportPassword.Text;
                        if (password == "")
                            password = hdnSaveReportPassword.Value;

                        IntPtr userHandle = IntPtr.Zero;

                        bool loggedOn = LogonUser(
                            username,
                            domain,
                            password,
                            2,
                            0,
                            ref userHandle);

                        if (!loggedOn)
                        {
                            error = "Invalid username or password";
                        }
                        else
                        {
                            // Begin impersonating the user
                            WindowsImpersonationContext impersonationContext = WindowsIdentity.Impersonate(userHandle);

                            try
                            {
                                SqlConnection cn = new SqlConnection("Server=" + txtReportServer.Text + ";Database=" + txtReportDatabase.Text + ";Trusted_Connection=True");
                                cn.Open();
                                cn.Close();
                            }
                            catch (Exception ex)
                            {
                                error = ex.Message;
                            }

                            // Clean up
                            CloseHandle(userHandle);
                            impersonationContext.Undo();
                        }
                    });

                    return error;
                    
                }
                else
                {
                    string password = txtReportPassword.Text;
                    if (password == "")
                        password = hdnSaveReportPassword.Value;
                    SqlConnection cn = new SqlConnection("Server=" + txtReportServer.Text + ";Database=" + txtReportDatabase.Text + ";User Id=" + txtReportUsername.Text + ";Password=" + password);
                    cn.Open();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        private void processReports(SPWeb web)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate(){

                SSRS2006.ReportingService2006 SSRS = new SSRS2006.ReportingService2006();
                SSRS.Url = ssrsurl + "/ReportService2006.asmx";
                SSRS.UseDefaultCredentials = true;

                string username = "";
                string password = "";
                EPMLiveCore.ReportAuth _chrono = SPContext.Current.Site.WebApplication.GetChild<EPMLiveCore.ReportAuth>("ReportAuth");
                if(_chrono != null)
                {
                    username = _chrono.Username;
                    password = EPMLiveCore.CoreFunctions.Decrypt(_chrono.Password, "KgtH(@C*&@Dhflosdf9f#&f");
                }

                if(password != "")
                {
                    SSRS.UseDefaultCredentials = false;
                    if(username.Contains("\\"))
                    {
                        SSRS.Credentials = new System.Net.NetworkCredential(username.Substring(username.IndexOf("\\") + 1), password, username.Substring(0, username.IndexOf("\\")));
                    }
                    else
                    {
                        SSRS.Credentials = new System.Net.NetworkCredential(username, password);
                    }
                }


                /*System.Web.HttpCookie tCookie = System.Web.HttpContext.Current.Response.Cookies["WSS_KeepSessionAuthenticated"];

                System.Net.Cookie oC = new System.Net.Cookie();

                // Convert between the System.Net.Cookie to a System.Web.HttpCookie...
                oC.Domain = System.Web.HttpContext.Current.Request.Url.Host;
                oC.Expires = tCookie.Expires;
                oC.Name = tCookie.Name;
                oC.Path = tCookie.Path;
                oC.Secure = tCookie.Secure;
                oC.Value = tCookie.Value;
                 
                SSRS.CookieContainer = new System.Net.CookieContainer();

                SSRS.CookieContainer.Add(oC);
                */


                var authCookie = HttpContext.Current.Request.Cookies["FedAuth"];

                var fedAuth = new Cookie(authCookie.Name, authCookie.Value, authCookie.Path, string.IsNullOrEmpty(authCookie.Domain) ? HttpContext.Current.Request.Url.Host : authCookie.Domain);
                SSRS.CookieContainer =

                new CookieContainer();
                SSRS.CookieContainer.Add(fedAuth);

                SPDocumentLibrary list = (SPDocumentLibrary)web.Lists["Report Library"];

                SPListItemCollection folders = list.GetItemsInFolder(list.DefaultView, list.RootFolder);

                foreach (SPListItem li in folders)
                {
                    if (li.FileSystemObjectType == SPFileSystemObjectType.Folder && li.Name == "Data Sources")
                    {
                        SSRS2006.DataSourceDefinition dsd = new SSRS2006.DataSourceDefinition();
                        dsd.ConnectString = "Data Source=" + txtReportServer.Text + ";Initial Catalog=" + txtReportDatabase.Text + ";";
                        dsd.CredentialRetrieval = SSRS2006.CredentialRetrievalEnum.Store;
                        dsd.UserName = txtReportUsername.Text;
                        if (hdnReportPassword.Value == "")
                            dsd.Password = hdnSaveReportPassword.Value;
                        else
                            dsd.Password = hdnReportPassword.Value;
                        
                        if(chkWindows.Checked)
                            dsd.WindowsCredentials = chkWindows.Checked;

                        dsd.Enabled = true;
                        dsd.Extension = "SQL";

                        SSRS.CreateDataSource("EPMLiveReportDB.rsds", web.Url + "/" + li.Url, true, dsd, null);
                    }
                }
            
                SSRS2006.DataSourceReference dsr = new SSRS2006.DataSourceReference();
                dsr.Reference = web.Url + "/Report Library/Data Sources/EPMLiveReportDB.rsds";

                foreach (SPListItem li in folders)
                {
                    processRDL(SSRS, web, li, dsr, list);
                }
            });
        }

        private void processRDL(SSRS2006.ReportingService2006 SSRS, SPWeb web, SPListItem folder, SSRS2006.DataSourceReference dsr, SPDocumentLibrary list)
        {
            foreach (SPListItem li in list.GetItemsInFolder(list.DefaultView, folder.Folder))
            {
                if (li.FileSystemObjectType == SPFileSystemObjectType.Folder)
                {

                    processRDL(SSRS, web, li, dsr, list);
                }
                else
                {
                    try
                    {
                        SSRS2006.DataSource[] dsstl = SSRS.GetItemDataSources(web.Url + "/" + li.Url);
                        for (int i = 0; i < dsstl.Length; i++)
                        {
                            if (dsstl[i].Name == "EPMLiveReportDB")
                            {
                                dsstl[i].Item = dsr;
                            }
                        }
                        SSRS.SetItemDataSources(web.Url + "/" + li.Url, dsstl);
                    }
                    catch { }
                }
            }
            
        }

        private void hideWizard(SPWeb web)
        {
            if (web.Properties.ContainsKey("workenginewizard"))
            {
                web.Properties["workenginewizard"] = web.ID.ToString();
                web.Properties.Update();
                web.Update();
            }
            else
            {
                web.Properties.Add("workenginewizard", web.ID.ToString());
                web.Properties.Update();
                web.Update();
            }
        }
    }
}
