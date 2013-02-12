using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class sitepermissions : LayoutsPageBase
    {
        protected string account_ref;
        protected Guid accountid;


        protected string quantity;
        protected string strBarColor;
        protected string strWidth;
        protected string version;
        protected string weburl;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb mySite = SPContext.Current.Web;
            weburl = mySite.Url;

            //pnlAddUser.Visible = false;


            if (!IsPostBack)
            {
                fillData(mySite.Site);
            }


            lblTitle.Text = "Manage Site Permissions";
            //pnlCounter.Visible = false;
            //pnlBuild.Visible = true;
            //pnlAddUser.Visible = false;


            bool canEdit = false;

            foreach (SPGroup group in mySite.Groups)
            {
                if (group.CanCurrentUserEditMembership)
                {
                    canEdit = true;
                    break;
                }
            }

            if (!canEdit)
            {
                //pnlBuild.Visible = false;
                GridView1.Columns[4].Visible = false;
            }

            //mySite.Close();
        }

        private void fillData(SPSite site)
        {
            SPWeb web = SPContext.Current.Web;

            bool bCanUserEditAGroup = false;

            foreach (SPGroup group in web.Groups)
            {
                if (group.CanCurrentUserEditMembership)
                {
                    bCanUserEditAGroup = true;
                }
            }

            if (bCanUserEditAGroup)
            {
                fillSubData(web);
                //web.Close();
            }
            else
            {
                //web.Close();
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("accessdenied.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

        private void fillSubData(SPWeb web)
        {
            lblDesc.Text =
                "The Site Members list below displays users that have access to this Workspace.  You can edit their permissions or remove them from this site by using the links below.";

            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add("name");
            ds.Tables[0].Columns.Add("email");
            ds.Tables[0].Columns.Add("group");
            ds.Tables[0].Columns.Add("username");
            ds.Tables[0].Columns.Add("uid");

            Hashtable tblUsers = new Hashtable();

            foreach (SPUser user in web.AllUsers)
            {
                if (user.IsSiteAdmin)
                {
                    tblUsers.Add(user.ID, user.Name + "\n" + user.Email + "\n" + user.LoginName + "\nSite Collection Administrator");
                }
            }
            foreach (SPGroup group in web.Groups)
            {
                if (group.CanCurrentUserViewMembership)
                {
                    foreach (SPUser user in group.Users)
                    {
                        if (tblUsers.Contains(user.ID))
                        {
                            string val = tblUsers[user.ID].ToString();
                            tblUsers[user.ID] = val + "<br>" + group.Name;
                        }
                        else
                        {
                            tblUsers.Add(user.ID, user.Name + "\n" + user.Email + "\n" + user.LoginName + "\n" + group.Name);
                        }
                    }
                }
            }


            foreach (DictionaryEntry entry in tblUsers)
            {
                string[] vals = entry.Value.ToString().Split('\n');
                ds.Tables[0].Rows.Add(vals[0], vals[1], vals[3], vals[2], vals[2]);
            }

            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = "name";

            GridView1.DataSource = dv.Table;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SPWeb web = SPContext.Current.Web;

                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton2");
                string cmd = l.CommandArgument;

                l = (LinkButton)e.Row.FindControl("LinkButton1");
                if (l.CommandArgument.ToUpper() == hdnUserId.Value.ToUpper())
                    l.Visible = false;


                l.Attributes.Add("onclick",
                                 string.Format("javascript:return confirm('Are you sure you want to delete {0} from your site?')", DataBinder.Eval(e.Row.DataItem, "name")));

                l.CommandArgument = cmd;

                //web.Close();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //lblError.Visible = false;
            //lblSuccess.Visible = false;
            if (e.CommandName == "Del")
            {
                SPWeb web = SPContext.Current.Web;

                SPUser user = web.AllUsers[e.CommandArgument.ToString().Replace("\\\\", "\\")];
                foreach (SPGroup group in web.Groups)
                {
                    if (group.CanCurrentUserEditMembership)
                    {
                        try
                        {
                            group.RemoveUser(user);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                string url = web.Url;
                //web.Close();
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/sitepermissions.aspx?", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
            if (e.CommandName == "Edi")
            {


                SPWeb mySite = SPContext.Current.Web;

                pnlEdit.Visible = true;
                pnl.Visible = false;
                string username = e.CommandArgument.ToString().Replace("\\\\", "\\");

                HiddenUsername.Value = username;
                try
                {
                    lblName.Text = mySite.AllUsers[username].Name;
                    lblUsername.Text = username;
                    lblEmail.Text = mySite.AllUsers[username].Email;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

                if (mySite.UserIsSiteAdmin)
                {
                    if (mySite.AllUsers[username].IsSiteAdmin)
                        pnlGroups.Controls.Add(
                            new LiteralControl(
                                "<input type=\"checkbox\" name=\"Groups\" checked value=\"@\"> Site Collection Administrator"));
                    else
                        pnlGroups.Controls.Add(
                            new LiteralControl(
                                "<input type=\"checkbox\" name=\"Groups\" value=\"@\"> Site Collection Administrator"));
                    pnlGroups.Controls.Add(new LiteralControl("<br>"));
                }


                SPUser user = mySite.AllUsers[username];
                foreach (SPGroup g in mySite.Groups)
                {
                    string group = g.Name;
                    bool canEdit = mySite.SiteGroups[group].CanCurrentUserEditMembership;
                    bool found = false;
                    foreach (SPGroup ugroup in user.Groups)
                    {
                        if (ugroup.Name == group)
                            found = true;
                    }
                    if (found)
                        if (canEdit)
                            pnlGroups.Controls.Add(
                                new LiteralControl("<input type=\"checkbox\" name=\"Groups\" checked value=\"" + group +
                                                   "\">" + group));
                        else
                            pnlGroups.Controls.Add(
                                new LiteralControl("<input type=\"checkbox\" name=\"Groups\" checked value=\"" + group +
                                                   "\" disabled>" + group));
                    else if (canEdit)
                        pnlGroups.Controls.Add(
                            new LiteralControl("<input type=\"checkbox\" name=\"Groups\" value=\"" + group + "\">" +
                                               group));
                    else
                        pnlGroups.Controls.Add(
                            new LiteralControl("<input type=\"checkbox\" name=\"Groups\" value=\"" + group +
                                               "\" disabled>" + group));
                    pnlGroups.Controls.Add(new LiteralControl("<br>"));
                }
               // mySite.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;
            SPWeb mySite = SPContext.Current.Web;
            mySite.AllowUnsafeUpdates = true;

            pnlEdit.Visible = false;
            GridView1.Visible = true;
            Hashtable myHash = new Hashtable();
            SPUser user = mySite.AllUsers[HiddenUsername.Value];


            bool hasGroup = false;
            bool addGroup = false;
            foreach (SPGroup group in user.Groups)
            {
                try
                {
                    string g = mySite.Groups[group.Name].Name;
                    hasGroup = true;
                }
                catch
                {
                }
            }

            bool setSiteAdmin = false;

            if (Request["Groups"] != null)
            {
                string[] groups = Request["Groups"].Split(',');
                if (groups.Length > 0)
                {
                    foreach (string group in groups)
                    {
                        if (group == "@")
                        {
                            setSiteAdmin = true;
                        }
                        else
                        {
                            try
                            {
                                myHash.Add(group, "");
                                mySite.Groups[group].AddUser(user);
                                addGroup = true;
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }


            foreach (SPGroup g in mySite.SiteGroups)
            {
                string group = g.Name;
                if (mySite.SiteGroups[group].CanCurrentUserEditMembership)
                {
                    if (!myHash.Contains(group))
                    {
                        try
                        {
                            mySite.Groups[group].RemoveUser(user);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            string url = site.Url;

            if (!hasGroup && addGroup)
            {
                //Nick - commented out in order to compile

                //accounts.Service accts = new accounts.Service();
                //if (ConfigurationManager.AppSettings["acctsUrl"] != null)
                //    accts.Url = ConfigurationManager.AppSettings["acctsUrl"];
                //accts.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["username"].ToString(), System.Configuration.ConfigurationManager.AppSettings["password"].ToString(), System.Configuration.ConfigurationManager.AppSettings["domain"].ToString());

                //emailservice.Service eService = new emailservice.Service();
                //if (ConfigurationManager.AppSettings["emailUrl"] != null)
                //    eService.Url = ConfigurationManager.AppSettings["emailUrl"];
                //eService.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["username"].ToString(), System.Configuration.ConfigurationManager.AppSettings["password"].ToString(), System.Configuration.ConfigurationManager.AppSettings["domain"].ToString());
                //bool ret = eService.sendEmail(2, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", user.Email, new string[] { accts.getName(), mySite.Url, mySite.Title, user.LoginName });
            }

            if (mySite.UserIsSiteAdmin)
            {
                if (setSiteAdmin)
                {
                    user.IsSiteAdmin = true;
                    user.Update();
                }
                else
                {
                    user.IsSiteAdmin = false;
                    user.Update();
                }
            }

            //site.Close();
            url = mySite.Url;
            //mySite.Close();
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/sitepermissions.aspx?", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SPWeb mySite = SPContext.Current.Web;
            string url = mySite.Url;
            //mySite.Close();

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/sitepermissions.aspx?", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }
    }
}