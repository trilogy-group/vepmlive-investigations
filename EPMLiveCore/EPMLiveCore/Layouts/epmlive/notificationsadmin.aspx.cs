using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint.Administration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.Text;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class notificationsadmin : LayoutsPageBase
    {
        public string strTitle;
        public string strTemplate;
        public static Hashtable desc;
        //protected ListBox lstSiteUsers;           --EPML 1901
        //protected ListBox lstNotificationUsers;   --EPML 1901
        //protected CheckBox chkLockNotify;         --EPML 1901
        protected Panel pnlTL;
        protected Panel pnlMain;
        protected Panel pnlGeneralSettings;
        protected Panel pnlUserSettings;
        protected HyperLink hlAdmin;
        protected Button Button1;
        protected Button btnAdd;
        protected Button btnRemove;
        protected Button btnTest;
        protected DropDownList ddlRunTime;
        protected TextBox txtFromEmail; 
        protected TextBox txtEmailSubject;
        protected TextBox txtNotes;
        protected GridView gvNotificationLists;
        protected Label lblLastRun;
        protected Label lblNotEnabled;
        //protected CheckBox chkAllUsers;           --EPML 1901
        protected Label lblStatus;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SPWeb web = SPContext.Current.Web;

                if(!CoreFunctions.DoesCurrentUserHaveFullControl(web))
                {
                    Microsoft.SharePoint.Utilities.SPUtility.TransferToErrorPage("Access denied.");
                }

                if (!web.IsRootWeb)
                {
                    pnlTL.Visible = true;
                    hlAdmin.NavigateUrl = SPContext.Current.Site.Url + "/_layouts/epmlive/notificationsadmin.aspx";
                    pnlMain.Visible = false;
                }
                else
                {
                    SPSite site;

                    if (Request["delete"] != null && Request["delete"] != "")
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            DeleteList(Request["delete"]);
                        });
                    }

                    MenuTemplate propertyNameListMenu = new MenuTemplate();
                    propertyNameListMenu.ID = "PropertyNameListMenu";

                    MenuItemTemplate miDel = new MenuItemTemplate("Delete Section", "/_layouts/images/delete.gif");
                    miDel.ClientOnClickNavigateUrl = "javascript:delOkCancel('%NAME%')";
                    propertyNameListMenu.Controls.Add(miDel);
                    MenuItemTemplate miEdit = new MenuItemTemplate("Edit Section", "/_layouts/images/edit.gif");
                    miEdit.ClientOnClickScript = "javascript:editNotificationList('%NAME%','%RNUM%','%QRY%')";
                    propertyNameListMenu.Controls.Add(miEdit);

                    this.Controls.Add(propertyNameListMenu);



                    //try
                    //{
                    //    using (SPSite sites = SPContext.Current.Site)
                    //    {
                    //        SPSecurity.RunWithElevatedPrivileges(delegate()
                    //        {
                    //            SPSite realsite = new SPSite(sites.ID);
                    //            bool found = false;
                    //            foreach (SPJobDefinition job in realsite.WebApplication.JobDefinitions)
                    //            {
                    //                if (job.Name == "EPM Live Timer Service" && !job.IsDisabled)
                    //                    found = true;
                    //            }
                    //            if (!found)
                    //                lblNotEnabled.Visible = true;
                    //            else
                    //                lblNotEnabled.Visible = false;
                    //            realsite.Close();
                    //        });
                    //    }
                    //}
                    //catch { }

                    if (!IsPostBack)
                    {
                        if (!SPContext.Current.Web.IsRootWeb)
                        {
                            pnlTL.Visible = true;
                            hlAdmin.NavigateUrl = SPContext.Current.Site.Url + "/_layouts/epmlive/notificationsadmin.aspx";
                            //pnlMain.Visible = false;
                        }
                        else
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                site = SPContext.Current.Site;
                                site.CatchAccessDeniedException = false;

                                SPWeb currWeb = SPContext.Current.Web;
                                {
                                    currWeb.AllowUnsafeUpdates = true;

                                    if (currWeb.Properties.ContainsKey("EPMLiveNotificationEmail"))
                                    {
                                        txtFromEmail.Text = currWeb.Properties["EPMLiveNotificationEmail"];
                                    }
                                    if (currWeb.Properties.ContainsKey("EPMLiveNotificationEmailSubject"))
                                    {
                                        txtEmailSubject.Text = currWeb.Properties["EPMLiveNotificationEmailSubject"];
                                    }
                                    else
                                    {
                                        currWeb.Properties.Add("EPMLiveNotificationEmailSubject", "EPM Live: Task Status Report");
                                        currWeb.Properties.Update();
                                        txtEmailSubject.Text = "EPM Live: Task Status Report";
                                    }


                                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(currWeb.Site.WebApplication.Id));

                                    SPSecurity.RunWithElevatedPrivileges(delegate()
                                    {
                                        cn.Open();
                                    });


                                    SqlCommand cmd = new SqlCommand("select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=3", cn);
                                    cmd.Parameters.AddWithValue("@siteguid", currWeb.Site.ID);
                                    SqlDataReader dr = cmd.ExecuteReader();

                                    if (dr.Read())
                                    {
                                        ddlRunTime.SelectedValue = dr.GetInt32(1).ToString();

                                        if (!dr.IsDBNull(3))
                                        {
                                            if (dr.GetInt32(3) == 0)
                                            {
                                                lblStatus.Text = "Queued";
                                                btnTest.Enabled = false;
                                            }
                                            else if (dr.GetInt32(3) == 1)
                                            {
                                                lblStatus.Text = "Processing (" + dr.GetInt32(2).ToString("##0") + "%)";
                                                btnTest.Enabled = false;
                                            }
                                            else if (!dr.IsDBNull(5))
                                            {
                                                lblStatus.Text = dr.GetString(5);
                                            }
                                            else
                                            {
                                                lblStatus.Text = "No Results";
                                            }
                                        }

                                        if (!dr.IsDBNull(4))
                                            lblLastRun.Text = dr.GetDateTime(4).ToString();
                                    }

                                    dr.Close();

                                    cn.Close();

                                    if (currWeb.Properties.ContainsKey("EPMLiveNotificationNote"))
                                    {
                                        txtNotes.Text = currWeb.Properties["EPMLiveNotificationNote"];
                                    }
                                    else
                                    {
                                        currWeb.Properties.Add("EPMLiveNotificationNote", "The following items are assigned to you in EPM Live.");
                                        currWeb.Properties.Update();
                                        txtNotes.Text = "The following items are assigned to you in EPM Live.";
                                    }

                                    //-- EPML 1901 --

                                    //Store the Opted out users in the propery bag
                                    string sNotificationOptedOutUsers = string.Empty;

                                    if (currWeb.Properties.ContainsKey("EPMLiveNotificationOptedOutUsers"))
                                    {
                                        sNotificationOptedOutUsers = currWeb.Properties["EPMLiveNotificationOptedOutUsers"];
                                    }
                                    loadNotificationBoxes(site, sNotificationOptedOutUsers);

                                    //-- End EPML 1901 --

                                    //if (site.RootWeb.CurrentUser.IsSiteAdmin)
                                    //{
                                    //    pnlGeneralSettings.Visible = true;
                                    //    pnlUserSettings.Visible = true;
                                    //}
                                    //else
                                    //{
                                    //    pnlGeneralSettings.Visible = false;
                                    //    pnlUserSettings.Visible = false;
                                    //}
                                }
                            });
                        }
                    }
                    else
                    {
                        string sSection = Request["txSection"];
                        string sLists = Request["txList"];
                        string sCols = Request["txColumns"];
                        string sQueries = Request["txQuery"];
                        if(Request["txType"] == "add")
                        {
                            if (sSection.Trim() != "" & sLists.Trim() != "" & sCols.Trim() != "")
                            {
                                AddList(sSection, sLists, sCols, sQueries);
                                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/notificationsadmin.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                            }
                        }
                        else if(Request["txType"] == "edit")
                        {
                            EditList(sSection, sLists, sCols, sQueries);
                            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/notificationsadmin.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                        }
                    }

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        site = SPContext.Current.Site;
                        SPWeb currWeb = SPContext.Current.Web;
                        {
                            if(!currWeb.Properties.ContainsKey("EPMLiveNotificationLists"))
                            {
                                SPContext.Current.Web.AllowUnsafeUpdates = true;
                                currWeb.Properties.Add("EPMLiveNotificationLists", Properties.Resources.txtFileDefaultSections);
                                currWeb.Properties.Update();
                                SPContext.Current.Web.AllowUnsafeUpdates = false;
                            }
                            BindNListsToGrid(currWeb.Properties["EPMLiveNotificationLists"]);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            //Page.RegisterStartupScript("disableusers", "<script language=\"javascript\">alluserchange(document.getElementById(\"ctl00_PlaceHolderMain_ctl05_ctl00_chkAllUsers\"));</script>");
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                saveSettings();
                //using (SPSite site = SPContext.Current.Site)
                //{
                //    using (SPWeb web = site.RootWeb)
                //    {
                //        //NotificationsJob tjNotif = new NotificationsJob();
                //        //tjNotif.ShowGreeting = false;
                //        //tjNotif.LogDetailedErrors = true;
                //        //tjNotif.ErrorLogDetailLevel = NotificationsJob.ErrorLogDetailLevelEnum.JobLevelErrors;
                //        //tjNotif.ExecuteJob(web);

                //        //if (web.Properties.ContainsKey("epmlivenotificationlastrun"))
                //        //{
                //        //    lblLastRun.Text = web.Properties["epmlivenotificationlastrun"];
                //        //}
                //    }
                //}

                SPSite site = SPContext.Current.Site;
                {
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        cn.Open();
                    });

                    Guid jobguid = Guid.Empty;

                    SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=3", cn);
                    cmd.Parameters.AddWithValue("@siteguid", site.ID.ToString());
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        jobguid = dr.GetGuid(0);
                    }
                    dr.Close();

                    if (jobguid != Guid.Empty)
                    {
                        CoreFunctions.enqueue(jobguid, 0);
                    }
                }
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/notificationsadmin.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
        
        private void loadNotificationBoxes(SPSite site, string sOptedOutUsers)
        {
            try
            {
                //-- EPML 1901 --
                lstNotificationOptInUsers.Items.Clear();
                lstNotificationOptedOutUsers.Items.Clear();

                //populate the OptIn user list with ALL site users (non System Account)
                foreach (SPUser u in site.RootWeb.SiteUsers)
                {
                    if (u.Name != "System Account")
                    {
                        string user = u.Name;
                        if (u.Email != "")
                            user += " (" + u.Email + ")";
                        ListItem li = new ListItem(user, u.ID.ToString());
                        lstNotificationOptInUsers.Items.Add(li);
                    }
                }

                //populate the Opted-out user list
                string[] arrOptedOutUsers = sOptedOutUsers.Split('|');
                foreach (string sUser in arrOptedOutUsers)
                {
                    if (sUser.Trim().Length > 0)
                    {
                        string[] sUserIDNameSplit = sUser.Replace("#", "").Split(';');

                        try
                        {
                            SPUser u = site.RootWeb.SiteUsers.GetByID(int.Parse(sUserIDNameSplit[0].Trim()));
                            string user = string.Empty;
                            if (u != null)
                            {
                                user = u.Name;
                                if (u.Email != string.Empty)
                                    user += " (" + u.Email + ")";
                            }

                            ListItem li = new ListItem(user, sUserIDNameSplit[0].Trim());
                            lstNotificationOptedOutUsers.Items.Add(li);

                            //If the OptedOut user is present in OptIn list then remove it
                            ListItem liOptedOutUser =  lstNotificationOptInUsers.Items.FindByValue(li.Value);
                            if (liOptedOutUser != null) lstNotificationOptInUsers.Items.Remove(liOptedOutUser);
                        }
                        catch
                        {
                            //No error logging??
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
        
        private void BindNListsToGrid(string sLists)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SectionName");
            dt.Columns.Add("ListNames");
            dt.Columns.Add("Columns");
            dt.Columns.Add("Query");
            dt.Columns.Add("RNum");

            string[] arrRow = sLists.Split('\t');
            int rnumCnt = 2; // when rendered, GridView row item count starts at 2
            foreach (string sRow in arrRow)
            {
                if (sRow.Trim() != "")
                {
                    string sSection = "";
                    string sList = "";
                    string sCol = "";
                    string sQuery = "";

                    string[] sRowItems = sRow.Split('`');
                    if (sRowItems.Length > 0)
                    {
                        sSection = sRowItems[0];
                    }
                    if (sRowItems.Length > 1)
                    {
                        sList = sRowItems[1];
                    }
                    if (sRowItems.Length > 2)
                    {
                        sCol = sRowItems[2];
                    }
                    if (sRowItems.Length > 3)
                    {
                        sQuery = sRowItems[3];
                    }

                    dt.Rows.Add(new string[] { sSection, sList, sCol, sQuery, rnumCnt.ToString() });
                    rnumCnt++;
                }
            }

            gvNotificationLists.DataSource = dt;
            gvNotificationLists.DataBind();

        }

        protected void gvNotificationLists_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtListNames = (TextBox)e.Row.FindControl("txtListNames");
                string sListNames = DataBinder.Eval(e.Row.DataItem, "ListNames").ToString();
                txtListNames.Text = sListNames;
                string[] arListNames = sListNames.Split('\r');
                int cnt = 0;
                foreach (string name in arListNames)
                {
                    cnt++;
                }
                txtListNames.Height = cnt * 16;
                //txtListNames.Width = sListNames.Length * 15;

                TextBox txtColumns = (TextBox)e.Row.FindControl("txtColumns");
                string sCols = DataBinder.Eval(e.Row.DataItem, "Columns").ToString();
                txtColumns.Text = sCols;
                string[] arCols = sCols.Split('\r');
                cnt = 0; // reset
                foreach (string name in arCols)
                {
                    cnt++;
                }
                txtColumns.Height = cnt * 16;
                //txtColumns.Width = sCols.Length * 15;

                TextBox txtQuery = (TextBox)e.Row.FindControl("txtQuery");
                string sQry = DataBinder.Eval(e.Row.DataItem, "Query").ToString();
                txtQuery.Text = sQry;
                string[] arQry = sQry.Split('\r');
                cnt = 0; // reset
                foreach (string name in arQry)
                {
                    cnt++;
                }
                txtQuery.Height = txtColumns.Height;
                txtQuery.Wrap = true;
            }
        }

        private void AddNewPageList()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    foreach (GridViewRow dr in gvNotificationLists.Rows)
                    {
                        AddList(dr.Cells[0].Text, dr.Cells[1].Text, dr.Cells[2].Text, dr.Cells[3].Text);
                    }
                });
            }
            catch
            {
            }
        }

        private void AddList(string sSection, string sLists, string sCols, string sQueries)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    SPWeb currWeb = SPContext.Current.Web;
                    {

                        string sNList = "";
                        sNList += sSection + "`" + sLists + "`" + sCols + "`" + sQueries + "\t";

                        if(currWeb.Properties.ContainsKey("EPMLiveNotificationLists"))
                        {
                            // property exists already -> update it
                            string sNewVal = currWeb.Properties["EPMLiveNotificationLists"] + sNList;
                            currWeb.Properties["EPMLiveNotificationLists"] = sNewVal;
                        }
                        else
                        {
                            // property doesn't exist -> add it if there is value to set
                            currWeb.Properties.Add("EPMLiveNotificationLists", sNList + Properties.Resources.txtFileDefaultSections);
                        }

                        currWeb.Properties.Update();
                    }
                });
            }
            catch
            {
            }
        }

        private void EditList(string sSection, string sLists, string sCols, string sQueries)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPSite site = SPContext.Current.Site;
                    SPWeb currWeb = SPContext.Current.Web;
                    {
                        currWeb.AllowUnsafeUpdates = true;
                        if(currWeb.Properties.ContainsKey("EPMLiveNotificationLists"))
                        {
                            string sNList = currWeb.Properties["EPMLiveNotificationLists"];
                            if(sNList.Contains(sSection))
                            {
                                int iTabDlmtrLocation = sNList.IndexOf("\t", sNList.IndexOf(sSection) + sSection.Length) + 1;
                                string sEditedList = sSection + "`" + sLists + "`" + sCols + "`" + sQueries + "\t";
                                string sNewVal;
                                if(iTabDlmtrLocation > 0) // has more
                                {
                                    sNewVal = sNList.Replace(sNList.Substring(sNList.IndexOf(sSection), iTabDlmtrLocation - sNList.IndexOf(sSection)), sEditedList);
                                }
                                else // last one
                                {
                                    sNewVal = sNList.Replace(sNList.Substring(sNList.IndexOf(sSection), sNList.Length - sNList.IndexOf(sSection)), sEditedList); // remove to the end
                                }
                                currWeb.Properties["EPMLiveNotificationLists"] = sNewVal;
                            }

                            currWeb.Properties.Update();
                        }
                    }
                });
            }
            catch
            {
            }
        }

        private void DeleteList(string sSection)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPSite site = SPContext.Current.Site;
                    SPWeb currWeb = SPContext.Current.Web;
                    {
                        currWeb.AllowUnsafeUpdates = true;
                        string sNList = currWeb.Properties["EPMLiveNotificationLists"];
                        if(sNList.Contains(sSection))
                        {
                            int iPipeLocation = sNList.IndexOf("\t", sNList.IndexOf(sSection) + sSection.Length) + 1;
                            string sNewVal;
                            if(iPipeLocation > 0) // has more
                            {
                                sNewVal = sNList.Remove(sNList.IndexOf(sSection), sNList.Substring(sNList.IndexOf(sSection), iPipeLocation - sNList.IndexOf(sSection)).Length);
                            }
                            else // last one
                            {
                                sNewVal = sNList.Remove(sNList.IndexOf(sSection)); // remove to the end
                            }
                            currWeb.Properties["EPMLiveNotificationLists"] = sNewVal;
                        }

                        currWeb.Properties.Update();
                        Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/notificationsadmin.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                    }
                });
            }
            catch
            {
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList arrDel = new ArrayList();
                //-- EPML 1901
                foreach (ListItem li in lstNotificationOptInUsers.Items)
                {
                    if (li.Selected)
                    {
                        lstNotificationOptedOutUsers.Items.Add(li);
                        arrDel.Add(li);
                    }
                }
                foreach (ListItem li in arrDel)
                    lstNotificationOptInUsers.Items.Remove(li);
                //-- End EPML 1901
            }
            catch
            {
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                //-- EPML 1901
                ArrayList arrDel = new ArrayList();
                foreach (ListItem li in lstNotificationOptedOutUsers.Items)
                {
                    if (li.Selected)
                    {
                        lstNotificationOptInUsers.Items.Add(li);
                        arrDel.Add(li);
                    }
                }
                foreach (ListItem li in arrDel)
                    lstNotificationOptedOutUsers.Items.Remove(li);
                //-- End EPML 1901
            }
            catch
            {
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            saveSettings();

            if(!String.IsNullOrEmpty(Request["Source"]))
            {
                Response.Redirect(Request["Source"]);
            }
            else
            {
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("settings.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

        private void saveSettings()
        {
            try
            {
                SPWeb w = SPContext.Current.Web;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using(SPSite site = new SPSite(w.Site.ID))
                    {
                        using(SPWeb currWeb = site.OpenWeb(w.ID))
                        {
                            currWeb.AllowUnsafeUpdates = true;
                            string sEmail = txtFromEmail.Text;
                            if(currWeb.Properties.ContainsKey("EPMLiveNotificationEmail"))
                            {
                                // property exists already -> update it
                                currWeb.Properties["EPMLiveNotificationEmail"] = sEmail;
                            }
                            else if(sEmail.Length > 0)
                            {
                                // property doesn't exist -> add it if there is value to set
                                currWeb.Properties.Add("EPMLiveNotificationEmail", sEmail);
                            }

                            string sEmailSubject = txtEmailSubject.Text;
                            if(currWeb.Properties.ContainsKey("EPMLiveNotificationEmailSubject"))
                            {
                                // property exists already -> update it
                                currWeb.Properties["EPMLiveNotificationEmailSubject"] = sEmailSubject;
                            }
                            else if(sEmailSubject.Length > 0)
                            {
                                // property doesn't exist -> add it if there is value to set
                                currWeb.Properties.Add("EPMLiveNotificationEmailSubject", sEmailSubject);
                            }

                            string sTime = ddlRunTime.SelectedValue;

                            SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(currWeb.Site.WebApplication.Id));

                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                cn.Open();
                            });

                            SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=3", cn);
                            cmd.Parameters.AddWithValue("@siteguid", currWeb.Site.ID.ToString());
                            SqlDataReader dr = cmd.ExecuteReader();
                            if(dr.Read())
                            {
                                dr.Close();
                                cmd = new SqlCommand("UPDATE TIMERJOBS set runtime = @runtime where siteguid=@siteguid and jobtype=3", cn);
                                cmd.Parameters.AddWithValue("@siteguid", currWeb.Site.ID.ToString());
                                cmd.Parameters.AddWithValue("@runtime", ddlRunTime.SelectedValue);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                dr.Close();
                                cmd = new SqlCommand("INSERT INTO TIMERJOBS (siteguid, jobtype, jobname, runtime, scheduletype, webguid) VALUES (@siteguid, 3, 'Notifications', @runtime, 2, @webguid)", cn);
                                cmd.Parameters.AddWithValue("@siteguid", currWeb.Site.ID.ToString());
                                cmd.Parameters.AddWithValue("@webguid", currWeb.ID.ToString());
                                cmd.Parameters.AddWithValue("@runtime", ddlRunTime.SelectedValue);
                                cmd.ExecuteNonQuery();
                            }

                            cn.Close();
                            //if (currWeb.Properties.ContainsKey("EPMLiveNotificationTime"))
                            //{
                            //    // property exists already -> update it
                            //    currWeb.Properties["EPMLiveNotificationTime"] = sTime;
                            //}
                            //else
                            //{
                            //    // property doesn't exist -> add it if there is value to set
                            //    currWeb.Properties.Add("EPMLiveNotificationTime", sTime);
                            //}

                            string sNotes = txtNotes.Text;
                            if(currWeb.Properties.ContainsKey("EPMLiveNotificationNote"))
                            {
                                // property exists already -> update it
                                currWeb.Properties["EPMLiveNotificationNote"] = sNotes;
                            }
                            else if(sNotes.Length > 0)
                            {
                                // property doesn't exist -> add it if there is value to set
                                currWeb.Properties.Add("EPMLiveNotificationNote", sNotes);
                            }

                            //-- EPML 1901
                            //string sNotificationOptedOutUsers = string.Empty;
                            StringBuilder sNotificationOptedOutUsers = new StringBuilder(string.Empty);
                            foreach(ListItem li in lstNotificationOptedOutUsers.Items)
                            {
                                //sNotificationOptedOutUsers += li.Value + ";#" + li.Text + "|";
                                sNotificationOptedOutUsers.Append(li.Value);
                                sNotificationOptedOutUsers.Append(";#");
                                sNotificationOptedOutUsers.Append(li.Text);
                                sNotificationOptedOutUsers.Append("|");
                            }
                            if (currWeb.Properties.ContainsKey("EPMLiveNotificationOptedOutUsers"))
                            {
                                // property exists already -> update it
                                currWeb.Properties["EPMLiveNotificationOptedOutUsers"] = sNotificationOptedOutUsers.ToString();
                            }
                            else if (sNotificationOptedOutUsers.Length > 0)
                            {
                                // property doesn't exist -> add it if there is value to set
                                currWeb.Properties.Add("EPMLiveNotificationOptedOutUsers", sNotificationOptedOutUsers.ToString());
                            }

                            if(!currWeb.Properties.ContainsKey("EPMLiveNotificationLists")) // new site. settings not configured. use resource txt file
                            {
                                currWeb.Properties.Add("EPMLiveNotificationLists", Properties.Resources.txtFileDefaultSections);
                            }

                            currWeb.Properties.Update();
                        }
                    }
                });
                {
                                        
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}
