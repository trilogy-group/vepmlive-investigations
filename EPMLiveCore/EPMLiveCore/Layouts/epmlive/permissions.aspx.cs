using System;
using System.Data;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class permissions : LayoutsPageBase
    {
        private DataTable _groups;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            SPSite site = SPContext.Current.Site;
            {
                SPWeb web = SPContext.Current.Web;
                {
                    _groups = ConfigureGroupsData(web);
                    PopulateGvSelect(site, web);
                }
            }
        }

        private DataTable GetSpUsers(DataView dv, SPWeb web)
        {
            DataTable spUsers = new DataTable("SPUsers");
            spUsers.Columns.Add("Name");
            spUsers.Columns.Add("LoginName");
            spUsers.Columns.Add("Email");
            foreach (DataRowView rowView in dv)
            {
                SPFieldUserValue fuv = new SPFieldUserValue(web, rowView["SharePointAccount"].ToString());
                spUsers.Rows.Add((fuv.User == null)
                                     ? new object[] { rowView["Title"].ToString(), "", "" }
                                     : new object[] { fuv.User.Name, fuv.User.LoginName, fuv.User.Email });
            }
            return spUsers;
        }

        private void PopulateGvSelect(SPSite site, SPWeb web)
        {

            DataView resources;
            string resUrl = CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL");

            if (resUrl.StartsWith("/"))
            {
                using (SPWeb resWeb = site.OpenWeb(resUrl))
                {
                    SPList resList = resWeb.Lists[CoreFunctions.getConfigSetting(resWeb, "EPMLiveResourcePool")];
                    DataQueryFactory dqf = new DataQueryFactory();
                    dqf.ListIds.Add(resList.ID);
                    dqf.ViewFields.Add("Title");
                    //dqf.ViewFields.Add("ID");
                    dqf.ViewFields.Add("SharePointAccount");
                    resources = resWeb.GetSiteData(dqf.DataQuery).DefaultView;
                }
            }
            else
            {
                using (SPSite resSite = new SPSite(resUrl))
                {
                    using (SPWeb resWeb = resSite.OpenWeb())
                    {
                        SPList resList = resWeb.Lists[CoreFunctions.getConfigSetting(resWeb, "EPMLiveResourcePool")];
                        DataQueryFactory dqf = new DataQueryFactory();
                        dqf.ListIds.Add(resList.ID);
                        dqf.ViewFields.Add("Title");
                        //dqf.ViewFields.Add("ID");
                        dqf.ViewFields.Add("SharePointAccount");
                        resources = resWeb.GetSiteData(dqf.DataQuery).DefaultView;
                    }
                }
            }

            resources.RowFilter = GetClause(Request.QueryString["Resources"]);

            if (resources.Count == 0)
            {
                LblNoUsers.Visible = true;
                return;
            }

            DataTable spUsers = GetSpUsers(resources, web);

            //GvSelect.Columns[4].Visible = true;
            GvSelect.DataSource = spUsers;
            GvSelect.DataBind();
            GvSelect.Columns[4].Visible = false;
        }

        private string GetClause(string resources)
        {
            string[] users = resources.Trim(',').Split(',');

            string clause = "";
            foreach (string user in users)
            {
                if (clause != "")
                    clause += " or ";
                clause += "ID = " + user;
            }
            return clause;
        }

        private DataTable ConfigureGroupsData(SPWeb web)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("key");
            dt.Rows.Add("No Access", "");

            foreach (SPGroup group in web.Groups)
            {
                if (group.CanCurrentUserEditMembership)
                {
                    dt.Rows.Add(group.Name, group.Name);
                }
            }
            return dt;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            CheckBox chk = (CheckBox)e.Row.FindControl("chkChange");

            DropDownList l = (DropDownList)e.Row.FindControl("ddlGroup");

            if (((DataRowView)e.Row.DataItem).Row[1].ToString() == "")
            {
                chk.Enabled = false;
                e.Row.Cells[2].Text = "<em>No account associated with this user.</em>";
                l.Visible = false;
                return;
            }
            else
            {
                l.DataTextField = "name";
                l.DataValueField = "key";
                l.DataSource = _groups;
                l.DataBind();
            }



            chk.Attributes.Add("onclick", string.Format("Javascript:chk('{0}','{1}');", chk.UniqueID, e.Row.Cells[2].Text));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            foreach (GridViewRow gr in GvSelect.Rows)
            {
                string username = GvSelect.DataKeys[gr.DataItemIndex].Value.ToString();
                if (username == "")
                    continue;

                string groupName = ((DropDownList)gr.Cells[3].Controls[1]).SelectedValue;

                SPUser user = null;
                bool good = false;
                try
                {
                    user = web.AllUsers[username];
                    good = true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        if ("User cannot be found." == ex.Message)
                        {
                            web.AllUsers.Add(username, gr.Cells[2].Text, gr.Cells[1].Text, "");
                            user = web.AllUsers[username];
                            good = true;
                        }
                    }
                    catch
                    {
                        good = false;
                    }
                }
                if (good)
                {
                    bool hasGroup = false;
                    foreach (SPGroup group in user.Groups)
                    {
                        string g = "";
                        try
                        {
                            g = web.Groups[group.Name].Name;
                            hasGroup = true;
                        }
                        catch (Exception ex)
                        {
                            Trace.Write(string.Format("{0} {1}", g, ex.Message));
                        }
                    }

                    try
                    {
                        web.Groups[groupName].AddUser(user);
                    }
                    catch (Exception ex)
                    {
                        Trace.Write(ex.Message);
                    }

                    if (!hasGroup)
                    {
                        //accounts.Service accts = new accounts.Service();
                        //if (ConfigurationManager.AppSettings["acctsUrl"] != null)
                        //    accts.Url = ConfigurationManager.AppSettings["acctsUrl"];
                        //accts.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["username"].ToString(), System.Configuration.ConfigurationManager.AppSettings["password"].ToString(), System.Configuration.ConfigurationManager.AppSettings["domain"].ToString());

                        //emailservice.Service eService = new emailservice.Service();
                        //if (ConfigurationManager.AppSettings["emailUrl"] != null)
                        //    eService.Url = ConfigurationManager.AppSettings["emailUrl"];
                        //eService.UseDefaultCredentials = true;
                        //bool ret = eService.sendEmail(2, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", user.Email, new string[] { accts.getName(), web.Url, web.Title, user.LoginName });
                    }
                }
            }
            
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/SitePermissions.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/SitePermissions.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/addusers.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }
    }
}